using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using DAL;
using DTO;

namespace BUL
{
    // <summarry>
    // BUL_CTPBH class : perform database update in bussiness layer
    //</summary>
    public class BUL_CTPBH
    {
        private DAL_CTPBH dalDetails; // reference to BUL layer 
        public BUL_CTPBH()
        {
            this.dalDetails = new DAL_CTPBH();
        }

        public int count()
        {
            return this.dalDetails.count();
        }


        public void insertRange(List<CTPBH> listOfDetails)
        {
            this.dalDetails.insertRange(listOfDetails);
        }

        //<sumamry>
        // from bussiness layer
        // returns all records in table CTPBH satisfied crterion
        // if cretion is null , returns all content of table
        //</summary>
        public BindingList<CTPBH> toBindingList(PHIEUBANHANG creterion)
        {
            return this.dalDetails.toBindingList(creterion);
        }

        public void updateSoLuong(int soPhieu, int maSp, int soLuongMoi)
        {
            this.dalDetails.updateSoLuong(soPhieu, maSp, soLuongMoi);
        }

        public void delete(int soPhieu, int maSp)
        {
            this.dalDetails.delete(soPhieu, maSp);
        }

    }
}
