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
using DTO;

namespace QuanLiBanVang.Form
{
    public partial class ThayDoiQuyDinh_Form : DevExpress.XtraEditors.XtraForm
    {
        private BUL.BUL_BangThamSo _bulAgurment;
         
        public ThayDoiQuyDinh_Form()
        {
            InitializeComponent();
            _bulAgurment = new BUL.BUL_BangThamSo();
        }

        private void ThayDoiQuyDinh_Form_Load(object sender, EventArgs e)
        {
            List<DTO.BANGTHAMSO> listAgurment = _bulAgurment.getAllAgurment();
            foreach (DTO.BANGTHAMSO item in listAgurment)
            {
                ExtendClass.ContainerItem cboItem = new ExtendClass.ContainerItem();
                if (item.TenThamSo.Equals("PhanTramTienGCThoNhan"))
                    cboItem.Text = "Phần trăm tiền gia công thợ được nhận";
                if (item.TenThamSo.Equals("TienTraToiThieu"))
                    cboItem.Text = "Phần trăm số tiền trả trước tối thiểu";
                if (item.TenThamSo.Equals("SoLuongNhapToiDa"))
                    cboItem.Text = "Số lượng nhập tối đa";
                cboItem.Value = item;
                this.cboAgurment.Properties.Items.Add(cboItem);
            }
        }

        private void cboAgurment_SelectedIndexChanged(object sender, EventArgs e)
        {
            BANGTHAMSO bangthamso =
                ((this.cboAgurment.SelectedItem as ExtendClass.ContainerItem).Value as DTO.BANGTHAMSO);
            if (bangthamso.TenThamSo.Equals("SoLuongNhapToiDa"))
                this.txtValue.Text = Math.Round(bangthamso.GiaTri).ToString();
            else
                this.txtValue.Text =(bangthamso.GiaTri*100).ToString();
            labelControlPhanTram.Visible = !cboAgurment.Text.Equals("Số lượng nhập tối đa");
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string name = ((this.cboAgurment.SelectedItem as ExtendClass.ContainerItem).Value as DTO.BANGTHAMSO).TenThamSo;
            double value=0;
            if (name == "PhanTramTienGCThoNhan" || name == "TienTraToiThieu")
            {
                value = (double.Parse(this.txtValue.Text) / 100);
            }
            else
            {
                value = (double.Parse(this.txtValue.Text));
            }

            this._bulAgurment.updateAgurment(name, value);
            //((this.cboAgurment.SelectedItem as ExtendClass.ContainerItem).Value as DTO.BANGTHAMSO).GiaTri = double.Parse(this.txtValue.Text);
            //this._bulAgurment.updateAgurment(((this.cboAgurment.SelectedItem as ExtendClass.ContainerItem).Value as DTO.BANGTHAMSO).TenThamSo,
            //    (double)((this.cboAgurment.SelectedItem as ExtendClass.ContainerItem).Value as DTO.BANGTHAMSO).GiaTri);
            MessageBox.Show("Thay đổi thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ThayDoiQuyDinh_Form_SizeChanged(object sender, EventArgs e)
        {
            groupControl1.Left = (ClientSize.Width - groupControl1.Width) / 2;
            btnExit.Left = groupControl1.Right - btnSave.Width;
            btnSave.Left = btnExit.Left - btnSave.Width - 10; 
        }
    }
}