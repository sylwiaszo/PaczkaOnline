using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PaczkaOnline.Web.Pages
{
    public class CzekamModel : PageModel
    {
        private readonly BazaDanych db;

        public CzekamModel(BazaDanych db)
        {
            this.db = db;
        }

        [BindProperty]
        public string Dane { get; set; }
        [BindProperty]
        public string KodPaczki2 { get; set; }

        public void OnGet()
        {
            if (RouteData.Values != null && RouteData.Values["KodPaczki"] != null)
            {

                if (Guid.TryParse(RouteData.Values["KodPaczki"].ToString(), out Guid kodPaczki))
                {
                    Dane = db.PobierzPaczke(kodPaczki.ToString(), this.ViewData);
                    ViewData["MiastoCel"] = ViewData["Miasto"];
                    ViewData.Remove("Miasto");
                    db.PobierzLokalizacje(ViewData["Lokalizacja"].ToString(), ViewData);
                }
            }
        }

        public IActionResult OnPost()
        {
            return RedirectToPage("/Czekam", new { KodPaczki = KodPaczki2 });
        }
    }
}