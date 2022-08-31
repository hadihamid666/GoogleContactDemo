using GoogleContactPage.Interface;
using GoogleContactPage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoogleContactPage.Services
{
    public class UserRegistrationsService: IUserRegistrationsService
    {
        private readonly ModelContext _context;

        public UserRegistrationsService(ModelContext context)
        {
            _context = context;
        }

        //Get All User List
        public List<UserRegistration> GetUserList()
        {

            var UserList = _context.UserRegistrations.OrderByDescending(x => x.Id).ToList();
            return UserList;
        }

        //Save User Information
        public ResponseModel AddUser(UserInformation userInfo)
        {
            ResponseModel model = new ResponseModel();
            try
            {
                var searchResult = _context.UserRegistrations.FirstOrDefault(x => x.Email == userInfo.Email);
                if(searchResult != null)
                {
                    model.Messsage = "This email already Exist!";
                    model.IsSuccess = false; ;
                }
                else
                {
                    UserRegistration user = new UserRegistration()
                    {
                        FirstName = userInfo.FirstName,
                        LastName = userInfo.LastName,
                        PhoneNumber = userInfo.PhoneNumber,
                        Email = userInfo.Email,
                        IsAuthorized = "0",
                        Status = "0",
                        Created = DateTime.Now,
                        Updated = DateTime.Now,
                        Password = "erainfotech"
                    };
                    _context.UserRegistrations.Add(user);
                    model.Messsage = "User Registrations Successfully!";
                    _context.SaveChanges();
                    model.IsSuccess = true;
                }
                
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
