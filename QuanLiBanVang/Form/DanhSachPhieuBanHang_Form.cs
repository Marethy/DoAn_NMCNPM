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
using System.Collections.ObjectModel;
using QuanLiBanVang.Model;
using DTO;
using BUL;
using System.Data.Entity;

namespace QuanLiBanVang.Form
{
    public partial class DanhSachPhieuBanHang_Form : DevExpress.XtraEditors.XtraForm
    {
        private BUL_PhieuBanHang bulPhieuBanHang = new BUL_PhieuBanHang();
        public DanhSachPhieuBanHang_Form()
        {
            InitializeComponent();
            // reference to grid view data source
            // Binding data into gridview
            this.gridControlListReceipts.DataSource = this.bulPhieuBanHang.toBindingList();
        }

        private void DanhSachPhieuBanHang_Load(object sender, EventArgs e)
        {

        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.Close(); // close the form
        }

        private void chiTiếtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // update new data state
            // this.bulPhieuBanHang = new BUL_PhieuBanHang();
            // this.gridControlListReceipts.DataSource = this.bulPhieuBanHang.toBindingList();

            if (this.gridView1.SelectedRowsCount < 0 || this.gridView1.SelectedRowsCount > 1 || this.gridView1.DataRowCount == 0) return;
            // get item from focused row of gridview
            PHIEUBANHANG focusedRow = (PHIEUBANHANG)this.gridView1.GetRow(this.gridView1.FocusedRowHandle);
            // open new form
            PhieuBanHang detailForm = new PhieuBanHang(ActionType.ACTION_VIEW, focusedRow);
            detailForm.ShowDialog();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            PhieuBanHang newReceipt = new PhieuBanHang(ActionType.ACTION_CREATE_NEW, null);
            newReceipt.IsFromParentForm = true;
            newReceipt.refreshDelegateCallback = new PhieuBanHang.RefreshDelegate(this.refresh); // refresh list when close child form
            newReceipt.ShowDialog();
        }


        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.refresh();
        }

        private void simpleButtonChiTiet_Click(object sender, EventArgs e)
        {
            // update new data state
            // this.bulPhieuBanHang = new BUL_PhieuBanHang();
            // this.gridControlListReceipts.DataSource = this.bulPhieuBanHang.toBindingList();

            if (this.gridView1.SelectedRowsCount < 0 || this.gridView1.SelectedRowsCount > 1 || this.gridView1.DataRowCount == 0) return;
            // get item from focused row of gridview
            PHIEUBANHANG focusedRow = (PHIEUBANHANG)this.gridView1.GetRow(this.gridView1.FocusedRowHandle);
            // open new form
            PhieuBanHang detailForm = new PhieuBanHang(ActionType.ACTION_VIEW, focusedRow);
            detailForm.ShowDialog();
        }

        private void simpleButtonRefresh_Click(object sender, EventArgs e)
        {
            this.refresh();
        }


        private void refresh()
        {
            // update new data state
            this.bulPhieuBanHang = new BUL_PhieuBanHang();
            this.gridControlListReceipts.RefreshDataSource();
            this.gridControlListReceipts.DataSource = this.bulPhieuBanHang.toBindingList();
        }

        private void gridView1_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            simpleButtonChiTiet_Click(sender,e);
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            simpleButtonChiTiet_Click(sender,e);
        }
    }
}