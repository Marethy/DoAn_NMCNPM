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
using System.Data.Entity;
using QuanLiBanVang.Model;
using DTO;
namespace QuanLiBanVang.Form
{
    public partial class DanhSachNhaCungCap_Form : DevExpress.XtraEditors.XtraForm
    {
        // database context
        private BUL_NhaCungCap bulProvider;
        public DanhSachNhaCungCap_Form()
        {
            InitializeComponent();
            this.bulProvider = new BUL_NhaCungCap();
            // start to get all providers from database and binding into the view list
            this.gridControlDanhSachNhaCungCap.DataSource = this.bulProvider.getAll();
            gridViewDanhSachNhaCungCap.Columns[4].Visible = false;
        }

        private void DanhSachNhaCungCap_Load(object sender, EventArgs e)
        {
            this.renameColumnsOfGridView();
        }

        private void chiTiếtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // doing nothing if no rows selected or number of selected rows is greater than 1 
            if (this.gridViewDanhSachNhaCungCap.GetSelectedRows().Count() == 0 || this.gridViewDanhSachNhaCungCap.GetSelectedRows().Count() > 1) { return; }
            // otherwise , show detail form for the selected row
            NHACUNGCAP selectedProvider = (NHACUNGCAP)this.gridViewDanhSachNhaCungCap.GetRow(this.gridViewDanhSachNhaCungCap.FocusedRowHandle);
            NhaCungCap_Form viewExistedProviderForm = new NhaCungCap_Form(ActionType.ACTION_VIEW, selectedProvider);
            viewExistedProviderForm.ShowDialog();

        }

        private void simpleButtonThem_Click(object sender, EventArgs e)
        {
            NhaCungCap_Form newProviderForm = new NhaCungCap_Form(ActionType.ACTION_CREATE_NEW, null);
            newProviderForm.refreshDelegateCallback = new NhaCungCap_Form.RefreshDelegate(this.refresh);
            newProviderForm.IsFromParentForm = true;
            newProviderForm.ShowDialog();
        }

        private void simpleButtonThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void sửaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            // doing nothing if no rows selected or number of selected rows is greater than 1 
            if (this.gridViewDanhSachNhaCungCap.GetSelectedRows().Count() == 0 || this.gridViewDanhSachNhaCungCap.GetSelectedRows().Count() > 1) { return; }
            // otherwise , show detail form for the selected row
            NHACUNGCAP selectedProvider = (NHACUNGCAP)this.gridViewDanhSachNhaCungCap.GetRow(this.gridViewDanhSachNhaCungCap.FocusedRowHandle);
            NhaCungCap_Form updateExistedProviderForm = new NhaCungCap_Form(ActionType.ACTION_UPDATE, selectedProvider);
            updateExistedProviderForm.IsFromParentForm = true;
            updateExistedProviderForm.refreshDelegateCallback = new NhaCungCap_Form.RefreshDelegate(this.refresh);
            updateExistedProviderForm.ShowDialog();
        }

        private void xóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // doing nothing if no rows selected or number of selected rows is greater than 1 
            if (this.gridViewDanhSachNhaCungCap.GetSelectedRows().Count() == 0 || this.gridViewDanhSachNhaCungCap.GetSelectedRows().Count() > 1) { return; }

            // dialog to ask user

            NHACUNGCAP selectedProvider = (NHACUNGCAP)this.gridViewDanhSachNhaCungCap.GetRow(this.gridViewDanhSachNhaCungCap.FocusedRowHandle);
            DialogResult removeProviderDialogResult = MessageBox.Show("Bạn có chắc sẽ xóa nhà cung cấp " + selectedProvider.TenNCC + " không ?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (removeProviderDialogResult == System.Windows.Forms.DialogResult.Yes)
            {
                this.bulProvider.deleteProvider(selectedProvider.MaNCC);
            }
        }

        private void simpleButtonChiTiet_Click(object sender, EventArgs e)
        {
            // doing nothing if no rows selected or number of selected rows is greater than 1 
            if (this.gridViewDanhSachNhaCungCap.GetSelectedRows().Count() == 0 || this.gridViewDanhSachNhaCungCap.GetSelectedRows().Count() > 1) { return; }
            // otherwise , show detail form for the selected row
            NHACUNGCAP selectedProvider = (NHACUNGCAP)this.gridViewDanhSachNhaCungCap.GetRow(this.gridViewDanhSachNhaCungCap.FocusedRowHandle);
            NhaCungCap_Form viewExistedProviderForm = new NhaCungCap_Form(ActionType.ACTION_VIEW, selectedProvider);
            viewExistedProviderForm.ShowDialog();
        }

        private void simpleButtonRefresh_Click(object sender, EventArgs e)
        {
            this.refresh();
        }


        private void refresh()
        {
            this.bulProvider = new BUL_NhaCungCap();
            // start to get all providers from database and binding into the view list
            this.gridControlDanhSachNhaCungCap.DataSource = this.bulProvider.getAll();
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.refresh();
        }

        private void simpleButtonSua_Click(object sender, EventArgs e)
        {
            // doing nothing if no rows selected or number of selected rows is greater than 1 
            if (this.gridViewDanhSachNhaCungCap.GetSelectedRows().Count() == 0 || this.gridViewDanhSachNhaCungCap.GetSelectedRows().Count() > 1) { return; }
            // otherwise , show detail form for the selected row
            NHACUNGCAP selectedProvider = (NHACUNGCAP)this.gridViewDanhSachNhaCungCap.GetRow(this.gridViewDanhSachNhaCungCap.FocusedRowHandle);
            NhaCungCap_Form updateExistedProviderForm = new NhaCungCap_Form(ActionType.ACTION_UPDATE, selectedProvider);
            updateExistedProviderForm.refreshDelegateCallback = new NhaCungCap_Form.RefreshDelegate(this.refresh);
            updateExistedProviderForm.IsFromParentForm = true;
            updateExistedProviderForm.ShowDialog();
        }


        private void renameColumnsOfGridView()
        {
            this.gridViewDanhSachNhaCungCap.Columns[0].Caption = "Mã nhà cung cấp";
            this.gridViewDanhSachNhaCungCap.Columns[0].Visible = false;
            this.gridViewDanhSachNhaCungCap.Columns[1].Caption = "Tên nhà cung cấp";
            this.gridViewDanhSachNhaCungCap.Columns[2].Caption = "Địa chỉ";
            this.gridViewDanhSachNhaCungCap.Columns[3].Caption = "Số điện thoại";
        }

        private void simpleButtonXoa_Click(object sender, EventArgs e)
        {
            // doing nothing if no rows selected or number of selected rows is greater than 1 
            if (this.gridViewDanhSachNhaCungCap.GetSelectedRows().Count() == 0 || this.gridViewDanhSachNhaCungCap.GetSelectedRows().Count() > 1) { return; }

            // dialog to ask user

            NHACUNGCAP selectedProvider = (NHACUNGCAP)this.gridViewDanhSachNhaCungCap.GetRow(this.gridViewDanhSachNhaCungCap.FocusedRowHandle);
            DialogResult removeProviderDialogResult = MessageBox.Show("Bạn có chắc sẽ xóa nhà cung cấp " + selectedProvider.TenNCC + " không ?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (removeProviderDialogResult == System.Windows.Forms.DialogResult.Yes)
            {
                this.bulProvider.deleteProvider(selectedProvider.MaNCC);
            }
        }
    }
}