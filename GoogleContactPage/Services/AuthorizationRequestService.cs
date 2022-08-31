using GoogleContactPage.Interface;
using GoogleContactPage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoogleContactPage.Services
{
    public class AuthorizationRequestService : IAuthorizationRequestService
    {
        private readonly ModelContext _context;

        public AuthorizationRequestService(ModelContext context)
        {
            _context = context;
        }
        public List<UserRegistration> GetAuthorizationRequestList()
        {
            var user = _context.UserRegistrations.OrderByDescending(x => x.Id).Where(x => x.IsAuthorized == "0").ToList();
            return user;
        }

        public ResponseModel AuthorizatedUser(AuthorizedUserRequest authInfo)
        {
            ResponseModel model = new ResponseModel();
            try
            {
                var _temp = _context.UserRegistrations.FirstOrDefault(x => x.Id == authInfo.Id);
                if (_temp != null)
                {
                    if (authInfo.IsAuthorized == "Y")
                        _temp.IsAuthorized = "1";
                    else
                    {
                        _temp.IsAuthorized = "C";
                    }
                }
                _context.UserRegistrations.Update(_temp);
                _context.SaveChanges();
                model.Messsage = "User Authorization Successfully";
                model.IsSuccess = true;
            }
            catch (Exception ex)
            {
                model.IsSuccess = false;
                model.Messsage = "Error : " + ex.Message;
            }
            return model;
        }
    }
}
