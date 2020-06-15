using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebBanHoa.Web.Controllers
{
    using BLL;
    using System.Collections;
    using DAL.Models;
    using Common.Rsp;
    using Common.Req;
    using WebBanHoa.Common;
    using WebBanHoa.Common.Rep;

    [Route("api/[controller]")]
    [ApiController]
    public class SanPhamController : Controller
    {
        public SanPhamController()
        {
            _svc = new SanPhamSvc();
        }
        [HttpGet("Search-SanPham")]
        public IActionResult SearchSanPham([FromBody]SearchSanPhamReq req)
        {
            var res = new SingleRsp();
            var pros = _svc.SearchSanPham(req.Keyword, req.page, req.size);
            res.Data = pros;
            return Ok(res);
        }
        [HttpGet("Get-all-SanPham")]
        public IActionResult GetAll()
        {
            var res = new SingleRsp();
            res.Data = _svc.All;
            return Ok(res);
        }
        [HttpPost("Create-SanPham")]
        public IActionResult CreateSanPham([FromBody]SanPhamReq req)
        {
            var res = _svc.CreateSanPham(req);
            return Ok(res);
        }

        [HttpPut("Update-SanPham")]
        public IActionResult UpdateSanPham([FromBody]SanPhamReq req)
        {
            var res = _svc.UpdateSanPham(req);
            return Ok(res);
        }
        
        [HttpDelete("delete-SanPham")]
        public IActionResult DeleteSanPham([FromBody]DeleteSanPhamReq req)
        {
            var res = _svc.DeleteSanPham(req.MaHoa);

            return Ok(res);
        }
        private readonly SanPhamSvc _svc;
    }
}
