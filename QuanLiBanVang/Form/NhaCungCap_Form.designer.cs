namespace QuanLiBanVang.Form
{
    partial class NhaCungCap_Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NhaCungCap_Form));
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.richTextBoxDiaChi = new System.Windows.Forms.RichTextBox();
            this.textEditSoDienThoai = new DevExpress.XtraEditors.TextEdit();
            this.textEditMaNCC = new DevExpress.XtraEditors.TextEdit();
            this.textEditTenNhaCungCap = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControlMaNCC = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControlCaption = new DevExpress.XtraEditors.LabelControl();
            this.simpleButtonThoat = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonLuu = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEditSoDienThoai.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditMaNCC.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditTenNhaCungCap.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.richTextBoxDiaChi);
            this.groupControl1.Controls.Add(this.textEditSoDienThoai);
            this.groupControl1.Controls.Add(this.textEditMaNCC);
            this.groupControl1.Controls.Add(this.textEditTenNhaCungCap);
            this.groupControl1.Controls.Add(this.labelControl4);
            this.groupControl1.Controls.Add(this.labelControl3);
            this.groupControl1.Controls.Add(this.labelControlMaNCC);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Location = new System.Drawing.Point(12, 47);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(311, 171);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "Thông tin";
            // 
            // richTextBoxDiaChi
            // 
            this.richTextBoxDiaChi.Location = new System.Drawing.Point(88, 105);
            this.richTextBoxDiaChi.Name = "richTextBoxDiaChi";
            this.richTextBoxDiaChi.Size = new System.Drawing.Size(205, 52);
            this.richTextBoxDiaChi.TabIndex = 2;
            this.richTextBoxDiaChi.Text = "";
            // 
            // textEditSoDienThoai
            // 
            this.textEditSoDienThoai.Location = new System.Drawing.Point(86, 79);
            this.textEditSoDienThoai.Name = "textEditSoDienThoai";
            this.textEditSoDienThoai.Properties.Mask.EditMask = "[0-9]";
            this.textEditSoDienThoai.Properties.MaxLength = 11;
            this.textEditSoDienThoai.Size = new System.Drawing.Size(207, 20);
            this.textEditSoDienThoai.TabIndex = 1;
            // 
            // textEditMaNCC
            // 
            this.textEditMaNCC.Location = new System.Drawing.Point(86, 27);
            this.textEditMaNCC.Name = "textEditMaNCC";
            this.textEditMaNCC.Size = new System.Drawing.Size(120, 20);
            this.textEditMaNCC.TabIndex = 1;
            // 
            // textEditTenNhaCungCap
            // 
            this.textEditTenNhaCungCap.Location = new System.Drawing.Point(86, 53);
            this.textEditTenNhaCungCap.Name = "textEditTenNhaCungCap";
            this.textEditTenNhaCungCap.Size = new System.Drawing.Size(207, 20);
            this.textEditTenNhaCungCap.TabIndex = 1;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(11, 82);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(69, 13);
            this.labelControl4.TabIndex = 0;
            this.labelControl4.Text = "Số điện thoại :";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(11, 108);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(39, 13);
            this.labelControl3.TabIndex = 0;
            this.labelControl3.Text = "Địa chỉ :";
            // 
            // labelControlMaNCC
            // 
            this.labelControlMaNCC.Location = new System.Drawing.Point(11, 28);
            this.labelControlMaNCC.Name = "labelControlMaNCC";
            this.labelControlMaNCC.Size = new System.Drawing.Size(21, 13);
            this.labelControlMaNCC.TabIndex = 0;
            this.labelControlMaNCC.Text = "Mã :";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(11, 56);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(25, 13);
            this.labelControl2.TabIndex = 0;
            this.labelControl2.Text = "Tên :";
            // 
            // labelControlCaption
            // 
            this.labelControlCaption.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControlCaption.Appearance.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Bold);
            this.labelControlCaption.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.labelControlCaption.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.labelControlCaption.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControlCaption.Location = new System.Drawing.Point(12, 12);
            this.labelControlCaption.Name = "labelControlCaption";
            this.labelControlCaption.Size = new System.Drawing.Size(312, 29);
            this.labelControlCaption.TabIndex = 1;
            this.labelControlCaption.Text = "Thêm nhà cung cấp";
            // 
            // simpleButtonThoat
            // 
            this.simpleButtonThoat.Image = ((System.Drawing.Image)(resources.GetObject("simpleButtonThoat.Image")));
            this.simpleButtonThoat.Location = new System.Drawing.Point(236, 224);
            this.simpleButtonThoat.Name = "simpleButtonThoat";
            this.simpleButtonThoat.Size = new System.Drawing.Size(87, 27);
            this.simpleButtonThoat.TabIndex = 2;
            this.simpleButtonThoat.Text = "Thoát";
            this.simpleButtonThoat.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // simpleButtonLuu
            // 
            this.simpleButtonLuu.Image = ((System.Drawing.Image)(resources.GetObject("simpleButtonLuu.Image")));
            this.simpleButtonLuu.Location = new System.Drawing.Point(143, 224);
            this.simpleButtonLuu.Name = "simpleButtonLuu";
            this.simpleButtonLuu.Size = new System.Drawing.Size(87, 27);
            this.simpleButtonLuu.TabIndex = 3;
            this.simpleButtonLuu.Text = "Lưu";
            this.simpleButtonLuu.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // NhaCungCap_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(336, 260);
            this.Controls.Add(this.simpleButtonLuu);
            this.Controls.Add(this.simpleButtonThoat);
            this.Controls.Add(this.labelControlCaption);
            this.Controls.Add(this.groupControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.LookAndFeel.SkinName = "Office 2007 Blue";
            this.Name = "NhaCungCap_Form";
            this.Text = "Thêm nhà cung cấp";
            this.Load += new System.EventHandler(this.NhaCungCap_Load);
            this.SizeChanged += new System.EventHandler(this.NhaCungCap_Form_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEditSoDienThoai.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditMaNCC.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditTenNhaCungCap.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.LabelControl labelControlCaption;
        private DevExpress.XtraEditors.TextEdit textEditSoDienThoai;
        private DevExpress.XtraEditors.TextEdit textEditTenNhaCungCap;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.SimpleButton simpleButtonThoat;
        private DevExpress.XtraEditors.SimpleButton simpleButtonLuu;
        private System.Windows.Forms.RichTextBox richTextBoxDiaChi;
        private DevExpress.XtraEditors.TextEdit textEditMaNCC;
        private DevExpress.XtraEditors.LabelControl labelControlMaNCC;
    }
}