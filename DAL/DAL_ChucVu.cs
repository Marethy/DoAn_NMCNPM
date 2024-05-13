using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_ChucVu
    {
        DTO.DBQLCuaHangVangBacDaQuyEntities _context;
        public DAL_ChucVu()
        {
            _context = new DTO.DBQLCuaHangVangBacDaQuyEntities();
        }
        public List<DTO.CHUCVU> getListPosition()
        {
            var query = from pos in _context.CHUCVUs
                        select pos;
            return query.ToList();
        }
        public DTO.CHUCVU getPositionById(int id)
        {
            
            return _context.CHUCVUs.Single(pos => pos.MaCV == id);
        }
        
    }
}
