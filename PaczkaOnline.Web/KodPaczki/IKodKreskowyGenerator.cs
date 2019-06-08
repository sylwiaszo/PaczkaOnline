using System.Threading.Tasks;

namespace PaczkaOnline.Web.KodKreskowy
{
	public interface IKodKreskowyGenerator
	{
		Task<string> Generuj(string guid);
	}
}