using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PaintStore.Models;
using PaintStore.API.Data;

namespace PaintStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        //直接把dbcontext注入到这个controller里
        private PaintStoreDbContext _dbContext;//下划线代表私有字段
        public UserController(PaintStoreDbContext paintStoreDb)
        {
            //重要！！！
            _dbContext = paintStoreDb;
        }


        [HttpPost]
        public ActionResult CreateUser([FromBody] User user )
        {
            //访问数据库：add only mark user to be added并没有真的已经传入了 就像是commit了 

            _dbContext.Users.Add(user);

            //真正的存：
            _dbContext.SaveChanges();

            return Created($"GetUserById",user);
        }
            


        /*
        [HttpGet("CreateUser2")]
        public ActionResult CreateUser2(int id, string name, string email)
        {

            User result = new User(id,name,email);
            return Ok(result);
        }*/
    }
}
