using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using BUL;
using QuanLiBanVang.ExtendClass;
using QuanLiBanVang.Model;
using DTO;
using System.Collections.ObjectModel;

namespace QuanLiBanVang.Form
{

    public partial class PhieuNhapHang_Form : DevExpress.XtraEditors.XtraForm
    {
        ObservableCollection<ImportItemGridViewDataSource> bindingListDataSource = new ObservableCollection<ImportItemGridViewDataSource>(); // bindlist for gridview
        List<CTPNH> savingList = new List<CTPNH>(); // list to be saved into database
        private decimal total = decimal.Zero;
        private ActionType actionType;
        BUL_PhieuNhapHang bulImportDetail = new BUL_PhieuNhapHang();
        public bool IsFormParentForm { get; set; }

        public int LIMIT_NUMBER_OF_IMPORT_PROFUCTS { get; set; }

        public delegate void RefreshDelegate();
        public RefreshDelegate refreshDelegateCallback;

        public PhieuNhapHang_Form()
        {
            InitializeComponent();
        }

        /// <summary>
        /// member constructor
        /// </summary>
        /// <param name="type"> identify user's intention : view or create new one </param>
        /// <param name="data"> null if the Action Type is null. Otherwise , data will be not null to show to user</param>
        public PhieuNhapHang_Form(ActionType type, PHIEUNHAPHANG data)
        {
            this.InitializeComponent();
            this.actionType = type;
            switch (type)
            {
                // see detail from existed PHIEUNHAPHANG
                case ActionType.ACTION_VIEW:
                    this.showExistingImportDetail(data);
                    break;
                // create new PHIEUNHAPHANG
                case ActionType.ACTION_CREATE_NEW:
                    this.gridControlDanhSachSanPham.DataSource = this.bindingListDataSource; // binding datasource for gridview
                    // load staff information    
                    this.textEditNhanVien.Text = UserAccess.Instance.GetStaffName;

                    // today only
                    this.dateTimePickerNgayNhap.DateTime = DateTime.Now.Date;

                    // set value for LIMIT_NUMBER_OF_IMPORT_PROFUCTS
                    this.LIMIT_NUMBER_OF_IMPORT_PROFUCTS = Convert.ToInt32(new BUL_BangThamSo().getValueByArgument("SoLuongNhapToiDa"));
                    ContainerItem item; // temporary value holder
                    /* [START- set up content for combobox] */
                    foreach (NHACUNGCAP provider in new BUL_NhaCungCap().getAll())
                    {
                        item = new ContainerItem
                        {
                            Text = provider.TenNCC,
                            Value = provider

                        };
                        this.comboBoxEditNhaCungCap.Properties.Items.Add(item);
                    }
                    foreach (LOAISANPHAM productType in new BUL_LoaiSanPham().getAllProductType())
                    {
                        item = new ContainerItem
                        {
                            Text = productType.TenLoaiSP,
                            Value = productType

                        };
                        this.comboBoxEditLoaiSp.Properties.Items.Add(item);
                    }
                    /* [END- set up content for combobox] */
                    break;
                default:
                    break;
            }
        }
        /// <summary>
        /// 
        /// do things when load the form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PhieuNhapHang_Load(object sender, EventArgs e)
        {
            this.renameColumnsOfGridControl(this.actionType);
        }

        private void comboBoxEditLoaiSp_SelectedIndexChanged(object sender, EventArgs e)
        {
            // first , clear the items in comboboxSanPham
            this.comboBoxEditSP.Properties.Items.Clear();
            // load all product coresponding to the selected product type
            ContainerItem selectedItem = (ContainerItem)this.comboBoxEditLoaiSp.SelectedItem;
            LOAISANPHAM selectedProductType = (LOAISANPHAM)selectedItem.Value; // hold value of the selected item
            foreach (SANPHAM item in (new BUL_LoaiSanPham()).getProductsByTypeId(selectedProductType.MaLoaiSP))
            {
                this.comboBoxEditSP.Properties.Items.Add(new ContainerItem
                {
                    Text = item.TenSP,
                    Value = item
                });
            }

            this.comboBoxEditSP.SelectedIndex = 0;
        }

