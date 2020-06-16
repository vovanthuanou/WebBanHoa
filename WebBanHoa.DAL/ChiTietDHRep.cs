using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebBanHoa.Common.DAL;
using WebBanHoa.Common.Rsp;
using WebBanHoa.DAL.Models;

namespace WebBanHoa.DAL
{
    public class ChiTietDHRep : GenericRep<WebBanHoaContext, ChiTietDonHang>
    {
        public override ChiTietDonHang Read(int id)
        {
            var res = All.FirstOrDefault(p => p.MaDh == id);
            return res;
        }
        public int Remove(int id)
        {
            var m = base.All.First(i => i.MaDh == id);
            m = base.Delete(m); //TODO
            Context.SaveChanges();
            return m.MaDh;
        }
        // create 
        #region -- Methods --

        public SingleRsp CreateChiTietDH(ChiTietDonHang pro)
        {
            var res = new SingleRsp();
            using (var tran = Context.Database.BeginTransaction())
            {
                try
                {
                    var t = Context.ChiTietDonHang.Add(pro);
                    Context.SaveChanges();
                    tran.Commit();

                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    res.SetError(ex.StackTrace);
                }
            }
            return res;
        }
        #endregion
        // update
        public SingleRsp UpdateChiTietDH(ChiTietDonHang pro)
        {
            var res = new SingleRsp();
            using (var tran = Context.Database.BeginTransaction())
            {
                try
                {
                    var t = Context.ChiTietDonHang.Update(pro);
                    Context.SaveChanges();
                    tran.Commit();

                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    res.SetError(ex.StackTrace);
                }
            }
            return res;
        }
        public int DeleteChiTietDH(int id)
        {
            var m = base.All.First(i => i.MaDh == id);
            Context.ChiTietDonHang.Remove(m);
            Context.SaveChanges();
            return m.MaDh;
        }
    }
}
