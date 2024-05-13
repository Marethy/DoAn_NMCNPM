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
    public class DAL_PhieuBanHang
    {
        private DTO.DBQLCuaHangVangBacDaQuyEntities databaseContext;
        // contructor
        public DAL_PhieuBanHang()
        {
            this.databaseContext = new DTO.DBQLCuaHangVangBacDaQuyEntities();
            // load
            this.databaseContext.PHIEUBANHANGs.Load();
        }


        // return number of rows int table PHIEUBANHANG
        public int count()
        {
            var count = this.databaseContext.PHIEUBANHANGs.Count();
            return (int)count;
        }

        //<summary>
        //  Returns the fields "SoPhieu" of the last record of table PHIEUBANHANGs
        //</summary>
        public int numberOfLastRecepit()
        {
            var query = (from phieubanhang in this.databaseContext.PHIEUBANHANGs
                         orderby phieubanhang.SoPhieuBH
                         select phieubanhang.SoPhieuBH).Single();
            return (int)query;

        }

        public PHIEUBANHANG add(DTO.PHIEUBANHANG newReceipt)
        {
            // chu kt thu
            PHIEUBANHANG currentSaved = this.databaseContext.PHIEUBANHANGs.Add(newReceipt);
            this.databaseContext.SaveChanges();
            return currentSaved;

        }

        //<summary>
        // returns all records in PHIEUBANHANG table
        //</summary>
        public List<PHIEUBANHANG> getAll()
        {
            // instance a List to make sure that the mothed will not return null
            List<PHIEUBANHANG> listReceitps = new List<PHIEUBANHANG>();
            if (this.databaseContext != null)
            {
                listReceitps.AddRange(databaseContext.PHIEUBANHANGs.ToList());
            }
            return listReceitps;
        }

        //<summary>
        // returns all records converted to Bindlist in PHIEUBANHANG table , 
        // will be the data source for gridview
        //</summary>
        public BindingList<PHIEUBANHANG> toBindingList()
        {
            return this.databaseContext.PHIEUBANHANGs.Local.ToBindingList();
        }


        /// <summary>
        /// Checks that if the receipt with id has and dept receipts or not ?
        /// </summary>
        /// <param name="id">id of the receipt to be checked</param>
        /// <returns>true if the are any adept receipts of this receipt</returns>
        public bool hasDebtReceipts(int id)
        {
            return this.databaseContext.PHIEUTHUTIENNOes.Any(x => x.SoPhieuBH == id);
        }

        /// <summary>
        /// Find all receipts belongs to frequenter with specifed ID
        /// </summary>
        /// <param name="id">id of frequenter</param>
        /// <returns>list receipts in BindingList</returns>
        public BindingList<PHIEUBANHANG> findReceiptsByFrequenterId(int id)
        {

            var query = from receipts in this.databaseContext.PHIEUBANHANGs
                        where receipts.MaKH == id
                        select receipts;
            return new BindingList<PHIEUBANHANG>(query.ToList());

        }

        /// <summary>
        /// Find all dept receipts belongs to receipt with specifed ID
        /// </summary>
        /// <param name="id">id of receipts</param>
        /// <returns>list dept receipts in BindingList</returns>
        public BindingList<PHIEUTHUTIENNO> findDeptReceiptsByReceiptId(int id)
        {
            var query = from dept_receipts in this.databaseContext.PHIEUTHUTIENNOes
                        where dept_receipts.SoPhieuBH == id
                        select dept_receipts;
            return new BindingList<PHIEUTHUTIENNO>(query.ToList());
        }


        /// <summary>
        /// Find the last dept receipt of a recepit.
        /// </summary>
        /// <param name="id"> Id of the receipt</param>
        /// <returns>the last dept receipt of a recepit.</returns>
        public PHIEUTHUTIENNO findTheLastDeiptReceiptFromReceiptId(int id)
        {
            return this.databaseContext.PHIEUTHUTIENNOes.Where(x => x.SoPhieuBH == id)
                 .OrderByDescending(x => x.SoPhieuNo)
                 .FirstOrDefault();
        }
        /// <summary>
        /// Find a receipt via specified id
        /// </summary>
        /// <param name="id">The id of the receipt to be returned</param>
        /// <returns>The recepit whose id is sastified</returns>
        public PHIEUBANHANG findReceiptById(int id)
        {
            return this.databaseContext.PHIEUBANHANGs.Where(x => x.SoPhieuBH == id).FirstOrDefault();
        }

        /// <summary>
        /// Find all receipt of frequenter with payment date
        /// </summary>
        /// <param name="criteriaDate"> criteria date to filter</param>
        /// <returns> List of satisfied results in BindingList</returns>
        public BindingList<PHIEUBANHANG> findReceiptByPaymentDate(DateTime criteriaDate)
        {
            return new BindingList<PHIEUBANHANG>(this.databaseContext.PHIEUBANHANGs.Where(x => DateTime.Compare(x.NgayTra.Date, criteriaDate.Date)
                == 0 && x.MaKH != null).ToList());
        }
    }
}
