using System;
using System.Collections.Generic;

namespace WebBanHoa.DAL.Models
{
    public partial class NhanVien
    {
        public NhanVien()
        {
            ChiNhanh = new HashSet<ChiNhanh>();
            DonHang = new HashSet<DonHang>();
        }

        public int MaNv { get; set; }
        public string HoNv { get; set; }
        public string TenNv { get; set; }
        public string GioiTinh { get; set; }
        public string ChucVu { get; set; }
        public DateTime? NgaySinh { get; set; }
        public DateTime? NgayLam { get; set; }
        public int? SoCmnd { get; set; }
        public string DiaChi { get; set; }
        public byte[] HinhThe { get; set; }
        public decimal? Luong { get; set; }

        public virtual ICollection<ChiNhanh> ChiNhanh { get; set; }
        public virtual ICollection<DonHang> DonHang { get; set; }
    }
}
