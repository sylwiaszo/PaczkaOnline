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

        public int WyslanoPaczek { get; set; }
        public int PaczekWDrodze { get; set; }
        public int DostarczonoZSukcesem { get; set; }
        public int SredniCzasDostarczenia { get; set; }

        public string KodKreskowy { get; set; }

        public void OnGet()
        {

            bazaDanych.GenerujStatystyki(ViewData);
        }
    }
}