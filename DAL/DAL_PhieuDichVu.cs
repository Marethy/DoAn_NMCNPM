using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class DAL_PhieuDichVu
    {
        private DBQLCuaHangVangBacDaQuyEntities _context;
        public DAL_PhieuDichVu()
        {
            _context = new DBQLCuaHangVangBacDaQuyEntities();
        }
        public int AddNewPhieuDichVu(PHIEUDICHVU phieuDichVu)
        {
            _context.PHIEUDICHVUs.Add(phieuDichVu);
            _context.SaveChanges();
            return phieuDichVu.SoPhieuDV;
        }
        public List<PHIEUDICHVU> GetAllPhieuDichVu()
        {
            return _context.PHIEUDICHVUs.ToList();
        }
        public PHIEUDICHVU GetPhieuDichVuById(int id)
        {
            return _context.PHIEUDICHVUs.Single(pdv => pdv.SoPhieuDV == id);
        }
        public void UpdatePhieuDichVu(PHIEUDICHVU phieudichvu)
        {
            var currentPdv = _context.PHIEUDICHVUs.Find(phieudichvu.SoPhieuDV);
            if(currentPdv != null)
            {
                currentPdv.NgayDangKy = phieudichvu.NgayDangKy;
                currentPdv.NgayGiao = phieudichvu.NgayGiao;
                _context.SaveChanges();
            }
        }
        public void DeletePhieuDichVu(int id)
        {
            _context.PHIEUDICHVUs.Remove(GetPhieuDichVuById(id));
            _context.SaveChanges();
        }
    }
}
