using System;
using System.Collections.Generic;
using System.Text;
using WebBanHoa.Common.DAL;
using System.Linq;

namespace WebBanHoa.DAL
{
    using WebBanHoa.Common.Rsp;
    using WebBanHoa.DAL.Models;
    public class KhachHangRep : GenericRep<WebBanHoaContext, KhachHang>
    {
        #region --Override--
        public override KhachHang Read(int id)
        {
            var res = All.FirstOrDefault(p => p.MaKh == id);
            return res;
        }
        public int Remove(int id)
        {
            var m = base.All.First(i => i.MaKh == id);
            m = base.Delete(m);
            return m.MaKh;
        }
        #endregion

        #region --Methods--
        public SingleRsp CreateKhachHang(KhachHang kh)
        {
            var res = new SingleRsp();
            using (var context = new WebBanHoaContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var T = context.KhachHang.Add(kh);
                        context.SaveChanges();
                        tran.Commit();
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        res.SetError(ex.StackTrace);
                    }
                }
            }
            return res;
        }

        public SingleRsp UpdateKhachHang(KhachHang kh)
        {
            var res = new SingleRsp();
            using (var context = new WebBanHoaContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var T = context.KhachHang.Update(kh);
                        context.SaveChanges();
                        tran.Commit();
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        res.SetError(ex.StackTrace);
                    }
                }
            }
            return res;
        }
        public int DeleteKhachHang(int id)
        {
            var m = base.All.First(i => i.MaKh == id);
            Context.KhachHang.Remove(m);
            Context.SaveChanges();
            return m.MaKh;
        }
        #endregion
    }
}
