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

    public class DonHangController : Controller
    {

        public DonHangController()
        {
            _svc = new DonHangSvc();
        }
        [HttpGet("get-all-donhang")]
        public IActionResult getAllNhanVienById()
        {
            var res = new SingleRsp();
            res.Data = _svc.All;
            return Ok(res);
        }
        [HttpGet("search_donhang")]
        public IActionResult SearchDonHangCtrl([FromBody] SearchDonHangReq req)
        {
            var res = new SingleRsp();
            var pros = _svc.SearchDonHang(req.Page, req.Size, req.Keyword);
            res.Data = pros;

            return Ok(res);
        }
        [HttpPost("create-donhang")]
        public IActionResult CreateDonHang([FromBody] DonHangReq req)
        {
            var res = _svc.CreateDonHang(req);

            return Ok(res);
        }
        [HttpPut("update-donhang")]
        public IActionResult UpdateDonHang([FromBody] DonHangReq req)
        {
            var res = _svc.CapnhatDonHang(req);

            return Ok(res);
        }
        [HttpDelete("delete-donhang")]
        public IActionResult DeleteDonHang(DeleteDonHangReq req)
        {
            var res = _svc.DeleteDonHang(req.MaDh);

            return Ok(res);
        }
        

        private readonly DonHangSvc _svc;
    }

}

