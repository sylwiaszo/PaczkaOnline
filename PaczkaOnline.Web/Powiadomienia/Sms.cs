using PaczkaOnline.Web.Powiadomienia;
using System;

namespace PaczkaOnline.Web
{
	public class Sms : IPowiadomienie
	{
		private readonly string numer;
		private readonly string tresc;

		public Sms(string numer, string tresc)
		{
			this.numer = numer;
			this.tresc = tresc;
		}

		public void Wyslij()
		{
			Console.WriteLine($"Wysłano sms do {numer} o tresci: {tresc}");
		}
	}
}
