using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiBanVang.Model
{

    /*
        the class GridViewDataSource : data source model for gridview
     *  bind data to gridview whenever data changes
     *  - used for PhieuNhapHang's gridcontrol
     */
    public class ImportItemGridViewDataSource : IComparable
    {
        public int STT { get; set; }
        public string LoaiSanPham { get; set; }
        public int MaSp { get; set; }
        public string TenSp { get; set; }
        public int SoLuong { get; set; }
        public decimal GiaMua { get; set; }
        public decimal ThanhTien { get; set; }
        public int CompareTo(object obj)
        {
            throw new NotImplementedException();
        }
    }
}
