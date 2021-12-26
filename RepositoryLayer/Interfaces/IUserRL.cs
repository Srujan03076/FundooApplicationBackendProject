using CommonLayer.Model;
using CommonLayer.ResponseModel;
using CommonLayer.UserModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interfaces
{
    public interface IUserRL
    {
        /// <summary>
        /// This methods implements the Registration functionality
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        bool Registration(UserRegistration user);
        /// <summary>
        /// This methods implements the Login functionality
        /// </summary>
        /// <param name="userLogin"></param>
        /// <returns></returns>
        LoginResponse UserLogin(UserLogin userLogin);
        
    }
}
