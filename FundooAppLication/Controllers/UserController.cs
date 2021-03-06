using BussinessLayer.Interfaces;
using CommonLayer.Model;
using CommonLayer.ResponseModel;
using CommonLayer.UserModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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
        /// API for user registration in the web application
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
                return this.BadRequest(new { Success = false, message = e.Message, InnerException = e.InnerException });
            }

        }
        /// <summary>
        /// API for getting all the data from database in the web application
        /// </summary>
        /// <returns></returns>
        //[Authorize]
        [AllowAnonymous]
        [HttpGet]
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
                return this.BadRequest(new { Success = false, message = e.Message, InnerException = e.InnerException });
            }
        }
        /// <summary>
        /// API for user login in the web application
        /// </summary>
        /// <param name="userLogin"></param>
        /// <returns></returns>
        [HttpPost("Login")]
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
                return this.BadRequest(new { Success = false, message = e.Message, InnerException = e.InnerException }); ;
            }

        }
        /// <summary>
        /// API for forgot password in the web application
        /// </summary>
        /// <param name="EmailId"></param>
        /// <returns></returns>
        [HttpPost("{emailId}/Forgotpassword")]
        public IActionResult ForgotPassword(string EmailId)
        {
            if (string.IsNullOrEmpty(EmailId))
            {
                return this.BadRequest("Email shoud not be Empty");
            }
            try
            {
                if (this.userBL.ForgotPassword(EmailId))
                {
                    return this.Ok(new { Success = true, message = "Reset link send successfully" });
                }
                else
                {
                    return this.BadRequest(new { Success = false, message = "Link sending unsuccessful" });
                }
            }

            catch (Exception e)
            {
                return this.BadRequest(new { Success = false, message = e.Message, InnerException = e.InnerException });
            }
        }
        /// <summary>
        /// API for reset password in the web application
        /// </summary>
        /// <param name="switchPassword"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPost("ResetPassword")]

        public IActionResult ResetPassword(SwitchPassword switchPassword)
        {
            try
            {
                if (this.userBL.ResetPassword(switchPassword))
                {
                    return Ok(new { Success = true, message = "Password Reset Successfully" });
                }
                else
                {
                    return BadRequest(new { Success = false, message = "Password Resetion Failed" });
                }
            }
            catch (Exception e)
            {
                return this.BadRequest(new { Success = false, message = e.Message, InnerException = e.InnerException });
            }
        }
    }
}
            
            
          
























