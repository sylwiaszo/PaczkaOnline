using System.Collections.Generic;

namespace PaczkaOnline.Web.Powiadomienia
{
	public class PowiadomienieGenerator : IPowiadomienieGenerator
	{
		private readonly ICollection<IPowiadomienie> powiadomienia;
		public PowiadomienieGenerator()
		{
			powiadomienia = new List<IPowiadomienie>();
		}

		public void DodajPowiadomienie(TypPowiadomienia typ, string cel, string tresc)
		{
			switch (typ)
			{
				case TypPowiadomienia.EMAIL:
					powiadomienia.Add(new Email(cel, tresc));
					break;
				case TypPowiadomienia.SMS:
					powiadomienia.Add(new Sms(cel, tresc));
					break;
			}
		}

		public void Wyslij()
		{
			if (powiadomienia.Count > 0)
			{
				foreach (var powiadomienie in powiadomienia)
				{
					powiadomienie.Wyslij();
				}
			}
		}
	}
}
