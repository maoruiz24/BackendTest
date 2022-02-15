using MusicTest.Models.Login;
using MusicTest.Bussiness;
using Microsoft.AspNetCore.Mvc;


namespace MusicTest.Controllers
{
    [Route("api/login")]
    [ApiController]
    public class LoginController : ControllerBase
    {

        [HttpPost]
        [Route("v1/register")]
        public RegisterResponse Register([FromBody] RegisterRequest user)
        {
            RegisterResponse res = new RegisterResponse();

            if (Bussiness.User.IsValidUser(user.email, user.password, ref res))
            {
                return res;
            }
                        
            res.codeError = "00";
            res.msgError = "Register sussecfull";

            return res;
        }

        [HttpPost]
        [Route("v1/login")]
        public RegisterResponse Login([FromBody] RegisterRequest user)
        {
            RegisterResponse res = new RegisterResponse();

            if (Bussiness.User.IsValidUser(user.email, user.password, ref res))
            {
                return res;
            }

            res.codeError = "00";
            res.msgError = "Register sussecfull";

            return res;
        }
    }
}
