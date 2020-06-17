using System;
using System.Collections.Generic;
using System.Text;
using WebBanHoa.BLL;
using WebBanHoa.Common.Rsp;

namespace WebBanHoa.BLL
{
    using System.Linq;
    using DAL;
    using DAL.Models;
    using WebBanHoa.Common.BLL;
    using WebBanHoa.Common.Rep;

    public class KhachHangSvc : GenericSvc<KhachHangRep, KhachHang>
    {
        public override SingleRsp Read(int id)
        {
            var res = new SingleRsp();

            var m = _rep.Read(id);
            res.Data = m;

            return res;
        }


        public object SearchKhachHang(string keyword, int page, int size)
        {
            var nv = All.Where(x => x.TenKh.Contains(keyword));

            var offset = (page - 1) * size;
            var total = nv.Count();
            int totalpage = (total % size) == 0 ? (int)(total / size) : (int)((total / size) + 1);
            var data = nv.OrderBy(x => x.TenKh).Skip(offset).Take(size).ToList();

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



      

        public SingleRsp CreateKhachHang(KhachHangReq kh)
        {
            var res = new SingleRsp();
            KhachHang khachhang = new KhachHang();
            khachhang.MaKh = kh.MaKh;
            khachhang.HoKh = kh.HoKh;
            khachhang.TenKh = kh.TenKh;
            khachhang.GioiTinh = kh.GioiTinh;
            khachhang.DiaChi = kh.DiaChi;
            khachhang.Sdt = kh.Sdt;
            khachhang.Fax = kh.Fax;


            res = _rep.CreateKhachHang(khachhang);
            return res;
        }

        
        public SingleRsp UpdateKhachHang(KhachHangReq kh)
        {
            var res = new SingleRsp();
            KhachHang khachhang = new KhachHang();
            khachhang.MaKh = kh.MaKh;
            khachhang.HoKh = kh.HoKh;
            khachhang.TenKh = kh.TenKh;
            khachhang.GioiTinh = kh.GioiTinh;
            khachhang.DiaChi = kh.DiaChi;
            khachhang.Sdt = kh.Sdt;
            khachhang.Fax = kh.Fax;

            res = _rep.UpdateKhachHang(khachhang);
            return res;
        }
        public SingleRsp DeleteKhachHang(int id)
        {
            var res = new SingleRsp();
            try
            {
                res.Data = _rep.DeleteKhachHang(id);

            }
            catch (Exception ex)
            {
                res.SetError(ex.StackTrace);
            }


            return res;
        }
    }
}
