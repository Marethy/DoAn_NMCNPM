using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data.Entity;
using System.ComponentModel;

namespace DAL
{
    public class DAL_KhachHang
    {
        private DBQLCuaHangVangBacDaQuyEntities _context;

        public DAL_KhachHang()
        {
            _context = new DBQLCuaHangVangBacDaQuyEntities();
        }

        public void AddNewClient(KHACHHANG khachhang)
        {
            _context.KHACHHANGs.Add(khachhang);
            _context.SaveChanges();
        }


        public BindingList<KHACHHANG> getAllBindingListOfKhachHang()
        {
            this._context.KHACHHANGs.Load();
            return this._context.KHACHHANGs.Local.ToBindingList();
        }
        public List<KHACHHANG> GetAllKhachhangs()
        {
            return _context.KHACHHANGs.ToList();
        }

        public KHACHHANG GetKhachhangById(int? id)
        {
            return _context.KHACHHANGs.Single(kh => kh.MaKH == id);
        }

        public void UpdateKhachHang(KHACHHANG updateKhachhang)
        {
            var currentKh = _context.KHACHHANGs.Find(updateKhachhang.MaKH);
            if (currentKh != null)
            {
                currentKh.TenKH = updateKhachhang.TenKH;
                currentKh.SDT = updateKhachhang.SDT;
                currentKh.DiaChi = updateKhachhang.DiaChi;
                _context.SaveChanges();
            }
        }

        public void DeleteKhachHang(int id)
        {
            _context.KHACHHANGs.Remove(GetKhachhangById(id));
            _context.SaveChanges();
        }
    }
}
