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
    public partial class SuaPhieuGiaCong_Form : DevExpress.XtraEditors.XtraForm
    {
        private DataColumn _keyFeild;
        private DataTable _dataTableCtspCanGiaCong;
        private DataTable _dataTableCtpgcReview;
        private MyCache _cache = new MyCache("IDcache");
        private int _maNv;
        private int _soPGC;
        private bool _isResultOk;
        private ComboBoxItemCollection _comboboxItemsTho;
        private double _phanTramTienGcThoNhan;
        public SuaPhieuGiaCong_Form(int soPgc)
        {
            InitializeComponent();
            _soPGC = soPgc;           
            _isResultOk = false;
        }

        private void PhieuGiaCong_Load(object sender, EventArgs e)
        {
            dateEditNgayNhanHang.DateTime = DateTime.Today;
            comboBoxEditTenTho.ReadOnly = true;
            dateEditNgayNhanHang.ReadOnly = true;
            LoadThongTinPgc();
            CreateDataTableCtpdvCanGiaCong();
            LoadCtpdvCanGiaCong();
            CreateDataTableCTPGC_review();
            LoadCtpgc_review();
            _phanTramTienGcThoNhan = new BUL_BangThamSo().getValueByArgument("PhanTramTienGCThoNhan");
            labelControlChuThichTienCong.Text = "=(" + (_phanTramTienGcThoNhan * 100) + "%)";
        }
        private void LoadThongTinPgc()
        {
            BUL_PhieuGiaCong bulPhieuGiaCong = new BUL_PhieuGiaCong();
            PHIEUGIACONG pgc = bulPhieuGiaCong.GetPhieuGiaCongById(_soPGC);
            _maNv = pgc.MaNV;
            LoadEmployeeName(_maNv);
            LoadTho(pgc.MaTho);
            dateEditNgayNhanHang.DateTime = pgc.NgayNhanHang;
            dateEditNgayThanhToan.DateTime = pgc.NgayThanhToan;          
        }
        private void CreateDataTableCtpdvCanGiaCong()
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
            _dataTableCtspCanGiaCong.Columns.Add("TienCong", typeof(int));
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
        private void CreateDataTableCTPGC_review()
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
        private void LoadEmployeeName(int maNv)
        {
            BUL_NhanVien bulNhanVien = new BUL_NhanVien();
            NHANVIEN nv = bulNhanVien.getStaffById(maNv);
            textEditTenNhanVien.Text = nv.HoTen;
        }

        private void LoadTho(int matho)
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
            comboBoxEditTenTho.SelectedIndex = listThos.IndexOf(listThos.Find(i => i.MaTho == matho));
        }
        private void LoadCtpdvCanGiaCong()
        {
            BUL_LoaiSanPham bulLoaiSp = new BUL_LoaiSanPham();
            List<LOAISANPHAM> listLoaiSp = bulLoaiSp.getAllProductType();
            BUL_CTPDV bulCtpdv = new BUL_CTPDV();
            List<CTPDV> listCtpdv = bulCtpdv.GetCTPDVGiaCong();
            BUL_CTPGC bulCtpgc = new BUL_CTPGC();
            _dataTableCtspCanGiaCong.Rows.Clear();
            foreach (var item in listCtpdv){
                _dataTableCtspCanGiaCong.Rows.Add(new object[]
                {
                    null,
                    item.Id,
                    item.SoPhieuDV,
                    /*MaLoaiSP*/item.MaLoaiSP == null ? -1 : item.MaLoaiSP,
                    /*TenLoaiSP*/item.MaLoaiSP == null ? "Khác" : listLoaiSp.Find(i => i.MaLoaiSP == item.MaLoaiSP).TenLoaiSP,
                    /*HTGC*/item.GhiChu.Trim(),
                    /*Soluong*/item.SoLuong - bulCtpgc.GetSoluongByIdPDV(item.Id),
                    /*TienCong*/item.TienCong});
            }
            gridControlCTSPGC.DataSource = _dataTableCtspCanGiaCong;

            gridViewCTSPGC.Columns["SoPhieuDV"].GroupIndex = 0;
            gridViewCTSPGC.ExpandAllGroups();
        }
        private void LoadCtpgc_review()
        {
            BUL_LoaiSanPham bulLoaiSp = new BUL_LoaiSanPham();
            BUL_CTPDV bulCtpdv = new BUL_CTPDV();
            List<LOAISANPHAM> listLoaiSp = bulLoaiSp.getAllProductType();
            BUL_CTPGC bulCtpgc = new BUL_CTPGC();
            List<CTPGC> listCtpgc = bulCtpgc.GetAllCTPGCBySoPhieuGC(_soPGC);
            _dataTableCtpgcReview.Rows.Clear();
            foreach (var item in listCtpgc)
            {
                CTPDV ctpdv = bulCtpdv.GetCTPDVById(item.Id);
                _dataTableCtpgcReview.Rows.Add(new object[]
                {
                    null,
                    ctpdv.SoPhieuDV,
                    item.Id,
                    /*MaLoaiSP*/ctpdv.MaLoaiSP,
                    /*TenLoaiSP*/ctpdv.MaLoaiSP == null ? "Khác" : listLoaiSp.Find(i => i.MaLoaiSP == ctpdv.MaLoaiSP).TenLoaiSP,
                    /*HTGC*/ctpdv.GhiChu.Trim(),
                    /*Soluong*/item.SoLuong,
                    /*TienCong*/item.TienCong,
                    /*ThanhTien*/item.ThanhTien
                });
            }
            gridControlCTPGC_review.DataSource = _dataTableCtpgcReview;
            gridViewCTPGC_review.Columns["SoPhieuDV"].GroupIndex = 0;
            gridViewCTPGC_review.ExpandAllGroups();
            CalculateTongTien();
        }
        private void gridViewCTPGC_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            DataRow currentRow = gridViewCTSPGC.GetDataRow(gridViewCTSPGC.FocusedRowHandle);
            if (currentRow != null)
            {
                textEditTenLoaiSP.Text = currentRow["TenLoaiSP"].ToString();
                textEditHTGC.Text = currentRow["HTGC"].ToString();
                textEditSoLuong.Text = currentRow["SoLuong"].ToString();
                textEditTienCong.Text = (Convert.ToInt32(currentRow["TienCong"]) * _phanTramTienGcThoNhan).ToString();
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
            textEditThanhTien.Text = (Int32.Parse(soluong)*Int32.Parse(tiencong)).ToString();
        }

        private bool CheckLogicError()
        {
            string tenLoaiSp = textEditTenLoaiSP.Text;
            string soLuong = textEditSoLuong.Text;
            string tienCong = textEditTienCong.Text;
            if (tenLoaiSp.Equals(""))
            {
                MessageBox.Show(Resources.NhapPhieuGiaCong_SPCanGiaCongEmpty, Resources.TitleMessageBox_Error, MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }
            if (soLuong.Equals("") || soLuong.Equals("0"))
            {
                MessageBox.Show(Resources.NhapPhieuGiaCong_SoLuongBeHonKhong, Resources.TitleMessageBox_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (tienCong.Equals(""))
            {
                MessageBox.Show(Resources.NhapPhieuGiaCong_TienCongEmpty, Resources.TitleMessageBox_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            DataRow currentRow = gridViewCTSPGC.GetDataRow(gridViewCTSPGC.FocusedRowHandle);
            if (Int32.Parse(soLuong) > Int32.Parse(currentRow["SoLuong"].ToString()))
            {
                MessageBox.Show(Resources.NhapPhieuGiaCong_SLGiaCongLonHonSLCo, Resources.TitleMessageBox_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        private void simpleButtonThem_Click(object sender, EventArgs e)
        {
            if(!CheckLogicError())
                return;
            string soLuong = textEditSoLuong.Text;
            string tienCong = textEditTienCong.Text;
            string thanhTien = textEditThanhTien.Text;
            DataRow currentRow = gridViewCTSPGC.GetDataRow(gridViewCTSPGC.FocusedRowHandle);
            CTPGC ctpgc = new CTPGC
            {
                SoPhieuGC = _soPGC,
                Id = Convert.ToInt32(currentRow["Id"]),
                SoLuong = Convert.ToInt32(soLuong),
                TrongLuong = 0.1,
                TienCong = Convert.ToInt32(tienCong),
                ThanhTien = Convert.ToInt32(thanhTien)
            };
            BUL_CTPGC bulCtpgc = new BUL_CTPGC();
            

            DataRow drReview = _dataTableCtpgcReview.Select("Id=" + currentRow["Id"]).FirstOrDefault();
            //Neu da co trong datatable_review thi se cong them so luong va cap nhat tien cong 
            //moi nhat vao. Neu chua co thi moi add dong moi
            if (drReview != null)
            {
                ctpgc.SoLuong += Convert.ToInt32(drReview["SoLuong"]);
                ctpgc.TienCong = Convert.ToInt32(tienCong);
                ctpgc.ThanhTien = ctpgc.SoLuong * ctpgc.TienCong;
                bulCtpgc.UpdateCTPGC(ctpgc);
            }
            else
            {
                bulCtpgc.AddNewCTPGC(ctpgc);
            }

            //Neu ok het
            MessageBox.Show(Resources.SuaPhieuGiaCong_ThemCTPGCThanhCong, Resources.TitleMessageBox_ThongBao, MessageBoxButtons.OK, MessageBoxIcon.Information);
            //LoadInfoCTPDV();
            _isResultOk = true;
            //UpdateDataTableCTSPCanGiaCong
            LoadCtpdvCanGiaCong();
            LoadCtpgc_review();
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
            if (_dataTableCtpgcReview.Rows.Count == 1)
            {
                MessageBox.Show(Resources.NhapPhieuGiaCong_SLChiTietPGCToiThieu, Resources.TitleMessageBox_ThongBao, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult dialogResult = MessageBox.Show(Resources.DetailMessageBox_XacNhanXoa,
                Resources.TitleMessageBox_ThongBao, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dialogResult != DialogResult.OK)
                return;
            DataRow currentRow = gridViewCTPGC_review.GetDataRow(gridViewCTPGC_review.FocusedRowHandle);
            if (currentRow != null)
            {
                int id = Convert.ToInt32(currentRow["Id"]);
                BUL_CTPGC bulCtpgc = new BUL_CTPGC();
                bulCtpgc.DeleteCTPGC(_soPGC,id);
                //Neu ok het
                MessageBox.Show(Resources.SuaPhieuGiaCong_XoaCTPGCThanhCong, Resources.TitleMessageBox_ThongBao, MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadCtpgc_review();
                LoadCtpdvCanGiaCong();_isResultOk = true;               
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
            phieugiacong.SoPhieuGC = _soPGC;
            phieugiacong.NgayThanhToan = dateEditNgayThanhToan.DateTime;
            phieugiacong.TongTien = Convert.ToDecimal(textEditTongTien.Text);
            bulPhieuGiaCong.UpdatePhieuGiaCong(phieugiacong);
            //Neu ok het
            MessageBox.Show(Resources.SuaPhieuGiaCong_SuaPGCThanhCong, Resources.TitleMessageBox_ThongBao, MessageBoxButtons.OK, MessageBoxIcon.Information);
            simpleButtonLuu.Enabled = false;
            simpleButtonThem.Enabled = false;
            simpleButtonXoa.Enabled = false;
            simpleButtonSua.Enabled = false;
            _isResultOk = true;
            Close();
        }
        private void PhieuGiaCong_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult = _isResultOk ? DialogResult.OK : DialogResult.Cancel;
        }

        private void simpleButtonExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void simpleButtonSua_Click(object sender, EventArgs e)
        {
            int soluong = Convert.ToInt32(textEditSoLuong.Text);
            DataRow drReview = gridViewCTPGC_review.GetDataRow(gridViewCTPGC_review.FocusedRowHandle);
            BUL_CTPDV bulCtpdv = new BUL_CTPDV();
            int slTrenPdv = bulCtpdv.GetSoLuongById(Convert.ToInt32(drReview["Id"]));
            if (soluong > slTrenPdv)
            {
                MessageBox.Show(Resources.SuaPhieuGiaCong_SoLuongNhapGCToiDa
                    + Resources.SuaPhieuGiaCong_SLToiDaCoTheNhap + slTrenPdv, Resources.TitleMessageBox_Error,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            BUL_CTPGC bulCtpgc = new BUL_CTPGC();
            CTPGC ctpgc = new CTPGC();
            ctpgc.Id = Convert.ToInt32(drReview["Id"]);
            ctpgc.SoPhieuGC = _soPGC;
            ctpgc.TrongLuong = 0.1;
            ctpgc.SoLuong = Convert.ToInt32(soluong);
            ctpgc.TienCong = Convert.ToInt32(textEditTienCong.Text);
            ctpgc.ThanhTien = Convert.ToDecimal(textEditTongTien.Text);
            bulCtpgc.UpdateCTPGC(ctpgc);
            MessageBox.Show(Resources.SuaPhieuGiaCong_SuaCTPGCThanhCong, Resources.TitleMessageBox_ThongBao, MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadCtpgc_review();
            LoadCtpdvCanGiaCong();
        }

        private void gridViewCTPGC_review_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            DataRow currentRow = gridViewCTPGC_review.GetDataRow(gridViewCTPGC_review.FocusedRowHandle);
            if (currentRow != null)
            {
                textEditTenLoaiSP.Text = currentRow["TenLoaiSP"].ToString();
                textEditHTGC.Text = currentRow["HTGC"].ToString();
                textEditSoLuong.Text = currentRow["SoLuong"].ToString();
                textEditTienCong.Text = currentRow["TienCong"].ToString();
                textEditSoLuong.Text = currentRow["SoLuong"].ToString();
            }
        }


    }
}