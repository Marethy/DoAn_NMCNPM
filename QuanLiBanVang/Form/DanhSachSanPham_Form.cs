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
using System.Data;
using DevExpress.XtraGrid.Columns;
namespace QuanLiBanVang.Report
{
    public partial class DanhSachSanPham_Form : DevExpress.XtraEditors.XtraForm
    {
        private BUL.BUL_SanPham _bulProduct;
        private BUL.BUL_LoaiSanPham _bulProductType;

        private DataColumn _keyField;
        private DataTable _productTable;
        private ExtendClass.MyCache _myCache;
        public DanhSachSanPham_Form()
        {
            InitializeComponent();
            _bulProductType = new BUL.BUL_LoaiSanPham();
            _bulProduct = new BUL.BUL_SanPham();
            _myCache = new ExtendClass.MyCache("Id");
        }
        private void createTable()
        {
            _productTable = new System.Data.DataTable();
            _keyField = _productTable.Columns.Add("Id", typeof(int));
            _keyField.ReadOnly = true;
            _keyField.AutoIncrement = true;
            _productTable.Columns.Add("Tên sản phẩm", typeof(string));
            _productTable.Columns.Add("Loại sản phẩm", typeof(string));
            _productTable.Columns.Add("Số lượng tồn", typeof(int));
            _productTable.Columns.Add("Giá mua", typeof(decimal));
            _productTable.Columns.Add("Trọng lượng", typeof(float));
            _productTable.Columns.Add("Tình trạng", typeof(string));
            
        }
        private void addNewRowToDataTable(DTO.SANPHAM product, string producttype)
        {
            var datarow = _productTable.NewRow();
            datarow[0] = product.MaSP;
            datarow[1] = product.TenSP;
            datarow[2] = producttype;
            datarow[3] = product.SoLuongTon;
            datarow[4] = Math.Round(product.GiaMua).ToString();
            datarow[5] = product.TrongLuong;
            if (product.TinhTrang == true)
            {
                datarow[6] = "Đang bán";
            }
            else
            {
                datarow[6] = "Tạm ngừng bán";
            }
            _productTable.Rows.Add(datarow);
        }
        private void initTableData(List<DTO.SANPHAM> listproduct, List<DTO.LOAISANPHAM> listproducttype)
        {
            foreach (DTO.SANPHAM i in listproduct)
            {
                foreach (DTO.LOAISANPHAM j in listproducttype)
                {
                    if (j.MaLoaiSP == i.MaLoaiSP)
                    {
                        decimal price = i.GiaMua;
                        this.addNewRowToDataTable(i,j.TenLoaiSP);
                        break;
                    }
                }
            }
        }
        private void DanhSachSanPham_Form_Load(object sender, EventArgs e)
        {
            
            List<DTO.SANPHAM> _listProduct = new List<DTO.SANPHAM>();
            _listProduct = _bulProduct.getAllProduct();
            List<DTO.LOAISANPHAM> _listProductType = new List<DTO.LOAISANPHAM>();
            _listProductType = _bulProductType.getAllProductType();
            this.createTable();
            this.initTableData(_listProduct, _listProductType);
            this.dgvListProduct.DataSource = this._productTable;
            //this.dgvProduct.Columns[0].Visible = false;
        }

        private void dgvProduct_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            if (e.IsGetData)
                e.Value = _myCache.getValue(e.Row);
            if (e.IsSetData)
                _myCache.setValue(e.Row, e.Value);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            NhapSanPham_Form addProduct = new NhapSanPham_Form();
            DialogResult result = addProduct.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                DTO.SANPHAM newProduct = _bulProduct.getLastProduct();
                this.addNewRowToDataTable(newProduct, _bulProductType.getProductTypeNameById(newProduct.MaLoaiSP));
                this.dgvListProduct.Update();
            }
        }
        private void updateRowInDatatable(int index, DTO.SANPHAM product, string producttype)
        {
            //_productTable.
            _productTable.Rows[index][1] = product.TenSP;
            _productTable.Rows[index][2] = producttype;
            _productTable.Rows[index][3] = product.SoLuongTon;
            _productTable.Rows[index][4] = Math.Round(product.GiaMua).ToString();
            _productTable.Rows[index][5] = product.TrongLuong;
            if (product.TinhTrang == true)
            {
                _productTable.Rows[index][6] = "Đang bán";
            }
            else
            {
                _productTable.Rows[index][6] = "Tạm ngừng bán";
            }
 
          
            this.dgvProduct.RefreshRow(index);
            
            
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            DataRow row = null;
            int pos = 0;
            foreach (int i in this.dgvProduct.GetSelectedRows())
            {
                row = this.dgvProduct.GetDataRow(i);
                pos = i;
                break;

            }
            if (row != null)
            {
                //delete 
                DialogResult dresult = MessageBox.Show("Bạn có chắc muốn xóa sản phẩm này không?", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (dresult == System.Windows.Forms.DialogResult.OK)
                {
                    if (!this._bulProduct.deleteProduct((int)row[0]))
                    {
                        MessageBox.Show("Không thể xóa loại sản phẩm đang dùng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Xóa sản phẩm thành công!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.dgvProduct.DeleteRow(pos);
                    }
                }
                
            }
            
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            DataRow row = null;
            int pos = 0;
            foreach (int i in this.dgvProduct.GetSelectedRows())
            {
                row = this.dgvProduct.GetDataRow(i);
                pos = i;
                break;

            }
            if (row != null)
            {
                SuaSanPham_Form updateProductForm = new SuaSanPham_Form((int)row[0]);
                DialogResult result = updateProductForm.ShowDialog();
                if (result == System.Windows.Forms.DialogResult.OK)
                {
                    _bulProduct = null;
                    _bulProduct = new BUL.BUL_SanPham();
                    DTO.SANPHAM  product = _bulProduct.getProductById((int)row[0]);
                    this.updateRowInDatatable(pos, product, _bulProductType.getProductTypeNameById(product.MaLoaiSP));

                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            _bulProduct = null;
            _bulProduct = new BUL.BUL_SanPham();
            _bulProductType = null;
            _bulProductType = new BUL.BUL_LoaiSanPham();
            List<DTO.SANPHAM> _listProduct = new List<DTO.SANPHAM>();
            _listProduct = _bulProduct.getAllProduct();
            List<DTO.LOAISANPHAM> _listProductType = new List<DTO.LOAISANPHAM>();
            _listProductType = _bulProductType.getAllProductType();
            this._productTable.Rows.Clear();
            this.initTableData(_listProduct, _listProductType);
            this.dgvListProduct.DataSource = this._productTable;
        }

        private void barButtonItemCapNhat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            btnUpdate_Click(sender,e);
        }

        private void barButtonItemXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            btnDelete_Click(sender,e);
        }

        private void dgvProduct_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            if (e.MenuType == DevExpress.XtraGrid.Views.Grid.GridMenuType.Row)
                popupMenu1.ShowPopup(MousePosition);
        }

  
    }
}