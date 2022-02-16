using MusicTest.Models.Login;
using MusicTest.Bussiness;
using MusicTest.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace MusicTest.Controllers
{
    [Route("api/login")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILogin _login;

        public LoginController(ILogin login)
        {
            _login = login;
        }

        [HttpPost]
        [Route("v1/register")]
        public IActionResult Register([FromBody] RegisterRequest user)
        {
            string codError = String.Empty, msgError = String.Empty;

            if (!_login.IsValidUser(user.email, user.password, false, ref codError, ref msgError))
            {
                return BadRequest(
                    new RegisterResponse
                    {
                        codeError = codError,
                        msgError = msgError
                    });
                ;
            }

            return Ok(_login.Register(user.email, user.password));
        }

        [HttpPost]
        [Route("v1/login")]
        public IActionResult Login([FromBody] LoginRequest user)
        {
            string codError = String.Empty, msgError = String.Empty;

            if (!_login.IsValidUser(user.email, user.password, true, ref codError, ref msgError))
            {
                return BadRequest(
                    new LoginResponse{
                        codeError = "01",
                        msgError = "Email or password is wrong",
                        IdUser = String.Empty,
                        IsValid = false,
                        Token = String.Empty
                    });
            }

            return Ok(_login.UserExist(user.email, user.password));
        }
    }
}
