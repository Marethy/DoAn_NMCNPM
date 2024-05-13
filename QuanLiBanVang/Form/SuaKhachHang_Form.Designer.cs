namespace QuanLiBanVang
{
    partial class SuaKhachHang
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SuaKhachHang));
            this.simpleButtonHuy = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonOK = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.textEditDiaChi = new DevExpress.XtraEditors.TextEdit();
            this.textEditSDT = new DevExpress.XtraEditors.TextEdit();
            this.textEditTenKH = new DevExpress.XtraEditors.TextEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEditDiaChi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditSDT.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditTenKH.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // simpleButtonHuy
            // 
            this.simpleButtonHuy.Image = ((System.Drawing.Image)(resources.GetObject("simpleButtonHuy.Image")));
            this.simpleButtonHuy.Location = new System.Drawing.Point(219, 163);
            this.simpleButtonHuy.Name = "simpleButtonHuy";
            this.simpleButtonHuy.Size = new System.Drawing.Size(70, 27);
            this.simpleButtonHuy.TabIndex = 15;
            this.simpleButtonHuy.Text = "Huỷ";
            this.simpleButtonHuy.Click += new System.EventHandler(this.simpleButtonHuy_Click);
            // 
            // simpleButtonOK
            // 
            this.simpleButtonOK.Image = ((System.Drawing.Image)(resources.GetObject("simpleButtonOK.Image")));
            this.simpleButtonOK.Location = new System.Drawing.Point(133, 163);
            this.simpleButtonOK.Name = "simpleButtonOK";
            this.simpleButtonOK.Size = new System.Drawing.Size(80, 27);
            this.simpleButtonOK.TabIndex = 14;
            this.simpleButtonOK.Text = "Cập nhật";
            this.simpleButtonOK.Click += new System.EventHandler(this.simpleButtonOk_Click);
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.textEditDiaChi);
            this.groupControl1.Controls.Add(this.textEditSDT);
            this.groupControl1.Controls.Add(this.textEditTenKH);
            this.groupControl1.Controls.Add(this.labelControl5);
            this.groupControl1.Controls.Add(this.labelControl4);
            this.groupControl1.Controls.Add(this.labelControl3);
            this.groupControl1.Location = new System.Drawing.Point(10, 40);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(279, 115);
            this.groupControl1.TabIndex = 9;
            this.groupControl1.Text = "Chi tiết";
            // 
            // textEditDiaChi
            // 
            this.textEditDiaChi.Location = new System.Drawing.Point(89, 84);
            this.textEditDiaChi.Name = "textEditDiaChi";
            this.textEditDiaChi.Properties.Mask.EditMask = "(\\p{L}|[0-9]|\\s|[,/]){1,100}";
            this.textEditDiaChi.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.textEditDiaChi.Size = new System.Drawing.Size(175, 20);
            this.textEditDiaChi.TabIndex = 13;
            // 
            // textEditSDT
            // 
            this.textEditSDT.Location = new System.Drawing.Point(89, 58);
            this.textEditSDT.Name = "textEditSDT";
            this.textEditSDT.Properties.Mask.EditMask = "\\d{1,11}";
            this.textEditSDT.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.textEditSDT.Size = new System.Drawing.Size(175, 20);
            this.textEditSDT.TabIndex = 12;
            // 
            // textEditTenKH
            // 
            this.textEditTenKH.Location = new System.Drawing.Point(89, 32);
            this.textEditTenKH.Name = "textEditTenKH";
            this.textEditTenKH.Properties.Mask.EditMask = "(\\p{L}|\\s){1,70}";
            this.textEditTenKH.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.textEditTenKH.Size = new System.Drawing.Size(175, 20);
            this.textEditTenKH.TabIndex = 11;
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(17, 87);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(32, 13);
            this.labelControl5.TabIndex = 3;
            this.labelControl5.Text = "Địa chỉ";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(17, 61);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(62, 13);
            this.labelControl4.TabIndex = 2;
            this.labelControl4.Text = "Số điện thoại";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(17, 35);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(34, 13);
            this.labelControl3.TabIndex = 1;
            this.labelControl3.Text = "Tên KH";
            // 
            // labelControl1
            // 
            this.labelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Bold);
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.labelControl1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl1.Location = new System.Drawing.Point(9, 10);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(280, 24);
            this.labelControl1.TabIndex = 8;
            this.labelControl1.Text = "Sửa thông tin khách hàng";
            // 
            // SuaKhachHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(299, 200);
            this.Controls.Add(this.simpleButtonHuy);
            this.Controls.Add(this.simpleButtonOK);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.labelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SuaKhachHang";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sửa khách hàng";
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEditDiaChi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditSDT.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditTenKH.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton simpleButtonHuy;
        private DevExpress.XtraEditors.SimpleButton simpleButtonOK;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.TextEdit textEditDiaChi;
        private DevExpress.XtraEditors.TextEdit textEditSDT;
        private DevExpress.XtraEditors.TextEdit textEditTenKH;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl1;


    }
}