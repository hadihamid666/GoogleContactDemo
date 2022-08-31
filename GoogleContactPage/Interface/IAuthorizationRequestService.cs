using GoogleContactPage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoogleContactPage.Interface
{
    public interface IAuthorizationRequestService
    {
        public List<UserRegistration> GetAuthorizationRequestList();
        ResponseModel AuthorizatedUser(AuthorizedUserRequest authInfo);
       /* public ResponseModel CancleAuthorizatedUser(int authId);*/


    }
}
