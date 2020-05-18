using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static EntityDemo.CodeFirstTry1;
using static  EntityDemo.CodeFirstTry1.UsefulTransformations;

namespace EntityDemo
{
    public enum Uloga
    {
        RegistrovaniKorisnik,
        AdministratorAvio,
        AdministratorRentaCar,
        Admin
    }
   
    public class Korisnik
    {
        public int Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string ZahteviIDSerialized { get; set; }
        public List<int> ZahteviId
        {
            get
            {
               return  StringToListInt(ZahteviIDSerialized);
            }
        }
        public string PrijateljiIDSerialized { get; set; }
        public List<int> PrijateljiID
        {
            get
            {
                List<int> ret = new List<int>();
                foreach (string item in PrijateljiIDSerialized.Split(','))
                {
                    ret.Add(Int32.Parse(item));
                }
                return ret;
            }
        }

        public Uloga Uloga { get; set; }
        public int UlogaID { get; set; }

        public Korisnik(string ime, string prezime, Uloga uloga, int ulogaID)
        {
            Ime = ime;
            Prezime = prezime;
            Uloga = uloga;
            UlogaID = ulogaID;
            ZahteviIDSerialized = "";
            PrijateljiIDSerialized = "";
        }
        public Korisnik() { }

        public void AddZahtevID(int toAdd)
        {
            string s = "," + toAdd;
            ZahteviIDSerialized += s;
        }
        public void PrihvatiZahtev(int id)
        {
            string[] s = ZahteviIDSerialized.Split(',');
            string[] s2 = PrijateljiIDSerialized.Split(',');
            if (ZahteviIDSerialized == id.ToString())
                ZahteviIDSerialized = "";
            else
                for (int i = 0; i < s.Length; i++)
                {
                    if (Int32.Parse(s[i]) == id)
                        if (ZahteviIDSerialized.Replace("," + id, "") == ZahteviIDSerialized)
                            ZahteviIDSerialized.Replace(id + ",", "");
                }
            if (s2.Length == 0)
                PrijateljiIDSerialized += id.ToString();
            else
                PrijateljiIDSerialized += "," + id;

        }
        public void OdbijZahtev(int id)
        {
            string[] s = ZahteviIDSerialized.Split(',');
           
            if (ZahteviIDSerialized == id.ToString())
                ZahteviIDSerialized = "";
            else
                for (int i = 0; i < s.Length; i++)
                {
                    if (Int32.Parse(s[i]) == id)
                        if (ZahteviIDSerialized.Replace("," + id, "") == ZahteviIDSerialized)
                            ZahteviIDSerialized.Replace(id + ",", "");
                }
        }
       
    }
    public class Admin
    {
        public int Id { get; set; }

        public Admin()
        {
        }
    }
    public class AdminAvio
    {
        public int Id { get; set; }
        public string AviokompanijaIDSerialized { get; set; }
        public List<int> AviokompanijaID
        {
            get
            {
                return StringToListInt(AviokompanijaIDSerialized);
            }
        }
        public AdminAvio()
        {
            AviokompanijaIDSerialized = "";
        }
    }
    public class AdminRent
    {
        public int Id { get; set; }
        public string RentACarIDSerialized { get; set; }
        public List<int> RentACarID {
            get {
                return StringToListInt(RentACarIDSerialized);
            } }
        public AdminRent()
        {
            RentACarIDSerialized = "";
        }
    }

    [ComplexType]
    public class Adresa
    {
        public string Drzava { get; set; }
        public string Grad { get; set; }
        public string Ulica { get; set; }
        public int Broj { get; set; }
        public int Postanski_Broj { get; set; }

        public Adresa(string drzava, string grad, string ulica, int broj, int postanski_Broj)
        {
            Drzava = drzava;
            Grad = grad;
            Ulica = ulica;
            Broj = broj;
            Postanski_Broj = postanski_Broj;
        }

        public Adresa()
        {
        }
    }
    public class Aviokompanija
    {
        public int Id { get; set; }
        public Adresa Adresa { get; set; }
        public string Promo_opis { get; set; }
        public int Prosecna_ocena { get; set; }
        public List<Lokacija> Destinacije { get; set; }
        public string LetoviIDSerialized { get; set; }
        public List<int> LetoviID
        {
            get
            {
                return StringToListInt(LetoviIDSerialized);
            }
        }

        public Aviokompanija(Adresa adresa, string promo_opis, List<Lokacija> destinacije)
        {
            Adresa = adresa;
            Promo_opis = promo_opis;
            Destinacije = destinacije;
            LetoviIDSerialized = "";
        }
        public Aviokompanija()
        {

        }
    }
    public class RentACar
    {
        public int Id { get; set; }
        public Adresa Adresa { get; set; }
        public string Promo_opis { get; set; }
        public int Prosecna_ocena { get; set; }
        public List<Lokacija> Destinacije { get; set; }
        public string VozilaIDSerialized { get; set; }
        public List<int> VozilaID
        {
            get
            {
                return StringToListInt(VozilaIDSerialized);
            }
        }

        public RentACar(Adresa adresa, string promo_opis, int prosecna_ocena, List<Lokacija> destinacije)
        {
            Adresa = adresa;
            Promo_opis = promo_opis;
            Prosecna_ocena = prosecna_ocena;
            Destinacije = destinacije;
            VozilaIDSerialized = "";
        }
        public void Modify(Adresa adresa, string promo_opis, List<Lokacija> destinacije)
        {
            if (adresa != null)
            {
                Adresa = adresa;
            }
            if (promo_opis != null)
            {
                Promo_opis = promo_opis;
            }
            if (destinacije != null)
            {
                Destinacije = destinacije;
            }
        }
    }
    public class Vozilo
    {
        public int Id { get; set; }
        public Adresa Adresa { get; set; }
        public string Info { get; set; }

        public Vozilo(Adresa adresa, string info)
        {
            Adresa = adresa;
            Info = info;
        }
    }


}
