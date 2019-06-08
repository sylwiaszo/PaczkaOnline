namespace PaczkaOnline.Web.Powiadomienia
{
	public interface IPowiadomienieGenerator
	{
		void DodajPowiadomienie(TypPowiadomienia typ, string cel, string tresc);
		void Wyslij();
	}
}