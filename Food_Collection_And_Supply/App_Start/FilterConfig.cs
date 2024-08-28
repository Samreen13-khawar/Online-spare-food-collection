using System.Web;
using System.Web.Mvc;

namespace Food_Collection_And_Supply
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
