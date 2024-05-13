using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class DAL_DichVu
    {
        private DBQLCuaHangVangBacDaQuyEntities _context;

        public DAL_DichVu()
        {
            _context = new DBQLCuaHangVangBacDaQuyEntities();
        }

        public void AddNewDichVu(DICHVU dichvu)
        {
            _context.DICHVUs.Add(dichvu);
            _context.SaveChanges();
        }

        public List<DICHVU> GetAllDichvus()
        {
            return _context.DICHVUs.ToList();
        }

        public DICHVU GetDichvuById(int id)
        {
            return _context.DICHVUs.Single(dv => dv.MaDV == id);
        }

        public void UpdateDichVu(DICHVU updateDichvu)
        {
            var currentDichvu = _context.DICHVUs.Find(updateDichvu.MaDV);
            if (currentDichvu != null)
            {
                currentDichvu.TenDV = updateDichvu.TenDV;
                currentDichvu.TienCong = updateDichvu.TienCong;
                _context.SaveChanges();
            }
        }

        public void DeleteDichVu(int id)
        {
            _context.DICHVUs.Remove(GetDichvuById(id));
            _context.SaveChanges();
        }
    }
}
