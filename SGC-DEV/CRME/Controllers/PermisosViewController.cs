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
            ViewBag.HiddenMenu = 1;

            return View();
        }

        public ActionResult _FormularioPermisos(long? Sc_Cve_Sucursal)
        {
            cat_sistemas cond = new cat_sistemas();
            Empresa emp = new Empresa();
            cat_perm perm = new cat_perm();
            Permisos Permiso = new Permisos();

            if (Sc_Cve_Sucursal != null)
            {
                ViewBag.edit = 1;

                cond = db.cat_sistemas.Find(Sc_Cve_Sucursal);
                ViewBag.Perfiles = new SelectList(db.cat_sistemas.ToList(), "sistemas_ID", "username", cond.username);
                emp = db.Empresa.Find(Sc_Cve_Sucursal);
                ViewBag.Empresas = new SelectList(db.Empresa.ToList(), "Em_Cve_Empresa", "Em_Descripcion", emp.Em_Descripcion);
                perm = db.cat_perms.Find(Sc_Cve_Sucursal);
                ViewBag.Cat_Perm = new SelectList(db.cat_perms.ToList(), "Id", "descripcion", perm.descripcion);
                Permiso = db.Permisos.Find(Sc_Cve_Sucursal);
               
                if (Permiso.Id_per != 0)
                {
                    ViewBag.Permiso = new SelectList(db.Permisos.ToList(), "Id_per", "User_ID", Permiso.Id_per);
                }
                else
                {
                  ViewBag.Permiso = new SelectList(db.Permisos.ToList(), "Id_per", "User_ID");
                }
            }
            else
            {
                ViewBag.Perfiles = new SelectList(db.cat_sistemas.ToList(), "sistemas_ID", "username");
                ViewBag.Empresas = new SelectList(db.Empresa.ToList(), "Em_Cve_Empresa", "Em_Descripcion");
                ViewBag.Cat_Perm = new SelectList(db.cat_perms.ToList(), "Id", "descripcion");
                ViewBag.Permiso = new SelectList(db.Permisos.ToList(), "Id_per", "User_ID");
            }

            return PartialView(Permiso);
        }

        public ActionResult _TablaModulos(int? page, string filtro)
        {
            const int pageSize = 10;
            int pageNumber = (page ?? 1);
            var lista = db.Permisos.OrderByDescending(x => x.Id_per).ToList();

            ViewBag.filtro = filtro;

            return PartialView(lista.ToPagedList(pageNumber, pageSize));
        }


        public ActionResult savePermisos(Permisos permiso, int? SGC, int? CI)
        {
            Permisos ind = new Permisos();
            var serializerCat = new JavaScriptSerializer();
            bool success = false;
            string mensajefound = "";
            var found = db.Permisos.FirstOrDefault(x => x.User_ID == permiso.User_ID && x.empresa_ID == permiso.empresa_ID);

            if (found != null)
            {
                mensajefound = "¡Ya existen permisos asignados al usuario";

            }
            else
            {

                if (permiso.Id_per == 0)
                {
                    try
                    {
                        Permisos perm = new Permisos();
                        perm.empresa_ID = permiso.empresa_ID;
                        perm.User_ID = permiso.User_ID;
                        perm.cre = permiso.cre;
                        perm.rea = permiso.rea;
                        perm.upd = permiso.upd;
                        perm.del = permiso.del;
                        perm.modulo1_ID = permiso.modulo1_ID;
                        perm.modulo2_ID = permiso.modulo2_ID;
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

                        Condi.empresa_ID = permiso.empresa_ID;
                        Condi.User_ID = permiso.User_ID;
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


        //public ActionResult DeleteUsuario(long? Em_Cve_Empresa)
        //{
        //    bool success = false; ;
        //    string mensajefound = "";

        //    try
        //    {
        //        Permisos condi = db.Permisos.Find(Em_Cve_Empresa);
        //        db.Entry(condi).State = EntityState.Deleted;
        //        if (db.SaveChanges() > 0)
        //        {
        //            success = true;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        mensajefound = "Ocurrio un error al dar baja la empresa";
        //    }
        //    return Json(new { success = success, mensajefound }, JsonRequestBehavior.AllowGet);
        //}
    }
}