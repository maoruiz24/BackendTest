namespace MusicTest.Models.Login
{
    /// <summary>
    /// Response for Login User
    /// </summary>
    public class LoginResponse
    {
        /// <summary>
        /// Code Error
        /// </summary>
        public string codeError { get; set; }
        /// <summary>
        /// Message Error
        /// </summary>
        public string msgError { get; set; }
        /// <summary>
        /// Is Valid
        /// </summary>
        public bool IsValid { get; set; }
        /// <summary>
        /// Id user
        /// </summary>
        public string IdUser { get; set; }
        /// <summary>
        /// Token
        /// </summary>
        public string Token { get; set; }
    }

}
