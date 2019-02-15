using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PaczkaOnline.Web.Pages
{
    public class WyslijModel : PageModel
    {
        private readonly BazaDanych db;
        private readonly IWysylaczEmail email;
        private readonly KodKreskowyGenerator generatorKodKreskowy;

        public WyslijModel(BazaDanych db, IWysylaczEmail email)
        {
            this.db = db;
            this.email = email;
        }

        [BindProperty]
        public string Email { get; set; }
        [BindProperty]
        public string Telefon { get; set; }
        [BindProperty]
        public string ImieOdbiorcy { get; set; }
        [BindProperty]
        public string NazwiskoOdbiorcy { get; set; }
        [BindProperty]
        public string MiastoOdbiorcy { get; set; }
        [BindProperty]
        public string TelefonOdbiorcy { get; set; }
        [BindProperty]
        public string EmailOdbiorcy { get; set; }
        [BindProperty]
        public string KodPocztowyOdbiorcy { get; set; }
        [BindProperty]
        public string UlicaOdbiorcy { get; set; }
        [BindProperty]
        public string NumerLokaluOdbiorcy { get; set; }

        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {
            var wygenerowanyKodPaczki = Guid.NewGuid().ToString().Split('-')[0].ToUpper();
            var idNadawcy = db.DodajNadawce(Email, Telefon);
            var idOdbiorcy = db.DodajOdbiorce(ImieOdbiorcy, NazwiskoOdbiorcy, EmailOdbiorcy, TelefonOdbiorcy);
            var kodPaczki = db.DodajPaczke(idNadawcy, idOdbiorcy, MiastoOdbiorcy, UlicaOdbiorcy, KodPocztowyOdbiorcy, NumerLokaluOdbiorcy);

            email.Wyslij(EmailOdbiorcy, kodPaczki);
            return RedirectToPage("/Podsumowanie", new { KodPaczki = kodPaczki, Email = EmailOdbiorcy });
        }
    }
}