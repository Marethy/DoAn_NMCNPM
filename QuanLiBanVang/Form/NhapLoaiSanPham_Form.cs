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
    public partial class NhapLoaiSanPham_Form : DevExpress.XtraEditors.XtraForm
    {
        DTO.LOAISANPHAM _newProductType;
        BUL.BUL_LoaiSanPham _bulProductType;
        public NhapLoaiSanPham_Form()
        {
            InitializeComponent();
            _newProductType = new DTO.LOAISANPHAM();
            _bulProductType = new BUL.BUL_LoaiSanPham();
        }
        public bool CheckControlValidation()
        {
            if (this.txtName.Text == "")
                return false;
            if (this.txtPercent.Text == "")
                return false;
            return true;
        }
        private void Clear()
        {
            this.txtName.Text = "";
            this.txtPercent.Text = "";
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (this.CheckControlValidation())
            {
                _newProductType.PhanTramLoiNhuan = (float)(float.Parse(this.txtPercent.Text)/100);
                _newProductType.TenLoaiSP = this.txtName.Text;
                _bulProductType.addNewProductType(_newProductType);
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                MessageBox.Show("Thêm loại sản phẩm thành công!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (!this.IsMdiChild)
                    this.Close();
                else
                    this.Clear();
            }
            else
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void NhapLoaiSanPham_Form_SizeChanged(object sender, EventArgs e)
        {
            groupControlInfo.Left = (ClientSize.Width - groupControlInfo.Width) / 2;
            btnCancel.Left = groupControlInfo.Right - btnCancel.Width;
            btnSave.Left = btnCancel.Left - btnSave.Width - 10; 
        }
    }
}