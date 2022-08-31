using GoogleContactPage.Interface;
using GoogleContactPage.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoogleContactPage.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserRegistrationController : ControllerBase
    {
        IUserRegistrationsService userRegistrationsService;

        public UserRegistrationController(IUserRegistrationsService _userRegistrationsService)
        {
            userRegistrationsService = _userRegistrationsService;
        }
        //Get All User List
        [HttpGet]
        [Route("[action]")]
        public IActionResult GetUser()
        {
            try
            {
                var data = userRegistrationsService.GetUserList();
                if (data == null)
                {
                    return NotFound();
                }

                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        //Add User
        [HttpPost]
        [Route("[action]")]
        public IActionResult AddUser(UserInformation userInfo)
        {
            try
            {
                var data = userRegistrationsService.AddUser(userInfo);
                return Ok(data);

            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

    }
}
