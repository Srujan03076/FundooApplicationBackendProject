using CommonLayer.Model;
using CommonLayer.ResponseModel;
using CommonLayer.UserModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
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

        FundooContext context;
        IConfiguration _config;

        public UserRL(FundooContext _context, IConfiguration _config)
        {
            this.context = _context;
            this._config = _config;
        }
        /// <summary>
        /// This method implements getting all the user data from database
        /// </summary>
        /// <returns></returns>

        public IEnumerable<User> GetRegistrations()
        {
            return context.UserTable.ToList();
        }
        /// <summary>
        /// This method implements registraton of user
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
                newUser.Password = encryptpass(user.Password);
                newUser.Createdat = DateTime.Now;


                this.context.UserTable.Add(newUser);

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
                var validateLogin = this.context.UserTable.Where(x => x.EmailId == userLogin.Email).FirstOrDefault();
                if (Decryptpass(validateLogin.Password) == userLogin.Password)
                {
                    LoginResponse login1 = new LoginResponse();
                    string token;
                    token = GenerateJWTToken(validateLogin.EmailId,validateLogin.Id);
                    login1.Id = validateLogin.Id;
                    login1.FirstName = validateLogin.FirstName;
                    login1.LastName = validateLogin.LastName;
                    login1.EmailId = validateLogin.EmailId;
                    login1.Createat = validateLogin.Createdat;
                    login1.Modifiedat = validateLogin.Modifiedat;
                    login1.token = token;
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
        private string GenerateJWTToken(string EmailId,long Id)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[] {
                new Claim("EmailId",EmailId),
                new Claim("Id",Id.ToString())
            };


            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
        _config["Jwt:Issuer"],
        claims,
        expires: DateTime.Now.AddMinutes(10),
        signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        /// <summary>
        /// This method implements encryption of password 
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public string encryptpass(string password)
        {
            string msg = "";
            byte[] encode = new byte[password.Length];
            encode = Encoding.UTF8.GetBytes(password);
            msg = Convert.ToBase64String(encode);
            return msg;
        }
        /// <summary>
        /// This method implements decryption of password 
        /// </summary>
        /// <param name="encryptpwd"></param>
        /// <returns></returns>
        private string Decryptpass(string encryptpwd)
        {
            string decryptpwd = string.Empty;
            UTF8Encoding encodepwd = new UTF8Encoding();
            Decoder Decode = encodepwd.GetDecoder();
            byte[] todecode_byte = Convert.FromBase64String(encryptpwd);
            int charCount = Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length);
            char[] decoded_char = new char[charCount];
            Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);
            decryptpwd = new String(decoded_char);
            return decryptpwd;
        }
        /// <summary>
        /// This method implements forgot password  
        /// </summary>
        /// <param name="EmailId"></param>
        /// <returns></returns>
        public bool ForgotPassword(string EmailId)
        {
            var validateLogin = this.context.UserTable.Where(Z => Z.EmailId == EmailId).FirstOrDefault();
            if (validateLogin.EmailId != null)
            {
                var token = GenerateJWTToken(validateLogin.EmailId,validateLogin.Id);
                new MsmqOperation().Sender(token);
                return true;
            }
            return false;
        }
        /// <summary>
        /// This method implements reset password 
        /// </summary>
        /// <param name="switchPassword"></param>
        /// <returns></returns>
        public bool ResetPassword(SwitchPassword switchPassword)
        {

            var validateLogin = this.context.UserTable.SingleOrDefault(R => R.EmailId == switchPassword.EmailId);
            if (validateLogin.EmailId != null)
            {
                context.UserTable.Attach(validateLogin);
                validateLogin.Password = switchPassword.ConfirmPassword;
                context.SaveChanges();
                return true;
            }
            else
            {
                return false;

            }
        }
    }
}

        
































