using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace PaczkaOnline.Web
{
    public class KodKreskowyGenerator
    {
        public async Task<string> Generuj(string guid)
        {
            using (var http = new HttpClient())
            {
                var dane = await http.GetByteArrayAsync($"https://barcode.tec-it.com/barcode.ashx?data={guid}&code=Code128&download=true");
                var base64 = Convert.ToBase64String(dane);
                return $"data:image/gif;base64,{base64}"; ;
            }
        }
    }
}
