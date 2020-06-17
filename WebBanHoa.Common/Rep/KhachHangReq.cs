using System;
using System.Collections.Generic;
using System.Text;

namespace WebBanHoa.Common.Rep
{
    public class KhachHangReq
    {
        public int MaKh { get; set; }
        public string HoKh { get; set; }
        public string TenKh { get; set; }
        public string GioiTinh { get; set; }
        public string DiaChi { get; set; }
        public int? Sdt { get; set; }
        public int? Fax { get; set; }
    }
}
