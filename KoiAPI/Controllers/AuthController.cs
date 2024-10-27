using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Services.IServices;
using Services.Modal.Request;
using Services.Modal.Response;

namespace KoiAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthServices _authService;

        public AuthController(IAuthServices authServices)
        {
            _authService = authServices;
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login(LoginDTO model)
        {
            var result = await _authService.AuthenticateAsync(model.Username , model.Password);

            return StatusCode((int)result.Code, result);
        }

        [HttpPost("register")]
        public IActionResult Register(RegisterDTO model)
        {
            // Implement user registration logic here

            // Once the user is registered, generate JWT token
            //return Ok(_authService.RegisterAsync(model).Result);
            var result = _authService.RegisterAsync(model).Result;
            return StatusCode((int)result.Code, result);
        }
    }
}
