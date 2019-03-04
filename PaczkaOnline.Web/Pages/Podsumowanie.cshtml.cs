using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PaczkaOnline.Web.Pages
{
    public class PodsumowanieModel : PageModel
    {
        private readonly BazaDanych bazaDanych;

        public string KodKreskowy { get; set; }

        public PodsumowanieModel(KodKreskowyGenerator kodKreskowyGenerator, BazaDanych bazaDanych)
        {
            KodKreskowyGenerator = kodKreskowyGenerator;
            this.bazaDanych = bazaDanych;
        }

        public KodKreskowyGenerator KodKreskowyGenerator { get; }

        public void OnGet()
        {
            if (RouteData.Values["KodPaczki"] != null)
            {
                KodKreskowy = KodKreskowyGenerator.Generuj(RouteData.Values["KodPaczki"].ToString()).Result;
            }

            if (RouteData.Values["KodPocztowy"] != null)
            {
                bazaDanych.PobierzLokalizacje(RouteData.Values["KodPocztowy"].ToString(), ViewData);
            }
        }
    }
}