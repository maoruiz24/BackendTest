using MusicTest.Models.Login;
using MusicTest.Utils;
using MusicTest.Connection;
using MusicTest.Helpers;
using MongoDB.Driver;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using MongoDB.Bson;

namespace MusicTest.Bussines
{
    public interface ILogin
    {
        bool IsValidUser(string email, string password, bool isLogin, ref string codeError, ref string msgError);
        bool EmailExist(string email);
        RegisterResponse Register(string email, string password);
        LoginResponse UserExist(string email, string password);
        User getById(string id);
    }

    public class Login: ILogin
    {
        private readonly AppSettings _appSettings;

        public Login(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }

        public bool IsValidUser(string email, string password, bool isLogin, ref string codeError, ref string msgError)
        {
            //Validate valid email 
            if (!Validate.IsValidEmail(email))
            {
                codeError = "01";
                msgError = "Email format is not valid";
                return false;
            }

            //Validate if email exists
            if (isLogin)
            {
                if (EmailExist(email))
                {
                    codeError = "02";
                    msgError = "Email doesn't exist in the database";
                    return false;
                }
            }
            else
            {
                if (!EmailExist(email))
                {
                    codeError = "02";
                    msgError = "Email already exists in the database";
                    return false;
                }
            }
            

            //Validate password length
            if (!Validate.IsStrongPassword(password))
            {
                codeError = "03";
                msgError = "Password doesn't contain at least 10 characters or does not contain one lowercase or uppercase letter";
                return false;
            }

            return true;
        }

        public bool EmailExist(string email)
        {
            try
            {
                var document = MongoContext.Database().GetCollection<User>("User");

                var user = (from p in document.AsQueryable()
                            where (p.email.Equals(email))
                            select p).FirstOrDefault();

                if (user == null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public RegisterResponse Register(string email, string password)
        {
            try
            {
                var document = MongoContext.Database().GetCollection<Models.Login.User>("User");

                var user = new Models.Login.User(){ email= email, password = password};

                document.InsertOne(user);

                return new RegisterResponse
                {
                    codeError = "00",
                    msgError = "The user has been registered",
                };
            }
            catch (Exception ex)
            {
                return new RegisterResponse
                {
                    codeError = "01",
                    msgError = ex.Message
                };
            }
        }

        public LoginResponse UserExist(string email, string password)
        {
            try
            {
                var document = MongoContext.Database().GetCollection<User>("User");

                var user = (from p in document.AsQueryable()
                            where (p.email.Equals(email) &&
                                     p.password.Equals(password))
                            select p).FirstOrDefault();

                if (user != null)
                {
                    return new LoginResponse {
                        codeError = "00",
                        msgError = "Valid User",
                        IdUser = user.Id.ToString(),
                        IsValid = true,
                        Token = generateJwtToken(user)
                    };
                }
                else
                {
                    return new LoginResponse
                    {
                        codeError = "01",
                        msgError = "Email or password are wrong",
                        IdUser = String.Empty,
                        IsValid = false,
                        Token = String.Empty
                    };
                }
            }
            catch (Exception ex)
            {
                return new LoginResponse
                {
                    codeError = "02",
                    msgError = ex.Message,
                    IdUser = String.Empty,
                    IsValid = false,
                    Token = String.Empty
                };
            }
        }

        public User getById(string id)
        {
            try
            {
                var _id = ObjectId.Parse(id);
                var document = MongoContext.Database().GetCollection<User>("User");

                var user = (from p in document.AsQueryable()
                            where (p.Id.Equals(_id))
                            select p).FirstOrDefault();

                return user;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        private string generateJwtToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
                Expires = DateTime.UtcNow.AddMinutes(20),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
