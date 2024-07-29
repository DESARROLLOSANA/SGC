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
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "AccesoView");
            }
            ViewBag.HiddenMenu = 1;
            ViewBag.Departamento = new SelectList(db.Departamentos.Where(x => x.Em_Cve_Sucursal == id).ToList(), "Dp_Cve_Departamento", "Dp_Descripcion");
            ViewBag.ide = id;
            return View();
            
        }

        public ActionResult _TablaProcesos(int? page, int? dep, int? ide, int? idtd)
        {

            const int pageSize = 10;
            int pageNumber = (page ?? 1);
            List<Procesos> lista = new List<Procesos>();
            if (dep != null || dep != 0)
            {
                 lista = db.Procesos.Where(x=> x.Dp_cve_Departamento == dep).ToList();
                
            }
            ViewBag.TipoDoc = new SelectList(db.TipoDocumento.ToList(), "id", "descripcion");
            ViewBag.ide = ide;
            return PartialView(lista.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult CrearProceso(int? ide, int? idp) // id desde el menu
        { // find
            ViewBag.ide = ide;
            ViewBag.Departamento = new SelectList(db.Departamentos.Where(x => x.Em_Cve_Sucursal == ide).ToList(), "Dp_Cve_Departamento", "Dp_Descripcion");
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
                ViewBag.Departamento = new SelectList(db.Departamentos.Where(x => x.Em_Cve_Sucursal == edificiossolicitud.Em_Cve_Empresa).ToList(), "Dp_Cve_Departamento", "Dp_Descripcion", edificiossolicitud.Em_Cve_Empresa);
            }
            else
            {
                ViewBag.tipodoc = new SelectList(db.TipoDocumento.ToList(), "id", "descripcion");
            }
            //ViewBag.ide = 
            return PartialView(edificiossolicitud);
        }

        public ActionResult GuardarProceso(Procesos proceso, string ruta, string ruta2)
        {
            Auditoria auditoria = new Auditoria();
            var serializerCat = new JavaScriptSerializer();
            bool success = false;
            int idemp = 0;
            string mensajefound = "";

            if (proceso.id == 0)
            {
                var found = db.Procesos.FirstOrDefault(x => x.descripcion == proceso.descripcion);
                try
                {
                    Procesos Edificio = new Procesos();

                    //Usuarios
                    Edificio.descripcion = proceso.descripcion;
                    Edificio.idTD = proceso.idTD;
                    Edificio.version = proceso.version;
                    Edificio.FechaEmision = proceso.FechaEmision;
                    Edificio.UltimaActu = proceso.UltimaActu;
                    Edificio.ControlCambios = ruta2;
                    Edificio.Indicadores = ruta;
                    Edificio.responsable = proceso.responsable;
                    Edificio.Em_Cve_Empresa = proceso.Em_Cve_Empresa;
                    Edificio.Dp_cve_Departamento = proceso.Dp_cve_Departamento;
                    idemp = proceso.Em_Cve_Empresa;
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

                    var emcvempresa = Edificio.Em_Cve_Empresa;
                    var dpcvedepartamento = Edificio.Dp_cve_Departamento;

                    Edificio.descripcion = proceso.descripcion;
                    Edificio.idTD = proceso.idTD;
                    Edificio.version = proceso.version;
                    Edificio.FechaEmision = proceso.FechaEmision;
                    Edificio.UltimaActu = proceso.UltimaActu;


                    if (ruta2 == null || ruta2 == "")
                    {
                        Edificio.ControlCambios = proceso.ControlCambios;
                    }
                    else
                    {
                        Edificio.ControlCambios = ruta2;
                    }


                    if (ruta == null || ruta == "")
                    {
                      Edificio.Indicadores = proceso.Indicadores;
                    }
                   else
                    {
                        Edificio.Indicadores = ruta;
                    }

                    
                    Edificio.responsable = proceso.responsable;
                    Edificio.Em_Cve_Empresa = emcvempresa;
                    Edificio.Dp_cve_Departamento = dpcvedepartamento;
                    idemp = proceso.Em_Cve_Empresa;
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
            return Json(new { success = success, mensajefound, idemp }, JsonRequestBehavior.AllowGet);
        }

        //Borrar Poceso

        public ActionResult DeleteUsuario(long? Em_Cve_Empresa)
        {
            bool success = false; ;
            string mensajefound = "";

            try
            {
                Procesos condi = db.Procesos.Find(Em_Cve_Empresa);
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
        
        //CARGAR FORMATOS
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

        //public async Task<JsonResult> Uploadfile()
        //{
        //    bool success = false;
        //    string mensaje = "";
        //    string msj = "";
        //    string Filet = "";
        //    //var year = DateTime.Now;
        //    //string conver = Convert.ToString(year);
        //    string name = Path.GetRandomFileName();

        //    await Task.Run(() =>
        //    {

        //        string savedFileNameDownload = "";
        //        string nombreArchivo = "Archivo" + name;
        //        FileStream stream = null;

        //        try
        //        {
        //            foreach (string file in Request.Files)
        //            {
        //                if (System.IO.File.Exists(System.Web.Hosting.HostingEnvironment.MapPath("~/Upload/Sistema/files/" + nombreArchivo + ".pdf")))
        //                {
        //                    System.IO.File.Delete(System.Web.Hosting.HostingEnvironment.MapPath("~/Upload/Sistema/files/" + nombreArchivo + ".pdf"));
        //                }

        //                HttpPostedFileBase hpf = Request.Files[file] as HttpPostedFileBase;
        //                string savedFileName = Path.Combine(System.Web.Hosting.HostingEnvironment.MapPath("~/Upload/Sistema/files/"), nombreArchivo + Path.GetExtension(Path.GetFileName(hpf.FileName)));
        //                Filet = "~/Upload/Sistema/files/" + nombreArchivo + ".pdf";
        //                hpf.SaveAs(savedFileName);
        //                success = true;
        //            }

        //        }
        //        catch (DbEntityValidationException ex)
        //        {
        //            success = false;
        //            mensaje = "Ocurrió un problema al subir el archivo";
        //            Console.WriteLine(ex);
        //            if (stream != null)
        //                stream.Close();
        //            stream.Dispose();
        //        }
        //    });

        //    return Json(new { success = success, mensaje, Filet });
        //}

       
        
        
        //PARA GUARDAR DOCUMENTO CON NOMBRE RAMDOM.
        //public async Task<JsonResult> Uploadfile()
        //{
        //    bool success = false;
        //    string mensaje = "";
        //    string Filet = "";

        //    await Task.Run(() =>
        //    {
        //        try
        //        {
        //            foreach (string file in Request.Files)
        //            {
        //                HttpPostedFileBase hpf = Request.Files[file] as HttpPostedFileBase;

        //                // Verificar si el archivo tiene una extensión permitida
        //                string extension = Path.GetExtension(hpf.FileName).ToLower();
        //                if (extension == ".pdf" || extension == ".docx" || extension == ".xlsx" || extension == ".ods")
        //                {
        //                    // Generar un nombre único para el archivo
        //                    string uniqueFileName = Path.GetFileNameWithoutExtension(Path.GetRandomFileName()) + extension;

        //                    // Ruta donde se va a guardar el archivo
        //                    string savedFileName = Path.Combine(System.Web.Hosting.HostingEnvironment.MapPath("~/Upload/Sistema/files/"), uniqueFileName);

        //                    // Guardar el archivo en el servidor
        //                    hpf.SaveAs(savedFileName);

        //                    // Guardar la ruta relativa para la respuesta JSON
        //                    Filet = "~/Upload/Sistema/files/" + uniqueFileName;

        //                    success = true;
        //                }
        //                else
        //                {
        //                    mensaje = "La extensión del archivo no es válida. Se permiten archivos PDF, DOCX y XLSX.";
        //                    success = false;
        //                }
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            success = false;
        //            mensaje = "Ocurrió un problema al subir el archivo";
        //            Console.WriteLine(ex);
        //        }
        //    });

        //    return Json(new { success = success, mensaje, Filet });
        //}



        //PARA QUE EL DOCUMENTO SE SUBA CON SU NOMBRE ASIGNADO
        public async Task<JsonResult> Uploadfile()
        {
            bool success = false;
            string mensaje = "";
            string Filet = "";

            await Task.Run(() =>
            {
                try
                {
                    foreach (string file in Request.Files)
                    {
                        HttpPostedFileBase hpf = Request.Files[file] as HttpPostedFileBase;

                        // Verificar si el archivo tiene una extensión permitida
                        string extension = Path.GetExtension(hpf.FileName).ToLower();
                        if (extension == ".pdf" || extension == ".docx" || extension == ".xlsx" || extension == ".ods" || extension == ".odt")
                        {
                            // Ruta donde se va a guardar el archivo
                            string savedFileName = Path.Combine(System.Web.Hosting.HostingEnvironment.MapPath("~/Upload/Sistema/files/"), hpf.FileName);

                            // Guardar el archivo en el servidor
                            hpf.SaveAs(savedFileName);

                            // Guardar la ruta relativa para la respuesta JSON
                            Filet = "~/Upload/Sistema/files/" + hpf.FileName;

                            success = true;
                        }
                        else
                        {
                            mensaje = "La extensión del archivo no es válida. Se permiten archivos PDF, DOCX, XLSX y ODS.";
                            success = false;
                        }
                    }
                }
                catch (Exception ex)
                {
                    success = false;
                    mensaje = "Ocurrió un problema al subir el archivo";
                    Console.WriteLine(ex);
                }
            });

            return Json(new { success = success, mensaje, Filet });
        }

        //CARGAR DOCUMENTO (PROCESO O EL NECESARIO)
        public async Task<ActionResult> Cargarfile2()
        {
            bool success = false;
            string mensaje = "";
            string FileT2 = "";
            JsonResult Resp = await Uploadfile2();
            JavaScriptSerializer ser = new JavaScriptSerializer();
            ResponseObjectVM2 Respuestas = ser.Deserialize<ResponseObjectVM2>(ser.Serialize(Resp.Data));
            success = Respuestas.success;
            mensaje = Respuestas.mensaje;
            FileT2 = Respuestas.Filet2;
            ViewBag.rutatarjeta = Respuestas.Filet2;
            return Json(new { success = success, mensaje, FileT2 });
        }
        public async Task<JsonResult> Uploadfile2()
        {
            bool success = false;
            string mensaje = "";
            string msj = "";
            string Filet2 = "";
            //var year = DateTime.Now;
            //string conver = Convert.ToString(year);
            string name = Path.GetRandomFileName();

            await Task.Run(() =>
            {

                string savedFileNameDownload = "";
                string nombreArchivo2 = "Archivo2" + name;
                FileStream stream = null;

                try
                {
                    foreach (string file in Request.Files)
                    {
                        if (System.IO.File.Exists(System.Web.Hosting.HostingEnvironment.MapPath("~/Upload/Sistema/files/" + nombreArchivo2 + ".pdf")))
                        {
                            System.IO.File.Delete(System.Web.Hosting.HostingEnvironment.MapPath("~/Upload/Sistema/files/" + nombreArchivo2 + ".pdf"));
                        }

                        HttpPostedFileBase hpf = Request.Files[file] as HttpPostedFileBase;
                        string savedFileName = Path.Combine(System.Web.Hosting.HostingEnvironment.MapPath("~/Upload/Sistema/files/"), nombreArchivo2 + Path.GetExtension(Path.GetFileName(hpf.FileName)));
                        Filet2 = "~/Upload/Sistema/files/" + nombreArchivo2 + ".pdf";
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

            return Json(new { success = success, mensaje, Filet2 });
        }
    }
}