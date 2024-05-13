namespace QuanLiBanVang.Form
{
    partial class BaoCaoCongNo_Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BaoCaoCongNo_Form));
            this.groupControlInfo = new DevExpress.XtraEditors.GroupControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.rdoGroupSelection = new DevExpress.XtraEditors.RadioGroup();
            this.btnExport = new DevExpress.XtraEditors.SimpleButton();
            this.btnDisplay = new DevExpress.XtraEditors.SimpleButton();
            this.groupControlReport = new DevExpress.XtraEditors.GroupControl();
            this.dcmvReport = new DevExpress.XtraPrinting.Preview.DocumentViewer();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlInfo)).BeginInit();
            this.groupControlInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rdoGroupSelection.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlReport)).BeginInit();
            this.groupControlReport.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupControlInfo
            // 
            this.groupControlInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControlInfo.Controls.Add(this.labelControl2);
            this.groupControlInfo.Controls.Add(this.rdoGroupSelection);
            this.groupControlInfo.Controls.Add(this.btnExport);
            this.groupControlInfo.Controls.Add(this.btnDisplay);
            this.groupControlInfo.Location = new System.Drawing.Point(12, 39);
            this.groupControlInfo.Name = "groupControlInfo";
            this.groupControlInfo.Size = new System.Drawing.Size(754, 64);
            this.groupControlInfo.TabIndex = 3;
            this.groupControlInfo.Text = "Tùy chọn";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(16, 35);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(49, 13);
            this.labelControl2.TabIndex = 7;
            this.labelControl2.Text = "Xem theo:";
            // 
            // rdoGroupSelection
            // 
            this.rdoGroupSelection.EditValue = ((short)(0));
            this.rdoGroupSelection.Location = new System.Drawing.Point(71, 27);
            this.rdoGroupSelection.Name = "rdoGroupSelection";
            this.rdoGroupSelection.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(((short)(0)), "Mặc định"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(((byte)(1)), "Nợ giảm dần"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(((short)(2)), "Nợ tăng dần")});
            this.rdoGroupSelection.Size = new System.Drawing.Size(248, 29);
            this.rdoGroupSelection.TabIndex = 6;
            // 
            // btnExport
            // 
            this.btnExport.Image = ((System.Drawing.Image)(resources.GetObject("btnExport.Image")));
            this.btnExport.Location = new System.Drawing.Point(497, 26);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(100, 27);
            this.btnExport.TabIndex = 5;
            this.btnExport.Text = "Xuất file PDF";
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnDisplay
            // 
            this.btnDisplay.Image = ((System.Drawing.Image)(resources.GetObject("btnDisplay.Image")));
            this.btnDisplay.Location = new System.Drawing.Point(391, 26);
            this.btnDisplay.Name = "btnDisplay";
            this.btnDisplay.Size = new System.Drawing.Size(100, 27);
            this.btnDisplay.TabIndex = 4;
            this.btnDisplay.Text = "Xem báo cáo";
            this.btnDisplay.Click += new System.EventHandler(this.btnDisplay_Click);
            // 
            // groupControlReport
            // 
            this.groupControlReport.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControlReport.Controls.Add(this.dcmvReport);
            this.groupControlReport.Location = new System.Drawing.Point(12, 109);
            this.groupControlReport.Name = "groupControlReport";
            this.groupControlReport.Size = new System.Drawing.Size(756, 427);
            this.groupControlReport.TabIndex = 4;
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
            this.dcmvReport.Size = new System.Drawing.Size(752, 405);
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
            this.labelControl1.Location = new System.Drawing.Point(12, 9);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(756, 24);
            this.labelControl1.TabIndex = 5;
            this.labelControl1.Text = "Báo cáo công nợ";
            // 
            // BaoCaoCongNo_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(780, 545);
            this.Controls.Add(this.groupControlInfo);
            this.Controls.Add(this.groupControlReport);
            this.Controls.Add(this.labelControl1);
            this.Name = "BaoCaoCongNo_Form";
            this.Text = "Báo cáo công nợ";
            this.Load += new System.EventHandler(this.BaoCaoCongNo_Form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControlInfo)).EndInit();
            this.groupControlInfo.ResumeLayout(false);
            this.groupControlInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rdoGroupSelection.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlReport)).EndInit();
            this.groupControlReport.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControlInfo;
        private DevExpress.XtraEditors.SimpleButton btnExport;
        private DevExpress.XtraEditors.SimpleButton btnDisplay;
        private DevExpress.XtraEditors.GroupControl groupControlReport;
        private DevExpress.XtraPrinting.Preview.DocumentViewer dcmvReport;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.RadioGroup rdoGroupSelection;
    }
}