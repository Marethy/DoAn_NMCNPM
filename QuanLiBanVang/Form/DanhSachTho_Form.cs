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
    public partial class DanhSachTho : DevExpress.XtraEditors.XtraForm
    {
        private BUL_Tho _bulTho;
        private DataColumn _keyFeild;
        private DataTable _dataTable;
        private MyCache _cache = new MyCache("IDcache");
        private List<THO> _listTho;
        public DanhSachTho()
        {
            InitializeComponent();
            _bulTho = new BUL_Tho();
            CreateDataTable();
            FillGridView();
            
        }

        private void simpleButtonThem_Click(object sender, EventArgs e)
        {
            NhapTho nhap = new NhapTho();
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
            DataRow currentRow = gridViewDSTho.GetDataRow(gridViewDSTho.FocusedRowHandle);
            if (currentRow != null)
            {
                int id = Int32.Parse(currentRow[1].ToString());
                SuaTho sua = new SuaTho(id);
                DialogResult dialogResult = sua.ShowDialog();
                if (dialogResult == DialogResult.OK)
                {
                    _bulTho = null;
                    _bulTho = new BUL_Tho();
                    FillGridView();
                }
            }
        }

        private void simpleButtonXoa_Click(object sender, EventArgs e)
        {
            DataRow currentRow = gridViewDSTho.GetDataRow(gridViewDSTho.FocusedRowHandle);
            if (currentRow != null)
            {
                DialogResult result = MessageBox.Show(Resources.DetailMessageBox_XacNhanXoa, Resources.TitleMessageBox_ThongBao,
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Question);
                if (result == DialogResult.OK)
                {
                    int id = Int32.Parse(currentRow[1].ToString());
                    try
                    {
                        _bulTho = null;
                        _bulTho = new BUL_Tho();
                        _bulTho.DeleteWorker(id);
                        FillGridView();
                    }
                    catch (DbUpdateException dbUpdateException)
                    {
                        SqlException eSqlException =
                            ((SqlException)((UpdateException)dbUpdateException.InnerException).InnerException);
                        if (eSqlException.Message.Contains("FK_PGC_THO"))
                            MessageBox.Show(Resources.DanhSachTho_DelError, Resources.TitleMessageBox_Error,
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void simpleButtonThoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void gridViewDSTho_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            if (e.IsGetData)
                e.Value = _cache.getValue(e.Row);
            if (e.IsSetData)
                _cache.setValue(e.Row, e.Value);
        }
        private void FillGridView()
        {
            _dataTable.Rows.Clear();
            _listTho = _bulTho.GetAllWorkerList();
            foreach (THO t in _listTho)
            {
                _dataTable.Rows.Add(new object[] { null, t.MaTho, t.TenTho, t.SDT, t.DiaChi });
            }
            gridControlDSTho.DataSource = _dataTable;
        }

        private void CreateDataTable()
        {
            _dataTable = new DataTable();
            _keyFeild = _dataTable.Columns.Add("IDcache", typeof(int));
            _keyFeild.ReadOnly = true;
            _keyFeild.AutoIncrement = true;
            _dataTable.Columns.Add("MaTho", typeof(int));
            _dataTable.Columns.Add("TenTho", typeof(string));
            _dataTable.Columns.Add("SDT", typeof(string));
            _dataTable.Columns.Add("DiaChi", typeof(string));
            gridControlDSTho.DataSource = _dataTable;
            gridViewDSTho.Columns[0].Visible = false;
            gridViewDSTho.Columns[1].Visible = false;
            gridViewDSTho.Columns[2].Caption = Resources.TenTho;
            gridViewDSTho.Columns[3].Caption = Resources.SDT;
            gridViewDSTho.Columns[4].Caption = Resources.DiaChi;
            gridViewDSTho.OptionsMenu.EnableColumnMenu = false;
        }

        private void gridViewDSTho_DoubleClick(object sender, EventArgs e)
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

        private void gridViewDSTho_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
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