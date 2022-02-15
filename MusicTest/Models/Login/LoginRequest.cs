namespace MusicTest.Models.Login
{
    /// <summary>
    /// Request for login User
    /// </summary>
    public class LoginRequest
    {
        /// <summary>
        /// Email User
        /// </summary>
        public string email { get; set; }
        /// <summary>
        /// Password User
        /// </summary>
        public string password { get; set; }
    }
}
