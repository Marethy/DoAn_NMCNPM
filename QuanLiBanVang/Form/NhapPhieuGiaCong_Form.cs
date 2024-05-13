using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using QuanLiBanVang.ExtendClass;
using BUL;
using DevExpress.XtraEditors.Controls;
using DTO;
using QuanLiBanVang.Properties;

namespace QuanLiBanVang
{
    public partial class NhapPhieuGiaCong_Form : DevExpress.XtraEditors.XtraForm
    {
        private DataColumn _keyFeild;
        private DataTable _dataTableCtspCanGiaCong;
        private DataTable _dataTableCtpgcReview;
        private MyCache _cache = new MyCache("IDcache");
        private int _maNV;
        private bool _isResultOk;
        private ComboBoxItemCollection _comboboxItemsTho;
        private double _phanTramTienGcThoNhan;
        public NhapPhieuGiaCong_Form()
        {
            InitializeComponent();
            _maNV = _maNV = ExtendClass.UserAccess.Instance.GetUserId;;
            _isResultOk = false;
            
        }

        private void PhieuGiaCong_Load(object sender, EventArgs e)
        {
            dateEditNgayNhanHang.DateTime = DateTime.Today;
            dateEditNgayNhanHang.ReadOnly = true;
            CreateDataTableCtspgc();
            LoadCtpdvCanGiaCong();
            CreateDataTablePGC_review();
            LoadEmployeeName();
            LoadDanhSachTho();
            _phanTramTienGcThoNhan = new BUL_BangThamSo().getValueByArgument("PhanTramTienGCThoNhan");
            labelControlChuThichTienCong.Text = "=(" + (_phanTramTienGcThoNhan*100) + "%)";
        }

        private void CreateDataTableCtspgc()
        {
            _dataTableCtspCanGiaCong = new DataTable();
            _keyFeild = _dataTableCtspCanGiaCong.Columns.Add("IDcache", typeof(int));
            _keyFeild.ReadOnly = true;
            _keyFeild.AutoIncrement = true;
            _dataTableCtspCanGiaCong.Columns.Add("Id", typeof(int));
            _dataTableCtspCanGiaCong.Columns.Add("SoPhieuDV", typeof(int));
            _dataTableCtspCanGiaCong.Columns.Add("MaLoaiSP", typeof(int));
            _dataTableCtspCanGiaCong.Columns.Add("TenLoaiSP", typeof(string));
            _dataTableCtspCanGiaCong.Columns.Add("HTGC", typeof(string));
            _dataTableCtspCanGiaCong.Columns.Add("SoLuong", typeof(int));
            _dataTableCtspCanGiaCong.Columns.Add("TienCong", typeof (int));
            gridControlCTSPGC.DataSource = _dataTableCtspCanGiaCong;
            gridViewCTSPGC.Columns[0].Visible =
                gridViewCTSPGC.Columns[1].Visible =
                    gridViewCTSPGC.Columns[2].Visible =
                        gridViewCTSPGC.Columns[3].Visible =false;
            gridViewCTSPGC.Columns[4].Caption = Resources.TenLoaiSP;
            gridViewCTSPGC.Columns[5].Caption = Resources.HTGC;
            gridViewCTSPGC.Columns[6].Caption = Resources.SoLuong;
            gridViewCTSPGC.Columns[7].Caption = Resources.TienCong;
            gridViewCTSPGC.OptionsMenu.EnableColumnMenu = false;

        }
        private void CreateDataTablePGC_review()
        {
            _dataTableCtpgcReview = new DataTable();
            _keyFeild = _dataTableCtpgcReview.Columns.Add("IDcache", typeof(int));
            _keyFeild.ReadOnly = true;
            _keyFeild.AutoIncrement = true;
            _dataTableCtpgcReview.Columns.Add("SoPhieuDV", typeof(int));
            _dataTableCtpgcReview.Columns.Add("Id", typeof(int));
            _dataTableCtpgcReview.Columns.Add("MaLoaiSP", typeof(int));
            _dataTableCtpgcReview.Columns.Add("TenLoaiSP", typeof(string));
            _dataTableCtpgcReview.Columns.Add("HTGC", typeof(string));
            _dataTableCtpgcReview.Columns.Add("SoLuong", typeof(int));
            _dataTableCtpgcReview.Columns.Add("TienCong", typeof(int));
            _dataTableCtpgcReview.Columns.Add("ThanhTien", typeof(int));
            gridControlCTPGC_review.DataSource = _dataTableCtpgcReview;
            gridViewCTPGC_review.Columns[0].Visible =
                gridViewCTPGC_review.Columns[1].Visible =
                    gridViewCTPGC_review.Columns[2].Visible =
                        gridViewCTPGC_review.Columns[3].Visible = false;
            gridViewCTPGC_review.Columns[4].Caption = Resources.TenLoaiSP;
            gridViewCTPGC_review.Columns[5].Caption = Resources.HTGC;
            gridViewCTPGC_review.Columns[6].Caption = Resources.SoLuong;
            gridViewCTPGC_review.Columns[7].Caption = Resources.TienCong;
            gridViewCTPGC_review.Columns[8].Caption = Resources.ThanhTien;
            gridViewCTPGC_review.OptionsMenu.EnableColumnMenu = false;

        }
        private void gridViewCT_PDV_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            if (e.IsGetData)
                e.Value = _cache.getValue(e.Row);
            if (e.IsSetData)
                _cache.setValue(e.Row, e.Value);
        }

