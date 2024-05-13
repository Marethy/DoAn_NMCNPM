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
using DevExpress.XtraPrinting;
using System.Diagnostics;

namespace QuanLiBanVang.Form
{
    public partial class BaoCaoCongNo_Form : DevExpress.XtraEditors.XtraForm
    {
        private Report.BaoCaoCongNo _templateReport;
        public BaoCaoCongNo_Form()
        {
            InitializeComponent();
        }

        private void btnDisplay_Click(object sender, EventArgs e)
        {
            _templateReport = null;
            if (rdoGroupSelection.SelectedIndex == 0)
            {
                _templateReport = new Report.BaoCaoCongNo(0);
            }
            else if (rdoGroupSelection.SelectedIndex == 1)
            {
                _templateReport = new Report.BaoCaoCongNo(1);
            }
            else
            {
                _templateReport = new Report.BaoCaoCongNo(2);
            }
            this.dcmvReport.DocumentSource = null;
            this.dcmvReport.DocumentSource = _templateReport;
            _templateReport.CreateDocument();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (this.dcmvReport.DocumentSource != null)
            {
                string fileName = "";
                DialogResult result = this.folderBrowserDialog.ShowDialog();
                if (result == DialogResult.OK)
                {
                    fileName = this.folderBrowserDialog.SelectedPath;


                    PdfExportOptions pdfOption = this._templateReport.ExportOptions.Pdf;
                    pdfOption.Compressed = true;
                    pdfOption.ImageQuality = PdfJpegImageQuality.Medium;
                    pdfOption.NeverEmbeddedFonts = "Tahoma;Courier New";
                    pdfOption.DocumentOptions.Application = "QuanLiBanVang";
                    pdfOption.DocumentOptions.Author = ExtendClass.UserAccess.Instance.GetStaffName;
                    pdfOption.DocumentOptions.Keywords = "Xtra Report";
                    pdfOption.DocumentOptions.Subject = "Bao cao cong no";
                    pdfOption.DocumentOptions.Title = "Báo cáo công nợ";
                    fileName += "\\" + pdfOption.DocumentOptions.Title + ".pdf";
                    //pdfOption.PageRange = "1";
                    _templateReport.ExportToPdf(fileName);
                    MessageBox.Show("Xuất file thành công!","Info",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    this.StartProcess(fileName);
                }
            }
        }
        public void StartProcess(string path)
        {
            Process p = new Process();
            try
            {
                p.StartInfo.FileName = path;
                p.Start();
     
                p.WaitForInputIdle();
            }
            catch { }
        }

        private void BaoCaoCongNo_Form_Load(object sender, EventArgs e)
        {
            
            _templateReport = new Report.BaoCaoCongNo(DateTime.Now);
            this.dcmvReport.DocumentSource = _templateReport;
            _templateReport.CreateDocument();
        }
        
    }
}