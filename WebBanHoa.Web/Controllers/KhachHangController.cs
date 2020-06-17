using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebBanHoa.Web.Controllers
{
    using BLL;
    using DAL.Models;
    using Common.Req;
    using Common.Rsp;
    using WebBanHoa.Common.Rep;

    [Route("api/[controller]")]
    [ApiController]
    public class KhachHangController : ControllerBase
    {
        public KhachHangController()
        {
            _svc = new KhachHangSvc();
        }

        [HttpPost("get_khach-hang_theo_makh")]
        public IActionResult getKhachHangById([FromBody]SimpleReq req)
        {
            var res = new SingleRsp();
            res = _svc.Read(req.Id);
            return Ok(res);
        }

        [HttpPost("get_all")]
        public IActionResult getAllKhachHangById()
        {
            var res = new SingleRsp();
            res.Data = _svc.All;
            return Ok(res);
        }

        [HttpPost("search_khach-hang")]
        public IActionResult SearchKhachHang(SearchKhachHangReq req)
        {
            var res = new SingleRsp();
            var pros = _svc.SearchKhachHang(req.Keyword, req.Page, req.Size);
            res.Data = pros;

            return Ok(res);
        }

        [HttpPost("create_khach-hang")]
        public IActionResult CreateKhachHang([FromBody]KhachHangReq req)
        {
            var res = _svc.CreateKhachHang(req);
            return Ok(res);
        }

        [HttpPut("update_khach-hang")]
        public IActionResult UpdateKhachHang([FromBody]KhachHangReq req)
        {
            var res = _svc.UpdateKhachHang(req);
            return Ok(res);
        }

        [HttpDelete("delete_khachhang")]
        public IActionResult DeleteKhachHang(DeleteKhachHangReq req)
        {
            var res = _svc.DeleteKhachHang(req.MaKh);

            return Ok(res);
        }

        private readonly KhachHangSvc _svc;
    }
}