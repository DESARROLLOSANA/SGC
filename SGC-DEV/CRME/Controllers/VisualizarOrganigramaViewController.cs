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
    public class VisualizarOrganigramaViewController : Controller
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
                if (sucursal.Em_Cve_Empresa != 0) {
                    ViewBag.Em_Cve_Empresa1 = new SelectList(db.Empresa.ToList(), "Em_Cve_Empresa", "Em_Descripcion", sucursal.Em_Cve_Empresa);
                    ViewBag.Img = sucursal.Ruta;
                }
                else
                {
                    ViewBag.Em_Cve_Empresa1 = new SelectList(db.Empresa.ToList(), "Em_Cve_Empresa", "Em_Descripcion");
                }
            }
            else
            {
                ViewBag.Em_Cve_Empresa1 = new SelectList(db.Empresa.ToList(), "Em_Cve_Empresa", "Em_Descripcion");
                ViewBag.Img = "~/Upload/Empresa/organigramas_CICLO.png";

            }

            return PartialView(sucursal);
        }

        //public ActionResult _TablaCecos(long? Em_Cve_Empresa )
        //{
        //    //const int pageSize = 10;
        //    //int pageNumber = (page ?? 1);
        //    ViewBag.Img = "Detalle";


        //    //ArchivosOrganigrama sucursal = new ArchivosOrganigrama();

        //    //var lista = db.ArchivosOrganigrama.OrderByDescending(x => x.Id_Archivo); //.Where(x => x.Em_Cve_Empresa == true).ToList();
        //    //var lista = db.Ce_cos.Where(x => x.Estatus == true).ToList();

        //    //var sucursal = db.ArchivosOrganigrama.Where(x => x.Equals (Em_Cve_Empresa) );
        //    //db.ArchivosOrganigrama.Find(Em_Cve_Empresa);

        //    //ViewBag.Img = sucursal.Ruta;

        //    return PartialView();
        //}
        public ActionResult _TablaImg(long? Em_Cve_Empresa)
        {

            ArchivosOrganigrama sucursal = new ArchivosOrganigrama();
            ViewBag.Valor = Em_Cve_Empresa;
            int? EmCveEmpresa = (int?) Em_Cve_Empresa;

            if (Em_Cve_Empresa != null)
            {
                sucursal = db.ArchivosOrganigrama.FirstOrDefault(x => x.Em_Cve_Empresa == EmCveEmpresa);
                //sucursal = db.ArchivosOrganigrama.Where(x => x.Em_Cve_Empresa == EmCveEmpresa);
                    if (sucursal.Em_Cve_Empresa != null)
                    {
                    ViewBag.Nombre= db.Empresa.Find(Em_Cve_Empresa).Em_Descripcion;
                    ViewBag.Img = sucursal.Ruta;
                    }
            //    else
            //    {
            //        ViewBag.Em_Cve_Empresa1 = new SelectList(db.Empresa.ToList(), "Em_Cve_Empresa", "Em_Descripcion");
            //    }
            }
            else
            {
                ViewBag.Nombre = "";
                ViewBag.Img = ""; //"/Upload/Empresa/organigramas_CICLO.png";

            }


            return PartialView();
        }

        //cambios minimos, pendientes de verificacion
        public ActionResult DeleteSucursal(long? Ceco_ID)
        {
            bool success = false; ;
            string mensajefound = "";

            try
            {
                Ce_cos sucur = db.Ce_cos.Find(Ceco_ID);
                sucur.Estatus = false;
                //sucur.Fecha_Baja = DateTime.Now;
                //sucur.Oper_Baja = Auth.Usuario.username;

                db.Entry(sucur).State = EntityState.Modified;
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


        public ActionResult _FormulariowImg(long? Sc_Cve_Sucursal)
        {  //codigo para agregar y editar usuarios
            //UsuariosPersonas Personas = new UsuariosPersonas();
            ArchivosOrganigrama sucursal = new ArchivosOrganigrama();
            // Personas Persona = new Personas();
            if (Sc_Cve_Sucursal != null)
            {
                //ViewBag.edit = 1;
                //db.ArchivosOrganigrama.Find(Sc_Cve_Sucursal);
                sucursal = db.ArchivosOrganigrama.Find(Sc_Cve_Sucursal);
                if (sucursal.Em_Cve_Empresa != 0)
                {
                    ViewBag.Em_Cve_Empresa1 = new SelectList(db.Empresa.ToList(), "Em_Cve_Empresa", "Em_Descripcion", sucursal.Em_Cve_Empresa);
                    ViewBag.img = sucursal.Ruta;
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




        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}