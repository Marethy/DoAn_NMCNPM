using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel;
using DAL;
using DTO;

namespace BUL
{
    public class BUL_PhieuNhapHang
    {
        private DAL_PhieuNhapHang dalImportReceipt;

        public BUL_PhieuNhapHang()
        {
            this.dalImportReceipt = new DAL_PhieuNhapHang();
        }

        /// <summary>
        /// get the receipt number of the last record int table
        /// </summary>
        /// <returns> the receipt number </returns>
        public int lastNumberOfReceipt()
        {
            return this.dalImportReceipt.lastNumberOfReceipt();
        }


        //<summary>
        // add new record into table PHIEUNHAPHANG
        //</summary>
        public PHIEUNHAPHANG add(PHIEUNHAPHANG newImportReceipt)
        {
            return this.dalImportReceipt.add(newImportReceipt);
        }

        /// <summary>
        /// get all PHIEUNHAPHANGs created before
        /// </summary>
        /// <returns>
        /// all PHIEUNHAPHANGs in BindingList
        /// </returns>
        public BindingList<PHIEUNHAPHANG> getAll()
        {
            return this.dalImportReceipt.getAll();
        }
    }
}
