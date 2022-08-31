using GoogleContactPage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoogleContactPage.Interface
{
    public interface IUserLoginService
    {
        public ResponseModel LoginUser(LoginRequest loginRequest);
    }
}
