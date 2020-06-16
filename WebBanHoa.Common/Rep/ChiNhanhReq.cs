using System;
using System.Collections.Generic;
using System.Text;
using WebBanHoa.Common.BLL;
using WebBanHoa.Common.DAL;

namespace WebBanHoa.Common.Rep
{
    public class ChiNhanhReq
    {
        public int MaChiNhanh { get; set; }
        public int? MaNv { get; set; }
        public string TenChiNhanh { get; set; }
        public string DiaChi { get; set; }
        public DateTime? NgayHoatDong { get; set; }
        public DateTime? GiaThue { get; set; }

        public virtual NhanVienreq MaNvNavigation { get; set; }
    }
}
