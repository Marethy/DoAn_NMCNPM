namespace QuanLiBanVang.Form
{
    partial class UpdateImportDetailltem
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UpdateImportDetailltem));
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.textEditGiaMua = new DevExpress.XtraEditors.TextEdit();
            this.textEditSoLuong = new DevExpress.XtraEditors.TextEdit();
            this.comboBoxEditSP = new DevExpress.XtraEditors.ComboBoxEdit();
            this.comboBoxEditLoaiSP = new DevExpress.XtraEditors.ComboBoxEdit();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton_OK = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEditGiaMua.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditSoLuong.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEditSP.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEditLoaiSP.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.textEditGiaMua);
            this.groupControl1.Controls.Add(this.textEditSoLuong);
            this.groupControl1.Controls.Add(this.comboBoxEditSP);
            this.groupControl1.Controls.Add(this.comboBoxEditLoaiSP);
            this.groupControl1.Controls.Add(this.label4);
            this.groupControl1.Controls.Add(this.label3);
            this.groupControl1.Controls.Add(this.label2);
            this.groupControl1.Controls.Add(this.label1);
            this.groupControl1.Location = new System.Drawing.Point(12, 12);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(214, 146);
            this.groupControl1.TabIndex = 5;
            this.groupControl1.Text = "Chi tiết";
            // 
            // textEditGiaMua
            // 
            this.textEditGiaMua.Location = new System.Drawing.Point(86, 108);
            this.textEditGiaMua.Name = "textEditGiaMua";
            this.textEditGiaMua.Properties.MaxLength = 9;
            this.textEditGiaMua.Size = new System.Drawing.Size(100, 20);
            this.textEditGiaMua.TabIndex = 11;
            // 
            // textEditSoLuong
            // 
            this.textEditSoLuong.Location = new System.Drawing.Point(86, 82);
            this.textEditSoLuong.Name = "textEditSoLuong";
            this.textEditSoLuong.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.textEditSoLuong.Properties.MaxLength = 4;
            this.textEditSoLuong.Size = new System.Drawing.Size(43, 20);
            this.textEditSoLuong.TabIndex = 12;
            // 
            // comboBoxEditSP
            // 
            this.comboBoxEditSP.Location = new System.Drawing.Point(86, 56);
            this.comboBoxEditSP.Name = "comboBoxEditSP";
            this.comboBoxEditSP.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxEditSP.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.comboBoxEditSP.Size = new System.Drawing.Size(100, 20);
            this.comboBoxEditSP.TabIndex = 9;
            // 
            // comboBoxEditLoaiSP
            // 
            this.comboBoxEditLoaiSP.Location = new System.Drawing.Point(86, 30);
            this.comboBoxEditLoaiSP.Name = "comboBoxEditLoaiSP";
            this.comboBoxEditLoaiSP.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxEditLoaiSP.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.comboBoxEditLoaiSP.Size = new System.Drawing.Size(100, 20);
            this.comboBoxEditLoaiSP.TabIndex = 10;
            this.comboBoxEditLoaiSP.SelectedIndexChanged += new System.EventHandler(this.comboBoxEditLoaiSP_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 111);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Giá mua : ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Số Lượng :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Sản Phẩm :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Loại SP :";
            // 
            // simpleButton1
            // 
            this.simpleButton1.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton1.Image")));
            this.simpleButton1.Location = new System.Drawing.Point(139, 164);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(87, 27);
            this.simpleButton1.TabIndex = 6;
            this.simpleButton1.Text = "Hủy";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // simpleButton_OK
            // 
            this.simpleButton_OK.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton_OK.Image")));
            this.simpleButton_OK.Location = new System.Drawing.Point(46, 164);
            this.simpleButton_OK.Name = "simpleButton_OK";
            this.simpleButton_OK.Size = new System.Drawing.Size(87, 27);
            this.simpleButton_OK.TabIndex = 7;
            this.simpleButton_OK.Text = "OK";
            this.simpleButton_OK.Click += new System.EventHandler(this.simpleButton_OK_Click);
            // 
            // UpdateImportDetailltem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(237, 196);
            this.Controls.Add(this.simpleButton_OK);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.groupControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UpdateImportDetailltem";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cập nhật";
            this.Load += new System.EventHandler(this.UpdateImportDetailltem_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEditGiaMua.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditSoLuong.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEditSP.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEditLoaiSP.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.TextEdit textEditGiaMua;
        private DevExpress.XtraEditors.TextEdit textEditSoLuong;
        private DevExpress.XtraEditors.ComboBoxEdit comboBoxEditSP;
        private DevExpress.XtraEditors.ComboBoxEdit comboBoxEditLoaiSP;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.SimpleButton simpleButton_OK;
    }
}