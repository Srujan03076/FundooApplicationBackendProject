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
        public bool Registration(UserRegistration user);

        /// <summary>
        /// This methods implements the Login functionality
        /// </summary>
        /// <param name="userLogin"></param>
        /// <returns></returns>
        LoginResponse UserLogin(UserLogin userLogin);
        /// <summary>
        /// This methods show all the data 
        /// </summary>
        /// <returns></returns>
        IEnumerable<User> GetRegistrations();
        /// <summary>
        ///  Forgot password method performs sending mail to user,for creating new password
        /// </summary>
        /// <param name="EmailId"></param>
        /// <returns></returns>
        public bool ForgotPassword(string EmailId);
        /// <summary>
        /// This methods implements the ResetPassword functionality
        /// </summary>
        /// <param name="switchPassword"></param>
        /// <returns></returns>
        public bool ResetPassword(SwitchPassword switchPassword);

        

    }
}
