using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace PaczkaOnline.Web
{
    public class BazaDanych : DbContext
    {
        public BazaDanych(DbContextOptions<BazaDanych> opt)
            : base(opt)
        {

        }

        public int DodajNadawce(string email, string telefon)
        {
            var idNadawcy = new SqlParameter();
            idNadawcy.ParameterName = "@idNadawcy";
            idNadawcy.DbType = DbType.Int32;
            idNadawcy.Direction = ParameterDirection.Output;

            Database.ExecuteSqlCommand("execute DodajNadawce @email, @telefon, @idNadawcy OUT", 
                new SqlParameter("@email", email), 
                new SqlParameter("@telefon", telefon),
                idNadawcy);

            return (int)idNadawcy.Value;
        }

        public void DodajPaczke()
        {
        }
    }
}
