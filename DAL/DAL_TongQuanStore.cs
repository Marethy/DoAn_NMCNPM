using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Globalization;

namespace DAL
{
    public class DAL_TongQuanStore
    {
        
        
        DTO.DBQLCuaHangVangBacDaQuyEntities _context;
        public DAL_TongQuanStore()
        {
            _context = new DTO.DBQLCuaHangVangBacDaQuyEntities();
        }
        public decimal calculateIncomeInDate(DateTime t)
        {
            string date = t.Date.ToString("dd-MM-yyyy");
            //decimal? x = _context.CalculateRevenueInDate(DateTime.Parse(date)).Single();
            decimal? x = _context.CalculateRevenueInDate(DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture)).Single();
            if (x == null)
                return 0;
            else
                return x.Value;
            //return _context.CalculateIncomeInDate(t.Date).Single();
        }
        public decimal calculateCostInDate(DateTime t)
        {

            string date = t.Date.ToString("dd-MM-yyyy");
            //decimal? x = _context.CalculateFeeInDate(DateTime.Parse(date)).Single();
            decimal? x = _context.CalculateFeeInDate(DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture)).Single();
            if (x == null)
                return 0;
            else
                return x.Value;
            //return _context.CalculateCostInDate(t.Date).Single().Value;
        }
        public DTO.CalculateNumberOfIncomeBill_Result calculateNumberOfIncomeBill(DateTime t)
        {
            string date = t.Date.ToString("dd-MM-yyyy");
            return _context.CalculateNumberOfIncomeBill(DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture)).Single();
        }
        public DTO.CalculateNumberOfCostBill_Result calculateNumberOfCostBill(DateTime t)
        {
            string date = t.Date.ToString("dd-MM-yyyy");
            return _context.CalculateNumberOfCostBill(DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture)).Single();
        }
        public DTO.CalculateStoreStatus_Result calculateStoreStatus()
        {
            return _context.CalculateStoreStatus().Single();
        }

        public CalculateNumberOfPartner_Result CalculateNumberOfPartner()
        {
            return _context.CalculateNumberOfPartner().Single();
        }

    }
}
