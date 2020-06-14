using System;
using System.Collections.Generic;

namespace WebBanHoa.DAL.Models
{
    public partial class DonHang
    {
        public DonHang()
        {
            ChiTietDonHang = new HashSet<ChiTietDonHang>();
        }

        public int MaDh { get; set; }
        public int? MaKh { get; set; }
        public int? MaNv { get; set; }
        public DateTime? NgayDatHoa { get; set; }
        public DateTime? NgayGiaoHoa { get; set; }
        public DateTime? NgayNhan { get; set; }
        public string DiaChiNhan { get; set; }
        public string NguoiNhan { get; set; }

        public virtual KhachHang MaKhNavigation { get; set; }
        public virtual NhanVien MaNvNavigation { get; set; }
        public virtual ICollection<ChiTietDonHang> ChiTietDonHang { get; set; }
    }
}
