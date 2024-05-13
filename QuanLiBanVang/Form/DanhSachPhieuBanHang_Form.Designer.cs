namespace QuanLiBanVang.Form
{
    partial class DanhSachPhieuBanHang_Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DanhSachPhieuBanHang_Form));
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.simpleButtonRefresh = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonChiTiet = new DevExpress.XtraEditors.SimpleButton();
            this.gridControlListReceipts = new DevExpress.XtraGrid.GridControl();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.chiTiếtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colSoPhieuBH = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMaNV = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMaKH = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNgayBan = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNgayTra = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTongTien = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCTPBHs = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKHACHHANG = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNHANVIEN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPHIEUTHUTIENNOes = new DevExpress.XtraGrid.Columns.GridColumn();
            this.simpleButtonThem = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.simpleButtonThoat = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlListReceipts)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl1.Controls.Add(this.simpleButtonRefresh);
            this.groupControl1.Controls.Add(this.simpleButtonChiTiet);
            this.groupControl1.Controls.Add(this.gridControlListReceipts);
            this.groupControl1.Controls.Add(this.simpleButtonThem);
            this.groupControl1.Location = new System.Drawing.Point(12, 42);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(640, 328);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "Danh sách";
            // 
            // simpleButtonRefresh
            // 
            this.simpleButtonRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButtonRefresh.Image = ((System.Drawing.Image)(resources.GetObject("simpleButtonRefresh.Image")));
            this.simpleButtonRefresh.Location = new System.Drawing.Point(548, 294);
            this.simpleButtonRefresh.Name = "simpleButtonRefresh";
            this.simpleButtonRefresh.Size = new System.Drawing.Size(87, 27);
            this.simpleButtonRefresh.TabIndex = 5;
            this.simpleButtonRefresh.Text = "Làm mới";
            this.simpleButtonRefresh.Click += new System.EventHandler(this.simpleButtonRefresh_Click);
            // 
            // simpleButtonChiTiet
            // 
            this.simpleButtonChiTiet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButtonChiTiet.Image = ((System.Drawing.Image)(resources.GetObject("simpleButtonChiTiet.Image")));
            this.simpleButtonChiTiet.Location = new System.Drawing.Point(548, 56);
            this.simpleButtonChiTiet.Name = "simpleButtonChiTiet";
            this.simpleButtonChiTiet.Size = new System.Drawing.Size(87, 27);
            this.simpleButtonChiTiet.TabIndex = 4;
            this.simpleButtonChiTiet.Text = "Chi tiết";
            this.simpleButtonChiTiet.Click += new System.EventHandler(this.simpleButtonChiTiet_Click);
            // 
            // gridControlListReceipts
            // 
            this.gridControlListReceipts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControlListReceipts.ContextMenuStrip = this.contextMenuStrip1;
            this.gridControlListReceipts.DataSource = this.bindingSource1;
            this.gridControlListReceipts.Location = new System.Drawing.Point(2, 20);
            this.gridControlListReceipts.MainView = this.gridView1;
            this.gridControlListReceipts.Name = "gridControlListReceipts";
            this.gridControlListReceipts.Size = new System.Drawing.Size(540, 301);
            this.gridControlListReceipts.TabIndex = 0;
            this.gridControlListReceipts.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.chiTiếtToolStripMenuItem,
            this.refreshToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(114, 48);
            // 
            // chiTiếtToolStripMenuItem
            // 
            this.chiTiếtToolStripMenuItem.Name = "chiTiếtToolStripMenuItem";
            this.chiTiếtToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.chiTiếtToolStripMenuItem.Text = "Chi tiết";
            this.chiTiếtToolStripMenuItem.Click += new System.EventHandler(this.chiTiếtToolStripMenuItem_Click);
            // 
            // refreshToolStripMenuItem
            // 
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            this.refreshToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.refreshToolStripMenuItem.Text = "Refresh";
            this.refreshToolStripMenuItem.Click += new System.EventHandler(this.refreshToolStripMenuItem_Click);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colSoPhieuBH,
            this.colMaNV,
            this.colMaKH,
            this.colNgayBan,
            this.colNgayTra,
            this.colTongTien,
            this.colCTPBHs,
            this.colKHACHHANG,
            this.colNHANVIEN,
            this.colPHIEUTHUTIENNOes});
            this.gridView1.GridControl = this.gridControlListReceipts;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsCustomization.AllowColumnMoving = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.DoubleClick += new System.EventHandler(this.gridView1_DoubleClick);
            // 
            // colSoPhieuBH
            // 
            this.colSoPhieuBH.Caption = "Số phiếu bán hàng";
            this.colSoPhieuBH.FieldName = "SoPhieuBH";
            this.colSoPhieuBH.Name = "colSoPhieuBH";
            this.colSoPhieuBH.Visible = true;
            this.colSoPhieuBH.VisibleIndex = 0;
            this.colSoPhieuBH.Width = 86;
            // 
            // colMaNV
            // 
            this.colMaNV.Caption = "Mã NV";
            this.colMaNV.FieldName = "MaNV";
            this.colMaNV.Name = "colMaNV";
            this.colMaNV.Visible = true;
            this.colMaNV.VisibleIndex = 1;
            this.colMaNV.Width = 86;
            // 
            // colMaKH
            // 
            this.colMaKH.Caption = "Mã KH";
            this.colMaKH.FieldName = "MaKH";
            this.colMaKH.Name = "colMaKH";
            this.colMaKH.Visible = true;
            this.colMaKH.VisibleIndex = 2;
            this.colMaKH.Width = 86;
            // 
            // colNgayBan
            // 
            this.colNgayBan.Caption = "Ngày bán";
            this.colNgayBan.FieldName = "NgayBan";
            this.colNgayBan.Name = "colNgayBan";
            this.colNgayBan.Visible = true;
            this.colNgayBan.VisibleIndex = 3;
            this.colNgayBan.Width = 86;
            // 
            // colNgayTra
            // 
            this.colNgayTra.Caption = "Ngày trả";
            this.colNgayTra.FieldName = "NgayTra";
            this.colNgayTra.Name = "colNgayTra";
            this.colNgayTra.Visible = true;
            this.colNgayTra.VisibleIndex = 4;
            this.colNgayTra.Width = 86;
            // 
            // colTongTien
            // 
            this.colTongTien.Caption = "Tổng tiền";
            this.colTongTien.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colTongTien.FieldName = "TongTien";
            this.colTongTien.Name = "colTongTien";
            this.colTongTien.Visible = true;
            this.colTongTien.VisibleIndex = 5;
            this.colTongTien.Width = 117;
            // 
            // colCTPBHs
            // 
            this.colCTPBHs.FieldName = "CTPBHs";
            this.colCTPBHs.Name = "colCTPBHs";
            this.colCTPBHs.Width = 78;
            // 
            // colKHACHHANG
            // 
            this.colKHACHHANG.FieldName = "KHACHHANG";
            this.colKHACHHANG.Name = "colKHACHHANG";
            this.colKHACHHANG.Width = 78;
            // 
            // colNHANVIEN
            // 
            this.colNHANVIEN.FieldName = "NHANVIEN";
            this.colNHANVIEN.Name = "colNHANVIEN";
            this.colNHANVIEN.Width = 78;
            // 
            // colPHIEUTHUTIENNOes
            // 
            this.colPHIEUTHUTIENNOes.FieldName = "PHIEUTHUTIENNOes";
            this.colPHIEUTHUTIENNOes.Name = "colPHIEUTHUTIENNOes";
            this.colPHIEUTHUTIENNOes.Width = 82;
            // 
            // simpleButtonThem
            // 
            this.simpleButtonThem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButtonThem.Image = ((System.Drawing.Image)(resources.GetObject("simpleButtonThem.Image")));
            this.simpleButtonThem.Location = new System.Drawing.Point(548, 23);
            this.simpleButtonThem.Name = "simpleButtonThem";
            this.simpleButtonThem.Size = new System.Drawing.Size(87, 27);
            this.simpleButtonThem.TabIndex = 3;
            this.simpleButtonThem.Text = "Thêm";
            this.simpleButtonThem.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Bold);
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.labelControl1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl1.Location = new System.Drawing.Point(14, 12);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(638, 24);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "Danh sách phiếu bán hàng";
            // 
            // simpleButtonThoat
            // 
            this.simpleButtonThoat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButtonThoat.Image = ((System.Drawing.Image)(resources.GetObject("simpleButtonThoat.Image")));
            this.simpleButtonThoat.Location = new System.Drawing.Point(565, 376);
            this.simpleButtonThoat.Name = "simpleButtonThoat";
            this.simpleButtonThoat.Size = new System.Drawing.Size(87, 27);
            this.simpleButtonThoat.TabIndex = 2;
            this.simpleButtonThoat.Text = "Thoát";
            this.simpleButtonThoat.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // DanhSachPhieuBanHang_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(664, 414);
            this.Controls.Add(this.simpleButtonThoat);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.groupControl1);
            this.Name = "DanhSachPhieuBanHang_Form";
            this.Text = "Danh sách phiếu bán hàng";
            this.Load += new System.EventHandler(this.DanhSachPhieuBanHang_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlListReceipts)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton simpleButtonThoat;
        private DevExpress.XtraGrid.GridControl gridControlListReceipts;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.BindingSource bindingSource1;
        private DevExpress.XtraGrid.Columns.GridColumn colSoPhieuBH;
        private DevExpress.XtraGrid.Columns.GridColumn colMaNV;
        private DevExpress.XtraGrid.Columns.GridColumn colMaKH;
        private DevExpress.XtraGrid.Columns.GridColumn colNgayBan;
        private DevExpress.XtraGrid.Columns.GridColumn colNgayTra;
        private DevExpress.XtraGrid.Columns.GridColumn colTongTien;
        private DevExpress.XtraGrid.Columns.GridColumn colCTPBHs;
        private DevExpress.XtraGrid.Columns.GridColumn colKHACHHANG;
        private DevExpress.XtraGrid.Columns.GridColumn colNHANVIEN;
        private DevExpress.XtraGrid.Columns.GridColumn colPHIEUTHUTIENNOes;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem chiTiếtToolStripMenuItem;
        private DevExpress.XtraEditors.SimpleButton simpleButtonThem;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
        private DevExpress.XtraEditors.SimpleButton simpleButtonRefresh;
        private DevExpress.XtraEditors.SimpleButton simpleButtonChiTiet;
    }
}