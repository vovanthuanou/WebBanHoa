using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebBanHoa.Common.DAL;
using WebBanHoa.Common.Rsp;
using WebBanHoa.DAL.Models;

namespace WebBanHoa.DAL
{
    public class SanPhamRep : GenericRep<WebBanHoaContext, Hoa>
    {
        #region --Overrides--
        ///<summary>
        /// Read single object
        /// </summary>
        ///<param name = 'Id'>Primary key  </param>"
        ///<returns> Return the object </returns>


        public override Hoa Read(int id)
        {
            var res = All.FirstOrDefault(p => p.MaHoa == id);
            return res;
        }
        ///<summary>
        /// Remove not restore 
        /// </summary>
        ///<param name = 'Id'>Primary key  </param>"
        ///<returns> Number of affect </returns>
        public int remove(int id)
        {
            var m = base.All.First(p => p.MaHoa == id);
            m = base.Delete(m); //TODO
            return m.MaHoa;
        }
        #endregion

        #region Method
        ///<summary> Initialize 
        ///</summary>
        ///

        public SingleRsp CreateProduct(Hoa pro)
        {
            var res = new SingleRsp();
            using (var context = new WebBanHoaContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var t = context.Hoa.Add(pro);
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
        public SingleRsp UpdateProduct(Hoa pro)
        {
            var res = new SingleRsp();
            using (var context = new WebBanHoaContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var t = context.Hoa.Update(pro);
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
        public int DeleteSanPham(int id)
        {
            var m = base.All.First(i => i.MaHoa == id);
            Context.Hoa.Remove(m);
            Context.SaveChanges();
            return m.MaHoa;
        }
        #endregion
    }
}
