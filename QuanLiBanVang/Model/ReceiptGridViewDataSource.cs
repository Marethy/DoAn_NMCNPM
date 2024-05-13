using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiBanVang.Model
{
    public class ReceiptGridViewDataSource : IComparable
    {
        public int Stt { set; get; }
        public int SoPhieu { get; set; }
        public DateTime NgayLap { set; get; }
        public DateTime NgayThanhToan { get; set; }
        public int MaKH { get; set; }
        public int MaNV { get; set; }
        public decimal TongTien { get; set; }
        public int CompareTo(object obj)
        {
            throw new NotImplementedException();
        }
        
    }
}
