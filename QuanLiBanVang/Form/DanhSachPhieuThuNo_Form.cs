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
using BUL;
using DTO;
using QuanLiBanVang.ExtendClass;
using QuanLiBanVang.Model;

namespace QuanLiBanVang.Form
{
    public partial class DanhSachPhieuThuNo_Form : DevExpress.XtraEditors.XtraForm
    {
        private BUL_KhachHang bulKhachHang;
        private BUL_PhieuBanHang bulPhieuBanHang;
        private BUL_PhieuThuTienNo bulPhieuThuTienNo;
        public DanhSachPhieuThuNo_Form()
        {
            InitializeComponent();
            this.bulKhachHang = new BUL_KhachHang();
            this.bulPhieuThuTienNo = new BUL_PhieuThuTienNo();
        }

        private void DanhSachPhieuThuNo_Load(object sender, EventArgs e)
        {
            // load danh sach khach hang into combobox
            List<KHACHHANG> listKhachHangs = this.bulKhachHang.GetAllKhachhangs();
            foreach (KHACHHANG item in listKhachHangs)
            {
                this.comboBoxEditKhachHang.Properties.Items.Add(new ContainerItem
                {
                    Text = item.TenKH + "-" + item.SDT,
                    Value = item
                });
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.gridControlDanhSachPhieuNo.DataSource = null;
            // see all receipts of selected frequenter //
            ContainerItem selectedItem = (ContainerItem)this.comboBoxEditKhachHang.SelectedItem;
            if (selectedItem == null) { return; }
            KHACHHANG selectedFrequenter = (KHACHHANG)selectedItem.Value;

            this.bulPhieuBanHang = new BUL_PhieuBanHang();
            this.gridControlPhieuBanHang.RefreshDataSource();
            this.gridControlPhieuBanHang.DataSource = this.bulPhieuBanHang.findReceiptsByFrequenterId(selectedFrequenter.MaKH);
            this.renameColumnsOfReceiptsGridView();
            // all uninformative columns will be invisible
            this.gridViewDanhSachPhieuBanHang.Columns[6].Visible = false;
            this.gridViewDanhSachPhieuBanHang.Columns[7].Visible = false;
            this.gridViewDanhSachPhieuBanHang.Columns[8].Visible = false;
            this.gridViewDanhSachPhieuBanHang.Columns[9].Visible = false;
        }

        private void xemPhiếuNợToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.gridViewDanhSachPhieuBanHang.DataRowCount == 0)
            {
                return;
            }
            PHIEUBANHANG selectedReceipt = (PHIEUBANHANG)this.gridViewDanhSachPhieuBanHang.GetRow(this.gridViewDanhSachPhieuBanHang.FocusedRowHandle);
            // start to look up all dept receipts
            this.bulPhieuBanHang = new BUL_PhieuBanHang();
            this.gridControlDanhSachPhieuNo.RefreshDataSource();
            this.gridControlDanhSachPhieuNo.DataSource = this.bulPhieuBanHang.findDeptReceiptsByReceiptId(selectedReceipt.SoPhieuBH);
            this.renameColumnsOfDebReceiptsGridView();
            // all uninformative columns will be invisible
            this.gridViewDanhSachPhieuNo.Columns[8].Visible = false;
            this.gridViewDanhSachPhieuNo.Columns[9].Visible = false;
        }

