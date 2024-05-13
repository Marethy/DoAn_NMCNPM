namespace QuanLiBanVang
{
    partial class NhapTho
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NhapTho));
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.textEditDiaChi = new DevExpress.XtraEditors.TextEdit();
            this.textEditSDT = new DevExpress.XtraEditors.TextEdit();
            this.textEditTenTho = new DevExpress.XtraEditors.TextEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.simpleButtonOK = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonHuy = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEditDiaChi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditSDT.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditTenTho.Properties)).BeginInit();
            this.SuspendLayout();
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
            this.labelControl1.Size = new System.Drawing.Size(270, 24);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Nhập thông tin thợ";
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.textEditDiaChi);
            this.groupControl1.Controls.Add(this.textEditSDT);
            this.groupControl1.Controls.Add(this.textEditTenTho);
            this.groupControl1.Controls.Add(this.labelControl5);
            this.groupControl1.Controls.Add(this.labelControl4);
            this.groupControl1.Controls.Add(this.labelControl3);
            this.groupControl1.Location = new System.Drawing.Point(12, 42);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(270, 111);
            this.groupControl1.TabIndex = 1;
            this.groupControl1.Text = "Chi tiết";
            // 
            // textEditDiaChi
            // 
            this.textEditDiaChi.Location = new System.Drawing.Point(90, 79);
            this.textEditDiaChi.Name = "textEditDiaChi";
            this.textEditDiaChi.Properties.Mask.EditMask = "(\\p{L}|[0-9]|\\s|[,/]){1,100}";
            this.textEditDiaChi.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.textEditDiaChi.Size = new System.Drawing.Size(175, 20);
            this.textEditDiaChi.TabIndex = 8;
            // 
            // textEditSDT
            // 
            this.textEditSDT.Location = new System.Drawing.Point(90, 53);
            this.textEditSDT.Name = "textEditSDT";
            this.textEditSDT.Properties.Mask.EditMask = "\\d{1,11}";
            this.textEditSDT.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.textEditSDT.Size = new System.Drawing.Size(175, 20);
            this.textEditSDT.TabIndex = 7;
            // 
            // textEditTenTho
            // 
            this.textEditTenTho.Location = new System.Drawing.Point(90, 27);
            this.textEditTenTho.Name = "textEditTenTho";
            this.textEditTenTho.Properties.Mask.EditMask = "(\\p{L}|\\s){1,70}";
            this.textEditTenTho.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.textEditTenTho.Size = new System.Drawing.Size(175, 20);
            this.textEditTenTho.TabIndex = 6;
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(12, 82);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(32, 13);
            this.labelControl5.TabIndex = 3;
            this.labelControl5.Text = "Địa chỉ";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(12, 56);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(62, 13);
            this.labelControl4.TabIndex = 2;
            this.labelControl4.Text = "Số điện thoại";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(12, 30);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(37, 13);
            this.labelControl3.TabIndex = 1;
            this.labelControl3.Text = "Tên thợ";
            // 
            // simpleButtonOK
            // 
            this.simpleButtonOK.Image = ((System.Drawing.Image)(resources.GetObject("simpleButtonOK.Image")));
            this.simpleButtonOK.Location = new System.Drawing.Point(136, 159);
            this.simpleButtonOK.Name = "simpleButtonOK";
            this.simpleButtonOK.Size = new System.Drawing.Size(70, 27);
            this.simpleButtonOK.TabIndex = 9;
            this.simpleButtonOK.Text = "Lưu";
            this.simpleButtonOK.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // simpleButtonHuy
            // 
            this.simpleButtonHuy.Image = ((System.Drawing.Image)(resources.GetObject("simpleButtonHuy.Image")));
            this.simpleButtonHuy.Location = new System.Drawing.Point(212, 159);
            this.simpleButtonHuy.Name = "simpleButtonHuy";
            this.simpleButtonHuy.Size = new System.Drawing.Size(70, 27);
            this.simpleButtonHuy.TabIndex = 10;
            this.simpleButtonHuy.Text = "Huỷ";
            this.simpleButtonHuy.Click += new System.EventHandler(this.simpleButtonHuy_Click);
            // 
            // NhapTho
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(291, 194);
            this.Controls.Add(this.simpleButtonHuy);
            this.Controls.Add(this.simpleButtonOK);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.labelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NhapTho";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nhập thợ";
            this.SizeChanged += new System.EventHandler(this.NhapTho_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEditDiaChi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditSDT.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditTenTho.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.TextEdit textEditDiaChi;
        private DevExpress.XtraEditors.TextEdit textEditSDT;
        private DevExpress.XtraEditors.TextEdit textEditTenTho;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.SimpleButton simpleButtonOK;
        private DevExpress.XtraEditors.SimpleButton simpleButtonHuy;
    }
}