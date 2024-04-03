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
                return RedirectToAction("Index", "IndicadoresView");
            }
            ViewBag.HiddenMenu = 1;
            return View();
        }

        //GUARDAR FORMULARIO

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
                        catinb.proceso = catind.proceso;
                        catinb.indicador = catind.indicador;
                        catinb.form_cal = catind.form_cal;
                        catinb.res_esp = catind.res_esp;
                        catinb.resp_med = catind.resp_med;
                        catinb.frec_med = catind.frec_med;
                        catinb.resp_mej = catind.resp_mej;
                        catinb.ene = catind.ene;
                        catinb.feb = catind.feb;
                        catinb.mar = catind.mar;
                        catinb.abr = catind.abr;
                        catinb.may = catind.may;
                        catinb.jun = catind.jun;
                        catinb.jul = catind.jul;
                        catinb.ago = catind.ago;
                        catinb.sep = catind.sep;
                        catinb.oct = catind.oct;
                        catinb.nov = catind.nov;
                        catinb.dec = catind.dec;
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

                        Condi.proceso = catind.proceso;
                        Condi.indicador = catind.indicador;
                        Condi.form_cal = catind.form_cal;
                        Condi.res_esp = catind.res_esp;
                        Condi.resp_med = catind.resp_med;
                        Condi.frec_med = catind.frec_med;
                        Condi.resp_mej = catind.resp_mej;
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

        //Metodo para llenar la tabla
        public ActionResult _TablaLineas(int? page, string filtro)
        {
            const int pageSize = 10;
            int pageNumber = (page ?? 1);
                var lista = db.cat_indicadores.OrderByDescending(x => x.indicadores_ID).ToList();
                   //|| x.cod_inventario.ToUpper().Contains(filtro.ToUpper().Trim()) || x.folio.ToUpper().Contains(filtro.ToUpper().Trim())
                   //|| x.ubicacion.ToUpper().Contains(filtro.ToUpper().Trim())
                   //|| x.departamento.ToUpper().Contains(filtro.ToUpper().Trim())

                ViewBag.filtro = filtro;

                return PartialView(lista.ToPagedList(pageNumber, pageSize));
        }

        //Llamar al Visualizador
        public ActionResult VisualizarInd(long? tg)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "IndicadoresView");
            }

            return View();
        }

        //Metodo para la vista del formulario
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
                ViewBag.Procesos = new SelectList(db.Procesos.ToList(), "id", "descripcion");
                ViewBag.Puestos = new SelectList(db.Puestos.ToList(), "Pu_Cve_Puesto", "Pu_Descripcion");
                ViewBag.Periodos = new SelectList(db.cat_periodos.ToList(), "periodo_ID", "periodo_des");
            }

            return PartialView(Indicadores);
        }


        //Carga de combos

        //COMBO RESPONSABLE MEDICION Y MEJORA

        //COMBO RESPONSABLE MEDICION
        public ActionResult ComboResponMed(int? sistemas_ID)
        {
            if (sistemas_ID != null)
            {
                ViewBag.sistemas_ID = new SelectList(db.cat_sistemas.ToList(), "sistemas_ID", "username", sistemas_ID);
            }
            else
            {
                ViewBag.sistemas_ID = new SelectList(db.cat_sistemas.ToList(), "sistemas_ID", "username");
            }

            return View();
        }

        //COMBO RESPONSABLE MEJORA
        public ActionResult ComboResponMej(int? sistemas_ID)
        {
            if (sistemas_ID != null)
            {
                ViewBag.sistemas_ID = new SelectList(db.cat_sistemas.ToList(), "sistemas_ID", "nombre", sistemas_ID);
            }
            else
            {
                ViewBag.sistemas_ID = new SelectList(db.cat_sistemas.ToList(), "sistemas_ID", "nombre");
            }

            return View();
        }
        //COMBO FRECUENCIA
        public ActionResult ComboFrec(int? periodo_ID)
        {
            if (periodo_ID != null)
            {
                ViewBag.periodo_ID = new SelectList(db.cat_periodos.ToList(), "periodo_ID", "periodo_des", periodo_ID);
            }
            else
            {
                ViewBag.periodo_ID = new SelectList(db.cat_periodos.ToList(), "periodo_ID", "periodo_des");
            }

            return View();
        }

        //COMBO PROCESOS

        public ActionResult ComboProc(int? id)
        {
            if (id != null)
            {
                ViewBag.id = new SelectList(db.Procesos.ToList(), "id", "descripcion", id);
            }
            else
            {
                ViewBag.id = new SelectList(db.Procesos.ToList(), "id", "descripcion");
            }

            return View();
        }
    }


}
