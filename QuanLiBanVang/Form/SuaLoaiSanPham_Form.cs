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
    public partial class SuaLoaiSanPham_Form : DevExpress.XtraEditors.XtraForm
    {
        DTO.LOAISANPHAM _productType;
        BUL.BUL_LoaiSanPham _bulProductType;
        public SuaLoaiSanPham_Form()
        {
            InitializeComponent();
            _bulProductType = new BUL.BUL_LoaiSanPham();
            _productType = new DTO.LOAISANPHAM();
        }
        public SuaLoaiSanPham_Form(int id)
        {
            InitializeComponent();
            _bulProductType = new BUL.BUL_LoaiSanPham();
            _productType = new DTO.LOAISANPHAM();
            _productType = _bulProductType.getProductTypeById(id);
        }
        private void SuaLoaiSanPham_Form_Load(object sender, EventArgs e)
        {
            

            if (_productType != null)
            {
                this.txtName.Text = _productType.TenLoaiSP;
                double? tmp = _productType.PhanTramLoiNhuan * 100;
                this.txtPercent.Text = Math.Round(tmp.Value).ToString(); ;
            }
        }
        public bool CheckControlValidation()
        {
            foreach (Control control in this.groupControlInfo.Controls)
            {
                if (control is TextEdit)
                {
                    if ((control as TextEdit).Text == "")
                    {
                        return false;
                    }
                }
                if (control is ComboBoxEdit)
                {
                    if ((control as ComboBoxEdit).SelectedIndex == -1)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.CheckControlValidation())
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return;
            }
            else
            {
                _productType.PhanTramLoiNhuan = (float)(float.Parse(txtPercent.Text)/100);
                _productType.TenLoaiSP = txtName.Text;
                _bulProductType.updateProductType(_productType);
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                MessageBox.Show("Cập nhật loại sản phẩm thành công!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }
    }
}