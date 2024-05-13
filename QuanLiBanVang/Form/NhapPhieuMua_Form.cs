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

namespace QuanLiBanVang.Report
{
    public partial class NhapPhieuMua_Form : DevExpress.XtraEditors.XtraForm
    {
       // private DataColumn _keyField;
        private ExtendClass.MyCache _myCache;

        private DataTable _detailTable;
        private BUL.BUL_CTPM _bulBuyDetail;
        private BUL.BUL_PhieuMua _bulBuyBill;
        private BUL.BUL_SanPham _bulProduct;
        private BUL.BUL_LoaiSanPham _bulProductType;
        private BUL.BUL_KhachHang _bulClient;

        private int _staffId;
        public NhapPhieuMua_Form()
        {
            InitializeComponent();
            _myCache = new ExtendClass.MyCache("Id");
            _bulBuyBill = new BUL.BUL_PhieuMua();
            _bulBuyDetail = new BUL.BUL_CTPM();
            _bulProduct = new BUL.BUL_SanPham();
            _bulProductType = new BUL.BUL_LoaiSanPham();
            _bulClient = new BUL.BUL_KhachHang();
            _detailTable = new DataTable();
        }
        public NhapPhieuMua_Form(int staffid)
        {
            InitializeComponent();
            _myCache = new ExtendClass.MyCache("Id");
            _bulBuyBill = new BUL.BUL_PhieuMua();
            _bulBuyDetail = new BUL.BUL_CTPM();
            _bulProduct = new BUL.BUL_SanPham();
            _bulProductType = new BUL.BUL_LoaiSanPham();
            _bulClient = new BUL.BUL_KhachHang();
            _detailTable = new DataTable();
            _staffId = staffid;
        }
        public void createTable()
        {
            _detailTable.Columns.Add("ProductId",typeof(int));
            _detailTable.Columns.Add("ProductTypeId", typeof(int));
            _detailTable.Columns.Add("Tên sản phẩm", typeof(string));
            _detailTable.Columns.Add("Loại sản phẩm", typeof(string));
            _detailTable.Columns.Add("Số lượng", typeof(int));
            _detailTable.Columns.Add("Trọng lượng", typeof(float));
            _detailTable.Columns.Add("Giá mua", typeof(decimal));
            _detailTable.Columns.Add("Thành tiền", typeof(decimal));
        }
        public void addNewRowToDataTable(DTO.CTPMH buydetail, string product, string producttype)
        {
            var datarow = _detailTable.NewRow();
            if (buydetail.MaSP != null)
            {
                datarow[0] = buydetail.MaSP;
            }
            if (buydetail.MaLoaiSP != null)
            {
                datarow[1] = buydetail.MaLoaiSP;
            }
            datarow[2] = product;
            datarow[3] = producttype;
            datarow[4] = buydetail.SoLuong;
            datarow[5] = buydetail.TrongLuong;
            datarow[6] = Math.Round(buydetail.GiaMua).ToString();
            datarow[7] = Math.Round(buydetail.Thanhtien).ToString();
            _detailTable.Rows.Add(datarow);
        }
        private void dgvBuy_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            if (e.IsGetData)
            {
                e.Value = _myCache.getValue(e.Row);
            }
            if (e.IsSetData)
            {
                _myCache.setValue(e.Row, e.Value);
            }
        }

