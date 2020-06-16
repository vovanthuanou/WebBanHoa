using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebBanHoa.Common.DAL;
using WebBanHoa.Common.Rsp;
using WebBanHoa.DAL.Models;


namespace WebBanHoa.DAL
{
   
        public class DonHangRep : GenericRep<WebBanHoaContext, DonHang>
        {

            public override DonHang Read(int id)
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

            public SingleRsp CreateDonHang(DonHang pro)
            {
                var res = new SingleRsp();
                using (var tran = Context.Database.BeginTransaction())
                {
                    try
                    {
                        var t = Context.DonHang.Add(pro);
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
            public SingleRsp UpdateDonHang(DonHang pro)
            {
                var res = new SingleRsp();
                using (var tran = Context.Database.BeginTransaction())
                {
                    try
                    {
                        var t = Context.DonHang.Update(pro);
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
            public int DeleteDonHang(int id)
            {
                var m = base.All.First(i => i.MaDh == id);
                Context.DonHang.Remove(m);
                Context.SaveChanges();
                return m.MaDh;
            }

        }
    }
