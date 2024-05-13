using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_PhieuChi
    {
        DTO.DBQLCuaHangVangBacDaQuyEntities _context;
        public DAL_PhieuChi()
        {
            _context = new DTO.DBQLCuaHangVangBacDaQuyEntities();
        }
        public void addNewPaymentBill(DTO.PHIEUCHI bill)
        {
            _context.PHIEUCHIs.Add(bill);
            _context.SaveChanges();
        }
        public List<DTO.PHIEUCHI> getAllPaymentBill()
        {
            return _context.PHIEUCHIs.ToList();
        }
        public DTO.PHIEUCHI getPaymentBillById(int id)
        {
            return _context.PHIEUCHIs.Single(pb => pb.SoPC == id);
        }
        public void deletePaymentBill(int id)
        {
            var target = _context.PHIEUCHIs.Find(id);
            _context.PHIEUCHIs.Remove(target);
            _context.SaveChanges();
        }
        public DTO.PHIEUCHI updatePaymentBill(DTO.PHIEUCHI updatePayment)
        {
            var current = _context.PHIEUCHIs.Find(updatePayment.SoPC);
            if (current != null)
            {
                current.SoTien = updatePayment.SoTien;
                current.MaNV = updatePayment.MaNV;
                current.NoiDungChi = current.NoiDungChi;
                current.NgayLap = updatePayment.NgayLap;
                _context.SaveChanges();
            }
            return updatePayment;
        }
        public DTO.PHIEUCHI getLastPaymentBill()
        {
            var max = _context.PHIEUCHIs.Max(pb => pb.SoPC);
            return _context.PHIEUCHIs.Single(pb => pb.SoPC == max);
        }
    }
}
