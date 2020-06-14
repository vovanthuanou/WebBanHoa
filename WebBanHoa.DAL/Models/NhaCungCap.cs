using System;
using System.Collections.Generic;

namespace WebBanHoa.DAL.Models
{
    public partial class NhaCungCap
    {
        public NhaCungCap()
        {
            Hoa = new HashSet<Hoa>();
        }

        public int MaNcc { get; set; }
        public string TenNcc { get; set; }
        public string DiaChi { get; set; }
        public int? SoDt { get; set; }

        public virtual ICollection<Hoa> Hoa { get; set; }
    }
}
