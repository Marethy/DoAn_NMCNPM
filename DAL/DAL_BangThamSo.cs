using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_BangThamSo
    {
        DTO.DBQLCuaHangVangBacDaQuyEntities _context;
        public DAL_BangThamSo()
        {
            _context = new DTO.DBQLCuaHangVangBacDaQuyEntities();
        }
        public void UpdateAgurmentValue(string agurment,double value)
        {
            var current = _context.BANGTHAMSOes.Find(agurment);
            if (current != null)
            {

                current.GiaTri = value;
                _context.SaveChanges();
                
            }
        }
        public List<DTO.BANGTHAMSO> getAllAgurment()
        {
            return _context.BANGTHAMSOes.ToList();
        }

        public double getValueByArgument(string argument)
        {
            return _context.BANGTHAMSOes.Find(argument).GiaTri;
        }
    }
}
