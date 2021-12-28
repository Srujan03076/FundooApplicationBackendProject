using CommonLayer.Model;
using CommonLayer.ResponseModel;
using CommonLayer.UserModel;
using RepositoryLayer.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessLayer.Interfaces
{
    public interface IUserBL
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
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        IEnumerable<User> GetRegistrations();


    }
}
