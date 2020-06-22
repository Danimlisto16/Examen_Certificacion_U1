using System.Web;
using System.Web.Mvc;

namespace Examen_Certificacion_U1
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
