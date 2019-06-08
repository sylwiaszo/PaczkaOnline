using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;
using PaczkaOnline.Web.Paczki;
using PaczkaOnline.Web.Uzytkownicy;
using System;
using System.Data;
using System.Data.SqlClient;

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
			var idNadawcy = new SqlParameter
			{
				ParameterName = "@idNadawcy",
				DbType = DbType.Int32,
				Direction = ParameterDirection.Output
			};

			Database.ExecuteSqlCommand("execute DodajNadawce @email, @telefon, @idNadawcy OUT",
				new SqlParameter("@email", email),
				new SqlParameter("@telefon", telefon),
				idNadawcy);

			return (int)idNadawcy.Value;
		}

		public int DodajOdbiorce(string imie, string nazwisko, string email, string telefon)
		{
			var idOdbiorcy = new SqlParameter
			{
				ParameterName = "@idOdbiorcy",
				DbType = DbType.Int32,
				Direction = ParameterDirection.Output
			};

			Database.ExecuteSqlCommand("execute DodajOdbiorce @imie, @nazwisko, @email, @telefon, @idOdbiorcy OUT",
				new SqlParameter("@imie", imie),
				new SqlParameter("@nazwisko", nazwisko),
				new SqlParameter("@email", email),
				new SqlParameter("@telefon", telefon),
				idOdbiorcy);

			return (int)idOdbiorcy.Value;
		}

		public Uzytkownik PobierzNadawce(int id)
		{
			var email = new SqlParameter
			{
				ParameterName = "@email",
				DbType = DbType.String,
				Direction = ParameterDirection.Output
			};

			var telefon = new SqlParameter
			{
				ParameterName = "@telefon",
				DbType = DbType.String,
				Direction = ParameterDirection.Output
			};

			Database.ExecuteSqlCommand("execute PobierzNadawce @id, @email OUT, @telefon OUT",
				new SqlParameter("@id", id),
				email,
				telefon);

			return new Uzytkownik { Email = email.Value.ToString(), Telefon = telefon.Value.ToString() };
		}

		public Uzytkownik PobierzOdbiorce(int id)
		{
			var email = new SqlParameter
			{
				ParameterName = "@email",
				DbType = DbType.String,
				Direction = ParameterDirection.Output
			};

			var telefon = new SqlParameter
			{
				ParameterName = "@telefon",
				DbType = DbType.String,
				Direction = ParameterDirection.Output
			};

			Database.ExecuteSqlCommand("execute PobierzOdbiorce @id, @email OUT, @telefon OUT",
				new SqlParameter("@id", id),
				email,
				telefon);

			return new Uzytkownik { Email = email.Value.ToString(), Telefon = telefon.Value.ToString() };
		}


		public string DodajPaczke(int idNadawcy, int idOdbiorcy, string miasto, string ulica, string kodPocztowy, string lokal)
		{
			var idPaczki = new SqlParameter
			{
				ParameterName = "@id",
				DbType = DbType.String,
				Size = 36,
				Direction = ParameterDirection.Output
			};

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

		public Paczka PobierzPaczke(string idPaczki)
		{
			var lokalizacja = new SqlParameter
			{
				ParameterName = "@lokalizacja",
				DbType = DbType.StringFixedLength,
				Size = 6,
				Direction = ParameterDirection.Output
			};

			var czasNadania = new SqlParameter
			{
				ParameterName = "@czasNadania",
				DbType = DbType.DateTime,
				Direction = ParameterDirection.Output
			};

			var miasto = new SqlParameter
			{
				ParameterName = "@miasto",
				DbType = DbType.String,
				Size = 30,
				Direction = ParameterDirection.Output
			};

			var ulica = new SqlParameter
			{
				ParameterName = "@ulica",
				DbType = DbType.String,
				Size = 30,
				Direction = ParameterDirection.Output
			};

			var lokal = new SqlParameter
			{
				ParameterName = "@lokal",
				DbType = DbType.String,
				Size = 30,
				Direction = ParameterDirection.Output
			};

			var nadawca = new SqlParameter
			{
				ParameterName = "@nadawca",
				DbType = DbType.Int32,
				Direction = ParameterDirection.Output
			};

			var odbiorca = new SqlParameter
			{
				ParameterName = "@odbiorca",
				DbType = DbType.Int32,
				Direction = ParameterDirection.Output
			};

			var dostarczona = new SqlParameter
			{
				ParameterName = "@dostarczona",
				DbType = DbType.Boolean,
				Direction = ParameterDirection.Output
			};

			var kodPocztowy = new SqlParameter
			{
				ParameterName = "@kodPocztowy",
				DbType = DbType.StringFixedLength,
				Size = 6,
				Direction = ParameterDirection.Output
			};

			Database.ExecuteSqlCommand("execute PobierzPaczke @id, @lokalizacja OUT, @czasNadania OUT, @miasto OUT, @kodPocztowy OUT, @ulica OUT, @lokal OUT, @nadawca OUT, @odbiorca OUT, @dostarczona OUT",
				new SqlParameter("@id", idPaczki),
			   lokalizacja,
				czasNadania,
				miasto,
				kodPocztowy,
				ulica,
				lokal,
				nadawca,
				odbiorca,
				dostarczona);

			var paczka = new Paczka
			{
				Id = new Guid(idPaczki),
				Lokalizacja = lokalizacja.Value.ToString(),
				CzasNadania = czasNadania.Value.ToString(),
				Miasto = miasto.Value.ToString(),
				KodPocztowy = kodPocztowy.Value.ToString(),
				Ulica = ulica.Value.ToString(),
				Lokal = lokal.Value.ToString(),
				Nadawca = (int)nadawca.Value,
				Odbiorca = (int)odbiorca.Value,
				Odebrana = (bool)dostarczona.Value
			};

			return paczka;
		}

		public void PobierzLokalizacje(string kodPocztowy, ViewDataDictionary viewData)
		{
			var kodPocztowyParam = new SqlParameter
			{
				ParameterName = "@KodPocztowy",
				Value = kodPocztowy,
				DbType = DbType.String
			};

			var miasto = new SqlParameter
			{
				ParameterName = "@Miasto",
				DbType = DbType.String,
				Size = 30,
				Direction = ParameterDirection.Output
			};

			var wojewodztwo = new SqlParameter
			{
				ParameterName = "@Wojewodztwo",
				DbType = DbType.String,
				Size = 20,
				Direction = ParameterDirection.Output
			};

			var adres = new SqlParameter
			{
				ParameterName = "@Adres",
				DbType = DbType.String,
				Size = 100,
				Direction = ParameterDirection.Output
			};


			Database.ExecuteSqlCommand("execute PobierzLokalizacje @KodPocztowy, @Miasto OUT, @Wojewodztwo OUT, @Adres OUT",
				kodPocztowyParam, miasto, wojewodztwo, adres);

			viewData.Add("Miasto", miasto.Value.ToString());
			viewData.Add("Adres", adres.Value.ToString());
			viewData.Add("Wojewodztwo", wojewodztwo.Value.ToString());
		}

		public void GenerujStatystyki(ViewDataDictionary viewData)
		{
			var wyslanoPaczek = new SqlParameter
			{
				ParameterName = "@WyslanoPaczek",
				DbType = DbType.Int32,
				Direction = ParameterDirection.Output
			};

			var paczekWDrodze = new SqlParameter
			{
				ParameterName = "@PaczekWDrodze",
				DbType = DbType.Int32,
				Direction = ParameterDirection.Output
			};

			var dostarczonoPaczek = new SqlParameter
			{
				ParameterName = "@Dostarczono",
				DbType = DbType.Int32,
				Direction = ParameterDirection.Output
			};

			var dostarczonoPaczekProcent = new SqlParameter
			{
				ParameterName = "@DostarczonoProcent",
				DbType = DbType.Int32,
				Direction = ParameterDirection.Output
			};

			var sredniCzasDostarczenia = new SqlParameter
			{
				ParameterName = "@SredniCzasDostarczenia",
				DbType = DbType.Int32,
				Direction = ParameterDirection.Output
			};



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
