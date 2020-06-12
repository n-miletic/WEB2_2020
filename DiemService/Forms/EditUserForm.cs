using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiemService.Forms
{
    public class EditUserForm
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Hash { get; set; }
        public string NewHash { get; set; }
        public string Email { get; set; }
    }
}