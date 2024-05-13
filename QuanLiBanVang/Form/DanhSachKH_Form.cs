using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Core;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Windows.Forms;
using BUL;
using DTO;
using QuanLiBanVang.ExtendClass;
using QuanLiBanVang.Properties;

namespace QuanLiBanVang
{
    public partial class DanhSachKH : DevExpress.XtraEditors.XtraForm
    {
        private BUL_KhachHang _bulKhachHang;
        private DataColumn _keyFeild;
        private DataTable _dataTable;
        private MyCache _cache = new MyCache("IDcache");
        private List<KHACHHANG> _listKhachhang;
        public DanhSachKH()
        {
            InitializeComponent();
            _bulKhachHang = new BUL_KhachHang();
            CreateDataTable();
            FillGridView();
            
        }

        private void FillGridView()
        {
            _dataTable.Rows.Clear();
            _listKhachhang = _bulKhachHang.GetAllKhachhangs();
            foreach (KHACHHANG t in _listKhachhang)
            {
                _dataTable.Rows.Add(new object[] { null, t.MaKH, t.TenKH, t.SDT, t.DiaChi, t.SoTienNo });
            }
            gridControlDSKH.DataSource = _dataTable;
        }

        private void CreateDataTable()
        {
            _dataTable = new DataTable();
            _keyFeild = _dataTable.Columns.Add("IDcache", typeof (int));
            _keyFeild.ReadOnly = true;
            _keyFeild.AutoIncrement = true;
            _dataTable.Columns.Add("MaKH", typeof (int));
            _dataTable.Columns.Add("TenKH", typeof (string));
            _dataTable.Columns.Add("SDT", typeof (string));
            _dataTable.Columns.Add("DiaChi", typeof (string));
            _dataTable.Columns.Add("SoTienNo", typeof (int));      
            gridControlDSKH.DataSource = _dataTable;
            gridViewDSKH.Columns[0].Visible = false;
            gridViewDSKH.Columns[1].Visible = false;
            gridViewDSKH.Columns[2].Caption = Resources.TenKH;
            gridViewDSKH.Columns[3].Caption = Resources.SDT;
            gridViewDSKH.Columns[4].Caption = Resources.DiaChi;
            gridViewDSKH.Columns[5].Caption = Resources.SoTienNo;
            gridViewDSKH.OptionsMenu.EnableColumnMenu = false;
        }

        private void gridViewDSKH_CustomUnboundColumnData(object sender,
            DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            if (e.IsGetData)
                e.Value = _cache.getValue(e.Row);
            if (e.IsSetData)
                _cache.setValue(e.Row, e.Value);
        }

        private void simpleButtonThem_Click(object sender, EventArgs e)
        {
            NhapKhachHang nhap = new NhapKhachHang();
            DialogResult result = nhap.ShowDialog();
            if (result == DialogResult.OK)
            {
                FillGridView();
            }

        }

        private void simpleButtonSua_Click(object sender, EventArgs e)
        {
            OpenEditDialog();
        }

        private void OpenEditDialog()
        {
            DataRow currentRow = gridViewDSKH.GetDataRow(gridViewDSKH.FocusedRowHandle);
            if (currentRow != null)
            {
                int id = Int32.Parse(currentRow[1].ToString());
                SuaKhachHang sua = new SuaKhachHang(id);
                DialogResult dialogResult = sua.ShowDialog();
                if (dialogResult == DialogResult.OK)
                {
                    _bulKhachHang = null;
                    _bulKhachHang = new BUL_KhachHang();
                    FillGridView();
                }
            }
        }
        private void simpleButtonXoa_Click(object sender, EventArgs e)
        {
            DataRow currentRow = gridViewDSKH.GetDataRow(gridViewDSKH.FocusedRowHandle);
            if (currentRow != null)
            {
                DialogResult result = MessageBox.Show(Resources.DetailMessageBox_XacNhanXoa,Resources.TitleMessageBox_ThongBao,
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Question);
                if (result == DialogResult.OK)
                {
                    int id = Int32.Parse(currentRow[1].ToString());
                    try
                    {
                        _bulKhachHang = null;
                        _bulKhachHang = new BUL_KhachHang();
                        _bulKhachHang.DeleteKhachHang(id);
                        FillGridView();
                    }
                    catch (DbUpdateException dbUpdateException)
                    {
                        SqlException eSqlException = ((SqlException)((UpdateException)dbUpdateException.InnerException).InnerException);
                        if (eSqlException.Message.Contains("FK_PDV_KH"))
                            MessageBox.Show(Resources.DanhSachKH_DelError,Resources.TitleMessageBox_Error,
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    
                }
            }
        }
        private void simpleButtonThoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void gridViewDSKH_DoubleClick(object sender, EventArgs e)
        {
            OpenEditDialog();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenEditDialog();
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            simpleButtonXoa_Click(sender,e);
        }

        private void gridViewDSKH_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            if (e.MenuType == DevExpress.XtraGrid.Views.Grid.GridMenuType.Row)
                popupMenu1.ShowPopup(MousePosition);
        }

        private void simpleButtonLamMoi_Click(object sender, EventArgs e)
        {
            FillGridView();
        }
    }
}