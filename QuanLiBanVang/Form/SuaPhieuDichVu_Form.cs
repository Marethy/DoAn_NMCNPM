using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Core;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Windows.Forms;
using DevExpress.XtraEditors.Controls;
using QuanLiBanVang.ExtendClass;
using BUL;
using DTO;
using QuanLiBanVang.Properties;

namespace QuanLiBanVang
{
    public partial class SuaPhieuDichVu : DevExpress.XtraEditors.XtraForm
    {
        private BUL_PhieuDichVu _bulPhieuDichVu;
        private BUL_CTPDV _bulCtpdv;
        private PHIEUDICHVU _pdv;
        private List<KHACHHANG> _listKh;
        private List<DICHVU> _listDichVu;
        private List<LOAISANPHAM> _listLoaiSp;
        private ComboBoxItemCollection _comboboxItemsKh;
        private DataColumn _keyFeild;
        private DataTable _dataTable;
        private MyCache _cache = new MyCache("IDcache");
        private int _soPDV;
        private bool _isResultOk;
        public SuaPhieuDichVu(int soPdv)
        {
            InitializeComponent();
            _soPDV = soPdv;
            _isResultOk = false;
            _bulPhieuDichVu = new BUL_PhieuDichVu();
            _bulCtpdv = new BUL_CTPDV();
        }
        private void PhieuDichVu_Load(object sender, EventArgs e)
        {
            _comboboxItemsKh = comboBoxEditTenKhach.Properties.Items;
            checkEditKhachQuen.ReadOnly = true;
            AddDichVuToComboBoxEdit();
            AddLoaiSpToComboBoxEdit();
            CreateDataTable();
            LoadInfoPdv();        
        }
        private void LoadInfoPdv()
        {
            _pdv = _bulPhieuDichVu.GetPhieuDichVuById(_soPDV);
            LoadEmployeeName(_pdv.MaNV);
            dateEditNgayDK.DateTime = _pdv.NgayDangKy;
            dateEditNgayDK.ReadOnly = true;
            dateEditNgayGiao.DateTime = _pdv.NgayGiao;
            checkEditKhachQuen.ReadOnly = true;
            comboBoxEditTenKhach.ReadOnly = true;
            textEditDiaChi.ReadOnly = true;
            AddKhachHangToComboEdit();
            int makh = _pdv.MaKH ?? 0;
            if (makh == 0)
            {
                checkEditKhachQuen.Checked = false;
                comboBoxEditTenKhach.Text = Resources.KhachVangLai;
            }
            else
            {
                KHACHHANG kh = _listKh.Find(i => i.MaKH == makh);
                checkEditKhachQuen.Checked = true;
                comboBoxEditTenKhach.SelectedIndex = _listKh.IndexOf(kh);
                textEditDiaChi.Text = kh.DiaChi;
            }
            LoadInfoCtpdv();
        }
        private void LoadInfoCtpdv()
        {
            List<CTPDV> listCtpdv = _bulCtpdv.GetAllCTPDVBySoPhieuDV(_soPDV);
            _dataTable.Rows.Clear();
            foreach (var item in listCtpdv)
            {
                _dataTable.Rows.Add(new object[] { 
                null, 
                item.Id, 
                item.SoPhieuDV, 
                /*MaLoaiSP*/item.MaLoaiSP == null?-1:item.MaLoaiSP, 
                /*TenLoaiSP*/item.MaLoaiSP == null?"Khác":_listLoaiSp.Find(i => i.MaLoaiSP == item.MaLoaiSP).TenLoaiSP, 
                /*MaDV*/item.MaDV,
                /*TenDV*/_listDichVu.Find(i => i.MaDV == item.MaDV).TenDV,
                /*Soluong*/item.SoLuong,
                /*TienCong*/item.TienCong,
                /*ThanhTien*/item.ThanhTien,
                /*GhiChu*/item.GhiChu == null ? "" : item.GhiChu.Trim()
                });
            }
            gridControlCTPDV.DataSource = _dataTable;
            CalculateTongTien();
        }
        private void LoadEmployeeName(int maNv)
        {
            BUL_NhanVien bulNhanVien = new BUL_NhanVien();
            NHANVIEN nv = bulNhanVien.getStaffById(maNv);
            textEditTenNhanVien.Text = nv.HoTen;
        }
        private void AddDichVuToComboBoxEdit()
        {
            BUL_DichVu bulDichVu = new BUL_DichVu();
            ComboBoxItemCollection comboboxItemsLoaiDv = comboBoxEditTenDV.Properties.Items;
            _listDichVu = bulDichVu.GetAllDichvus();
            comboboxItemsLoaiDv.BeginUpdate();
            try
            {
                foreach (var item in _listDichVu)
                {
                    ContainerItem dv = new ContainerItem
                    {
                        Text = item.TenDV,
                        Value = item
                    };
                    comboboxItemsLoaiDv.Add(dv);
                }
            }
            finally
            {
                comboboxItemsLoaiDv.EndUpdate();
            }
        }
        private void AddLoaiSpToComboBoxEdit()
        {
            BUL_LoaiSanPham bulLoaiSp = new BUL_LoaiSanPham();
            ComboBoxItemCollection comboboxItemsLoaiSp = comboBoxEditLoaiSP.Properties.Items;
            _listLoaiSp = bulLoaiSp.getAllProductType();
            comboboxItemsLoaiSp.BeginUpdate();
            try
            {
                ContainerItem spNull = new ContainerItem
                {
                    Text = "Khác",
                    Value = null
                };
                comboboxItemsLoaiSp.Add(spNull);

                foreach (LOAISANPHAM item in _listLoaiSp)
                {
                    ContainerItem sp = new ContainerItem
                    {
                        Text = item.TenLoaiSP,
                        Value = item
                    };
                    comboboxItemsLoaiSp.Add(sp);
                }
            }
            finally
            {
                comboboxItemsLoaiSp.EndUpdate();
            }
        }
        private void AddKhachHangToComboEdit()
        {
            ClearAllItemInComboboxKh();
            if(_listKh == null)
            {
                BUL_KhachHang bulKhachHang = new BUL_KhachHang();
                _listKh = bulKhachHang.GetAllKhachhangs();
            }
            _comboboxItemsKh.BeginUpdate();
            try
            {
                foreach (var item in _listKh)
                {
                    ContainerItem kh = new ContainerItem
                    {
                        Text = item.TenKH,
                        Value = item
                    };
                    _comboboxItemsKh.Add(kh);
                }
            }
            finally
            {
                _comboboxItemsKh.EndUpdate();
            }
        }
        private void ClearAllItemInComboboxKh()
        {
            while (_comboboxItemsKh.Count != 0)
            {
                _comboboxItemsKh.RemoveAt(0);
            }
            comboBoxEditTenKhach.SelectedIndex = -1;
        }
        private void checkEditKhachQuen_CheckedChanged(object sender, EventArgs e)
        {
            //if (checkEditKhachQuen.Checked){
            //    comboBoxEditTenKhach.Properties.TextEditStyle = TextEditStyles.DisableTextEditor;
            //    AddKhachHangToComboEdit();
            //    comboBoxEditTenKhach.SelectedIndex = -1;
            //}
            //else
            //{
            //    comboBoxEditTenKhach.Properties.TextEditStyle = TextEditStyles.Standard;
            //    ClearAllItemInComboboxKh();           
            //}
        }
        private void gridViewCT_PDV_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            if (e.IsGetData)
                e.Value = _cache.getValue(e.Row);
            if (e.IsSetData)
                _cache.setValue(e.Row, e.Value);
        }
        private void CreateDataTable()
        {
            _dataTable = new DataTable();
            _keyFeild = _dataTable.Columns.Add("IDcache", typeof(int));
            _keyFeild.ReadOnly = true;
            _keyFeild.AutoIncrement = true;
            _dataTable.Columns.Add("Id", typeof(int));
            _dataTable.Columns.Add("SoPhieuDV", typeof(int));
            _dataTable.Columns.Add("MaLoaiSP", typeof(int));
            _dataTable.Columns.Add("TenLoaiSP", typeof(string));
            _dataTable.Columns.Add("MaDV", typeof(int));
            _dataTable.Columns.Add("TenDV", typeof(string));
            _dataTable.Columns.Add("SoLuong", typeof(int));
            _dataTable.Columns.Add("TienCong", typeof(int));
            _dataTable.Columns.Add("ThanhTien", typeof(int));
            _dataTable.Columns.Add("GhiChu", typeof(string));
            gridControlCTPDV.DataSource = _dataTable;
            gridViewCT_PDV.Columns[0].Visible =
            gridViewCT_PDV.Columns[1].Visible =
            gridViewCT_PDV.Columns[2].Visible =
            gridViewCT_PDV.Columns[3].Visible =
            gridViewCT_PDV.Columns[5].Visible = false;
            gridViewCT_PDV.Columns[4].Caption = Resources.TenLoaiSP;
            gridViewCT_PDV.Columns[6].Caption = Resources.TenDichVu;
            gridViewCT_PDV.Columns[7].Caption = Resources.SoLuong;
            gridViewCT_PDV.Columns[8].Caption = Resources.TienCong;
            gridViewCT_PDV.Columns[9].Caption = Resources.ThanhTien;
            gridViewCT_PDV.Columns[10].Caption = Resources.GhiChu;
            gridViewCT_PDV.OptionsMenu.EnableColumnMenu = false;
        }
        private void comboBoxEditTenDV_SelectedIndexChanged(object sender, EventArgs e)
        {
            BUL_DichVu bulDichVu = new BUL_DichVu();
            DICHVU dv = ((ContainerItem) comboBoxEditTenDV.SelectedItem).Value as DICHVU;
            if (dv != null)
            {
                decimal tiencong = bulDichVu.GetDichvuById(dv.MaDV).TienCong??0;
                textEditTienCong.Text = ((int)tiencong).ToString();
                CalculateThanhTien();
                if (dv.MaDV == 2)
                {
                    textEditTienCong.ReadOnly = false;
                    textEditTienCong.Text = null;
                    textEditHTGC.ReadOnly = false;
                }
                else
                {
                    textEditTienCong.ReadOnly = true;
                    textEditHTGC.Text = string.Empty;
                    textEditHTGC.ReadOnly = true;
                }
            }           
        }
        private void textEditSoLuong_EditValueChanged(object sender, EventArgs e)
        {
            CalculateThanhTien();
        }
        private void CalculateThanhTien()
        {
            decimal tiencong = Int32.Parse(textEditTienCong.Text == "" ? "0" : textEditTienCong.Text);
            decimal soluong = Int32.Parse(textEditSoLuong.Text == "" ? "0" : textEditSoLuong.Text);
            textEditThanhTien.Text = (tiencong * soluong).ToString();
        }
        private bool CheckLogicError()
        {
            if (comboBoxEditLoaiSP.SelectedIndex == -1)
            {
                MessageBox.Show(Resources.NhapPhieuDichVu_LoaiSPEmpty, Resources.TitleMessageBox_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                comboBoxEditLoaiSP.Focus();
                return false;
            }
            if (comboBoxEditTenDV.SelectedIndex == -1)
            {
                MessageBox.Show(Resources.NhapDichVu_TenDVEmpty, Resources.TitleMessageBox_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                comboBoxEditTenDV.Focus();
                return false;
            }
            if (textEditSoLuong.Text == "" || Int32.Parse(textEditSoLuong.Text) == 0)
            {
                MessageBox.Show(Resources.NhapPhieuDichVu_SoLuongEmpty, Resources.TitleMessageBox_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                textEditSoLuong.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(textEditHTGC.Text) && comboBoxEditTenDV.Text.Equals("Gia công"))
            {
                MessageBox.Show(Resources.NhapPhieuDichVu_HTGCEmpty, Resources.TitleMessageBox_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                textEditHTGC.Focus();
                return false;
            }
            return true;
        }
        private void simpleButtonThem_Click(object sender, EventArgs e)
        {
            if (!CheckLogicError())
                return;
            LOAISANPHAM lsp = ((ContainerItem) comboBoxEditLoaiSP.SelectedItem).Value as LOAISANPHAM;
            DICHVU dv = ((ContainerItem) comboBoxEditTenDV.SelectedItem).Value as DICHVU;

            CTPDV ctpdv = new CTPDV();
            ctpdv.SoPhieuDV = _soPDV;
            if (lsp != null)
                ctpdv.MaLoaiSP = lsp.MaLoaiSP;
            if (dv != null) ctpdv.MaDV = dv.MaDV;
            ctpdv.SoLuong = Int32.Parse(textEditSoLuong.Text);
            ctpdv.TienCong = Int32.Parse(textEditTienCong.Text);
            ctpdv.ThanhTien = Convert.ToDecimal(textEditThanhTien.Text);
            ctpdv.GhiChu = textEditHTGC.Text;
            _bulCtpdv.AddNewCTPDV(ctpdv);
            //Neu ok het
            MessageBox.Show(Resources.SuaPhieuDichVu_ThemCTPDVThanhCong, Resources.TitleMessageBox_ThongBao, MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadInfoCtpdv();
            _isResultOk = true;
        }

        private void simpleButtonXoa_Click(object sender, EventArgs e)
        {
            if (_dataTable.Rows.Count == 1)
            {
                MessageBox.Show(Resources.NhapPhieuDichVu_SoPDVToiThieu, Resources.TitleMessageBox_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult dialogResult = MessageBox.Show(Resources.DetailMessageBox_XacNhanXoa,
                Resources.TitleMessageBox_ThongBao, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if(dialogResult != DialogResult.OK)
                return;
            DataRow currentRow = gridViewCT_PDV.GetDataRow(gridViewCT_PDV.FocusedRowHandle);
            if (currentRow != null)
            {
                int id = Int32.Parse(currentRow[1].ToString());
                try
                {
                    _bulCtpdv.DeleteCTPDVById(id);
                }
                catch (DbUpdateException dbUpdateException)
                {
                    SqlException eSqlException = ((SqlException)((UpdateException)dbUpdateException.InnerException).InnerException);
                    if (eSqlException.Message.Contains("FK_CTPGC_ID"))
                        MessageBox.Show(Resources.SuaPhieuDichVu_XoaCTPDVDaGiaCongError, Resources.TitleMessageBox_Error,
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                //Neu ok het
                MessageBox.Show(Resources.SuaPhieuDichVu_XoaCTPDVThanhCong, Resources.TitleMessageBox_ThongBao, MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadInfoCtpdv();
                _isResultOk = true;
            }                
        }
        private void CalculateTongTien()
        {
            decimal tongtien = 0;
            for (int i = 0; i < _dataTable.Rows.Count;i++ )
            {
                tongtien += (int)_dataTable.Rows[i][9];
            }
            textEditTongTien.Text = tongtien.ToString();
        }

        private void simpleButtonHuy_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void simpleButtonOK_Click(object sender, EventArgs e)
        {
            //Check logic condition
            if (dateEditNgayGiao.Text == "")
            {
                MessageBox.Show(Resources.NhapPhieuDichVu_NgayGiaoEmpty, Resources.TitleMessageBox_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                dateEditNgayDK.Focus();
                return;
            }
            if(dateEditNgayDK.DateTime > dateEditNgayGiao.DateTime)
            {
                MessageBox.Show(Resources.NhapPhieuDichVu_NgayGiaoTruocNgayDK, Resources.TitleMessageBox_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                dateEditNgayGiao.Focus();
                return;
            }
            if(_dataTable.Rows.Count == 0)
            {
                MessageBox.Show(Resources.NhapPhieuDichVu_SoPDVToiThieu, Resources.TitleMessageBox_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                comboBoxEditLoaiSP.Focus();
                return;
            }

            //Update PDV
            _pdv.NgayGiao = dateEditNgayGiao.DateTime;
            _pdv.TongTien = Convert.ToDecimal(textEditTongTien.Text);
            _bulPhieuDichVu.UpdatePhieuDichVu(_pdv);//Neu ok het
            MessageBox.Show(Resources.SuaPhieuDichVu_SuaPDVThanhCong, Resources.TitleMessageBox_ThongBao, MessageBoxButtons.OK, MessageBoxIcon.Information);
            _isResultOk = true;
            Close();;
        }

        private void NhapPhieuDichVu_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_isResultOk)
                DialogResult = DialogResult.OK;
            else
                DialogResult = DialogResult.Cancel;
        }

        private void simpleButtonSua_Click(object sender, EventArgs e)
        {
            DataRow currentRow = gridViewCT_PDV.GetDataRow(gridViewCT_PDV.FocusedRowHandle);
            if (currentRow != null)
            {
                int id = Int32.Parse(currentRow[1].ToString());
                if (!CheckLogicError())
                    return;
                LOAISANPHAM lsp = ((ContainerItem) comboBoxEditLoaiSP.SelectedItem).Value as LOAISANPHAM;
                DICHVU dv = ((ContainerItem) comboBoxEditTenDV.SelectedItem).Value as DICHVU;

                CTPDV ctpdv = _bulCtpdv.GetCTPDVById(id);
                if (lsp != null)
                    ctpdv.MaLoaiSP = lsp.MaLoaiSP;
                else
                    ctpdv.MaLoaiSP = null;
                if (dv != null) ctpdv.MaDV = dv.MaDV;
                ctpdv.SoLuong = Int32.Parse(textEditSoLuong.Text);
                ctpdv.TienCong = Int32.Parse(textEditTienCong.Text);
                ctpdv.ThanhTien = Int32.Parse(textEditThanhTien.Text);
                ctpdv.GhiChu = textEditHTGC.Text;
                _bulCtpdv.UpdateCTPDV(ctpdv);
                //Neu ok het
                MessageBox.Show(Resources.SuaCTPDVThanhCong, Resources.TitleMessageBox_ThongBao, MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadInfoCtpdv();
                _isResultOk = true;
            }           
        }

        private void gridViewCT_PDV_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            DataRow currentRow = gridViewCT_PDV.GetDataRow(gridViewCT_PDV.FocusedRowHandle);
            if (currentRow != null)
            {
                int malsp = Convert.ToInt32(currentRow["MaLoaiSP"]);
                if(malsp == -1)
                    comboBoxEditLoaiSP.SelectedIndex = 0;
                else
                    comboBoxEditLoaiSP.SelectedIndex = _listLoaiSp.IndexOf(_listLoaiSp.Find(sp => sp.MaLoaiSP == malsp)) +1 ;//+1 vì "Khác" ở vị trí 0
                comboBoxEditTenDV.SelectedIndex = _listDichVu.IndexOf(_listDichVu.Find(dv => dv.MaDV == Convert.ToInt32(currentRow["MaDV"])));
                textEditSoLuong.Text = currentRow["SoLuong"].ToString();
                textEditTienCong.Text = currentRow["TienCong"].ToString();
                textEditThanhTien.Text = currentRow["ThanhTien"].ToString();
                textEditHTGC.Text = currentRow["GhiChu"].ToString();
            }
        }

        private void dateEditNgayGiao_EditValueChanged(object sender, EventArgs e)
        {
            //if (dateEditNgayGiao.DateTime != _pdv.NgayGiao)
            //    simpleButtonOK.Enabled = true;
            //else
            //    simpleButtonOK.Enabled = false;
        }

        private void textEditTienCong_EditValueChanged(object sender, EventArgs e)
        {
            CalculateThanhTien();
        } 
    }
}