using System;
using System.Windows.Forms;
using BUL;
using DTO;
using QuanLiBanVang.Properties;

namespace QuanLiBanVang
{
    public partial class NhapDichVu : DevExpress.XtraEditors.XtraForm
    {
        private BUL_DichVu _bulDichVu;
        public NhapDichVu()
        {
            InitializeComponent();
            _bulDichVu = new BUL_DichVu();
        }

        private void simpleButtonOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textEditTenDV.Text))
            {
                MessageBox.Show(Resources.NhapDichVu_TenDVEmpty, Resources.TitleMessageBox_Error, MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrEmpty(textEditTienCong.Text))
            {
                MessageBox.Show(Resources.NhapDichVu_TienCongEmpty, Resources.TitleMessageBox_Error,
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DICHVU newDichvu = new DICHVU();
            newDichvu.TenDV = textEditTenDV.Text;
            newDichvu.TienCong = Int32.Parse(textEditTienCong.Text);
            _bulDichVu.AddNewDichVu(newDichvu);
            MessageBox.Show(Resources.ThemThanhCong, Resources.TitleMessageBox_ThongBao, MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            DialogResult = DialogResult.OK;
            ClearForm();
            if (!IsMdiChild)
                Close();
        }

        private void ClearForm()
        {
            textEditTenDV.Text = textEditTienCong.Text = null;
        }
        private void simpleButtonHuy_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void NhapDichVu_SizeChanged(object sender, EventArgs e)
        {
            groupControl1.Left = (ClientSize.Width - groupControl1.Width) / 2;
            simpleButtonHuy.Left = groupControl1.Right - simpleButtonOK.Width;
            simpleButtonOK.Left = simpleButtonHuy.Left - simpleButtonOK.Width - 10; 
        }
    }
}