using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BUL
{
    public class BUL_CTPGC
    {
        private DAL_CTPGC _dalCtpgc;

        public BUL_CTPGC()
        {
            _dalCtpgc = new DAL_CTPGC();
        }
        public void AddNewCTPGC(CTPGC ctpgc)
        {
            _dalCtpgc.AddNewCTPGC(ctpgc);
        }
        public List<CTPGC> GetAllCTPGC()
        {
            return _dalCtpgc.GetAllCTPGC();
        }
        public List<CTPGC> GetAllCTPGCByIdCTPDV(int id)
        {
            return _dalCtpgc.GetAllCTPGCByIdCTPDV(id);
        }
        public List<CTPGC> GetAllCTPGCBySoPhieuGC(int sophieugc)
        {
            return _dalCtpgc.GetAllCTPGCBySoPhieuGC(sophieugc);
        }
        public void UpdateCTPGC(CTPGC ctpgc)
        {
            _dalCtpgc.UpdateCTPGC(ctpgc);
        }
        public void DeleteCTPGC(int sophieugc, int id)
        {
            _dalCtpgc.DeleteCTPGC(sophieugc,id);
        }
        public int GetSoluongByIdPDV(int id)
        {
            return _dalCtpgc.GetSoluongByIdPDV(id);
        }
    }
}
