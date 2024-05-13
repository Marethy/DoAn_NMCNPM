using System;
using System.Windows.Forms;
using BUL;
using DTO;
using QuanLiBanVang.Properties;

namespace QuanLiBanVang
{
    public partial class SuaTho : DevExpress.XtraEditors.XtraForm
    {
        private BUL_Tho _bulTho;
        private THO _tho;
        public SuaTho(int id)
        {
            InitializeComponent();
            _bulTho = new BUL_Tho();
            _tho = _bulTho.GetWorkerById(id);
            textEditTenTho.Text = _tho.TenTho;
            textEditDiaChi.Text = _tho.DiaChi;
            textEditSDT.Text = _tho.SDT;
        }

        private void simpleButtonOK_Click(object sender, EventArgs e)
        {
            if (textEditTenTho.Text == "")
            {
                MessageBox.Show(Resources.NhapPhieuGiaCong_TenThoEmpty, Resources.TitleMessageBox_Error, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (textEditSDT.Text == "")
            {
                MessageBox.Show(Resources.NhapKhachHang_SDTEmpty, Resources.TitleMessageBox_Error, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (textEditDiaChi.Text == "")
            {
                MessageBox.Show(Resources.NhapKhachHang_DiaChiEmpty, Resources.TitleMessageBox_Error, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            _tho.TenTho = textEditTenTho.Text;
            _tho.DiaChi = textEditDiaChi.Text;
            _tho.SDT = textEditSDT.Text;
            _bulTho.UpdateWorker(_tho);
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