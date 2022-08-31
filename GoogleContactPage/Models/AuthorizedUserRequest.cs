using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoogleContactPage.Models
{
    public class AuthorizedUserRequest
    {
        public decimal Id { get; set; }
        public string IsAuthorized { get; set; }
    }
}
