using System;
using System.Windows.Forms;
using BUL;
using DTO;
using QuanLiBanVang.Properties;

namespace QuanLiBanVang
{
    public partial class SuaDichVu : DevExpress.XtraEditors.XtraForm
    {
        private BUL_DichVu _bulDichVu;
        private DICHVU _dichvu;
        public SuaDichVu(int id)
        {
            InitializeComponent();
            _bulDichVu = new BUL_DichVu();
            _dichvu = _bulDichVu.GetDichvuById(id);
            textEditTenDV.Text = _dichvu.TenDV;
            textEditTienCong.Text = ((int)(_dichvu.TienCong ?? 0)).ToString();
        }

        private void simpleButtonOK_Click(object sender, EventArgs e)
        {
            if (textEditTenDV.Text == "")
            {
                MessageBox.Show(Resources.NhapDichVu_TenDVEmpty, Resources.TitleMessageBox_Error, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (textEditTienCong.Text == "")
            {
                MessageBox.Show(Resources.NhapDichVu_TienCongEmpty, Resources.TitleMessageBox_Error, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            _dichvu.TenDV = textEditTenDV.Text;
            _dichvu.TienCong = Int32.Parse(textEditTienCong.Text);
            _bulDichVu.UpdateDichVu(_dichvu);
            DialogResult = DialogResult.OK;
            MessageBox.Show(Resources.UpdateSuccess, Resources.TitleMessageBox_ThongBao, MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            Close();
        }

        private void simpleButtonHuy_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}