using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.IO;
using System.Linq;
using System.Web;

namespace DiemService.Database
{
    public class DbConfig : DbConfiguration
    {
        public DbConfig() :base()
        {
            
            var path = Path.GetDirectoryName(this.GetType().Assembly.Location);
            SetModelStore(new DefaultDbModelStore(path));
        }
    }
    [DbConfigurationType(typeof(DbConfig))]
    public class DiemServiceDB : DbContext
    {
        public virtual DbSet<Flight> FlightDbSet { get; set; }
        public virtual DbSet<User> UserDbSet { get; set; }
        public virtual DbSet<Admin> AdminDbSet { get; set; }
        public virtual DbSet<AdminAvio> AdminAvioDbSet { get; set; }
        public virtual DbSet<AdminRent> AdminRentDbSet { get; set; }
        public virtual DbSet<RegisteredUser> RegisteredUserDbSet { get; set; }
        public virtual DbSet<AvioCompany> AvioCompanyDbSet { get; set; }
        public virtual DbSet<Review> ReviewDbSet { get; set; }
        public virtual DbSet<RentACar> RentACarDbSet { get; set; }
        public virtual DbSet<Vehicle> VehicleDbSet { get; set; }
        public virtual DbSet<Location> LocationDbSet { get; set; }
        public virtual DbSet<Address> AddressDbSet { get; set; }
        public virtual DbSet<FlightReservation> FlightReservationDbSet { get; set; }
        public virtual DbSet<TempUser> TempUserDbSet { get; set; }

        
        public void ThePurge()
        {
            UserDbSet.RemoveRange(UserDbSet.Include(x=>x.PendingFriends).Include(x=>x.Friends).Include(x=>x.FriendRequestsSent));
            FlightDbSet.RemoveRange(FlightDbSet);
            AdminDbSet.RemoveRange(AdminDbSet);
            AdminAvioDbSet.RemoveRange(AdminAvioDbSet);
            AdminRentDbSet.RemoveRange(AdminRentDbSet);
            AvioCompanyDbSet.RemoveRange(AvioCompanyDbSet);
            RentACarDbSet.RemoveRange(RentACarDbSet);
            VehicleDbSet.RemoveRange(VehicleDbSet);
            LocationDbSet.RemoveRange(LocationDbSet);
            AddressDbSet.RemoveRange(AddressDbSet);
            TempUserDbSet.RemoveRange(TempUserDbSet);
            ReviewDbSet.RemoveRange(ReviewDbSet);
            FlightReservationDbSet.RemoveRange(FlightReservationDbSet);
            this.SaveChanges();
        }
    }
}