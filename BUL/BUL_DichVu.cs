using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BUL
{
    public class BUL_DichVu
    {
        private DAL_DichVu dalDichVu;

        public BUL_DichVu()
        {
            dalDichVu = new DAL_DichVu();
        }
        public void AddNewDichVu(DICHVU dichvu)
        {
            dalDichVu.AddNewDichVu(dichvu);
        }

        public List<DICHVU> GetAllDichvus()
        {
            return dalDichVu.GetAllDichvus();
        }

        public DICHVU GetDichvuById(int id)
        {
            return dalDichVu.GetDichvuById(id);
        }

        public void UpdateDichVu(DICHVU updateDichvu)
        {
            dalDichVu.UpdateDichVu(updateDichvu);
        }

        public void DeleteDichVu(int id)
        {
            dalDichVu.DeleteDichVu(id);
        }
    }
}
