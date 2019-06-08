using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PaczkaOnline.Web.Powiadomienia;
using System.Data.SqlClient;

namespace PaczkaOnline.Web
{
	[Route("api/zarzadzaj")]
	public class ZarzadzajController : Controller
	{
		private readonly BazaDanych bazaDanych;
		private readonly IPowiadomienieGenerator powiadomienia;

		public ZarzadzajController(BazaDanych bazaDanych, IPowiadomienieGenerator powiadomienia)
		{
			this.bazaDanych = bazaDanych;
			this.powiadomienia = powiadomienia;
		}

		[Route("dostarczono"), HttpPost]
		public IActionResult DostarczonoPaczke(string idPaczki)
		{
			bazaDanych.Database.ExecuteSqlCommand("execute AktualizujStatusPaczki @paczka @dostarczona",
				new SqlParameter("@paczka", idPaczki),
				new SqlParameter("@dostarczona", true));

			var paczka = bazaDanych.PobierzPaczke(idPaczki);
			var nadawca = bazaDanych.PobierzNadawce(paczka.Nadawca);
			var odbiorca = bazaDanych.PobierzOdbiorce(paczka.Odbiorca);

			powiadomienia.DodajPowiadomienie(TypPowiadomienia.EMAIL, nadawca.Email, "Twoja paczka została odebrana.");
			powiadomienia.Wyslij();

			return StatusCode(200);
		}

		[Route("lokalizacja"), HttpPost]
		public IActionResult LokalizacjaPaczki(string idPaczki, string lokaliizacja)
		{
			bazaDanych.Database.ExecuteSqlCommand("execute AktualizujLokalizacjePaczki @paczka @lokalizacja",
				new SqlParameter("@paczka", idPaczki),
				new SqlParameter("@lokalizacja", lokaliizacja));

			var paczka = bazaDanych.PobierzPaczke(idPaczki);
			var nadawca = bazaDanych.PobierzNadawce(paczka.Nadawca);
			var odbiorca = bazaDanych.PobierzOdbiorce(paczka.Odbiorca);

			powiadomienia.DodajPowiadomienie(TypPowiadomienia.EMAIL, nadawca.Email, $"Twoja paczka jest teraz w {lokaliizacja}");
			powiadomienia.DodajPowiadomienie(TypPowiadomienia.SMS, odbiorca.Email, $"Twoja paczka jest teraz w {lokaliizacja}");
			powiadomienia.Wyslij();

			return StatusCode(200);
		}
	}
}
