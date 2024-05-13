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
using BUL;
using QuanLiBanVang.ExtendClass;
using QuanLiBanVang.Model;

namespace QuanLiBanVang.Form
{
    public partial class PhieuThuTienNo_Form : DevExpress.XtraEditors.XtraForm
    {
        // private static readonly decimal ACCEPTABLE_FIRST_PREPAID_PERCENTAGE = 0.6M;
        // private static readonly string NOT_ACCEPTABLE_PREPAY_VALUE_MESSAGE = ";
        private static readonly string PAYMENT_DATE_NOT_VALID_MESSAGE = "Ngày trả không được sớm hơn ngày lập phiếu nợ";

        BUL_PhieuThuTienNo bulDeptReceipt; // to handle the operation with database
        BUL_KhachHang bulKhachHang;
        BUL_BangThamSo bulBangThamSo;
        PHIEUBANHANG receipt; // save the receipt if this is the first dept receipt
        PHIEUTHUTIENNO previousDeptRecepit; // if this is NOT the first dept receipt
        bool isTheFirstDept;

        public delegate void RefreshDebtReceiptData();
        public RefreshDebtReceiptData refreshDebtReceiptDataCallback;

        public PhieuThuTienNo_Form()
        {
            InitializeComponent();

        }

        /// <summary>
        /// constructor for the first dept receipt
        /// </summary>
        /// <param name="receipt"></param>
        public PhieuThuTienNo_Form(PHIEUBANHANG receipt)
        {
            InitializeComponent();
            this.bulKhachHang = new BUL_KhachHang();
            this.bulDeptReceipt = new BUL_PhieuThuTienNo();
            this.bulBangThamSo = new BUL_BangThamSo();
            this.receipt = receipt;

            // set defaul value for date time picker : system current date
            this.dateTimePickerNgayLap.DateTime = DateTime.Now.Date;
            this.dateTimePickerNgayLap.ReadOnly = true;
            this.dateTimePickerNgayTra.DateTime = DateTime.Now.Date;
            this.previousDeptRecepit = null;
            // indicate that, this is the first dept
            this.isTheFirstDept = true;
            // this is the first decpt receipt 
            this.textEditMaPhieuBanHang.Text = receipt.SoPhieuBH.ToString();
            this.textEditTenKhachHang.Text = this.bulKhachHang.GetKhachhangById(receipt.MaKH).TenKH;
            this.textEditMaKhachHang.Text = receipt.MaKH.ToString();

            // the first dept
            this.textEditSoTienNo.Text = receipt.TongTien.ToString();
            this.labelControlRecommendedInput.Visible = true;
            decimal ACCEPTABLE_FIRST_PREPAID_PERCENTAGE = Convert.ToDecimal(this.bulBangThamSo.getValueByArgument("TienTraToiThieu"));
            decimal minimumAmout = decimal.Multiply(ACCEPTABLE_FIRST_PREPAID_PERCENTAGE, receipt.TongTien);
            this.labelControlRecommendedInput.Text = "(Tối thiểu: " + Math.Round(minimumAmout) + ")";
        }

