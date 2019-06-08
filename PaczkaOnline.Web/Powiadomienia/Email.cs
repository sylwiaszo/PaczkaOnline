using PaczkaOnline.Web.Powiadomienia;
using System;

namespace PaczkaOnline.Web
{
	public class Email : IPowiadomienie
	{
		private readonly string adres;
		private readonly string tresc;

		public Email(string adres, string tresc)
		{
			this.adres = adres;
			this.tresc = tresc;
		}
		public void Wyslij()
		{
			Console.WriteLine($"Wysłano email do {adres} o tresci: {tresc}");
		}
	}
}
