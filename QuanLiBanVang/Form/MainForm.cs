using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QuanLiBanVang.Form;
using QuanLiBanVang.Model;

namespace QuanLiBanVang
{
    public partial class MainForm : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public MainForm()
        {
            InitializeComponent();
        }
        [System.STAThread]
        public static void ThreadProcess()
        {
            Application.Run(new MainForm());
        }
  
        private void InitInventoryReport()
        {

            BUL.BUL_BaoCaoTonKho bulReport = new BUL.BUL_BaoCaoTonKho();
            if (!bulReport.isReportExisted(DateTime.Now.Date))
            {
                BUL.BUL_SanPham bulProduct = new BUL.BUL_SanPham();
                List<DTO.SANPHAM> listproduct = bulProduct.getAllProduct();
                foreach (DTO.SANPHAM i in listproduct)
                {
                    DTO.BAOCAOTONKHO report = new DTO.BAOCAOTONKHO();
                    report.NgayBC = DateTime.Now.Date;
                    report.MaSP = i.MaSP;
                    report.TonDau = i.SoLuongTon;
                    report.TonCuoi = i.SoLuongTon;
                    bulReport.addNewInventoryReport(report);
                }
            }
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            this.Hide();
            Report.Login_Form login_frm = new Report.Login_Form();
            DialogResult result = login_frm.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                this.Show();
                InitInventoryReport();
                SetAccessControl();
                TongQuan tongQuan_frm = new TongQuan();
                OpenChildForm(tongQuan_frm);
            }
            else
                this.Close();
        }
        //Open from or focus if opened
        public void OpenChildForm(XtraForm form)
        {
            //Check before open
            if (!IsFormOpened(form))
            {
                form.MdiParent = this;
                form.Show();
            }
        }
        //Check if a form is opened already      
        private bool IsFormOpened(XtraForm form)
        {
            bool isOpened = false;
            //If there is more than one form opened
            if (MdiChildren.Count() > 0)
            {
                foreach (var item in MdiChildren)
                {
                    if (form.Name == item.Name)
                    {
                        //Active this form
                        xtraTabbedMdiManager1.Pages[item].MdiChild.Activate();
                        isOpened = true;
                    }
                }
            }
            return isOpened;
        }
        private void SetAccessControl(){
            int level = ExtendClass.UserAccess.Instance.GetAccessLevel;
            switch (level)
            {
                case 1:
                    {
                        this.barButtonItemQD.Enabled = false;
                        this.barButtonItemDSNV.Enabled = false;
                        this.barButtonItemThemNV.Enabled = false;
                        break;
                    }
                default: break;
            }
        }
        private void barButtonItemDSKhachHang_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DanhSachKH dsKhachHangFrom = new DanhSachKH();
            OpenChildForm(dsKhachHangFrom);
        }

        private void barButtonItemDSNhaCungCap_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DanhSachNhaCungCap_Form nhaCungCap = new DanhSachNhaCungCap_Form();
            OpenChildForm(nhaCungCap);
        }

        private void barButtonItemDSThoGiaCong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DanhSachTho dsThoForm = new DanhSachTho();
            OpenChildForm(dsThoForm);
        }

        private void barButtonItemDSPhieuDV_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DanhSachPDV danhSachPdv = new DanhSachPDV();
            OpenChildForm(danhSachPdv);
        }

        private void barButtonItemDSPhieuGC_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DanhSachPGC danhSachPgc = new DanhSachPGC();
            OpenChildForm(danhSachPgc);
        }

        private void barButtonItemThemKH_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            NhapKhachHang nhapKhachHang = new NhapKhachHang();
            OpenChildForm(nhapKhachHang);
        }

        private void barButtonItemThemTho_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            NhapTho nhapTho = new NhapTho();
            OpenChildForm(nhapTho);
        }

        private void barButtonItemThemPGC_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            NhapPhieuGiaCong_Form nhapPhieuGiaCong = new NhapPhieuGiaCong_Form();
            OpenChildForm(nhapPhieuGiaCong);
        }

        private void barButtonItemLapPhieuDV_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            NhapPhieuDichVu nhapPhieuDichVu = new NhapPhieuDichVu();
            OpenChildForm(nhapPhieuDichVu);
        }

        private void barButtonItemDSLoaiDV_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DanhSachDichVu danhSachDichVu = new DanhSachDichVu();
            OpenChildForm(danhSachDichVu);
        }

        private void barButtonItemThemLoaiDV_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            NhapDichVu nhapDichVu = new NhapDichVu();
            OpenChildForm(nhapDichVu);
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            TongQuan tongQuan_frm = new TongQuan();
            OpenChildForm(tongQuan_frm);
        }

        private void barButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Report.DanhSachLoaiSanPham_Form dsLoaiSanPham_frm = new Report.DanhSachLoaiSanPham_Form();
            OpenChildForm(dsLoaiSanPham_frm);
        }

        private void barButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Report.NhapLoaiSanPham_Form nhapLoaiSanPham_frm = new Report.NhapLoaiSanPham_Form();
            OpenChildForm(nhapLoaiSanPham_frm);
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Report.DanhSachSanPham_Form dsSanPham_frm = new Report.DanhSachSanPham_Form();
            OpenChildForm(dsSanPham_frm);
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Report.NhapSanPham_Form nhapSanPham_frm = new Report.NhapSanPham_Form();
            OpenChildForm(nhapSanPham_frm);
        }

        private void barButtonItem19_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Report.DanhSachPhieuMua_Form dsPhieuMua_frm = new Report.DanhSachPhieuMua_Form();
            OpenChildForm(dsPhieuMua_frm);
        }

        private void barButtonItem20_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Report.NhapPhieuMua_Form nhapPhieuMua_frm = new Report.NhapPhieuMua_Form();
            OpenChildForm(nhapPhieuMua_frm);
        }

        private void barButtonItem22_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Report.DanhSachPhieuChi_Form dsPhieuChi_frm = new Report.DanhSachPhieuChi_Form();
            OpenChildForm(dsPhieuChi_frm);
        }

        private void barButtonItem23_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Report.NhapPhieuChi_Form nhapPhieuchi_frm = new Report.NhapPhieuChi_Form();
            OpenChildForm(nhapPhieuchi_frm);
        }

        private void barButtonItem21_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ThayDoiQuyDinh_Form thayDoiQuyDinhForm = new ThayDoiQuyDinh_Form();
            OpenChildForm(thayDoiQuyDinhForm);
        }

        private void barButtonItem24_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Report.DanhSachNhanVien_Form dsNhanVien_frm = new Report.DanhSachNhanVien_Form();
            OpenChildForm(dsNhanVien_frm);
        }

        private void barButtonItem27_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Report.NhapNhanVien_Form nhapNhanVien_frm = new Report.NhapNhanVien_Form();
            OpenChildForm(nhapNhanVien_frm);
        }

        private void barButtonItem26_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            System.Threading.Thread thread = new System.Threading.Thread(new System.Threading.ThreadStart(ThreadProcess));
            thread.SetApartmentState(System.Threading.ApartmentState.STA);
            thread.Start();
            this.Close();
        }

        private void barButtonItem15_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Report.BaoCaoTonKho_Form baoCaoTonKho_frm = new Report.BaoCaoTonKho_Form();
            OpenChildForm(baoCaoTonKho_frm);
        }

        private void barButtonItem16_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form.BaoCaoCongNo_Form baoCaoConNo_frm = new Form.BaoCaoCongNo_Form();
            OpenChildForm(baoCaoConNo_frm);
        }

        private void barButtonItemDSPhieuBanHang_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DanhSachPhieuBanHang_Form danhSachPhieuBanHang = new DanhSachPhieuBanHang_Form();
            OpenChildForm(danhSachPhieuBanHang);
        }

        private void barButtonItemLapPBH_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            PhieuBanHang phieuBanHang = new PhieuBanHang(ActionType.ACTION_CREATE_NEW, null);
            phieuBanHang.IsFromParentForm = false;
            OpenChildForm(phieuBanHang);
        }

        private void barButtonItemDSPhieuThuTienNo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DanhSachPhieuThuNo_Form phieuThuNo = new DanhSachPhieuThuNo_Form();
            OpenChildForm(phieuThuNo);
        }

        private void barButtonItemLapPhieuTTN_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            PhieuThuTienNo_Form phieuThuTienNo = new PhieuThuTienNo_Form();
            OpenChildForm(phieuThuTienNo);
        }

        private void barButtonItemDSphieuNhapHang_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DanhSachPhieuNhapHang_Form phieuNhapHang = new DanhSachPhieuNhapHang_Form();
            OpenChildForm(phieuNhapHang);
        }

        private void barButtonItemThemPhieuNhapHang_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            PhieuNhapHang_Form phieuNhapHang = new PhieuNhapHang_Form(ActionType.ACTION_CREATE_NEW, null);
            phieuNhapHang.IsFormParentForm = false; // indicate that phieuNhapHang from is not created from parent form
            OpenChildForm(phieuNhapHang);
        }

        private void barButtonItemThemNCC_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            NhaCungCap_Form nhaCungCap = new NhaCungCap_Form(ActionType.ACTION_CREATE_NEW , null);
            nhaCungCap.IsFromParentForm = false;
            OpenChildForm(nhaCungCap);
        }




    }
}