        public PhieuThuTienNo_Form(PHIEUTHUTIENNO previousDeptReceipt)
        {
            InitializeComponent();
            this.bulKhachHang = new BUL_KhachHang();
            this.bulDeptReceipt = new BUL_PhieuThuTienNo();
            this.previousDeptRecepit = previousDeptReceipt;
            // indicate that, this is NOT the first dept
            this.isTheFirstDept = false;
            // this is the first decpt receipt 
            this.textEditMaPhieuBanHang.Text = this.previousDeptRecepit.SoPhieuBH.ToString();

            this.receipt = new BUL_PhieuBanHang().findReceiptById(this.previousDeptRecepit.SoPhieuBH);
            this.textEditTenKhachHang.Text = this.bulKhachHang.GetKhachhangById(this.receipt.MaKH).TenKH;
            this.textEditMaKhachHang.Text = this.receipt.MaKH.ToString();

            // the first dept
            this.textEditSoTienNo.Text = this.previousDeptRecepit.SoTienConLai.ToString();

            // set defaul value for date time picker : system current date
            this.dateTimePickerNgayLap.DateTime = DateTime.Now.Date;
            this.dateTimePickerNgayLap.ReadOnly = true;
            this.dateTimePickerNgayTra.DateTime = DateTime.Now.Date;
            this.labelControlRecommendedInput.Visible = false;

        }
        private void PhieuThuTienNo_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Save the dept receipt into database.
        /// Here including checks to make sure all values are valid before being saved
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void simpleButtonLuu_Click(object sender, EventArgs e)
        {
            // make sure that all input is valid
            if (string.IsNullOrEmpty(this.textEditSoTienTra.Text)
                || string.IsNullOrEmpty(this.textEditConLai.Text) ||
                this.dateTimePickerNgayLap.DateTime == null
                || this.dateTimePickerNgayTra.DateTime == null)
            {
                MessageBox.Show(ErrorMessage.CLIENT_INVALID_INPUT_MESSAGE, ErrorMessage.ERROR_MESSARE_TITLE, MessageBoxButtons.OK
                    , MessageBoxIcon.Error);
                return;
            }


            /// If any values are valid  ////

            decimal frequenterPrepay = decimal.Parse(this.textEditSoTienTra.Text.Trim());
            decimal deptAmount = decimal.Parse(this.textEditSoTienNo.Text.Trim());
            if (this.isTheFirstDept) // is the first dept recepit
            {
                // get minimun percentage for the first repayment
                decimal ACCEPTABLE_FIRST_PREPAID_PERCENTAGE = Convert.ToDecimal(this.bulBangThamSo.getValueByArgument("TienTraToiThieu"));
                if (decimal.Compare(frequenterPrepay, decimal.Multiply(deptAmount, ACCEPTABLE_FIRST_PREPAID_PERCENTAGE)) < 0)
                {
                    MessageBox.Show("Số tiền trả trước không được nhỏ hơn" + ACCEPTABLE_FIRST_PREPAID_PERCENTAGE + "% tổng tiền phiếu bán.", ErrorMessage.ERROR_MESSARE_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else // start to save into database
                {
                    PHIEUTHUTIENNO newDeptReceipt = new PHIEUTHUTIENNO
                    {
                        SoPhieuBH = this.receipt.SoPhieuBH,
                        NgayLap = this.dateTimePickerNgayLap.DateTime.Date,
                        NgayTra = this.dateTimePickerNgayTra.DateTime.Date,
                        MaNV = UserAccess.Instance.GetUserId,
                        SoTienNo = deptAmount,
                        SoTienTra = frequenterPrepay,
                        SoTienConLai = decimal.Subtract(deptAmount, frequenterPrepay)
                    };

                    // start to save into database
                    this.bulDeptReceipt.add(newDeptReceipt);
                    this.refreshDebtReceiptDataCallback(); // delegate to main form to refresh data
                    // PhieuThuTienNo recentSavedDeptReceipt = this.bulDeptReceipt
                    if (decimal.Compare(newDeptReceipt.SoTienConLai, decimal.Zero) == 0)
                    {
                        if (MessageBox.Show("Đã lưu phiếu thu nợ . Phiếu nợ đã được trả đủ !", NotificationMessage.MESSAGE_TITLE,
                               MessageBoxButtons.OK, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.OK)
                        {
                            this.Close();
                        }
                    }
                    else if (MessageBox.Show("Đã lưu phiếu thu nợ .Ngày hẹn trả : " + this.dateTimePickerNgayTra.DateTime.ToShortDateString(), NotificationMessage.MESSAGE_TITLE,
                          MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                    {
                        this.Close();
                    }
                }
            }
            else // NOT the first dept recepit
            {
                PHIEUTHUTIENNO newDeptReceipt = new PHIEUTHUTIENNO
                {
                    SoPhieuBH = this.previousDeptRecepit.SoPhieuBH,
                    NgayLap = this.dateTimePickerNgayLap.DateTime.Date,
                    NgayTra = this.dateTimePickerNgayTra.DateTime.Date,
                    MaNV = UserAccess.Instance.GetUserId,
                    SoTienNo = deptAmount,
                    SoTienTra = frequenterPrepay,
                    SoTienConLai = decimal.Subtract(deptAmount, frequenterPrepay)
                };
                // start to save into database
                this.bulDeptReceipt.add(newDeptReceipt);
                this.refreshDebtReceiptDataCallback(); // delegate to main form to refresh data
                if (decimal.Compare(newDeptReceipt.SoTienConLai, decimal.Zero) == 0)
                {
                    if (MessageBox.Show("Đã lưu phiếu thu nợ . Phiếu nợ đã được trả đủ !", NotificationMessage.MESSAGE_TITLE,
                           MessageBoxButtons.OK, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.OK)
                    {
                        this.Close();
                    }
                }
                else if (MessageBox.Show("Đã lưu phiếu thu nợ .Ngày hẹn trả : " + this.dateTimePickerNgayTra.DateTime.ToShortDateString(), NotificationMessage.MESSAGE_TITLE,
                          MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                {
                    this.Close();
                }
            }

        }
        /// <summary>
        /// Check the date to be valid when user choose the date for payment
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dateTimePickerNgayTra_ValueChanged(object sender, EventArgs e)
        {
            // make sure that the pay date is later than the date that create the 
            // dept receipt
            if (DateTime.Compare(this.dateTimePickerNgayTra.DateTime, this.dateTimePickerNgayLap.DateTime) < 0)
            {
                MessageBox.Show(PAYMENT_DATE_NOT_VALID_MESSAGE, ErrorMessage.ERROR_MESSARE_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.dateTimePickerNgayTra.DateTime = DateTime.Now; // set to the current date time
                return;
            }
        }

        private void textEditSoTienTra_EditValueChanged(object sender, EventArgs e)
        {
            // if the string is empty or null , do nothing
            if (string.IsNullOrEmpty(this.textEditSoTienTra.Text)) { return; }
            // recompute the rest 
            decimal frequenterPrepay = decimal.Parse(this.textEditSoTienTra.Text.Trim());
            decimal deptAmount = decimal.Parse(this.textEditSoTienNo.Text.Trim());
            decimal rest = decimal.Subtract(deptAmount, frequenterPrepay);
            // make sure we do not have negative result
            if (decimal.Compare(deptAmount, frequenterPrepay) < 0)
            {
                this.textEditSoTienTra.ResetText();
            }
            else
            {
                this.textEditConLai.Text = rest.ToString();
            }
        }

        private void PhieuThuTienNo_Form_SizeChanged(object sender, EventArgs e)
        {
            groupControl1.Left = (ClientSize.Width - groupControl1.Width) / 2;
            simpleButtonThoat.Left = groupControl1.Right - simpleButtonLuu.Width;
            simpleButtonLuu.Left = simpleButtonThoat.Left - simpleButtonLuu.Width - 10;
        }

        private void dateTimePickerNgayTra_EditValueChanged(object sender, EventArgs e)
        {
            if (DateTime.Compare(this.dateTimePickerNgayTra.DateTime.Date, this.dateTimePickerNgayLap.DateTime.Date) < 0)
            {
                MessageBox.Show("Ngày trả nợ phải lớn hơn hoặc bằng ngày lập phiếu nơ", "Lỗi", MessageBoxButtons.OK
                     , MessageBoxIcon.Error);
                // update date value
                this.dateTimePickerNgayLap.DateTime = DateTime.Now.Date;
                this.dateTimePickerNgayTra.DateTime = DateTime.Now.Date;
            }
        }

        private void simpleButtonThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textEditSoTienTra_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Back || e.KeyCode != Keys.Delete)
            {
                // if the string is empty or null , do nothing
                if (string.IsNullOrEmpty(this.textEditSoTienTra.Text)) { return; }
                // recompute the rest 
                decimal frequenterPrepay = decimal.Parse(this.textEditSoTienTra.Text.Trim());
                decimal deptAmount = decimal.Parse(this.textEditSoTienNo.Text.Trim());
                decimal rest = decimal.Subtract(deptAmount, frequenterPrepay);
                // make sure we do not have negative result
                if (decimal.Compare(deptAmount, frequenterPrepay) < 0)
                {

                    if (MessageBox.Show("Số tiền nhập vượt quá số tiền nợ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error) == System.Windows.Forms.DialogResult.OK)
                    {

                        this.textEditSoTienTra.ResetText();
                        this.textEditSoTienTra.Text = decimal.Zero.ToString();
                        this.textEditConLai.Text = deptAmount.ToString();
                        e.Handled = true;
                    }
                }
                else
                {
                    this.textEditConLai.Text = rest.ToString();
                }
            }
        }
    }
}