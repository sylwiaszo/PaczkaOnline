namespace PaczkaOnline.Web
{
    public interface IWysylaczEmail
    {
        void Wyslij(string adres, string tresc);
    }
}