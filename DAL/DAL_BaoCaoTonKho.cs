using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_BaoCaoTonKho
    {
        DTO.DBQLCuaHangVangBacDaQuyEntities _context;
        public DAL_BaoCaoTonKho()
        {
            _context = new DTO.DBQLCuaHangVangBacDaQuyEntities();
        }
        public void addNewInventoryReport(DTO.BAOCAOTONKHO report)
        {
            _context.BAOCAOTONKHOes.Add(report);
            _context.SaveChanges();
        }
        public DTO.BAOCAOTONKHO getInventoryReportById(DateTime reportdate, int productid)
        {
            return _context.BAOCAOTONKHOes.Single(rp => rp.NgayBC == reportdate && rp.MaSP == productid);
        }
        public List<DTO.BAOCAOTONKHO> getInventoryReportByDate(DateTime reportdate)
        {
            return _context.BAOCAOTONKHOes.Where(rp => rp.NgayBC == reportdate).ToList();
        }
        public bool isReportExisted(DateTime reportdate)
        {
            return _context.BAOCAOTONKHOes.Any(rp => rp.NgayBC == reportdate);
        }
    }
}