        private void gridViewCTPGC_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            if (e.IsGetData)
                e.Value = _cache.getValue(e.Row);
            if (e.IsSetData)
                _cache.setValue(e.Row, e.Value);
        }
        private void LoadEmployeeName()
        {
            BUL_NhanVien bulNhanVien = new BUL_NhanVien();
            NHANVIEN nv = bulNhanVien.getStaffById(_maNV);
            textEditTenNhanVien.Text = nv.HoTen;
        }

        private void LoadDanhSachTho()
        {
            BUL_Tho bulTho = new BUL_Tho();
            List<THO> listThos = bulTho.GetAllWorkerList();
            comboBoxEditTenTho.Properties.TextEditStyle = TextEditStyles.DisableTextEditor;
            _comboboxItemsTho = comboBoxEditTenTho.Properties.Items;
            _comboboxItemsTho.BeginUpdate();
            try
            {foreach (var item in listThos)
                {
                    ContainerItem tho = new ContainerItem();
                    tho.Text = item.TenTho;
                    tho.Value = item;
                    _comboboxItemsTho.Add(tho);
                }
            }
            finally
            {
                _comboboxItemsTho.EndUpdate();
            }
        }
        private void LoadCtpdvCanGiaCong()
        {
            BUL_LoaiSanPham bulLoaiSp = new BUL_LoaiSanPham();
            List<LOAISANPHAM> listLoaiSp = bulLoaiSp.getAllProductType();
            BUL_CTPDV bulCtpdv = new BUL_CTPDV();
            List<CTPDV> listCtpdv = bulCtpdv.GetCTPDVGiaCong();
            BUL_CTPGC bulCtpgc = new BUL_CTPGC();
            _dataTableCtspCanGiaCong.Rows.Clear();
            foreach (var item in listCtpdv)
            {
                _dataTableCtspCanGiaCong.Rows.Add(new object[]
                {
                    null,
                    item.Id,
                    item.SoPhieuDV,
                    /*MaLoaiSP*/item.MaLoaiSP == null ? -1 : item.MaLoaiSP,/*TenLoaiSP*/
                    item.MaLoaiSP == null ? "Khác" : listLoaiSp.Find(i => i.MaLoaiSP == item.MaLoaiSP).TenLoaiSP,
                    /*HTGC*/item.GhiChu.Trim(),
                    /*Soluong*/item.SoLuong - bulCtpgc.GetSoluongByIdPDV(item.Id),
                    /*TienCong*/item.TienCong
                });
            }
            gridControlCTSPGC.DataSource = _dataTableCtspCanGiaCong;

            gridViewCTSPGC.Columns["SoPhieuDV"].GroupIndex = 0;
            gridViewCTSPGC.ExpandAllGroups();

        }
        private void gridViewCTPGC_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            DataRow currentRow = gridViewCTSPGC.GetDataRow(gridViewCTSPGC.FocusedRowHandle);
            if (currentRow != null)
            {
                textEditTenLoaiSP.Text = currentRow["TenLoaiSP"].ToString();
                textEditHTGC.Text = currentRow["HTGC"].ToString();
                textEditSoLuong.Text = currentRow["SoLuong"].ToString();
                textEditTienCong.Text = ((int)(Convert.ToInt32(currentRow["TienCong"]) * _phanTramTienGcThoNhan)).ToString();
            }
        }
        private void textEditSoLuong_EditValueChanged(object sender, EventArgs e)
        {
            CalculateThanhTien();
        }
        private void textEditTienCong_EditValueChanged(object sender, EventArgs e)
        {
            CalculateThanhTien();
        }
        private void CalculateThanhTien()
        {
            string soluong = textEditSoLuong.Text;
            string tiencong = textEditTienCong.Text;
            if(soluong.Equals("") || tiencong.Equals(""))
                return;
            textEditThanhTien.Text = (Convert.ToDecimal(soluong)*Convert.ToDecimal(tiencong)).ToString();
        }

        private void simpleButtonThem_Click(object sender, EventArgs e)
        {
            string tenLoaiSp = textEditTenLoaiSP.Text;
            string soLuong = textEditSoLuong.Text;
            string tienCong = textEditTienCong.Text;
            string thanhTien = textEditThanhTien.Text;
            if (tenLoaiSp.Equals(""))
            {
                MessageBox.Show(Resources.NhapPhieuGiaCong_SPCanGiaCongEmpty, Resources.TitleMessageBox_Error, MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
            if (soLuong.Equals("") || soLuong.Equals("0"))
            {
                MessageBox.Show(Resources.NhapPhieuGiaCong_SoLuongBeHonKhong, Resources.TitleMessageBox_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (tienCong.Equals(""))
            {
                MessageBox.Show(Resources.NhapPhieuGiaCong_TienCongEmpty, Resources.TitleMessageBox_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DataRow currentRow = gridViewCTSPGC.GetDataRow(gridViewCTSPGC.FocusedRowHandle);
            if (Int32.Parse(soLuong) > Int32.Parse(currentRow["SoLuong"].ToString()))
            {
                MessageBox.Show(Resources.NhapPhieuGiaCong_SLGiaCongLonHonSLCo, Resources.TitleMessageBox_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DataRow drReview = _dataTableCtpgcReview.Select("Id=" + currentRow["Id"]).FirstOrDefault();
            //Neu da co trong datatable_review thi se cong them so luong va cap nhat tien cong 
            //moi nhat vao. Neu chua co thi moi add dong moi
            if (drReview != null)
            {
                drReview["SoLuong"] = Int32.Parse(drReview["SoLuong"].ToString()) + Int32.Parse(soLuong);
                drReview["TienCong"] = tienCong;
                drReview["ThanhTien"] = ((int) drReview["SoLuong"])*Convert.ToDecimal(tienCong);
            }
            else
            {
                _dataTableCtpgcReview.Rows.Add(new object[]
                {
                    null,
                    currentRow["SoPhieuDV"],
                    currentRow["Id"],
                    /*MaLoaiSP*/currentRow["MaLoaiSP"],
                    /*TenLoaiSP*/currentRow["TenLoaiSP"],
                    /*HTGC*/currentRow["HTGC"],
                    /*Soluong*/Int32.Parse(soLuong),
                    /*TienCong*/Convert.ToDecimal(tienCong),
                    /*ThanhTien*/Convert.ToDecimal(thanhTien)
                });
            }gridControlCTPGC_review.DataSource = _dataTableCtpgcReview;
            gridViewCTPGC_review.Columns["SoPhieuDV"].GroupIndex = 0;
            gridViewCTPGC_review.ExpandAllGroups();
            CalculateTongTien();
            //UpdateDataTableCTSPCanGiaCong
            DataRow dr = _dataTableCtspCanGiaCong.Select("Id=" + currentRow["Id"]).FirstOrDefault(); 
            if (dr != null)
                dr["SoLuong"] = Int32.Parse(dr["SoLuong"].ToString()) - Int32.Parse(soLuong);
        }
        private void CalculateTongTien()
        {
            decimal tongtien = 0;
            for (int i = 0; i < _dataTableCtpgcReview.Rows.Count; i++)
            {
                tongtien += (int)_dataTableCtpgcReview.Rows[i][8];
            }
            textEditTongTien.Text = tongtien.ToString();
        }
        private void simpleButtonXoa_Click(object sender, EventArgs e)
        {
            DataRow currentRow = gridViewCTPGC_review.GetDataRow(gridViewCTPGC_review.FocusedRowHandle);
            if (currentRow != null)
            {
                //UpdateDataTableCTSPCanGiaCong
                DataRow dr = _dataTableCtspCanGiaCong.Select("Id=" + currentRow["Id"]).FirstOrDefault();
                if (dr != null)
                    dr["SoLuong"] = Int32.Parse(dr["SoLuong"].ToString()) +
                                    Int32.Parse(currentRow["SoLuong"].ToString());
                _dataTableCtpgcReview.Rows.Remove(currentRow);
                CalculateTongTien();
            }
        }

        private void simpleButtonLuu_Click(object sender, EventArgs e)
        {
            //Check logic condition
            if (comboBoxEditTenTho.SelectedIndex == -1)
            {
                MessageBox.Show(Resources.NhapPhieuGiaCong_TenThoEmpty, Resources.TitleMessageBox_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                comboBoxEditTenTho.Focus();
                return;
            }
            if (dateEditNgayNhanHang.Text.Equals(""))
            {
                MessageBox.Show(Resources.NhapPhieuGiaCong_NgayNhanHangEmpty, Resources.TitleMessageBox_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                dateEditNgayNhanHang.Focus();
                return;
            }
            if (dateEditNgayThanhToan.Text.Equals(""))
            {
                MessageBox.Show(Resources.NhapPhieuGiaCong_NgayThanhToanEmpty, Resources.TitleMessageBox_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                dateEditNgayThanhToan.Focus();
                return;
            } if (dateEditNgayNhanHang.DateTime != DateTime.Today)
            {
                MessageBox.Show(Resources.NgNhanHang, Resources.TitleMessageBox_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                dateEditNgayNhanHang.Focus();
                return;
            }
            if (dateEditNgayNhanHang.DateTime > dateEditNgayThanhToan.DateTime)
            {
                MessageBox.Show(Resources.NhapPhieuGiaCong_NgayThanhToanTruocNgayNhanHang, Resources.TitleMessageBox_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                dateEditNgayThanhToan.Focus();
                return;
            }
            if (_dataTableCtpgcReview.Rows.Count == 0)
            {
                MessageBox.Show(Resources.NhapPhieuGiaCong_SLChiTietPGCToiThieu, Resources.TitleMessageBox_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //Create PGC
            BUL_PhieuGiaCong bulPhieuGiaCong = new BUL_PhieuGiaCong();
            PHIEUGIACONG phieugiacong = new PHIEUGIACONG();
            phieugiacong.NgayNhanHang = dateEditNgayNhanHang.DateTime;
            phieugiacong.NgayThanhToan = dateEditNgayThanhToan.DateTime;
            phieugiacong.MaTho = ((THO) ((ContainerItem) comboBoxEditTenTho.SelectedItem).Value).MaTho;
            phieugiacong.TongTien = Convert.ToDecimal(textEditTongTien.Text);
            phieugiacong.MaNV = _maNV;
            int sophieuGc = bulPhieuGiaCong.AddNewPhieuGiaCong(phieugiacong);

            //Create CTPGC
            BUL_CTPGC bulCtpgc = new BUL_CTPGC();      
            foreach(DataRow dtRow in _dataTableCtpgcReview.Rows)
            {
                CTPGC ctpgc = new CTPGC();
                ctpgc.SoPhieuGC = sophieuGc;
                ctpgc.Id = Convert.ToInt32(dtRow["Id"]);
                ctpgc.SoLuong = Convert.ToInt32(dtRow["SoLuong"]);
                ctpgc.TienCong = Convert.ToDecimal(dtRow["TienCong"]);
                ctpgc.ThanhTien = Convert.ToDecimal(dtRow["ThanhTien"]);
                ctpgc.TrongLuong = 0.1;
                bulCtpgc.AddNewCTPGC(ctpgc);
            }
            //Neu ok het
            MessageBox.Show(Resources.NhapPhieuGiaCong_TaoPGCThanhCong, Resources.TitleMessageBox_ThongBao, MessageBoxButtons.OK, MessageBoxIcon.Information);
            simpleButtonLuu.Enabled = false;
            simpleButtonThem.Enabled = false;
            simpleButtonXoa.Enabled = false;
            _isResultOk = true;
            Close();
        }
        private void PhieuGiaCong_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_isResultOk)
                DialogResult = DialogResult.OK;
            else
                DialogResult = DialogResult.Cancel;
        }

        private void simpleButtonExit_Click(object sender, EventArgs e)
        {
            Close();
        }


    }
}