using Hdeleon_MVCRolesPermisos.Filters;
using System.Web.Mvc;


namespace Hdeleon_MVCRolesPermisos.Controllers
{
    public class HomeController : Controller
    {
        //Se agrega Filtro [UserAuthorized(IdOperation:1)] 
        //valida acceso de Usuario clase UserAuthorized
        //valida IdOperation en la Base de Datos tabla RolOperacion

        #region Redirecciona a la vista Index
        [UserAuthorized(IdOperation:1)]
        public ActionResult Index()
        {
            return View();
        }
        #endregion

        #region Redirecciona a la vista About
        [UserAuthorized(IdOperation: 2)]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        #endregion

        #region Redirecciona a la vista Contact
        [UserAuthorized(IdOperation: 3)]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        #endregion
    }
}