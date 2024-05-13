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
using QuanLiBanVang.ExtendClass;
namespace QuanLiBanVang.Report
{
    public partial class SuaSanPham_Form : DevExpress.XtraEditors.XtraForm
    {
        BUL.BUL_SanPham _bulSanPham;
        BUL.BUL_LoaiSanPham _bulLoaiSanPham;
        DTO.SANPHAM _product;
        public SuaSanPham_Form()
        {
            InitializeComponent();
            _bulSanPham = new BUL.BUL_SanPham();
            _product = new DTO.SANPHAM();
            _bulLoaiSanPham = new BUL.BUL_LoaiSanPham();
        }
        public SuaSanPham_Form(int id)
        {
            InitializeComponent();
            _bulSanPham = new BUL.BUL_SanPham();
            _bulLoaiSanPham = new BUL.BUL_LoaiSanPham();
            _product = _bulSanPham.getProductById(id);
        }
        private void SuaSanPham_Form_Load(object sender, EventArgs e)
        {
            List<DTO.LOAISANPHAM> _listProductType = _bulLoaiSanPham.getAllProductType();
            foreach (DTO.LOAISANPHAM item in _listProductType)
            {
                ExtendClass.ContainerItem cboItem = new ContainerItem();
                cboItem.Text = item.TenLoaiSP;
                cboItem.Value = item;
                this.cboProductType.Properties.Items.Add(cboItem);
            }
            for (int i = 0; i < cboProductType.Properties.Items.Count; i++)
            {
                ExtendClass.ContainerItem item = cboProductType.Properties.Items[i] as ExtendClass.ContainerItem;
                DTO.LOAISANPHAM type = (item.Value as DTO.LOAISANPHAM);
                if (type.MaLoaiSP == _product.MaLoaiSP)
                {
                    cboProductType.SelectedIndex = i;
                    break;
                }
            }
                this.radioGroupState.EditValue = (bool)this._product.TinhTrang;
            this.txtName.Text = _product.TenSP;
            
            this.txtWeight.Text = Math.Round(_product.TrongLuong).ToString();
        }
        public bool CheckControlValidation()
        {
            if (this.txtName.Text == "")
                return false;
            if (this.txtWeight.Text == "")
                return false;
            if (this.cboProductType.SelectedIndex == -1)
                return false;
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
                _product.TenSP = this.txtName.Text;
                _product.TrongLuong = float.Parse(this.txtWeight.Text);
                ExtendClass.ContainerItem item = cboProductType.SelectedItem as ExtendClass.ContainerItem;
                DTO.LOAISANPHAM type = item.Value as DTO.LOAISANPHAM;
                _product.MaLoaiSP = type.MaLoaiSP;
                _product.TinhTrang = (bool)this.radioGroupState.EditValue;
                _bulSanPham.updateProduct(_product);
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                MessageBox.Show("Sửa sản phẩm thành công!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
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