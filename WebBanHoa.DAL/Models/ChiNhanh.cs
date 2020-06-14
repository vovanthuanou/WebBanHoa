using System;
using System.Collections.Generic;

namespace WebBanHoa.DAL.Models
{
    public partial class ChiNhanh
    {
        public int MaChiNhanh { get; set; }
        public int? MaNv { get; set; }
        public string TenChiNhanh { get; set; }
        public string DiaChi { get; set; }
        public DateTime? NgayHoatDong { get; set; }
        public DateTime? GiaThue { get; set; }

        public virtual NhanVien MaNvNavigation { get; set; }
    }
}
