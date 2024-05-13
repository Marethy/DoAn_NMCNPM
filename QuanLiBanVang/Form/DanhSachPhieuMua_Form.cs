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

namespace QuanLiBanVang.Report
{
    public partial class DanhSachPhieuMua_Form : DevExpress.XtraEditors.XtraForm
    {
        private BUL.BUL_PhieuMua _bulBuyBill;
        private BUL.BUL_NhanVien _bulStaff;
        private BUL.BUL_KhachHang _bulClient;
        private DataColumn _keyField;
        private ExtendClass.MyCache _myCache;
        private DataTable _buyTable;

        private int _staffId;
        public DanhSachPhieuMua_Form()
        {
            InitializeComponent();
            _bulBuyBill = new BUL.BUL_PhieuMua();
            _bulStaff = new BUL.BUL_NhanVien();
            _bulClient = new BUL.BUL_KhachHang();
            _myCache = new ExtendClass.MyCache("Id");
        }
        public DanhSachPhieuMua_Form(int staffid)
        {
            InitializeComponent();
            _bulBuyBill = new BUL.BUL_PhieuMua();
            _bulStaff = new BUL.BUL_NhanVien();
            _bulClient = new BUL.BUL_KhachHang();
            _staffId = staffid;
            _myCache = new ExtendClass.MyCache("Id");
            
            
        }
        private void createTable()
        {
            _buyTable = new DataTable();
            _keyField = _buyTable.Columns.Add("Id", typeof(int));
            _buyTable.Columns.Add("Tên nhân viên", typeof(string));
            _buyTable.Columns.Add("Tên khách hàng", typeof(string));
            _buyTable.Columns.Add("Ngày lập", typeof(DateTime));
            _buyTable.Columns.Add("Tổng tiền", typeof(decimal));
        }
        private void addNewRowToTableData(DTO.PHIEUMUAHANG buybill, string staffname, string clientname)
        {
            DataRow newRow = _buyTable.NewRow();
            newRow[0] = buybill.SoPhieuMua;
            newRow[1] = staffname;
            newRow[2] = clientname;
            newRow[3] = buybill.NgayMua.Date;
            newRow[4] = Math.Round(buybill.TongTien.Value).ToString();
            _buyTable.Rows.Add(newRow);
        }
        private void updateRowInTableData(int index, DTO.PHIEUMUAHANG buybill, string staffname, string clientname)
        {
            _buyTable.Rows[index][1] = staffname;
            if (clientname != "")
            {
                _buyTable.Rows[index][2] = clientname;
            }
            else
            {
                _buyTable.Rows[index][2] = "Khách vãng lai";
            }
            _buyTable.Rows[index][3] = buybill.NgayMua.Date;
            _buyTable.Rows[index][4] = Math.Round(buybill.TongTien.Value).ToString();
            this.dgvBuyBill.RefreshRow(index);
        }
        private void initTableData(List<DTO.PHIEUMUAHANG> listbuybill, List<DTO.NHANVIEN> liststaff, List<DTO.KHACHHANG> listclient)
        {
            string staffname = "";
            string clientname = "";
            foreach (DTO.PHIEUMUAHANG i in listbuybill)
            {
                foreach (DTO.NHANVIEN j in liststaff)
                {
                    if (i.MaNV == j.MaNV)
                    {
                        staffname = j.HoTen;
                        break;
                    }
                }
                if (i.MaKH.ToString() != "")
                {
                    foreach (DTO.KHACHHANG k in listclient)
                    {
                        if (i.MaKH == k.MaKH)
                        {
                            clientname = k.TenKH;
                            break;
                        }
                    }
                }
                else
                {
                    clientname = "Khách vãng lai";
                }
                this.addNewRowToTableData(i, staffname, clientname);
            }

        }


