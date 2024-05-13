namespace QuanLiBanVang.Report
{
    partial class BaoCaoTonKho_Form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BaoCaoTonKho_Form));
            this.groupControlInfo = new DevExpress.XtraEditors.GroupControl();
            this.btnExport = new DevExpress.XtraEditors.SimpleButton();
            this.btnDisplay = new DevExpress.XtraEditors.SimpleButton();
            this.dtpkDisplayDate = new DevExpress.XtraEditors.DateEdit();
            this.labelControlDate = new DevExpress.XtraEditors.LabelControl();
            this.groupControlReport = new DevExpress.XtraEditors.GroupControl();
            this.dcmvReport = new DevExpress.XtraPrinting.Preview.DocumentViewer();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlInfo)).BeginInit();
            this.groupControlInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtpkDisplayDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpkDisplayDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlReport)).BeginInit();
            this.groupControlReport.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupControlInfo
            // 
            this.groupControlInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControlInfo.Controls.Add(this.btnExport);
            this.groupControlInfo.Controls.Add(this.btnDisplay);
            this.groupControlInfo.Controls.Add(this.dtpkDisplayDate);
            this.groupControlInfo.Controls.Add(this.labelControlDate);
            this.groupControlInfo.Location = new System.Drawing.Point(12, 42);
            this.groupControlInfo.Name = "groupControlInfo";
            this.groupControlInfo.Size = new System.Drawing.Size(754, 65);
            this.groupControlInfo.TabIndex = 0;
            this.groupControlInfo.Text = "Thông tin báo cáo";
            // 
            // btnExport
            // 
            this.btnExport.Image = ((System.Drawing.Image)(resources.GetObject("btnExport.Image")));
            this.btnExport.Location = new System.Drawing.Point(372, 26);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(100, 27);
            this.btnExport.TabIndex = 5;
            this.btnExport.Text = "Xuất file PDF";
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnDisplay
            // 
            this.btnDisplay.Image = ((System.Drawing.Image)(resources.GetObject("btnDisplay.Image")));
            this.btnDisplay.Location = new System.Drawing.Point(266, 26);
            this.btnDisplay.Name = "btnDisplay";
            this.btnDisplay.Size = new System.Drawing.Size(100, 27);
            this.btnDisplay.TabIndex = 4;
            this.btnDisplay.Text = "Xem báo cáo";
            this.btnDisplay.Click += new System.EventHandler(this.btnDisplay_Click);
            // 
            // dtpkDisplayDate
            // 
            this.dtpkDisplayDate.EditValue = null;
            this.dtpkDisplayDate.Location = new System.Drawing.Point(89, 30);
            this.dtpkDisplayDate.Name = "dtpkDisplayDate";
            this.dtpkDisplayDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpkDisplayDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpkDisplayDate.Properties.DisplayFormat.FormatString = "dd-MM-yyyy";
            this.dtpkDisplayDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.dtpkDisplayDate.Properties.EditFormat.FormatString = "dd-MM-yyyy";
            this.dtpkDisplayDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.dtpkDisplayDate.Size = new System.Drawing.Size(124, 20);
            this.dtpkDisplayDate.TabIndex = 2;
            // 
            // labelControlDate
            // 
            this.labelControlDate.Location = new System.Drawing.Point(31, 33);
            this.labelControlDate.Name = "labelControlDate";
            this.labelControlDate.Size = new System.Drawing.Size(52, 13);
            this.labelControlDate.TabIndex = 0;
            this.labelControlDate.Text = "Ngày xem:";
            // 
            // groupControlReport
            // 
            this.groupControlReport.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControlReport.Controls.Add(this.dcmvReport);
            this.groupControlReport.Location = new System.Drawing.Point(12, 113);
            this.groupControlReport.Name = "groupControlReport";
            this.groupControlReport.Size = new System.Drawing.Size(756, 420);
            this.groupControlReport.TabIndex = 1;
            this.groupControlReport.Text = "Bảng báo cáo";
            // 
            // dcmvReport
            // 
            this.dcmvReport.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dcmvReport.IsMetric = false;
            this.dcmvReport.Location = new System.Drawing.Point(2, 20);
            this.dcmvReport.Name = "dcmvReport";
            this.dcmvReport.Size = new System.Drawing.Size(752, 379);
            this.dcmvReport.TabIndex = 0;
            // 
            // labelControl1
            // 
            this.labelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.labelControl1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl1.Location = new System.Drawing.Point(12, 12);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(756, 24);
            this.labelControl1.TabIndex = 2;
            this.labelControl1.Text = "Báo cáo tồn kho";
            // 
            // BaoCaoTonKho_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(780, 545);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.groupControlReport);
            this.Controls.Add(this.groupControlInfo);
            this.Name = "BaoCaoTonKho_Form";
            this.Text = "Báo cáo tồn kho";
            this.Load += new System.EventHandler(this.BaoCaoTonKho_Form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControlInfo)).EndInit();
            this.groupControlInfo.ResumeLayout(false);
            this.groupControlInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtpkDisplayDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpkDisplayDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlReport)).EndInit();
            this.groupControlReport.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControlInfo;
        private DevExpress.XtraEditors.SimpleButton btnDisplay;
        private DevExpress.XtraEditors.DateEdit dtpkDisplayDate;
        private DevExpress.XtraEditors.LabelControl labelControlDate;
        private DevExpress.XtraEditors.GroupControl groupControlReport;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraPrinting.Preview.DocumentViewer dcmvReport;
        private DevExpress.XtraEditors.SimpleButton btnExport;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
    }
}