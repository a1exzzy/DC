using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PaintStore.Models;

namespace PaintStore.API.Controllers
{
    [Route("api/[controller]")]
    //等于[Route("api/PaintProduct")] 
    [ApiController]
    public class PaintProductController : ControllerBase
    {
        //拿到一个paintproduct
        [HttpGet("GetPaintProduct")]
        public PaintProduct GetPaintProduct()
        {
            //还没数据库 模拟一个
            PaintProduct paintProduct = new PaintProduct(1, "Dulux", 100);

            return paintProduct;
        }
        [HttpGet("GetPaintProduct2")]
        public PaintProduct GetPaintProduct2()
        {
            //还没数据库 模拟一个
            PaintProduct paintProduct = new PaintProduct(1, "Dulux", 100);
            
            return paintProduct;
        }

        //如果想要 通过id找到一个product PaintProduct/GetPaintProduct/1
        //最后这个1就会作为参数进去 这个是路由机制的一部分
        //那么路由就是 /{id}

        [HttpGet("GetPaintProduct/{id}")]

        public ActionResult GetPaintProductById(int id)
        {
            //还没数据库 模拟一个
            PaintProduct paintProduct = new PaintProduct(1, "Dulux", 100);

            if(id == paintProduct.Id)
            {
                return Ok(paintProduct);
            }
            
            return NotFound();
        }

    }
}
