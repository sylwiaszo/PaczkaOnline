using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PaczkaOnline.Web
{
    [Route("api/zarzadzaj")]
    public class ZarzadzajController : Controller
    {
        private readonly BazaDanych bazaDanych;
        private readonly IWysylaczEmail email;

        public ZarzadzajController(BazaDanych bazaDanych, IWysylaczEmail email)
        {
            this.bazaDanych = bazaDanych;
            this.email = email;
        }

        [Route("dostarczono"), HttpPost]
        public IActionResult DostarczonoPaczke(string idPaczki)
        {
            bazaDanych.Database.ExecuteSqlCommand("execute AktualizujStatusPaczki @paczka @dostarczona",
                new SqlParameter("@paczka", idPaczki),
                new SqlParameter("@dostarczona", true));

            return StatusCode(200);
        }

        [Route("lokalizacja"), HttpPost]
        public IActionResult LokalizacjaPaczki(string idPaczki, string lokaliizacja)
        {
            bazaDanych.Database.ExecuteSqlCommand("execute AktualizujLokalizacjePaczki @paczka @lokalizacja",
                new SqlParameter("@paczka", idPaczki),
                new SqlParameter("@lokalizacja", lokaliizacja));

            return StatusCode(200);
        }
    }
}
