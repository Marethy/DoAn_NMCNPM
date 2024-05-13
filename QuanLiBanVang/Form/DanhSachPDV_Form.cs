using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Core;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DTO;
using BUL;
using QuanLiBanVang.ExtendClass;
using QuanLiBanVang.Properties;

namespace QuanLiBanVang
{
    public partial class DanhSachPDV : XtraForm
    {
        private BUL_PhieuDichVu _bulPhieuDichVu;
        private List<KHACHHANG> _listKhachhang;
        private List<NHANVIEN> _listNhanvien; 
        private DataColumn _keyField;
        private DataTable _dataTable;
        private MyCache _cache = new MyCache("IDcache");
        private List<PHIEUDICHVU> _listPdv;
        public DanhSachPDV()
        {
            InitializeComponent();
            GetDataNvAndKh();
            CreateDataTable();
        }
        private void CreateDataTable()
        {
            _bulPhieuDichVu = new BUL_PhieuDichVu();
            _dataTable = new DataTable();
            _keyField = _dataTable.Columns.Add("IDcache", typeof(int));
            _keyField.ReadOnly = true;
            _keyField.AutoIncrement = true;
            _dataTable.Columns.Add("SoPhieuDV", typeof(int));
            _dataTable.Columns.Add("TenKH", typeof(string));
            _dataTable.Columns.Add("TenNV", typeof(string));
            _dataTable.Columns.Add("NgayDangKy", typeof(DateTime));
            _dataTable.Columns.Add("NgayGiao", typeof(DateTime));
            _dataTable.Columns.Add("TongTien", typeof(decimal));
            gridControlDSPDV.DataSource = _dataTable;
            gridViewDSPDV.Columns[0].Visible = 
            gridViewDSPDV.Columns[1].Visible = false;
            gridViewDSPDV.Columns[2].Caption = Resources.TenKH;
            gridViewDSPDV.Columns[3].Caption = Resources.TenNV;
            gridViewDSPDV.Columns[4].Caption = Resources.NgayDK;
            gridViewDSPDV.Columns[5].Caption = Resources.NgayGiao;
            gridViewDSPDV.Columns[6].Caption = Resources.TongTien;
            gridViewDSPDV.OptionsMenu.EnableColumnMenu = false;
        }

        private void GetDataNvAndKh()
        {
            BUL_NhanVien bulNhanVien = new BUL_NhanVien();
            BUL_KhachHang bulKhachHang= new BUL_KhachHang();
            _listKhachhang = bulKhachHang.GetAllKhachhangs();
            _listNhanvien = bulNhanVien.getAllStaff();
        }
        private string GetTenKh(int id)
        {
            if (id == 0)
                return "Khách vãng lai";
            return _listKhachhang.Find(i => i.MaKH == id).TenKH;
        }
        private string GetTenNv(int id)
        {
            return _listNhanvien.Find(i => i.MaNV == id).HoTen;
        }
        private void FillDataTable()
        {
            _dataTable.Rows.Clear();
            _listPdv = _bulPhieuDichVu.GetAllPhieuDichVu();
            foreach (PHIEUDICHVU t in _listPdv)
            {
                _dataTable.Rows.Add(new object[] { 
                    null,
                    t.SoPhieuDV, 
                    GetTenKh(t.MaKH??0),
                    GetTenNv(t.MaNV),
                    t.NgayDangKy,
                    t.NgayGiao,
                    Math.Round(t.TongTien)});
            }
            gridControlDSPDV.DataSource = _dataTable;
        }
        private void simpleButtonAdd_Click(object sender, EventArgs e)
        {
            NhapPhieuDichVu nhap = new NhapPhieuDichVu();
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
            DataRow currentRow = gridViewDSPDV.GetDataRow(gridViewDSPDV.FocusedRowHandle);
            if (currentRow != null)
            {
                DialogResult dialogResult = MessageBox.Show(Resources.DetailMessageBox_XacNhanXoa,
                    Resources.TitleMessageBox_ThongBao,
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.OK)
                {
                    try
                    {
                        _bulPhieuDichVu.DeletePhieuDichVu(Convert.ToInt32(currentRow[1]));
                        FillDataTable();
                    }
                    catch (DbUpdateException dbUpdateException)
                    {
                        SqlException eSqlException =
                            ((SqlException) ((UpdateException) dbUpdateException.InnerException).InnerException);
                        if (eSqlException.Message.Contains("FK_CTPGC_ID"))
                            MessageBox.Show(Resources.DanhSachPDV_DelError, Resources.TitleMessageBox_Error,
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
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
            DataRow currentRow = gridViewDSPDV.GetDataRow(gridViewDSPDV.FocusedRowHandle);
            if (currentRow != null)
            {
                SuaPhieuDichVu sua = new SuaPhieuDichVu(Convert.ToInt32(currentRow[1]));
                DialogResult result = sua.ShowDialog();
                if (result == DialogResult.OK)
                {
                    _bulPhieuDichVu = null;
                    _bulPhieuDichVu = new BUL_PhieuDichVu();
                    FillDataTable();
                }                
            }
        }

        private void DanhSachPDV_Load(object sender, EventArgs e)
        {
            FillDataTable();
        }

        private void DanhSachPDV_SizeChanged(object sender, EventArgs e)
        {
            
        }

        private void gridViewDSPDV_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            if (e.MenuType == DevExpress.XtraGrid.Views.Grid.GridMenuType.Row)
                popupMenu1.ShowPopup(MousePosition);
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenEditDialog();
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            simpleButtonDel_Click(sender,e);
        }

        private void simpleButtonLamMoi_Click(object sender, EventArgs e)
        {
            FillDataTable();
        }
    }
}