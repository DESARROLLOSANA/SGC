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

namespace CRME.Controllers
{
    public class OrganigramaViewController : Controller
    {
        // GET: SucursalesView
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

        //public ActionResult SaveSucursal(ArchivosOrganigrama sucursal)
        //{           
        //    var serializerCat = new JavaScriptSerializer();
        //    bool success = false;
        //    string mensajefound = "";
        //    var found = db.ArchivosOrganigrama.FirstOrDefault(x => x.Ruta == sucursal.Ruta && x.Em_Cve_Empresa != sucursal.Em_Cve_Empresa); // listo

        //    if (found != null)
        //    {
        //        mensajefound = "¡Ya existe una sucursal que coincide con el ingresado!";

        //    }
        //    else
        //    {
                
        //        if (sucursal.Id_Archivo == 0)
        //        {
        //            try
        //            {
        //                ArchivosOrganigrama sucur = new ArchivosOrganigrama();

        //                var pathCat = serializerCat.Deserialize<string>(sucursal.Ruta);
        //                sucur.Ruta = "~/Upload/Empresa/" + pathCat;
        //                sucur.Em_Cve_Empresa = sucursal.Em_Cve_Empresa;

        //            }
        //            catch (DbEntityValidationException ex)
        //            {
        //                var errorMessages = ex.EntityValidationErrors
        //                .SelectMany(x => x.ValidationErrors)
        //                .Select(x => x.ErrorMessage);

        //                // Join the list to a single string.
        //                var fullErrorMessage = string.Join("; ", errorMessages);

        //                // Combine the original exception message with the new one.
        //                var exceptionMessage = string.Concat(ex.Message, " The validation errors are: ", fullErrorMessage);

        //                // Throw a new DbEntityValidationException with the improved exception message.
        //                //throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);

        //                mensajefound = exceptionMessage + "fatal error";

        //            }
        //        }
        //        else
        //        {
        //            try
        //            {

        //                ArchivosOrganigrama sucur = db.ArchivosOrganigrama.Find(sucursal.Id_Archivo);
        //                if (sucur.Ruta == sucursal.Ruta)
        //                {
        //                    sucur.Ruta = sucursal.Ruta;
        //                }
        //                else
        //                {
        //                    var pathCat = serializerCat.Deserialize<string>(sucursal.Ruta);
        //                    sucur.Ruta = "~/Upload/Empresa/" + pathCat;
        //                }                        

        //                int lengthfoto1 = sucur.Ruta.Length;
        //                var quitar1 = sucur.Ruta.Remove(1, lengthfoto1 - 1);
        //                if (quitar1 == "~")
        //                {
        //                    sucur.Ruta = sucur.Ruta;
        //                }
     
                        
        //                sucur.Em_Cve_Empresa = sucursal.Em_Cve_Empresa;                                              

        //                db.Entry(sucur).State = EntityState.Modified;
        //                if (db.SaveChanges() > 0)
        //                {
        //                    success = true;
        //                }
        //            }
        //            catch (DbEntityValidationException ex)
        //            {
        //                var errorMessages = ex.EntityValidationErrors
        //               .SelectMany(x => x.ValidationErrors)
        //               .Select(x => x.ErrorMessage);

        //                // Join the list to a single string.
        //                var fullErrorMessage = string.Join("; ", errorMessages);

        //                // Combine the original exception message with the new one.
        //                var exceptionMessage = string.Concat(ex.Message, " The validation errors are: ", fullErrorMessage);

        //                // Throw a new DbEntityValidationException with the improved exception message.
        //                //throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);
        //                mensajefound = exceptionMessage + "fatal error";
        //            }
        //        }

        //    }

        //    return Json(new { success = success, mensajefound }, JsonRequestBehavior.AllowGet);

        //}


