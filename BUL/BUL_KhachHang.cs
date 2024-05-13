using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Data.Entity;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BUL
{
    public class BUL_KhachHang
    {
        private DAL_KhachHang dalKhachHang;

        public BUL_KhachHang()
        {
            dalKhachHang = new DAL_KhachHang();
        }
        public void AddNewClient(KHACHHANG khachhang)
        {
            dalKhachHang.AddNewClient(khachhang);
        }
        public BindingList<KHACHHANG> getAllBindingListOfKhachHang()
        {
            return this.dalKhachHang.getAllBindingListOfKhachHang();
        }

        public List<KHACHHANG> GetAllKhachhangs()
        {
            return dalKhachHang.GetAllKhachhangs();
        }

        public KHACHHANG GetKhachhangById(int? id)
        {
            return dalKhachHang.GetKhachhangById(id);
        }

        public void UpdateKhachHang(KHACHHANG updateKhachhang)
        {
            dalKhachHang.UpdateKhachHang(updateKhachhang);
        }

        public void DeleteKhachHang(int id)
        {
            dalKhachHang.DeleteKhachHang(id);
        }
    }
}
