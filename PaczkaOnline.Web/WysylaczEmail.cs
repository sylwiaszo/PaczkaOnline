using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaczkaOnline.Web
{
    public class WysylaczEmail : IWysylaczEmail
    {
        public void Wyslij(string adres, string tresc)
        {
            Console.WriteLine($"Wysłano email do {adres} o tresci: {tresc}");
        }
    }
}
