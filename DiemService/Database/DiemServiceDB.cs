using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DiemService.Database
{
    public class DiemServiceDB : DbContext
    {
        public virtual DbSet<Flight> FlightDbSet { get; set; }
        public virtual DbSet<User> UserDbSet { get; set; }
        public virtual DbSet<Admin> AdminDbSet { get; set; }
        public virtual DbSet<AdminAvio> AdminAvioDbSet { get; set; }
        public virtual DbSet<AdminRent> AdminRentDbSet { get; set; }
        public virtual DbSet<RegisteredUser> RegisteredUserDbSet { get; set; }
        public virtual DbSet<AvioCompany> AvioCompanyDbSet { get; set; }
        public virtual DbSet<RentACar> RentACarDbSet { get; set; }
        public virtual DbSet<Vehicle> VehicleDbSet { get; set; }
        public virtual DbSet<Location> LocationDbSet { get; set; }
        public virtual DbSet<Address> AddressDbSet { get; set; }

        public virtual DbSet<TempUser> TempUserDbSet { get; set; }

        public void ThePurge()
        {
            FlightDbSet.RemoveRange(FlightDbSet);
            UserDbSet.RemoveRange(UserDbSet);
            AdminDbSet.RemoveRange(AdminDbSet);
            AdminAvioDbSet.RemoveRange(AdminAvioDbSet);
            AdminRentDbSet.RemoveRange(AdminRentDbSet);
            AvioCompanyDbSet.RemoveRange(AvioCompanyDbSet);
            RentACarDbSet.RemoveRange(RentACarDbSet);
            VehicleDbSet.RemoveRange(VehicleDbSet);
            LocationDbSet.RemoveRange(LocationDbSet);
            AddressDbSet.RemoveRange(AddressDbSet);
            TempUserDbSet.RemoveRange(TempUserDbSet);
            this.SaveChanges();
        }
    }
}