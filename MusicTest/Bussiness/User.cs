using MusicTest.Models.Login;
using MusicTest.Utils;

namespace MusicTest.Bussiness
{
    public class User
    {
        public static bool IsValidUser(string email, string password, ref RegisterResponse response)
        {
            //Validate valid email 
            if (!Validate.IsValidEmail(email))
            {
                response.codeError = "01";
                response.msgError = "Email Invalid";
                return false;
            }

            //Validate if email exists
            if (!EmailExist(email))
            {
                response.codeError = "02";
                response.msgError = "Email is wrong";
                return false;
            }

            //Validate password length
            if (!Validate.IsStrongPassword(password))
            {
                response.codeError = "03";
                response.msgError = "Password don't contain at least 10 characters or not contain one lowercase or uppercase letter";
                return false;
            }

            return true;
        }

        private static bool EmailExist(string email)
        {
            return true;
        }
    }
}
