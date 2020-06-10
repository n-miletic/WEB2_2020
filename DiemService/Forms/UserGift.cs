using DiemService.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiemService.Forms
{
    public class UserGift
    {
        public string Token { get; set; }
        public object User { get; set; }

        public UserGift(string token, object user)
        {
            Token = token;
            User = user;
        }
    }
}