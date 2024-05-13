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
using QuanLiBanVang.Model;

namespace QuanLiBanVang.Form
{
    public partial class SoTienTraTruoc_Form : DevExpress.XtraEditors.XtraForm
    {

        private BUL.BUL_BangThamSo bulThamSo;
        private decimal total;
        private decimal prepaidExpenses;
        public SoTienTraTruoc_Form()
        {
            this.bulThamSo = new BUL.BUL_BangThamSo();
           
            InitializeComponent();
        }

        public SoTienTraTruoc_Form(decimal total)
        {
            InitializeComponent();
            this.total = total;
        }
        private void SoTienTraTruoc_Load(object sender, EventArgs e)
        {

        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            this.prepaidExpenses = Decimal.Parse(this.textEditSoTienTraTruoc.Text);
            if (Decimal.Compare(this.prepaidExpenses, this.total) > 0)
            {
                MessageBox.Show(ErrorMessage.EXCEEDS_TOTAL, ErrorMessage.ERROR_MESSARE_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }
            decimal MINIMUN_PERCENTAGE = Convert.ToDecimal(this.bulThamSo.getValueByArgument("TienTraToiThieu"));
            if (Decimal.Compare(this.prepaidExpenses, Decimal.Multiply(this.total, MINIMUN_PERCENTAGE)) < 0)
            {
                MessageBox.Show(ErrorMessage.NOT_QUALIFIED_TO_OWE, ErrorMessage.ERROR_MESSARE_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                // close and show new form
                this.Close();
                PhieuThuTienNo_Form phieuNo = new PhieuThuTienNo_Form();
                phieuNo.ShowDialog();
            }
        }
    }
}