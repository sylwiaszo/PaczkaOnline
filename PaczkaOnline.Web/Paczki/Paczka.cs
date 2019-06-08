using System;

namespace PaczkaOnline.Web.Paczki
{
	public class Paczka
	{
		public Guid Id { get; set; }
		public int Nadawca { get; set; }
		public int Odbiorca { get; set; }
		public string Miasto { get; set; }
		public string KodPocztowy { get; set; }
		public string Ulica { get; set; }
		public string Lokal { get; set; }
		public string Lokalizacja { get; set; }
		public string CzasNadania { get; set; }
		public string CzasDostarczenia { get; set; }
		public bool Odebrana { get; set; }
	}
}
