using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using DTO;
using System.ComponentModel;
using System.Data.Entity;
namespace DAL
{
    public class DAL_CTPNH
    {
        private DBQLCuaHangVangBacDaQuyEntities databaseContext;

        public DAL_CTPNH()
        {
            this.databaseContext = new DBQLCuaHangVangBacDaQuyEntities();
            this.databaseContext.CTPNHs.Load();

        }



        //<summary>
        // returns last number of recepti in CTPNH table
        //</summary>
        public int lastNumberOfReceipt()
        {
            var query = (from phieunhaphang in this.databaseContext.PHIEUNHAPHANGs
                         orderby phieunhaphang.SoPhieuNhap
                         select phieunhaphang.SoPhieuNhap).Single();
            return (int)query;
        }



        //<summary>
        // add a new record into table CTNPH
        //</summary>
        public void add(CTPNH newImportDetail)
        {
            this.databaseContext.CTPNHs.Add(newImportDetail);
            this.databaseContext.SaveChanges();
        }

        //<summary>
        // add new list of records into table CTNPH
        //</summary>
        public void addRange(List<CTPNH> newImportDetailList)
        {
            this.databaseContext.CTPNHs.AddRange(newImportDetailList);
            this.databaseContext.SaveChanges();
        }

        /// <summary>
        /// returns list CTPNH corresponding to specified PHIEUNHAPHANG
        /// </summary>
        /// <param name="importReceipt"></param>
        /// <returns>
        /// list CTPNH corresponding to specified PHIEUNHAPHANG, returns null if PHIEUNHAPHANG is null
        /// </returns>
        public BindingList<CTPNH> get(PHIEUNHAPHANG importReceipt)
        {
            BindingList<CTPNH> returnList; // list to be returned
            if (importReceipt == null)
            {
                returnList = this.databaseContext.CTPNHs.Local.ToBindingList();
            }
            else
            {
                var query = from import_detail in this.databaseContext.CTPNHs
                            where importReceipt.SoPhieuNhap == importReceipt.SoPhieuNhap
                            select import_detail;
                returnList = new BindingList<CTPNH>(query.ToList());
            }
            return returnList;
        }


        //public void updateSoLuong

    }
}
