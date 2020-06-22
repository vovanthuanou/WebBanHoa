using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebBanHoa.Common.Rep;
using WebBanHoa.Common.Rsp;

namespace WebBanHoa.Web.Controllers
{
    using BLL;
    using DAL.Models;
    using Common.Req;
    using Common.Rsp;
    using WebBanHoa.Common.Rep;

    [Route("api/[controller]")]
    [ApiController]
    public class NhaCungCapController : ControllerBase
    {
        public NhaCungCapController()
        {
            _svc = new NhaCungCapSvc();
        }
        [HttpPost("get_nhacungcap_theo_mancc")]
        public IActionResult getNhaCungCapById([FromBody]SimpleReq req)
        {
            var res = new SingleRsp();
            res = _svc.Read(req.Id);
            return Ok(res);
        }

        [HttpPost("get_all")]
        public IActionResult getAllNhaCungCapById()
        {
            var res = new SingleRsp();
            res.Data = _svc.All;
            return Ok(res);
        }

        [HttpPost("search_nhacungcap")]
        public IActionResult SearchNhaCungCapCtrl([FromBody] SearchNhaCungCapReq req)
        {
            var res = new SingleRsp();
            var pros = _svc.SearchNhaCungCap(req.Page, req.Size, req.Keyword);
            res.Data = pros;

            return Ok(res);
        }

        [HttpPost("create_nhacungcap")]
        public IActionResult CreateNhaCungCap([FromBody] NhaCungCapReq req)
        {
            var res = _svc.CreateNhaCungCap(req);

            return Ok(res);
        }
        [HttpPost("update_nhacungcap")]
        public IActionResult UpdateNhaCungCap([FromBody] NhaCungCapReq req)
        {
            var res = _svc.UpdateNhaCungCap(req);

            return Ok(res);
        }
        [HttpPost("delete_nhacungcap")]
        public IActionResult DeleteNhaCungCap(DeleteNhaCungCapReq req)
        {
            var res = _svc.DeleteNhaCungCap(req.MaNcc);

            return Ok(res);
        }
        


        private readonly NhaCungCapSvc _svc;



    }
}