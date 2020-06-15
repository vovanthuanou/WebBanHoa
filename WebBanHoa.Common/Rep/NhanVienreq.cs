using System;
using System.Collections.Generic;
using System.Text;

namespace WebBanHoa.Common.Rep
{
    public class NhanVienreq
    {
        public int MaNv { get; set; }
        public string HoNv { get; set; }
        public string TenNv { get; set; }
        public string GioiTinh { get; set; }
        public string ChucVu { get; set; }
        public DateTime? NgaySinh { get; set; }
        public DateTime? NgayLam { get; set; }
        public int? SoCmnd { get; set; }
        public string DiaChi { get; set; }
        public decimal? Luong { get; set; }
    }
}
