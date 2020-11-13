using System.Web.Mvc;

namespace Hdeleon_MVCRolesPermisos
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            //Se agrega filtro para vallidar Session de Usuario
            filters.Add(new Filters.UserSession());
        }
    }
}
