
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
    public class DonHangSvc : GenericSvc<DonHangRep, DonHang>
    {
        public override SingleRsp Read(int id)
        {
            var res = new SingleRsp();

            var m = _rep.Read(id);
            res.Data = m;

            return res;
        }


        public SingleRsp CreateDonHang(DonHangReq pro)
        {
            var res = new SingleRsp();
            DonHang donhang = new DonHang();
            donhang.MaDh = pro.MaDh;
            donhang.MaKh = pro.MaKh;
            donhang.MaNv = pro.MaNv;
            donhang.NgayDatHoa = pro.NgayDatHoa;
            donhang.NgayGiaoHoa = pro.NgayGiaoHoa;
            donhang.NgayNhan = pro.NgayNhan;
            donhang.DiaChiNhan = pro.DiaChiNhan;
            donhang.NguoiNhan = pro.NguoiNhan;
            res = _rep.CreateDonHang(donhang);
            return res;
        }

        public object DeleteDonHang(int? maDh)
        {
            throw new NotImplementedException();
        }

        public SingleRsp CapnhatDonHang(DonHangReq pro)
        {
            var res = new SingleRsp();
            DonHang donhang = new DonHang();
            donhang.MaDh = pro.MaDh;
            donhang.MaKh = pro.MaKh;
            donhang.MaNv = pro.MaNv;
            donhang.NgayDatHoa = pro.NgayDatHoa;
            donhang.NgayGiaoHoa = pro.NgayGiaoHoa;
            donhang.NgayNhan = pro.NgayNhan;
            donhang.DiaChiNhan = pro.DiaChiNhan;
            donhang.NguoiNhan = pro.NguoiNhan;
            res = _rep.UpdateDonHang(donhang);
            return res;
        }
        public SingleRsp DeleteDonHang(int id)
        {
            var res = new SingleRsp();
            try
            {
                res.Data = _rep.DeleteDonHang(id);

            }
            catch (Exception ex)
            {
                res.SetError(ex.StackTrace);
            }


            return res;
        }
        public object SearchDonHang(int page, int size, string keyword)
        {
            var pro = All.Where(x => x.NguoiNhan.Contains(keyword));
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