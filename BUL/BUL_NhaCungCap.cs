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
    public class BUL_NhaCungCap
    {
        private DAL_NhaCungCap dalProvider;

        public BUL_NhaCungCap()
        {
            this.dalProvider = new DAL_NhaCungCap();
        }

        /// <summary>
        ///  get all records from NHACUNGCAP table
        /// </summary>
        /// <returns>
        /// all records in BindingList
        /// </returns>
        public BindingList<NHACUNGCAP> getAll()
        {
            return this.dalProvider.getAll();
        }

        /// <summary>
        /// add new provider into database
        /// </summary>
        /// <param name="newProvider"></param>
        public void add(NHACUNGCAP newProvider)
        {
            this.dalProvider.add(newProvider);
        }

        /// <summary>
        /// Updates existing provider
        /// </summary>
        /// <param name="id"> id of provider to be updated</param>
        /// <param name="newInformation">new information for the updating provider</param>
        public void updateProvider(int id, NHACUNGCAP newInformation)
        {
            this.dalProvider.updateProvider(id, newInformation);
        }

        /// <summary>
        /// Delete a provider from database
        /// </summary>
        /// <param name="id"> identifer of the provider to be deleted</param>
        public void deleteProvider(int id)
        {
            this.dalProvider.deleteProvider(id);
        }

    }
}
