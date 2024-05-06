using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Configuration;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using CRME.Models;
using PagedList;
using System.Threading.Tasks;
using System.IO;
using CRME.Helpers;
using System.Web.Script.Serialization;
using System.Data.SqlClient;
using OfficeOpenXml.Table;
using OfficeOpenXml;
using System.Drawing;
using OfficeOpenXml.Style;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using CRME.Reportes;
using System.Data.Entity.Validation;
using Microsoft.Reporting.WebForms;
using Microsoft.SqlServer.Types;

namespace CRME.Controllers
{
    public class PermisosViewController : Controller
    {
        // GET: PermisosView
        private SIRE_Context db = new SIRE_Context();
        HelpersController helper = new HelpersController();
        SqlConnection conexion = new SqlConnection();

        public ActionResult Index()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "AccesoView");
            }
            ViewBag.HiddenMenu = 1;
            return View();
        }

        public ActionResult _TablaPermisos(int? page, string filtro)
        {
            const int pageSize = 10;
            int pageNumber = (page ?? 1);
            var lista = db.Permisos.OrderByDescending(x => x.Id_per).ToList();

            ViewBag.filtro = filtro;

            return PartialView(lista.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult Agregarper(long? tg)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "AccesoView");
            }

            return View();
        }

        public ActionResult _FormularioPermisos(long? Id_per)
        {
            cat_perfiles cond = new cat_perfiles();
            Permisos Permiso = new Permisos();

            if (Id_per != null)
            {
                ViewBag.edit = 1;

                cond = db.cat_perfiles.Find(Id_per);
                ViewBag.Perfiles = new SelectList(db.cat_perfiles.ToList(), "perfil_ID", "perfil", cond.perfil);

                Permiso = db.Permisos.Find(Id_per);
            }
            else
            {
                ViewBag.Perfiles = new SelectList(db.cat_perfiles.ToList(), "perfil_ID", "perfil");
            }

            return PartialView(Permiso);
        }


        public ActionResult savePermisos(Permisos permiso)
        {
            Permisos ind = new Permisos();
            var serializerCat = new JavaScriptSerializer();
            bool success = false;
            string mensajefound = "";
            var found = db.Permisos.FirstOrDefault(x => x.Id_perfil == permiso.Id_perfil);

            if (found != null)
            {
                mensajefound = "¡Ya existen permisos asignados al perfil!";

            }
            else
            {

                if (permiso.Id_per == 0)
                {
                    try
                    {
                        Permisos perm = new Permisos();
                        perm.descripcion = permiso.descripcion;
                        perm.Id_perfil = permiso.Id_perfil;
                        perm.cre = permiso.cre;
                        perm.rea = permiso.rea;
                        perm.upd = permiso.upd;
                        perm.del = permiso.del;
                        db.Permisos.Add(perm);
                        if (db.SaveChanges() > 0)
                        {
                            success = true;
                        }
                    }
                    catch (DbEntityValidationException ex)
                    {
                        var errorMessages = ex.EntityValidationErrors
                        .SelectMany(x => x.ValidationErrors)
                        .Select(x => x.ErrorMessage);

                        // Join the list to a single string.
                        var fullErrorMessage = string.Join("; ", errorMessages);

                        // Combine the original exception message with the new one.
                        var exceptionMessage = string.Concat(ex.Message, " The validation errors are: ", fullErrorMessage);

                        // Throw a new DbEntityValidationException with the improved exception message.
                        //throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);

                        mensajefound = exceptionMessage + "fatal error";

                    }
                }
                else
                {
                    try
                    {
                        Permisos Condi = db.Permisos.Find(permiso.Id_per);

                        Condi.descripcion = permiso.descripcion;
                        Condi.Id_perfil = permiso.Id_perfil;
                        Condi.cre = permiso.cre;
                        Condi.rea = permiso.rea;
                        Condi.upd = permiso.upd;
                        Condi.del = permiso.del;
                        db.Entry(Condi).State = EntityState.Modified;

                        if (db.SaveChanges() > 0)
                        {
                            success = true;
                        }
                    }
                    catch (DbEntityValidationException ex)
                    {
                        var errorMessages = ex.EntityValidationErrors
                       .SelectMany(x => x.ValidationErrors)
                       .Select(x => x.ErrorMessage);

                        // Join the list to a single string.
                        var fullErrorMessage = string.Join("; ", errorMessages);

                        // Combine the original exception message with the new one.
                        var exceptionMessage = string.Concat(ex.Message, " The validation errors are: ", fullErrorMessage);

                        // Throw a new DbEntityValidationException with the improved exception message.
                        //throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);
                        mensajefound = exceptionMessage + "fatal error";
                    }

                }
            }
            return Json(new { success = success, mensajefound }, JsonRequestBehavior.AllowGet);
        }
    }
}