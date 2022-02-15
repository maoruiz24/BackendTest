using System.Text.RegularExpressions;

namespace MusicTest.Utils
{
    public class Validate
    {
        public static bool IsValidEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                return false;
            }

            try
            {
                return Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
            }catch (Exception ex)
            {
                return false;
            }
        }

        public static bool IsStrongPassword(string password)
        {
            if (password.Length < 10)
            {
                return false;
            }

            try
            {
                return Regex.IsMatch(password, @"^.*(?=.{10,})(?=.*[a-z])(?=.*[A-Z])(?=.*[!@#?\]]).*$");
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        
    }
}