        private void DanhSachPhieuMua_Form_Load(object sender, EventArgs e)
        {
            List<DTO.PHIEUMUAHANG> listbuybill = _bulBuyBill.getAllBuyBill();
            List<DTO.NHANVIEN> liststaff = _bulStaff.getAllStaff();
            List<DTO.KHACHHANG> listclient = _bulClient.GetAllKhachhangs();
            createTable();
            this.initTableData(listbuybill, liststaff, listclient);
            this.dgvListBuyBill.DataSource = _buyTable;
            this.dgvBuyBill.Columns["Id"].Visible = false;
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            NhapPhieuMua_Form addBuyBillForm = new NhapPhieuMua_Form();
            DialogResult result = addBuyBillForm.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                DTO.PHIEUMUAHANG newBuyBill = _bulBuyBill.getLastBuyBill();
                if (newBuyBill.MaKH.ToString() != "")
                {
                    this.addNewRowToTableData(newBuyBill, _bulStaff.getStaffById(newBuyBill.MaNV).HoTen, _bulClient.GetKhachhangById((int)newBuyBill.MaKH).TenKH);
                }
                else
                {
                    this.addNewRowToTableData(newBuyBill, _bulStaff.getStaffById(newBuyBill.MaNV).HoTen,"Khách vãng lai");
                }
            }
        }
        private bool checkLegalDateChange(DateTime changetime)
        {
            DateTime current = DateTime.Now.Date;
            if (DateTime.Compare(changetime, current) < 0)
            {
                return false;
            }
            return true;
        }
        //private void btnDelete_Click(object sender, EventArgs e)
        //{
        //    DataRow row = null;
        //    int pos = -1;
        //    foreach (int i in this.dgvBuyBill.GetSelectedRows())
        //    {
        //        pos = i;
        //        row = this.dgvBuyBill.GetDataRow(i);
        //        break;
        //    }
        //    if (row != null)
        //    {
        //        if (this.checkLegalDateChange(((DateTime)row[3]).Date) == true)
        //        {
        //            this.dgvBuyBill.DeleteRow(pos);
        //        }
        //        else
        //        {
        //            MessageBox.Show("Không thể xóa phiếu khác ngày hiện tại!");
        //            return;
        //        }
        //    }
        //}

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            DataRow row = null;
            int pos = -1;
            foreach (int i in this.dgvBuyBill.GetSelectedRows())
            {
                pos = i;
                row = this.dgvBuyBill.GetDataRow(i);
                break;
            }
            if (row != null)
            {
                //if (!this.checkLegalDateChange(((DateTime)row[3]).Date) == true)
                //{
                //    MessageBox.Show("Không thể sửa phiếu của ngày trước!");
                //    return;
                //}
                SuaPhieuMua_Form updateBuyBillForm = new SuaPhieuMua_Form((int)row[0]);
                DialogResult result = updateBuyBillForm.ShowDialog();
                if (result == System.Windows.Forms.DialogResult.OK)
                {
                    _bulBuyBill = null;
                    _bulBuyBill = new BUL.BUL_PhieuMua();
                    DTO.PHIEUMUAHANG editedBill = _bulBuyBill.getBuyBillById((int)row[0]);
                    if (editedBill.MaKH.ToString() != "")
                    {
                        this.updateRowInTableData(pos, editedBill, _bulStaff.getStaffById(editedBill.MaNV).HoTen, _bulClient.GetKhachhangById((int)editedBill.MaKH).TenKH);
                    }
                    else
                    {
                        this.updateRowInTableData(pos, editedBill, _bulStaff.getStaffById(editedBill.MaNV).HoTen, "");
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
            _bulBuyBill = null;
            _bulStaff = null;
            _bulClient = null;
            _bulBuyBill = new BUL.BUL_PhieuMua();
            _bulClient = new BUL.BUL_KhachHang();
            _bulStaff = new BUL.BUL_NhanVien();
            List<DTO.PHIEUMUAHANG> listbuybill = _bulBuyBill.getAllBuyBill();
            List<DTO.NHANVIEN> liststaff = _bulStaff.getAllStaff();
            List<DTO.KHACHHANG> listclient = _bulClient.GetAllKhachhangs();
            this._buyTable.Rows.Clear();
            this.initTableData(listbuybill, liststaff, listclient);
            this.dgvListBuyBill.DataSource = _buyTable;
        }

        private void barButtonItemCN_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            btnUpdate_Click(sender,e);
        }


        private void dgvBuyBill_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            if (e.MenuType == DevExpress.XtraGrid.Views.Grid.GridMenuType.Row)
                popupMenu1.ShowPopup(MousePosition);
        }


    }
}