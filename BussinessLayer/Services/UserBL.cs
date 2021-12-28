using BussinessLayer.Interfaces;
using CommonLayer.Model;
using CommonLayer.ResponseModel;
using CommonLayer.UserModel;
using RepositoryLayer.Context;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessLayer.Services
{
    /// <summary>
    /// This is a class for UserBL
    /// </summary>
    public class UserBL : IUserBL
    {
        IUserRL userRL;
        public UserBL(IUserRL userRL)
        {
            this.userRL = userRL;

        }

        public IEnumerable<User> GetRegistrations()
        {
            return this.userRL.GetRegistrations();
        }

        public bool Registration(UserRegistration user)
        {
            try
            {
                return this.userRL.Registration(user);
            }
            catch (Exception e)
            {
                throw;
            }
            
        }

        public LoginResponse UserLogin(UserLogin userLogin)
        {
            {
                try
                {
                    return this.userRL.UserLogin(userLogin);
                }
                catch (Exception e)
                {
                    throw;
                }

            }
        }
    }
}
