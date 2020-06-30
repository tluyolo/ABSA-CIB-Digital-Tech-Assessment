using System.Web;
using System.Web.Mvc;

namespace ABSA_CIB_Digital_Tech___Assessment
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
