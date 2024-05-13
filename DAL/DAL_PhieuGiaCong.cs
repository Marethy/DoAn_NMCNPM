using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class DAL_PhieuGiaCong
    {
        private DBQLCuaHangVangBacDaQuyEntities _context;
        public DAL_PhieuGiaCong()
        {
            _context = new DBQLCuaHangVangBacDaQuyEntities();
        }
        public int AddNewPhieuGiaCong(PHIEUGIACONG phieuGiaCong)
        {
            _context.PHIEUGIACONGs.Add(phieuGiaCong);
            _context.SaveChanges();
            return phieuGiaCong.SoPhieuGC;
        }
        public List<PHIEUGIACONG> GetAllPhieuGiaCong()
        {
            return _context.PHIEUGIACONGs.ToList();
        }
        public PHIEUGIACONG GetPhieuGiaCongById(int id)
        {
            return _context.PHIEUGIACONGs.Single(pgc => pgc.SoPhieuGC == id);
        }
        public void UpdatePhieuGiaCong(PHIEUGIACONG phieugiacong)
        {
            var currentPgc = _context.PHIEUGIACONGs.Find(phieugiacong.SoPhieuGC);
            if (currentPgc != null)
            {
                currentPgc.NgayThanhToan = phieugiacong.NgayThanhToan;
                currentPgc.TongTien = phieugiacong.TongTien;
                _context.SaveChanges();
            }
        }
        public void DeletePhieuGiaCong(int id)
        {
            _context.PHIEUGIACONGs.Remove(GetPhieuGiaCongById(id));
            _context.SaveChanges();
        }
    }
}
