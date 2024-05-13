using System;
using System.Windows.Forms;
using BUL;
using DTO;
using QuanLiBanVang.Properties;

namespace QuanLiBanVang
{
    public partial class SuaKhachHang : DevExpress.XtraEditors.XtraForm
    {
        private BUL_KhachHang _bulKhachHang;
        private KHACHHANG khachhang;
        public SuaKhachHang(int id)
        {
            InitializeComponent();
            _bulKhachHang = new BUL_KhachHang();
            khachhang = _bulKhachHang.GetKhachhangById(id);
            textEditTenKH.Text = khachhang.TenKH;
            textEditDiaChi.Text = khachhang.DiaChi;
            textEditSDT.Text = khachhang.SDT;
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
            khachhang.TenKH = textEditTenKH.Text;
            khachhang.DiaChi = textEditDiaChi.Text;
            khachhang.SDT = textEditSDT.Text;
            _bulKhachHang.UpdateKhachHang(khachhang);
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