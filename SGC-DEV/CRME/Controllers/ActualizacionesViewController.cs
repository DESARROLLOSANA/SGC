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
using System;
using System.Collections.Generic;

namespace CRME.Controllers
{
    public class ActualizacionesViewController : Controller
    {
        private SIRE_Context db = new SIRE_Context();
        HelpersController helper = new HelpersController();
        SqlConnection conexion = new SqlConnection();
        // GET: ProcesosView
        public ActionResult Index() 
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "AccesoView");
            }
            ViewBag.HiddenMenu = 1;
            return View();
        }

        public ActionResult _TablaActu(int? page) 
        {

            const int pageSize = 10;
            int pageNumber = (page ?? 1);
            List<actualizaciones> lista = new List<actualizaciones>();
            lista = db.actualizaciones.ToList();

            return PartialView(lista.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult CrearActu(int? idp) // id desde el menu
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "AccesoView");
            }
            ViewBag.HiddenMenu = 1;
            return PartialView();
        }

        public ActionResult CrearSoli() // id desde el menu
        { 
            return PartialView();
        }

        [HttpGet]
        public ActionResult GetPuestoByDepartamento(int Dp_Cve_Departamento)
        {
            var departamento = db.Puestos
                .Where(x => x.Estatus == true && x.Dp_Cve_Departamento == Dp_Cve_Departamento)
                .Select(x => new { Value = x.Pu_Cve_Puesto, Text = x.Pu_Descripcion })
                .ToList();

            return Json(departamento, JsonRequestBehavior.AllowGet);
        }

        public ActionResult _Formulario(long? id)
        {
            actualizaciones edificiossolicitud = new actualizaciones();           
            ViewBag.depto = new SelectList(db.Departamentos.ToList(), "Dp_Cve_Departamento", "Dp_Descripcion");
           // ViewBag.est = new SelectList(db.EstadosAC.ToList(), "id", "descripcion");
   
            return PartialView(edificiossolicitud);
        }
        public ActionResult _FormularioSoli(long? id)
        {
            SolicitudActualizaciones edificiossolicitud = new SolicitudActualizaciones();
            ViewBag.depto = new SelectList(db.Departamentos.ToList(), "Dp_Cve_Departamento", "Dp_Descripcion");
            ViewBag.pu = new SelectList("", "Dp_Cve_Departamento", "Dp_Descripcion");
            // ViewBag.est = new SelectList(db.EstadosAC.ToList(), "id", "descripcion");

            return PartialView(edificiossolicitud);
        }

        public ActionResult GuardarSoli(SolicitudActualizaciones accion)
        {
            Auditoria auditoria = new Auditoria();
            var serializerCat = new JavaScriptSerializer();
            int idemp = 0;
            bool success = false;
            string mensajefound = "";

            if (accion.Id == 0)
            {
                try
                {
                    SolicitudActualizaciones Edificio = new SolicitudActualizaciones();

                    //Usuarios
                    Edificio.NombreSolicitante = accion.NombreSolicitante;
                    Edificio.Pu_Cve_Puesto = accion.Pu_Cve_Puesto;
                    Edificio.DescripcionSolicitud = accion.DescripcionSolicitud;

                    var liscaCorre = db.Correos_Calidad.ToList();

                    foreach (var i in liscaCorre)
                    {
                        var dato = i;
                        SendMailSoli(i.Correo,accion.NombreSolicitante,db.Puestos.FirstOrDefault(x=> x.Pu_Cve_Puesto == accion.Pu_Cve_Puesto).Pu_Descripcion,accion.DescripcionSolicitud);
                    }

                    db.SolicitudActualizaciones.Add(Edificio);

                    if (db.SaveChanges() > 0)
                    {
                        success = true;
                    }

                    auditoria.modulo = "SolicitudActualizaciones";
                    auditoria.idregistro = Edificio.Id;
                    auditoria.accion = "Registro";
                    auditoria.tabla = "SolicitudActualizaciones";
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

            return Json(new { success = success, mensajefound, idemp }, JsonRequestBehavior.AllowGet);
        }

        public bool SendMailSoli(string correo, string cambio,string puesto,string descripcion)
        {
            bool success = false;
            string Remitente = ConfigurationManager.AppSettings["Remitente"].ToString();
            string Destinatario = correo;
            string Contrasenia = ConfigurationManager.AppSettings["Contrasenia"].ToString();
            string Host = ConfigurationManager.AppSettings["Host"].ToString();
            int Port = Convert.ToInt32(ConfigurationManager.AppSettings["Port"].ToString());
            bool Ssl = Convert.ToBoolean(ConfigurationManager.AppSettings["Ssl"].ToString());
            string fecha = string.Empty;
            string ruta = string.Empty;
            string html = string.Empty;

            byte[] encryted = System.Text.Encoding.Unicode.GetBytes(DateTime.Now.ToString("dd/MM/yyyy hh:mm"));
            fecha = Convert.ToBase64String(encryted);
            string path = ConfigurationManager.AppSettings["path"].ToString();

            //ruta = path + "/AccesoView/Recuperar/?op2=" + fecha + "&op1=" + usuario.sistemas_ID;

            MailMessage msg = new MailMessage();

            msg.From = new MailAddress(Remitente, "SGC");
            msg.To.Add(Destinatario);
            msg.Subject = "SOLICITUD DE ACTUALIZACIÓN";
            msg.Priority = MailPriority.Normal;
            msg.IsBodyHtml = true;

            // INICIA CUERPO DE CORREO
            html += "<div> <div style=\"background-color:#FF8C00\"><img src='cid:imagen' width=\"100\"/></div>";
            html += "<div>";
            //html += "<p> Hola " + usuario.nombre + ", </p>";
            //html += "<p>Nos ha notificado que no recuerda su contraseña para ingresar a SGC.</p>";
            //html += "<p>Para cambiar su contraseña dé click en el siguiente enlace.<p>";
            html += "</br>";
            html += "<p>" + cambio + "</p>";
            //html += "<a href='" + ruta + "' target='_blank'>Restablecer Contraseña</a>";
            html += "</br>";
            html += "</br>";
            html += "<p>" + puesto + "</p>";
            //html += "<a href='" + ruta + "' target='_blank'>Restablecer Contraseña</a>";
            html += "</br>";
            html += "</br>";
            html += "<p>" + descripcion + "</p>";
            //html += "<a href='" + ruta + "' target='_blank'>Restablecer Contraseña</a>";
            html += "</br>";
            // html += "<p>El enlace caducará en 24 hrs., así que asegúrese de utilizarlo inmediatamente.</p>";
            html += "</br>";
            html += "<p>¡Gracias por utilizar SGC!</p>";
            html += "<hr style=\"color:#FF8C00;\"/>";
            html += "<i style=\"color:#FF8C00;\">&copy; Todos los derechos reservados | SGC " + DateTime.Now.Year + "</i>";
            html += "</br>";
            html += "</br>";
            html += "</div>";
            AlternateView html2 = AlternateView.CreateAlternateViewFromString(html, null, "text/html");
            LinkedResource logo = new LinkedResource(System.Web.Hosting.HostingEnvironment.MapPath("~/Upload/Sistema/Logo_CA.png"));
            logo.ContentId = "imagen";
            //html2.LinkedResources.Add(logo);
            msg.AlternateViews.Add(html2);

            SmtpClient client = new SmtpClient();
            client.Host = Host;
            client.Port = Port;
            client.EnableSsl = Ssl;
            NetworkCredential myCreds = new NetworkCredential(Remitente, Contrasenia);
            client.Credentials = myCreds;
            client.Send(msg);

            success = true;

            return success;
        }

        public ActionResult GuardarActu(actualizaciones accion, string ruta)
        {
            Auditoria auditoria = new Auditoria();
            var serializerCat = new JavaScriptSerializer();
            int idemp = 0;
            bool success = false;
            string mensajefound = "";

            if (accion.id == 0)
            {
                try
                {
                    actualizaciones Edificio = new actualizaciones();

                    //Usuarios
                    Edificio.descripcion = accion.descripcion;
                    Edificio.Dp_Cver_Departamento = accion.Dp_Cver_Departamento;
                    Edificio.Fecha = DateTime.Now;

                    var liscaCorre = (from a in db.cat_sistemas
                                  join b in db.Puestos on a.Pu_Cve_Puesto equals b.Pu_Cve_Puesto
                                  where (b.Dp_Cve_Departamento == accion.Dp_Cver_Departamento)
                                  select a.correo).ToList();

                    foreach(var i in liscaCorre)
                    {
                        var dato = i;
                        SendMail(i,accion.descripcion);
                    }
                  
                    db.actualizaciones.Add(Edificio);

                    if (db.SaveChanges() > 0)
                    {
                        success = true;
                    }

                    auditoria.modulo = "actualizaciones";
                    auditoria.idregistro = Edificio.id;
                    auditoria.accion = "Registro";
                    auditoria.tabla = "actualizaciones";
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
           
            return Json(new { success = success, mensajefound, idemp }, JsonRequestBehavior.AllowGet);
        }

        public bool SendMail(string correo, string cambio)
        {
            bool success = false;
            string Remitente = ConfigurationManager.AppSettings["Remitente"].ToString();
            string Destinatario = correo;
            string Contrasenia = ConfigurationManager.AppSettings["Contrasenia"].ToString();
            string Host = ConfigurationManager.AppSettings["Host"].ToString();
            int Port = Convert.ToInt32(ConfigurationManager.AppSettings["Port"].ToString());
            bool Ssl = Convert.ToBoolean(ConfigurationManager.AppSettings["Ssl"].ToString());
            string fecha = string.Empty;
            string ruta = string.Empty;
            string html = string.Empty;

            byte[] encryted = System.Text.Encoding.Unicode.GetBytes(DateTime.Now.ToString("dd/MM/yyyy hh:mm"));
            fecha = Convert.ToBase64String(encryted);
            string path = ConfigurationManager.AppSettings["path"].ToString();

            //ruta = path + "/AccesoView/Recuperar/?op2=" + fecha + "&op1=" + usuario.sistemas_ID;

            MailMessage msg = new MailMessage();

            msg.From = new MailAddress(Remitente, "SGC");
            msg.To.Add(Destinatario);
            msg.Subject = "titulo";
            msg.Priority = MailPriority.Normal;
            msg.IsBodyHtml = true;

            // INICIA CUERPO DE CORREO
            html += "<div> <div style=\"background-color:#FF8C00\"><img src='cid:imagen' width=\"100\"/></div>";
            html += "<div>";
            //html += "<p> Hola " + usuario.nombre + ", </p>";
            //html += "<p>Nos ha notificado que no recuerda su contraseña para ingresar a SGC.</p>";
            //html += "<p>Para cambiar su contraseña dé click en el siguiente enlace.<p>";
            html += "</br>";
            html += cambio;
           //html += "<a href='" + ruta + "' target='_blank'>Restablecer Contraseña</a>";
           html += "</br>";
           // html += "<p>El enlace caducará en 24 hrs., así que asegúrese de utilizarlo inmediatamente.</p>";
            html += "</br>";
            html += "<p>¡Gracias por utilizar SGC!</p>";
            html += "<hr style=\"color:#FF8C00;\"/>";
            html += "<i style=\"color:#FF8C00;\">&copy; Todos los derechos reservados | SGC " + DateTime.Now.Year + "</i>";
            html += "</br>";
            html += "</br>";
            html += "</div>";
            AlternateView html2 = AlternateView.CreateAlternateViewFromString(html, null, "text/html");
            LinkedResource logo = new LinkedResource(System.Web.Hosting.HostingEnvironment.MapPath("~/Upload/Sistema/Logo_CA.png"));
            logo.ContentId = "imagen";
            //html2.LinkedResources.Add(logo);
            msg.AlternateViews.Add(html2);

            SmtpClient client = new SmtpClient();
            client.Host = Host;
            client.Port = Port;
            client.EnableSsl = Ssl;
            NetworkCredential myCreds = new NetworkCredential(Remitente, Contrasenia);
            client.Credentials = myCreds;
            client.Send(msg);

            success = true;

            return success;
        }
    }
}