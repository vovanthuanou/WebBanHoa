using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebBanHoa.Common.BLL;
using WebBanHoa.Common.Rep;
using WebBanHoa.Common.Rsp;
using WebBanHoa.DAL;
using WebBanHoa.DAL.Models;

namespace WebBanHoa.BLL
{
    public class ChiNhanhSvc : GenericSvc<ChiNhanhRep, ChiNhanh>
    {
        public override SingleRsp Read(int id)
        {
            var res = new SingleRsp();

            var m = _rep.Read(id);
            res.Data = m;

            return res;
        }


        public SingleRsp CreateChiNhanh(ChiNhanhReq pro)
        {
            var res = new SingleRsp();
            ChiNhanh chiNhanh = new ChiNhanh();
            chiNhanh.MaChiNhanh = pro.MaChiNhanh;
            chiNhanh.TenChiNhanh = pro.TenChiNhanh;
            chiNhanh.MaNv = pro.MaNv;
            chiNhanh.DiaChi = pro.DiaChi;
            chiNhanh.NgayHoatDong = pro.NgayHoatDong;
            chiNhanh.GiaThue = pro.GiaThue;
            res = _rep.CreateChiNhanh(chiNhanh);
            return res;
        }

        public SingleRsp CapnhatChiNhanh(ChiNhanhReq pro)
        {
            var res = new SingleRsp();
            ChiNhanh chiNhanh = new ChiNhanh();
            chiNhanh.MaChiNhanh = pro.MaChiNhanh;
            chiNhanh.TenChiNhanh = pro.TenChiNhanh;
            chiNhanh.MaNv = pro.MaNv;
            chiNhanh.DiaChi = pro.DiaChi;
            chiNhanh.NgayHoatDong = pro.NgayHoatDong;
            chiNhanh.GiaThue = pro.GiaThue;
            res = _rep.UpdateChiNhanh(chiNhanh);
            return res;
        }
        public SingleRsp DeleteChiNhanh(int id)
        {
            var res = new SingleRsp();
            try
            {
                res.Data = _rep.DeleteChiNhanh(id);

            }
            catch (Exception ex)
            {
                res.SetError(ex.StackTrace);
            }


            return res;
        }
        public object SearchChiNhanh(int page, int size, string keyword)
        {
            var pro = All.Where(x => x.TenChiNhanh.Contains(keyword));
            var offset = (page - 1) * size;
            var total = pro.Count();
            int totalpage = (total % size) == 0 ? (int)(total / size) : (int)((total / size) + 1);
            var data = pro.OrderBy(x => x.MaChiNhanh).Skip(offset).Take(size).ToList();
            var res = new
            {
                Data = data,
                TotalRecord = total,
                TotalPage = totalpage,
                Pages = page,
                Size = size

            };
            return res;
        }
    }
}