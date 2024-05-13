namespace QuanLiBanVang.Form
{
    partial class DanhSachNhaCungCap_Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DanhSachNhaCungCap_Form));
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.simpleButtonXoa = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonSua = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonRefresh = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonChiTiet = new DevExpress.XtraEditors.SimpleButton();
            this.gridControlDanhSachNhaCungCap = new DevExpress.XtraGrid.GridControl();
            this.contextMenuStripNhaCungCap = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.chiTiếtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xóaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sửaToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.gridViewDanhSachNhaCungCap = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.simpleButtonThem = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonThoat = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlDanhSachNhaCungCap)).BeginInit();
            this.contextMenuStripNhaCungCap.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewDanhSachNhaCungCap)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl1.Controls.Add(this.simpleButtonXoa);
            this.groupControl1.Controls.Add(this.simpleButtonSua);
            this.groupControl1.Controls.Add(this.simpleButtonRefresh);
            this.groupControl1.Controls.Add(this.simpleButtonChiTiet);
            this.groupControl1.Controls.Add(this.gridControlDanhSachNhaCungCap);
            this.groupControl1.Controls.Add(this.simpleButtonThem);
            this.groupControl1.Location = new System.Drawing.Point(12, 41);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(599, 328);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "Thông tin";
            // 
            // simpleButtonXoa
            // 
            this.simpleButtonXoa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButtonXoa.Image = ((System.Drawing.Image)(resources.GetObject("simpleButtonXoa.Image")));
            this.simpleButtonXoa.Location = new System.Drawing.Point(507, 122);
            this.simpleButtonXoa.Name = "simpleButtonXoa";
            this.simpleButtonXoa.Size = new System.Drawing.Size(87, 27);
            this.simpleButtonXoa.TabIndex = 9;
            this.simpleButtonXoa.Text = "Xóa";
            this.simpleButtonXoa.Click += new System.EventHandler(this.simpleButtonXoa_Click);
            // 
            // simpleButtonSua
            // 
            this.simpleButtonSua.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButtonSua.Image = ((System.Drawing.Image)(resources.GetObject("simpleButtonSua.Image")));
            this.simpleButtonSua.Location = new System.Drawing.Point(507, 89);
            this.simpleButtonSua.Name = "simpleButtonSua";
            this.simpleButtonSua.Size = new System.Drawing.Size(87, 27);
            this.simpleButtonSua.TabIndex = 8;
            this.simpleButtonSua.Text = "Sửa";
            this.simpleButtonSua.Click += new System.EventHandler(this.simpleButtonSua_Click);
            // 
            // simpleButtonRefresh
            // 
            this.simpleButtonRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButtonRefresh.Image = ((System.Drawing.Image)(resources.GetObject("simpleButtonRefresh.Image")));
            this.simpleButtonRefresh.Location = new System.Drawing.Point(507, 296);
            this.simpleButtonRefresh.Name = "simpleButtonRefresh";
            this.simpleButtonRefresh.Size = new System.Drawing.Size(87, 27);
            this.simpleButtonRefresh.TabIndex = 7;
            this.simpleButtonRefresh.Text = "Làm mới";
            this.simpleButtonRefresh.Click += new System.EventHandler(this.simpleButtonRefresh_Click);
            // 
            // simpleButtonChiTiet
            // 
            this.simpleButtonChiTiet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButtonChiTiet.Image = ((System.Drawing.Image)(resources.GetObject("simpleButtonChiTiet.Image")));
            this.simpleButtonChiTiet.Location = new System.Drawing.Point(507, 56);
            this.simpleButtonChiTiet.Name = "simpleButtonChiTiet";
            this.simpleButtonChiTiet.Size = new System.Drawing.Size(87, 27);
            this.simpleButtonChiTiet.TabIndex = 6;
            this.simpleButtonChiTiet.Text = "Chi tiết";
            this.simpleButtonChiTiet.Click += new System.EventHandler(this.simpleButtonChiTiet_Click);
            // 
            // gridControlDanhSachNhaCungCap
            // 
            this.gridControlDanhSachNhaCungCap.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControlDanhSachNhaCungCap.ContextMenuStrip = this.contextMenuStripNhaCungCap;
            this.gridControlDanhSachNhaCungCap.Location = new System.Drawing.Point(4, 22);
            this.gridControlDanhSachNhaCungCap.MainView = this.gridViewDanhSachNhaCungCap;
            this.gridControlDanhSachNhaCungCap.Name = "gridControlDanhSachNhaCungCap";
            this.gridControlDanhSachNhaCungCap.Size = new System.Drawing.Size(492, 303);
            this.gridControlDanhSachNhaCungCap.TabIndex = 0;
            this.gridControlDanhSachNhaCungCap.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewDanhSachNhaCungCap});
            // 
            // contextMenuStripNhaCungCap
            // 
            this.contextMenuStripNhaCungCap.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.chiTiếtToolStripMenuItem,
            this.xóaToolStripMenuItem,
            this.refreshToolStripMenuItem,
            this.sửaToolStripMenuItem1});
            this.contextMenuStripNhaCungCap.Name = "contextMenuStrip1";
            this.contextMenuStripNhaCungCap.Size = new System.Drawing.Size(114, 92);
            // 
            // chiTiếtToolStripMenuItem
            // 
            this.chiTiếtToolStripMenuItem.Name = "chiTiếtToolStripMenuItem";
            this.chiTiếtToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.chiTiếtToolStripMenuItem.Text = "Chi tiết";
            this.chiTiếtToolStripMenuItem.Click += new System.EventHandler(this.chiTiếtToolStripMenuItem_Click);
            // 
            // xóaToolStripMenuItem
            // 
            this.xóaToolStripMenuItem.Name = "xóaToolStripMenuItem";
            this.xóaToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.xóaToolStripMenuItem.Text = "Xóa";
            this.xóaToolStripMenuItem.Click += new System.EventHandler(this.xóaToolStripMenuItem_Click);
            // 
            // refreshToolStripMenuItem
            // 
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            this.refreshToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.refreshToolStripMenuItem.Text = "Refresh";
            this.refreshToolStripMenuItem.Click += new System.EventHandler(this.refreshToolStripMenuItem_Click);
            // 
            // sửaToolStripMenuItem1
            // 
            this.sửaToolStripMenuItem1.Name = "sửaToolStripMenuItem1";
            this.sửaToolStripMenuItem1.Size = new System.Drawing.Size(113, 22);
            this.sửaToolStripMenuItem1.Text = "Sửa";
            this.sửaToolStripMenuItem1.Click += new System.EventHandler(this.sửaToolStripMenuItem1_Click);
            // 
            // gridViewDanhSachNhaCungCap
            // 
            this.gridViewDanhSachNhaCungCap.GridControl = this.gridControlDanhSachNhaCungCap;
            this.gridViewDanhSachNhaCungCap.Name = "gridViewDanhSachNhaCungCap";
            this.gridViewDanhSachNhaCungCap.OptionsBehavior.Editable = false;
            this.gridViewDanhSachNhaCungCap.OptionsView.ShowGroupPanel = false;
            // 
            // simpleButtonThem
            // 
            this.simpleButtonThem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButtonThem.Image = ((System.Drawing.Image)(resources.GetObject("simpleButtonThem.Image")));
            this.simpleButtonThem.Location = new System.Drawing.Point(507, 23);
            this.simpleButtonThem.Name = "simpleButtonThem";
            this.simpleButtonThem.Size = new System.Drawing.Size(87, 27);
            this.simpleButtonThem.TabIndex = 5;
            this.simpleButtonThem.Text = "Thêm";
            this.simpleButtonThem.Click += new System.EventHandler(this.simpleButtonThem_Click);
            // 
            // simpleButtonThoat
            // 
            this.simpleButtonThoat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButtonThoat.Image = ((System.Drawing.Image)(resources.GetObject("simpleButtonThoat.Image")));
            this.simpleButtonThoat.Location = new System.Drawing.Point(524, 375);
            this.simpleButtonThoat.Name = "simpleButtonThoat";
            this.simpleButtonThoat.Size = new System.Drawing.Size(87, 27);
            this.simpleButtonThoat.TabIndex = 4;
            this.simpleButtonThoat.Text = "Thoát";
            this.simpleButtonThoat.Click += new System.EventHandler(this.simpleButtonThoat_Click);
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
            this.labelControl1.Size = new System.Drawing.Size(599, 24);
            this.labelControl1.TabIndex = 6;
            this.labelControl1.Text = "Danh sách nhà cung cấp";
            // 
            // DanhSachNhaCungCap_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(623, 410);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.simpleButtonThoat);
            this.Controls.Add(this.groupControl1);
            this.Name = "DanhSachNhaCungCap_Form";
            this.Text = "Danh sách nhà cung cấp";
            this.Load += new System.EventHandler(this.DanhSachNhaCungCap_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlDanhSachNhaCungCap)).EndInit();
            this.contextMenuStripNhaCungCap.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridViewDanhSachNhaCungCap)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraGrid.GridControl gridControlDanhSachNhaCungCap;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewDanhSachNhaCungCap;
        private DevExpress.XtraEditors.SimpleButton simpleButtonThoat;
        private DevExpress.XtraEditors.SimpleButton simpleButtonThem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripNhaCungCap;
        private System.Windows.Forms.ToolStripMenuItem chiTiếtToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem xóaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private System.Windows.Forms.ToolStripMenuItem sửaToolStripMenuItem1;
        private DevExpress.XtraEditors.SimpleButton simpleButtonChiTiet;
        private DevExpress.XtraEditors.SimpleButton simpleButtonRefresh;
        private DevExpress.XtraEditors.SimpleButton simpleButtonSua;
        private DevExpress.XtraEditors.SimpleButton simpleButtonXoa;
    }
}