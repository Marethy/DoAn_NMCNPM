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
    public partial class SuaNhanVien_Form : DevExpress.XtraEditors.XtraForm
    {
        DTO.NHANVIEN _staff;
        BUL.BUL_NhanVien _bulStaff;
        BUL.BUL_ChucVu _bulPosition;
        BUL.BUL_NhomNguoiDung _bulGroupUser;
        public SuaNhanVien_Form()
        {
            InitializeComponent();
        }
        public SuaNhanVien_Form(int id)
        {
            InitializeComponent();
            _bulStaff = new BUL.BUL_NhanVien();
            _bulGroupUser = new BUL.BUL_NhomNguoiDung();
            _bulPosition = new BUL.BUL_ChucVu();
            _staff = _bulStaff.getStaffById(id);
            
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
        public void loadStaffInfo()
        {
          //  _bulStaff = new BUL.BUL_NhanVien();
          //  _bulGroupUser = new BUL.BUL_NhomNguoiDung();
         //   _bulPosition = new BUL.BUL_ChucVu();
          //  _staff = _bulStaff.getStaffById(4);
            List<DTO.CHUCVU> _listPosition = new List<DTO.CHUCVU>();
            List<DTO.NHOMNGUOIDUNG> _listGroupUser = new List<DTO.NHOMNGUOIDUNG>();
            _listGroupUser = _bulGroupUser.getAllGroupUser();
            _listPosition = _bulPosition.getAllPosition();
            foreach (DTO.CHUCVU i in _listPosition)
            {
                ExtendClass.ContainerItem cboitem = new ExtendClass.ContainerItem();
                cboitem.Text = i.TenCV;
                cboitem.Value = i;
                this.cboPosition.Properties.Items.Add(cboitem);
            }
            foreach (DTO.NHOMNGUOIDUNG i in _listGroupUser)
            {
                ExtendClass.ContainerItem cboitem = new ExtendClass.ContainerItem();
                cboitem.Text = i.TenNhom;
                cboitem.Value = i;
                this.cboGroupUser.Properties.Items.Add(cboitem);
            }

            for (int i = 0; i < this.cboPosition.Properties.Items.Count; i++)
            {
                ExtendClass.ContainerItem x = cboPosition.Properties.Items[i] as ExtendClass.ContainerItem;
                DTO.CHUCVU po = (x.Value as DTO.CHUCVU);
                if (po.MaCV == _staff.MaCV)
                {
                    this.cboPosition.SelectedIndex = i;
                    break;
                }
            }

            for (int i = 0; i < this.cboGroupUser.Properties.Items.Count; i++)
            {
                ExtendClass.ContainerItem item = cboGroupUser.Properties.Items[i] as ExtendClass.ContainerItem;
                DTO.NHOMNGUOIDUNG groupuser = (item.Value as DTO.NHOMNGUOIDUNG);
                if (groupuser.MaNhom == _staff.MaNhom)
                {
                    this.cboGroupUser.SelectedIndex = i;
                    break;
                }
            }
            this.txtName.Text = _staff.HoTen;
            this.txtAddress.Text = _staff.DiaChi;
            this.txtPhone.Text = _staff.SDT;
            this.rdoGender.EditValue = _staff.GioiTinh;
            this.txtUsername.Text = _staff.TenDangNhap;
            this.txtPassword.Text = _staff.MatKhau;
            this.dtpkBirth.DateTime = _staff.NgSinh;
        }
        private void SuaNhanVien_Form_Load(object sender, EventArgs e)
        {
            this.loadStaffInfo();
            this.txtUsername.Enabled = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (this.CheckControlValidation())
            {
                string newPass = ExtendClass.MD5Encryptor.MD5Hash(this.txtPassword.Text);
                if (newPass == _staff.MatKhau)
                {
                    MessageBox.Show("Mật khẩu mới không thể giống mật khẩu hiện tại!");
                    return;
                }
                else
                {
                    if((bool)this.chkbChangePassword.EditValue == true)
                        _staff.MatKhau = newPass;
                }
                _staff.HoTen = this.txtName.Text;
                _staff.NgSinh = this.dtpkBirth.DateTime;
                _staff.MaCV = ((this.cboPosition.SelectedItem as ExtendClass.ContainerItem).Value as DTO.CHUCVU).MaCV;
                _staff.DiaChi = this.txtAddress.Text;
                _staff.SDT = this.txtPhone.Text;
                _staff.GioiTinh = (bool)this.rdoGender.EditValue;
                _staff.MaNhom = ((this.cboGroupUser.SelectedItem as ExtendClass.ContainerItem).Value as DTO.NHOMNGUOIDUNG).MaNhom;
                _staff.TenDangNhap = this.txtUsername.Text;

                this._bulStaff.updateStaff(_staff);
                MessageBox.Show("Cập nhật thông tin tài khoản thành công!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
         
                    
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    this.Close();
                
    
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

        private void chkbChangePassword_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkbChangePassword.Checked == true)
            {
                this.txtPassword.ReadOnly = false;
            }
            else
            {
                this.txtPassword.ReadOnly = true;
            }
        }
    }
}