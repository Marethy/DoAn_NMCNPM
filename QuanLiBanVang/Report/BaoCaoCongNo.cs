using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace QuanLiBanVang.Report
{
    public partial class BaoCaoCongNo : DevExpress.XtraReports.UI.XtraReport
    {
        int _selection;
        public BaoCaoCongNo()
        {
            InitializeComponent();
            _selection = 0;
        }
        public BaoCaoCongNo(DateTime date)
        {
            InitializeComponent();
            this.xrLabelDate.Text = (date.Day + "/" + date.Month + "/" + date.Year).ToString();
            _selection = 0;
        }
        public BaoCaoCongNo(int selection)
        {
            InitializeComponent();
            this.xrLabelDate.Text = (DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year).ToString();
            _selection = selection;
            if(_selection == 1)
            {
                this.Detail.SortFields.Add(new GroupField("SoTienNo",XRColumnSortOrder.Descending));
            }
            else if (selection == 2)
            {
                this.Detail.SortFields.Add(new GroupField("SoTienNo",XRColumnSortOrder.Ascending));
            }
        }
    }
}
