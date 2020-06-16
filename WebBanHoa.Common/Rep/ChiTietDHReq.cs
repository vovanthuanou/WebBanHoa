using System;
using System.Collections.Generic;
using System.Text;

namespace WebBanHoa.Common.Rep
{
   public class ChiTietDHReq
    {
        public int MaDh { get; set; }
        public int MaHoa { get; set; }
        public decimal SoTien { get; set; }
        public int Soluong { get; set; }
        public string GiamGia { get; set; }
    }
}
