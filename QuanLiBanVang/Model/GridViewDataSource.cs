using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiBanVang.model
{
    /*
        the class GridViewDataSource : data source model for gridview
     *  bind data to gridview whenever data changes
     *  - used for PhieuBanHang's gridcontrol
     */
    public class DetailGridViewDataSource : IComparable
    {
        public int Stt { set; get; }
        public int MaLoaiSp { get; set; }
        public string LoaiSP { set; get; }
        public int MaSP { get; set; }
        public string TenSp { get; set; }
        public int SoLuong { get; set; }
        public decimal GiaBan { get; set; }
        public decimal ThanhTien { get; set; }

        public int CompareTo(object obj)
        {
            throw new NotImplementedException();
        }
    }
}
