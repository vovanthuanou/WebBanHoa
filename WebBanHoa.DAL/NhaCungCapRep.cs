using System;
using System.Collections.Generic;
using System.Text;
using WebBanHoa.Common.DAL;
using System.Linq;

namespace WebBanHoa.DAL
{
    using WebBanHoa.Common.Rsp;
    using WebBanHoa.DAL.Models;
    public class NhaCungCapRep : GenericRep<WebBanHoaContext, NhaCungCap>
    {
        #region --Override--
        public override NhaCungCap Read(int id)
        {
            var res = All.FirstOrDefault(p => p.MaNcc == id);
            return res;
        }
        public int Remove(int id)
        {
            var m = base.All.First(i => i.MaNcc == id);
            m = base.Delete(m);
            return m.MaNcc;
        }
        #endregion
        #region -- Methods --
        public SingleRsp CreateNhaCungCap(NhaCungCap Ncc)
        {
            var res = new SingleRsp();
            using (var context = new WebBanHoaContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var t = context.NhaCungCap.Add(Ncc);
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

        #endregion
        public SingleRsp UpdateNhaCungCap(NhaCungCap Ncc)
        {
            var res = new SingleRsp();
            using (var context = new WebBanHoaContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var t = context.NhaCungCap.Update(Ncc);
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
        public int DeleteNhaCungCap(int id)
        {
            var m = base.All.First(i => i.MaNcc == id);
            Context.NhaCungCap.Remove(m);
            Context.SaveChanges();
            return m.MaNcc;
        }
    }
}