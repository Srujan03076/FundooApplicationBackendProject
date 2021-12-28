using CommonLayer.Model;
using CommonLayer.ResponseModel;
using CommonLayer.UserModel;
using Microsoft.IdentityModel.Tokens;
using RepositoryLayer.Context;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace RepositoryLayer.Services
{
    /// <summary>
    /// This is a UserRL class
    /// </summary>
    public class UserRL : IUserRL
    {
        private const string SecretKey = "This is my sample key ";
        FundooContext context;
        public UserRL(FundooContext context)
        {
            this.context = context;
        }

        public IEnumerable<User> GetRegistrations()
        {
            return context.Users.ToList();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool Registration(UserRegistration user)
        {
            try
            {
                User newUser = new User();
                newUser.FirstName = user.FirstName;
                newUser.LastName = user.LastName;
                newUser.EmailId = user.EmailId;
                newUser.Password = user.Password;
                newUser.Createdat = DateTime.Now;


                this.context.Users.Add(newUser);

                int result = this.context.SaveChanges();
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            catch (Exception e)
            {
                throw;
            }
        }
        /// <summary>
        /// To check the EmailId, password & Get Login
        /// </summary>
        /// <param name="userLogin"></param>
        /// <returns></returns>
        public LoginResponse UserLogin(UserLogin userLogin)
        {
            try
            {
                var validateLogin = this.context.Users.Where(x => x.EmailId == userLogin.Email && x.Password == userLogin.Password).FirstOrDefault();

                if (validateLogin.Id != 0 && validateLogin.EmailId != null)
                {
                    LoginResponse login1 = new LoginResponse();
                    string token;
                    token = GenerateJWTToken(validateLogin.EmailId);
                    login1.Id = validateLogin.Id;
                    login1.FirstName = validateLogin.FirstName;
                    login1.LastName = validateLogin.LastName;
                    login1.EmailId = validateLogin.EmailId;
                    login1.Createat = validateLogin.Createdat;
                    login1.Modifiedat = validateLogin.Modifiedat;
                    login1.token =token;
                    return login1;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {
                throw;
            }
        }
        /// <summary>
        /// This method implements generation of token
        /// </summary>
        /// <param name="EmailId"></param>
        /// <returns></returns>
        private string GenerateJWTToken(string EmailId)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("This is my sample key"));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[] {
                new Claim("EmailId",EmailId) 
            };
                
             var token = new JwtSecurityToken("Srujan", EmailId, claims,
              expires: DateTime.Now.AddMinutes(10),
              signingCredentials: credentials);
              return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}














       