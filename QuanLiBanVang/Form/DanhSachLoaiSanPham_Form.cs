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
    public partial class DanhSachLoaiSanPham_Form : DevExpress.XtraEditors.XtraForm
    {
        private ExtendClass.MyCache _myCache;
        private DataColumn _keyField;

        private BUL.BUL_LoaiSanPham _bulProductType;
        private DataTable _productTypeTable;
        private void createTable()
        {
            _productTypeTable = new DataTable();
            _keyField = _productTypeTable.Columns.Add("Id", typeof(int));
            _keyField.ReadOnly = true;
            _keyField.AutoIncrement = true;
            _productTypeTable.Columns.Add("Loại sản phẩm", typeof(string));
            _productTypeTable.Columns.Add("Phần trăm lợi nhuận(%)", typeof(float));
        }
        private void addNewRowToDataTable(DTO.LOAISANPHAM producttype)
        {
            var datarow = _productTypeTable.NewRow();
            datarow[0] = producttype.MaLoaiSP;
            datarow[1] = producttype.TenLoaiSP;
            datarow[2] = producttype.PhanTramLoiNhuan *100;

            _productTypeTable.Rows.Add(datarow);
        }
        private void updateRowInDatatable(int index, DTO.LOAISANPHAM producttype)
        {
            _productTypeTable.Rows[index][1] = producttype.TenLoaiSP;
            _productTypeTable.Rows[index][2] = producttype.PhanTramLoiNhuan*100;

            this.dgvProductType.RefreshRow(index);


        }
        public DanhSachLoaiSanPham_Form()
        {
            InitializeComponent();
            this._bulProductType = new BUL.BUL_LoaiSanPham();
            
        }

        private void gridViewProductType_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            if (e.IsGetData)
                e.Value = _myCache.getValue(e.Row);
            if (e.IsSetData)
                _myCache.setValue(e.Row, e.Value);
        }
        private void initTableData(List<DTO.LOAISANPHAM> listproducttype)
        {
            foreach (DTO.LOAISANPHAM i in listproducttype)
            {
                this.addNewRowToDataTable(i);
            }
        }
        private void DanhSachLoaiSanPham_Form_Load(object sender, EventArgs e)
        {
            List<DTO.LOAISANPHAM> _listProductType = _bulProductType.getAllProductType();
            this.createTable();
            this.initTableData(_listProductType);
            this.dgvListProductType.DataSource = this._productTypeTable;
            this.dgvProductType.Columns[0].Visible = false;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            NhapLoaiSanPham_Form _addNewForm = new NhapLoaiSanPham_Form();
            DialogResult result = _addNewForm.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                DTO.LOAISANPHAM newType = _bulProductType.getLastProduct();
                this.addNewRowToDataTable(newType);
                this.dgvListProductType.Update();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DataRow row = null;
            int pos = -1;
            foreach (int i in dgvProductType.GetSelectedRows())
            {
                row = dgvProductType.GetDataRow(i);
                pos = i;
                break;
            }
            if (row != null)
            {
                DialogResult dresult = MessageBox.Show("Bạn có chắc muốn xóa loại sản phẩm này?", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (dresult == System.Windows.Forms.DialogResult.OK)
                {
                    if (!_bulProductType.deleteProductType((int)row[0]))
                    {
                        MessageBox.Show("Không thể xóa loại sản phẩm đang kinh doanh!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        this.dgvProductType.DeleteRow(pos);
                        MessageBox.Show("Xóa loại sản phẩm thành công!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            DataRow row = null;
            int pos = -1;
            foreach (int i in dgvProductType.GetSelectedRows())
            {
                row = dgvProductType.GetDataRow(i);
                pos = i;
                break;
            }
            if (row != null)
            {
                SuaLoaiSanPham_Form _updateTypeForm = new SuaLoaiSanPham_Form((int)row[0]);
                DialogResult result = _updateTypeForm.ShowDialog();
                if (result == System.Windows.Forms.DialogResult.OK)
                {
                    _bulProductType = null;
                    _bulProductType = new BUL.BUL_LoaiSanPham();
                    DTO.LOAISANPHAM updatetype = _bulProductType.getProductTypeById((int)row[0]);
                    this.updateRowInDatatable(pos,updatetype);
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            _bulProductType = null;
            _bulProductType = new BUL.BUL_LoaiSanPham();
            List<DTO.LOAISANPHAM> _listProductType = _bulProductType.getAllProductType();
            this._productTypeTable.Rows.Clear();
            this.initTableData(_listProductType);
            this.dgvListProductType.DataSource = this._productTypeTable;
        }

        private void barButtonItemCapNhat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            btnUpdate_Click(sender, e);
        }

        private void barButtonItemXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            btnDelete_Click(sender,e);
        }

        private void dgvProductType_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            if (e.MenuType == DevExpress.XtraGrid.Views.Grid.GridMenuType.Row)
                popupMenu1.ShowPopup(MousePosition);
        }

    }
}