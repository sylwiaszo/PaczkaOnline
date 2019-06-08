using Microsoft.AspNetCore.Mvc.RazorPages;
using PaczkaOnline.Web.KodKreskowy;

namespace PaczkaOnline.Web.Pages
{
	public class PodsumowanieModel : PageModel
	{
		private readonly BazaDanych bazaDanych;

		public string KodKreskowy { get; set; }

		public PodsumowanieModel(IKodKreskowyGenerator kodKreskowyGenerator, BazaDanych bazaDanych)
		{
			KodKreskowyGenerator = kodKreskowyGenerator;
			this.bazaDanych = bazaDanych;
		}

		public IKodKreskowyGenerator KodKreskowyGenerator { get; }

		public void OnGet()
		{
			if (RouteData.Values["KodPaczki"] != null)
			{
				KodKreskowy = KodKreskowyGenerator.Generuj(RouteData.Values["KodPaczki"].ToString()).Result;
			}

			if (RouteData.Values["KodPocztowy"] != null)
			{
				bazaDanych.PobierzLokalizacje(RouteData.Values["KodPocztowy"].ToString(), ViewData);
			}
		}
	}
}