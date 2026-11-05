using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PaintStore.Models;
using PaintStore.API.Data;
using PaintStore.API.Services;

namespace PaintStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private UserService _userService;
        public UserController( )
        { 
        }

        [HttpPost]
        public ActionResult CreateUser([FromBody] User user )
        {
            User newUser = _userService.CreateUser(user);

            return Created($"GetUserById",user);
        }  
    }
}
