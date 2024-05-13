namespace QuanLiBanVang.Form
{
    partial class DanhSachPhieuNhapHang_Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DanhSachPhieuNhapHang_Form));
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.simpleButtonRefresh = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonChiTiet = new DevExpress.XtraEditors.SimpleButton();
            this.gridControlDanhSachPhieuNhap = new DevExpress.XtraGrid.GridControl();
            this.gridviewContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.chiTiếtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gridViewDanhSachPhieuNhapHang = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.simpleButtonThem = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.simpleButtonThoat = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlDanhSachPhieuNhap)).BeginInit();
            this.gridviewContextMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewDanhSachPhieuNhapHang)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl1.Controls.Add(this.simpleButtonRefresh);
            this.groupControl1.Controls.Add(this.simpleButtonChiTiet);
            this.groupControl1.Controls.Add(this.gridControlDanhSachPhieuNhap);
            this.groupControl1.Controls.Add(this.simpleButtonThem);
            this.groupControl1.Location = new System.Drawing.Point(12, 42);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(600, 346);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "Thông tin";
            // 
            // simpleButtonRefresh
            // 
            this.simpleButtonRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButtonRefresh.Image = ((System.Drawing.Image)(resources.GetObject("simpleButtonRefresh.Image")));
            this.simpleButtonRefresh.Location = new System.Drawing.Point(506, 314);
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
            this.simpleButtonChiTiet.Location = new System.Drawing.Point(506, 56);
            this.simpleButtonChiTiet.Name = "simpleButtonChiTiet";
            this.simpleButtonChiTiet.Size = new System.Drawing.Size(87, 27);
            this.simpleButtonChiTiet.TabIndex = 4;
            this.simpleButtonChiTiet.Text = "Chi tiết";
            this.simpleButtonChiTiet.Click += new System.EventHandler(this.simpleButtonChiTiet_Click);
            // 
            // gridControlDanhSachPhieuNhap
            // 
            this.gridControlDanhSachPhieuNhap.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControlDanhSachPhieuNhap.ContextMenuStrip = this.gridviewContextMenuStrip;
            this.gridControlDanhSachPhieuNhap.Location = new System.Drawing.Point(4, 22);
            this.gridControlDanhSachPhieuNhap.MainView = this.gridViewDanhSachPhieuNhapHang;
            this.gridControlDanhSachPhieuNhap.Name = "gridControlDanhSachPhieuNhap";
            this.gridControlDanhSachPhieuNhap.Size = new System.Drawing.Size(498, 319);
            this.gridControlDanhSachPhieuNhap.TabIndex = 0;
            this.gridControlDanhSachPhieuNhap.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewDanhSachPhieuNhapHang});
            // 
            // gridviewContextMenuStrip
            // 
            this.gridviewContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.chiTiếtToolStripMenuItem,
            this.refreshToolStripMenuItem});
            this.gridviewContextMenuStrip.Name = "gridviewContextMenuStrip";
            this.gridviewContextMenuStrip.Size = new System.Drawing.Size(114, 48);
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
            // gridViewDanhSachPhieuNhapHang
            // 
            this.gridViewDanhSachPhieuNhapHang.GridControl = this.gridControlDanhSachPhieuNhap;
            this.gridViewDanhSachPhieuNhapHang.Name = "gridViewDanhSachPhieuNhapHang";
            this.gridViewDanhSachPhieuNhapHang.OptionsBehavior.Editable = false;
            this.gridViewDanhSachPhieuNhapHang.OptionsBehavior.ReadOnly = true;
            this.gridViewDanhSachPhieuNhapHang.OptionsView.ShowGroupPanel = false;
            this.gridViewDanhSachPhieuNhapHang.DoubleClick += new System.EventHandler(this.gridViewDanhSachPhieuNhapHang_DoubleClick);
            // 
            // simpleButtonThem
            // 
            this.simpleButtonThem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButtonThem.Image = ((System.Drawing.Image)(resources.GetObject("simpleButtonThem.Image")));
            this.simpleButtonThem.Location = new System.Drawing.Point(506, 23);
            this.simpleButtonThem.Name = "simpleButtonThem";
            this.simpleButtonThem.Size = new System.Drawing.Size(87, 27);
            this.simpleButtonThem.TabIndex = 3;
            this.simpleButtonThem.Text = "Thêm";
            this.simpleButtonThem.Click += new System.EventHandler(this.button2_Click);
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
            this.labelControl1.Size = new System.Drawing.Size(600, 24);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "Danh sách phiếu nhập hàng";
            // 
            // simpleButtonThoat
            // 
            this.simpleButtonThoat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButtonThoat.Image = ((System.Drawing.Image)(resources.GetObject("simpleButtonThoat.Image")));
            this.simpleButtonThoat.Location = new System.Drawing.Point(525, 394);
            this.simpleButtonThoat.Name = "simpleButtonThoat";
            this.simpleButtonThoat.Size = new System.Drawing.Size(87, 27);
            this.simpleButtonThoat.TabIndex = 4;
            this.simpleButtonThoat.Text = "Thoát";
            this.simpleButtonThoat.Click += new System.EventHandler(this.button1_Click);
            // 
            // DanhSachPhieuNhapHang_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 430);
            this.Controls.Add(this.simpleButtonThoat);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.groupControl1);
            this.Name = "DanhSachPhieuNhapHang_Form";
            this.Text = "Danh sách phiếu nhập";
            this.Load += new System.EventHandler(this.DanhSachPhieuNhapHang_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlDanhSachPhieuNhap)).EndInit();
            this.gridviewContextMenuStrip.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridViewDanhSachPhieuNhapHang)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraGrid.GridControl gridControlDanhSachPhieuNhap;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewDanhSachPhieuNhapHang;
        private System.Windows.Forms.ContextMenuStrip gridviewContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem chiTiếtToolStripMenuItem;
        private DevExpress.XtraEditors.SimpleButton simpleButtonThem;
        private DevExpress.XtraEditors.SimpleButton simpleButtonThoat;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
        private DevExpress.XtraEditors.SimpleButton simpleButtonRefresh;
        private DevExpress.XtraEditors.SimpleButton simpleButtonChiTiet;
    }
}