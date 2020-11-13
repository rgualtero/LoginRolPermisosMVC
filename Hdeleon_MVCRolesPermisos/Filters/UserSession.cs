using System.Web;
using System.Web.Mvc;
using Hdeleon_MVCRolesPermisos.Models;
using Hdeleon_MVCRolesPermisos.Controllers;

namespace Hdeleon_MVCRolesPermisos.Filters
{
    public class UserSession: ActionFilterAttribute 
    {
        private Usuario oUsuario;

        #region Funcion Valida Usuario de Sesion para acceso directo al Login
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            try
            {
                base.OnActionExecuting(filterContext);

                oUsuario = (Usuario)HttpContext.Current.Session["User"];
                if (oUsuario == null)
                {
                    if (filterContext.Controller is AccesosController == false)
                    {
                        filterContext.HttpContext.Response.Redirect("/Accesos/Login");
                    }
                }
            }
            catch (System.Exception)
            {
                filterContext.Result = new RedirectResult("~/Accesos/Login");
            }
        }
        #endregion
    }
}