﻿using DiemService.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.IO;
using DiemService.Forms;
using System.Security.Claims;

namespace DiemService.ManageMeLikeOneOfYourDbSets
{
    public static class AvioCompanyDbManager
    {
        public static AvioCompany GetById(int id)
        {
            using (var _context = new DiemServiceDB())
            {
                AvioCompany retVal = _context.AvioCompanyDbSet.Where(u => u.Id == id)
                                                .Include(x => x.Owner)
                                                .Include(y=> y.Flights)
                                                .Include(y=>y.Flights.Select(x=>x.To_Location))
                                                .Include(y => y.Flights.Select(x => x.From_Location))
                                                .Include(y => y.Flights.Select(x => x.Provider))
                                                .Include(y => y.Flights.Select(x => x.Transits))
                                                .Include(z=> z.Destinations)
                                                .Include(i=> i.Address)
                                                .FirstOrDefault();
                Byte[] img = File.ReadAllBytes(AppDomain.CurrentDomain.BaseDirectory + "/" + retVal.Logo);
                retVal.Logo = Convert.ToBase64String(img);
                return retVal;

            }
        }

        public static void EditAvio(AvioCompanyEditForm form,int id)
        {
            if(form != null)
            using (var _context = new DiemServiceDB())
            {

                AvioCompany retVal = _context.AvioCompanyDbSet.Where(u => u.Id == id)
                                                .Include(x => x.Owner)
                                                .Include(y => y.Flights)
                                                .Include(z => z.Destinations)
                                                .Include(i => i.Address)
                                                .FirstOrDefault();
                    string caller = ((ClaimsPrincipal)HttpContext.Current.User).FindFirst("username").Value;
                    User found = _context.UserDbSet.Where(u => u.Username == caller).FirstOrDefault();
                    if (found.Role != Role.Admin && found.Username != retVal.Owner.Username)
                        return;
                    if (form.Name != null)
                        retVal.Name = form.Name;
                    if (form.Promo_description != null)
                        retVal.Promo_description = form.Promo_description;
                    if (form.Address != null)
                        retVal.Address.State = form.Address;
                    _context.SaveChanges();
            }
        }

    }
}