        public ActionResult SaveSucursal(ArchivosOrganigrama sucursal)
        {
            Auditoria auditoria = new Auditoria();
            var serializerCat = new JavaScriptSerializer();
            bool success = false;
            string mensajefound = "";
            var found = db.ArchivosOrganigrama.FirstOrDefault(x => x.Ruta == sucursal.Ruta && x.Em_Cve_Empresa != sucursal.Em_Cve_Empresa); // listo

            if (found != null)
            {
                mensajefound = "¡Ya existe una sucursal que coincide con la informacion ingresada!";

            }
            else
            {
                if (sucursal.Id_Archivo == 0)
                {
                    try
                    {
                        ArchivosOrganigrama sucur = new ArchivosOrganigrama();

                        //sucursal
                        var pathCat = serializerCat.Deserialize<string>(sucursal.Ruta);
                        sucur.Ruta = "/Upload/Empresa/" + pathCat;
                        sucur.Em_Cve_Empresa = sucursal.Em_Cve_Empresa;

                        db.ArchivosOrganigrama.Add(sucur);


                        if (db.SaveChanges() > 0)
                        {
                            success = true;
                        }

                        auditoria.modulo = "Usuario Registro";
                        auditoria.idregistro = Auth.Usuario.sistemas_ID;
                        auditoria.accion = "Registro";
                        auditoria.tabla = "cat_sistemas";
                        auditoria.idusuario = Auth.Usuario.sistemas_ID;
                        auditoria.fecha = DateTime.Now;

                        db.Auditoria.Add(auditoria);

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

                        ArchivosOrganigrama sucur = db.ArchivosOrganigrama.Find(sucursal.Id_Archivo);

                        //Usuarios
                        if (sucur.Ruta == sucursal.Ruta)
                        {
                            sucur.Ruta = sucursal.Ruta;
                        }
                        else
                        {
                            var pathCat = serializerCat.Deserialize<string>(sucursal.Ruta);
                            sucur.Ruta = "/Upload/Empresa/" + pathCat;
                        }

                        int lengthfoto1 = sucur.Ruta.Length;
                        var quitar1 = sucur.Ruta.Remove(1, lengthfoto1 - 1);
                        if (quitar1 == "~")
                        {
                            sucur.Ruta = sucursal.Ruta;
                        }

                        db.Entry(sucur).State = EntityState.Modified;


                        if (db.SaveChanges() > 0)
                        {
                            success = true;
                        }

                        auditoria.modulo = "Usuario Modificacion";
                        auditoria.idregistro = Auth.Usuario.sistemas_ID;
                        auditoria.accion = "Modificacion";
                        auditoria.tabla = "cat_sistemas";
                        auditoria.idusuario = Auth.Usuario.sistemas_ID;
                        auditoria.fecha = DateTime.Now;

                        db.Auditoria.Add(auditoria);

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


        //sin cambios aparentes
        public ActionResult _Formulario(long? Sc_Cve_Sucursal)
        {  //codigo para agregar y editar usuarios
            //UsuariosPersonas Personas = new UsuariosPersonas();
            ArchivosOrganigrama sucursal = new ArchivosOrganigrama();
            // Personas Persona = new Personas();
            if (Sc_Cve_Sucursal != null)
            {
                ViewBag.edit = 1;
                //db.ArchivosOrganigrama.Find(Sc_Cve_Sucursal);
                sucursal = db.ArchivosOrganigrama.Find(Sc_Cve_Sucursal);

                if (sucursal.Em_Cve_Empresa != 0){
                    ViewBag.Em_Cve_Empresa1 = new SelectList(db.Empresa.ToList(), "Em_Cve_Empresa", "Em_Descripcion", sucursal.Em_Cve_Empresa);
                }
                else
                {
                    ViewBag.Em_Cve_Empresa1 = new SelectList(db.Empresa.ToList(), "Em_Cve_Empresa", "Em_Descripcion");
                }
            }
            else
            {
                ViewBag.Em_Cve_Empresa1 = new SelectList(db.Empresa.ToList(), "Em_Cve_Empresa", "Em_Descripcion");                

            }

            return PartialView(sucursal);
        }

        //sin cambios necesarios
        public ActionResult _TablaCecos(int? page)
        {
            const int pageSize = 10;
            int pageNumber = (page ?? 1);

            var lista = db.ArchivosOrganigrama.OrderByDescending(x => x.Id_Archivo); //.Where(x => x.Em_Cve_Empresa == true).ToList();
            //var lista = db.Ce_cos.Where(x => x.Estatus == true).ToList();

            return PartialView(lista.ToPagedList(pageNumber, pageSize));
        }
        
        //cambios minimos, pendientes de verificacion

        public ActionResult DeleteSucursal(long? Ceco_ID)
        {
            bool success = false; ;
            string mensajefound = "";

            try
            {
                ArchivosOrganigrama condi = db.ArchivosOrganigrama.Find(Ceco_ID);
                db.Entry(condi).State = EntityState.Deleted;
                if (db.SaveChanges() > 0)
                {
                    success = true;
                }
            }
            catch (Exception ex)
            {
                mensajefound = "Ocurrio un error al dar baja la empresa";
            }
            return Json(new { success = success, mensajefound }, JsonRequestBehavior.AllowGet);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public JsonResult CargarLogo()
        {
            bool success = false;
            string error = "";
            var savedFileNameDownload = "";
            string savedFileName = "";
            string completeName = "";
            try
            {
                foreach (string file in Request.Files)
                {

                    HttpPostedFileBase hpf = Request.Files[file] as HttpPostedFileBase;
                    string name = Path.GetRandomFileName();
                    string extension = Path.GetExtension(Path.GetFileName(hpf.FileName));
                    completeName = name + extension;
                    savedFileName = Path.Combine(Server.MapPath("~/Upload/Empresa/"), completeName);
                    hpf.SaveAs(savedFileName);
                    success = true;

                }
            }
            catch (Exception ex)
            {
                error = "Archivo Invalido, Error al procesar el archivo";
            }

            return Json(new { success = success, error = error, savedFileName = completeName }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult EliminarLogo(string path)
        {
            bool success = false;
            try
            {
                var serializer = new JavaScriptSerializer();
                var pathh = serializer.Deserialize<string>(path);
                var rutapath = "~/Upload/Empresa/" + pathh;
                if (System.IO.File.Exists(Server.MapPath(rutapath)))
                {
                    try
                    {
                        System.IO.File.Delete(Server.MapPath(rutapath));
                        success = true;
                    }
                    catch (System.IO.IOException e)
                    {
                        Console.WriteLine(e.Message);
                    }

                }

            }
            catch (Exception exp)
            {
                ViewBag.ResultMessage = "Error occured." + exp;
            }
            return Json(new { success = success }, JsonRequestBehavior.AllowGet);
        }
    }
}