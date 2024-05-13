namespace QuanLiBanVang.Form
{
    partial class UpdateDetaiItem
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UpdateDetaiItem));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textEditGiaBan = new DevExpress.XtraEditors.TextEdit();
            this.textEditSoLuong = new DevExpress.XtraEditors.TextEdit();
            this.comboBoxEditSP = new DevExpress.XtraEditors.ComboBoxEdit();
            this.comboBoxEditLoaiSP = new DevExpress.XtraEditors.ComboBoxEdit();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.simpleButton_Ok = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton_Huy = new DevExpress.XtraEditors.SimpleButton();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEditGiaBan.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditSoLuong.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEditSP.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEditLoaiSP.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textEditGiaBan);
            this.groupBox1.Controls.Add(this.textEditSoLuong);
            this.groupBox1.Controls.Add(this.comboBoxEditSP);
            this.groupBox1.Controls.Add(this.comboBoxEditLoaiSP);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(216, 142);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Chi tiết";
            // 
            // textEditGiaBan
            // 
            this.textEditGiaBan.Enabled = false;
            this.textEditGiaBan.Location = new System.Drawing.Point(75, 102);
            this.textEditGiaBan.Name = "textEditGiaBan";
            this.textEditGiaBan.Properties.MaxLength = 9;
            this.textEditGiaBan.Size = new System.Drawing.Size(122, 20);
            this.textEditGiaBan.TabIndex = 4;
            // 
            // textEditSoLuong
            // 
            this.textEditSoLuong.Location = new System.Drawing.Point(75, 76);
            this.textEditSoLuong.Name = "textEditSoLuong";
            this.textEditSoLuong.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.textEditSoLuong.Properties.MaxLength = 4;
            this.textEditSoLuong.Size = new System.Drawing.Size(43, 20);
            this.textEditSoLuong.TabIndex = 4;
            // 
            // comboBoxEditSP
            // 
            this.comboBoxEditSP.Location = new System.Drawing.Point(75, 50);
            this.comboBoxEditSP.Name = "comboBoxEditSP";
            this.comboBoxEditSP.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxEditSP.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.comboBoxEditSP.Size = new System.Drawing.Size(122, 20);
            this.comboBoxEditSP.TabIndex = 3;
            this.comboBoxEditSP.SelectedIndexChanged += new System.EventHandler(this.comboBoxEdit2_SelectedIndexChanged);
            // 
            // comboBoxEditLoaiSP
            // 
            this.comboBoxEditLoaiSP.Location = new System.Drawing.Point(75, 24);
            this.comboBoxEditLoaiSP.Name = "comboBoxEditLoaiSP";
            this.comboBoxEditLoaiSP.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxEditLoaiSP.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.comboBoxEditLoaiSP.Size = new System.Drawing.Size(122, 20);
            this.comboBoxEditLoaiSP.TabIndex = 3;
            this.comboBoxEditLoaiSP.SelectedIndexChanged += new System.EventHandler(this.comboBoxEditLoaiSP_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 105);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Giá bán : ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Số Lượng :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Sản Phẩm :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Loại SP :";
            // 
            // simpleButton_Ok
            // 
            this.simpleButton_Ok.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton_Ok.Image")));
            this.simpleButton_Ok.Location = new System.Drawing.Point(48, 158);
            this.simpleButton_Ok.Name = "simpleButton_Ok";
            this.simpleButton_Ok.Size = new System.Drawing.Size(87, 27);
            this.simpleButton_Ok.TabIndex = 5;
            this.simpleButton_Ok.Text = "OK";
            this.simpleButton_Ok.Click += new System.EventHandler(this.simpleButton_Ok_Click);
            // 
            // simpleButton_Huy
            // 
            this.simpleButton_Huy.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton_Huy.Image")));
            this.simpleButton_Huy.Location = new System.Drawing.Point(141, 158);
            this.simpleButton_Huy.Name = "simpleButton_Huy";
            this.simpleButton_Huy.Size = new System.Drawing.Size(87, 27);
            this.simpleButton_Huy.TabIndex = 2;
            this.simpleButton_Huy.Text = "Hủy";
            this.simpleButton_Huy.Click += new System.EventHandler(this.simpleButton_Huy_Click);
            // 
            // UpdateDetaiItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(242, 195);
            this.Controls.Add(this.simpleButton_Ok);
            this.Controls.Add(this.simpleButton_Huy);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UpdateDetaiItem";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sửa Chi Tiết";
            this.Load += new System.EventHandler(this.UpdateDetaiItem_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEditGiaBan.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditSoLuong.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEditSP.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEditLoaiSP.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private DevExpress.XtraEditors.TextEdit textEditGiaBan;
        private DevExpress.XtraEditors.TextEdit textEditSoLuong;
        private DevExpress.XtraEditors.ComboBoxEdit comboBoxEditSP;
        private DevExpress.XtraEditors.ComboBoxEdit comboBoxEditLoaiSP;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.SimpleButton simpleButton_Ok;
        private DevExpress.XtraEditors.SimpleButton simpleButton_Huy;
    }
}