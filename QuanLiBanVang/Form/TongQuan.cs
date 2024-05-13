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

namespace QuanLiBanVang
{
    public partial class TongQuan : DevExpress.XtraEditors.XtraForm
    {
        private decimal _income;
        private decimal _cost;
        private DTO.CalculateNumberOfCostBill_Result _numberOfCostBill;
        private DTO.CalculateNumberOfIncomeBill_Result _numberOfIncomeBill;
        private DTO.CalculateStoreStatus_Result _storeStatus;
        private CalculateNumberOfPartner_Result _numberOfPartnerResult;///Nghia
        private BUL.BUL_TongQuanStore _bulTongQuan;
        public TongQuan()
        {
            InitializeComponent();
            _bulTongQuan = new BUL.BUL_TongQuanStore();
        }
        public void loadData()
        {
            
            this.sANPHAMTableAdapter.Fill(this.dBQLCuaHangVangBacDaQuyDataSet.SANPHAM);
            DateTime t = DateTime.Now;
            _income = _bulTongQuan.calculateIncomeInDate(t);
            _cost = _bulTongQuan.calculateCostInDate(t);
            _numberOfCostBill = _bulTongQuan.calculateNumberOfCostBill(t);
            _numberOfIncomeBill = _bulTongQuan.calculateNumberOfIncomeBill(t);
            _storeStatus = _bulTongQuan.calculateStoreStatus();
            _numberOfPartnerResult = _bulTongQuan.CalculateNumberOfPartner();//Nghia
            this.lblIncome.Text = Math.Round(_income).ToString();
            this.lblCost.Text = Math.Round(_cost).ToString();
            this.lblTotal.Text = (Math.Round(_income - _cost)).ToString();
            this.lblSaleBill.Text = _numberOfIncomeBill.sophieuban.Value.ToString();
            this.lblOweBill.Text = _numberOfIncomeBill.sophieuno.Value.ToString();
            this.lblServiceBill.Text = _numberOfIncomeBill.sophieudv.Value.ToString();
            this.lblBuyBill.Text = _numberOfCostBill.sophieumua.Value.ToString();
            this.lblImportBill.Text = _numberOfCostBill.sophieunhap.Value.ToString();
            this.lblOutsourcing.Text = _numberOfCostBill.sophieugiacong.Value.ToString();
            this.lblFeeBill.Text = _numberOfCostBill.sophieuchi.Value.ToString();
            this.lblInStock.Text = _storeStatus.sodangban.Value.ToString();
            this.lblPause.Text = _storeStatus.songungban.Value.ToString();
            this.lblOutOfStock.Text = _storeStatus.sosanphamhet.Value.ToString();
            this.lblLastUpdate.Text = DateTime.Now.ToString();
            labelControlSLTho.Text = (_numberOfPartnerResult.SlTho ?? 0).ToString();
            labelControlSlKH.Text = (_numberOfPartnerResult.SlKhachHang ?? 0).ToString();
            labelControlSLNCC.Text = (_numberOfPartnerResult.SlNCC ?? 0).ToString();}
        private void TongQuan_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dBQLCuaHangVangBacDaQuyDataSet.SANPHAM' table. You can move, or remove it, as needed.
            //this.sANPHAMTableAdapter.Fill(this.dBQLCuaHangVangBacDaQuyDataSet.SANPHAM);
            //DateTime t= DateTime.Now;
            //_income = _bulTongQuan.calculateIncomeInDate(t);
            //_cost = _bulTongQuan.calculateCostInDate(t);
            //_numberOfCostBill = _bulTongQuan.calculateNumberOfCostBill(t);
            //_numberOfIncomeBill = _bulTongQuan.calculateNumberOfIncomeBill(t);
            //_storeStatus = _bulTongQuan.calculateStoreStatus();
            this.loadData();
            

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.dBQLCuaHangVangBacDaQuyDataSet.SANPHAM.Clear();
            this.loadData();
            this.chartControlProduct.RefreshData();
        }
    }
}