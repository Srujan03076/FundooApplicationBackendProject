using CommonLayer.Model;
using CommonLayer.ResponseModel;
using CommonLayer.UserModel;
using RepositoryLayer.Context;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RepositoryLayer.Services
{
    public class UserRL : IUserRL
    {
        FundooContext context;
        public UserRL(FundooContext context)
        {
            this.context = context;
        }
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

        public LoginResponse UserLogin(UserLogin userLogin)
        {
            try
            {
                var validateLogin = this.context.Users.Where(x => x.EmailId == userLogin.Email && x.Password == userLogin.Password).FirstOrDefault();

                if (validateLogin.Id != 0 && validateLogin.EmailId != null)  
                {
                    LoginResponse login1 = new LoginResponse();
                    login1.Id = validateLogin.Id;
                    login1.FirstName = validateLogin.FirstName;
                    login1.LastName = validateLogin.LastName;
                    login1.EmailId = validateLogin.EmailId;
                    login1.Createat = validateLogin.Createdat;
                    login1.Modifiedat = validateLogin.Modifiedat;
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
    }
}


       