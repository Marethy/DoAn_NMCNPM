using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUL
{
    public class BUL_CTPM
    {
        private DAL.DAL_CTPM _dalBuyDetail;
        public BUL_CTPM()
        {
            _dalBuyDetail = new DAL.DAL_CTPM();
        }
        public void addNewBuyDetail(DTO.CTPMH buydetail)
        {
            _dalBuyDetail.addNewBuyDetail(buydetail);
        }
        public void deleteBuyDetail(int billid, int serial)
        {
            _dalBuyDetail.deleteBuyDetail(billid, serial);
        }
        public List<DTO.CTPMH> getAllBuyDetails()
        {
            return _dalBuyDetail.getAllBuyDetails();
        }
        public List<DTO.CTPMH> getBuyDetailsByBillId(int billid)
        {
            return _dalBuyDetail.getBuyDetailsByBillId(billid);
        }
        public DTO.CTPMH getBuyDetailByBillIdAndSerial(int billid, int serial)
        {
            return _dalBuyDetail.getBuyDetailByBillIdAndSerial(billid, serial);
        }
        public DTO.CTPMH updateBuyDetail(DTO.CTPMH buydetail)
        {
            return _dalBuyDetail.updateBuyDetail(buydetail);
        }

    }
}
