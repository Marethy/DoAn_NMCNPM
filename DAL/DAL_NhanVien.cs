using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_NhanVien
    {
        DTO.DBQLCuaHangVangBacDaQuyEntities _context;
        public DAL_NhanVien()
        {
            _context = new DTO.DBQLCuaHangVangBacDaQuyEntities();
        }
        public void addNewStaff(DTO.NHANVIEN staff)
        {
            _context.NHANVIENs.Add(staff);
            _context.SaveChanges();
        }
        public bool addNewUser(DTO.NHANVIEN staff)
        {
            bool isDuplicate = _context.NHANVIENs.Any(nv => nv.TenDangNhap == staff.TenDangNhap);
            if (isDuplicate)
            {
                return false;
            }
            else
            {
                _context.NHANVIENs.Add(staff);
                _context.SaveChanges();
                return true;
            }
        }
        public DTO.NHANVIEN getStaffById(int id)
        {
            return _context.NHANVIENs.Where(nv => nv.MaNV == id).Single();
        }
        public List<DTO.NHANVIEN> getAllStaff()
        {
            return _context.NHANVIENs.ToList();
        }
        public void updateStaff(DTO.NHANVIEN updateStaff)
        {
            var current = _context.NHANVIENs.Find(updateStaff.MaNV);
            if (current != null)
            {
                current.HoTen = updateStaff.HoTen;
                current.MaCV = updateStaff.MaCV;
                current.MaNhom = updateStaff.MaNhom;
                current.MatKhau = updateStaff.MatKhau;
                current.NgSinh = updateStaff.NgSinh;
                current.TenDangNhap = updateStaff.TenDangNhap;
                current.GioiTinh = updateStaff.GioiTinh;
                current.DiaChi = updateStaff.DiaChi;
                current.SDT = updateStaff.SDT;
                _context.SaveChanges();
            }
        }
        public DTO.NHANVIEN getLastStaff()
        {
            var max = _context.NHANVIENs.Max(s => s.MaNV);
            return _context.NHANVIENs.Single(s => s.MaNV == max);
        }
        public void deleteStaff(int id)
        {
            var target = _context.NHANVIENs.Find(id);
            _context.NHANVIENs.Remove(target);
            _context.SaveChanges();
        }

        public DTO.NHANVIEN getStaffByUsername(string username)
        {
            return _context.NHANVIENs.Single(s => s.TenDangNhap == username);
        }

    }
}
