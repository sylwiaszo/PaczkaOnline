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
        public PodsumowanieModel(KodKreskowyGenerator kodKreskowyGenerator)
        {
            KodKreskowyGenerator = kodKreskowyGenerator;
        }

        public KodKreskowyGenerator KodKreskowyGenerator { get; }

        public void OnGet()
        {
            if (RouteData.Values["KodPaczki"] != null)
            {
                ViewData.Add("KodKreskowy", KodKreskowyGenerator.Generuj(RouteData.Values["KodPaczki"].ToString()).Result);
            }
        }
    }
}