        /// <summary>
        /// save this import receit into database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            // make sure everthing is ready to be saved
            if (this.isValidGeneralInformation())
            {
                ContainerItem selectedItem = (ContainerItem)this.comboBoxEditNhaCungCap.SelectedItem;
                NHACUNGCAP provider = (NHACUNGCAP)selectedItem.Value;
                // start to save
                PHIEUNHAPHANG newImportReceipt = new PHIEUNHAPHANG
                {
                    MaNCC = provider.MaNCC,
                    NgayNhap = this.dateTimePickerNgayNhap.DateTime.Date,
                    MaNV = UserAccess.Instance.GetUserId,
                    TongTien = this.total,
                    //NHACUNGCAP = provider,
                    // ignore some fields


                };
                newImportReceipt = this.bulImportDetail.add(newImportReceipt); // save the receipt

                foreach (ImportItemGridViewDataSource item in this.bindingListDataSource)
                {
                    this.savingList.Add(new CTPNH
                    {
                        SoPhieuNhap = newImportReceipt.SoPhieuNhap,
                        MaSP = item.MaSp,
                        SoLuong = item.SoLuong,
                        ThanhTien = item.ThanhTien,
                        GiaMua = item.GiaMua
                    });
                }
                new BUL_CTPNH().addRange(this.savingList); // save the list of detail
                // notify user that the work is done
                DialogResult dialogResult = MessageBox.Show(NotificationMessage.MESSAGE_SAVING_JOB_DONE,
                    NotificationMessage.MESSAGE_TITLE,
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (dialogResult == System.Windows.Forms.DialogResult.OK)
                {
                    if (this.IsFormParentForm)
                    {
                        this.refreshDelegateCallback();
                    }
                    this.Close();
                }
            }
        }

