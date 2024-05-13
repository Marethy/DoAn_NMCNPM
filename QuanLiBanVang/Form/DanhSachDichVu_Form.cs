using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using BUL;
using DTO;
using QuanLiBanVang.ExtendClass;
using QuanLiBanVang.Properties;

namespace QuanLiBanVang
{
    public partial class DanhSachDichVu : DevExpress.XtraEditors.XtraForm
    {
        private BUL_DichVu _bulDichVu;
        private DataColumn _keyField;
        private DataTable _dataTable;
        private MyCache _cache = new MyCache("IDcache");
        private List<DICHVU> _listDichvu;

        public DanhSachDichVu()
        {
            InitializeComponent();
            _bulDichVu = new BUL_DichVu();
            CreateDataTable();
            FillGridView();
        }
        private void CreateDataTable()
        {
            _dataTable = new DataTable();
            _keyField = _dataTable.Columns.Add("IDcache", typeof(int));
            _keyField.ReadOnly = true;
            _keyField.AutoIncrement = true;
            _dataTable.Columns.Add("MaDV", typeof(int));
            _dataTable.Columns.Add("TenDV", typeof(string));
            _dataTable.Columns.Add("TienCong", typeof(int));
            gridControlDSDV.DataSource = _dataTable;
            gridViewDSDV.Columns[0].Visible = false;
            gridViewDSDV.Columns[1].Visible = false;
            gridViewDSDV.Columns[2].Caption = Resources.TenDichVu;
            gridViewDSDV.Columns[3].Caption = Resources.TienCong;
            gridViewDSDV.OptionsMenu.EnableColumnMenu = false;
        }

        private void FillGridView()
        {
            _dataTable.Rows.Clear();
            _listDichvu = _bulDichVu.GetAllDichvus();
            foreach (var t in _listDichvu)
            {
                _dataTable.Rows.Add(null, t.MaDV, t.TenDV, t.TienCong);
            }
            gridControlDSDV.DataSource = _dataTable;
        }       

        private void simpleButtonAdd_Click(object sender, EventArgs e)
        {
            NhapDichVu nhap = new NhapDichVu();
            DialogResult dialogResult = nhap.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                FillGridView();
            }
        }

        private void simpleButtonEdit_Click(object sender, EventArgs e)
        {
            DataRow currentRow = gridViewDSDV.GetDataRow(gridViewDSDV.FocusedRowHandle);
            int id = Int32.Parse(currentRow[1].ToString());
            if (id == 2)
            {
                MessageBox.Show(Resources.Cant_edit_DVGC, Resources.TitleMessageBox_Error, MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
            OpenEditDialog();
        }

        private void OpenEditDialog()
        {
            DataRow currentRow = gridViewDSDV.GetDataRow(gridViewDSDV.FocusedRowHandle);
            if (currentRow != null)
            {
                int id = Int32.Parse(currentRow[1].ToString());
                SuaDichVu sua = new SuaDichVu(id);
                DialogResult dialogResult = sua.ShowDialog();
                if (dialogResult == DialogResult.OK)
                {
                    _bulDichVu = null;
                    _bulDichVu = new BUL_DichVu();
                    FillGridView();
                }
            }
        }

        private void simpleButtonDel_Click(object sender, EventArgs e)
        {
            DataRow currentRow = gridViewDSDV.GetDataRow(gridViewDSDV.FocusedRowHandle);
            if (currentRow != null)
            {
                DialogResult result = MessageBox.Show(Resources.DetailMessageBox_XacNhanXoa, Resources.TitleMessageBox_ThongBao,
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Question);
                if (result == DialogResult.OK)
                {
                    int id = Int32.Parse(currentRow[1].ToString());
                    if (id == 2)
                    {
                        MessageBox.Show(Resources.DanhSachDichVu_DelError, Resources.TitleMessageBox_Error, MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        return;
                    }
                    _bulDichVu.DeleteDichVu(id);
                    FillGridView();
                }
            }
        }

        private void simpleButtonThoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void gridViewDSDV_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            if (e.IsGetData)
                e.Value = _cache.getValue(e.Row);
            if (e.IsSetData)
                _cache.setValue(e.Row, e.Value);}

        private void gridViewDSDV_DoubleClick(object sender, EventArgs e)
        {
            simpleButtonEdit_Click(sender,e);
        }

        private void gridViewDSDV_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            if(e.MenuType == DevExpress.XtraGrid.Views.Grid.GridMenuType.Row)
                popupMenu1.ShowPopup(MousePosition);
        }

        private void barButtonItemCapNhat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            simpleButtonEdit_Click(sender, e);
        }

        private void barButtonItemXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            simpleButtonDel_Click(sender,e);
        }

        private void simpleButtonLamMoi_Click(object sender, EventArgs e)
        {
            FillGridView();
        }
    }
}