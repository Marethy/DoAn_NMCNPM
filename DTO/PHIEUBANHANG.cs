//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DTO
{
    using System;
    using System.Collections.Generic;
    
    public partial class PHIEUBANHANG
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PHIEUBANHANG()
        {
            this.CTPBHs = new HashSet<CTPBH>();
            this.PHIEUTHUTIENNOes = new HashSet<PHIEUTHUTIENNO>();
        }
    
        public int SoPhieuBH { get; set; }
        public int MaNV { get; set; }
        public Nullable<int> MaKH { get; set; }
        public System.DateTime NgayBan { get; set; }
        public System.DateTime NgayTra { get; set; }
        public decimal TongTien { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTPBH> CTPBHs { get; set; }
        public virtual KHACHHANG KHACHHANG { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PHIEUTHUTIENNO> PHIEUTHUTIENNOes { get; set; }
        public virtual NHANVIEN NHANVIEN { get; set; }
    }
}
