using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUL
{
    public class BUL_SanPham
    {
        private DAL.DAL_SanPham _dalSanPham;
        public BUL_SanPham()
        {
            _dalSanPham = new DAL.DAL_SanPham();
        }   
        public void addNewProduct(DTO.SANPHAM product)
        {
            _dalSanPham.addNewProduct(product);
        }
        public DTO.SANPHAM getProductById(int id)
        {
            
            return _dalSanPham.getProductById(id);
        }
        public List<DTO.SANPHAM> getAllProduct()
        {
            return _dalSanPham.getAllProduct();
        }
        public bool deleteProduct(int id)
        {
            try
            {
                _dalSanPham.deleteProduct(id);
                return true;
            }
            catch (Exception e)
            {
                _dalSanPham = null;
                _dalSanPham = new DAL.DAL_SanPham();
                return false;
            }
        }
        public DTO.SANPHAM getLastProduct()
        {
            return _dalSanPham.getLastProduct();
        }
        public DTO.SANPHAM updateProduct(DTO.SANPHAM updateProduct)
        {
            return this._dalSanPham.updateProduct(updateProduct);
        }
        public List<DTO.SANPHAM> getProductByProductType(int producttype)
        {
            return _dalSanPham.getProductByProductType(producttype);
        }
    }
}
