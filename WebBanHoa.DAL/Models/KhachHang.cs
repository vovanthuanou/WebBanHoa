using System;
using System.Collections.Generic;

namespace WebBanHoa.DAL.Models
{
    public partial class KhachHang
    {
        public KhachHang()
        {
            DonHang = new HashSet<DonHang>();
        }

        public int MaKh { get; set; }
        public string HoKh { get; set; }
        public string TenKh { get; set; }
        public string GioiTinh { get; set; }
        public string DiaChi { get; set; }
        public int? Sdt { get; set; }
        public int? Fax { get; set; }

        public virtual ICollection<DonHang> DonHang { get; set; }
    }
}
