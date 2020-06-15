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

    public class NhanVienSvc : GenericSvc<NhanVienRep, NhanVien>
    {
        public override SingleRsp Read(int id)
        {
            var res = new SingleRsp();

            var m = _rep.Read(id);
            res.Data = m;

            return res;
        }

        //Search NhanVien

        public object SearchNhanVien(string keyword, int page, int size)
        {
            var nv = All.Where(x => x.TenNv.Contains(keyword));

            var offset = (page - 1) * size;
            var total = nv.Count();
            int totalpage = (total % size) == 0 ? (int)(total / size) : (int)((total / size) + 1);
            var data = nv.OrderBy(x => x.TenNv).Skip(offset).Take(size).ToList();

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

    

        //Create_NhanVien

        public SingleRsp CreateNhanVien(NhanVienreq nv)
        {
            var res = new SingleRsp();
            NhanVien nhanvien = new NhanVien();
            nhanvien.MaNv = nv.MaNv;
            nhanvien.HoNv = nv.HoNv;
            nhanvien.TenNv = nv.TenNv;
            nhanvien.GioiTinh = nv.GioiTinh;
            nhanvien.ChucVu = nv.ChucVu;
            nhanvien.NgaySinh = nv.NgaySinh;
            nhanvien.NgayLam = nv.NgayLam;
            nhanvien.SoCmnd = nv.SoCmnd;
            nhanvien.DiaChi = nv.DiaChi;
            nhanvien.Luong = nv.Luong;

            res = _rep.CreateNhanVien(nhanvien);
            return res;
        }

        //update_NhanVien
        public SingleRsp UpdateNhanVien(NhanVienreq nv)
        {
            var res = new SingleRsp();
            NhanVien nhanvien = new NhanVien();
            nhanvien.MaNv = nv.MaNv;
            nhanvien.HoNv = nv.HoNv;
            nhanvien.TenNv = nv.TenNv;
            nhanvien.GioiTinh = nv.GioiTinh;
            nhanvien.ChucVu = nv.ChucVu;
            nhanvien.NgaySinh = nv.NgaySinh;
            nhanvien.NgayLam = nv.NgayLam;
            nhanvien.SoCmnd = nv.SoCmnd;
            nhanvien.DiaChi = nv.DiaChi;
            nhanvien.Luong = nv.Luong;

            res = _rep.UpdateNhanVien(nhanvien);
            return res;
        }
    }
}
