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
    
     public class AddCompanyForm
    {
        public string OwnerUsername { get; set; }
        public string Name { get; set; }
        public string Promo_description { get; set; }
        public string Address { get; set; }
        public string Logo { get; set; }

        public AvioCompany getAvio()
        {
            return new AvioCompany(Name, new Database.Address() { State = Address }, Promo_description,Logo);
        }
        public RentACar getRent()
        {
            return new RentACar(Name, new Database.Address() { State = Address }, Promo_description, Logo);
        }
    }


}