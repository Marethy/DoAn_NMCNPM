using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUL;
using DevExpress.XtraEditors;

namespace QuanLiBanVang.Report
{
    public partial class DanhSachNhanVien_Form : DevExpress.XtraEditors.XtraForm
    {
        private DataTable _staffTable;
        private DataColumn _keyField;
        private BUL.BUL_NhanVien _bulStaff;
        private BUL.BUL_ChucVu _bulPosition;
        private BUL.BUL_NhomNguoiDung _bulGroupUser;
        private ExtendClass.MyCache _myCache;
        private const int DEFAULT_USER_ID = 12;
        public DanhSachNhanVien_Form()
        {
            InitializeComponent();
            _bulStaff = new BUL.BUL_NhanVien();
            _bulPosition = new BUL_ChucVu();
            _myCache = new ExtendClass.MyCache("Id");
            _bulPosition = new BUL.BUL_ChucVu();
            _bulGroupUser = new BUL.BUL_NhomNguoiDung();
            
        }
        private void createTable()
        {
            _staffTable = new DataTable();
            _keyField = _staffTable.Columns.Add("Id", typeof(int));
            _keyField.ReadOnly = true;
            _keyField.AutoIncrement = true;
            _staffTable.Columns.Add("Họ và tên", typeof(string));
            _staffTable.Columns.Add("Ngày sinh", typeof(string));
            _staffTable.Columns.Add("Giới tính", typeof(string));
            _staffTable.Columns.Add("Chức vụ", typeof(string));
            _staffTable.Columns.Add("Số điện thoại", typeof(string));
            _staffTable.Columns.Add("Tên đăng nhập", typeof(string));
            _staffTable.Columns.Add("Nhóm người dùng", typeof(string));
            

        }
        private void addNewRowToDataTable(DTO.NHANVIEN staff, string position, string groupusername)
        {
            var datarow = _staffTable.NewRow();
            datarow[0] = staff.MaNV;
            datarow[1] = staff.HoTen;
            datarow[2] = staff.NgSinh;

            if(staff.GioiTinh == true)
            {
                datarow[3] = "Nam";
            }
            else
            {
                datarow[3] = "Nữ";
            }
            datarow[4] = position;
            datarow[5] = staff.SDT;
            datarow[6] = staff.TenDangNhap;
            datarow[7] = groupusername;
            this._staffTable.Rows.Add(datarow);

        }
        private void updateRowInDataTable(int index, DTO.NHANVIEN staff, string pos, string groupusername)
        {
            _staffTable.Rows[index][1] = staff.HoTen;
            _staffTable.Rows[index][2] = staff.NgSinh;
            if (staff.GioiTinh == true)
            {
                _staffTable.Rows[index][3] = "Nam";
            }
            else
            {
                _staffTable.Rows[index][3] = "Nữ";
            }
            _staffTable.Rows[index][4] = pos;
            _staffTable.Rows[index][5] = staff.SDT;
            _staffTable.Rows[index][6] = staff.TenDangNhap;
            _staffTable.Rows[index][7] = groupusername;
            dgvStaff.RefreshRow(index);
        }
        private void initTableData(List<DTO.NHANVIEN> liststaff, List<DTO.CHUCVU> listpos, List<DTO.NHOMNGUOIDUNG> listgroupuser)
        {
            foreach (DTO.NHANVIEN i in liststaff)
            {
                string pos = ""; 
                string groupusername = "";
                foreach (DTO.CHUCVU j in listpos)
                {
                    if (i.MaCV == j.MaCV)
                    {
                        pos = j.TenCV;
                        break;
                    }
                }
                foreach (DTO.NHOMNGUOIDUNG k in listgroupuser)
                {
                    if (k.MaNhom == i.MaNhom)
                    {
                        groupusername = k.TenNhom;
                        break;
                    }
                }
                this.addNewRowToDataTable(i, pos, groupusername);
            }
            
        }
        private void DanhSachNhanVien_Form_Load(object sender, EventArgs e)
        {
            List<DTO.NHANVIEN> listStaff = _bulStaff.getAllStaff();
            List<DTO.CHUCVU> listPosition = _bulPosition.getAllPosition();
            List<DTO.NHOMNGUOIDUNG> listGroupUser = _bulGroupUser.getAllGroupUser();
            this.createTable();
            this.initTableData(listStaff, listPosition, listGroupUser);
            this.dgvListStaff.DataSource = _staffTable;
            this.dgvStaff.Columns[0].Visible = false;
        }
        
