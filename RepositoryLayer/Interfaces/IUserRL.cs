using CommonLayer.Model;
using CommonLayer.ResponseModel;
using CommonLayer.UserModel;
using RepositoryLayer.Context;
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
        /// <summary>
        /// This methods implements to get all registered data
        /// </summary>
        /// <returns></returns>
        IEnumerable<User> GetRegistrations();
        /// <summary>
        /// This methods implements forgot password functionality
        /// </summary>
        /// <param name="EmailId"></param>
        /// <returns></returns>
        bool ForgotPassword(string EmailId);
        /// <summary>
        /// This methods implements reset password functionality
        /// </summary>
        /// <param name="switchPassword"></param>
        /// <returns></returns>
        bool ResetPassword(SwitchPassword switchPassword);
    }
}
