using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PocztaOnline.Aplikacja.Pages
{
	public class IndexModel : PageModel
	{
		public void OnGet()
		{
			if (RouteData.Values.Keys.Contains("KodPaczki"))
			{
				Response.Redirect("/Czekam/" + RouteData.Values["KodPaczki"].ToString());
			}
		}
	}
}