using System;
using System.Collections.Generic;
using System.Text;
using WebBanHoa.Common.DAL;
using System.Linq;

namespace WebBanHoa.DAL
{
    using WebBanHoa.DAL.Models;
    public class NhanVienRep : GenericRep<WebBanHoaContext, NhanVien>
    {
        #region --Override--
        public override NhanVien Read(int id)
        {
            var res = All.FirstOrDefault(p => p.MaNv == id);
            return res;
        }
        public int Remove(int id)
        {
            var m = base.All.First(i => i.MaNv == id);
            m = base.Delete(m);
            return m.MaNv;
        }
        #endregion
    }
}
