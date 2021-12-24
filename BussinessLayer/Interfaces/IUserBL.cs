using CommonLayer.Model;
using CommonLayer.ResponseModel;
using CommonLayer.UserModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessLayer.Interfaces
{
    public interface IUserBL
    {
         bool Registration(UserRegistration user);
        LoginResponse UserLogin(UserLogin userLogin);
        
    }
}
