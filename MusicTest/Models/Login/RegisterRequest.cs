namespace MusicTest.Models.Login
{
    /// <summary>
    /// Request for Register User
    /// </summary>
    public class RegisterRequest
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
