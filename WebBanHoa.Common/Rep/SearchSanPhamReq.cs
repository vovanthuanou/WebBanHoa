using System;
using System.Collections.Generic;
using System.Text;

namespace WebBanHoa.Common.Rep
{
    public class SearchSanPhamReq
    {
        public int page { get; set; }
        public int size { get; set; }
        public int Id { get; set; }
        public string Keyword { get; set; }
    }
}
