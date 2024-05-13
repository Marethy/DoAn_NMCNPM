using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BUL
{
    public class BUL_PhieuGiaCong
    {
        private DAL_PhieuGiaCong _dalPhieuGiaCong;

        public BUL_PhieuGiaCong()
        {
            _dalPhieuGiaCong = new DAL_PhieuGiaCong();
        }
        public int AddNewPhieuGiaCong(PHIEUGIACONG phieuGiaCong)
        {
            return _dalPhieuGiaCong.AddNewPhieuGiaCong(phieuGiaCong);
        }
        public List<PHIEUGIACONG> GetAllPhieuGiaCong()
        {
            return _dalPhieuGiaCong.GetAllPhieuGiaCong();
        }
        public PHIEUGIACONG GetPhieuGiaCongById(int id)
        {
            return _dalPhieuGiaCong.GetPhieuGiaCongById(id);
        }
        public void UpdatePhieuGiaCong(PHIEUGIACONG phieugiacong)
        {
            _dalPhieuGiaCong.UpdatePhieuGiaCong(phieugiacong);
        }
        public void DeletePhieuGiaCong(int id)
        {
            _dalPhieuGiaCong.DeletePhieuGiaCong(id);
        }
    }
}
