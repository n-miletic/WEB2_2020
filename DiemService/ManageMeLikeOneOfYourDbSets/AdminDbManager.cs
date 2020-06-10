using DiemService.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using DiemService.Forms;
using System.IO;

namespace DiemService.ManageMeLikeOneOfYourDbSets
{
    public static class AdminDbManager
    {
        public static void PromoteUser(string username, Role role)
        {
            using (var _context = new DiemServiceDB())
            {
                User found = _context.UserDbSet.Where(user => user.Username == username).FirstOrDefault();
                found.Role = role;
                switch (role)
                {
                    case Role.AdminAvio:
                        AdminAvio toAdd = _context.AdminAvioDbSet.Add(new AdminAvio());
                        _context.SaveChanges();
                        found.UlogaID = toAdd.Id; 
                        break;
                    case Role.AdminRentACar:
                        AdminRent adminRent = _context.AdminRentDbSet.Add(new AdminRent());
                        _context.SaveChanges();
                        found.UlogaID = adminRent.Id;
                        break;
                    default:
                        break;
                }
                _context.SaveChanges();
            }
        }

        public static void AddCompany(AddCompanyForm rent)
        {
            using (var _context = new DiemServiceDB())
            {
                
                User found = _context.UserDbSet.Where(user => user.Username == rent.OwnerUsername).FirstOrDefault();
                switch (found.Role)
                {
                    case Role.AdminAvio:
                        AvioCompany toAdd = rent.getAvio();
                        string imgName = "avioCompany" + toAdd.Id;
                        File.WriteAllBytes(AppDomain.CurrentDomain.BaseDirectory + "/" + imgName, Convert.FromBase64String(toAdd.Logo));
                        toAdd.Logo = imgName;
                        toAdd.Owner = found;
                        _context.AdminAvioDbSet.Include(x => x.OwnedAvioCompanies)
                                                .Where(x => x.Id == found.UlogaID)
                                                .FirstOrDefault().OwnedAvioCompanies
                                                .Add(_context.AvioCompanyDbSet.Add(toAdd));
                        break;
                    case Role.AdminRentACar:
                        RentACar toAdd2 = rent.getRent();
                        toAdd2.Owner = found;
                        _context.AdminRentDbSet.Include(x => x.OwnedRentServices)
                                                .Where(x => x.Id == found.UlogaID)
                                                .FirstOrDefault().OwnedRentServices
                                                .Add(_context.RentACarDbSet.Add(toAdd2));
                        break;
                    default:
                        break;
                }
                
                _context.SaveChanges();
            }
        }



    }
}