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
    public class IndicadoresViewController : Controller
    {
        // GET: IndicadoresView
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

        //Metodo para guardar los indicadores.

        public ActionResult SaveIndicador(cat_indicadores catind)
        {
            cat_indicadores ind = new cat_indicadores();
            var serializerCat = new JavaScriptSerializer();
            bool success = false;
            string mensajefound = "";
            var found = db.cat_indicadores.FirstOrDefault(x => x.proceso == catind.proceso);

            if (found != null)
            {
                mensajefound = "¡Ya existe un indicador que coincide con el ingresado!";

            }
            else
            {
                if (catind.indicadores_ID == 0)
                {
                    try
                    {
                        cat_indicadores catinb = new cat_indicadores();
                        var year = DateTime.Now.Year;
                        var month = DateTime.Now.Month;
                        var dia = DateTime.Now.Day;
                        catinb.proceso = catind.proceso;
                        catinb.indicador = catind.indicador;
                        catinb.form_cal = catind.form_cal;
                        catinb.res_esp = catind.res_esp;
                        catinb.resp_med = catind.resp_med;
                        catinb.frec_med = catind.frec_med;
                        catinb.resp_mej = catind.resp_mej;
                        catinb.ene = 0;
                        catinb.feb = 0;
                        catinb.mar = 0;
                        catinb.abr = 0;
                        catinb.may = 0;
                        catinb.jun = 0;
                        catinb.jul = 0;
                        catinb.ago = 0;
                        catinb.sep = 0;
                        catinb.oct = 0;
                        catinb.nov = 0;
                        catinb.dec = 0;
                        catinb.por_cum = 0;
                        catinb.mes = month;
                        catinb.year = year;
                        catinb.dia = dia;
                        db.cat_indicadores.Add(catinb);
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
                        cat_indicadores Condi = db.cat_indicadores.Find(catind.indicadores_ID);

                        int a = (int)Condi.ene;
                        int b = (int)Condi.feb;
                        int c = (int)Condi.mar;
                        int d = (int)Condi.abr;
                        int e = (int)Condi.may;
                        int f = (int)Condi.jun;
                        int g = (int)Condi.jul;
                        int h = (int)Condi.ago;
                        int i = (int)Condi.sep;
                        int j = (int)Condi.oct;
                        int k = (int)Condi.nov;
                        int l = (int)Condi.dec;
                        float m = Condi.res_esp;
                        int sum = a + b + c + d + e + f + g + h + i + j + k + l;
                        float pretotal = sum * m;
                        float total = pretotal / m;

                        Condi.ene = catind.ene;
                        Condi.feb = catind.feb;
                        Condi.mar = catind.mar;
                        Condi.abr = catind.abr;
                        Condi.may = catind.may;
                        Condi.jun = catind.jun;
                        Condi.jul = catind.jul;
                        Condi.ago = catind.ago;
                        Condi.sep = catind.sep;
                        Condi.oct = catind.oct;
                        Condi.nov = catind.nov;
                        Condi.dec = catind.dec;
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


        //Metodo para guardas los porcentajes de la tabla.
        public ActionResult SaveDatos(cat_indicadores caind)
        {
            
            var serializerCat = new JavaScriptSerializer();
            bool success = false;
            string mensajefound = "";
            try
            {
                var id = db.cat_indicadores.FirstOrDefault(x => x.indicadores_ID == caind.indicadores_ID);
                int Id_Ene = caind.ene;
                int Id_Feb = caind.feb;
                int Id_Mar = caind.mar;
                int Id_Abr = caind.abr;
                int Id_May = caind.may;
                int Id_Jun = caind.jun;
                int Id_Jul = caind.jul;
                int Id_Ago = caind.ago;
                int Id_Sep = caind.sep;
                int Id_Oct = caind.oct;
                int Id_Nov = caind.nov;
                int Id_Dec = caind.dec;

                int sum = Id_Ene + Id_Feb + Id_Mar + Id_Abr + Id_May + Id_Jun + Id_Jul + Id_Ago + Id_Sep + Id_Oct + Id_Nov + Id_Dec;
                //float pretotal = sum * m;
                //float total = pretotal / m;
                var ftotal = sum;

                cat_indicadores catibn = db.cat_indicadores.Find(caind.indicadores_ID);

                if (catibn.indicadores_ID == caind.indicadores_ID)
                {
                 catibn.ene = Id_Ene;
                 catibn.feb = Id_Feb;
                 catibn.mar = Id_Mar;
                 catibn.abr = Id_Abr;
                 catibn.may = Id_May;
                 catibn.jun = Id_Jun;
                 catibn.jul = Id_Jul;
                 catibn.ago = Id_Ago;
                 catibn.sep = Id_Sep;
                 catibn.oct = Id_Oct;
                 catibn.nov = Id_Nov;
                 catibn.dec = Id_Dec;
                 catibn.por_cum = ftotal;
                 db.Entry(catibn).State = EntityState.Modified;
                }

                //catibn.ene = Id_Ene;
                //catibn.feb = Id_Feb;
                //catibn.mar = Id_Mar;
                //catibn.abr = Id_Abr;
                //catibn.may = Id_May;
                //catibn.jun = Id_Jun;
                //catibn.jul = Id_Jul;
                //catibn.ago = Id_Ago;
                //catibn.sep = Id_Sep;
                //catibn.oct = Id_Oct;
                //catibn.nov = Id_Nov;
                //catibn.dec = Id_Dec;
                //catibn.por_cum = ftotal;
                //db.Entry(catibn).State = EntityState.Modified;

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

        //Metodo para llenar la tabla.
        public ActionResult _TablaLineas(int? page, string filtro)
        {
            const int pageSize = 10;
            int pageNumber = (page ?? 1);
            var lista = db.cat_indicadores.OrderByDescending(x => x.indicadores_ID).ToList();
            //List<Procesos> lista = new List<Procesos>();

            ViewBag.filtro = filtro;

            return PartialView(lista.ToPagedList(pageNumber, pageSize));
        }

        //Llamar al Visualizador.
        public ActionResult VisualizarInd(long? tg)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "AccesoView");
            }
            ViewBag.HiddenMenu = 1;

            return View();
        }

        //Metodo para vista de formulario de datos.
        public ActionResult _FormularioDatos(int? indicadores_ID)
        {
            cat_indicadores idIndic = new cat_indicadores();

            if (indicadores_ID != null)
            {
                ViewBag.edit = 1;
                idIndic = db.cat_indicadores.Find(indicadores_ID);
            }
            return PartialView("_FormularioDatos", idIndic);
        }

        //Metodo para la vista del formulario.
        public ActionResult _FormularioIndicadores(long? indicadores_ID)
        {
            Procesos condicion = new Procesos();
            Puestos condil = new Puestos();
            cat_periodos cond = new cat_periodos();
            cat_indicadores Indicadores = new cat_indicadores();

            if (indicadores_ID != null)
            {
                ViewBag.edit = 1;

                condicion = db.Procesos.Find(indicadores_ID);
                ViewBag.Procesos = new SelectList(db.Procesos.ToList(), "id", "descripcion", condicion.Indicadores);

                condil = db.Puestos.Find(indicadores_ID);
                ViewBag.Puestos = new SelectList(db.Puestos.ToList(), "Pu_Cve_Puesto", "Pu_Descripcion", condil.Estatus);

                cond = db.cat_periodos.Find(indicadores_ID);
                ViewBag.Periodos = new SelectList(db.cat_periodos.ToList(), "periodo_ID", "periodo_des", cond.periodo_des);

                Indicadores = db.cat_indicadores.Find(indicadores_ID);
            }
            else
            {
                ViewBag.Procesos = new SelectList(db.Procesos.Where(x => x.idTD == 1).ToList(), "id", "descripcion");
                ViewBag.Puestos = new SelectList(db.Puestos.ToList(), "Pu_Cve_Puesto", "Pu_Descripcion");
                ViewBag.Periodos = new SelectList(db.cat_periodos.ToList(), "periodo_ID", "periodo_des");
            }

            return PartialView(Indicadores);
        }

        //Metodo para generar el reporte.
        public ActionResult GenerarReporte(int? idIndicador)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "AccesoView");
            }


            var ind = db.cat_indicadores.Find(idIndicador);
            ViewBag.indicador = new SelectList(db.cat_indicadores.Where(x => x.indicadores_ID == idIndicador).ToList(), "Indicadores_ID", "Proceso");
            var serializerCat = new JavaScriptSerializer();
            var nombre = db.Procesos.Find(ind.proceso).descripcion;

            var TituloColumna1 = string.Empty;
            var TituloColumna2 = string.Empty;
            var TituloColumna3 = string.Empty;
            var TituloColumna4 = string.Empty;
            var TituloColumna5 = string.Empty;
            var TituloColumna6 = string.Empty;
            var TituloColumna7 = string.Empty;
            var TituloColumna8 = string.Empty;
            var TituloColumna9 = string.Empty;
            var TituloColumna10 = string.Empty;
            var TituloColumna11 = string.Empty;
            var TituloColumna12 = string.Empty;
            var TituloColumna13 = string.Empty;
            var TituloColumna14 = string.Empty;
            var TituloColumna15 = string.Empty;
            var TituloColumna16 = string.Empty;
            //var TituloColumna17 = string.Empty;
            //var TituloColumna18 = string.Empty;
            //var TituloColumna19 = string.Empty;


            DataTable dt = new DataTable();
            dt.Columns.Add("Valor1", typeof(int));
            dt.Columns.Add("Valor2", typeof(string));
            dt.Columns.Add("Valor3", typeof(string));
            dt.Columns.Add("Valor4", typeof(int));
            dt.Columns.Add("Valor5", typeof(int));
            dt.Columns.Add("Valor6", typeof(int));
            dt.Columns.Add("Valor7", typeof(int));
            dt.Columns.Add("Valor8", typeof(int));
            dt.Columns.Add("Valor9", typeof(int));
            dt.Columns.Add("Valor10", typeof(int));
            dt.Columns.Add("Valor11", typeof(int));
            dt.Columns.Add("Valor12", typeof(int));
            dt.Columns.Add("Valor13", typeof(int));
            dt.Columns.Add("Valor14", typeof(int));
            dt.Columns.Add("Valor15", typeof(int));
            dt.Columns.Add("Valor16", typeof(int));
            dt.Columns.Add("Valor17", typeof(int));
            dt.Columns.Add("Valor18", typeof(int));
            dt.Columns.Add("Valor19", typeof(int));

            var row = dt.NewRow();

            TituloColumna1 = nombre;
            TituloColumna2 = "Ejemplo2";
            TituloColumna3 = "Ejemplo3";
            TituloColumna4 = "Ejemplo4";
            TituloColumna5 = "Ejemplo5";
            TituloColumna6 = "Ejemplo6";
            TituloColumna7 = "Ejemplo7";
            TituloColumna8 = "Ejemplo8";
            TituloColumna9 = "Ejemplo9";
            TituloColumna10 = "Ejemplo10";
            TituloColumna11 = "Ejemplo11";
            TituloColumna12 = "Ejemplo12";
            TituloColumna13 = "Ejemplo13";
            TituloColumna14 = "Ejemplo14";
            TituloColumna15 = "Ejemplo15";
            TituloColumna16 = "Ejemplo16";
            //TituloColumna17 = "Ejemplo17";
            //TituloColumna18 = "Ejemplo18";
            //TituloColumna19 = "Ejemplo19";

            row["Valor1"] = ind.proceso;
            row["Valor2"] = ind.indicador;
            row["Valor3"] = ind.form_cal;
            row["Valor4"] = ind.res_esp;
            row["Valor5"] = ind.resp_med;
            row["Valor6"] = ind.frec_med;
            row["Valor7"] = ind.resp_mej;

            if (ind.frec_med == 1)
            {
                row["Valor8"] = ind.ene;
                row["Valor9"] = ind.feb;
                row["Valor10"] = ind.mar;
                row["Valor11"] = ind.abr;
                row["Valor12"] = ind.may;
                row["Valor13"] = ind.jun;
                row["Valor14"] = ind.jul;
                row["Valor15"] = ind.ago;
                row["Valor16"] = ind.sep;
                row["valor17"] = ind.oct;
                row["valor18"] = ind.nov;
                row["valor19"] = ind.dec;
            }
            else if (ind.frec_med == 2)
            {
                row["Valor9"] = ind.feb;
                row["Valor11"] = ind.abr;
                row["Valor13"] = ind.jun;
                row["Valor15"] = ind.ago;
                row["valor17"] = ind.oct;
                row["valor19"] = ind.dec;
            }
            else if (ind.frec_med == 3)
            {

                row["Valor10"] = ind.mar;
                row["Valor13"] = ind.jun;
                row["Valor16"] = ind.sep;
                row["valor19"] = ind.dec;
            }
            else if (ind.frec_med == 4)
            {
                row["Valor13"] = ind.jun;
                row["valor19"] = ind.dec;
            }
            else if (ind.frec_med == 5)
            {
                row["valor19"] = ind.dec;
            }


            dt.Rows.Add(row);

            string path = string.Empty;
            LocalReport localReport = new LocalReport();
            path = Path.Combine(Server.MapPath("~/Reportes/"), "Reportes.rdlc");

            localReport.ReportPath = path;
            ReportDataSource reporte = new ReportDataSource("Reportes1", dt);
            localReport.DataSources.Add(reporte);



            ReportParameter Titulo1 = new ReportParameter("Titulo1", TituloColumna1);
            ReportParameter Titulo2 = new ReportParameter("Titulo2", TituloColumna2);
            ReportParameter Titulo3 = new ReportParameter("Titulo3", TituloColumna3);
            ReportParameter Titulo4 = new ReportParameter("Titulo4", TituloColumna4);
            ReportParameter Titulo5 = new ReportParameter("Titulo5", TituloColumna5);
            ReportParameter Titulo6 = new ReportParameter("Titulo6", TituloColumna6);
            ReportParameter Titulo7 = new ReportParameter("Titulo7", TituloColumna7);
            ReportParameter Titulo8 = new ReportParameter("Titulo8", TituloColumna8);
            ReportParameter Titulo9 = new ReportParameter("Titulo9", TituloColumna9);
            ReportParameter Titulo10 = new ReportParameter("Titulo10", TituloColumna10);
            ReportParameter Titulo11 = new ReportParameter("Titulo11", TituloColumna11);
            ReportParameter Titulo12 = new ReportParameter("Titulo12", TituloColumna12);
            ReportParameter Titulo13 = new ReportParameter("Titulo13", TituloColumna13);
            ReportParameter Titulo14 = new ReportParameter("Titulo14", TituloColumna14);
            ReportParameter Titulo15 = new ReportParameter("Titulo15", TituloColumna15);
            ReportParameter Titulo16 = new ReportParameter("Titulo16", TituloColumna16);
            //ReportParameter Titulo17 = new ReportParameter("Titulo17", TituloColumna17);
            //ReportParameter Titulo18 = new ReportParameter("Titulo18", TituloColumna18);
            //ReportParameter Titulo19 = new ReportParameter("Titulo19", TituloColumna19);
            ReportParameter FechaReporte = new ReportParameter("FechaReporte", DateTime.Now.ToString());

            //Parametros a enviar en el reporte
            localReport.SetParameters(Titulo1);
            localReport.SetParameters(Titulo2);
            localReport.SetParameters(Titulo3);
            localReport.SetParameters(Titulo4);
            localReport.SetParameters(Titulo5);
            localReport.SetParameters(Titulo6);
            localReport.SetParameters(Titulo7);
            localReport.SetParameters(Titulo8);
            localReport.SetParameters(Titulo9);
            localReport.SetParameters(Titulo10);
            localReport.SetParameters(Titulo11);
            localReport.SetParameters(Titulo12);
            localReport.SetParameters(Titulo13);
            localReport.SetParameters(Titulo14);
            localReport.SetParameters(Titulo15);
            localReport.SetParameters(Titulo16);
            //localReport.SetParameters(Titulo17);
            //localReport.SetParameters(Titulo18);
            //localReport.SetParameters(Titulo19);
            localReport.SetParameters(FechaReporte);

            string reportType = "EXCELOPENXML";
            string mimeType;
            string encoding;
            string fileNameExtension;
            Warning[] warnings;
            string[] streams;
            byte[] renderedBytes;
            string fileName = "";

            renderedBytes = localReport.Render(reportType, "", out mimeType, out encoding, out fileNameExtension, out streams, out warnings);
            fileName = "Indicadores.xlsx";

            return File(renderedBytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", fileName);
        }

    }


}
