using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel;
using System.Data.Entity;
using DTO;

namespace DAL
{
    // Summary:
    // all operations for table NHACUNGCAP
    // 
    //
    //
    public class DAL_NhaCungCap
    {
        private DBQLCuaHangVangBacDaQuyEntities databaseContext = new DBQLCuaHangVangBacDaQuyEntities();

        public DAL_NhaCungCap()
        {
            this.databaseContext = new DBQLCuaHangVangBacDaQuyEntities();
        }

        // <summary>
        // returns all records in the NHACUNGCAP table
        //</summary>
        public BindingList<NHACUNGCAP> getAll()
        {
            this.databaseContext.NHACUNGCAPs.Load();
            return this.databaseContext.NHACUNGCAPs.Local.ToBindingList();
        }

        /// <summary>
        /// add new provider into database
        /// </summary>
        /// <param name="newProvider">the new provider to be saved</param>
        public void add(NHACUNGCAP newProvider)
        {
            this.databaseContext.NHACUNGCAPs.Add(newProvider);
            this.databaseContext.SaveChanges();
        }

        /// <summary>
        /// Updates existing provider
        /// </summary>
        /// <param name="id"> id of provider to be updated</param>
        /// <param name="newInformation">new information for the updating provider</param>
        public void updateProvider(int id, NHACUNGCAP newInformation)
        {
            var provider = this.databaseContext.NHACUNGCAPs.Find(id);
            if (provider != null)
            {
                provider.TenNCC = newInformation.TenNCC;
                provider.DiaChi = newInformation.DiaChi;
                provider.SDT = newInformation.SDT;
                this.databaseContext.SaveChanges();
            }
        }

        /// <summary>
        /// Delete a provider from database
        /// </summary>
        /// <param name="id"> identifer of the provider to be deleted</param>
        public void deleteProvider(int id)
        {
            try
            {
                var provider = this.databaseContext.NHACUNGCAPs.Find(id);
                if (provider != null)
                {
                    this.databaseContext.NHACUNGCAPs.Remove(provider);
                    this.databaseContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e.Message + e.InnerException);
            }
        }
    }
}
