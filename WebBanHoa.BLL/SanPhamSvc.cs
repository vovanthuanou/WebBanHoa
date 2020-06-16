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
    public class SanPhamSvc : GenericSvc<SanPhamRep, Hoa>
    {

        #region --Overrides--
        public override SingleRsp Read(int id)
        {
            var res = new SingleRsp();

            var m = _rep.Read(id);
            res.Data = m;
            return res;
        }
        /// <summary>
        /// Search product
        /// </summary>
        /// <param name="m">The model</param>
        /// <returns>Return list product</returns>
        public object SearchSanPham(string Keyword, int page, int size)
        {
            var pro = All.Where(p => p.TenHoa.Contains(Keyword));

            var offset = (page - 1) * size;
            var total = pro.Count();
            int totalPages = (total % size) == 0 ? (int)(total / size) : (int)(total / size + 1);
            var data = pro.OrderBy(p => p.TenHoa).Skip(offset).Take(size).ToList();

            var res = new
            {
                Data = data,
                TotalRecord = total,
                TotalPages = totalPages,
                Page = page,
                Size = size

            };
            return res;
        }


        #endregion

        #region -- Methods --

        /// <summary>
        /// Initialize
        /// </summary>
        public SingleRsp CreateProduct(SanPhamReq pro)
        {
            var res = new SingleRsp();
            Hoa products = new Hoa();
            products.MaHoa = pro.MaHoa;
            products.TenHoa = pro.TenHoa;
            products.MaNcc = pro.MaNcc;
            products.GiaMua = pro.GiaMua;
            products.GiaBan = pro.GiaBan;
            products.SoLuong = pro.SoLuong;
            products.TonKho = pro.TonKho;
            products.Mota = pro.Mota;
            res = _rep.CreateProduct(products);

            return res;
        }
        public SingleRsp UpdateProduct(SanPhamReq pro)
        {
            var res = new SingleRsp();
            Hoa products = new Hoa();
            products.MaHoa = pro.MaHoa;
            products.TenHoa = pro.TenHoa;
            products.MaNcc = pro.MaNcc;
            products.GiaMua = pro.GiaMua;
            products.GiaBan = pro.GiaBan;
            products.SoLuong = pro.SoLuong;
            products.TonKho = pro.TonKho;
            products.Mota = pro.Mota;
            res = _rep.UpdateProduct(products);

            return res;
        }
        public SingleRsp DeleteSanPham(int id)
        {
            var res = new SingleRsp();
            try
            {
                res.Data = _rep.DeleteSanPham(id);

            }
            catch (Exception ex)
            {
                res.SetError(ex.StackTrace);
            }
            return res;
        }
        #endregion
    }
}
