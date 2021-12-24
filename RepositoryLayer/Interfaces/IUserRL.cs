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
          bool Registration(UserRegistration user);
        LoginResponse UserLogin(UserLogin userLogin);
        
    }
}
