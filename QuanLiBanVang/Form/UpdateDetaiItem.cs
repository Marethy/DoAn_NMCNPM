using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using BUL;
using QuanLiBanVang.model;
using QuanLiBanVang.ExtendClass;
using QuanLiBanVang.Model;

namespace QuanLiBanVang.Form
{
    public partial class UpdateDetaiItem : DevExpress.XtraEditors.XtraForm
    {
        public delegate void onDataSendBack(DetailGridViewDataSource arg);
        public onDataSendBack sendBackDelegate;
        public int STT;
        public UpdateDetaiItem()
        {
            InitializeComponent();
        }

        // member contructor
        public UpdateDetaiItem(DetailGridViewDataSource arg)
        {

            this.InitializeComponent();
            /**
             * start to load list product types and coresponding prodcuts from database into view component(ComboBox Edit)
             * 
             */
            // load product types from database
            BUL_LoaiSanPham bulProductTypes = new BUL_LoaiSanPham();
            ContainerItem temporaryItem; // temporary saver
            foreach (LOAISANPHAM item in bulProductTypes.getAllProductType())
            {
                temporaryItem = new ContainerItem
                {
                    Text = item.TenLoaiSP,
                    Value = item,
                };
                this.comboBoxEditLoaiSP.Properties.Items.Add(temporaryItem);
                if (item.MaLoaiSP == arg.MaLoaiSp)
                {
                    this.comboBoxEditLoaiSP.SelectedItem = temporaryItem;
                }
            }
            // set value for view components
            // BUL_SanPham bulProducts = new BUL_SanPham();
            foreach (SANPHAM product in bulProductTypes.getProductsByTypeId(arg.MaLoaiSp))
            {
                temporaryItem = new ContainerItem
                {
                    Text = product.TenSP,
                    Value = product
                };
                this.comboBoxEditSP.Properties.Items.Add(temporaryItem);
                if (product.MaSP == arg.MaSP)
                {
                    this.comboBoxEditSP.SelectedItem = temporaryItem;
                }
            }

            // amount and unit price
            this.textEditSoLuong.Text = arg.SoLuong.ToString();
            this.textEditGiaBan.Text = arg.GiaBan.ToString();
            this.STT = arg.Stt;

        }

        //private void button2_Click(object sender, EventArgs e)
        //{
        //    // close the form
        //    this.Close();
        //}


        private void UpdateDetaiItem_Load(object sender, EventArgs e)
        {

        }

        // listener for combobox loai SP
        private void comboBoxEdit2_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (this.comboBoxEditSP.SelectedItem == null) { return; }
            ContainerItem selectedItem = (ContainerItem)this.comboBoxEditSP.SelectedItem;
            SANPHAM sanPham = (SANPHAM)selectedItem.Value;
            ContainerItem productTypeItem = (ContainerItem)this.comboBoxEditLoaiSP.SelectedItem;
            LOAISANPHAM prodcuctType = (LOAISANPHAM)productTypeItem.Value;
            this.textEditGiaBan.Text = Decimal.Multiply(Convert.ToDecimal(sanPham.GiaMua), Convert.ToDecimal(1 + prodcuctType.PhanTramLoiNhuan)).ToString();
        }

        // listener for combobox SP
        private void comboBoxEditLoaiSP_SelectedIndexChanged(object sender, EventArgs e)
        {
            // update value for combox sp
            // first , clear the items in comboboxSanPham
            this.comboBoxEditSP.Properties.Items.Clear();
            // load all product coresponding to the selected product type
            ContainerItem selectedItem = (ContainerItem)this.comboBoxEditLoaiSP.SelectedItem;
            LOAISANPHAM selectedProductType = (LOAISANPHAM)selectedItem.Value; // hold value of the selected item
            foreach (SANPHAM item in (new BUL_LoaiSanPham()).getProductsByTypeId(selectedProductType.MaLoaiSP))
            {
                // make sure that this product is available to be sold
                if (item.TinhTrang == true)
                {
                    this.comboBoxEditSP.Properties.Items.Add(new ContainerItem
                    {
                        Text = item.TenSP,
                        Value = item
                    });
                }
            }
            this.comboBoxEditSP.SelectedIndex = 0;
        }



        /* check all input data whether is valid or not
         * returns true if all data is valid to be updated ,
         * otherwise returns false
         */
        private bool isValidItem()
        {
            // make sure that no field is empty
            if (string.IsNullOrEmpty(this.textEditSoLuong.Text))
            {
                MessageBox.Show(ErrorMessage.CLIENT_INVALID_INPUT_MESSAGE, ErrorMessage.ERROR_MESSARE_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            // check amount of product in stock
            int numberOfProducts = Int32.Parse(textEditSoLuong.Text.Trim());
            ContainerItem selectedItem = (ContainerItem)this.comboBoxEditSP.SelectedItem;
            SANPHAM selectedProduct = (SANPHAM)selectedItem.Value;
            if (numberOfProducts > selectedProduct.SoLuongTon)
            {
                MessageBox.Show(ErrorMessage.OVER_IN_STOCK_MESSAGE + "\n .Số lượng tồn hiện tại : " + selectedProduct.SoLuongTon.ToString(),
                    ErrorMessage.ERROR_MESSARE_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void simpleButton_Huy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void simpleButton_Ok_Click(object sender, EventArgs e)
        {
            ContainerItem selectedItem = (ContainerItem)this.comboBoxEditLoaiSP.SelectedItem;
            LOAISANPHAM selectedProductType = (LOAISANPHAM)selectedItem.Value; // hold value of the selected item
            selectedItem = (ContainerItem)this.comboBoxEditSP.SelectedItem;
            SANPHAM sanPham = (SANPHAM)selectedItem.Value;
            // start to send back data backto main form
            if (this.isValidItem())
            {
                // create new GridViewDataSource instance
                DetailGridViewDataSource sendBackData = new DetailGridViewDataSource
                {
                    MaLoaiSp = sanPham.MaLoaiSP,
                    LoaiSP = selectedProductType.TenLoaiSP,
                    MaSP = sanPham.MaSP,
                    SoLuong = Int32.Parse(this.textEditSoLuong.Text.Trim()),
                    GiaBan = Math.Round(Decimal.Parse(this.textEditGiaBan.Text)),
                    TenSp = sanPham.TenSP,
                    Stt = this.STT

                };
                sendBackData.ThanhTien = Math.Round(Decimal.Multiply(sendBackData.SoLuong, sendBackData.GiaBan));
                this.sendBackDelegate(sendBackData); // delegate here
                this.Close();
            }
        }



        /* delete to transfer data from form to form*/


    }
}
