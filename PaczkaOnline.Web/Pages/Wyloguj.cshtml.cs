using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PaczkaOnline.Web.Pages
{
    public class WylogujModel : PageModel
    {
        public void OnGet()
        {
            var adminBytes = Encoding.UTF8.GetBytes("brak");
            HttpContext.Session.Set("admin", adminBytes);
        }
    }
}