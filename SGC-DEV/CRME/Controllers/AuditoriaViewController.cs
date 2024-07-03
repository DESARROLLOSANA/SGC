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
    public class AuditoriaViewController : Controller
    {
        private SIRE_Context db = new SIRE_Context();
        HelpersController helper = new HelpersController();
        SqlConnection conexion = new SqlConnection();
        // GET: ProcesosView
        public ActionResult Index() // id desde el menu
        {
            //ViewBag.Departamento = new SelectList(db.Departamentos.Where(x => x.Em_Cve_Sucursal == id).ToList(), "Dp_Cve_Departamento", "Dp_Descripcion");
            //ViewBag.ide = id;
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "AccesoView");
            }
            ViewBag.HiddenMenu = 1;
            return View();

        }

        public ActionResult _TablaAudit(int? page) // NO FUNCIONAL FILTRO DEP
        {

            const int pageSize = 10;
            int pageNumber = (page ?? 1);
            List<Auditoria_Interna> lista = new List<Auditoria_Interna>();
            //if (dep != null || dep != 0)
            //{
                lista = db.Auditoria_Interna.ToList();

            //}
           // ViewBag.ide = ide;
            return PartialView(lista.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult CrearAudit(int? idp) // id desde el menu
        { // find
            //ViewBag.ide = ide; ;
            //ViewBag.Departamento = new SelectList(db.Departamentos.Where(x => x.Em_Cve_Sucursal == ide).ToList(), "Dp_Cve_Departamento", "Dp_Descripcion");
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "AccesoView");
            }
            ViewBag.HiddenMenu = 1;
            ViewBag.id = idp;
            return PartialView();
        }

        public ActionResult _Formulario(long? id)
        {
            Auditoria_Interna edificiossolicitud = new Auditoria_Interna();

            if (id != null)
            {
                ViewBag.edit = 1;
                edificiossolicitud = db.Auditoria_Interna.Find(id);
                ViewBag.tipodoc = new SelectList(db.Empresa.ToList(), "Em_Cve_Empresa", "Em_Descripcion", edificiossolicitud.Em_Cve_Empresa);
            }
            else
            {
                ViewBag.tipodoc = new SelectList(db.Empresa.ToList(), "Em_Cve_Empresa", "Em_Descripcion");
            }

            return PartialView(edificiossolicitud);
        }

        public ActionResult GuardarProceso(Auditoria_Interna proceso, string ruta)
        {
            Auditoria auditoria = new Auditoria();
            var serializerCat = new JavaScriptSerializer();
            int idemp = 0;
            bool success = false;
            string mensajefound = "";

            if (proceso.id == 0)
            {
                var found = db.Auditoria_Interna.FirstOrDefault(x => x.Certificacion == proceso.Certificacion);

                if (found != null)
                {
                    mensajefound = "¡Ya existe la certificacion " + found.Certificacion + "!";
                }
                else
                {
                    try
                    {
                        Auditoria_Interna Edificio = new Auditoria_Interna();

                        //Usuarios
                        Edificio.Certificacion = proceso.Certificacion;
                        Edificio.Vigencia = proceso.Vigencia;
                        Edificio.version = proceso.version;
                        Edificio.FechaAuditoria = proceso.FechaAuditoria;
                        Edificio.planAuditoria = ruta;
                        Edificio.Informe = proceso.Informe;
                        Edificio.Resultado = proceso.Resultado;
                        Edificio.FechaSigAudi = proceso.FechaSigAudi;
                        Edificio.Em_Cve_Empresa = proceso.Em_Cve_Empresa;                       
                        idemp = proceso.Em_Cve_Empresa;

                        db.Auditoria_Interna.Add(Edificio);

                        if (db.SaveChanges() > 0)
                        {
                            success = true;
                        }

                        auditoria.modulo = "Control_Interno";
                        auditoria.idregistro = Edificio.id;
                        auditoria.accion = "Registro";
                        auditoria.tabla = "Control_Interno";
                        //auditoria.idusuario = Auth.Usuario.sistemas_ID;
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
            else
            {
                try
                {
                    Auditoria_Interna Edificio = db.Auditoria_Interna.Find(proceso.id);
                    Edificio.Certificacion = proceso.Certificacion;
                    Edificio.Vigencia = proceso.Vigencia;
                    Edificio.version = proceso.version;
                    Edificio.FechaAuditoria = proceso.FechaAuditoria;
                    Edificio.Informe = proceso.Informe;
                    Edificio.Resultado = proceso.Resultado;
                    Edificio.planAuditoria = ruta;
                    Edificio.FechaSigAudi = proceso.FechaSigAudi;
                    Edificio.Em_Cve_Empresa = proceso.Em_Cve_Empresa;                    
                    idemp = proceso.Em_Cve_Empresa;
                    db.Entry(Edificio).State = EntityState.Modified;

                    if (db.SaveChanges() > 0)
                    {
                        success = true;
                    }

                    auditoria.modulo = "Auditoria_Interna";
                    auditoria.idregistro = Edificio.id;
                    auditoria.accion = "Modificacion";
                    auditoria.tabla = "Auditoria_Interna";
                    // auditoria.idusuario = Auth.Usuario.sistemas_ID;
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
            return Json(new { success = success, mensajefound, idemp }, JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> Cargarfile()
        {
            bool success = false;
            string mensaje = "";
            string FileT = "";
            JsonResult Resp = await Uploadfile();
            JavaScriptSerializer ser = new JavaScriptSerializer();
            ResponseObjectVM Respuestas = ser.Deserialize<ResponseObjectVM>(ser.Serialize(Resp.Data));
            success = Respuestas.success;
            mensaje = Respuestas.mensaje;
            FileT = Respuestas.Filet;
            ViewBag.rutatarjeta = Respuestas.Filet;
            return Json(new { success = success, mensaje, FileT });
        }
        public async Task<JsonResult> Uploadfile()
        {
            bool success = false;
            string mensaje = "";
            string msj = "";
            string Filet = "";
            //var year = DateTime.Now;
            //string conver = Convert.ToString(year);
            string name = Path.GetRandomFileName();

            await Task.Run(() =>
            {

                string savedFileNameDownload = "";
                string nombreArchivo = "Archivo" + name;
                FileStream stream = null;

                try
                {
                    foreach (string file in Request.Files)
                    {
                        if (System.IO.File.Exists(System.Web.Hosting.HostingEnvironment.MapPath("~/Upload/Sistema/files/" + nombreArchivo + ".pdf")))
                        {
                            System.IO.File.Delete(System.Web.Hosting.HostingEnvironment.MapPath("~/Upload/Sistema/files/" + nombreArchivo + ".pdf"));
                        }

                        HttpPostedFileBase hpf = Request.Files[file] as HttpPostedFileBase;
                        string savedFileName = Path.Combine(System.Web.Hosting.HostingEnvironment.MapPath("~/Upload/Sistema/files/"), nombreArchivo + Path.GetExtension(Path.GetFileName(hpf.FileName)));
                        Filet = "~/Upload/Sistema/files/" + nombreArchivo + ".pdf";
                        hpf.SaveAs(savedFileName);
                        success = true;
                    }

                }
                catch (DbEntityValidationException ex)
                {
                    success = false;
                    mensaje = "Ocurrió un problema al subir el archivo";
                    Console.WriteLine(ex);
                    if (stream != null)
                        stream.Close();
                    stream.Dispose();
                }
            });

            return Json(new { success = success, mensaje, Filet });
        }


        public ActionResult ActualizarEstado(Auditoria_Interna caind)
        {

            var serializerCat = new JavaScriptSerializer();
            bool success = false;
            string mensajefound = "";
            try
            {
                var id = db.Auditoria_Interna.FirstOrDefault(x => x.id == caind.id);

                Auditoria_Interna catibn = db.Auditoria_Interna.Find(caind.id);

                if (catibn.id == caind.id)
                {
                    catibn.version = caind.version;
                    db.Entry(catibn).State = EntityState.Modified;
                }

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

            return Json(new { success = success, mensajefound }, JsonRequestBehavior.AllowGet);

        }

        public ActionResult _FormularioAceptar(int? indicadores_ID)
        {
            Auditoria_Interna idIndic = new Auditoria_Interna();

            if (indicadores_ID != null)
            {
                ViewBag.edit = 1;
                idIndic = db.Auditoria_Interna.Find(indicadores_ID);
            }
            return PartialView("_FormularioAceptar", idIndic);
        }

    }
}