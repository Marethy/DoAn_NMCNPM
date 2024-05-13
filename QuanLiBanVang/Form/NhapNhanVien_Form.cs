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

namespace QuanLiBanVang.Report
{
    public partial class NhapNhanVien_Form : DevExpress.XtraEditors.XtraForm
    {
        DTO.NHANVIEN _staff;
        BUL.BUL_NhanVien _bulStaff;
        BUL.BUL_ChucVu _bulPosition;
        BUL.BUL_NhomNguoiDung _bulGroupUser;

        public NhapNhanVien_Form()
        {
            InitializeComponent();
            _staff = new DTO.NHANVIEN();
            _bulStaff = new BUL.BUL_NhanVien();
            _bulPosition = new BUL.BUL_ChucVu();
            _bulGroupUser = new BUL.BUL_NhomNguoiDung();
        }
        public bool CheckControlValidation()
        {
            if (this.txtAddress.Text == "")
                return false;
            if (this.txtName.Text == "")
                return false;
            if (this.txtPassword.Text == "")
                return false;
            if (this.txtPhone.Text == "")
                return false;
            if (this.txtUsername.Text == "")
                return false;
            if (this.cboGroupUser.SelectedIndex == -1)
                return false;
            if (this.cboPosition.SelectedIndex == -1)
                return false;
            if (this.dtpkBirth.EditValue == null)
                return false;
            return true;
        }
        private void NhapNhanVien_Form_Load(object sender, EventArgs e)
        {
            List<DTO.CHUCVU> _listPosition = new List<DTO.CHUCVU>();
            List<DTO.NHOMNGUOIDUNG> _listGroupUser = new List<DTO.NHOMNGUOIDUNG>();
            _listPosition = _bulPosition.getAllPosition();
            _listGroupUser = _bulGroupUser.getAllGroupUser();
            foreach (DTO.CHUCVU i in _listPosition)
            {
                ExtendClass.ContainerItem item = new ExtendClass.ContainerItem();
                item.Text = i.TenCV;
                item.Value = i;
                this.cboPosition.Properties.Items.Add(item);
            }

            foreach (DTO.NHOMNGUOIDUNG i in _listGroupUser)
            {
                ExtendClass.ContainerItem item = new ExtendClass.ContainerItem();
                item.Text = i.TenNhom;
                item.Value = i;
                this.cboGroupUser.Properties.Items.Add(item);
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (this.CheckControlValidation())
            {
                //nhap thong tin chung
                this._staff.HoTen = this.txtName.Text;
                this._staff.DiaChi = this.txtAddress.Text;
                this._staff.GioiTinh = (bool)this.rdoGender.EditValue;
                this._staff.NgSinh = this.dtpkBirth.DateTime;
                this._staff.SDT = this.txtPhone.Text;
                this._staff.MaCV = ((this.cboPosition.SelectedItem as ExtendClass.ContainerItem).Value as DTO.CHUCVU).MaCV;
                //nhap thong tin tai khoan
                this._staff.TenDangNhap = this.txtUsername.Text;
                string encryptedPass = ExtendClass.MD5Encryptor.MD5Hash(this.txtPassword.Text);
                this._staff.MatKhau = encryptedPass;
                this._staff.MaNhom = ((this.cboGroupUser.SelectedItem as ExtendClass.ContainerItem).Value as DTO.NHOMNGUOIDUNG).MaNhom;

                //Luu lai
                //this._bulStaff.addNewStaff(this._staff);
                bool isSuceeded = this._bulStaff.addNewUser(this._staff);
                if (isSuceeded)
                {
                    MessageBox.Show("Thêm tài khoản nhân viên mới thành công!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Tài khoản đã bị trùng, vui lòng chọn tên đăng nhập khác!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin cần thiết!","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void NhapNhanVien_Form_SizeChanged(object sender, EventArgs e)
        {
            groupControlInfo.Left = (ClientSize.Width - groupControlInfo.Width) / 2;
            groupControlAccountInfo.Left = (ClientSize.Width - groupControlAccountInfo.Width) / 2;
            btnCancel.Left = groupControlAccountInfo.Right - btnSave.Width;
            btnSave.Left = btnCancel.Left - btnSave.Width - 10; 
        }

    }
}