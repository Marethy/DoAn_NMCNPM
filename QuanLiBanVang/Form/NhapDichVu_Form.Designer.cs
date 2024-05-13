namespace QuanLiBanVang
{
    partial class NhapDichVu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NhapDichVu));
            this.simpleButtonHuy = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonOK = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.textEditTienCong = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.textEditTenDV = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEditTienCong.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditTenDV.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // simpleButtonHuy
            // 
            this.simpleButtonHuy.Image = ((System.Drawing.Image)(resources.GetObject("simpleButtonHuy.Image")));
            this.simpleButtonHuy.Location = new System.Drawing.Point(191, 139);
            this.simpleButtonHuy.Name = "simpleButtonHuy";
            this.simpleButtonHuy.Size = new System.Drawing.Size(70, 27);
            this.simpleButtonHuy.TabIndex = 9;
            this.simpleButtonHuy.Text = "Huỷ";
            this.simpleButtonHuy.Click += new System.EventHandler(this.simpleButtonHuy_Click);
            // 
            // simpleButtonOK
            // 
            this.simpleButtonOK.Image = ((System.Drawing.Image)(resources.GetObject("simpleButtonOK.Image")));
            this.simpleButtonOK.Location = new System.Drawing.Point(115, 139);
            this.simpleButtonOK.Name = "simpleButtonOK";
            this.simpleButtonOK.Size = new System.Drawing.Size(70, 27);
            this.simpleButtonOK.TabIndex = 8;
            this.simpleButtonOK.Text = "Lưu";
            this.simpleButtonOK.Click += new System.EventHandler(this.simpleButtonOK_Click);
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.textEditTienCong);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.textEditTenDV);
            this.groupControl1.Controls.Add(this.labelControl3);
            this.groupControl1.Location = new System.Drawing.Point(14, 42);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(248, 91);
            this.groupControl1.TabIndex = 9;
            this.groupControl1.Text = "Chi tiết";
            // 
            // textEditTienCong
            // 
            this.textEditTienCong.Location = new System.Drawing.Point(80, 59);
            this.textEditTienCong.Name = "textEditTienCong";
            this.textEditTienCong.Properties.Mask.EditMask = "\\d{1,9}";
            this.textEditTienCong.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.textEditTienCong.Size = new System.Drawing.Size(152, 20);
            this.textEditTienCong.TabIndex = 7;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(15, 62);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(46, 13);
            this.labelControl2.TabIndex = 7;
            this.labelControl2.Text = "Tiền công";
            // 
            // textEditTenDV
            // 
            this.textEditTenDV.Location = new System.Drawing.Point(80, 33);
            this.textEditTenDV.Name = "textEditTenDV";
            this.textEditTenDV.Size = new System.Drawing.Size(152, 20);
            this.textEditTenDV.TabIndex = 6;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(15, 36);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(55, 13);
            this.labelControl3.TabIndex = 1;
            this.labelControl3.Text = "Tên dịch vụ";
            // 
            // labelControl1
            // 
            this.labelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Bold);
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.labelControl1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl1.Location = new System.Drawing.Point(12, 12);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(249, 24);
            this.labelControl1.TabIndex = 8;
            this.labelControl1.Text = "Nhập thông tin dịch vụ";
            // 
            // NhapDichVu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(273, 173);
            this.Controls.Add(this.simpleButtonHuy);
            this.Controls.Add(this.simpleButtonOK);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.labelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "NhapDichVu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nhập dịch vụ";
            this.SizeChanged += new System.EventHandler(this.NhapDichVu_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEditTienCong.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditTenDV.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton simpleButtonHuy;
        private DevExpress.XtraEditors.SimpleButton simpleButtonOK;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.TextEdit textEditTenDV;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit textEditTienCong;
        private DevExpress.XtraEditors.LabelControl labelControl2;

    }
}