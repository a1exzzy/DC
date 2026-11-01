using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PaintStore.API.Data;
using PaintStore.Models;

namespace PaintStore.API.Controllers
{
    [Route("api/[controller]")]
    //等于[Route("api/PaintProduct")] 
    [ApiController]
  
    public class PaintProductController : ControllerBase
    {
        //注入数据库
        private PaintStoreDbContext _dbContext; 

        public PaintProductController(PaintStoreDbContext paintStoreDb)
        {
            _dbContext = paintStoreDb;
        }


        //拿到一个paintproduct
        [HttpGet("GetPaintProduct")]
        public PaintProduct GetPaintProduct()
        {
            //还没数据库 模拟一个
            PaintProduct paintProduct = new PaintProduct( "Dulux", 100);

            return paintProduct;
        }
        [HttpGet("GetPaintProduct2")]
        public PaintProduct GetPaintProduct2()
        {
            //还没数据库 模拟一个
            PaintProduct paintProduct = new PaintProduct(  "Dulux", 100);
            
            return paintProduct;
        }

        //如果想要 通过id找到一个product PaintProduct/GetPaintProduct/1
        //最后这个1就会作为参数进去 这个是路由机制的一部分
        //那么路由就是 /{id}

        [HttpGet("GetPaintProduct/{id}")]

        public ActionResult GetPaintProductById(int id)
        {
            //向dbcontext拿数据
            // _dbContext.PaintProducts我们需要的是paintproduct表的数据
            //.FirstOrDefault找id
            //因为既可能是null也可能是PaintProduct
            //所以变成 可空类型 -- nullablt
            PaintProduct? paintProduct = _dbContext.PaintProducts.FirstOrDefault(p => p.Id == id);
            
            if(paintProduct == null)
            {
                return NotFound($"PaintProduct with Id: {id} cannot be found");
            }

            return Ok(paintProduct);           
        }

        //练习 CreateProduct
        [HttpPost]
        public ActionResult CreatePaintProduct ([FromBody] PaintProduct paintProduct)
        {
            _dbContext.PaintProducts.Add(paintProduct);
            _dbContext.SaveChanges();
            return Created($"GetPaintProductById/{paintProduct.Id}",paintProduct);
        }

    }
}
