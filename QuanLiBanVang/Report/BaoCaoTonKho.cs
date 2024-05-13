using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace QuanLiBanVang.Report
{
    public partial class BaoCaoTonKho : DevExpress.XtraReports.UI.XtraReport
    {
        public BaoCaoTonKho()
        {
            InitializeComponent();
        }
        public BaoCaoTonKho(DateTime date)
        {

            InitializeComponent();
            this.xrlblDate.Text = (date.Day + "/" + date.Month + "/" + date.Year).ToString();
        }
    }
}
