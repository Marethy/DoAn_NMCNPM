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
    
    public partial class PHIEUDICHVU
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PHIEUDICHVU()
        {
            this.CTPDVs = new HashSet<CTPDV>();
        }
    
        public int SoPhieuDV { get; set; }
        public Nullable<int> MaKH { get; set; }
        public int MaNV { get; set; }
        public System.DateTime NgayDangKy { get; set; }
        public System.DateTime NgayGiao { get; set; }
        public decimal TongTien { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTPDV> CTPDVs { get; set; }
        public virtual KHACHHANG KHACHHANG { get; set; }
        public virtual NHANVIEN NHANVIEN { get; set; }
    }
}