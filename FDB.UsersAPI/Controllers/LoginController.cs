using FDB.UsersAPI.Data.Request;
using FDB.UsersAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace FDB.UsersAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LoginController : Controller
    {
        private LoginService _login;

        public LoginController(LoginService login)
        {
            _login = login;
        }

        [HttpPost]
        public IActionResult LoginUser(LoginRequest request)
        {
            var result = _login.LoginUser(request);

            if (result.IsFailed)
            {
                return Unauthorized(result.Errors);
            }
            return Ok(result.Successes);
        }
    }
}
