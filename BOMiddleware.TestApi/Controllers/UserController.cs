using BOMiddleware.TestApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BOMiddleware.TestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet("{id}")]
        public IActionResult GetUserInfo(int id) 
        { 
            var user = new UserLoginResponseModel()
            {
                Success = true,
                UserEmail = "okurbatuhan@outlook.com"
            };

            return Ok(user);
        }

        [HttpPost]
        [Route("login")]
        public IActionResult Login([FromBody] UserLoginRequestModel model)
        {
            var user = new UserLoginResponseModel()
            {
                Success = true,
                UserEmail = "okurbatuhan@outlook.com"
            };

            return Ok(user);
        }

        [HttpPost]
        [Route("loginonly")]
        public IActionResult LoginOnly([FromBody] UserLoginRequestModel model)
        {
            return Ok();
        }
    }
}
