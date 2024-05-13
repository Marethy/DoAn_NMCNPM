using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using DTO;
using BUL;
using QuanLiBanVang.ExtendClass;
using QuanLiBanVang.Properties;

namespace QuanLiBanVang
{
    public partial class DanhSachPGC : DevExpress.XtraEditors.XtraForm
    {
        private BUL_PhieuGiaCong _bulPhieuGiaCong;
        private BUL_NhanVien _bulNhanVien;
        private BUL_Tho _bulTho;
        private DataColumn _keyField;
        private DataTable _dataTable;
        private MyCache _cache = new MyCache("IDcache");
        private List<PHIEUGIACONG> _listPgc;
        public DanhSachPGC()
        {
            InitializeComponent();
            _bulNhanVien = new BUL_NhanVien();
            _bulTho = new BUL_Tho();
            CreateDataTable();
        }
        private void CreateDataTable()
        {
            _bulPhieuGiaCong = new BUL_PhieuGiaCong();
            _dataTable = new DataTable();
            _keyField = _dataTable.Columns.Add("IDcache", typeof(int));
            _keyField.ReadOnly = true;
            _keyField.AutoIncrement = true;
            _dataTable.Columns.Add("SoPhieuGC", typeof(int));
            _dataTable.Columns.Add("TenTho", typeof(string));
            _dataTable.Columns.Add("TenNV", typeof(string));
            _dataTable.Columns.Add("NgayNhanHang", typeof(DateTime));
            _dataTable.Columns.Add("NgayThanhToan", typeof(DateTime));
            _dataTable.Columns.Add("TongTien", typeof(decimal));
            gridControlDSPGC.DataSource = _dataTable;
            gridViewDSPGC.Columns[0].Visible = 
            gridViewDSPGC.Columns[1].Visible = false;
            gridViewDSPGC.Columns[2].Caption = Resources.TenTho;
            gridViewDSPGC.Columns[3].Caption = Resources.TenNV;
            gridViewDSPGC.Columns[4].Caption = Resources.NgayNhanHang;
            gridViewDSPGC.Columns[5].Caption = Resources.NgayThanhToan;
            gridViewDSPGC.Columns[6].Caption = Resources.TongTien;
            gridViewDSPGC.OptionsMenu.EnableColumnMenu = false;
        }
        private string GetTenTho(int id)
        {
            return _bulTho.GetWorkerById(id).TenTho;
        }
        private string GetTenNv(int id)
        {
            return _bulNhanVien.getStaffById(id).HoTen;
        }
        private void FillDataTable()
        {
            _dataTable.Rows.Clear();
            _listPgc = _bulPhieuGiaCong.GetAllPhieuGiaCong();
            foreach (PHIEUGIACONG t in _listPgc)
            {
                _dataTable.Rows.Add(new object[] { 
                    null,
                    t.SoPhieuGC, 
                    GetTenTho(t.MaTho),
                    GetTenNv(t.MaNV),
                    t.NgayNhanHang,
                    t.NgayThanhToan,
                    Math.Round(t.TongTien)});
            }
            gridControlDSPGC.DataSource = _dataTable;
        }
        private void simpleButtonAdd_Click(object sender, EventArgs e)
        {
            NhapPhieuGiaCong_Form nhap = new NhapPhieuGiaCong_Form();
            DialogResult result = nhap.ShowDialog();
            if(result == DialogResult.OK)
                FillDataTable();
        }

        private void simpleButtonEdit_Click(object sender, EventArgs e)
        {
            OpenEditDialog();            
        }

        private void simpleButtonDel_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show(Resources.DetailMessageBox_XacNhanXoa, Resources.TitleMessageBox_ThongBao,
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if(dialogResult == DialogResult.OK)
            {
                DataRow currentRow = gridViewDSPGC.GetDataRow(gridViewDSPGC.FocusedRowHandle);
                _bulPhieuGiaCong.DeletePhieuGiaCong(Convert.ToInt32(currentRow[1]));
                FillDataTable();
            }
        }

        private void simpleButtonThoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void gridViewDSPDV_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            if (e.IsGetData)
                e.Value = _cache.getValue(e.Row);
            if (e.IsSetData)
                _cache.setValue(e.Row, e.Value);
        }

        private void gridViewDSPDV_DoubleClick(object sender, EventArgs e)
        {
            OpenEditDialog();  
        }
        private void OpenEditDialog()
        {
            DataRow currentRow = gridViewDSPGC.GetDataRow(gridViewDSPGC.FocusedRowHandle);
            if (currentRow != null)
            {
                SuaPhieuGiaCong_Form sua = new SuaPhieuGiaCong_Form(Convert.ToInt32(currentRow[1]));
                DialogResult result = sua.ShowDialog();
                if (result == DialogResult.OK)
                {
                    _bulPhieuGiaCong = null;
                    _bulPhieuGiaCong = new BUL_PhieuGiaCong();
                    FillDataTable();
                }                
            }
        }

        private void DanhSachPDV_Load(object sender, EventArgs e)
        {
            FillDataTable();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenEditDialog();
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            simpleButtonDel_Click(sender,e);
        }

        private void gridViewDSPDV_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            if (e.MenuType == DevExpress.XtraGrid.Views.Grid.GridMenuType.Row)
                popupMenu1.ShowPopup(MousePosition);
        }

        private void simpleButtonLamMoi_Click(object sender, EventArgs e)
        {
            FillDataTable();
        }
    }
}