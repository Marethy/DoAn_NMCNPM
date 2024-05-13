using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DTO;
using System.Threading.Tasks;

namespace BUL
{	// updated
    public class BUL_LoaiSanPham
    {
        private DAL.DAL_LoaiSanPham _dalProductType;
        public BUL_LoaiSanPham()
        {
            _dalProductType = new DAL.DAL_LoaiSanPham();
        }
        public void addNewProductType(DTO.LOAISANPHAM producttype)
        {
            _dalProductType.addNewProductType(producttype);
        }
        public List<DTO.LOAISANPHAM> getAllProductType()
        {
            return _dalProductType.getAllProductType();
        }
        public DTO.LOAISANPHAM getProductTypeById(int id)
        {
            return _dalProductType.getProductTypeById(id);
        }

        public List<SANPHAM> getProductsByTypeId(int typeId)
        {
            return this._dalProductType.getProductsByTypeId(typeId);
        }

        public void updateProductType(DTO.LOAISANPHAM updateProductType)
        {
            _dalProductType.updateProductType(updateProductType);
        }
        public string getProductTypeNameById(int id)
        {
            return _dalProductType.getProductNameById(id);
        }
        public bool deleteProductType(int id)
        {
            try
            {
                _dalProductType.deleteProduct(id);
                return true;
            }
            catch (Exception e)
            {
                
                _dalProductType = null;
                _dalProductType = new DAL.DAL_LoaiSanPham();
                return false;
            }
        }
        public DTO.LOAISANPHAM getLastProduct()
        {
            return _dalProductType.getLastProductType();
        }
    }
}
