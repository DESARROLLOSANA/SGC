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
    public class AccionCorectViewController : Controller
    {
        private SIRE_Context db = new SIRE_Context();
        HelpersController helper = new HelpersController();
        SqlConnection conexion = new SqlConnection();
        // GET: ProcesosView
        public ActionResult Index() // id desde el menu
        {
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
            List<Acciones_correctivas> lista = new List<Acciones_correctivas>();
            //if (dep != null || dep != 0)
            //{
            lista = db.Acciones_correctivas.ToList();

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
            Acciones_correctivas edificiossolicitud = new Acciones_correctivas();



            if (id != null)
            {
                ViewBag.edit = 1;
                edificiossolicitud = db.Acciones_correctivas.Find(id);
                ViewBag.tipodoc = new SelectList(db.Empresa.ToList(), "Em_Cve_Empresa", "Em_Descripcion", edificiossolicitud.Em_Cve_Empresa);
                ViewBag.est = new SelectList(db.EstadosAC.ToList(), "id", "descripcion", edificiossolicitud.Estatus);
            }
            else
            {
                ViewBag.tipodoc = new SelectList(db.Empresa.ToList(), "Em_Cve_Empresa", "Em_Descripcion");
                ViewBag.est = new SelectList(db.EstadosAC.ToList(), "id", "descripcion");
            }

            return PartialView(edificiossolicitud);
        }

        public ActionResult GuardarAccion(Acciones_correctivas accion, string ruta)
        {
            Auditoria auditoria = new Auditoria();
            var serializerCat = new JavaScriptSerializer();
            int idemp = 0;
            bool success = false;
            string mensajefound = "";

            if (accion.id == 0)
            {
                var found = db.Acciones_correctivas.FirstOrDefault(x => x.Proceso == accion.Proceso);

                if (found != null)
                {
                    mensajefound = "¡Ya existe la certificacion " + found.Proceso + "!";
                }
                else
                {
                    try
                    {
                        Acciones_correctivas Edificio = new Acciones_correctivas();

                        //Usuarios
                        Edificio.Proceso = accion.Proceso;
                        Edificio.DesviacionDet = accion.DesviacionDet;                        
                        Edificio.ResponsableAC = accion.ResponsableAC;
                        Edificio.Evidencia = ruta;
                        Edificio.AccionCorrectiva = accion.AccionCorrectiva;
                        Edificio.FechaCompromiso = accion.FechaCompromiso;
                        Edificio.Estatus = accion.Estatus;
                        Edificio.Avance = accion.Avance;
                        Edificio.Em_Cve_Empresa = accion.Em_Cve_Empresa;
                        idemp = accion.Em_Cve_Empresa;

                        db.Acciones_correctivas.Add(Edificio);

                        if (db.SaveChanges() > 0)
                        {
                            success = true;
                        }

                        auditoria.modulo = "Acciones_correctivas";
                        auditoria.idregistro = Edificio.id;
                        auditoria.accion = "Registro";
                        auditoria.tabla = "Acciones_correctivas";
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
                    Acciones_correctivas Edificio = db.Acciones_correctivas.Find(accion.id);
                    Edificio.Proceso = accion.Proceso;
                    Edificio.DesviacionDet = accion.DesviacionDet;
                    Edificio.ResponsableAC = accion.ResponsableAC;
                    Edificio.Evidencia = ruta;
                    Edificio.AccionCorrectiva = accion.AccionCorrectiva;
                    Edificio.FechaCompromiso = accion.FechaCompromiso;
                    Edificio.Estatus = accion.Estatus;
                    Edificio.Avance = accion.Avance;
                    Edificio.Em_Cve_Empresa = accion.Em_Cve_Empresa;
                    idemp = accion.Em_Cve_Empresa;
                    db.Entry(Edificio).State = EntityState.Modified;

                    if (db.SaveChanges() > 0)
                    {
                        success = true;
                    }

                    auditoria.modulo = "Acciones_correctivas";
                    auditoria.idregistro = Edificio.id;
                    auditoria.accion = "Modificacion";
                    auditoria.tabla = "Acciones_correctivas";
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
                        mensaje = "¡Archivo subido con éxito!";
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
    }
}