using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_CTPM
    {
        private DTO.DBQLCuaHangVangBacDaQuyEntities _context;
        public DAL_CTPM()
        {
            _context = new DTO.DBQLCuaHangVangBacDaQuyEntities();
        }
        public List<DTO.CTPMH> getAllBuyDetails()
        {
            return _context.CTPMHs.ToList();
        }
        public List<DTO.CTPMH> getBuyDetailsByBillId(int id)
        {
            var query = from dt in _context.CTPMHs
                        where dt.SoPhieuMua == id
                        select dt;
            return query.ToList();
        }
        public DTO.CTPMH getBuyDetailByBillIdAndSerial(int id, int serial)
        {
            return _context.CTPMHs.Single(dt => dt.SoPhieuMua == id && dt.STT == serial);
        }
        public void addNewBuyDetail(DTO.CTPMH detail)
        {
            _context.CTPMHs.Add(detail);
            _context.SaveChanges();
        }
        public void deleteBuyDetail(int billid, int serial)
        {
            var target = _context.CTPMHs.Find(new object[] { billid, serial });
            _context.CTPMHs.Remove(target);
            _context.SaveChanges();
        }
        public DTO.CTPMH updateBuyDetail(DTO.CTPMH buydetail)
        {
            var current = _context.CTPMHs.Find(new object[] { buydetail.SoPhieuMua, buydetail.STT });
            if (current != null)
            {
                current.MaSP = buydetail.MaSP;
                current.MaLoaiSP = buydetail.MaLoaiSP;
                current.SoLuong = buydetail.SoLuong;
                current.Thanhtien = buydetail.Thanhtien;
            }
            return buydetail;
        }
    }
}
