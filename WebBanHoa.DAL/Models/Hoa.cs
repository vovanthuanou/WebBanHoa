using System;
using System.Collections.Generic;

namespace WebBanHoa.DAL.Models
{
    public partial class Hoa
    {
        public Hoa()
        {
            ChiTietDonHang = new HashSet<ChiTietDonHang>();
        }

        public int MaHoa { get; set; }
        public string TenHoa { get; set; }
        public int? MaNcc { get; set; }
        public decimal? GiaMua { get; set; }
        public decimal? GiaBan { get; set; }
        public int? SoLuong { get; set; }
        public int? TonKho { get; set; }
        public string Mota { get; set; }

        public virtual NhaCungCap MaNccNavigation { get; set; }
        public virtual ICollection<ChiTietDonHang> ChiTietDonHang { get; set; }
    }
}
