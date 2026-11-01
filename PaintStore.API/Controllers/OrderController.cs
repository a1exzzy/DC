using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PaintStore.API.Data;
using PaintStore.Models;
using PaintStore.Models.DTOs;



namespace PaintStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {   
        //暂时的order数据 mock data
        //private List<Order> OrdersData;
        private PaintStoreDbContext _dbContext;

        public OrderController(PaintStoreDbContext paintStoreDb)
        {
            _dbContext = paintStoreDb;

            //OrdersData = new List<Order>();
        }

        // public Order(int id, List<PaintProduct> paintProducts, DateTime creatAt)
        //[HttpGet("GetOrder/{id}")]
        [HttpGet("{id}")]
        public ActionResult GetOrderById (int id)
        {
            Order order = new Order();
            if (id == order.Id)
            {
                return Ok(order);
            }
            return NotFound();
        }


        //Create an order
        //key-value data ----> {}----> json
        [HttpPost]
        public ActionResult CreateOrder([FromBody]OrderCreateDto orderCreateDto)
        {
            Order order = new Order();
            //把user关联上
            order.UserId = orderCreateDto.UserId;
            //
            List<PaintProduct> paintProducts = _dbContext.PaintProducts.Where(p => orderCreateDto.PaintProductIds.Contains(p.Id)).ToList();
      
            //把paintproduct数据关联上
            order.PaintProducts = paintProducts;

            _dbContext.Orders.Add(order);
            _dbContext.SaveChanges();
            return Created($"GetOrderById/{order.Id}",order);

        }



/*
        //Create an order
        //key-value data ----> {}----> json
        [HttpPost]
        public ActionResult CreateOrder([FromBody]Order order){
            // if(order.Id == 0)
            // {
            //     throw new Exception("Order id is invalid");
            // }

            //假设这个是数据库传来的数据 
            
            order.Id = 100;

            if (order.PaintProducts.Count <= 0)
            {
                throw new Exception("Cannot create empty order since paintproducts number <=0");
            }
            
            //我们暂时的Order数据
            ////OrdersData.Add(order);
            
            //我们想要返回201
            //return StatusCode(201);
            //或者
            //return Created();
            //或者给一个路径 
            return Created($"GetOrderById/{order.Id}", order);
        }

        //Query order with id > 10 < 1000, return all the orders matching

        //We can use QueryString to pass multiple parameters

        //relyon URL to pass ----> http://localhost:5065/api/Order/GetOrderWithPrice?minPrice=10&maxPRice=1000



        [HttpGet("GetPriceWithPriceRange")]
        public ActionResult GetOrderWithPriceRange([FromQuery] decimal minPrice, [FromQuery] decimal maxPrice)
        {

            //手动模拟
            ////OrdersData.Add(new Order());
            List<Order> orders = OrdersData.Where(o => o.TotalPrice > minPrice && o.TotalPrice < maxPrice).ToList();

            return Ok(orders);

            //这里回到Order class 新增了价格
        }

        //作业
        //Create an endpoint GetPaginatedOrders,传入参数：pageNumber(int),pageSize(int),
        [HttpGet("GetPaginatedOrders")]
        public ActionResult GetPaginatedOrders(int pageNumber, int pageSize)
        {
            OrdersData.Add(new Order());
            OrdersData.Add(new Order());
            OrdersData.Add(new Order());
            OrdersData.Add(new Order());
            OrdersData.Add(new Order());
            OrdersData.Add(new Order());

            List<Order> result = OrdersData.Skip((pageNumber-1) * pageSize).Take(pageSize).ToList();
            
            return Ok(result);
        }
        */
    }
}
