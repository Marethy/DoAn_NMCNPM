using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using BUL;
using QuanLiBanVang.Model;
using DTO;

namespace QuanLiBanVang.Form
{
    public partial class NhaCungCap_Form : DevExpress.XtraEditors.XtraForm
    {

        // datbase context
        private BUL_NhaCungCap bulProvider = new BUL_NhaCungCap();
        private ActionType formActionType; // mark user's intention when opening the form
        public delegate void RefreshDelegate();
        public RefreshDelegate refreshDelegateCallback;
        public bool IsFromParentForm { get; set; }
        public NhaCungCap_Form()
        {
            InitializeComponent();
        }


        public NhaCungCap_Form(ActionType type, NHACUNGCAP data)
        {
            this.InitializeComponent();
            // setup the view coresponding to the type of the form
            this.formActionType = type;
            switch (type)
            {
                case ActionType.ACTION_VIEW:
                    this.viewActionType(data);
                    break;
                case ActionType.ACTION_CREATE_NEW:
                    this.textEditMaNCC.Enabled = false;
                    this.labelControlMaNCC.Enabled = false;
                    this.textEditMaNCC.Visible = false;
                    this.labelControlMaNCC.Visible = false;
                    break;
                case ActionType.ACTION_UPDATE:
                    this.updateProviderActionType(data);
                    break;
                default: break;
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void NhaCungCap_Load(object sender, EventArgs e)
        {

        }


        /// <summary>
        /// make sure all contents from view is valid(not null or empty or existed from database)
        /// </summary>
        /// <returns>
        /// true if all contents are valid. Otherwise, returns false
        /// </returns>
        private bool isValidInformation()
        {
            if (string.IsNullOrEmpty(this.textEditTenNhaCungCap.Text)
                || string.IsNullOrEmpty(this.richTextBoxDiaChi.Text)
                || string.IsNullOrEmpty(this.textEditSoDienThoai.Text))
            {
                MessageBox.Show(ErrorMessage.CLIENT_INVALID_INPUT_MESSAGE, ErrorMessage.ERROR_MESSARE_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            // check if this new provider did not exist in database
            //if (this.bulProvider.getAll().Any(x => x.TenNCC.Equals(this.textEditTenNhaCungCap.Text.Trim())))
            //{
            //    MessageBox.Show(ErrorMessage.EXISTED_PROVIDER_IN_DATABASE, ErrorMessage.ERROR_MESSARE_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return false;
            //}

            return true;
        }
        /// <summary>
        /// save new provider into database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            if (this.formActionType == ActionType.ACTION_CREATE_NEW)
            {
                if (this.isValidInformation())
                {
                    // save new supplier
                    this.bulProvider.add(new NHACUNGCAP
                    {
                        // MACC is auto increment
                        TenNCC = this.textEditTenNhaCungCap.Text.Trim(),
                        DiaChi = this.richTextBoxDiaChi.Text.Trim(),
                        SDT = this.textEditSoDienThoai.Text.Trim()

                    });
                    // show notification to user
                    DialogResult notification = MessageBox.Show(NotificationMessage.MESSAGE_SAVING_JOB_DONE,
                        NotificationMessage.MESSAGE_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (notification == DialogResult.OK)
                    {
                        if (this.IsFromParentForm)
                        {
                            this.refreshDelegateCallback();
                        }
                        this.Close();
                    }
                }
            }
            else if (this.formActionType == ActionType.ACTION_UPDATE && this.isValidInformation())
            {
                NHACUNGCAP modifiedProvider = new NHACUNGCAP
                {
                    TenNCC = this.textEditTenNhaCungCap.Text,
                    DiaChi = this.richTextBoxDiaChi.Text,
                    SDT = this.textEditSoDienThoai.Text
                };
                this.bulProvider.updateProvider(int.Parse(this.textEditMaNCC.Text), modifiedProvider);
                // show notification to user
                DialogResult notification = MessageBox.Show(NotificationMessage.MESSAGE_UPDATE_JOB_DONE,
                    NotificationMessage.MESSAGE_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (notification == System.Windows.Forms.DialogResult.OK)
                {
                    if (this.IsFromParentForm)
                    {
                        this.refreshDelegateCallback();
                    }
                    this.Close();
                }

            }
        }
        /// <summary>
        /// Set up data for viewing existed provider from database
        /// and disable all essential view components to prevent user from modifying data
        /// </summary>
        /// <param name="data"> data to be filled in the view</param>
        private void viewActionType(NHACUNGCAP data)
        {
            this.Text = "Thông tin nhà cung cấp";
            this.labelControlCaption.Text = "Thông tin nhà cung cấp";
            this.textEditMaNCC.Text = data.MaNCC.ToString();
            this.textEditMaNCC.ReadOnly = true;
            this.textEditTenNhaCungCap.Text = data.TenNCC;
            this.textEditTenNhaCungCap.ReadOnly = true;
            this.textEditSoDienThoai.Text = data.SDT;
            this.textEditSoDienThoai.ReadOnly = true;
            this.richTextBoxDiaChi.Text = data.DiaChi;
            this.richTextBoxDiaChi.ReadOnly = true;

            // invisible button
            this.simpleButtonLuu.Enabled = false;
            this.simpleButtonLuu.Visible = false;
        }

        private void updateProviderActionType(NHACUNGCAP argument)
        {
            // make sure argument is valid
            if (argument == null)
            {
                return;
            }

            this.textEditMaNCC.Text = argument.MaNCC.ToString();
            this.textEditMaNCC.Enabled = false;
            this.textEditTenNhaCungCap.Text = argument.TenNCC;
            this.textEditTenNhaCungCap.Enabled = true;
            this.textEditSoDienThoai.Text = argument.SDT;
            this.textEditSoDienThoai.Enabled = true;
            this.richTextBoxDiaChi.Text = argument.DiaChi;


            // update button text
            this.simpleButtonLuu.Text = "Sủa";
        }

        private void NhaCungCap_Form_SizeChanged(object sender, EventArgs e)
        {
            groupControl1.Left = (ClientSize.Width - groupControl1.Width) / 2;
            simpleButtonThoat.Left = groupControl1.Right - simpleButtonLuu.Width;
            simpleButtonLuu.Left = simpleButtonThoat.Left - simpleButtonLuu.Width - 10;
        }
    }
}