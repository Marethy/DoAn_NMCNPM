using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_SanPham
    {
        DTO.DBQLCuaHangVangBacDaQuyEntities _context;
        public DAL_SanPham()
        {
            _context = new DTO.DBQLCuaHangVangBacDaQuyEntities();
        }
        public void addNewProduct(DTO.SANPHAM product)
        {
            _context.SANPHAMs.Add(product);
            _context.SaveChanges();
            
            
        }
        public List<DTO.SANPHAM> getAllProduct()
        {
            List<DTO.SANPHAM> _listProduct = new List<DTO.SANPHAM>();
            var query = from product in _context.SANPHAMs
                        select product;
            _listProduct = query.ToList();
            return _listProduct;
        }
        public DTO.SANPHAM getProductById(int id)
        {
            var query = from product in _context.SANPHAMs
                        where product.MaSP == id
                        select product;
            return query.Single();
        }
        public DTO.SANPHAM updateProduct(DTO.SANPHAM updateProduct)
        {
            var current = _context.SANPHAMs.Find(updateProduct.MaSP);
            if (current != null)
            {
                current.TenSP = updateProduct.TenSP;
                current.MaLoaiSP = updateProduct.MaLoaiSP;
                current.GiaMua = updateProduct.GiaMua;
                current.SoLuongTon = updateProduct.SoLuongTon;
                current.TinhTrang = updateProduct.TinhTrang;
                current.TrongLuong = updateProduct.TrongLuong;
                _context.SaveChanges();
            }
            return current;
        }
        public void deleteProduct(int id)
        {
            var target = this._context.SANPHAMs.Find(id);
            this._context.SANPHAMs.Remove(target);
            this._context.SaveChanges();
        }
        public DTO.SANPHAM getLastProduct()
        {
            var max = _context.SANPHAMs.Max(p => p.MaSP);
            return _context.SANPHAMs.Where(p => p.MaSP == max).Single();
        }
        public List<DTO.SANPHAM> getProductByProductType(int producttype)
        {
            return _context.SANPHAMs.Where(p => p.MaLoaiSP == producttype).ToList();
        }
    }
}
