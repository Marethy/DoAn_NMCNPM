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
    public partial class DanhSachPhieuChi_Form : DevExpress.XtraEditors.XtraForm
    {
        private DataColumn _keyField;
        private DataTable _paymentTable;
        private ExtendClass.MyCache _myCache;
        private BUL.BUL_PhieuChi _bulPaymentBill;

        private BUL.BUL_NhanVien _bulStaff;
        public DanhSachPhieuChi_Form()
        {
            InitializeComponent();
            _myCache = new ExtendClass.MyCache("Id");
            _bulPaymentBill = new BUL.BUL_PhieuChi();

            _bulStaff = new BUL.BUL_NhanVien();
        }
        private void createTable()
        {
            _paymentTable = new DataTable();
            _keyField = _paymentTable.Columns.Add("Id", typeof(int));
            _keyField.ReadOnly = true;
            _keyField.AutoIncrement = true;
            _paymentTable.Columns.Add("Ngày lập", typeof(DateTime));
            _paymentTable.Columns.Add("Người lập", typeof(string));
            _paymentTable.Columns.Add("Nội dung chi", typeof(string));
            _paymentTable.Columns.Add("Số tiền", typeof(decimal));
            

        }
        private void initTableData(List<DTO.PHIEUCHI> listpayment, List<DTO.NHANVIEN> liststaff)
        {
            foreach(DTO.PHIEUCHI i in listpayment)
            {
                string staffname = "";

                foreach (DTO.NHANVIEN j in liststaff)
                {
                    if (i.MaNV == j.MaNV)
                    {
                        staffname = j.HoTen;
                        break;
                    }
                }
             
                this.addNewRowToDataTable(i, staffname);
            }
        }
        private void addNewRowToDataTable(DTO.PHIEUCHI paymentbill, string staffname)
        {
            var datarow = _paymentTable.NewRow();
            datarow[0] = paymentbill.SoPC;
            datarow[1] = paymentbill.NgayLap;
            datarow[2] = staffname;
            datarow[3] = paymentbill.NoiDungChi;
            datarow[4] = Math.Round(paymentbill.SoTien).ToString();
            _paymentTable.Rows.Add(datarow);
        }
        private void updateRowInDataTable(int index, DTO.PHIEUCHI paymentbill, string staffname)
        {
            _paymentTable.Rows[index][1] = paymentbill.NgayLap;
            _paymentTable.Rows[index][2] = staffname;
            _paymentTable.Rows[index][3] = paymentbill.NoiDungChi;
            _paymentTable.Rows[index][4] = Math.Round(paymentbill.SoTien).ToString();
            this.dgvPaymentBill.RefreshRow(index);
        }
        private void dgvPaymentBill_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            if (e.IsGetData)
                e.Value = _myCache.getValue(e.Row);
            if (e.IsSetData)
                _myCache.setValue(e.Row, e.Value);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            NhapPhieuChi_Form addPaymentForm = new NhapPhieuChi_Form();
            DialogResult result = addPaymentForm.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                DTO.PHIEUCHI newRow = _bulPaymentBill.getLastPaymentBill();
                this.addNewRowToDataTable(newRow, _bulStaff.getStaffById(newRow.MaNV).HoTen);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DataRow row = null;
            int pos = 0;
            foreach (int i in this.dgvPaymentBill.GetSelectedRows())
            {
                row = this.dgvPaymentBill.GetDataRow(i);
                pos = i;
                break;

            }
            if (row != null)
            {
                //delete 
                DateTime current = DateTime.UtcNow.Date;
                if (DateTime.Compare(((DateTime)row[1]).Date, current) < 0)
                {
                    MessageBox.Show("Không thể xóa phiếu chi đã lập trước ngày hiện tại!","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    return;
                }
                DialogResult dresult = MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (dresult == System.Windows.Forms.DialogResult.OK)
                {
                    this._bulPaymentBill.deletePaymentBill((int)row[0]);
                    this.dgvPaymentBill.DeleteRow(pos);
                    MessageBox.Show("Đã xóa thành công!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            DataRow row = null;
            int pos = 0;
            foreach (int i in this.dgvPaymentBill.GetSelectedRows())
            {
                row = this.dgvPaymentBill.GetDataRow(i);
                pos = i;
                break;
            }
            if (row != null)
            {
                //DateTime current = DateTime.UtcNow.Date;
                if (DateTime.Compare(((DateTime)row[1]).Date, DateTime.Now.Date) < 0)
                {
                    MessageBox.Show("Không thể sửa phiếu chi đã lập trước ngày hiện tại!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                SuaPhieuChi_Form editPayment_frm = new SuaPhieuChi_Form((int)row[0]);
                DialogResult dresult = editPayment_frm.ShowDialog();
                if (dresult == System.Windows.Forms.DialogResult.OK)
                {
                    _bulPaymentBill = null;
                    _bulPaymentBill = new BUL.BUL_PhieuChi();
                    DTO.PHIEUCHI updateRow = _bulPaymentBill.getPaymentBillById((int)row[0]);
                    this.updateRowInDataTable(pos, updateRow, _bulStaff.getStaffById(updateRow.MaNV).HoTen);
                }
            }
        }

        private void DanhSachPhieuChi_Form_Load(object sender, EventArgs e)
        {
            List<DTO.PHIEUCHI> listPaymentBill = _bulPaymentBill.getAllPaymentBill();

            List<DTO.NHANVIEN> listStaff = _bulStaff.getAllStaff();
            this.createTable();
            this.initTableData(listPaymentBill,  listStaff);
            this.dgvListPayment.DataSource = _paymentTable;
            this.dgvPaymentBill.Columns[0].Visible = false;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            _bulPaymentBill = null;
            _bulPaymentBill = new BUL.BUL_PhieuChi();
            _bulStaff = null;
            _bulStaff = new BUL.BUL_NhanVien();
            List<DTO.PHIEUCHI> listPaymentBill = _bulPaymentBill.getAllPaymentBill();

            List<DTO.NHANVIEN> listStaff = _bulStaff.getAllStaff();
            this._paymentTable.Rows.Clear();
            
            this.initTableData(listPaymentBill, listStaff);
            this.dgvListPayment.DataSource = _paymentTable;
            this.dgvPaymentBill.Columns[0].Visible = false;
        }

        private void dgvPaymentBill_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            if (e.MenuType == DevExpress.XtraGrid.Views.Grid.GridMenuType.Row)
                popupMenu1.ShowPopup(MousePosition);
        }

        private void barButtonItemCapNhat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            btnUpdate_Click(sender,e);
        }

        private void barButtonItemXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            btnDelete_Click(sender,e);
        }
        

    }
}