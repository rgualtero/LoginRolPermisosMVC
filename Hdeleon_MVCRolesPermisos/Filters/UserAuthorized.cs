using Hdeleon_MVCRolesPermisos.Models;
using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hdeleon_MVCRolesPermisos.Filters
{

    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class UserAuthorized : AuthorizeAttribute
    {
        private Usuario OUsuario;
        private AplicacionMVCEntities db = new AplicacionMVCEntities();
        private int IdOperacion;

        #region Constructor Recibe el IdOperation de la Vista
        public UserAuthorized (int IdOperation = 0)
        {
            this.IdOperacion = IdOperation;
        }
        #endregion

        #region Funcion Valida el Usuario tenga Permiso Acceso a la vista por Id RolOperacion
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            String nombreOperacion = "";
            String nombreModulo = "";

            try
            {
                OUsuario = (Usuario)HttpContext.Current.Session["User"];
                var lstOperaciones = (from a in db.RolOperacion
                                      where a.IdRol == OUsuario.IdRol
                                      && a.IdOperacion == IdOperacion
                                      select a);

                //Controla Mensaje de Acceso sin Autorizacion
                if(lstOperaciones.ToList().Count() == 0)
                {
                    var oOperacion = db.Operacion.Find(IdOperacion);
                    int? idModulo = oOperacion.IdModulo;
                    nombreOperacion = GetNombreOperacion(IdOperacion);
                    nombreModulo = GetNombreModulo(IdOperacion);
                    nombreModulo = nombreModulo.Replace(' ', '+');
                    nombreOperacion = nombreOperacion.Replace(' ', '+');


                    filterContext.Result = new RedirectResult("~/Error/UnAuthorized?operacion=" + nombreOperacion + "&modulo=" + nombreModulo + "&msgError=" + "");
                }

            }
            catch (Exception ex)
            {
                filterContext.Result = new RedirectResult("~/Error/UnAuthorized?operacion=" + nombreOperacion + "&modulo=" + nombreModulo + "&msgError=" + ex.Message);
            }
        }
        #endregion

        #region Funcion Obtener Nombre de las Operaciones
        public string GetNombreOperacion(int IdOperacion)
        {
            var Ope = from a in db.Operacion
                      where a.Id == IdOperacion
                      select a.Nombre;
            String nombreOperacion;

            try
            {
                nombreOperacion = Ope.First();
            }
            catch (Exception)
            {
                nombreOperacion = "";
            }
            return nombreOperacion;
        }
        #endregion

        #region Funcion Obtener Nombres de los Modulo
        public string GetNombreModulo(int? IdModulo)
        {
            var Mod = from a in db.Modulo
                      where a.Id == IdModulo
                      select a.Nombre;

            String nombreModulo;
            try
            {
                nombreModulo = Mod.First();
            }
            catch (Exception)
            {
                nombreModulo = "";
            }
            return nombreModulo;
        }
        #endregion
    }
}