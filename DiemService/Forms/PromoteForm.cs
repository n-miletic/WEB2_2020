using DiemService.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiemService.Forms
{
    public class PromoteForm
    {
        public string username { get; set; }
        public Role role { get; set; }
    }
    
     public class AddRentForm
    {
        public string username { get; set; }
        public RentACar toAdd { get; set; }
    }

    public class AddAvioForm
    {
        public string username { get; set; }
        public AvioCompany toAdd { get; set; }
    }
}