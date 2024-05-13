using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Data.Entity;
using DAL;
using DTO;

namespace BUL
{
    public class BUL_CTPNH
    {
        private DAL_CTPNH dalImportDetail;

        public BUL_CTPNH()
        {
            this.dalImportDetail = new DAL_CTPNH();

        }

        //<summary>
        // add a new record into table CTNPH
        //</summary>
        public void add(CTPNH importDetail)
        {
            this.dalImportDetail.add(importDetail);
        }

        /// <summary>
        /// add new list of records into table CTNPH
        /// </summary>
        /// <param name="listOfImportDetail"> list to be added</param>
        public void addRange(List<CTPNH> listOfImportDetail)
        {
            this.dalImportDetail.addRange(listOfImportDetail);
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
            return this.dalImportDetail.get(importReceipt);
        }
    }
}
