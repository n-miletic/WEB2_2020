using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityDemo
{
    public class CodeFirstTry1
    {
        public enum metric_imperial
        {
            METRIC,
            IMPERIAL
        }
        [ComplexType]
        public class Duzina_putovanja
        {
            
            public string metri { get; set; }
            public string milje { get; set; }

            public Duzina_putovanja(double units,metric_imperial s)
            {
                switch (s)
                {
                    case metric_imperial.METRIC:
                        metri = units + " km";
                        milje = units/1.609 + " milja";
                        break;
                    case metric_imperial.IMPERIAL:
                        metri = units * 1.609 + " km";
                        milje = units + " milja";
                        break;
                }
            }
            public Duzina_putovanja()
            {

            }
        }
       
        public class Lokacija
        {
            public int Id { get; set; }
            public string drzava { get; set; }
            public string grad { get; set; }

            public Lokacija(string drzava, string grad)
            {
                this.drzava = drzava;
                this.grad = grad;
            }
            public Lokacija()
            {

            }
        }
        public enum Valuta
        {
            RSD,
            USD
        }
        [ComplexType]
        public class Cena
        {
            public double cena { get; set; }
            public Valuta valuta { get; set; }

            public Cena(double cena, Valuta valuta)
            {
                this.cena = cena;
                this.valuta = valuta;
            }
            public Cena()
            {

            }
        }
        public class Let
        {
            public int Id { get; set; }
            public DateTime datum_vreme_poletanja { get; set; }
            public DateTime datum_vreme_sletanja { get; set; }
            public Duzina_putovanja duzina_putovanja { get; set; }
            public virtual ICollection<Lokacija> lokacije_presedanja { get; set; }
            public Cena cena_karte { get; set; }

            public Let(DateTime datum_vreme_poletanja, DateTime datum_vreme_sletanja, Duzina_putovanja duzina_putovanja, Cena cena_karte)
            {
                this.datum_vreme_poletanja = datum_vreme_poletanja;
                this.datum_vreme_sletanja = datum_vreme_sletanja;
                this.duzina_putovanja = duzina_putovanja;
                this.lokacije_presedanja = new List<Lokacija>();
                
                this.cena_karte = cena_karte;
            }
            public Let()
            {

            }
        }

        public class LetoviDBContext : DbContext
        {
            public virtual DbSet<Let> Letovis { get; set; }
            public virtual DbSet<Korisnik> Korisnicis { get; set; }
            public virtual DbSet<Admin> Admins { get; set; }
            public virtual DbSet<AdminAvio> AdminAvios { get; set; }
            public virtual DbSet<AdminRent> AdminRents { get; set; }
            public virtual DbSet<Aviokompanija> Aviokompanijas { get; set; }
            public virtual DbSet<RentACar> RentACars { get; set; }
            public virtual DbSet<Vozilo> Vozilos { get; set; }
            public virtual DbSet<Lokacija> Lokacijas { get; set; }

            public List<Let> GetAllFlights()
            {
                return Letovis.ToList();
            }
            public List<Korisnik> GetAllUsers()
            {
                return Korisnicis.ToList();
            }
            public void ThePurge()
            {
                Letovis.RemoveRange(Letovis);
                Korisnicis.RemoveRange(Korisnicis);
                Admins.RemoveRange(Admins);
                AdminAvios.RemoveRange(AdminAvios);
                AdminRents.RemoveRange(AdminRents);
                Aviokompanijas.RemoveRange(Aviokompanijas);
                RentACars.RemoveRange(RentACars);
                Vozilos.RemoveRange(Vozilos);
                Lokacijas.RemoveRange(Lokacijas);
            }
            
        }
        public static class UsefulTransformations
        {
            public static  List<int> StringToListInt(string serialized)
            {
                List<int> ret = new List<int>();
                foreach (string item in serialized.Split(','))
                {
                    ret.Add(Int32.Parse(item));
                }
                return ret;
            }
        }
    }
}
