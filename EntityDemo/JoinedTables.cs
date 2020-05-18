using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static EntityDemo.CodeFirstTry1;

namespace EntityDemo
{
    
    public class JoinedTables
    {
        public interface IUloga
        {

        }
        public class AdminJ : IUloga
        {

        }
        public class AdminAvioJ : IUloga
        {

        }
        public class AdminRentJ : IUloga
        {

        }
        public class KorisnikJoined
        {
            public int Id { get; set; }
            public string Ime { get; set; }
            public string Prezime { get; set; }

            public IUloga Uloga { get; set; }
            public KorisnikJoined(Korisnik k)
            {
                //using (var _context = new LetoviDBContext())
                //{
                //    switch (k.Uloga)
                //    {
                //        case EntityDemo.Uloga.RegistrovaniKorisnik:
                //            Uloga = new 
                //            break;
                //    }
                //    _context.AdminAvios;

                //}
            }
        }
    }
}
