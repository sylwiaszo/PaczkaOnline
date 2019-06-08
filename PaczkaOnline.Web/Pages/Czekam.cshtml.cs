using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PaczkaOnline.Web.Paczki;
using System;

namespace PaczkaOnline.Web.Pages
{
	public class CzekamModel : PageModel
	{
		private readonly BazaDanych db;

		public Paczka Paczka;

		public CzekamModel(BazaDanych db)
		{
			this.db = db;
		}

		[BindProperty]
		public string KodPaczki2 { get; set; }

		public void OnGet()
		{
			if (RouteData.Values != null && RouteData.Values["KodPaczki"] != null)
			{

				if (Guid.TryParse(RouteData.Values["KodPaczki"].ToString(), out Guid kodPaczki))
				{
					Paczka = db.PobierzPaczke(kodPaczki.ToString());
					db.PobierzLokalizacje(Paczka.Lokalizacja, ViewData);
				}
			}
		}

		public IActionResult OnPost()
		{
			return RedirectToPage("/Czekam", new { KodPaczki = KodPaczki2 });
		}
	}
}