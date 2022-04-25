using FDB.UsersAPI.Data.Dtos;
using FDB.UsersAPI.Services;
using FluentResults;
using Microsoft.AspNetCore.Mvc;

namespace FDB.UsersAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RegisterController : Controller
    {
        private RegisterService _register;

        public RegisterController(RegisterService register)
        {
            _register = register;
        }

        [HttpPost]
        public IActionResult SignUp(CreateUserDto newUserDto)
        {
            Result result = _register.RegisterUser(newUserDto);

            if (result.IsFailed)
            {
                return StatusCode(500);
            }

            return Ok();
        }
    }
}
