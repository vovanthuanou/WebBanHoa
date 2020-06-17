using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebBanHoa.BLL;
using WebBanHoa.Common.Rep;
using WebBanHoa.Common.Req;
using WebBanHoa.Common.Rsp;

namespace WebBanHoa.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ChiNhanhController : Controller
    {

        public ChiNhanhController()
        {
            _svc = new ChiNhanhSvc();
        }
        [HttpPost("get_chi-nhanh_theo_machinhanh")]
        public IActionResult getChiNhanhByMaChiNhanhbyId([FromBody] SimpleReq req)
        {
            var res = new SingleRsp();
            res = _svc.Read(req.Id);
            return Ok(res);
        }

        [HttpPost("get-all")]
        public IActionResult getAllChiNhanhById()
        {
            var res = new SingleRsp();
            res.Data = _svc.All;
            return Ok(res);
        }

        [HttpPost("search_chinhanh")]
        public IActionResult SearchChiNhanhCtrl([FromBody] SearchChiNhanhReq req)
        {
            var res = new SingleRsp();
            var pros = _svc.SearchChiNhanh(req.Page, req.Size, req.Keyword);
            res.Data = pros;

            return Ok(res);
        }

        [HttpPost("create-chinhanh")]
        public IActionResult CreateChiNhanh([FromBody] ChiNhanhReq req)
        {
            var res = _svc.CreateChiNhanh(req);

            return Ok(res);
        }
        [HttpPut("update-chinhanh")]
        public IActionResult UpdateChiNhanh([FromBody] ChiNhanhReq req)
        {
            var res = _svc.CapnhatChiNhanh(req);

            return Ok(res);
        }
        [HttpDelete("delete-chinhanh")]
        public IActionResult DeleteChiNhanh(DeleteChiNhanhReq req)
        {
            var res = _svc.DeleteChiNhanh(req.MaChiNhanh);

            return Ok(res);
        }
        

        private readonly ChiNhanhSvc _svc;
    }

}
