namespace QuanLiBanVang.Report
{
    partial class SuaPhieuMua_Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SuaPhieuMua_Form));
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.dgvBuy = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.dgvBuyList = new DevExpress.XtraGrid.GridControl();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl11 = new DevExpress.XtraEditors.LabelControl();
            this.lbTotal = new DevExpress.XtraEditors.LabelControl();
            this.labelControl10 = new DevExpress.XtraEditors.LabelControl();
            this.txtWeight = new DevExpress.XtraEditors.TextEdit();
            this.groupControlDetail = new DevExpress.XtraEditors.GroupControl();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.txtPrice = new DevExpress.XtraEditors.TextEdit();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.cboProductType = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cboProduct = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.txtQuantity = new DevExpress.XtraEditors.TextEdit();
            this.btnAdd = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.groupControlGeneralInfo = new DevExpress.XtraEditors.GroupControl();
            this.lblPhoneNumber = new DevExpress.XtraEditors.LabelControl();
            this.lblPhone = new DevExpress.XtraEditors.LabelControl();
            this.cboClientName = new DevExpress.XtraEditors.ComboBoxEdit();
            this.rdoClientType = new DevExpress.XtraEditors.RadioGroup();
            this.dtpkCreateDate = new DevExpress.XtraEditors.DateEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBuy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBuyList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtWeight.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlDetail)).BeginInit();
            this.groupControlDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrice.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboProductType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboProduct.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtQuantity.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlGeneralInfo)).BeginInit();
            this.groupControlGeneralInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboClientName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdoClientType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpkCreateDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpkCreateDate.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Appearance.Options.UseFont = true;
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.Location = new System.Drawing.Point(681, 490);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(87, 27);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "Hủy";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // dgvBuy
            // 
            this.dgvBuy.GridControl = this.dgvBuyList;
            this.dgvBuy.Name = "dgvBuy";
            this.dgvBuy.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.dgvBuy.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.dgvBuy.OptionsBehavior.Editable = false;
            this.dgvBuy.OptionsCustomization.AllowColumnMoving = false;
            this.dgvBuy.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.dgvBuy.OptionsSelection.MultiSelect = true;
            this.dgvBuy.OptionsView.ShowGroupPanel = false;
            this.dgvBuy.CustomUnboundColumnData += new DevExpress.XtraGrid.Views.Base.CustomColumnDataEventHandler(this.dgvBuy_CustomUnboundColumnData);
            // 
            // dgvBuyList
            // 
            this.dgvBuyList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvBuyList.Location = new System.Drawing.Point(5, 86);
            this.dgvBuyList.MainView = this.dgvBuy;
            this.dgvBuyList.Name = "dgvBuyList";
            this.dgvBuyList.Size = new System.Drawing.Size(747, 205);
            this.dgvBuyList.TabIndex = 0;
            this.dgvBuyList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.dgvBuy});
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Appearance.Options.UseFont = true;
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.Location = new System.Drawing.Point(588, 490);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(87, 27);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "Lưu";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // labelControl11
            // 
            this.labelControl11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl11.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl11.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.labelControl11.Location = new System.Drawing.Point(725, 300);
            this.labelControl11.Name = "labelControl11";
            this.labelControl11.Size = new System.Drawing.Size(27, 16);
            this.labelControl11.TabIndex = 16;
            this.labelControl11.Text = "VNĐ";
            // 
            // lbTotal
            // 
            this.lbTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lbTotal.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTotal.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.lbTotal.Location = new System.Drawing.Point(619, 300);
            this.lbTotal.Name = "lbTotal";
            this.lbTotal.Size = new System.Drawing.Size(8, 16);
            this.lbTotal.TabIndex = 15;
            this.lbTotal.Text = "0";
            // 
            // labelControl10
            // 
            this.labelControl10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl10.Location = new System.Drawing.Point(550, 300);
            this.labelControl10.Name = "labelControl10";
            this.labelControl10.Size = new System.Drawing.Size(50, 13);
            this.labelControl10.TabIndex = 14;
            this.labelControl10.Text = "Tổng cộng";
            // 
            // txtWeight
            // 
            this.txtWeight.Location = new System.Drawing.Point(482, 31);
            this.txtWeight.Name = "txtWeight";
            this.txtWeight.Properties.Mask.EditMask = "\\d+(\\R.\\d{0,2})?";
            this.txtWeight.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.txtWeight.Size = new System.Drawing.Size(100, 20);
            this.txtWeight.TabIndex = 8;
            // 
            // groupControlDetail
            // 
            this.groupControlDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControlDetail.Controls.Add(this.labelControl11);
            this.groupControlDetail.Controls.Add(this.lbTotal);
            this.groupControlDetail.Controls.Add(this.labelControl10);
            this.groupControlDetail.Controls.Add(this.txtWeight);
            this.groupControlDetail.Controls.Add(this.labelControl9);
            this.groupControlDetail.Controls.Add(this.txtPrice);
            this.groupControlDetail.Controls.Add(this.labelControl8);
            this.groupControlDetail.Controls.Add(this.cboProductType);
            this.groupControlDetail.Controls.Add(this.cboProduct);
            this.groupControlDetail.Controls.Add(this.labelControl6);
            this.groupControlDetail.Controls.Add(this.txtQuantity);
            this.groupControlDetail.Controls.Add(this.btnAdd);
            this.groupControlDetail.Controls.Add(this.labelControl7);
            this.groupControlDetail.Controls.Add(this.labelControl5);
            this.groupControlDetail.Controls.Add(this.dgvBuyList);
            this.groupControlDetail.Location = new System.Drawing.Point(11, 164);
            this.groupControlDetail.Name = "groupControlDetail";
            this.groupControlDetail.Size = new System.Drawing.Size(757, 320);
            this.groupControlDetail.TabIndex = 7;
            this.groupControlDetail.Text = "Chi tiết phiếu mua";
            // 
            // labelControl9
            // 
            this.labelControl9.Location = new System.Drawing.Point(413, 34);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(58, 13);
            this.labelControl9.TabIndex = 12;
            this.labelControl9.Text = "Trọng lượng";
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(292, 57);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Properties.Mask.EditMask = "[0-9]{1,8}";
            this.txtPrice.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.txtPrice.Size = new System.Drawing.Size(108, 20);
            this.txtPrice.TabIndex = 7;
            // 
            // labelControl8
            // 
            this.labelControl8.Location = new System.Drawing.Point(243, 60);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(38, 13);
            this.labelControl8.TabIndex = 10;
            this.labelControl8.Text = "Giá mua";
            // 
            // cboProductType
            // 
            this.cboProductType.Location = new System.Drawing.Point(98, 31);
            this.cboProductType.Name = "cboProductType";
            this.cboProductType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboProductType.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cboProductType.Size = new System.Drawing.Size(116, 20);
            this.cboProductType.TabIndex = 5;
            this.cboProductType.SelectedIndexChanged += new System.EventHandler(this.cboProductType_SelectedIndexChanged);
            // 
            // cboProduct
            // 
            this.cboProduct.Location = new System.Drawing.Point(98, 57);
            this.cboProduct.Name = "cboProduct";
            this.cboProduct.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboProduct.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cboProduct.Size = new System.Drawing.Size(116, 20);
            this.cboProduct.TabIndex = 4;
            this.cboProduct.SelectedIndexChanged += new System.EventHandler(this.cboProduct_SelectedIndexChanged);
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(16, 34);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(68, 13);
            this.labelControl6.TabIndex = 2;
            this.labelControl6.Text = "Loại sản phẩm";
            // 
            // txtQuantity
            // 
            this.txtQuantity.Location = new System.Drawing.Point(292, 31);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Properties.Mask.EditMask = "[0-9]{1,2}";
            this.txtQuantity.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.txtQuantity.Size = new System.Drawing.Size(108, 20);
            this.txtQuantity.TabIndex = 6;
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Appearance.Options.UseFont = true;
            this.btnAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.Image")));
            this.btnAdd.Location = new System.Drawing.Point(665, 27);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(87, 27);
            this.btnAdd.TabIndex = 9;
            this.btnAdd.Text = "Thêm";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(243, 34);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(42, 13);
            this.labelControl7.TabIndex = 3;
            this.labelControl7.Text = "Số lượng";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(16, 60);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(67, 13);
            this.labelControl5.TabIndex = 1;
            this.labelControl5.Text = "Tên sản phẩm";
            // 
            // groupControlGeneralInfo
            // 
            this.groupControlGeneralInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControlGeneralInfo.Controls.Add(this.lblPhoneNumber);
            this.groupControlGeneralInfo.Controls.Add(this.lblPhone);
            this.groupControlGeneralInfo.Controls.Add(this.cboClientName);
            this.groupControlGeneralInfo.Controls.Add(this.rdoClientType);
            this.groupControlGeneralInfo.Controls.Add(this.dtpkCreateDate);
            this.groupControlGeneralInfo.Controls.Add(this.labelControl4);
            this.groupControlGeneralInfo.Controls.Add(this.labelControl3);
            this.groupControlGeneralInfo.Controls.Add(this.labelControl2);
            this.groupControlGeneralInfo.Location = new System.Drawing.Point(11, 42);
            this.groupControlGeneralInfo.Name = "groupControlGeneralInfo";
            this.groupControlGeneralInfo.Size = new System.Drawing.Size(757, 178);
            this.groupControlGeneralInfo.TabIndex = 6;
            this.groupControlGeneralInfo.Text = "Thông tin chung";
            // 
            // lblPhoneNumber
            // 
            this.lblPhoneNumber.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPhoneNumber.Location = new System.Drawing.Point(403, 88);
            this.lblPhoneNumber.Name = "lblPhoneNumber";
            this.lblPhoneNumber.Size = new System.Drawing.Size(49, 13);
            this.lblPhoneNumber.TabIndex = 5;
            this.lblPhoneNumber.Text = "0123456";
            // 
            // lblPhone
            // 
            this.lblPhone.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPhone.Location = new System.Drawing.Point(302, 88);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(76, 13);
            this.lblPhone.TabIndex = 4;
            this.lblPhone.Text = "Số điện thoại:";
            // 
            // cboClientName
            // 
            this.cboClientName.Location = new System.Drawing.Point(117, 85);
            this.cboClientName.Name = "cboClientName";
            this.cboClientName.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboClientName.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cboClientName.Size = new System.Drawing.Size(157, 20);
            this.cboClientName.TabIndex = 3;
            // 
            // rdoClientType
            // 
            this.rdoClientType.EditValue = true;
            this.rdoClientType.Location = new System.Drawing.Point(117, 56);
            this.rdoClientType.Name = "rdoClientType";
            this.rdoClientType.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(true, "Vãng lai"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(false, "Thân thiết")});
            this.rdoClientType.Size = new System.Drawing.Size(198, 23);
            this.rdoClientType.TabIndex = 2;
            this.rdoClientType.SelectedIndexChanged += new System.EventHandler(this.rdoClientType_SelectedIndexChanged);
            // 
            // dtpkCreateDate
            // 
            this.dtpkCreateDate.EditValue = null;
            this.dtpkCreateDate.Enabled = false;
            this.dtpkCreateDate.Location = new System.Drawing.Point(117, 30);
            this.dtpkCreateDate.Name = "dtpkCreateDate";
            this.dtpkCreateDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpkCreateDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpkCreateDate.Properties.DisplayFormat.FormatString = "dd-MM-yyyy";
            this.dtpkCreateDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.dtpkCreateDate.Properties.EditFormat.FormatString = "dd-MM-yyyy";
            this.dtpkCreateDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.dtpkCreateDate.Size = new System.Drawing.Size(157, 20);
            this.dtpkCreateDate.TabIndex = 1;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(5, 88);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(76, 13);
            this.labelControl4.TabIndex = 2;
            this.labelControl4.Text = "Tên khách hàng";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(5, 61);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(77, 13);
            this.labelControl3.TabIndex = 1;
            this.labelControl3.Text = "Loại khách hàng";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(5, 33);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(71, 13);
            this.labelControl2.TabIndex = 0;
            this.labelControl2.Text = "Ngày lập phiếu";
            // 
            // labelControl1
            // 
            this.labelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.labelControl1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl1.Location = new System.Drawing.Point(12, 12);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(756, 24);
            this.labelControl1.TabIndex = 5;
            this.labelControl1.Text = "Phiếu mua hàng";
            // 
            // SuaPhieuMua_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(780, 526);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.groupControlDetail);
            this.Controls.Add(this.groupControlGeneralInfo);
            this.Controls.Add(this.labelControl1);
            this.Name = "SuaPhieuMua_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sửa phiếu mua hàng";
            this.Load += new System.EventHandler(this.SuaPhieuMua_Form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBuy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBuyList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtWeight.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlDetail)).EndInit();
            this.groupControlDetail.ResumeLayout(false);
            this.groupControlDetail.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrice.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboProductType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboProduct.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtQuantity.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlGeneralInfo)).EndInit();
            this.groupControlGeneralInfo.ResumeLayout(false);
            this.groupControlGeneralInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboClientName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdoClientType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpkCreateDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpkCreateDate.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraGrid.Views.Grid.GridView dgvBuy;
        private DevExpress.XtraGrid.GridControl dgvBuyList;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.LabelControl labelControl11;
        private DevExpress.XtraEditors.LabelControl lbTotal;
        private DevExpress.XtraEditors.LabelControl labelControl10;
        private DevExpress.XtraEditors.TextEdit txtWeight;
        private DevExpress.XtraEditors.GroupControl groupControlDetail;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private DevExpress.XtraEditors.TextEdit txtPrice;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.ComboBoxEdit cboProductType;
        private DevExpress.XtraEditors.ComboBoxEdit cboProduct;
        private DevExpress.XtraEditors.TextEdit txtQuantity;
        private DevExpress.XtraEditors.SimpleButton btnAdd;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.GroupControl groupControlGeneralInfo;
        private DevExpress.XtraEditors.ComboBoxEdit cboClientName;
        private DevExpress.XtraEditors.RadioGroup rdoClientType;
        private DevExpress.XtraEditors.DateEdit dtpkCreateDate;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl lblPhoneNumber;
        private DevExpress.XtraEditors.LabelControl lblPhone;
    }
}