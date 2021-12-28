﻿using BussinessLayer.Interfaces;
using CommonLayer.Model;
using CommonLayer.ResponseModel;
using CommonLayer.UserModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FundooAppLication.Controllers
{

    [Route("api/[controller]")]
    [ApiController]

    /// <summary>
    /// It is a class for UserController
    /// </summary>

    public class UserController : ControllerBase
    {
        private readonly IUserBL userBL;
        public UserController(IUserBL userBL)
        {
            this.userBL = userBL;
        }
        /// <summary>
        ///  This method is used for User Registration in the web application
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult UserRegistration(UserRegistration user)
        {
            try
            {
                if (this.userBL.Registration(user))
                {
                    return this.Ok(new { Success = true, message = "Registration Successful" });
                }
                else
                {
                    return this.BadRequest(new { Success = false, message = "Registration unsuccessful" });
                }
            }
            catch (Exception e)
            {
                return this.BadRequest(new { Success = false, message = e.Message });
            }

        }
        /// <summary>
        /// This method is used for get all the data of user in the web application
        /// </summary>
        /// <returns></returns>
        [HttpGet("userdetails")]
        public IActionResult GetRegistrations()
        {
            try
            {
                var userDetails = this.userBL.GetRegistrations();
                if (userDetails == null)
                {
                    return this.BadRequest(new { Success = false, message = " User records not found" });
                }
                return this.Ok(new { Success = true, message = "User records found", userdata = userDetails });
            }
            catch (Exception e)
            {
                return this.BadRequest(new { Success = false, message = e.Message });
            }
        }
        /// <summary>
        ///  This method is used for User Login in the web application
        /// </summary>
        /// <param name="userLogin"></param>
        /// <returns></returns>
        [HttpPost("login")]
        public IActionResult UserLogin(UserLogin userLogin)
        {
            try
            {
                LoginResponse result = this.userBL.UserLogin(userLogin);
                if (result.EmailId == null)
                {
                    return this.BadRequest(new { Success = false, message = "Email or Password not Found" });
                }
                return this.Ok(new { Success = true, message = "Login Successful", data = result });
            }
            catch (Exception e)
            {
                return this.BadRequest(new { Success = false, message = e.Message });
            }

        }
    }
}



        
        

    

    


