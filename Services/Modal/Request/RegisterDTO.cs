using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Modal.Request
{
    public class AdminCreateAccountRequest
    {
        public string Username { get; set; }
        //public string Password { get; set; }
        public string Email { get; set; }

        public int RoleId { get; set; }
        public bool Status { get; set; }

    }

    public class RegisterDTO : AdminCreateAccountRequest
    {
        public string Password { get; set; }


    }
}
