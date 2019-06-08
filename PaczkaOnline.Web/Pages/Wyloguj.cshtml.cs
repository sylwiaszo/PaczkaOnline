using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text;

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