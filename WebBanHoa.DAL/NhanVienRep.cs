using System;
using System.Collections.Generic;
using System.Text;
using WebBanHoa.Common.DAL;
using System.Linq;

namespace WebBanHoa.DAL
{
    using WebBanHoa.Common.Rsp;
    using WebBanHoa.DAL.Models;
    public class NhanVienRep : GenericRep<WebBanHoaContext, NhanVien>
    {
        #region --Override--
        public override NhanVien Read(int id)
        {
            var res = All.FirstOrDefault(p => p.MaNv == id);
            return res;
        }
        public int Remove(int id)
        {
            var m = base.All.First(i => i.MaNv == id);
            m = base.Delete(m);
            return m.MaNv;
        }
        #endregion

        #region --Methods--
        public SingleRsp CreateNhanVien(NhanVien nv)
        {
            var res = new SingleRsp();
            using(var context = new WebBanHoaContext())
            {
                using(var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var T = context.NhanVien.Add(nv);
                        context.SaveChanges();
                        tran.Commit();
                    }
                    catch(Exception ex)
                    {
                        tran.Rollback();
                        res.SetError(ex.StackTrace);
                    }
                }
            }
            return res;
        }

        public SingleRsp UpdateNhanVien(NhanVien nv)
        {
            var res = new SingleRsp();
            using (var context = new WebBanHoaContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var T = context.NhanVien.Update(nv);
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
    }
}
