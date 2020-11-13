using System;
using System.Web.Mvc;

namespace Hdeleon_MVCRolesPermisos.Controllers
{
    public class ErrorController : Controller
    {
        #region GET: Direccion a vista Error/UnAuthorized cuando el usuario no tiene permisos de accesos
        [HttpGet]
        public ActionResult UnAuthorized(String operacion, String modulo, String msgError)
        {
            ViewBag.operacion = operacion;
            ViewBag.modulo = modulo;
            ViewBag.msgError = msgError;
            return View();
        }
        #endregion
    }
}