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
    public class CtrlInternoViewController : Controller
    {
        private SIRE_Context db = new SIRE_Context();
        HelpersController helper = new HelpersController();
        SqlConnection conexion = new SqlConnection();
        // GET: ProcesosView
        public ActionResult Index(int? id) // id desde el menu
        {
            ViewBag.Departamento = new SelectList(db.Departamentos.Where(x => x.Em_Cve_Sucursal == id).ToList(), "Dp_Cve_Departamento", "Dp_Descripcion");
            ViewBag.ide = id;
            return View();

        }

        public ActionResult _TablaProcesos(int? page, int? dep, int? ide) // NO FUNCIONAL FILTRO DEP
        {

            const int pageSize = 10;
            int pageNumber = (page ?? 1);
            List<Control_Interno> lista = new List<Control_Interno>();
            if (dep != null || dep != 0)
            {
                lista = db.Control_Interno.Where(x => x.Dp_cve_Departamento == dep).ToList();

            }
            ViewBag.ide = ide;
            return PartialView(lista.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult CrearCtrlint(int? ide, int? idp) // id desde el menu
        { // find
            ViewBag.ide = ide; ;
            ViewBag.Departamento = new SelectList(db.Departamentos.Where(x => x.Em_Cve_Sucursal == ide).ToList(), "Dp_Cve_Departamento", "Dp_Descripcion");
            ViewBag.id = idp;
            return PartialView();
        }

        public ActionResult _Formulario(long? id)
        {
            Control_Interno edificiossolicitud = new Control_Interno();

            if (id != null)
            {
                ViewBag.edit = 1;
                edificiossolicitud = db.Control_Interno.Find(id);
                ViewBag.tipodoc = new SelectList(db.TipoDocumento.ToList(), "id", "descripcion", edificiossolicitud.idTD);
            }
            else
            {
                ViewBag.tipodoc = new SelectList(db.TipoDocumento.ToList(), "id", "descripcion");
            }

            return PartialView(edificiossolicitud);
        }

        public ActionResult GuardarProceso(Control_Interno proceso, string ruta)
        {
            Auditoria auditoria = new Auditoria();
            var serializerCat = new JavaScriptSerializer();
            int idemp = 0;
            bool success = false;
            string mensajefound = "";

            if (proceso.id == 0)
            {
                var found = db.Control_Interno.FirstOrDefault(x => x.descripcion == proceso.descripcion);

                if (found != null)
                {
                    mensajefound = "¡Ya existe el control interno " + found.descripcion + "!";
                }
                else
                {
                    try
                    {
                        Control_Interno Edificio = new Control_Interno();

                        //Usuarios
                        Edificio.descripcion = proceso.descripcion;
                        Edificio.idTD = proceso.idTD;
                        Edificio.version = proceso.version;
                        Edificio.FechaEmision = proceso.FechaEmision;
                        Edificio.UltimaActu = proceso.UltimaActu;
                        Edificio.ControlCambios = proceso.ControlCambios;
                        Edificio.Indicadores = ruta;
                        Edificio.responsable = proceso.responsable;
                        Edificio.Em_Cve_Empresa = proceso.Em_Cve_Empresa;
                        Edificio.Dp_cve_Departamento = proceso.Dp_cve_Departamento;
                        idemp = proceso.Em_Cve_Empresa;

                        db.Control_Interno.Add(Edificio);

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
                    Control_Interno Edificio = db.Control_Interno.Find(proceso.id);
                    Edificio.descripcion = proceso.descripcion;
                    Edificio.idTD = proceso.idTD;
                    Edificio.version = proceso.version;
                    Edificio.FechaEmision = proceso.FechaEmision;
                    Edificio.UltimaActu = proceso.UltimaActu;
                    Edificio.ControlCambios = proceso.ControlCambios;
                    Edificio.Indicadores = ruta;
                    Edificio.responsable = proceso.responsable;
                    Edificio.Em_Cve_Empresa = proceso.Em_Cve_Empresa;
                    Edificio.Dp_cve_Departamento = proceso.Dp_cve_Departamento;
                    idemp = proceso.Em_Cve_Empresa;
                    db.Entry(Edificio).State = EntityState.Modified;

                    if (db.SaveChanges() > 0)
                    {
                        success = true;
                    }

                    auditoria.modulo = "CtrlInterno";
                    auditoria.idregistro = Edificio.id;
                    auditoria.accion = "Modificacion";
                    auditoria.tabla = "Control_Interno";
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
    }
}