using Hdeleon_MVCRolesPermisos.Models;
using System;
using System.Linq;
using System.Web.Mvc;

namespace Hdeleon_MVCRolesPermisos.Controllers
{
    public class AccesosController : Controller
    {
        #region GET: Direcciona a la Vista Accesos/Login
        public ActionResult Login()
        {
            return View();
        }
        #endregion

        #region POST: Valida Usuario y Contraseña Accesos/Login
        [HttpPost]
        public ActionResult Login(string Usuario, string Contrasena)
        {
            try
            {
                using(var db = new AplicacionMVCEntities())
                {
                    var oUsuario = (from d in db.Usuario
                                    where d.Email == Usuario.Trim() && d.Contrasena == Contrasena.Trim()
                                    select d).FirstOrDefault();

                    if(oUsuario == null)
                    {
                        ViewBag.Error = "Usuario y Contraseña Invalidos";
                        return View();
                    }

                    Session["User"] = oUsuario;
                }
                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }            
        }
        #endregion

    }
}