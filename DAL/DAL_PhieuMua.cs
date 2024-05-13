using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    
    public class DAL_PhieuMua
    {
        private DTO.DBQLCuaHangVangBacDaQuyEntities _context;
        public DAL_PhieuMua()
        {
            _context = new DTO.DBQLCuaHangVangBacDaQuyEntities();
        }
        public List<DTO.PHIEUMUAHANG> getAllBuyBill()
        {
            return _context.PHIEUMUAHANGs.ToList();
        }
        public DTO.PHIEUMUAHANG getBuyBillById(int id)
        {
            return _context.PHIEUMUAHANGs.Single(bb => bb.SoPhieuMua == id);
        }
        public void addNewBuyBill(DTO.PHIEUMUAHANG buybill)
        {
            _context.PHIEUMUAHANGs.Add(buybill);
            _context.SaveChanges();
        }
        public void deleteBuyBill(int id)
        {
            var target = _context.PHIEUMUAHANGs.Find(id);
            _context.PHIEUMUAHANGs.Remove(target);
            _context.SaveChanges();
        }
        public DTO.PHIEUMUAHANG updateBuyBill(DTO.PHIEUMUAHANG buybill)
        {
            var current = _context.PHIEUMUAHANGs.Find(buybill.SoPhieuMua);
            if (current != null)
            {
                current.MaNV = buybill.MaNV;
                current.MaKH = buybill.MaKH;
                current.NgayMua = buybill.NgayMua;
                current.TongTien = buybill.TongTien;
                _context.SaveChanges();
            }
            return buybill;
        }
        public DTO.PHIEUMUAHANG getLastBuyBill()
        {
            var max = _context.PHIEUMUAHANGs.Max(bb => bb.SoPhieuMua);
            return _context.PHIEUMUAHANGs.Single(bb => bb.SoPhieuMua == max);
        }

    }
}
