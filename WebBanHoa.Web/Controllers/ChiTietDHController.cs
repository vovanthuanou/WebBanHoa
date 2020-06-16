using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebBanHoa.BLL;
using WebBanHoa.Common.Rep;
using WebBanHoa.Common.Req;
using WebBanHoa.Common.Rsp;

namespace WebBanHoa.Web.Controllers
{

    [Route("api/[controller]")]
    [ApiController]

    public class ChiTietDHController : Controller
    {
        public ChiTietDHController()
        {
            _svc = new ChiTietDHSvc();
        }

        [HttpPost("get-by-id")]
        public IActionResult getCHitietById([FromBody]SimpleReq req)
        {
            var res = new SingleRsp();
            res = _svc.Read(req.Id);
            return Ok(res);
        }

        [HttpGet("get-all")]
        public IActionResult getAllchitietById()
        {
            var res = new SingleRsp();
            res.Data = _svc.All;
            return Ok(res);
        }
        [HttpPost("create-chitiet-donhang")]
        public IActionResult CreateChiTietDonHang([FromBody] ChiTietDHReq req)
        {
            var res = _svc.CreateChiTietDH(req);

            return Ok(res);
        }
        [HttpPut("update-chitiet-donhang")]
        public IActionResult UpdateChiTietDonHangCtrl([FromBody] ChiTietDHReq req)
        {
            var res = _svc.UpdateChiTietDH(req);

            return Ok(res);
        }

        [HttpDelete("delete-chitiet-donhang")]
        public IActionResult DeleteChitietDonHangCtrl(DeleteChiTietDHReq req)
        {
            var res = _svc.DeleteChiTietDH(req.MaDh);

            return Ok(res);
        }
        [HttpPost("search-chitiet-donhang")]
        public IActionResult SearchCTDonHangCtrl([FromBody] SearchChiTietDHReq req)
        {
            var res = new SingleRsp();
            var pros = _svc.SearchChiTietDH(req.Page, req.Size, req.Keyword);
            res.Data = pros;

            return Ok(res);
        }

        private readonly ChiTietDHSvc _svc;
    }
}
