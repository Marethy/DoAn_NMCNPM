using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
namespace DAL
{
    public class DAL_LoaiSanPham
    {
        // updated
        DTO.DBQLCuaHangVangBacDaQuyEntities _context;
        public DAL_LoaiSanPham()
        {
            _context = new DTO.DBQLCuaHangVangBacDaQuyEntities();
        }
        public void addNewProductType(DTO.LOAISANPHAM productType)
        {

            _context.LOAISANPHAMs.Add(productType);
            _context.SaveChanges();
            
        }
        public List<DTO.LOAISANPHAM> getAllProductType()
        {

            List<DTO.LOAISANPHAM> _listProductType = new List<DTO.LOAISANPHAM>();
            var query = from productType in _context.LOAISANPHAMs
                        select productType;
            _listProductType = query.ToList();
            return _listProductType;
        }


        /// <summary>
        /// get all products by product type id
        /// </summary>
        /// <param name="typeId"></param>
        /// <returns> list desired products</returns>
        public List<SANPHAM> getProductsByTypeId(int typeId)
        {
            return this._context.SANPHAMs.Where(x => x.MaLoaiSP == typeId).ToList();
        }
        public DTO.LOAISANPHAM getProductTypeById(int id)
        {
            //var query = from productType in _context.LOAISANPHAMs
            //            where productType.MaLoaiSP == Id
            //            select productType;
            //return query.Single();
            return _context.LOAISANPHAMs.Single(type => type.MaLoaiSP == id);
        }
        public void updateProductType(DTO.LOAISANPHAM updateProductType)
        {
            var current = _context.LOAISANPHAMs.Find(updateProductType.MaLoaiSP);
            if (current != null)
            {
                current.MaLoaiSP = updateProductType.MaLoaiSP;
                current.PhanTramLoiNhuan = updateProductType.PhanTramLoiNhuan;
                current.TenLoaiSP = updateProductType.TenLoaiSP;
                _context.SaveChanges();
            }
        }
        public void deleteProduct(int id)
        {
            var target = _context.LOAISANPHAMs.Find(id);
            _context.LOAISANPHAMs.Remove(target);
            _context.SaveChanges();
            
        }
        public string getProductNameById(int id)
        {
            return _context.LOAISANPHAMs.Single(p => p.MaLoaiSP == id).TenLoaiSP;
        }
        public DTO.LOAISANPHAM getLastProductType()
        {
            var max = _context.LOAISANPHAMs.Max(t => t.MaLoaiSP);
            return _context.LOAISANPHAMs.Single(t => t.MaLoaiSP == max);
        }
    }
}
