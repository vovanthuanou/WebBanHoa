using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using WebBanHoa.Common.DAL;

namespace WebBanHoa.DAL
{
    using WebBanHoa.Common.Rsp;
    using WebBanHoa.DAL.Models;
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
        public int DeleteSanPham(int id)
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

        public SingleRsp CreateSanPham(Hoa sp)
        {
            var res = new SingleRsp();
            using (var context = new WebBanHoaContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var t = context.Hoa.Add(sp);
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
        public SingleRsp UpdateSanPham(Hoa sp)
        {
            var res = new SingleRsp();
            using (var context = new WebBanHoaContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var t = context.Hoa.Update(sp);
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
