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
        private ILogger<UserController> _logger;
        public UserController( UserService userService, ILogger<UserController> logger )
        {
            _userService = userService;
            _logger = logger;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        /// 可以补全啊 见笔记
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult CreateUser([FromBody] User user )
        {
            _logger.LogInformation("Create User: Received request");
            User newUser = _userService.CreateUser(user);

            _logger.LogInformation($"Create User: User created with id {newUser.Id}");
            return Created($"GetUserById",newUser);
        }  
    }
}
