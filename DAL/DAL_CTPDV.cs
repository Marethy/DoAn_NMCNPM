using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class DAL_CTPDV
    {
        private DBQLCuaHangVangBacDaQuyEntities _context;
        public DAL_CTPDV()
        {
            _context = new DBQLCuaHangVangBacDaQuyEntities();
        }
        public int AddNewCTPDV(CTPDV ctpdv)
        {
            _context.CTPDVs.Add(ctpdv);
            _context.SaveChanges();
            return ctpdv.Id;
        }
        public List<CTPDV> GetAllCTPDV()
        {
            return _context.CTPDVs.ToList();
        }
        public CTPDV GetCTPDVById(int id)
        {
            return _context.CTPDVs.Single(ctpdv => ctpdv.Id == id);
        }
        public List<CTPDV> GetAllCTPDVBySoPhieuDV(int sophieudv)
        {
            var query = from ctpdv in _context.CTPDVs
                        where ctpdv.SoPhieuDV == sophieudv
                        select ctpdv;
            return query.ToList();
        }
        public void UpdateCTPDV(CTPDV ctpdv)
        {
            var current = _context.CTPDVs.Find(ctpdv.Id);
            if(current != null)
            {
                current.MaLoaiSP = ctpdv.MaLoaiSP;
                current.MaDV = ctpdv.MaDV;
                current.SoLuong = ctpdv.SoLuong;
                current.TienCong = ctpdv.TienCong;
                current.ThanhTien = ctpdv.ThanhTien;
                _context.SaveChanges();
            }
        }
        public void DeleteCTPDVById(int id)
        {
            _context.CTPDVs.Remove(GetCTPDVById(id));
            _context.SaveChanges();
        }

        public List<CTPDV> GetCTPDVGiaCong()
        {
            var query = from ctpdv in _context.CTPDVs
                        where ctpdv.MaDV == 2
                        && (!_context.CTPGCs.Any(ct => ct.Id == ctpdv.Id)
                        || (_context.CTPGCs.Any(ct => ct.Id == ctpdv.Id) && ctpdv.SoLuong > (_context.CTPGCs.Where(ct => ct.Id == ctpdv.Id).Sum(item => item.SoLuong))))
                        select ctpdv;
            return query.ToList();
        }

        public int GetSoLuongById(int id)
        {
            return _context.CTPDVs.Single(ctpdv => ctpdv.Id == id).SoLuong;
        }
    }
}
