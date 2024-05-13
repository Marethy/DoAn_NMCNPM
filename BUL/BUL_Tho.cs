using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BUL
{
    public class BUL_Tho
    {
        private DAL_Tho dalTho;

        public BUL_Tho()
        {
            dalTho = new DAL_Tho();
        }
        public void AddNewWorker(THO worker)
        {
            dalTho.AddNewWorker(worker);
        }

        public List<THO> GetAllWorkerList()
        {
            return dalTho.GetAllWorkerList();
        }

        public THO GetWorkerById(int id)
        {
            return dalTho.GetWorkerById(id);
        }
        public void UpdateWorker(THO updateWorker)
        {
            dalTho.UpdateWorker(updateWorker);
        }

        public void DeleteWorker(int id)
        {
           dalTho.DeleteWorker(id);
        }
    }
}
