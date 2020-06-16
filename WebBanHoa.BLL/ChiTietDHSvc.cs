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
    public class ChiTietDHSvc : GenericSvc<ChiTietDHRep, ChiTietDonHang>
    {
        public override SingleRsp Read(int id)
        {
            var res = new SingleRsp();

            var m = _rep.Read(id);
            res.Data = m;

            return res;
        }
        public SingleRsp CreateChiTietDH(ChiTietDHReq pro)
        {
            var res = new SingleRsp();
            ChiTietDonHang chitiet= new ChiTietDonHang();
            chitiet.MaDh = pro.MaDh;
            chitiet.MaHoa = pro.MaHoa;
            chitiet.SoTien = pro.SoTien;
            chitiet.Soluong = pro.Soluong;
            chitiet.GiamGia = pro.GiamGia;
            res = _rep.CreateChiTietDH(chitiet);
            return res;
        }
        public SingleRsp UpdateChiTietDH(ChiTietDHReq pro)
        {
            var res = new SingleRsp();
            ChiTietDonHang chitiet = new ChiTietDonHang();
            chitiet.MaDh = pro.MaDh;
            chitiet.MaHoa = pro.MaHoa;
            chitiet.SoTien = pro.SoTien;
            chitiet.Soluong = pro.Soluong;
            chitiet.GiamGia = pro.GiamGia;
            res = _rep.UpdateChiTietDH(chitiet);
            return res;
        }
        public SingleRsp DeleteChiTietDH(int id)
        {
            var res = new SingleRsp();
            try
            {
                res.Data = _rep.DeleteChiTietDH(id);

            }
            catch (Exception ex)
            {
                res.SetError(ex.StackTrace);
            }


            return res;
        }
        public object SearchChiTietDH(int page, int size, string keyword)
        {
            var pro = All.Where(x => x.GiamGia.Contains(keyword));
            var offset = (page - 1) * size;
            var total = pro.Count();
            int totalpage = (total % size) == 0 ? (int)(total / size) : (int)((total / size) + 1);
            var data = pro.OrderBy(x => x.MaDh).Skip(offset).Take(size).ToList();
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