        private void rdoClientType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.rdoClientType.SelectedIndex == 0)
            {
                this.cboClientName.Enabled = false;
                this.cboClientName.SelectedIndex = -1;
                this.lblPhoneNumber.Text = "(Không có)";

            }
            else
            {
                this.cboClientName.Enabled = true;
                //this.lblPhoneNumber.Text = ((this.cboClientName.SelectedItem as ExtendClass.ContainerItem).Value as DTO.KHACHHANG).SDT;
            }
        }
        private bool checkLegalDetail()
        {
            if (this.txtWeight.Text == "")
                return false;
            if (txtPrice.Text == "")
                return false;
            if (txtPrice.Text == "")
                return false;
            if (txtQuantity.Text == "")
                return false;
            return true;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!checkLegalDetail())
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DTO.CTPMH detail = new DTO.CTPMH();
            string product ="";
            string producttype = "";
            if (this.cboProduct.SelectedIndex != -1 && this.cboProduct.SelectedIndex != 0)
            {
                detail.MaSP = ((this.cboProduct.SelectedItem as ExtendClass.ContainerItem).Value as DTO.SANPHAM).MaSP;
                product = ((this.cboProduct.SelectedItem as ExtendClass.ContainerItem).Value as DTO.SANPHAM).TenSP;
            }
            if (this.cboProductType.SelectedIndex != -1 && this.cboProductType.SelectedIndex != 0)
            {
                detail.MaLoaiSP = ((this.cboProductType.SelectedItem as ExtendClass.ContainerItem).Value as DTO.LOAISANPHAM).MaLoaiSP;
                producttype = ((this.cboProductType.SelectedItem as ExtendClass.ContainerItem).Value as DTO.LOAISANPHAM).TenLoaiSP;
            }
            detail.TrongLuong = float.Parse(txtWeight.Text);
            detail.SoLuong = int.Parse(txtQuantity.Text);
            detail.GiaMua = decimal.Parse(txtPrice.Text);
            detail.Thanhtien = (decimal)(detail.SoLuong * detail.GiaMua);
            this.addNewRowToDataTable(detail, product, producttype);
            
            decimal total = decimal.Parse(lbTotal.Text);
            total += Math.Round((decimal)detail.Thanhtien);
            this.lbTotal.Text = total.ToString();
        }

        private void NhapPhieuMua_Form_Load(object sender, EventArgs e)
        {
            
            this.dtpkCreateDate.Properties.MinValue = DateTime.Now;
            this.dtpkCreateDate.Properties.MaxValue = DateTime.Now;
            this.dtpkCreateDate.EditValue = DateTime.Now;
            this.dtpkCreateDate.ReadOnly = true;
            if (this.rdoClientType.SelectedIndex == 0)
            {
                this.cboClientName.Enabled = false;
            }
            List<DTO.SANPHAM> listproduct = _bulProduct.getAllProduct();
            List<DTO.LOAISANPHAM> listproducttype = _bulProductType.getAllProductType();
            List<DTO.KHACHHANG> listclient = _bulClient.GetAllKhachhangs();
            ExtendClass.ContainerItem noneItem = new ExtendClass.ContainerItem();
            noneItem.Text = "";
            noneItem.Value = "";
            this.cboProduct.Properties.Items.Add(noneItem);
            this.cboProductType.Properties.Items.Add(noneItem);
            foreach (DTO.SANPHAM i in listproduct)
            {
                ExtendClass.ContainerItem item = new ExtendClass.ContainerItem();
                item.Text = i.TenSP;
                item.Value = i;
                this.cboProduct.Properties.Items.Add(item);
            }
            foreach (DTO.LOAISANPHAM i in listproducttype)
            {
                ExtendClass.ContainerItem item = new ExtendClass.ContainerItem();
                item.Text = i.TenLoaiSP;
                item.Value = i;
                this.cboProductType.Properties.Items.Add(item);
            }
            foreach (DTO.KHACHHANG i in listclient)
            {
                ExtendClass.ContainerItem item = new ExtendClass.ContainerItem();
                item.Text = i.TenKH;
                item.Value = i;
                this.cboClientName.Properties.Items.Add(item);
            }
            this.cboProduct.Enabled = false;
            createTable();
            this.dgvBuyList.DataSource = _detailTable;
            this.dgvBuy.Columns[0].Visible = false;
            this.dgvBuy.Columns[1].Visible = false;
            this.lblPhoneNumber.Text = "";
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //if (this.dgvBuy.RowCount > 1)
           // {
                int pos = -1;
                foreach (int i in this.dgvBuy.GetSelectedRows())
                {
                    pos = i;
                    break;
                }
                if (pos != -1)
                {
                    this.dgvBuy.DeleteRow(pos);
                }
           // }
            //else
            //{
               // MessageBox.Show("Không thể xóa! Mỗi phiếu mua phải có ít nhất 1 chi tiết");
               // return;
            //}
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }
        public bool CheckControlValidation()
        {
            if (this.txtPrice.Text == "")
                return false;
            if (this.txtQuantity.Text == "")
                return false;
            if (this.txtWeight.Text == "")
                return false;
            if (this.rdoClientType.SelectedIndex == 1)
            {
                if (this.cboClientName.SelectedIndex == -1)
                    return false;
            }
            
            return true;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (this.dgvBuy.RowCount == 0)
                MessageBox.Show("Không thể lưu phiếu mua! Mỗi phiếu mua phải có ít nhất 1 chi tiết phiếu!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            if (this.CheckControlValidation() == true)
            {
                DTO.PHIEUMUAHANG newBuyBill = new DTO.PHIEUMUAHANG();
                newBuyBill.NgayMua = ((DateTime)dtpkCreateDate.EditValue).Date;
                if (rdoClientType.SelectedIndex == 1)
                {
                    newBuyBill.MaKH = ((cboClientName.SelectedItem as ExtendClass.ContainerItem).Value as DTO.KHACHHANG).MaKH;
                }
                newBuyBill.MaNV = ExtendClass.UserAccess.Instance.GetUserId;
                //newBuyBill.TongTien = decimal.Parse(this.lbTotal.Text);
                this._bulBuyBill.addNewBuyBill(newBuyBill);
                foreach (DataRow i in this._detailTable.Rows)
                {
                    DTO.CTPMH detail = new DTO.CTPMH();

                    if (i[0].ToString() != "")
                    {
                        detail.MaSP = (int)i[0];
                    }
                    if (i[1].ToString() != "")
                    {
                        detail.MaLoaiSP = (int)i[1];
                    }
                    detail.SoPhieuMua = newBuyBill.SoPhieuMua;
                    detail.SoLuong = (int)i[4];
                    detail.TrongLuong = (float)i[5];
                    detail.GiaMua = (decimal)i[6];
                    detail.Thanhtien = (decimal)i[7];
                    this._bulBuyDetail.addNewBuyDetail(detail);
                }
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                MessageBox.Show("Nhập phiếu mua hàng thành công!", "Info", MessageBoxButtons.OK,MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin quy định","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
        }

        private void cboClientName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cboClientName.SelectedItem != null)
            {
                this.lblPhoneNumber.Text = ((this.cboClientName.SelectedItem as ExtendClass.ContainerItem).Value as DTO.KHACHHANG).SDT.ToString();
            }
        }

        private void cboProductType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cboProductType.SelectedIndex == 0)
            {
                this.cboProduct.SelectedIndex = 0;
                this.cboProduct.Enabled = false;
            }
            else
            {
                
                int productTypeid = ((this.cboProductType.SelectedItem as ExtendClass.ContainerItem).Value as DTO.LOAISANPHAM).MaLoaiSP;
                List<DTO.SANPHAM> listProduct = _bulProduct.getProductByProductType(productTypeid);
                this.cboProduct.Properties.Items.Clear();
                ExtendClass.ContainerItem noneItem = new ExtendClass.ContainerItem();
                noneItem.Text = "";
                noneItem.Value = "";
                this.cboProduct.Properties.Items.Add(noneItem);
                this.cboProduct.SelectedIndex = 0;
                foreach (DTO.SANPHAM i in listProduct)
                {
                    ExtendClass.ContainerItem item = new ExtendClass.ContainerItem();
                    item.Text = i.TenSP;
                    item.Value = i;
                    this.cboProduct.Properties.Items.Add(item);
                }
                this.cboProduct.Enabled = true;
            }
        }

        private void cboProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cboProduct.SelectedIndex == 0)
            {
                this.txtWeight.Enabled = true;
                this.txtWeight.Text = "";
            }
            else
            {
                this.txtWeight.Text = ((this.cboProduct.SelectedItem as ExtendClass.ContainerItem).Value as DTO.SANPHAM).TrongLuong.ToString();
                this.txtWeight.Enabled = false;
            }
        }
    }
}