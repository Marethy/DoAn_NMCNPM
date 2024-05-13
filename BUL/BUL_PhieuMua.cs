using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUL
{
    public class BUL_PhieuMua
    {
        DAL.DAL_PhieuMua _dalBuyBill;
        public BUL_PhieuMua()
        {
            _dalBuyBill = new DAL.DAL_PhieuMua();
        }
        public void addNewBuyBill(DTO.PHIEUMUAHANG buybill)
        {
            _dalBuyBill.addNewBuyBill(buybill);
        }
        public void deleteBuyBill(int id)
        {
            try
            {
                _dalBuyBill.deleteBuyBill(id);
            }
            catch (Exception e)
            {
                _dalBuyBill = null;
                _dalBuyBill = new DAL.DAL_PhieuMua();
            }
        }
        public List<DTO.PHIEUMUAHANG> getAllBuyBill()
        {
            return _dalBuyBill.getAllBuyBill();
        }
        public DTO.PHIEUMUAHANG getBuyBillById(int id)
        {
            return _dalBuyBill.getBuyBillById(id);
        }
        public DTO.PHIEUMUAHANG updateBuyBill(DTO.PHIEUMUAHANG buybill)
        {
            return _dalBuyBill.updateBuyBill(buybill);
        }
        public DTO.PHIEUMUAHANG getLastBuyBill()
        {
            return _dalBuyBill.getLastBuyBill();
        }
    }
}
