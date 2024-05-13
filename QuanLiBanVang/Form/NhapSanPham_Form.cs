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
    public partial class NhapSanPham_Form : DevExpress.XtraEditors.XtraForm
    {
        private BUL.BUL_SanPham _bulSanPham;
        private BUL.BUL_LoaiSanPham _bulLoaiSanPham;
        private BUL.BUL_BaoCaoTonKho _bulInventory;
        public NhapSanPham_Form()
        {
            InitializeComponent();
            _bulSanPham = new BUL.BUL_SanPham();
            _bulLoaiSanPham = new BUL.BUL_LoaiSanPham();
            _bulInventory = new BUL.BUL_BaoCaoTonKho();
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
        private void Clear()
        {
            this.txtName.Text = "";
            this.txtWeight.Text = "";
            this.cboProductType.SelectedIndex = -1;
            this.radioGroupState.SelectedIndex = 0;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.CheckControlValidation())
            {
                MessageBox.Show("Ban chua nhap day du thong tin can thiet.Vui long nhap lai!");
            }
            else
            {
                DTO.SANPHAM _product = new DTO.SANPHAM();

                _product.TenSP = this.txtName.Text;
                _product.MaLoaiSP = ((this.cboProductType.SelectedItem as ExtendClass.ContainerItem).Value as DTO.LOAISANPHAM).MaLoaiSP;
                _product.TrongLuong = float.Parse(this.txtWeight.Text);
                _product.TinhTrang = (bool)(this.radioGroupState.EditValue);
                _bulSanPham.addNewProduct(_product);

                DTO.BAOCAOTONKHO _newReport = new DTO.BAOCAOTONKHO();
                _newReport.NgayBC = DateTime.Now.Date;
                _newReport.MaSP = _product.MaSP;
                _newReport.TonDau = 0;
                _newReport.SoLuongMua = 0;
                _newReport.SoLuongBan = 0;
                _newReport.TonCuoi = 0;

                _bulInventory.addNewInventoryReport(_newReport);
                MessageBox.Show("Nhập sản phẩm thành công!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                if (!this.IsMdiChild)
                    this.Close();
                else
                    this.Clear();
            }
        }

        private void NhapSanPham_Form_Load(object sender, EventArgs e)
        {
            this.cboProductType.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            List<DTO.LOAISANPHAM> listProductType = _bulLoaiSanPham.getAllProductType();
            foreach(DTO.LOAISANPHAM item in listProductType)
            {
                ExtendClass.ContainerItem cboItem = new ContainerItem();
                cboItem.Text = item.TenLoaiSP;
                cboItem.Value = item;
                this.cboProductType.Properties.Items.Add(cboItem);
            }
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void NhapSanPham_Form_SizeChanged(object sender, EventArgs e)
        {
            groupControlInfo.Left = (ClientSize.Width - groupControlInfo.Width) / 2;
            btnCancel.Left = groupControlInfo.Right - btnSave.Width;
            btnSave.Left = btnCancel.Left - btnSave.Width - 10; 
        }
    }
}