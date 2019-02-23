using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace PaczkaOnline.Web
{
    public class BazaDanych : DbContext
    {
        public BazaDanych(DbContextOptions<BazaDanych> opt)
            : base(opt)
        {

        }

        public int DodajNadawce(string email, string telefon)
        {
            var idNadawcy = new SqlParameter();
            idNadawcy.ParameterName = "@idNadawcy";
            idNadawcy.DbType = DbType.Int32;
            idNadawcy.Direction = ParameterDirection.Output;

            Database.ExecuteSqlCommand("execute DodajNadawce @email, @telefon, @idNadawcy OUT",
                new SqlParameter("@email", email),
                new SqlParameter("@telefon", telefon),
                idNadawcy);

            return (int)idNadawcy.Value;
        }

        public int DodajOdbiorce(string imie, string nazwisko, string email, string telefon)
        {
            var idOdbiorcy = new SqlParameter();
            idOdbiorcy.ParameterName = "@idOdbiorcy";
            idOdbiorcy.DbType = DbType.Int32;
            idOdbiorcy.Direction = ParameterDirection.Output;

            Database.ExecuteSqlCommand("execute DodajOdbiorce @imie, @nazwisko, @email, @telefon, @idOdbiorcy OUT",
                new SqlParameter("@imie", imie),
                new SqlParameter("@nazwisko", nazwisko),
                new SqlParameter("@email", email),
                new SqlParameter("@telefon", telefon),
                idOdbiorcy);

            return (int)idOdbiorcy.Value;
        }

        public string DodajPaczke(int idNadawcy, int idOdbiorcy, string miasto, string ulica, string kodPocztowy, string lokal)
        {
            var idPaczki = new SqlParameter();
            idPaczki.ParameterName = "@id";
            idPaczki.DbType = DbType.String;
            idPaczki.Size = 36;
            idPaczki.Direction = ParameterDirection.Output;

            Database.ExecuteSqlCommand("execute DodajPaczke @nadawca, @odbiorca, @miasto, @kod, @ulica, @lokal, @id OUT",
                new SqlParameter("@nadawca", idNadawcy),
                new SqlParameter("@odbiorca", idOdbiorcy),
                new SqlParameter("@miasto", miasto),
                new SqlParameter("@kod", kodPocztowy),
                new SqlParameter("@ulica", ulica),
                new SqlParameter("@lokal", lokal),
                idPaczki);

            return idPaczki.Value.ToString();
        }

        public string PobierzPaczke(string idPaczki, ViewDataDictionary viewData)
        {
            var lokalizacja = new SqlParameter();
            lokalizacja.ParameterName = "@lokalizacja";
            lokalizacja.DbType = DbType.StringFixedLength;
            lokalizacja.Size = 6;
            lokalizacja.Direction = ParameterDirection.Output;

            var czasNadania = new SqlParameter();
            czasNadania.ParameterName = "@czasNadania";
            czasNadania.DbType = DbType.DateTime;
            czasNadania.Direction = ParameterDirection.Output;

            var miasto = new SqlParameter();
            miasto.ParameterName = "@miasto";
            miasto.DbType = DbType.String;
            miasto.Size = 30;
            miasto.Direction = ParameterDirection.Output;

            var ulica = new SqlParameter();
            ulica.ParameterName = "@ulica";
            ulica.DbType = DbType.String;
            ulica.Size = 30;
            ulica.Direction = ParameterDirection.Output;

            var lokal = new SqlParameter();
            lokal.ParameterName = "@lokal";
            lokal.DbType = DbType.String;
            lokal.Size = 30;
            lokal.Direction = ParameterDirection.Output;

            var kodPocztowy = new SqlParameter();
            kodPocztowy.ParameterName = "@kodPocztowy";
            kodPocztowy.DbType = DbType.StringFixedLength;
            kodPocztowy.Size = 6;
            kodPocztowy.Direction = ParameterDirection.Output;

            Database.ExecuteSqlCommand("execute PobierzPaczke @id, @lokalizacja OUT, @czasNadania OUT, @miasto OUT, @kodPocztowy OUT, @ulica OUT, @lokal OUT",
                new SqlParameter("@id", idPaczki),
               lokalizacja,
                czasNadania,
                miasto,
                kodPocztowy,
                ulica,
                lokal);

            viewData.Add("Lokalizacja", lokalizacja.Value.ToString());
            viewData.Add("CzasNadania", czasNadania.Value.ToString());
            viewData.Add("Miasto", miasto.Value.ToString());
            viewData.Add("KodPocztowy", kodPocztowy.Value.ToString());
            viewData.Add("Ulica", ulica.Value.ToString());
            viewData.Add("Lokal", lokal.Value.ToString());

            return lokalizacja.Value.ToString() + czasNadania.Value.ToString() + miasto.Value.ToString();
        }

        public void GenerujStatystyki(ViewDataDictionary viewData)
        {
            var wyslanoPaczek = new SqlParameter();
            wyslanoPaczek.ParameterName = "@WyslanoPaczek";
            wyslanoPaczek.DbType = DbType.Int32;
            wyslanoPaczek.Direction = ParameterDirection.Output;

            var paczekWDrodze = new SqlParameter();
            paczekWDrodze.ParameterName = "@PaczekWDrodze";
            paczekWDrodze.DbType = DbType.Int32;
            paczekWDrodze.Direction = ParameterDirection.Output;

            var dostarczonoPaczek = new SqlParameter();
            dostarczonoPaczek.ParameterName = "@Dostarczono";
            dostarczonoPaczek.DbType = DbType.Int32;
            dostarczonoPaczek.Direction = ParameterDirection.Output;

            var dostarczonoPaczekProcent = new SqlParameter();
            dostarczonoPaczekProcent.ParameterName = "@DostarczonoProcent";
            dostarczonoPaczekProcent.DbType = DbType.Int32;
            dostarczonoPaczekProcent.Direction = ParameterDirection.Output;

            var sredniCzasDostarczenia = new SqlParameter();
            sredniCzasDostarczenia.ParameterName = "@SredniCzasDostarczenia";
            sredniCzasDostarczenia.DbType = DbType.Int32;
            sredniCzasDostarczenia.Direction = ParameterDirection.Output;



            Database.ExecuteSqlCommand("execute GenerujStatystyki @WyslanoPaczek OUT, @PaczekWDrodze OUT, @Dostarczono OUT, @DostarczonoProcent OUT, @SredniCzasDostarczenia OUT",
               wyslanoPaczek,
                paczekWDrodze,
                dostarczonoPaczek,
                dostarczonoPaczekProcent,
                sredniCzasDostarczenia);

            viewData.Add("WyslanoPaczek", wyslanoPaczek.Value.ToString());
            viewData.Add("PaczekWDrodze", paczekWDrodze.Value.ToString());
            viewData.Add("Dostarczono", dostarczonoPaczek.Value.ToString());
            viewData.Add("DostarczonoProcent", dostarczonoPaczekProcent.Value.ToString());
            viewData.Add("SredniCzasDostarczenia", sredniCzasDostarczenia.Value.ToString());
        }
    }
}
