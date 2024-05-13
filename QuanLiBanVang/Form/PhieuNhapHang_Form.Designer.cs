namespace QuanLiBanVang.Form
{
    partial class PhieuNhapHang_Form
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PhieuNhapHang_Form));
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.dateTimePickerNgayNhap = new DevExpress.XtraEditors.DateEdit();
            this.comboBoxEditNhaCungCap = new DevExpress.XtraEditors.ComboBoxEdit();
            this.textEditNhanVien = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.gridViewContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.xóaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sửaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.simpleButtonThoat = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonSave = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.simpleButtonXoa = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonSua = new DevExpress.XtraEditors.SimpleButton();
            this.gridControlDanhSachSanPham = new DevExpress.XtraGrid.GridControl();
            this.gridViewDanhSachSanPham = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.textEditSoLuong = new DevExpress.XtraEditors.TextEdit();
            this.textEditGiaMua = new DevExpress.XtraEditors.TextEdit();
            this.textEditTongTien = new DevExpress.XtraEditors.TextEdit();
            this.comboBoxEditSP = new DevExpress.XtraEditors.ComboBoxEdit();
            this.comboBoxEditLoaiSp = new DevExpress.XtraEditors.ComboBoxEdit();
            this.simpleButtonThem = new DevExpress.XtraEditors.SimpleButton();
            this.label4 = new System.Windows.Forms.Label();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateTimePickerNgayNhap.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateTimePickerNgayNhap.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEditNhaCungCap.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditNhanVien.Properties)).BeginInit();
            this.gridViewContextMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlDanhSachSanPham)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewDanhSachSanPham)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditSoLuong.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditGiaMua.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditTongTien.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEditSP.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEditLoaiSp.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl1.Controls.Add(this.dateTimePickerNgayNhap);
            this.groupControl1.Controls.Add(this.comboBoxEditNhaCungCap);
            this.groupControl1.Controls.Add(this.textEditNhanVien);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.labelControl4);
            this.groupControl1.Controls.Add(this.labelControl3);
            this.groupControl1.Location = new System.Drawing.Point(12, 42);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(910, 110);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "Thông tin ";
            // 
            // dateTimePickerNgayNhap
            // 
            this.dateTimePickerNgayNhap.EditValue = null;
            this.dateTimePickerNgayNhap.Location = new System.Drawing.Point(114, 53);
            this.dateTimePickerNgayNhap.Name = "dateTimePickerNgayNhap";
            this.dateTimePickerNgayNhap.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateTimePickerNgayNhap.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateTimePickerNgayNhap.Properties.ReadOnly = true;
            this.dateTimePickerNgayNhap.Size = new System.Drawing.Size(168, 20);
            this.dateTimePickerNgayNhap.TabIndex = 7;
            this.dateTimePickerNgayNhap.EditValueChanged += new System.EventHandler(this.dateTimePicker1_EditValueChanged);
            // 
            // comboBoxEditNhaCungCap
            // 
            this.comboBoxEditNhaCungCap.Location = new System.Drawing.Point(114, 79);
            this.comboBoxEditNhaCungCap.Name = "comboBoxEditNhaCungCap";
            this.comboBoxEditNhaCungCap.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxEditNhaCungCap.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.comboBoxEditNhaCungCap.Size = new System.Drawing.Size(242, 20);
            this.comboBoxEditNhaCungCap.TabIndex = 4;
            // 
            // textEditNhanVien
            // 
            this.textEditNhanVien.Location = new System.Drawing.Point(114, 28);
            this.textEditNhanVien.Name = "textEditNhanVien";
            this.textEditNhanVien.Properties.ReadOnly = true;
            this.textEditNhanVien.Size = new System.Drawing.Size(168, 20);
            this.textEditNhanVien.TabIndex = 3;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(13, 56);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(59, 13);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "Ngày nhập :";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(13, 82);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(72, 13);
            this.labelControl4.TabIndex = 1;
            this.labelControl4.Text = "Nhà cung cấp :";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(13, 28);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(55, 13);
            this.labelControl3.TabIndex = 1;
            this.labelControl3.Text = "Nhân viên :";
            // 
            // gridViewContextMenuStrip
            // 
            this.gridViewContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.xóaToolStripMenuItem,
            this.sửaToolStripMenuItem});
            this.gridViewContextMenuStrip.Name = "gridViewContextMenuStrip";
            this.gridViewContextMenuStrip.Size = new System.Drawing.Size(95, 48);
            // 
            // xóaToolStripMenuItem
            // 
            this.xóaToolStripMenuItem.Name = "xóaToolStripMenuItem";
            this.xóaToolStripMenuItem.Size = new System.Drawing.Size(94, 22);
            this.xóaToolStripMenuItem.Text = "Xóa";
            this.xóaToolStripMenuItem.Click += new System.EventHandler(this.xóaToolStripMenuItem_Click);
            // 
            // sửaToolStripMenuItem
            // 
            this.sửaToolStripMenuItem.Name = "sửaToolStripMenuItem";
            this.sửaToolStripMenuItem.Size = new System.Drawing.Size(94, 22);
            this.sửaToolStripMenuItem.Text = "Sửa";
            this.sửaToolStripMenuItem.Click += new System.EventHandler(this.sửaToolStripMenuItem_Click);
            // 
            // simpleButtonThoat
            // 
            this.simpleButtonThoat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButtonThoat.Image = ((System.Drawing.Image)(resources.GetObject("simpleButtonThoat.Image")));
            this.simpleButtonThoat.Location = new System.Drawing.Point(835, 639);
            this.simpleButtonThoat.Name = "simpleButtonThoat";
            this.simpleButtonThoat.Size = new System.Drawing.Size(87, 27);
            this.simpleButtonThoat.TabIndex = 1;
            this.simpleButtonThoat.Text = "Thoát";
            this.simpleButtonThoat.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // simpleButtonSave
            // 
            this.simpleButtonSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButtonSave.Image = ((System.Drawing.Image)(resources.GetObject("simpleButtonSave.Image")));
            this.simpleButtonSave.Location = new System.Drawing.Point(742, 639);
            this.simpleButtonSave.Name = "simpleButtonSave";
            this.simpleButtonSave.Size = new System.Drawing.Size(87, 27);
            this.simpleButtonSave.TabIndex = 1;
            this.simpleButtonSave.Text = "Lưu";
            this.simpleButtonSave.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // labelControl5
            // 
            this.labelControl5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Bold);
            this.labelControl5.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.labelControl5.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.labelControl5.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl5.Location = new System.Drawing.Point(12, 12);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(910, 24);
            this.labelControl5.TabIndex = 2;
            this.labelControl5.Text = "Phiếu Nhập Hàng";
            // 
            // groupControl2
            // 
            this.groupControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl2.Controls.Add(this.simpleButtonXoa);
            this.groupControl2.Controls.Add(this.simpleButtonSua);
            this.groupControl2.Controls.Add(this.gridControlDanhSachSanPham);
            this.groupControl2.Controls.Add(this.textEditSoLuong);
            this.groupControl2.Controls.Add(this.textEditGiaMua);
            this.groupControl2.Controls.Add(this.textEditTongTien);
            this.groupControl2.Controls.Add(this.comboBoxEditSP);
            this.groupControl2.Controls.Add(this.comboBoxEditLoaiSp);
            this.groupControl2.Controls.Add(this.simpleButtonThem);
            this.groupControl2.Controls.Add(this.label4);
            this.groupControl2.Controls.Add(this.labelControl6);
            this.groupControl2.Controls.Add(this.label3);
            this.groupControl2.Controls.Add(this.label2);
            this.groupControl2.Controls.Add(this.label1);
            this.groupControl2.Location = new System.Drawing.Point(12, 158);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(910, 475);
            this.groupControl2.TabIndex = 3;
            this.groupControl2.Text = "Chi tiết";
            // 
            // simpleButtonXoa
            // 
            this.simpleButtonXoa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButtonXoa.Image = ((System.Drawing.Image)(resources.GetObject("simpleButtonXoa.Image")));
            this.simpleButtonXoa.Location = new System.Drawing.Point(781, 97);
            this.simpleButtonXoa.Name = "simpleButtonXoa";
            this.simpleButtonXoa.Size = new System.Drawing.Size(87, 27);
            this.simpleButtonXoa.TabIndex = 8;
            this.simpleButtonXoa.Text = "Xóa";
            this.simpleButtonXoa.Click += new System.EventHandler(this.simpleButtonXoa_Click);
            // 
            // simpleButtonSua
            // 
            this.simpleButtonSua.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButtonSua.Image = ((System.Drawing.Image)(resources.GetObject("simpleButtonSua.Image")));
            this.simpleButtonSua.Location = new System.Drawing.Point(781, 64);
            this.simpleButtonSua.Name = "simpleButtonSua";
            this.simpleButtonSua.Size = new System.Drawing.Size(87, 27);
            this.simpleButtonSua.TabIndex = 7;
            this.simpleButtonSua.Text = "Sửa";
            this.simpleButtonSua.Click += new System.EventHandler(this.simpleButtonSua_Click);
            // 
            // gridControlDanhSachSanPham
            // 
            this.gridControlDanhSachSanPham.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControlDanhSachSanPham.ContextMenuStrip = this.gridViewContextMenuStrip;
            this.gridControlDanhSachSanPham.Location = new System.Drawing.Point(0, 64);
            this.gridControlDanhSachSanPham.MainView = this.gridViewDanhSachSanPham;
            this.gridControlDanhSachSanPham.Name = "gridControlDanhSachSanPham";
            this.gridControlDanhSachSanPham.Size = new System.Drawing.Size(775, 376);
            this.gridControlDanhSachSanPham.TabIndex = 6;
            this.gridControlDanhSachSanPham.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewDanhSachSanPham});
            // 
            // gridViewDanhSachSanPham
            // 
            this.gridViewDanhSachSanPham.GridControl = this.gridControlDanhSachSanPham;
            this.gridViewDanhSachSanPham.Name = "gridViewDanhSachSanPham";
            this.gridViewDanhSachSanPham.OptionsBehavior.Editable = false;
            this.gridViewDanhSachSanPham.OptionsBehavior.ReadOnly = true;
            this.gridViewDanhSachSanPham.OptionsView.ShowGroupPanel = false;
            // 
            // textEditSoLuong
            // 
            this.textEditSoLuong.Location = new System.Drawing.Point(708, 32);
            this.textEditSoLuong.Name = "textEditSoLuong";
            this.textEditSoLuong.Properties.Mask.EditMask = "[0-9]{1,3}";
            this.textEditSoLuong.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.textEditSoLuong.Size = new System.Drawing.Size(63, 20);
            this.textEditSoLuong.TabIndex = 5;
            // 
            // textEditGiaMua
            // 
            this.textEditGiaMua.Location = new System.Drawing.Point(481, 32);
            this.textEditGiaMua.Name = "textEditGiaMua";
            this.textEditGiaMua.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.textEditGiaMua.Properties.MaxLength = 9;
            this.textEditGiaMua.Size = new System.Drawing.Size(153, 20);
            this.textEditGiaMua.TabIndex = 4;
            // 
            // textEditTongTien
            // 
            this.textEditTongTien.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.textEditTongTien.Location = new System.Drawing.Point(735, 446);
            this.textEditTongTien.Name = "textEditTongTien";
            this.textEditTongTien.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.textEditTongTien.Properties.Appearance.Options.UseFont = true;
            this.textEditTongTien.Properties.ReadOnly = true;
            this.textEditTongTien.Size = new System.Drawing.Size(161, 20);
            this.textEditTongTien.TabIndex = 3;
            // 
            // comboBoxEditSP
            // 
            this.comboBoxEditSP.Location = new System.Drawing.Point(275, 32);
            this.comboBoxEditSP.Name = "comboBoxEditSP";
            this.comboBoxEditSP.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxEditSP.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.comboBoxEditSP.Size = new System.Drawing.Size(136, 20);
            this.comboBoxEditSP.TabIndex = 3;
            // 
            // comboBoxEditLoaiSp
            // 
            this.comboBoxEditLoaiSp.Location = new System.Drawing.Point(96, 32);
            this.comboBoxEditLoaiSp.Name = "comboBoxEditLoaiSp";
            this.comboBoxEditLoaiSp.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxEditLoaiSp.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.comboBoxEditLoaiSp.Size = new System.Drawing.Size(100, 20);
            this.comboBoxEditLoaiSp.TabIndex = 3;
            this.comboBoxEditLoaiSp.SelectedIndexChanged += new System.EventHandler(this.comboBoxEditLoaiSp_SelectedIndexChanged);
            // 
            // simpleButtonThem
            // 
            this.simpleButtonThem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButtonThem.Image = ((System.Drawing.Image)(resources.GetObject("simpleButtonThem.Image")));
            this.simpleButtonThem.Location = new System.Drawing.Point(781, 29);
            this.simpleButtonThem.Name = "simpleButtonThem";
            this.simpleButtonThem.Size = new System.Drawing.Size(87, 27);
            this.simpleButtonThem.TabIndex = 1;
            this.simpleButtonThem.Text = "Thêm";
            this.simpleButtonThem.Click += new System.EventHandler(this.simpleButton3_Click_1);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(643, 36);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Số lượng :";
            // 
            // labelControl6
            // 
            this.labelControl6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl6.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl6.Location = new System.Drawing.Point(670, 449);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(59, 13);
            this.labelControl6.TabIndex = 1;
            this.labelControl6.Text = "Tổng tiền :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(420, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Giá mua :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(205, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Sản phẩm :";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Loại sản phẩm :";
            // 
            // PhieuNhapHang_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(934, 678);
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.simpleButtonSave);
            this.Controls.Add(this.simpleButtonThoat);
            this.Controls.Add(this.groupControl1);
            this.Name = "PhieuNhapHang_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nhập hàng";
            this.Load += new System.EventHandler(this.PhieuNhapHang_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateTimePickerNgayNhap.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateTimePickerNgayNhap.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEditNhaCungCap.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditNhanVien.Properties)).EndInit();
            this.gridViewContextMenuStrip.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.groupControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlDanhSachSanPham)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewDanhSachSanPham)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditSoLuong.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditGiaMua.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditTongTien.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEditSP.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEditLoaiSp.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.SimpleButton simpleButtonThoat;
        private DevExpress.XtraEditors.SimpleButton simpleButtonSave;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.ComboBoxEdit comboBoxEditNhaCungCap;
        private DevExpress.XtraEditors.TextEdit textEditNhanVien;
        private System.Windows.Forms.ContextMenuStrip gridViewContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem xóaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sửaToolStripMenuItem;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.TextEdit textEditSoLuong;
        private DevExpress.XtraEditors.TextEdit textEditGiaMua;
        private DevExpress.XtraEditors.TextEdit textEditTongTien;
        private DevExpress.XtraEditors.ComboBoxEdit comboBoxEditSP;
        private DevExpress.XtraEditors.ComboBoxEdit comboBoxEditLoaiSp;
        private DevExpress.XtraEditors.SimpleButton simpleButtonThem;
        private System.Windows.Forms.Label label4;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraGrid.GridControl gridControlDanhSachSanPham;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewDanhSachSanPham;
        private DevExpress.XtraEditors.DateEdit dateTimePickerNgayNhap;
        private DevExpress.XtraEditors.SimpleButton simpleButtonSua;
        private DevExpress.XtraEditors.SimpleButton simpleButtonXoa;
    }
}