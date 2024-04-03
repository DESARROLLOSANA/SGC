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
    public class ProcesosViewController : Controller
    {

        private SIRE_Context db = new SIRE_Context();
        HelpersController helper = new HelpersController();
        SqlConnection conexion = new SqlConnection();
        // GET: ProcesosView
        public ActionResult Index(int? id) // id desde el menu
        {
            ViewBag.Departamento = new SelectList(db.Departamentos.Where(x => x.Em_Cve_Sucursal == id).ToList(), "Dp_Cve_Departamento", "Dp_Descripcion");
            return View();
            
        }

        public ActionResult _TablaProcesos(int? page)
        {
            const int pageSize = 10;
            int pageNumber = (page ?? 1);

            var lista = db.Procesos.ToList();

            return PartialView(lista.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult CrearProceso(int? ide ,int? idp) // id desde el menu
        { // find
            ViewBag.ide = 1;
            ViewBag.Departamento = new SelectList(db.Departamentos.Where(x => x.Em_Cve_Sucursal == 1).ToList(), "Dp_Cve_Departamento", "Dp_Descripcion");
            ViewBag.id = idp;
            return PartialView();
        }

        public ActionResult _Formulario(long? id)
        {
            Procesos edificiossolicitud = new Procesos();

            if (id != null)
            {
                ViewBag.edit = 1;
                edificiossolicitud = db.Procesos.Find(id);
                ViewBag.tipodoc = new SelectList(db.TipoDocumento.ToList(), "id", "descripcion", edificiossolicitud.idTD);               
            }
            else
            {
                ViewBag.tipodoc = new SelectList(db.TipoDocumento.ToList(), "id", "descripcion");              
            }

            return PartialView(edificiossolicitud);
        }

        public ActionResult GuardarProceso(Procesos proceso, string ruta)
        {
            Auditoria auditoria = new Auditoria();
            var serializerCat = new JavaScriptSerializer();
            bool success = false;
            string mensajefound = "";

            if (proceso.id == 0)
            {
                var found = db.Equipo_Menor.FirstOrDefault(x => x.Descripcion == proceso.descripcion);

                //if (found != null)
                //{
                //    mensajefound = "¡Ya existe una herramienta igual!";
                //}
                //else
                //{
                try
                {
                    Procesos Edificio = new Procesos();

                    //Usuarios
                    Edificio.descripcion = proceso.descripcion;
                    Edificio.idTD = proceso.idTD;
                    Edificio.version = proceso.version;
                    Edificio.FechaEmision = proceso.FechaEmision;
                    Edificio.UltimaActu = proceso.UltimaActu;
                    Edificio.ControlCambios = proceso.ControlCambios;
                    Edificio.Indicadores = ruta;
                    Edificio.responsable = proceso.responsable;                  

                    db.Procesos.Add(Edificio);

                    if (db.SaveChanges() > 0)
                    {
                        success = true;
                    }

                    auditoria.modulo = "Procesos";
                    auditoria.idregistro = Edificio.id;
                    auditoria.accion = "Registro";
                    auditoria.tabla = "Procesos";
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
            else
            {
                try
                {
                    Procesos Edificio = db.Procesos.Find(proceso.id);                  
                    Edificio.descripcion = proceso.descripcion;
                    Edificio.idTD = proceso.idTD;
                    Edificio.version = proceso.version;
                    Edificio.FechaEmision = proceso.FechaEmision;
                    Edificio.UltimaActu = proceso.UltimaActu;
                    Edificio.ControlCambios = proceso.ControlCambios;
                    Edificio.Indicadores = ruta;
                    Edificio.responsable = proceso.responsable;                    
                    db.Entry(Edificio).State = EntityState.Modified;

                    if (db.SaveChanges() > 0)
                    {
                        success = true;
                    }

                    auditoria.modulo = "Procesos";
                    auditoria.idregistro = Edificio.id;
                    auditoria.accion = "Modificacion";
                    auditoria.tabla = "Procesos";
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
            return Json(new { success = success, mensajefound }, JsonRequestBehavior.AllowGet);
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
    }
}