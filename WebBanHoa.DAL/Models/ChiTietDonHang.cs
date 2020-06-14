using System;
using System.Collections.Generic;

namespace WebBanHoa.DAL.Models
{
    public partial class ChiTietDonHang
    {
        public int MaDh { get; set; }
        public int MaHoa { get; set; }
        public decimal? SoTien { get; set; }
        public int? Soluong { get; set; }
        public string GiamGia { get; set; }

        public virtual DonHang MaDhNavigation { get; set; }
        public virtual Hoa MaHoaNavigation { get; set; }
    }
}
