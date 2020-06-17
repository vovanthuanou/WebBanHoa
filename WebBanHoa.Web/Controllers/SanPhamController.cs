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
    public class SanPhamController : ControllerBase
    {
        public SanPhamController()
        {
            _svc = new SanPhamSvc();
        }

        [HttpPost("get_sanpham_theo_mahoa")]
        public IActionResult getSanPhamById([FromBody]SimpleReq req)
        {
            var res = new SingleRsp();
            res = _svc.Read(req.Id);
            return Ok(res);
        }

        [HttpPost("get_all")]
        public IActionResult GetAll()
        {
            var res = new SingleRsp();
            res.Data = _svc.All;
            return Ok(res);
        }
        [HttpPost("search_sanpham")]
        public IActionResult SearchSanPham(SearchSanPhamReq req)
        {
            var res = new SingleRsp();
            var pros = _svc.SearchSanPham(req.Keyword, req.page, req.size);
            res.Data = pros;
            return Ok(res);
        }
        [HttpPost("creat_sanPham")]
        public IActionResult CreateProduct([FromBody]SanPhamReq req)
        {
            var res = _svc.CreateProduct(req);
            return Ok(res);
        }

        [HttpPut("update_sanpham")]
        public IActionResult UpdateProduct([FromBody]SanPhamReq req)
        {
            var res = _svc.UpdateProduct(req);
            return Ok(res);
        }
        [HttpDelete("delete_sanpham")]
        public IActionResult DeleteSanPham([FromBody]DeleteSanPhamReq req)
        {
            var res = _svc.DeleteSanPham(req.MaHoa);

            return Ok(res);
        }

        private readonly SanPhamSvc _svc;
    }
}