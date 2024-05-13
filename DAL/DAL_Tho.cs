using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class DAL_Tho
    {
        private DBQLCuaHangVangBacDaQuyEntities _context;
        public DAL_Tho()
        {
            _context = new DBQLCuaHangVangBacDaQuyEntities();
        }

        public void AddNewWorker(THO worker)
        {
            _context.THOes.Add(worker);
            _context.SaveChanges();
        }

        public List<THO> GetAllWorkerList()
        {
            List<THO> listWorker = new List<THO>();
            var query = from worker in _context.THOes
                        select worker;
            listWorker = query.ToList();
            return listWorker;
        }

        public THO GetWorkerById(int id)
        {
            var query = from worker in _context.THOes
                where worker.MaTho == id
                select worker;
            return query.Single();
        }

        public void UpdateWorker(THO updateWorker)
        {
            var currentWorker = _context.THOes.Find(updateWorker.MaTho);
            if (currentWorker != null)
            {
                currentWorker.TenTho = updateWorker.TenTho;
                currentWorker.DiaChi = updateWorker.DiaChi;
                currentWorker.SDT = updateWorker.SDT;
                _context.SaveChanges();
            }
        }

        public void DeleteWorker(int id)
        {
            _context.THOes.Remove(GetWorkerById(id));
            _context.SaveChanges();
        }
    }
}
