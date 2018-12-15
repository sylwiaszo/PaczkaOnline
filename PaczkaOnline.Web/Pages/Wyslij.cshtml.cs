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
            return RedirectToPage("/Podsumowanie", new { KodPaczki = wygenerowanyKodPaczki });
        }
    }
}