﻿using System;
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

        public ActionResult CrearProceso(int? ide ,int? idp) // id desde el menu
        { // find
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "AccesoView");
            }
            ViewBag.HiddenMenu = 1;
            ViewBag.ide = ide;
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

        //CARGAR INDICADORES
        
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

        //CARGAR CONTROL CAMBIOS
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