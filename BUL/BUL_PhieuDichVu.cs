using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BUL
{
    public class BUL_PhieuDichVu
    {
        private DAL_PhieuDichVu _dalPhieuDichVu;
        public BUL_PhieuDichVu()
        {
            _dalPhieuDichVu = new DAL_PhieuDichVu();
        }
        public int AddNewPhieuDichVu(PHIEUDICHVU phieuDichVu)
        {
            return _dalPhieuDichVu.AddNewPhieuDichVu(phieuDichVu);
        }
        public List<PHIEUDICHVU> GetAllPhieuDichVu()
        {
            return _dalPhieuDichVu.GetAllPhieuDichVu();
        }
        public PHIEUDICHVU GetPhieuDichVuById(int id)
        {
            return _dalPhieuDichVu.GetPhieuDichVuById(id);
        }
        public void UpdatePhieuDichVu(PHIEUDICHVU phieudichvu)
        {
            _dalPhieuDichVu.UpdatePhieuDichVu(phieudichvu);
        }
        public void DeletePhieuDichVu(int id)
        {
            _dalPhieuDichVu.DeletePhieuDichVu(id);
        }
    }
}
