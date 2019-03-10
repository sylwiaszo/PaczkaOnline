using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PaczkaOnline.Web.Pages
{
    public class StatystykiModel : PageModel
    {
        private readonly BazaDanych bazaDanych;

        public StatystykiModel(BazaDanych bazaDanych)
        {
            this.bazaDanych = bazaDanych;
        }

        public string WyslanoPaczek { get; set; }
        public string PaczekWDrodze { get; set; }
        public string DostarczonoProcent { get; set; }
        public string DostarczonoZSukcesem { get; set; }
        public string SredniCzasDostarczenia { get; set; }

        public string KodKreskowy { get; set; }

        public void OnGet()
        {
            bazaDanych.GenerujStatystyki(ViewData);

            WyslanoPaczek = ViewData["WyslanoPaczek"].ToString();
            PaczekWDrodze = ViewData["PaczekWDrodze"].ToString();
            DostarczonoZSukcesem = ViewData["Dostarczono"].ToString();
            DostarczonoProcent = ViewData["DostarczonoProcent"].ToString();
            SredniCzasDostarczenia = ViewData["SredniCzasDostarczenia"].ToString();

        }

        public void OnPost(string hasloAdmin)
        {
            if(hasloAdmin == "statystyki2019")
            {
                var adminBytes = Encoding.UTF8.GetBytes("admin");
                HttpContext.Session.Set("admin", adminBytes);
                OnGet();
            }
        }
    }
}