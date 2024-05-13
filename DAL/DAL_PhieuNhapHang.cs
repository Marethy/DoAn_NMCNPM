using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using DTO;
using System.Data.Entity;
using System.ComponentModel;

namespace DAL
{
    public class DAL_PhieuNhapHang
    {
        private DBQLCuaHangVangBacDaQuyEntities databaseContext;

        public DAL_PhieuNhapHang()
        {
            this.databaseContext = new DBQLCuaHangVangBacDaQuyEntities();
        }


        /// <summary>
        ///   
        ///  get receipt number of last record in table
        /// </summary>
        /// <returns>
        ///  receipt number of last records. 
        ///  -1 if the table is current empty
        /// </returns>
        public int lastNumberOfReceipt()
        {
            if (this.databaseContext.PHIEUNHAPHANGs.Count() == 0) { return -1; }
            var query = (from phieunhaphang in this.databaseContext.PHIEUNHAPHANGs
                         orderby phieunhaphang.SoPhieuNhap
                         select phieunhaphang.SoPhieuNhap).Single();
            return (int)query;
        }


        /// <summary>
        ///  add new record into table PHIEUNHAPHANG
        /// </summary>
        /// <param name="newImportReceipt"> record to be saved</param>
        /// <returns> PHIEUBANHANG has been saved</returns>
        public PHIEUNHAPHANG add(PHIEUNHAPHANG newImportReceipt)
        {
            // this.databaseContext.PHIEUNHAPHANGs.Load();
            PHIEUNHAPHANG currentSaved = this.databaseContext.PHIEUNHAPHANGs.Add(newImportReceipt);
            this.databaseContext.SaveChanges();
            return currentSaved;
        }

        /// <summary>
        /// get all record in table PHIEUNHAPHANG into binging list
        /// </summary>
        /// <returns>
        /// the Binding List of all records in table PHIEUNHAPHANG
        /// </returns>
        public BindingList<PHIEUNHAPHANG> getAll()
        {
            this.databaseContext.PHIEUNHAPHANGs.Load();
            return this.databaseContext.PHIEUNHAPHANGs.Local.ToBindingList();
        }





    }
}
