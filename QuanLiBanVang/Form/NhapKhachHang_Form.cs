using System;
using System.Windows.Forms;
using BUL;
using DTO;
using QuanLiBanVang.Properties;

namespace QuanLiBanVang
{
    public partial class NhapKhachHang : DevExpress.XtraEditors.XtraForm
    {
        private BUL_KhachHang _bulKhachHang;
        public NhapKhachHang()
        {
            InitializeComponent();
            _bulKhachHang = new BUL_KhachHang();
        }

        private void simpleButtonOk_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textEditTenKH.Text))
            {
                MessageBox.Show(Resources.NhapKhachHang_TenKHEmpty, Resources.TitleMessageBox_Error, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrEmpty(textEditSDT.Text))
            {
                MessageBox.Show(Resources.NhapKhachHang_SDTEmpty, Resources.TitleMessageBox_Error, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrEmpty(textEditDiaChi.Text))
            {
                MessageBox.Show(Resources.NhapKhachHang_DiaChiEmpty, Resources.TitleMessageBox_Error, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            KHACHHANG khachhang = new KHACHHANG
            {
                TenKH = textEditTenKH.Text,
                DiaChi = textEditDiaChi.Text,
                SDT = textEditSDT.Text
            };
            _bulKhachHang.AddNewClient(khachhang);
            MessageBox.Show(Resources.ThemThanhCong, Resources.TitleMessageBox_ThongBao, MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            DialogResult = DialogResult.OK;
            ClearForm();
            if (!IsMdiChild)
                Close();
        }

        private void ClearForm()
        {
            textEditTenKH.Text = textEditSDT.Text = textEditDiaChi.Text = null;
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void NhapKhachHang_SizeChanged(object sender, EventArgs e)
        {
            groupControl1.Left = (ClientSize.Width - groupControl1.Width) / 2;
            simpleButtonHuy.Left = groupControl1.Right - simpleButtonOK.Width;
            simpleButtonOK.Left = simpleButtonHuy.Left - simpleButtonOK.Width - 10; 
        }
    }
}