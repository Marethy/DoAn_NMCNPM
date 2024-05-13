using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_NhomNguoiDung
    {
        DTO.DBQLCuaHangVangBacDaQuyEntities _context;
        public DAL_NhomNguoiDung()
        {
            _context = new DTO.DBQLCuaHangVangBacDaQuyEntities();
        }
        public List<DTO.NHOMNGUOIDUNG> getAllGroupUser()
        {
            return _context.NHOMNGUOIDUNGs.ToList();
        }
        public DTO.NHOMNGUOIDUNG getGroupUserById(int id)
        {
            return _context.NHOMNGUOIDUNGs.Single(g => g.MaNhom == id);
        }
        public int getAccessLevelByGroupUserId(int id)
        {
            return _context.QUYENHANs.Single(per => per.NHOMNGUOIDUNGs.Any(g => g.MaNhom == id)).CapDoTruyCap;
        }
    }
}
