using System;
using System.Collections.Generic;
using System.Text;
using WebBanHoa.Common.DAL;
using System.Linq;
using WebBanHoa.DAL.Models;
using WebBanHoa.Common.Rsp;

namespace WebBanHoa.DAL
{
    public class ChiNhanhRep : GenericRep<WebBanHoaContext, ChiNhanh>
    {
        public override ChiNhanh Read(int id)
        {
            var res = All.FirstOrDefault(p => p.MaChiNhanh == id);
            return res;
        }
        public int Remove(int id)
        {
            var m = base.All.First(i => i.MaChiNhanh == id);
            m = base.Delete(m); //TODO
            Context.SaveChanges();
            return m.MaChiNhanh;
        }
        // create 
        #region -- Methods --

        public SingleRsp CreateChiNhanh(ChiNhanh pro)
        {
            var res = new SingleRsp();
            using (var tran = Context.Database.BeginTransaction())
            {
                try
                {
                    var t = Context.ChiNhanh.Add(pro);
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
        public SingleRsp UpdateChiNhanh(ChiNhanh pro)
        {
            var res = new SingleRsp();
            using (var tran = Context.Database.BeginTransaction())
            {
                try
                {
                    var t = Context.ChiNhanh.Update(pro);
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
        public int DeleteChiNhanh(int id)
        {
            var m = base.All.First(i => i.MaChiNhanh == id);
            Context.ChiNhanh.Remove(m);
            Context.SaveChanges();
            return m.MaChiNhanh;
        }

    }
}
