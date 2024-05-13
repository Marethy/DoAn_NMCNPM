using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class DAL_CTPGC
    {
        private DBQLCuaHangVangBacDaQuyEntities _context;
        public DAL_CTPGC()
        {
            _context = new DBQLCuaHangVangBacDaQuyEntities();
        }
        public void AddNewCTPGC(CTPGC ctpgc)
        {
            _context.CTPGCs.Add(ctpgc);
            _context.SaveChanges();
        }
        public List<CTPGC> GetAllCTPGC(){
            return _context.CTPGCs.ToList();
        }
        public List<CTPGC> GetAllCTPGCByIdCTPDV(int id)
        {
            var query = from ctpgc in _context.CTPGCs
                        where ctpgc.Id == id
                        select ctpgc;
            return query.ToList();
        }
        public List<CTPGC> GetAllCTPGCBySoPhieuGC(int sophieugc)
        {
            var query = from ctpgc in _context.CTPGCs
                        where ctpgc.SoPhieuGC == sophieugc
                        select ctpgc;
            return query.ToList();
        }
        public void UpdateCTPGC(CTPGC ctpgc)
        {
            var current = _context.CTPGCs.Find(ctpgc.SoPhieuGC,ctpgc.Id);
            if(current != null)
            {
                current.SoLuong = ctpgc.SoLuong;
                current.TienCong = ctpgc.TienCong;
                current.ThanhTien = ctpgc.ThanhTien;
                _context.SaveChanges();
            }
        }
        public void DeleteCTPGC(int sophieugc, int id)
        {
            _context.CTPGCs.Remove(_context.CTPGCs.Find(sophieugc,id));
            _context.SaveChanges();
        }

        public int GetSoluongByIdPDV(int id)
        {
            int sl = 0;
            if(_context.CTPGCs.Any(ct => ct.Id == id))
                sl = _context.CTPGCs.Where(ct => ct.Id == id).Sum(item => item.SoLuong);
            return sl;
        }
    }
}
