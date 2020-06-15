using System;
using System.Collections.Generic;
using System.Text;

namespace WebBanHoa.Common.Rep
{
    public class DonHangReq
    {
        public int MaDh { get; set; }
        public int MaKh { get; set; }
        public int MaNv { get; set; }
        public DateTime NgayDatHoa { get; set; }
        public DateTime NgayGiaoHoa { get; set; }
        public DateTime NgayNhan { get; set; }
        public string DiaChiNhan { get; set; }
        public string NguoiNhan { get; set; }
    }
}
