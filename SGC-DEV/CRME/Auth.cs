using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CRME.Models;

namespace CRME
{
    public class Auth
    {
        private const string UserKey = "CRME.Auth.UserKey";

        public static cat_sistemas Usuario
        {
            get
            {
                if (!HttpContext.Current.User.Identity.IsAuthenticated)
                {
                    return null;
                }
                var usuario = HttpContext.Current.Items[UserKey] as cat_sistemas;

                if (usuario == null)
                {
                    SIRE_Context db = new SIRE_Context();
                    usuario = db.cat_sistemas.FirstOrDefault(x => x.correo == HttpContext.Current.User.Identity.Name);

                    if (usuario == null)
                    {
                        return null;
                    }
                    HttpContext.Current.Items[UserKey] = usuario;
                }
                return usuario;
            }
        }

        public static Permisos Permiso
        {
            get
            {
                if (!HttpContext.Current.User.Identity.IsAuthenticated)
                {
                    return null;
                }
                var permiso = HttpContext.Current.Items[UserKey] as Permisos;

                if (permiso == null)
                {
                    SIRE_Context db = new SIRE_Context();
                    permiso = db.Permisos.FirstOrDefault(x => Auth.Usuario.correo == HttpContext.Current.User.Identity.Name);

                    if(permiso == null)
                    {
                        return null;
                    }
                    HttpContext.Current.Items[UserKey] = permiso;
                }
                return permiso;
            }
        }
    }



    public class UsuarioInfo
    {
        public cat_sistemas Usuario { get; set; }
        public Permisos Permiso { get; set; }
    }

    public class Auth2
    {
        private const string UserKey = "CRME.Auth:Userkey";

        public static UsuarioInfo UsuarioActual
        {
            get
            {
                if (!HttpContext.Current.User.Identity.IsAuthenticated)
                {
                    return null;
                }

                var usuarioInfo = HttpContext.Current.Items[UserKey] as UsuarioInfo;

                if (usuarioInfo == null)
                {
                    SIRE_Context db = new SIRE_Context();
                    var usuario = db.cat_sistemas.FirstOrDefault(x => x.correo == HttpContext.Current.User.Identity.Name);

                    if(usuario == null)
                    {
                        return null;
                    }

                    var permiso = db.Permisos.FirstOrDefault(x => Auth.Usuario.correo == HttpContext.Current.User.Identity.Name);

                    usuarioInfo = new UsuarioInfo
                    {
                        Usuario = usuario,
                        Permiso = permiso
                    };
                    HttpContext.Current.Items[UserKey] = usuarioInfo;
                }
                return usuarioInfo;
            }
        }
    }
}