        private void gridViewListStaff_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            if (e.IsGetData)
                e.Value = _myCache.getValue(e.Row);
            if (e.IsSetData)
                _myCache.setValue(e.Row, e.Value);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            NhapNhanVien_Form addStaffForm = new NhapNhanVien_Form();
            DialogResult result = addStaffForm.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                DTO.NHANVIEN newRow = _bulStaff.getLastStaff();
                addNewRowToDataTable(newRow, _bulPosition.getPositionById(newRow.MaCV).TenCV, _bulGroupUser.getGroupUserById(newRow.MaNhom).TenNhom);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DataRow row = null;
            int pos = 0;
            foreach (int i in this.dgvStaff.GetSelectedRows())
            {
                row = this.dgvStaff.GetDataRow(i);
                pos = i;
                break;
            }
            if (row != null)
            {
                if ((int)row[0] == DEFAULT_USER_ID)
                {
                    MessageBox.Show("Đây là tài khoản mặc định, bạn không thể xóa tài khoản này!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (ExtendClass.UserAccess.Instance.GetUserId == (int)row[0])
                {
                    MessageBox.Show("Không thể xóa tài khoản đang đăng nhập!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    DialogResult dresult = MessageBox.Show("Bạn có chắc muốn xóa tài khoản này?", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    if (dresult == System.Windows.Forms.DialogResult.OK)
                    {
                        bool isSucess =this._bulStaff.deleteStaff((int)row[0]);
                        if (isSucess)
                        {
                            this.dgvStaff.DeleteRow(pos);
                            MessageBox.Show("Xóa tài khoản nhân viên thành công", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Không thể xóa tài khoản nhân viên đã sử dụng!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            DataRow row = null;
            int pos = 0;
            foreach (int i in this.dgvStaff.GetSelectedRows())
            {
                row = this.dgvStaff.GetDataRow(i);
                pos = i;
                break;
            }
            if (row != null)
            {
                if ((int)row[0] == DEFAULT_USER_ID)
                {
                    MessageBox.Show("Đây là tài khoản mặc định, bạn không thể thay đổi!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                SuaNhanVien_Form updateStaffForm = new SuaNhanVien_Form((int)row[0]);
                DialogResult result = updateStaffForm.ShowDialog();
                if (result == System.Windows.Forms.DialogResult.OK)
                {
                    _bulStaff = null;
                    _bulStaff = new BUL.BUL_NhanVien();
                    DTO.NHANVIEN updateRow = _bulStaff.getStaffById((int)row[0]);
                    updateRowInDataTable(pos,updateRow,_bulPosition.getPositionById(updateRow.MaCV).TenCV, _bulGroupUser.getGroupUserById(updateRow.MaNhom).TenNhom);
                    if (updateRow.MaNV == ExtendClass.UserAccess.Instance.GetUserId)
                    {
                        MessageBox.Show("Bạn đã thay đổi tài khoản đang đăng nhập, hệ thống sẽ tự đăng xuất để khởi động lại!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        System.Threading.Thread thread = new System.Threading.Thread(new System.Threading.ThreadStart(MainForm.ThreadProcess));
                        thread.SetApartmentState(System.Threading.ApartmentState.STA);
                        thread.Start();

                        this.MdiParent.Close();
                        this.Close();
                        
                    }
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            _bulStaff = null;
            _bulStaff = new BUL_NhanVien();
            _bulPosition = null;
            _bulPosition = new BUL_ChucVu();
            _bulGroupUser = null;
            _bulGroupUser = new BUL_NhomNguoiDung();
            List<DTO.NHANVIEN> listStaff = _bulStaff.getAllStaff();
            List<DTO.CHUCVU> listPosition = _bulPosition.getAllPosition();
            List<DTO.NHOMNGUOIDUNG> listGroupUser = _bulGroupUser.getAllGroupUser();
            this._staffTable.Rows.Clear();
            this.initTableData(listStaff, listPosition, listGroupUser);
            this.dgvListStaff.DataSource = _staffTable;
        }

        private void barButtonItemCapNhat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            btnUpdate_Click(sender,e);
        }

        private void barButtonItemXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            btnDelete_Click(sender,e);
        }

        private void dgvStaff_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            if (e.MenuType == DevExpress.XtraGrid.Views.Grid.GridMenuType.Row)
                popupMenu1.ShowPopup(MousePosition);
        }


    }
}