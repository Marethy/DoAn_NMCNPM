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
    public partial class Login_Form : DevExpress.XtraEditors.XtraForm
    {
        BUL.BUL_NhanVien _bulStaff;
        int _attempTimes;
        public static int MAX_LOGIN_ATTEMP_TIME = 3;
        public Login_Form()
        {
            InitializeComponent();
            _bulStaff = new BUL.BUL_NhanVien();
            _attempTimes = 0;
        }

        private void Login_Form_Load(object sender, EventArgs e)
        {
            this.pbIcon.ContextMenuStrip = new ContextMenuStrip();
            
        }
        private bool CheckControlValidation()
        {
            if (this.txtPassword.Text == "")
                return false;
            if (this.txtUserID.Text == "")
                return false;
            return true;
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (!CheckControlValidation())
            {
                this.lbState.Text = "Vui lòng nhập đầy đủ thông tin đăng nhập!";
                this.lbState.ForeColor = Color.Red;
                return;
            }
            DTO.NHANVIEN staff = _bulStaff.getStaffByUsername(this.txtUserID.Text);
            if (staff != null)
            {
                string pass = ExtendClass.MD5Encryptor.MD5Hash(this.txtPassword.Text);
                if (staff.MatKhau == pass)
                {
                    ExtendClass.UserAccess.Instance.SetUserId = staff.MaNV;
                    ExtendClass.UserAccess.Instance.SetStaffName = staff.HoTen;
                    BUL.BUL_NhomNguoiDung _bulGroupUser = new BUL.BUL_NhomNguoiDung();
                    ExtendClass.UserAccess.Instance.SetAccessLevel = _bulGroupUser.getAccessLevelByGroupUserId(staff.MaNhom);
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    this.Close();
                }
                else
                {
                    this.lbState.Text = "Mật khẩu không chính xác!";
                    this.lbState.ForeColor = Color.Red;
                    this.txtPassword.Text = null;
                    return;
                }
            }
            else
            {
                this.lbState.Text = "Tên đăng nhập không chính xác!";
                this.lbState.ForeColor = Color.Red;
                this.txtPassword.Text = null;
                return;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void Login_Form_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnLogin_Click(sender, e);
            }
        }

        private void txtUserID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnLogin_Click(sender, e);
            }
        }
    }
}