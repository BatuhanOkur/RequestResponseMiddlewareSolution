using BOMiddleware.TestApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BOMiddleware.TestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> logger;

        public UserController(ILogger<UserController> logger)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpGet("{id}")]
        public IActionResult GetUserInfo(int id) 
        {
            logger.LogInformation("Hello from GetUserInfo method.");

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
            logger.LogInformation("Hello from Login method.");

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
            logger.LogInformation("Hello from LoginOnly method.");
            return Ok();
        }
    }
}
