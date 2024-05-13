using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;

namespace BUL
{
    public class BUL_CTPDV
    {
        private DAL_CTPDV _dalCTPDV;
        public BUL_CTPDV()
        {
            _dalCTPDV = new DAL_CTPDV();
        }
        public int AddNewCTPDV(CTPDV ctpdv)
        {
            return _dalCTPDV.AddNewCTPDV(ctpdv);
        }
        public List<CTPDV> GetAllCTPDV()
        {
            return _dalCTPDV.GetAllCTPDV();
        }
        public CTPDV GetCTPDVById(int id)
        {
            return _dalCTPDV.GetCTPDVById(id);
        }
        public List<CTPDV> GetAllCTPDVBySoPhieuDV(int sophieudv)
        {
            return _dalCTPDV.GetAllCTPDVBySoPhieuDV(sophieudv);
        }
        public void UpdateCTPDV(CTPDV ctpdv)
        {
            _dalCTPDV.UpdateCTPDV(ctpdv);
        }
        public void DeleteCTPDVById(int id)
        {
            _dalCTPDV.DeleteCTPDVById(id);
        }
        public List<CTPDV> GetCTPDVGiaCong()
        {
            return _dalCTPDV.GetCTPDVGiaCong();
        }
        public int GetSoLuongById(int id)
        {
            return _dalCTPDV.GetSoLuongById(id);
        }
    }
}