        private void lậpPhiếuNợToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // get the focused row
            if (this.gridViewDanhSachPhieuBanHang.DataRowCount == 0)
            {
                return;
            }
            PHIEUBANHANG selectedReceipt = (PHIEUBANHANG)this.gridViewDanhSachPhieuBanHang.GetRow(this.gridViewDanhSachPhieuBanHang.FocusedRowHandle);
            // check if this recept has dept recepit or not ?
            if (this.bulPhieuBanHang.hasDebtReceipts(selectedReceipt.SoPhieuBH) == false)
            {
                // create the first dept receipt
                PhieuThuTienNo_Form firstDeptReceiptForm = new PhieuThuTienNo_Form(selectedReceipt);
                firstDeptReceiptForm.refreshDebtReceiptDataCallback = new PhieuThuTienNo_Form.RefreshDebtReceiptData(this.refreshDebtReceiptData);
                firstDeptReceiptForm.ShowDialog();
            }
            else // otherwise
            {
                // get the last dept recpeit
                PHIEUTHUTIENNO lastDeptReceip = this.bulPhieuBanHang.findTheLastDeiptReceiptFromReceiptId(selectedReceipt.SoPhieuBH);
                // check if user paid for all the depts
                if (decimal.Equals(lastDeptReceip.SoTienConLai, decimal.Zero))
                {
                    MessageBox.Show("Phiếu bán hàng này đã được trả nợ hết !", ErrorMessage.ERROR_MESSARE_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                // start to show the form
                PhieuThuTienNo_Form deptReceiptForm = new PhieuThuTienNo_Form(lastDeptReceip);
                deptReceiptForm.refreshDebtReceiptDataCallback = new PhieuThuTienNo_Form.RefreshDebtReceiptData(this.refreshDebtReceiptData);
                deptReceiptForm.ShowDialog();

            }
        }

        private void simpleButtonThoat_Click(object sender, EventArgs e)
        {
            // close the form
            this.Close();
        }

        private void simpleButtonXemPhieuNo_Click(object sender, EventArgs e)
        {
            this.showDetail();
        }

        private void simpleButtonLapPhieuNo_Click(object sender, EventArgs e)
        {
            // get the focused row
            if (this.gridViewDanhSachPhieuBanHang.DataRowCount == 0)
            {
                return;
            }
            PHIEUBANHANG selectedReceipt = (PHIEUBANHANG)this.gridViewDanhSachPhieuBanHang.GetRow(this.gridViewDanhSachPhieuBanHang.FocusedRowHandle);
            // check if this recept has dept recepit or not ?
            if (this.bulPhieuBanHang.hasDebtReceipts(selectedReceipt.SoPhieuBH) == false)
            {
                // create the first dept receipt
                PhieuThuTienNo_Form firstDeptReceiptForm = new PhieuThuTienNo_Form(selectedReceipt);
                firstDeptReceiptForm.refreshDebtReceiptDataCallback = new PhieuThuTienNo_Form.RefreshDebtReceiptData(this.refreshDebtReceiptData);
                firstDeptReceiptForm.ShowDialog();
            }
            else // otherwise
            {
                // get the last dept recpeit
                PHIEUTHUTIENNO lastDeptReceip = this.bulPhieuBanHang.findTheLastDeiptReceiptFromReceiptId(selectedReceipt.SoPhieuBH);
                // check if user paid for all the depts
                if (decimal.Equals(lastDeptReceip.SoTienConLai, decimal.Zero))
                {
                    MessageBox.Show("Phiếu bán hàng này đã được trả nợ hết !", ErrorMessage.ERROR_MESSARE_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                // start to show the form
                PhieuThuTienNo_Form deptReceiptForm = new PhieuThuTienNo_Form(lastDeptReceip);
                deptReceiptForm.refreshDebtReceiptDataCallback = new PhieuThuTienNo_Form.RefreshDebtReceiptData(this.refreshDebtReceiptData);
                deptReceiptForm.ShowDialog();

            }
        }


        private void simpleButtonXemTheoNgay_Click(object sender, EventArgs e)
        {
            DateTime criteriaDate = this.dateEditLocTheoNgayTra.DateTime;
            if (criteriaDate != null)
            {
                this.gridControlDanhSachPhieuNo.DataSource = this.bulPhieuThuTienNo.findDeptReceiptByPaymentDate(criteriaDate);
                // hide some uninformative columns
                this.gridViewDanhSachPhieuNo.Columns[8].Visible = false;
                this.gridViewDanhSachPhieuNo.Columns[9].Visible = false;
            }
        }

        private void gridViewDanhSachPhieuBanHang_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            this.showDetail();
        }


        private void showDetail()
        {
            if (this.gridViewDanhSachPhieuBanHang.DataRowCount == 0)
            {
                return;
            }
            PHIEUBANHANG selectedReceipt = (PHIEUBANHANG)this.gridViewDanhSachPhieuBanHang.GetRow(this.gridViewDanhSachPhieuBanHang.FocusedRowHandle);
            // start to look up all dept receipts
            this.bulPhieuBanHang = new BUL_PhieuBanHang();
            this.gridControlDanhSachPhieuNo.RefreshDataSource();
            this.gridControlDanhSachPhieuNo.DataSource = this.bulPhieuBanHang.findDeptReceiptsByReceiptId(selectedReceipt.SoPhieuBH);
            this.renameColumnsOfDebReceiptsGridView();
            // all uninformative columns will be invisible
            this.gridViewDanhSachPhieuNo.Columns[8].Visible = false;
            this.gridViewDanhSachPhieuNo.Columns[9].Visible = false;
        }


        private void renameColumnsOfReceiptsGridView()
        {
            // for grid view : danh sach phieu ban hang
            this.gridViewDanhSachPhieuBanHang.Columns[0].Caption = "Số phiếu bán";
            this.gridViewDanhSachPhieuBanHang.Columns[1].Caption = "Mã nhân viên";
            this.gridViewDanhSachPhieuBanHang.Columns[2].Caption = "Mã khách hàng";
            this.gridViewDanhSachPhieuBanHang.Columns[3].Caption = "Ngày bán";
            this.gridViewDanhSachPhieuBanHang.Columns[4].Caption = "Ngày trả";
            this.gridViewDanhSachPhieuBanHang.Columns[5].Caption = "Tổng tiền";
        }


        private void renameColumnsOfDebReceiptsGridView()
        {
            // for grid view : danh sach phieu no
            this.gridViewDanhSachPhieuNo.Columns[0].Caption = "Số phiếu nợ";
            this.gridViewDanhSachPhieuNo.Columns[1].Caption = "Số phiếu bán";
            this.gridViewDanhSachPhieuNo.Columns[2].Caption = "Mã nhân viên";
            this.gridViewDanhSachPhieuNo.Columns[3].Caption = "Ngày lập";
            this.gridViewDanhSachPhieuNo.Columns[4].Caption = "Ngày trả";
            this.gridViewDanhSachPhieuNo.Columns[5].Caption = "Số tiền nợ";
            this.gridViewDanhSachPhieuNo.Columns[6].Caption = "Số tiền trả";
            this.gridViewDanhSachPhieuNo.Columns[7].Caption = "Số tiền còn lại";
        }


        /// <summary>
        /// delegate method from form : PhieuThuTienNo_Form
        /// </summary>
        private void refreshDebtReceiptData()
        {
            this.showDetail();
        }
    }
}