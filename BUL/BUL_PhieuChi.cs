using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUL
{
    public class BUL_PhieuChi
    {
        private DAL.DAL_PhieuChi _dalPayment;
        public BUL_PhieuChi()
        {
            _dalPayment = new DAL.DAL_PhieuChi();
        }
        public void addNewPaymentBill(DTO.PHIEUCHI paymentbill)
        {
            _dalPayment.addNewPaymentBill(paymentbill);
        }
        public List<DTO.PHIEUCHI> getAllPaymentBill()
        {
            return _dalPayment.getAllPaymentBill();
        }
        public DTO.PHIEUCHI getLastPaymentBill()
        {
            return _dalPayment.getLastPaymentBill();
        }
        public void deletePaymentBill(int id)
        {
            _dalPayment.deletePaymentBill(id);
        }
        public DTO.PHIEUCHI updatePaymentBill(DTO.PHIEUCHI updatepayment)
        {
            return _dalPayment.updatePaymentBill(updatepayment);
        }
        public DTO.PHIEUCHI getPaymentBillById(int id)
        {
            return _dalPayment.getPaymentBillById(id);
        }
    }
}
