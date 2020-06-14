using System;
using System.Collections.Generic;
using System.Text;
using WebBanHoa.BLL;
using WebBanHoa.Common.Rsp;

namespace WebBanHoa.BLL
{
    using DAL;
    using DAL.Models;
    using WebBanHoa.Common.BLL;

    public class NhanVienSvc : GenericSvc<NhanVienRep, NhanVien>
    {
        public override SingleRsp Read(int id)
        {
            var res = new SingleRsp();

            var m = _rep.Read(id);
            res.Data = m;

            return res;
        }
    }
}
