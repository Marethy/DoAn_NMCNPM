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
using QuanLiBanVang.Model;
using BUL;
using DTO;

namespace QuanLiBanVang.Form
{
    public partial class DanhSachPhieuNhapHang_Form : DevExpress.XtraEditors.XtraForm
    {
        private BUL_PhieuNhapHang bulImportReceipt;
        public DanhSachPhieuNhapHang_Form()
        {
            InitializeComponent();
            this.bulImportReceipt = new BUL_PhieuNhapHang();
            this.gridControlDanhSachPhieuNhap.DataSource = this.bulImportReceipt.getAll(); // binding data for gridview
            // some columns that is not informative will be invisible 
            this.gridViewDanhSachPhieuNhapHang.Columns[5].Visible = false;
            this.gridViewDanhSachPhieuNhapHang.Columns[6].Visible = false;
            this.gridViewDanhSachPhieuNhapHang.Columns[7].Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close(); // close the form
        }

        private void chiTiếtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // check the gridview is valid 
            if (this.gridViewDanhSachPhieuNhapHang.SelectedRowsCount < 0 || this.gridViewDanhSachPhieuNhapHang.SelectedRowsCount > 1 || this.gridViewDanhSachPhieuNhapHang.DataRowCount == 0) { return; }
            PHIEUNHAPHANG selectedImportReceipt = (PHIEUNHAPHANG)this.gridViewDanhSachPhieuNhapHang.GetRow(this.gridViewDanhSachPhieuNhapHang.FocusedRowHandle);
            // start the form
            PhieuNhapHang_Form viewImportDetailForm = new PhieuNhapHang_Form(ActionType.ACTION_VIEW, selectedImportReceipt);
            // show form 
            viewImportDetailForm.ShowDialog();
        }

        private void DanhSachPhieuNhapHang_Load(object sender, EventArgs e)
        {
            this.renameColumnsOfGridView();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PhieuNhapHang_Form newImportReceipt = new PhieuNhapHang_Form(ActionType.ACTION_CREATE_NEW, null);
            newImportReceipt.IsFormParentForm = true; // indicate that newImportReceipt is created from parent form
            newImportReceipt.refreshDelegateCallback = new PhieuNhapHang_Form.RefreshDelegate(this.refresh);
            newImportReceipt.ShowDialog();
        }

        /// <summary>
        /// Refreshes gridview when user click refresh menu item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.refresh();
        }

        private void simpleButtonChiTiet_Click(object sender, EventArgs e)
        {
            // check the gridview is valid 
            if (this.gridViewDanhSachPhieuNhapHang.SelectedRowsCount < 0 || this.gridViewDanhSachPhieuNhapHang.SelectedRowsCount > 1 || this.gridViewDanhSachPhieuNhapHang.DataRowCount == 0) { return; }
            PHIEUNHAPHANG selectedImportReceipt = (PHIEUNHAPHANG)this.gridViewDanhSachPhieuNhapHang.GetRow(this.gridViewDanhSachPhieuNhapHang.FocusedRowHandle);
            // start the form
            PhieuNhapHang_Form viewImportDetailForm = new PhieuNhapHang_Form(ActionType.ACTION_VIEW, selectedImportReceipt);
            // show form 
            viewImportDetailForm.ShowDialog();
        }

        private void simpleButtonRefresh_Click(object sender, EventArgs e)
        {
            this.refresh();
        }


        // refresh grid control datasource
        private void refresh()
        {
            this.bulImportReceipt = new BUL_PhieuNhapHang();
            this.gridControlDanhSachPhieuNhap.DataSource = this.bulImportReceipt.getAll();
        }


        private void renameColumnsOfGridView()
        {
            this.gridViewDanhSachPhieuNhapHang.Columns[0].Caption = "Mã phiếu nhập";
            this.gridViewDanhSachPhieuNhapHang.Columns[1].Caption = "Mã nhà cung cấp";
            this.gridViewDanhSachPhieuNhapHang.Columns[2].Caption = "Mã nhân viên";
            this.gridViewDanhSachPhieuNhapHang.Columns[3].Caption = "Ngày nhập";
            this.gridViewDanhSachPhieuNhapHang.Columns[4].Caption = "Tổng tiền";
        }

        private void gridViewDanhSachPhieuNhapHang_DoubleClick(object sender, EventArgs e)
        {
            simpleButtonChiTiet_Click(sender, e);
        }
    }
}