using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel;
using DTO;
using DAL;
namespace BUL
{
    public class BUL_PhieuThuTienNo
    {
        private DAL_PhieuThuTienNo dalDeptReceipt;

        public BUL_PhieuThuTienNo()
        {
            this.dalDeptReceipt = new DAL_PhieuThuTienNo();
        }

        /// <summary>
        /// save new PHIEUTHUTIENNO into database. 
        /// Throw NullArgumentException if the newDeptReceipt is null
        /// </summary>
        /// <param name="newDeptReceipt"> the PHIEUTHUTIENNO to be saved</param>
        public void add(PHIEUTHUTIENNO newDeptReceipt)
        {
            this.dalDeptReceipt.add(newDeptReceipt);
        }


        /// <summary>
        /// Find all dept receipt of frequenter with payment date
        /// </summary>
        /// <param name="criteriaDate"> criteria date to filter</param>
        /// <returns> List of satisfied results in BindingList</returns>
        public BindingList<PHIEUTHUTIENNO> findDeptReceiptByPaymentDate(DateTime criteriaDate)
        {
            return this.dalDeptReceipt.findDeptReceiptByPaymentDate(criteriaDate);
        }
    }
}