        private void xóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.bindingListDataSource.Count == 0) { return; }// exit method if the binding datasource list is empty
            // delete the focused row of gridview
            this.bindingListDataSource.RemoveAt(this.gridViewDanhSachSanPham.FocusedRowHandle);
            // update stt
            for (int i = 0; i < this.bindingListDataSource.Count; ++i)
            {
                this.bindingListDataSource[i].STT = i;
            }
            this.gridViewDanhSachSanPham.RefreshData();
            // update total
            this.updateTotal();
        }

        #region ------------------------- PRIVATE METHOD ---------------------------------------
        /// <summary>
        /// check wheather content of view components is valid or not 
        /// </summary>
        /// <returns>
        /// true if all content is valid. Otherwise , return false
        /// </returns>
        private bool isValidImportViewData()
        {
            if (!string.IsNullOrEmpty(this.comboBoxEditLoaiSp.Text)
                && !string.IsNullOrEmpty(this.comboBoxEditSP.Text)
            && !string.IsNullOrEmpty(this.textEditSoLuong.Text)
            && !string.IsNullOrEmpty(this.textEditGiaMua.Text))
            {
                // MessageBox.Show(ErrorMessage.CLIENT_INVALID_INPUT_MESSAGE, ErrorMessage.ERROR_MESSARE_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (!string.IsNullOrEmpty(this.textEditSoLuong.Text) && int.Parse(this.textEditSoLuong.Text) > LIMIT_NUMBER_OF_IMPORT_PROFUCTS)
                {
                    MessageBox.Show(ErrorMessage.OVER_LIMITATION_FOR_IMPORTING + "\n .Tối đa số lượng cho mỗi sản phẩm là " + LIMIT_NUMBER_OF_IMPORT_PROFUCTS, ErrorMessage.ERROR_MESSARE_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false; // exit method
                }
                return true;
            }

            string listOfErrors = string.Empty;
            if (string.IsNullOrEmpty(this.comboBoxEditLoaiSp.Text))
            {
                listOfErrors += "Loại SP còn trống \n";
            }
            if (string.IsNullOrEmpty(this.comboBoxEditSP.Text))
            {
                listOfErrors += "SP còn trống \n";
            }
            if (string.IsNullOrEmpty(this.textEditSoLuong.Text))
            {
                listOfErrors += "Số lượng còn trống \n";
            }
            if (string.IsNullOrEmpty(this.textEditGiaMua.Text))
            {
                listOfErrors += "Giá mua còn trống \n";
            }
            MessageBox.Show(listOfErrors, ErrorMessage.ERROR_MESSARE_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }

        /// <summary>
        /// check whether general information of this receipt is valid
        /// </summary>
        /// <returns>
        /// true if information is valid, otherwise , return false;
        /// </returns>
        private bool isValidGeneralInformation()
        {
            if (this.bindingListDataSource.Count == 0)
            {
                MessageBox.Show(ErrorMessage.NO_DETALI_FOR_RECEIPT, ErrorMessage.ERROR_MESSARE_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (string.IsNullOrEmpty(this.comboBoxEditNhaCungCap.Text))
            {
                MessageBox.Show(ErrorMessage.CLIENT_INVALID_INPUT_MESSAGE, ErrorMessage.ERROR_MESSARE_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }


        private void updateTotal()
        {

            this.total = decimal.Zero;
            foreach (ImportItemGridViewDataSource element in this.bindingListDataSource)
            {
                this.total = decimal.Add(this.total, element.ThanhTien);
            }
            // update textedit
            this.textEditTongTien.Text = this.total.ToString();
        }


        private void updateItemFromDelegate(ImportItemGridViewDataSource item)
        {
            // check existence
            if (this.bindingListDataSource.Any(x => x.MaSp == item.MaSp && x.STT != item.STT))
            {
                MessageBox.Show(ErrorMessage.EXISTED_PRODUCT_MESSAGE, ErrorMessage.ERROR_MESSARE_TITLE + ". Vui lòng kiểm tra lại.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                this.bindingListDataSource[item.STT] = item;
                this.updateTotal();
            }
        }
        /// <summary>
        /// show detail of an existed PHIEUNHAPHANG
        /// </summary>
        /// <param name="data"> desired PHIEUBANHANG to be shown detal</param>
        private void showExistingImportDetail(PHIEUNHAPHANG data)
        {
            // general information
            //this.textEditSoPhieuNhap.Text = data.SoPhieuNhap.ToString();
            // this.textEditSoPhieuNhap.Enabled = false;
            this.textEditNhanVien.Text = data.NHANVIEN.HoTen.ToString();
            this.textEditNhanVien.Enabled = true;
            this.textEditNhanVien.ReadOnly = true;

            this.textEditTongTien.Text = data.TongTien.ToString();
            this.textEditTongTien.Enabled = true;
            this.textEditTongTien.ReadOnly = true;
            // date time
            this.dateTimePickerNgayNhap.DateTime = data.NgayNhap;
            this.dateTimePickerNgayNhap.Enabled = true;
            this.dateTimePickerNgayNhap.ReadOnly = true;
            // provider
            this.comboBoxEditNhaCungCap.Text = data.NHACUNGCAP.TenNCC;
            this.comboBoxEditNhaCungCap.ReadOnly = true;

            // disable conext strip menu to prevent user from modifying data
            this.gridViewContextMenuStrip.Enabled = false;
            // binding data 
            this.gridControlDanhSachSanPham.DataSource = new BUL_CTPNH().get(data);
            // all unimformative columns will be invisible
            this.gridViewDanhSachSanPham.Columns[5].Visible = false;
            this.gridViewDanhSachSanPham.Columns[6].Visible = false;

            this.simpleButtonThem.Enabled = false;

            // disable save , update , delete buttons
            this.simpleButtonSave.Enabled = false;
            this.simpleButtonSave.Visible = false;
            this.simpleButtonSua.Enabled = false;
            this.simpleButtonXoa.Enabled = false;


            // disable combobox
            this.comboBoxEditLoaiSp.Enabled = false;
            this.comboBoxEditSP.Enabled = false;
            this.textEditSoLuong.Enabled = false;
            this.textEditGiaMua.Enabled = false;

        }
        #endregion

        private void sửaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.bindingListDataSource.Count == 0) { return; }// exit if the binding datasource list is empty
            ImportItemGridViewDataSource focusedItem = (ImportItemGridViewDataSource)this.gridViewDanhSachSanPham.GetRow(this.gridViewDanhSachSanPham.FocusedRowHandle);

            UpdateImportDetailltem updateImportDetailItemForm = new UpdateImportDetailltem(focusedItem, this.gridViewDanhSachSanPham.FocusedRowHandle);
            updateImportDetailItemForm.sendBack = new UpdateImportDetailltem.SendBackDataDelegate(this.updateItemFromDelegate);
            updateImportDetailItemForm.ShowDialog();

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            // close the form
            this.Close();
        }

        /// <summary>
        ///  add new record into gridview, as well as add new item of the list to be saved into database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void simpleButton3_Click_1(object sender, EventArgs e)
        {
            // at first , check content of View (ComboxboxEdit and TextEdit)
            if (!this.isValidImportViewData())
            {
                return; // exit method
            }
            ContainerItem selectedItem = (ContainerItem)this.comboBoxEditSP.SelectedItem;
            SANPHAM selectedProduct = (SANPHAM)selectedItem.Value;
            // make sure that we have no duplicated elements
            if (this.bindingListDataSource.Any(x => x.MaSp == selectedProduct.MaSP))
            {
                MessageBox.Show(ErrorMessage.EXISTED_PRODUCT_MESSAGE, ErrorMessage.ERROR_MESSARE_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // exit method
            }
            else
            {
                // otherwise, instace new element
                ImportItemGridViewDataSource newElement = new ImportItemGridViewDataSource
                {
                    STT = this.bindingListDataSource.Count,
                    LoaiSanPham = this.comboBoxEditLoaiSp.Text,
                    MaSp = selectedProduct.MaSP,
                    TenSp = selectedProduct.TenSP,
                    SoLuong = Int32.Parse(this.textEditSoLuong.Text.Trim()),
                    GiaMua = Math.Round(decimal.Parse(this.textEditGiaMua.Text.Trim()))
                };
                // update cost
                newElement.ThanhTien = newElement.SoLuong * newElement.GiaMua;
                this.bindingListDataSource.Add(newElement); //add into list
                // this.gridControl1.RefreshDataSource();
                // update total
                this.updateTotal();
            }
        }

        private void dateTimePicker1_EditValueChanged(object sender, EventArgs e)
        {
            if (DateTime.Compare(this.dateTimePickerNgayNhap.DateTime.Date, DateTime.Now.Date) < 0)
            {
                MessageBox.Show(ErrorMessage.TODAY_ONLY_FOR_SELLING_DATE, ErrorMessage.ERROR_MESSARE_TITLE,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.dateTimePickerNgayNhap.DateTime = DateTime.Now;
            }
        }

        private void simpleButtonSua_Click(object sender, EventArgs e)
        {
            if (this.bindingListDataSource.Count == 0) { return; }// exit if the binding datasource list is empty
            ImportItemGridViewDataSource focusedItem = (ImportItemGridViewDataSource)this.gridViewDanhSachSanPham.GetRow(this.gridViewDanhSachSanPham.FocusedRowHandle);

            UpdateImportDetailltem updateImportDetailItemForm = new UpdateImportDetailltem(focusedItem, this.gridViewDanhSachSanPham.FocusedRowHandle);
            updateImportDetailItemForm.sendBack = new UpdateImportDetailltem.SendBackDataDelegate(this.updateItemFromDelegate);
            updateImportDetailItemForm.ShowDialog();
        }

        private void simpleButtonXoa_Click(object sender, EventArgs e)
        {
            if (this.bindingListDataSource.Count == 0) { return; }// exit method if the binding datasource list is empty
            // delete the focused row of gridview
            this.bindingListDataSource.RemoveAt(this.gridViewDanhSachSanPham.FocusedRowHandle);
            // update stt
            for (int i = 0; i < this.bindingListDataSource.Count; ++i)
            {
                this.bindingListDataSource[i].STT = i;
            }
            this.gridViewDanhSachSanPham.RefreshData();
            // update total
            this.updateTotal();
        }


        private void renameColumnsOfGridControl(ActionType actionType)
        {
            if (actionType == ActionType.ACTION_CREATE_NEW)
            {
                this.gridViewDanhSachSanPham.Columns[0].Caption = "Số TT";
                this.gridViewDanhSachSanPham.Columns[1].Caption = "Loại sản phẩm";
                this.gridViewDanhSachSanPham.Columns[2].Caption = "Mã sản phẩm";
                this.gridViewDanhSachSanPham.Columns[3].Caption = "Tên sản phẩm";
                this.gridViewDanhSachSanPham.Columns[4].Caption = "Số lượng";
                this.gridViewDanhSachSanPham.Columns[5].Caption = "Giá mua";
                this.gridViewDanhSachSanPham.Columns[6].Caption = "Thành tiền";
            }
            else
            {
                this.gridViewDanhSachSanPham.Columns[0].Caption = "Số phiếu nhập";
                this.gridViewDanhSachSanPham.Columns[1].Caption = "Mã sản phẩm";
                this.gridViewDanhSachSanPham.Columns[2].Caption = "Số lượng";
                this.gridViewDanhSachSanPham.Columns[3].Caption = "Giá mua";
                this.gridViewDanhSachSanPham.Columns[4].Caption = "Thành tiền";
            }
        }
    }
}