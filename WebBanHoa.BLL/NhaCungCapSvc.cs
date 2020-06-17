using System;
using System.Collections.Generic;
using System.Text;
using WebBanHoa.BLL;
using WebBanHoa.Common.Rsp;

namespace WebBanHoa.BLL
{
    using DAL;
    using DAL.Models;
    using System.Linq;
    using System.Net.Http.Headers;
    using WebBanHoa.Common.BLL;
    using WebBanHoa.Common.Rep;

    public class NhaCungCapSvc : GenericSvc<NhaCungCapRep, NhaCungCap>
    {
        public override SingleRsp Read(int id)
        {
            var res = new SingleRsp();

            var m = _rep.Read(id);
            res.Data = m;

            return res;
        }
        public object SearchNhaCungCap(string keyword, int page, int size)
        {
            var nv = All.Where(x => x.TenNcc.Contains(keyword));

            var offset = (page - 1) * size;
            var total = nv.Count();
            int totalpage = (total % size) == 0 ? (int)(total / size) : (int)((total / size) + 1);
            var data = nv.OrderBy(x => x.TenNcc).Skip(offset).Take(size).ToList();

            var res = new
            {
                Data = data,
                TotalRecord = total,
                Totalpage = totalpage,
                Page = page,
                Size = size
            };
            return res;
        }

        public SingleRsp CreateNhaCungCap(NhaCungCapReq Ncc)
        {
            var res = new SingleRsp();
            NhaCungCap nhacungcap = new NhaCungCap();
            nhacungcap.MaNcc = Ncc.MaNcc;
            nhacungcap.TenNcc = Ncc.TenNcc;
            nhacungcap.DiaChi = Ncc.DiaChi;
            nhacungcap.SoDt = Ncc.SoDt;
            res = _rep.CreateNhaCungCap(nhacungcap);
            return res;

        }
        public SingleRsp UpdateNhaCungCap(NhaCungCapReq Ncc)
        {
            var res = new SingleRsp();
            NhaCungCap nhacungcap = new NhaCungCap();
            nhacungcap.MaNcc = Ncc.MaNcc;
            nhacungcap.TenNcc = Ncc.TenNcc;
            nhacungcap.DiaChi = Ncc.DiaChi;
            nhacungcap.SoDt = Ncc.SoDt;
            res = _rep.UpdateNhaCungCap(nhacungcap);
            return res;

        }

        public object SearchNhaCungCap(int page, int size, string keyword)
        {
            throw new NotImplementedException();
        }

        public object DeleteNhaCungCap(int? MaNcc)
        {
            throw new NotImplementedException();
        }
        public SingleRsp DeleteNhaCungCap(int id)

        {
            var res = new SingleRsp();
            try
            {
                res.Data = _rep.DeleteNhaCungCap(id);

            }
            catch (Exception ex)
            {
                res.SetError(ex.StackTrace);
            }

            return res;
        }
    }


}