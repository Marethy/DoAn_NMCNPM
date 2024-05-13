using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel;
using DTO;

namespace DAL
{
    public class DAL_PhieuThuTienNo
    {
        DBQLCuaHangVangBacDaQuyEntities databaseContext;

        public DAL_PhieuThuTienNo()
        {
            this.databaseContext = new DBQLCuaHangVangBacDaQuyEntities();
        }

        /// <summary>
        /// insert new dept receipt into database
        /// </summary>
        /// <param name="newDeptReceipt"></param>
        public void add(PHIEUTHUTIENNO newDeptReceipt)
        {
            // make sure the argument is not null
            if (newDeptReceipt == null)
            {
                throw new ArgumentNullException();
            }
            this.databaseContext.PHIEUTHUTIENNOes.Add(newDeptReceipt);
            this.databaseContext.SaveChanges();
        }

        /// <summary>
        /// Find all dept receipt of frequenter with payment date
        /// </summary>
        /// <param name="criteriaDate"> criteria date to filter</param>
        /// <returns> List of satisfied results in BindingList</returns>
        public BindingList<PHIEUTHUTIENNO> findDeptReceiptByPaymentDate(DateTime criteriaDate)
        {
            return new BindingList<PHIEUTHUTIENNO>(this.databaseContext.PHIEUTHUTIENNOes.Where(x => x.NgayTra.Month == criteriaDate.Month && x.NgayTra.Year == criteriaDate.Year && x.NgayTra.Day == criteriaDate.Day).ToList());
        }
    }
}
