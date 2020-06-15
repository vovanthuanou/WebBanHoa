using System;
using System.Collections.Generic;
using System.Text;

namespace WebBanHoa.Common.Rep
{
    public class SanPhamReq
    {
        public int MaHoa { get; set; }
        public string TenHoa { get; set; }
        public int? MaNcc { get; set; }
        public decimal? GiaMua { get; set; }
        public decimal? GiaBan { get; set; }
        public int? SoLuong { get; set; }
        public int TonKho { get; set; }
        public string Mota { get; set; }
    }
}
