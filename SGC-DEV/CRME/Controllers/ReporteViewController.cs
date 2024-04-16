﻿//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.Mvc;
//using CRME.Models;
//using Microsoft.Reporting.WebForms;
//using System.Data;
//using System.IO;
//using System.Web.Script.Serialization;

//namespace CRME.Controllers
//{
//    public class ReporteViewController : Controller
//    {
//        private SIRE_Context db = new SIRE_Context();
//        public ActionResult Index(int? tipo)
//        {
//            if (!User.Identity.IsAuthenticated)
//            {
//                return RedirectToAction("Index", "AccesoView");
//            }
//            ViewBag.tipo = tipo;

//            return View();
//        }
//        public ActionResult _FormularioFiltros(long? indicadores_ID)
//        {
//            cat_indicadores Book = new cat_indicadores();

//            if (indicadores_ID != null)
//            {
//                Book = db.cat_indicadores.Find(indicadores_ID);
//                ViewBag.idBook = new SelectList(db.cat_indicadores.OrderBy(x => x.proceso).ToList(), "indicadores_ID", "proceso", Book.indicadores_ID);
//                ViewBag.idPeriodo = new SelectList(db.cat_periodos.OrderBy(x => x.periodo_ID).ToList(), "periodo_ID", "periodo_des", Book.frec_med);
//                ViewBag.Ene = new SelectList(db.cat_indicadores.OrderBy(x => x.ene).ToList(), "indicadores_ID", "ene", Book.ene);
//                ViewBag.Feb = new SelectList(db.cat_indicadores.OrderBy(x => x.feb).ToList(), "indicadores_ID", "ene", Book.feb);
//                ViewBag.Mar = new SelectList(db.cat_indicadores.OrderBy(x => x.mar).ToList(), "indicadores_ID", "mar", Book.mar);
//                ViewBag.Abr = new SelectList(db.cat_indicadores.OrderBy(x => x.abr).ToList(), "indicadores_ID", "abr", Book.abr);
//                ViewBag.May = new SelectList(db.cat_indicadores.OrderBy(x => x.may).ToList(), "indicadores_ID", "may", Book.may);
//                ViewBag.Jun = new SelectList(db.cat_indicadores.OrderBy(x => x.jun).ToList(), "indicadores_ID", "jun", Book.jun);
//                ViewBag.Jul = new SelectList(db.cat_indicadores.OrderBy(x => x.jul).ToList(), "indicadores_ID", "jul", Book.jul);
//                ViewBag.Ago = new SelectList(db.cat_indicadores.OrderBy(x => x.ago).ToList(), "indicadores_ID", "ago", Book.ago);
//                ViewBag.Sep = new SelectList(db.cat_indicadores.OrderBy(x => x.sep).ToList(), "indicadores_ID", "sep", Book.sep);
//                ViewBag.Oct = new SelectList(db.cat_indicadores.OrderBy(x => x.oct).ToList(), "indicadores_ID", "oct", Book.oct);
//                ViewBag.Nov = new SelectList(db.cat_indicadores.OrderBy(x => x.nov).ToList(), "indicadores_ID", "nov", Book.nov);
//                ViewBag.Dec = new SelectList(db.cat_indicadores.OrderBy(x => x.dec).ToList(), "indicadores_ID", "dec", Book.dec);
//            }
//            else
//            {
//                ViewBag.idBook = new SelectList(db.cat_indicadores.OrderBy(x => x.proceso).ToList(), "indicadores_ID", "proceso", Book.indicadores_ID);
//                //ViewBag.idBook = new SelectList(db.Books.OrderBy(x => x.nbBook).ToList(), "idBook", "nbBook");
//                //ViewBag.idGenero = new SelectList(db.CatGeneros.OrderBy(x => x.nbGenero).ToList(), "idGenero", "nbGenero");
//                //ViewBag.idEstadoCivil = new SelectList(db.CatEstadosCiviles.OrderBy(x => x.nbEstadoCivil).ToList(), "idEstadoCivil", "nbEstadoCivil");
//                //ViewBag.idTipoSangre = new SelectList(db.CatTiposSangre.OrderBy(x => x.nbTipoSangre).ToList(), "idTipoSangre", "nbTipoSangre");
//            }
//            //ViewBag.Licenciaturas = new SelectList(db.Licenciaturas.OrderBy(x => x.nbLicenciatura).ToList(), "idLicenciatura", "nbLicenciatura");
//            //ViewBag.Religiones = new SelectList(db.CatReligion.OrderBy(x => x.nbReligion).ToList(), "idReligion", "nbReligion");
//            //ViewBag.Estados = new SelectList(db.CatEstados.OrderBy(x => x.nbEstado).ToList(), "idEstado", "nbEstado");

//            return PartialView(Book);
//        }
//        public ActionResult _FormularioCampos(int tipo)
//        {
//            ViewBag.tipo = tipo;
//            return PartialView();
//        }
//        public ActionResult GenerarIndicador(cat_indicadores Book, int tpGrafica, string idsLicenciaturas, string idsReligiones, string idsEstados, string Campos)
//        {
//            if (!User.Identity.IsAuthenticated)
//            {
//                return RedirectToAction("Index", "AccesoView");
//            }

//            List<cat_indicadores> Alumnos = db.cat_indicadores.ToList();
//            var TituloColumna1 = string.Empty;
//            var TituloColumna2 = string.Empty;
//            var TituloColumna3 = string.Empty;
//            var TituloColumna4 = string.Empty;
//            var TituloGrafic = string.Empty;
//            var TotalDatos = 0;

//            //campo = 1 = "Nombre"
//            //campo = 2 = "Estado Civil"
//            //campo = 3 = "Edad"
//            //campo = 4 = "Telefono"
//            //campo = 5 = "Correo"
//            //campo = 6 = "Género"
//            //campo = 7 = "Licenciatura"
//            //campo = 8 = "Religón"
//            //campo = 9 = "Estado"
//            //campo = 10 = "Trabajo"
//            //campo = 11 = "Tipo de Sangre"
//            //campo = 12 = "Licencia"
//            //campo = 13 = "Tipo Egresado"
//            //campo = 14 = "Fallecido"

//            DataTable dt1 = new DataTable();
//            dt1.Columns.Add("proceso", typeof(int));
//            dt1.Columns.Add("indicador", typeof(string));
//            dt1.Columns.Add("por_cum", typeof(int));
//            dt1.Columns.Add("form_cal", typeof(int));

//            DataTable dt = new DataTable();
//            dt.Columns.Add("nbCategoria", typeof(string));
//            dt.Columns.Add("nbCategoria2", typeof(string));
//            dt.Columns.Add("numDatos", typeof(Int16));
//            dt.Columns.Add("numDatos2", typeof(Int16));


//            TituloColumna1 = "Procesador";
//            TituloColumna2 = "Indicador";
//            TituloColumna3 = "Avance";
//            TituloGrafic = "Gráfica de barras de Procesos";

//            foreach (var item in Alumnos)
//            {
//                var Proceso = db.Procesos.Find(Book.proceso).descripcion;

//            }

//            //PRUEBAS
//                //if (listacaCampos[0] == 2 && listacaCampos[1] == 3)
//                //{
//                //    #region

//                //    TituloColumna1 = "Estado Civil";
//                //    TituloColumna2 = "Edad";
//                //    TituloColumna3 = "Cantidad";
//                //    TituloGrafic = "Gráfica de barras por Estado Civil y Edad";
//                //    var CatEstadosCiviles = db.CatEstadosCiviles.ToList();
//                //    List<IndicadoresVM> ListaEdoCivilEdad = new List<IndicadoresVM>();

//                //    if (Book.proceso != null && Book.indicador != null && Book.form_cal != null)
//                //    {
//                //        for (var i = Book.numEdadMinima; i <= Book.numEdadMaxima; i++)
//                //        {
//                //            foreach (var item in Alumnos)
//                //            {
//                //                var EstadoCivil = db.CatEstadosCiviles.Find(Book.idEstadoCivil);
//                //                var edad = DateTime.Now.Year - ((DateTime)item.feNacimiento).Date.Year;
//                //                if (edad == i && item.idEstadoCivil == EstadoCivil.idEstadoCivil)
//                //                {
//                //                    IndicadoresVM IndicadorEdad = new IndicadoresVM();
//                //                    IndicadorEdad.nbCampo = EstadoCivil.nbEstadoCivil.Trim();
//                //                    IndicadorEdad.nbCampo2 = i + " Años";
//                //                    IndicadorEdad.numCampo = 1;
//                //                    ListaEdoCivilEdad.Add(IndicadorEdad);
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (Book.numEdadMinima != null && Book.numEdadMinima != null && Book.idEstadoCivil == null)
//                //    {
//                //        for (var i = Book.numEdadMinima; i <= Book.numEdadMaxima; i++)
//                //        {
//                //            foreach (var item in Alumnos)
//                //            {
//                //                foreach (var itemEC in CatEstadosCiviles)
//                //                {
//                //                    var edad = DateTime.Now.Year - ((DateTime)item.feNacimiento).Date.Year;
//                //                    if (edad == i && item.idEstadoCivil == itemEC.idEstadoCivil)
//                //                    {
//                //                        IndicadoresVM IndicadorEdad = new IndicadoresVM();
//                //                        IndicadorEdad.nbCampo = itemEC.nbEstadoCivil.Trim();
//                //                        IndicadorEdad.nbCampo2 = i + " Años";
//                //                        IndicadorEdad.numCampo = 1;
//                //                        ListaEdoCivilEdad.Add(IndicadorEdad);
//                //                    }
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (Book.numEdadMinima == null && Book.numEdadMinima == null && Book.idEstadoCivil != null)
//                //    {
//                //        for (var i = 15; i <= 80; i++)
//                //        {
//                //            foreach (var item in Alumnos)
//                //            {
//                //                var EstadoCivil = db.CatEstadosCiviles.Find(Book.idEstadoCivil);
//                //                var edad = DateTime.Now.Year - ((DateTime)item.feNacimiento).Date.Year;
//                //                if (edad == i && item.idEstadoCivil == EstadoCivil.idEstadoCivil)
//                //                {
//                //                    IndicadoresVM IndicadorEdad = new IndicadoresVM();
//                //                    IndicadorEdad.nbCampo = EstadoCivil.nbEstadoCivil.Trim();
//                //                    IndicadorEdad.nbCampo2 = i + " Años";
//                //                    IndicadorEdad.numCampo = 1;
//                //                    ListaEdoCivilEdad.Add(IndicadorEdad);
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (Book.numEdadMinima == null && Book.numEdadMinima == null && Book.idEstadoCivil == null)
//                //    {
//                //        for (var i = 15; i <= 80; i++)
//                //        {
//                //            foreach (var item in Alumnos)
//                //            {
//                //                foreach (var itemC in db.CatEstadosCiviles)
//                //                {
//                //                    var edad = DateTime.Now.Year - ((DateTime)item.feNacimiento).Date.Year;
//                //                    if (edad == i && item.CatEstadosCiviles.nbEstadoCivil.Trim().ToUpper() == itemC.nbEstadoCivil.Trim().ToUpper())
//                //                    {
//                //                        IndicadoresVM IndicadorEdad = new IndicadoresVM();
//                //                        IndicadorEdad.nbCampo = item.CatEstadosCiviles.nbEstadoCivil.Trim();
//                //                        IndicadorEdad.nbCampo2 = i + " Años";
//                //                        IndicadorEdad.numCampo = 1;
//                //                        ListaEdoCivilEdad.Add(IndicadorEdad);
//                //                    }
//                //                }
//                //            }
//                //        }
//                //    }

//                //    ListaEdoCivilEdad.ToList().ForEach(t =>
//                //    {
//                //        var row = dt.NewRow();
//                //        row["nbCategoria"] = t.nbCampo;
//                //        row["nbCategoria2"] = t.nbCampo2;
//                //        row["numDatos"] = t.numCampo;
//                //        dt.Rows.Add(row);
//                //    });
//                //    #endregion
//                //}
//                //else if (listacaCampos[0] == 2 && listacaCampos[1] == 6)
//                //{
//                //    #region

//                //    TituloColumna1 = "Estado Civil";
//                //    TituloColumna2 = "Género";
//                //    TituloColumna3 = "Cantidad";
//                //    TituloGrafic = "Gráfica de barras por Estado Civil y Género";

//                //    var CatGeneros = db.CatGeneros.ToList();
//                //    var CatEstadosCiviles = db.CatEstadosCiviles.ToList();
//                //    List<IndicadoresVM> ListaEdoCivilSexo = new List<IndicadoresVM>();
//                //    if (Book.idEstadoCivil != null && Book.idGenero != null)
//                //    {
//                //        foreach (var item in Alumnos)
//                //        {
//                //            var EstadoCivil = db.CatEstadosCiviles.Find(Book.idEstadoCivil);
//                //            var Genero = db.CatGeneros.Find(Book.idGenero);
//                //            if (item.Personas.idGenero == Genero.idGenero && item.idEstadoCivil == EstadoCivil.idEstadoCivil)
//                //            {
//                //                IndicadoresVM IndicadorECS = new IndicadoresVM();
//                //                IndicadorECS.nbCampo = EstadoCivil.nbEstadoCivil.Trim();
//                //                IndicadorECS.nbCampo2 = Genero.nbGenero;
//                //                IndicadorECS.numCampo = 1;
//                //                ListaEdoCivilSexo.Add(IndicadorECS);
//                //            }
//                //        }
//                //    }
//                //    else if (Book.idEstadoCivil != null && Book.idGenero == null)
//                //    {
//                //        foreach (var itemG in CatGeneros)
//                //        {
//                //            foreach (var item in Alumnos)
//                //            {
//                //                var EstadoCivil = db.CatEstadosCiviles.Find(Book.idEstadoCivil);
//                //                var Genero = db.CatGeneros.Find(itemG.idGenero);
//                //                if (item.Personas.idGenero == Genero.idGenero && item.idEstadoCivil == EstadoCivil.idEstadoCivil)
//                //                {
//                //                    IndicadoresVM IndicadorECS = new IndicadoresVM();
//                //                    IndicadorECS.nbCampo = EstadoCivil.nbEstadoCivil.Trim();
//                //                    IndicadorECS.nbCampo2 = Genero.nbGenero;
//                //                    IndicadorECS.numCampo = 1;
//                //                    ListaEdoCivilSexo.Add(IndicadorECS);
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (Book.idEstadoCivil == null && Book.idGenero != null)
//                //    {
//                //        foreach (var itemEC in CatEstadosCiviles)
//                //        {
//                //            foreach (var item in Alumnos)
//                //            {
//                //                var EstadoCivil = db.CatEstadosCiviles.Find(itemEC.idEstadoCivil);
//                //                var Genero = db.CatGeneros.Find(Book.idGenero);
//                //                if (item.Personas.idGenero == Genero.idGenero && item.idEstadoCivil == EstadoCivil.idEstadoCivil)
//                //                {
//                //                    IndicadoresVM IndicadorECS = new IndicadoresVM();
//                //                    IndicadorECS.nbCampo = EstadoCivil.nbEstadoCivil.Trim();
//                //                    IndicadorECS.nbCampo2 = Genero.nbGenero;
//                //                    IndicadorECS.numCampo = 1;
//                //                    ListaEdoCivilSexo.Add(IndicadorECS);
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (Book.idEstadoCivil == null && Book.idGenero == null)
//                //    {
//                //        foreach (var itemEC in CatEstadosCiviles)
//                //        {
//                //            foreach (var itemG in CatGeneros)
//                //            {
//                //                foreach (var item in Alumnos)
//                //                {
//                //                    var EstadoCivil = db.CatEstadosCiviles.Find(itemEC.idEstadoCivil);
//                //                    var Genero = db.CatGeneros.Find(itemG.idGenero);
//                //                    if (item.Personas.idGenero == Genero.idGenero && item.idEstadoCivil == EstadoCivil.idEstadoCivil)
//                //                    {
//                //                        IndicadoresVM IndicadorECS = new IndicadoresVM();
//                //                        IndicadorECS.nbCampo = EstadoCivil.nbEstadoCivil.Trim();
//                //                        IndicadorECS.nbCampo2 = Genero.nbGenero;
//                //                        IndicadorECS.numCampo = 1;
//                //                        ListaEdoCivilSexo.Add(IndicadorECS);
//                //                    }
//                //                }
//                //            }
//                //        }
//                //    }

//                //    ListaEdoCivilSexo.ToList().ForEach(t =>
//                //    {
//                //        var row = dt.NewRow();
//                //        row["nbCategoria"] = t.nbCampo;
//                //        row["nbCategoria2"] = t.nbCampo2;
//                //        row["numDatos"] = t.numCampo;
//                //        dt.Rows.Add(row);
//                //    });

//                //    #endregion
//                //}
//                //else if (listacaCampos[0] == 2 && listacaCampos[1] == 7)
//                //{
//                //    #region

//                //    TituloColumna1 = "Estado Civil";
//                //    TituloColumna2 = "Licenciatura";
//                //    TituloColumna3 = "Cantidad";
//                //    TituloGrafic = "Gráfica de barras por Estado Civil y Licenciatura";

//                //    Licenciaturas Licenciatura = new Licenciaturas();
//                //    var Licenciaturas = db.Licenciaturas.ToList();
//                //    var CatEstadosCiviles = db.CatEstadosCiviles.ToList();
//                //    List<IndicadoresVM> IndicadoresECLic = new List<IndicadoresVM>();

//                //    if (Book.idEstadoCivil != null && listaIdsLicenciaturas.Count > 0)
//                //    {
//                //        foreach (var itemL in listaIdsLicenciaturas)
//                //        {
//                //            foreach (var itemA in Alumnos)
//                //            {
//                //                var idLicenciatura = Convert.ToInt64(itemL);
//                //                Licenciatura = Licenciaturas.FirstOrDefault(x => x.idLicenciatura == idLicenciatura);
//                //                var EstadoCivil = db.CatEstadosCiviles.Find(Book.idEstadoCivil);
//                //                var FormacionesA = db.FormacionesAcademicas.Where(x => x.idAlumno == itemA.idAlumno && x.idLicenciatura == Licenciatura.idLicenciatura).ToList();
//                //                if (itemA.idEstadoCivil == EstadoCivil.idEstadoCivil && FormacionesA.Count() > 0)
//                //                {
//                //                    IndicadoresVM IndicadorECL = new IndicadoresVM();
//                //                    IndicadorECL.nbCampo = EstadoCivil.nbEstadoCivil.Trim();
//                //                    IndicadorECL.nbCampo2 = Licenciatura.nbLicenciatura.Trim();
//                //                    IndicadorECL.numCampo = 1;
//                //                    IndicadoresECLic.Add(IndicadorECL);
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (Book.idEstadoCivil == null && listaIdsLicenciaturas.Count > 0)
//                //    {
//                //        foreach (var itemL in listaIdsLicenciaturas)
//                //        {
//                //            var idLicenciatura = Convert.ToInt64(itemL);
//                //            Licenciatura = Licenciaturas.FirstOrDefault(x => x.idLicenciatura == idLicenciatura);
//                //            foreach (var itemEC in CatEstadosCiviles)
//                //            {
//                //                foreach (var itemA in Alumnos)
//                //                {
//                //                    var EstadoCivil = db.CatEstadosCiviles.Find(itemEC.idEstadoCivil);
//                //                    var FormacionesA = db.FormacionesAcademicas.Where(x => x.idAlumno == itemA.idAlumno && x.idLicenciatura == Licenciatura.idLicenciatura).ToList();
//                //                    if (itemA.idEstadoCivil == EstadoCivil.idEstadoCivil && FormacionesA.Count() > 0)
//                //                    {
//                //                        IndicadoresVM IndicadorECL = new IndicadoresVM();
//                //                        IndicadorECL.nbCampo = EstadoCivil.nbEstadoCivil.Trim();
//                //                        IndicadorECL.nbCampo2 = Licenciatura.nbLicenciatura.Trim();
//                //                        IndicadorECL.numCampo = 1;
//                //                        IndicadoresECLic.Add(IndicadorECL);
//                //                    }
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (Book.idEstadoCivil == null && listaIdsLicenciaturas.Count == 0)
//                //    {
//                //        foreach (var itemL in Licenciaturas)
//                //        {
//                //            foreach (var itemEC in CatEstadosCiviles)
//                //            {
//                //                foreach (var itemA in Alumnos)
//                //                {
//                //                    //var idLicenciatura = Convert.ToInt64(itemL);
//                //                    Licenciatura = Licenciaturas.FirstOrDefault(x => x.idLicenciatura == itemL.idLicenciatura);
//                //                    var EstadoCivil = db.CatEstadosCiviles.Find(itemEC.idEstadoCivil);
//                //                    var FormacionesA = db.FormacionesAcademicas.Where(x => x.idAlumno == itemA.idAlumno && x.idLicenciatura == Licenciatura.idLicenciatura).ToList();
//                //                    if (itemA.idEstadoCivil == EstadoCivil.idEstadoCivil && FormacionesA.Count() > 0)
//                //                    {
//                //                        IndicadoresVM IndicadorECL = new IndicadoresVM();
//                //                        IndicadorECL.nbCampo = EstadoCivil.nbEstadoCivil.Trim();
//                //                        IndicadorECL.nbCampo2 = Licenciatura.nbLicenciatura.Trim();
//                //                        IndicadorECL.numCampo = 1;
//                //                        IndicadoresECLic.Add(IndicadorECL);
//                //                    }
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (Book.idEstadoCivil != null && listaIdsLicenciaturas.Count == 0)
//                //    {
//                //        foreach (var itemL in Licenciaturas)
//                //        {
//                //            foreach (var itemA in Alumnos)
//                //            {
//                //                //var idLicenciatura = Convert.ToInt64(itemL);
//                //                Licenciatura = Licenciaturas.FirstOrDefault(x => x.idLicenciatura == itemL.idLicenciatura);
//                //                var EstadoCivil = db.CatEstadosCiviles.Find(Book.idEstadoCivil);
//                //                var FormacionesA = db.FormacionesAcademicas.Where(x => x.idAlumno == itemA.idAlumno && x.idLicenciatura == Licenciatura.idLicenciatura).ToList();
//                //                if (itemA.idEstadoCivil == EstadoCivil.idEstadoCivil && FormacionesA.Count() > 0)
//                //                {
//                //                    IndicadoresVM IndicadorECL = new IndicadoresVM();
//                //                    IndicadorECL.nbCampo = EstadoCivil.nbEstadoCivil.Trim();
//                //                    IndicadorECL.nbCampo2 = Licenciatura.nbLicenciatura.Trim();
//                //                    IndicadorECL.numCampo = 1;
//                //                    IndicadoresECLic.Add(IndicadorECL);
//                //                }
//                //            }
//                //        }
//                //    }

//                //    IndicadoresECLic.ToList().ForEach(l =>
//                //    {
//                //        var row = dt.NewRow();
//                //        row["nbCategoria"] = l.nbCampo;
//                //        row["nbCategoria2"] = l.nbCampo2;
//                //        row["numDatos"] = l.numCampo;
//                //        dt.Rows.Add(row);
//                //    });

//                //    #endregion
//                //}
//                //else if (listacaCampos[0] == 2 && listacaCampos[1] == 8)
//                //{
//                //    #region

//                //    TituloColumna1 = "Estado Civil";
//                //    TituloColumna2 = "Religion";
//                //    TituloColumna3 = "Cantidad";
//                //    TituloGrafic = "Gráfica de barras por Estado Civil y Religión";

//                //    CatReligion Religion = new CatReligion();
//                //    var Religiones = db.CatReligion.ToList();
//                //    var CatEstadosCiviles = db.CatEstadosCiviles.ToList();
//                //    List<IndicadoresVM> IndicadoresECR = new List<IndicadoresVM>();

//                //    if (Book.idEstadoCivil != null && listaIdsReligiones.Count > 0)
//                //    {
//                //        foreach (var item in listaIdsReligiones)
//                //        {
//                //            var idReligion = Convert.ToInt64(item);
//                //            Religion = Religiones.FirstOrDefault(x => x.idReligion == idReligion);
//                //            var EstadoCivil = db.CatEstadosCiviles.Find(Book.idEstadoCivil);
//                //            foreach (var itemA in Alumnos)
//                //            {
//                //                if (itemA.idEstadoCivil == Book.idEstadoCivil && itemA.idReligion == Religion.idReligion)
//                //                {
//                //                    IndicadoresVM IndicadorECR = new IndicadoresVM();
//                //                    IndicadorECR.nbCampo = EstadoCivil.nbEstadoCivil.Trim();
//                //                    IndicadorECR.nbCampo2 = Religion.nbReligion;
//                //                    IndicadorECR.numCampo = 1;
//                //                    IndicadoresECR.Add(IndicadorECR);
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (Book.idEstadoCivil == null && listaIdsReligiones.Count > 0)
//                //    {
//                //        foreach (var item in listaIdsLicenciaturas)
//                //        {
//                //            var idReligion = Convert.ToInt64(item);
//                //            Religion = Religiones.FirstOrDefault(x => x.idReligion == idReligion);
//                //            foreach (var itemEC in CatEstadosCiviles)
//                //            {
//                //                foreach (var itemA in Alumnos)
//                //                {
//                //                    if (itemA.idEstadoCivil == itemEC.idEstadoCivil && itemA.idReligion == Religion.idReligion)
//                //                    {
//                //                        IndicadoresVM IndicadorECR = new IndicadoresVM();
//                //                        IndicadorECR.nbCampo = itemEC.nbEstadoCivil.Trim();
//                //                        IndicadorECR.nbCampo2 = Religion.nbReligion;
//                //                        IndicadorECR.numCampo = 1;
//                //                        IndicadoresECR.Add(IndicadorECR);
//                //                    }
//                //                }
//                //                //var AlumnosECR = Alumnos.Where(x => x.idEstadoCivil == itemEC.idEstadoCivil && x.idReligion == Religion.idReligion).ToList();
//                //                //var EstadoCivil = db.CatEstadosCiviles.Find(Book.idEstadoCivil); 
//                //            }
//                //        }
//                //    }
//                //    else if (Book.idEstadoCivil == null && listaIdsReligiones.Count == 0)
//                //    {
//                //        foreach (var item in Religiones)
//                //        {
//                //            foreach (var itemEC in CatEstadosCiviles)
//                //            {
//                //                foreach (var itemA in Alumnos)
//                //                {
//                //                    Religion = Religiones.FirstOrDefault(x => x.idReligion == item.idReligion);
//                //                    if (itemA.idEstadoCivil == itemEC.idEstadoCivil && itemA.idReligion == Religion.idReligion)
//                //                    {
//                //                        IndicadoresVM IndicadorECR = new IndicadoresVM();
//                //                        IndicadorECR.nbCampo = itemEC.nbEstadoCivil.Trim();
//                //                        IndicadorECR.nbCampo2 = Religion.nbReligion;
//                //                        IndicadorECR.numCampo = 1;
//                //                        IndicadoresECR.Add(IndicadorECR);
//                //                    }
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (Book.idEstadoCivil != null && listaIdsReligiones.Count == 0)
//                //    {
//                //        foreach (var item in Religiones)
//                //        {
//                //            //var idReligion = Convert.ToInt64(item);
//                //            Religion = Religiones.FirstOrDefault(x => x.idReligion == item.idReligion);
//                //            var EstadoCivil = db.CatEstadosCiviles.Find(Book.idEstadoCivil);
//                //            foreach (var itemA in Alumnos)
//                //            {
//                //                if (itemA.idEstadoCivil == Book.idEstadoCivil && itemA.idReligion == Religion.idReligion)
//                //                {
//                //                    IndicadoresVM IndicadorECR = new IndicadoresVM();
//                //                    IndicadorECR.nbCampo = EstadoCivil.nbEstadoCivil.Trim();
//                //                    IndicadorECR.nbCampo2 = Religion.nbReligion;
//                //                    IndicadorECR.numCampo = 1;
//                //                    IndicadoresECR.Add(IndicadorECR);
//                //                }
//                //            }
//                //        }
//                //    }

//                //    IndicadoresECR.ToList().ForEach(l =>
//                //    {
//                //        var row = dt.NewRow();
//                //        row["nbCategoria"] = l.nbCampo;
//                //        row["nbCategoria2"] = l.nbCampo2;
//                //        row["numDatos"] = l.numCampo;
//                //        dt.Rows.Add(row);
//                //    });

//                //    #endregion
//                //}
//                //else if (listacaCampos[0] == 2 && listacaCampos[1] == 9)
//                //{
//                //    #region

//                //    TituloColumna1 = "Estado Civil";
//                //    TituloColumna2 = "Estados";
//                //    TituloColumna3 = "Cantidad";
//                //    TituloGrafic = "Gráfica de barras por Estado Civil y Estados";

//                //    var Estado = new CatEstados();
//                //    var Estados = db.CatEstados.ToList();
//                //    var CatEstadosCiviles = db.CatEstadosCiviles.ToList();
//                //    List<IndicadoresVM> IndicadoresEdoCEdos = new List<IndicadoresVM>();
//                //    if (Book.idEstadoCivil != null && listaIdsestados.Count > 0)
//                //    {
//                //        foreach (var item in listaIdsestados)
//                //        {
//                //            foreach (var itemA in Alumnos)
//                //            {
//                //                var idEstado = Convert.ToInt64(item);
//                //                Estado = Estados.FirstOrDefault(x => x.idEstado == idEstado);
//                //                var EstadoCivil = db.CatEstadosCiviles.Find(Book.idEstadoCivil);
//                //                if (itemA.idEstadoCivil == EstadoCivil.idEstadoCivil && itemA.Direcciones.nbEstado.Trim().ToUpper() == Estado.nbEstado.Trim().ToUpper())
//                //                {
//                //                    IndicadoresVM IndicadorECEstados = new IndicadoresVM();
//                //                    IndicadorECEstados.nbCampo = EstadoCivil.nbEstadoCivil.Trim();
//                //                    IndicadorECEstados.nbCampo2 = Estado.nbEstado;
//                //                    IndicadorECEstados.numCampo = 1;
//                //                    IndicadoresEdoCEdos.Add(IndicadorECEstados);
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (Book.idEstadoCivil == null && listaIdsestados.Count > 0)
//                //    {
//                //        foreach (var item in listaIdsestados)
//                //        {
//                //            foreach (var itemEC in CatEstadosCiviles)
//                //            {
//                //                foreach (var itemA in Alumnos)
//                //                {
//                //                    var idEstado = Convert.ToInt64(item);
//                //                    Estado = Estados.FirstOrDefault(x => x.idEstado == idEstado);
//                //                    var EstadoCivil = db.CatEstadosCiviles.Find(itemEC.idEstadoCivil);
//                //                    if (itemA.idEstadoCivil == EstadoCivil.idEstadoCivil && itemA.Direcciones.nbEstado.Trim().ToUpper() == Estado.nbEstado.Trim().ToUpper())
//                //                    {
//                //                        IndicadoresVM IndicadorECEstados = new IndicadoresVM();
//                //                        IndicadorECEstados.nbCampo = EstadoCivil.nbEstadoCivil.Trim();
//                //                        IndicadorECEstados.nbCampo2 = Estado.nbEstado;
//                //                        IndicadorECEstados.numCampo = 1;
//                //                        IndicadoresEdoCEdos.Add(IndicadorECEstados);
//                //                    }
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (Book.idEstadoCivil == null && listaIdsestados.Count == 0)
//                //    {
//                //        foreach (var item in Estados)
//                //        {
//                //            foreach (var itemEC in CatEstadosCiviles)
//                //            {
//                //                foreach (var itemA in Alumnos)
//                //                {
//                //                    //var idEstado = Convert.ToInt64(item);
//                //                    Estado = Estados.FirstOrDefault(x => x.idEstado == item.idEstado);
//                //                    var EstadoCivil = db.CatEstadosCiviles.Find(itemEC.idEstadoCivil);
//                //                    if (itemA.idEstadoCivil == EstadoCivil.idEstadoCivil && itemA.Direcciones.nbEstado.Trim().ToUpper() == Estado.nbEstado.Trim().ToUpper())
//                //                    {
//                //                        IndicadoresVM IndicadorECEstados = new IndicadoresVM();
//                //                        IndicadorECEstados.nbCampo = EstadoCivil.nbEstadoCivil.Trim();
//                //                        IndicadorECEstados.nbCampo2 = Estado.nbEstado;
//                //                        IndicadorECEstados.numCampo = 1;
//                //                        IndicadoresEdoCEdos.Add(IndicadorECEstados);
//                //                    }
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (Book.idEstadoCivil != null && listaIdsestados.Count == 0)
//                //    {
//                //        foreach (var item in Estados)
//                //        {
//                //            foreach (var itemA in Alumnos)
//                //            {
//                //                //var idEstado = Convert.ToInt64(item);
//                //                Estado = Estados.FirstOrDefault(x => x.idEstado == item.idEstado);
//                //                var EstadoCivil = db.CatEstadosCiviles.Find(Book.idEstadoCivil);
//                //                if (itemA.idEstadoCivil == EstadoCivil.idEstadoCivil && itemA.Direcciones.nbEstado.Trim().ToUpper() == Estado.nbEstado.Trim().ToUpper())
//                //                {
//                //                    IndicadoresVM IndicadorECEstados = new IndicadoresVM();
//                //                    IndicadorECEstados.nbCampo = EstadoCivil.nbEstadoCivil.Trim();
//                //                    IndicadorECEstados.nbCampo2 = Estado.nbEstado;
//                //                    IndicadorECEstados.numCampo = 1;
//                //                    IndicadoresEdoCEdos.Add(IndicadorECEstados);
//                //                }
//                //            }
//                //        }
//                //    }

//                //    IndicadoresEdoCEdos.ToList().ForEach(l =>
//                //    {
//                //        var row = dt.NewRow();
//                //        row["nbCategoria"] = l.nbCampo;
//                //        row["nbCategoria2"] = l.nbCampo2;
//                //        row["numDatos"] = l.numCampo;
//                //        dt.Rows.Add(row);
//                //    });

//                //    #endregion
//                //}
//                //else if (listacaCampos[0] == 2 && listacaCampos[1] == 10)
//                //{
//                //    #region

//                //    TituloColumna1 = "Estado Civil";
//                //    TituloColumna2 = "Trabajo";
//                //    TituloColumna3 = "Cantidad";
//                //    TituloGrafic = "Gráfica de barras por Estado Civil y Trabajo";
//                //    var CatEstadosCiviles = db.CatEstadosCiviles.ToList();
//                //    List<IndicadoresVM> IndicadoresEdoCTrabajo = new List<IndicadoresVM>();
//                //    if (Book.idEstadoCivil != null && Book.fgTrabajaActualmente != null)
//                //    {
//                //        foreach (var item in Alumnos)
//                //        {
//                //            var EstadoCivil = db.CatEstadosCiviles.Find(Book.idEstadoCivil);
//                //            if (item.fgTrabajaActualmente == Book.fgTrabajaActualmente && item.idEstadoCivil == EstadoCivil.idEstadoCivil)
//                //            {
//                //                IndicadoresVM IndicadorECT = new IndicadoresVM();
//                //                IndicadorECT.nbCampo = EstadoCivil.nbEstadoCivil;
//                //                IndicadorECT.nbCampo2 = (Book.fgTrabajaActualmente == true) ? "SI" : "NO";
//                //                IndicadorECT.numCampo = 1;
//                //                IndicadoresEdoCTrabajo.Add(IndicadorECT);
//                //            }
//                //        }
//                //    }
//                //    else if (Book.idEstadoCivil != null && Book.fgTrabajaActualmente == null)
//                //    {
//                //        foreach (var item in Alumnos)
//                //        {
//                //            var EstadoCivil = db.CatEstadosCiviles.Find(Book.idEstadoCivil);
//                //            if (item.fgTrabajaActualmente == true && item.idEstadoCivil == EstadoCivil.idEstadoCivil)
//                //            {
//                //                IndicadoresVM IndicadorECT = new IndicadoresVM();
//                //                IndicadorECT.nbCampo = EstadoCivil.nbEstadoCivil;
//                //                IndicadorECT.nbCampo2 = "SI";
//                //                IndicadorECT.numCampo = 1;
//                //                IndicadoresEdoCTrabajo.Add(IndicadorECT);
//                //            }
//                //            else if (item.fgTrabajaActualmente == false && item.idEstadoCivil == EstadoCivil.idEstadoCivil)
//                //            {
//                //                IndicadoresVM IndicadorECTN = new IndicadoresVM();
//                //                IndicadorECTN.nbCampo = EstadoCivil.nbEstadoCivil;
//                //                IndicadorECTN.nbCampo2 = "NO";
//                //                IndicadorECTN.numCampo = 1;
//                //                IndicadoresEdoCTrabajo.Add(IndicadorECTN);
//                //            }
//                //        }
//                //    }
//                //    else if (Book.idEstadoCivil == null && Book.fgTrabajaActualmente == null)
//                //    {
//                //        foreach (var itemEC in CatEstadosCiviles)
//                //        {
//                //            foreach (var item in Alumnos)
//                //            {
//                //                var EstadoCivil = db.CatEstadosCiviles.Find(itemEC.idEstadoCivil);
//                //                if (item.fgTrabajaActualmente == true && item.idEstadoCivil == EstadoCivil.idEstadoCivil)
//                //                {
//                //                    IndicadoresVM IndicadorECT = new IndicadoresVM();
//                //                    IndicadorECT.nbCampo = EstadoCivil.nbEstadoCivil;
//                //                    IndicadorECT.nbCampo2 = "SI";
//                //                    IndicadorECT.numCampo = 1;
//                //                    IndicadoresEdoCTrabajo.Add(IndicadorECT);
//                //                }
//                //                else if (item.fgTrabajaActualmente == false && item.idEstadoCivil == EstadoCivil.idEstadoCivil)
//                //                {
//                //                    IndicadoresVM IndicadorECTN = new IndicadoresVM();
//                //                    IndicadorECTN.nbCampo = EstadoCivil.nbEstadoCivil;
//                //                    IndicadorECTN.nbCampo2 = "NO";
//                //                    IndicadorECTN.numCampo = 1;
//                //                    IndicadoresEdoCTrabajo.Add(IndicadorECTN);
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (Book.idEstadoCivil == null && Book.fgTrabajaActualmente != null)
//                //    {
//                //        foreach (var itemEC in CatEstadosCiviles)
//                //        {
//                //            foreach (var item in Alumnos)
//                //            {
//                //                var EstadoCivil = db.CatEstadosCiviles.Find(itemEC.idEstadoCivil);
//                //                if (item.fgTrabajaActualmente == Book.fgTrabajaActualmente && item.idEstadoCivil == EstadoCivil.idEstadoCivil)
//                //                {
//                //                    IndicadoresVM IndicadorECT = new IndicadoresVM();
//                //                    IndicadorECT.nbCampo = EstadoCivil.nbEstadoCivil;
//                //                    IndicadorECT.nbCampo2 = (Book.fgTrabajaActualmente == true) ? "SI" : "NO";
//                //                    IndicadorECT.numCampo = 1;
//                //                    IndicadoresEdoCTrabajo.Add(IndicadorECT);
//                //                }
//                //            }

//                //        }
//                //    }

//                //    IndicadoresEdoCTrabajo.ToList().ForEach(l =>
//                //    {
//                //        var row = dt.NewRow();
//                //        row["nbCategoria"] = l.nbCampo;
//                //        row["nbCategoria2"] = l.nbCampo2;
//                //        row["numDatos"] = l.numCampo;
//                //        dt.Rows.Add(row);
//                //    });

//                //    #endregion
//                //}
//                //else if (listacaCampos[0] == 2 && listacaCampos[1] == 11)
//                //{
//                //    #region

//                //    TituloColumna1 = "Estado Civil";
//                //    TituloColumna2 = "Tipo de Sangre";
//                //    TituloColumna3 = "Cantidad";
//                //    TituloGrafic = "Gráfica de barras por Estado Civil y Tipo de Sangre";
//                //    var CatEstadosCiviles = db.CatEstadosCiviles.ToList();
//                //    var CatTiposSangre = db.CatTiposSangre.ToList();
//                //    List<IndicadoresVM> IndicadoresEdoCTpSangre = new List<IndicadoresVM>();
//                //    if (Book.idEstadoCivil != null && Book.idTipoSangre != null)
//                //    {
//                //        foreach (var item in Alumnos)
//                //        {
//                //            var EstadoCivil = db.CatEstadosCiviles.Find(Book.idEstadoCivil);
//                //            var TipoSangre = db.CatTiposSangre.Find(Book.idTipoSangre);
//                //            if (item.idTipoSangre == TipoSangre.idTipoSangre && item.idEstadoCivil == EstadoCivil.idEstadoCivil)
//                //            {
//                //                IndicadoresVM IndicadorECtpSangre = new IndicadoresVM();
//                //                IndicadorECtpSangre.nbCampo = EstadoCivil.nbEstadoCivil;
//                //                IndicadorECtpSangre.nbCampo2 = TipoSangre.nbTipoSangre;
//                //                IndicadorECtpSangre.numCampo = 1;
//                //                IndicadoresEdoCTpSangre.Add(IndicadorECtpSangre);
//                //            }
//                //        }
//                //    }
//                //    else if (Book.idEstadoCivil != null && Book.idTipoSangre == null)
//                //    {
//                //        foreach (var itemTS in CatTiposSangre)
//                //        {
//                //            foreach (var item in Alumnos)
//                //            {
//                //                var EstadoCivil = db.CatEstadosCiviles.Find(Book.idEstadoCivil);
//                //                var TipoSangre = db.CatTiposSangre.Find(itemTS.idTipoSangre);
//                //                if (item.idTipoSangre == TipoSangre.idTipoSangre && item.idEstadoCivil == EstadoCivil.idEstadoCivil)
//                //                {
//                //                    IndicadoresVM IndicadorECtpSangre = new IndicadoresVM();
//                //                    IndicadorECtpSangre.nbCampo = EstadoCivil.nbEstadoCivil;
//                //                    IndicadorECtpSangre.nbCampo2 = TipoSangre.nbTipoSangre;
//                //                    IndicadorECtpSangre.numCampo = 1;
//                //                    IndicadoresEdoCTpSangre.Add(IndicadorECtpSangre);
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (Book.idEstadoCivil == null && Book.idTipoSangre == null)
//                //    {
//                //        foreach (var itemEC in CatEstadosCiviles)
//                //        {
//                //            foreach (var itemTS in CatTiposSangre)
//                //            {
//                //                foreach (var item in Alumnos)
//                //                {
//                //                    var EstadoCivil = db.CatEstadosCiviles.Find(itemEC.idEstadoCivil);
//                //                    var TipoSangre = db.CatTiposSangre.Find(itemTS.idTipoSangre);
//                //                    if (item.idTipoSangre == TipoSangre.idTipoSangre && item.idEstadoCivil == EstadoCivil.idEstadoCivil)
//                //                    {
//                //                        IndicadoresVM IndicadorECtpSangre = new IndicadoresVM();
//                //                        IndicadorECtpSangre.nbCampo = EstadoCivil.nbEstadoCivil;
//                //                        IndicadorECtpSangre.nbCampo2 = TipoSangre.nbTipoSangre;
//                //                        IndicadorECtpSangre.numCampo = 1;
//                //                        IndicadoresEdoCTpSangre.Add(IndicadorECtpSangre);
//                //                    }
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (Book.idEstadoCivil == null && Book.idTipoSangre != null)
//                //    {
//                //        foreach (var itemEC in CatEstadosCiviles)
//                //        {
//                //            foreach (var item in Alumnos)
//                //            {
//                //                var EstadoCivil = db.CatEstadosCiviles.Find(itemEC.idEstadoCivil);
//                //                var TipoSangre = db.CatTiposSangre.Find(Book.idTipoSangre);
//                //                if (item.idTipoSangre == TipoSangre.idTipoSangre && item.idEstadoCivil == EstadoCivil.idEstadoCivil)
//                //                {
//                //                    IndicadoresVM IndicadorECtpSangre = new IndicadoresVM();
//                //                    IndicadorECtpSangre.nbCampo = EstadoCivil.nbEstadoCivil;
//                //                    IndicadorECtpSangre.nbCampo2 = TipoSangre.nbTipoSangre;
//                //                    IndicadorECtpSangre.numCampo = 1;
//                //                    IndicadoresEdoCTpSangre.Add(IndicadorECtpSangre);
//                //                }
//                //            }
//                //        }
//                //    }

//                //    IndicadoresEdoCTpSangre.ToList().ForEach(l =>
//                //    {
//                //        var row = dt.NewRow();
//                //        row["nbCategoria"] = l.nbCampo;
//                //        row["nbCategoria2"] = l.nbCampo2;
//                //        row["numDatos"] = l.numCampo;
//                //        dt.Rows.Add(row);
//                //    });

//                //    #endregion
//                //}
//                //else if (listacaCampos[0] == 2 && listacaCampos[1] == 12)
//                //{
//                //    #region

//                //    TituloColumna1 = "Estado Civil";
//                //    TituloColumna2 = "Licencia";
//                //    TituloColumna3 = "Cantidad";
//                //    TituloGrafic = "Gráfica de barras por Estado Civil y Licencia";
//                //    var CatEstadosCiviles = db.CatEstadosCiviles.ToList();
//                //    List<IndicadoresVM> IndicadoresEdoCLicencia = new List<IndicadoresVM>();

//                //    if (Book.idEstadoCivil != null && Book.fgLicencia != null)
//                //    {
//                //        foreach (var item in Alumnos)
//                //        {
//                //            var EstadoCivil = db.CatEstadosCiviles.Find(Book.idEstadoCivil);
//                //            if (item.fgLicencia == Book.fgLicencia && item.idEstadoCivil == EstadoCivil.idEstadoCivil)
//                //            {
//                //                IndicadoresVM IndicadorECL = new IndicadoresVM();
//                //                IndicadorECL.nbCampo = EstadoCivil.nbEstadoCivil;
//                //                IndicadorECL.nbCampo2 = (Book.fgLicencia == true) ? "SI" : "NO";
//                //                IndicadorECL.numCampo = 1;
//                //                IndicadoresEdoCLicencia.Add(IndicadorECL);
//                //            }
//                //        }
//                //    }
//                //    else if (Book.idEstadoCivil != null && Book.fgLicencia == null)
//                //    {
//                //        foreach (var item in Alumnos)
//                //        {
//                //            var EstadoCivil = db.CatEstadosCiviles.Find(Book.idEstadoCivil);
//                //            if (item.fgLicencia == true && item.idEstadoCivil == EstadoCivil.idEstadoCivil)
//                //            {
//                //                IndicadoresVM IndicadorECL = new IndicadoresVM();
//                //                IndicadorECL.nbCampo = EstadoCivil.nbEstadoCivil;
//                //                IndicadorECL.nbCampo2 = "SI";
//                //                IndicadorECL.numCampo = 1;
//                //                IndicadoresEdoCLicencia.Add(IndicadorECL);
//                //            }
//                //            else if (item.fgLicencia == false && item.idEstadoCivil == EstadoCivil.idEstadoCivil)
//                //            {
//                //                IndicadoresVM IndicadorECLN = new IndicadoresVM();
//                //                IndicadorECLN.nbCampo = EstadoCivil.nbEstadoCivil;
//                //                IndicadorECLN.nbCampo2 = "NO";
//                //                IndicadorECLN.numCampo = 1;
//                //                IndicadoresEdoCLicencia.Add(IndicadorECLN);
//                //            }
//                //        }
//                //    }
//                //    else if (Book.idEstadoCivil == null && Book.fgLicencia == null)
//                //    {
//                //        foreach (var itemEC in CatEstadosCiviles)
//                //        {
//                //            foreach (var item in Alumnos)
//                //            {
//                //                var EstadoCivil = db.CatEstadosCiviles.Find(itemEC.idEstadoCivil);
//                //                if (item.fgLicencia == true && item.idEstadoCivil == EstadoCivil.idEstadoCivil)
//                //                {
//                //                    IndicadoresVM IndicadorECL = new IndicadoresVM();
//                //                    IndicadorECL.nbCampo = EstadoCivil.nbEstadoCivil;
//                //                    IndicadorECL.nbCampo2 = "SI";
//                //                    IndicadorECL.numCampo = 1;
//                //                    IndicadoresEdoCLicencia.Add(IndicadorECL);
//                //                }
//                //                else if (item.fgLicencia == false && item.idEstadoCivil == EstadoCivil.idEstadoCivil)
//                //                {
//                //                    IndicadoresVM IndicadorECLN = new IndicadoresVM();
//                //                    IndicadorECLN.nbCampo = EstadoCivil.nbEstadoCivil;
//                //                    IndicadorECLN.nbCampo2 = "NO";
//                //                    IndicadorECLN.numCampo = 1;
//                //                    IndicadoresEdoCLicencia.Add(IndicadorECLN);
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (Book.idEstadoCivil == null && Book.fgLicencia != null)
//                //    {
//                //        foreach (var itemEC in CatEstadosCiviles)
//                //        {
//                //            foreach (var item in Alumnos)
//                //            {
//                //                var EstadoCivil = db.CatEstadosCiviles.Find(itemEC.idEstadoCivil);
//                //                if (item.fgLicencia == Book.fgLicencia && item.idEstadoCivil == EstadoCivil.idEstadoCivil)
//                //                {
//                //                    IndicadoresVM IndicadorECL = new IndicadoresVM();
//                //                    IndicadorECL.nbCampo = EstadoCivil.nbEstadoCivil;
//                //                    IndicadorECL.nbCampo2 = (Book.fgLicencia == true) ? "SI" : "NO";
//                //                    IndicadorECL.numCampo = 1;
//                //                    IndicadoresEdoCLicencia.Add(IndicadorECL);
//                //                }
//                //            }

//                //        }
//                //    }

//                //    IndicadoresEdoCLicencia.ToList().ForEach(l =>
//                //    {
//                //        var row = dt.NewRow();
//                //        row["nbCategoria"] = l.nbCampo;
//                //        row["nbCategoria2"] = l.nbCampo2;
//                //        row["numDatos"] = l.numCampo;
//                //        dt.Rows.Add(row);
//                //    });

//                //    #endregion
//                //}
//                //else if (listacaCampos[0] == 2 && listacaCampos[1] == 13)
//                //{
//                //    #region

//                //    TituloColumna1 = "Estado Civil";
//                //    TituloColumna2 = "Tipo de Egresado";
//                //    TituloColumna3 = "Cantidad";
//                //    TituloGrafic = "Gráfica de barras por Estado Civil y Tipo de Egresado";
//                //    var CatEstadosCiviles = db.CatEstadosCiviles.ToList();
//                //    List<IndicadoresVM> IndicadoresEdoCtpEgresado = new List<IndicadoresVM>();

//                //    if (Book.idEstadoCivil != null && Book.tpEgresado != null)
//                //    {
//                //        foreach (var item in Alumnos)
//                //        {
//                //            var EstadoCivil = db.CatEstadosCiviles.Find(Book.idEstadoCivil);
//                //            if (item.tpEgresado == Book.tpEgresado && item.idEstadoCivil == EstadoCivil.idEstadoCivil)
//                //            {
//                //                IndicadoresVM IndicadorECL = new IndicadoresVM();
//                //                IndicadorECL.nbCampo = EstadoCivil.nbEstadoCivil;
//                //                IndicadorECL.nbCampo2 = (Book.tpEgresado == "P") ? "Pasante" : "Titulado";
//                //                IndicadorECL.numCampo = 1;
//                //                IndicadoresEdoCtpEgresado.Add(IndicadorECL);
//                //            }
//                //        }
//                //    }
//                //    else if (Book.idEstadoCivil != null && Book.tpEgresado == null)
//                //    {
//                //        foreach (var item in Alumnos)
//                //        {
//                //            var EstadoCivil = db.CatEstadosCiviles.Find(Book.idEstadoCivil);
//                //            if (item.tpEgresado == "T" && item.idEstadoCivil == EstadoCivil.idEstadoCivil)
//                //            {
//                //                IndicadoresVM IndicadorECL = new IndicadoresVM();
//                //                IndicadorECL.nbCampo = EstadoCivil.nbEstadoCivil;
//                //                IndicadorECL.nbCampo2 = "Titulado";
//                //                IndicadorECL.numCampo = 1;
//                //                IndicadoresEdoCtpEgresado.Add(IndicadorECL);
//                //            }
//                //            else if (item.tpEgresado == "P" && item.idEstadoCivil == EstadoCivil.idEstadoCivil)
//                //            {
//                //                IndicadoresVM IndicadorECLN = new IndicadoresVM();
//                //                IndicadorECLN.nbCampo = EstadoCivil.nbEstadoCivil;
//                //                IndicadorECLN.nbCampo2 = "Pasante";
//                //                IndicadorECLN.numCampo = 1;
//                //                IndicadoresEdoCtpEgresado.Add(IndicadorECLN);
//                //            }
//                //        }
//                //    }
//                //    else if (Book.idEstadoCivil == null && Book.tpEgresado == null)
//                //    {
//                //        foreach (var itemEC in CatEstadosCiviles)
//                //        {
//                //            foreach (var item in Alumnos)
//                //            {
//                //                var EstadoCivil = db.CatEstadosCiviles.Find(itemEC.idEstadoCivil);
//                //                if (item.tpEgresado == "T" && item.idEstadoCivil == EstadoCivil.idEstadoCivil)
//                //                {
//                //                    IndicadoresVM IndicadorECL = new IndicadoresVM();
//                //                    IndicadorECL.nbCampo = EstadoCivil.nbEstadoCivil;
//                //                    IndicadorECL.nbCampo2 = "Titulado";
//                //                    IndicadorECL.numCampo = 1;
//                //                    IndicadoresEdoCtpEgresado.Add(IndicadorECL);
//                //                }
//                //                else if (item.tpEgresado == "P" && item.idEstadoCivil == EstadoCivil.idEstadoCivil)
//                //                {
//                //                    IndicadoresVM IndicadorECLN = new IndicadoresVM();
//                //                    IndicadorECLN.nbCampo = EstadoCivil.nbEstadoCivil;
//                //                    IndicadorECLN.nbCampo2 = "Pasante";
//                //                    IndicadorECLN.numCampo = 1;
//                //                    IndicadoresEdoCtpEgresado.Add(IndicadorECLN);
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (Book.idEstadoCivil == null && Book.tpEgresado != null)
//                //    {
//                //        foreach (var itemEC in CatEstadosCiviles)
//                //        {
//                //            foreach (var item in Alumnos)
//                //            {
//                //                var EstadoCivil = db.CatEstadosCiviles.Find(itemEC.idEstadoCivil);
//                //                if (item.tpEgresado == Book.tpEgresado && item.idEstadoCivil == EstadoCivil.idEstadoCivil)
//                //                {
//                //                    IndicadoresVM IndicadorECL = new IndicadoresVM();
//                //                    IndicadorECL.nbCampo = EstadoCivil.nbEstadoCivil;
//                //                    IndicadorECL.nbCampo2 = (Book.tpEgresado == "P") ? "Pasante" : "Titulado";
//                //                    IndicadorECL.numCampo = 1;
//                //                    IndicadoresEdoCtpEgresado.Add(IndicadorECL);
//                //                }
//                //            }
//                //        }
//                //    }

//                //    IndicadoresEdoCtpEgresado.ToList().ForEach(l =>
//                //    {
//                //        var row = dt.NewRow();
//                //        row["nbCategoria"] = l.nbCampo;
//                //        row["nbCategoria2"] = l.nbCampo2;
//                //        row["numDatos"] = l.numCampo;
//                //        dt.Rows.Add(row);
//                //    });

//                //    #endregion
//                //}
//                //else if (listacaCampos[0] == 2 && listacaCampos[1] == 14)
//                //{
//                //    #region

//                //    TituloColumna1 = "Estado Civil";
//                //    TituloColumna2 = "Fallecimiento";
//                //    TituloColumna3 = "Cantidad";
//                //    TituloGrafic = "Gráfica de barras por Estado Civil y Fallecimiento";
//                //    var CatEstadosCiviles = db.CatEstadosCiviles.ToList();
//                //    List<IndicadoresVM> IndicadoresEdoCFallecido = new List<IndicadoresVM>();


//                //    if (Book.idEstadoCivil != null && Book.fgFallecido != null)
//                //    {
//                //        foreach (var item in Alumnos)
//                //        {
//                //            var EstadoCivil = db.CatEstadosCiviles.Find(Book.idEstadoCivil);
//                //            if (item.fgFallecido == Book.fgFallecido && item.idEstadoCivil == EstadoCivil.idEstadoCivil)
//                //            {
//                //                IndicadoresVM IndicadorECF = new IndicadoresVM();
//                //                IndicadorECF.nbCampo = EstadoCivil.nbEstadoCivil;
//                //                IndicadorECF.nbCampo2 = (Book.fgFallecido == true) ? "SI" : "NO";
//                //                IndicadorECF.numCampo = 1;
//                //                IndicadoresEdoCFallecido.Add(IndicadorECF);
//                //            }
//                //        }
//                //    }
//                //    else if (Book.idEstadoCivil != null && Book.fgFallecido == null)
//                //    {
//                //        foreach (var item in Alumnos)
//                //        {
//                //            var EstadoCivil = db.CatEstadosCiviles.Find(Book.idEstadoCivil);
//                //            if (item.fgFallecido == true && item.idEstadoCivil == EstadoCivil.idEstadoCivil)
//                //            {
//                //                IndicadoresVM IndicadorECF = new IndicadoresVM();
//                //                IndicadorECF.nbCampo = EstadoCivil.nbEstadoCivil;
//                //                IndicadorECF.nbCampo2 = "SI";
//                //                IndicadorECF.numCampo = 1;
//                //                IndicadoresEdoCFallecido.Add(IndicadorECF);
//                //            }
//                //            else if (item.fgFallecido == false && item.idEstadoCivil == EstadoCivil.idEstadoCivil)
//                //            {
//                //                IndicadoresVM IndicadorECFN = new IndicadoresVM();
//                //                IndicadorECFN.nbCampo = EstadoCivil.nbEstadoCivil;
//                //                IndicadorECFN.nbCampo2 = "NO";
//                //                IndicadorECFN.numCampo = 1;
//                //                IndicadoresEdoCFallecido.Add(IndicadorECFN);
//                //            }
//                //        }
//                //    }
//                //    else if (Book.idEstadoCivil == null && Book.fgFallecido == null)
//                //    {
//                //        foreach (var itemEC in CatEstadosCiviles)
//                //        {
//                //            foreach (var item in Alumnos)
//                //            {
//                //                var EstadoCivil = db.CatEstadosCiviles.Find(itemEC.idEstadoCivil);
//                //                if (item.fgFallecido == true && item.idEstadoCivil == EstadoCivil.idEstadoCivil)
//                //                {
//                //                    IndicadoresVM IndicadorECF = new IndicadoresVM();
//                //                    IndicadorECF.nbCampo = EstadoCivil.nbEstadoCivil;
//                //                    IndicadorECF.nbCampo2 = "SI";
//                //                    IndicadorECF.numCampo = 1;
//                //                    IndicadoresEdoCFallecido.Add(IndicadorECF);
//                //                }
//                //                else if (item.fgFallecido == false && item.idEstadoCivil == EstadoCivil.idEstadoCivil)
//                //                {
//                //                    IndicadoresVM IndicadorECFN = new IndicadoresVM();
//                //                    IndicadorECFN.nbCampo = EstadoCivil.nbEstadoCivil;
//                //                    IndicadorECFN.nbCampo2 = "NO";
//                //                    IndicadorECFN.numCampo = 1;
//                //                    IndicadoresEdoCFallecido.Add(IndicadorECFN);
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (Book.idEstadoCivil == null && Book.fgFallecido != null)
//                //    {
//                //        foreach (var itemEC in CatEstadosCiviles)
//                //        {
//                //            foreach (var item in Alumnos)
//                //            {
//                //                var EstadoCivil = db.CatEstadosCiviles.Find(itemEC.idEstadoCivil);
//                //                if (item.fgFallecido == Book.fgFallecido && item.idEstadoCivil == EstadoCivil.idEstadoCivil)
//                //                {
//                //                    IndicadoresVM IndicadorECF = new IndicadoresVM();
//                //                    IndicadorECF.nbCampo = EstadoCivil.nbEstadoCivil;
//                //                    IndicadorECF.nbCampo2 = (Book.fgFallecido == true) ? "SI" : "NO";
//                //                    IndicadorECF.numCampo = 1;
//                //                    IndicadoresEdoCFallecido.Add(IndicadorECF);
//                //                }
//                //            }
//                //        }
//                //    }

//                //    IndicadoresEdoCFallecido.ToList().ForEach(l =>
//                //    {
//                //        var row = dt.NewRow();
//                //        row["nbCategoria"] = l.nbCampo;
//                //        row["nbCategoria2"] = l.nbCampo2;
//                //        row["numDatos"] = l.numCampo;
//                //        dt.Rows.Add(row);
//                //    });

//                //    #endregion
//                //}
//                //else if (listacaCampos[0] == 3 && listacaCampos[1] == 2)
//                //{
//                //    #region

//                //    TituloColumna1 = "Edad";
//                //    TituloColumna2 = "Estado Civil";
//                //    TituloColumna3 = "Cantidad";
//                //    TituloGrafic = "Gráfica de barras por Edad y Estado Civil";

//                //    var CatEstadosCiviles = db.CatEstadosCiviles.ToList();
//                //    List<IndicadoresVM> ListaEdadEdoCivil = new List<IndicadoresVM>();

//                //    if (Book.numEdadMinima != null && Book.numEdadMinima != null && Book.idEstadoCivil != null)
//                //    {
//                //        for (var i = Book.numEdadMinima; i <= Book.numEdadMaxima; i++)
//                //        {
//                //            foreach (var item in Alumnos)
//                //            {
//                //                var EstadoCivil = db.CatEstadosCiviles.Find(Book.idEstadoCivil);
//                //                var edad = DateTime.Now.Year - ((DateTime)item.feNacimiento).Date.Year;
//                //                if (edad == i && item.idEstadoCivil == EstadoCivil.idEstadoCivil)
//                //                {
//                //                    IndicadoresVM IndicadorEdad = new IndicadoresVM();
//                //                    IndicadorEdad.nbCampo = i + " Años";
//                //                    IndicadorEdad.nbCampo2 = EstadoCivil.nbEstadoCivil.Trim();
//                //                    IndicadorEdad.numCampo = 1;
//                //                    ListaEdadEdoCivil.Add(IndicadorEdad);
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (Book.numEdadMinima != null && Book.numEdadMinima != null && Book.idEstadoCivil == null)
//                //    {
//                //        for (var i = Book.numEdadMinima; i <= Book.numEdadMaxima; i++)
//                //        {
//                //            foreach (var item in Alumnos)
//                //            {
//                //                foreach (var itemEC in CatEstadosCiviles)
//                //                {
//                //                    var edad = DateTime.Now.Year - ((DateTime)item.feNacimiento).Date.Year;
//                //                    if (edad == i && item.idEstadoCivil == itemEC.idEstadoCivil)
//                //                    {
//                //                        IndicadoresVM IndicadorEdad = new IndicadoresVM();
//                //                        IndicadorEdad.nbCampo = i + " Años";
//                //                        IndicadorEdad.nbCampo2 = itemEC.nbEstadoCivil.Trim();
//                //                        IndicadorEdad.numCampo = 1;
//                //                        ListaEdadEdoCivil.Add(IndicadorEdad);
//                //                    }
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (Book.numEdadMinima == null && Book.numEdadMinima == null && Book.idEstadoCivil != null)
//                //    {
//                //        for (var i = 15; i <= 80; i++)
//                //        {
//                //            foreach (var item in Alumnos)
//                //            {
//                //                var EstadoCivil = db.CatEstadosCiviles.Find(Book.idEstadoCivil);
//                //                var edad = DateTime.Now.Year - ((DateTime)item.feNacimiento).Date.Year;
//                //                if (edad == i && item.idEstadoCivil == EstadoCivil.idEstadoCivil)
//                //                {
//                //                    IndicadoresVM IndicadorEdad = new IndicadoresVM();
//                //                    IndicadorEdad.nbCampo = i + " Años";
//                //                    IndicadorEdad.nbCampo2 = EstadoCivil.nbEstadoCivil.Trim();
//                //                    IndicadorEdad.numCampo = 1;
//                //                    ListaEdadEdoCivil.Add(IndicadorEdad);
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (Book.numEdadMinima == null && Book.numEdadMinima == null && Book.idEstadoCivil == null)
//                //    {
//                //        for (var i = 15; i <= 80; i++)
//                //        {
//                //            foreach (var item in Alumnos)
//                //            {
//                //                foreach (var itemC in db.CatEstadosCiviles)
//                //                {
//                //                    var edad = DateTime.Now.Year - ((DateTime)item.feNacimiento).Date.Year;
//                //                    if (edad == i && item.CatEstadosCiviles.nbEstadoCivil.Trim().ToUpper() == itemC.nbEstadoCivil.Trim().ToUpper())
//                //                    {
//                //                        IndicadoresVM IndicadorEdad = new IndicadoresVM();
//                //                        IndicadorEdad.nbCampo = i + " Años";
//                //                        IndicadorEdad.nbCampo2 = item.CatEstadosCiviles.nbEstadoCivil.Trim();
//                //                        IndicadorEdad.numCampo = 1;
//                //                        ListaEdadEdoCivil.Add(IndicadorEdad);
//                //                    }

//                //                }
//                //            }
//                //        }
//                //    }

//                //    ListaEdadEdoCivil.ToList().ForEach(t =>
//                //    {
//                //        var row = dt.NewRow();
//                //        row["nbCategoria"] = t.nbCampo;
//                //        row["nbCategoria2"] = t.nbCampo2;
//                //        row["numDatos"] = t.numCampo;
//                //        dt.Rows.Add(row);
//                //    });

//                //    #endregion
//                //}
//                //else if (listacaCampos[0] == 3 && listacaCampos[1] == 6)
//                //{
//                //    #region

//                //    TituloColumna1 = "Edad";
//                //    TituloColumna2 = "Género";
//                //    TituloColumna3 = "Cantidad";
//                //    TituloGrafic = "Gráfica de barras por Edad y Género";

//                //    var CatGeneros = db.CatGeneros.ToList();
//                //    List<IndicadoresVM> ListaEdadGenero = new List<IndicadoresVM>();

//                //    if (Book.numEdadMinima != null && Book.numEdadMinima != null && Book.idGenero != null)
//                //    {
//                //        for (var i = Book.numEdadMinima; i <= Book.numEdadMaxima; i++)
//                //        {
//                //            foreach (var item in Alumnos)
//                //            {
//                //                var Genero = db.CatGeneros.Find(Book.idGenero);
//                //                var edad = DateTime.Now.Year - ((DateTime)item.feNacimiento).Date.Year;
//                //                if (edad == i && item.Personas.idGenero == Genero.idGenero)
//                //                {
//                //                    IndicadoresVM IndicadorEdadG = new IndicadoresVM();
//                //                    IndicadorEdadG.nbCampo = i + " Años";
//                //                    IndicadorEdadG.nbCampo2 = Genero.nbGenero.Trim();
//                //                    IndicadorEdadG.numCampo = 1;
//                //                    ListaEdadGenero.Add(IndicadorEdadG);
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (Book.numEdadMinima != null && Book.numEdadMinima != null && Book.idGenero == null)
//                //    {
//                //        for (var i = Book.numEdadMinima; i <= Book.numEdadMaxima; i++)
//                //        {
//                //            foreach (var item in Alumnos)
//                //            {
//                //                foreach (var itemG in CatGeneros)
//                //                {
//                //                    var edad = DateTime.Now.Year - ((DateTime)item.feNacimiento).Date.Year;
//                //                    if (edad == i && item.Personas.idGenero == itemG.idGenero)
//                //                    {
//                //                        IndicadoresVM IndicadorEdadG = new IndicadoresVM();
//                //                        IndicadorEdadG.nbCampo = i + " Años";
//                //                        IndicadorEdadG.nbCampo2 = itemG.nbGenero.Trim();
//                //                        IndicadorEdadG.numCampo = 1;
//                //                        ListaEdadGenero.Add(IndicadorEdadG);
//                //                    }
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (Book.numEdadMinima == null && Book.numEdadMinima == null && Book.idGenero != null)
//                //    {
//                //        for (var i = 15; i <= 80; i++)
//                //        {
//                //            foreach (var item in Alumnos)
//                //            {
//                //                var Genero = db.CatGeneros.Find(Book.idGenero);
//                //                var edad = DateTime.Now.Year - ((DateTime)item.feNacimiento).Date.Year;
//                //                if (edad == i && item.Personas.idGenero == Genero.idGenero)
//                //                {
//                //                    IndicadoresVM IndicadorEdadG = new IndicadoresVM();
//                //                    IndicadorEdadG.nbCampo = i + " Años";
//                //                    IndicadorEdadG.nbCampo2 = Genero.nbGenero.Trim();
//                //                    IndicadorEdadG.numCampo = 1;
//                //                    ListaEdadGenero.Add(IndicadorEdadG);
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (Book.numEdadMinima == null && Book.numEdadMinima == null && Book.idGenero == null)
//                //    {
//                //        for (var i = 15; i <= 80; i++)
//                //        {
//                //            foreach (var item in Alumnos)
//                //            {
//                //                foreach (var itemG in CatGeneros)
//                //                {
//                //                    var edad = DateTime.Now.Year - ((DateTime)item.feNacimiento).Date.Year;
//                //                    if (edad == i && item.Personas.idGenero == itemG.idGenero)
//                //                    {
//                //                        IndicadoresVM IndicadorEdadG = new IndicadoresVM();
//                //                        IndicadorEdadG.nbCampo = i + " Años";
//                //                        IndicadorEdadG.nbCampo2 = itemG.nbGenero.Trim();
//                //                        IndicadorEdadG.numCampo = 1;
//                //                        ListaEdadGenero.Add(IndicadorEdadG);
//                //                    }
//                //                }
//                //            }
//                //        }
//                //    }

//                //    ListaEdadGenero.ToList().ForEach(t =>
//                //    {
//                //        var row = dt.NewRow();
//                //        row["nbCategoria"] = t.nbCampo;
//                //        row["nbCategoria2"] = t.nbCampo2;
//                //        row["numDatos"] = t.numCampo;
//                //        dt.Rows.Add(row);
//                //    });

//                //    #endregion
//                //}
//                //else if (listacaCampos[0] == 3 && listacaCampos[1] == 7)
//                //{
//                //    #region

//                //    TituloColumna1 = "Edad";
//                //    TituloColumna2 = "Licenciatura";
//                //    TituloColumna3 = "Cantidad";
//                //    TituloGrafic = "Gráfica de barras por Edad y Licenciatura";
//                //    Licenciaturas Licenciatura = new Licenciaturas();
//                //    var Licenciaturas = db.Licenciaturas.ToList();
//                //    List<IndicadoresVM> ListaEdadLic = new List<IndicadoresVM>();

//                //    if (Book.numEdadMinima != null && Book.numEdadMinima != null && listaIdsLicenciaturas.Count() > 0)
//                //    {
//                //        for (var i = Book.numEdadMinima; i <= Book.numEdadMaxima; i++)
//                //        {
//                //            foreach (var itemL in listaIdsLicenciaturas)
//                //            {
//                //                foreach (var item in Alumnos)
//                //                {
//                //                    var idLicenciatura = Convert.ToInt64(itemL);
//                //                    Licenciatura = Licenciaturas.FirstOrDefault(x => x.idLicenciatura == idLicenciatura);
//                //                    var FormacionesA = db.FormacionesAcademicas.Where(x => x.idAlumno == item.idAlumno && x.idLicenciatura == Licenciatura.idLicenciatura).ToList();
//                //                    var edad = DateTime.Now.Year - ((DateTime)item.feNacimiento).Date.Year;
//                //                    if (edad == i && FormacionesA.Count() > 0)
//                //                    {
//                //                        IndicadoresVM IndicadorEdadL = new IndicadoresVM();
//                //                        IndicadorEdadL.nbCampo = i + " Años";
//                //                        IndicadorEdadL.nbCampo2 = Licenciatura.nbLicenciatura.Trim();
//                //                        IndicadorEdadL.numCampo = 1;
//                //                        ListaEdadLic.Add(IndicadorEdadL);
//                //                    }
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (Book.numEdadMinima != null && Book.numEdadMinima != null && listaIdsLicenciaturas.Count() == 0)
//                //    {
//                //        for (var i = Book.numEdadMinima; i <= Book.numEdadMaxima; i++)
//                //        {
//                //            foreach (var itemL in Licenciaturas)
//                //            {
//                //                foreach (var item in Alumnos)
//                //                {
//                //                    //var idLicenciatura = Convert.ToInt64(itemL);
//                //                    //Licenciatura = Licenciaturas.FirstOrDefault(x => x.idLicenciatura == idLicenciatura);
//                //                    var FormacionesA = db.FormacionesAcademicas.Where(x => x.idAlumno == item.idAlumno && x.idLicenciatura == itemL.idLicenciatura).ToList();
//                //                    var edad = DateTime.Now.Year - ((DateTime)item.feNacimiento).Date.Year;
//                //                    if (edad == i && FormacionesA.Count() > 0)
//                //                    {
//                //                        IndicadoresVM IndicadorEdadL = new IndicadoresVM();
//                //                        IndicadorEdadL.nbCampo = i + " Años";
//                //                        IndicadorEdadL.nbCampo2 = itemL.nbLicenciatura.Trim();
//                //                        IndicadorEdadL.numCampo = 1;
//                //                        ListaEdadLic.Add(IndicadorEdadL);
//                //                    }
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (Book.numEdadMinima == null && Book.numEdadMinima == null && listaIdsLicenciaturas.Count() > 0)
//                //    {
//                //        for (var i = 15; i <= 80; i++)
//                //        {
//                //            foreach (var itemL in listaIdsLicenciaturas)
//                //            {
//                //                foreach (var item in Alumnos)
//                //                {
//                //                    var idLicenciatura = Convert.ToInt64(itemL);
//                //                    Licenciatura = Licenciaturas.FirstOrDefault(x => x.idLicenciatura == idLicenciatura);
//                //                    var FormacionesA = db.FormacionesAcademicas.Where(x => x.idAlumno == item.idAlumno && x.idLicenciatura == Licenciatura.idLicenciatura).ToList();
//                //                    var edad = DateTime.Now.Year - ((DateTime)item.feNacimiento).Date.Year;
//                //                    if (edad == i && FormacionesA.Count() > 0)
//                //                    {
//                //                        IndicadoresVM IndicadorEdadL = new IndicadoresVM();
//                //                        IndicadorEdadL.nbCampo = i + " Años";
//                //                        IndicadorEdadL.nbCampo2 = Licenciatura.nbLicenciatura.Trim();
//                //                        IndicadorEdadL.numCampo = 1;
//                //                        ListaEdadLic.Add(IndicadorEdadL);
//                //                    }
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (Book.numEdadMinima == null && Book.numEdadMinima == null && listaIdsLicenciaturas.Count() == 0)
//                //    {
//                //        for (var i = 15; i <= 80; i++)
//                //        {
//                //            foreach (var itemL in Licenciaturas)
//                //            {
//                //                foreach (var item in Alumnos)
//                //                {
//                //                    //var idLicenciatura = Convert.ToInt64(itemL);
//                //                    //Licenciatura = Licenciaturas.FirstOrDefault(x => x.idLicenciatura == idLicenciatura);
//                //                    var FormacionesA = db.FormacionesAcademicas.Where(x => x.idAlumno == item.idAlumno && x.idLicenciatura == itemL.idLicenciatura).ToList();
//                //                    var edad = DateTime.Now.Year - ((DateTime)item.feNacimiento).Date.Year;
//                //                    if (edad == i && FormacionesA.Count() > 0)
//                //                    {
//                //                        IndicadoresVM IndicadorEdadL = new IndicadoresVM();
//                //                        IndicadorEdadL.nbCampo = i + " Años";
//                //                        IndicadorEdadL.nbCampo2 = itemL.nbLicenciatura.Trim();
//                //                        IndicadorEdadL.numCampo = 1;
//                //                        ListaEdadLic.Add(IndicadorEdadL);
//                //                    }
//                //                }
//                //            }
//                //        }
//                //    }

//                //    ListaEdadLic.ToList().ForEach(t =>
//                //    {
//                //        var row = dt.NewRow();
//                //        row["nbCategoria"] = t.nbCampo;
//                //        row["nbCategoria2"] = t.nbCampo2;
//                //        row["numDatos"] = t.numCampo;
//                //        dt.Rows.Add(row);
//                //    });

//                //    #endregion
//                //}
//                //else if (listacaCampos[0] == 3 && listacaCampos[1] == 8)
//                //{
//                //    #region

//                //    TituloColumna1 = "Edad";
//                //    TituloColumna2 = "Religión";
//                //    TituloColumna3 = "Cantidad";
//                //    TituloGrafic = "Gráfica de barras por Edad y Religión";
//                //    CatReligion Religion = new CatReligion();
//                //    var Religiones = db.CatReligion.ToList();
//                //    List<IndicadoresVM> ListaEdadReligion = new List<IndicadoresVM>();

//                //    if (Book.numEdadMinima != null && Book.numEdadMinima != null && listaIdsReligiones.Count() > 0)
//                //    {
//                //        for (var i = Book.numEdadMinima; i <= Book.numEdadMaxima; i++)
//                //        {
//                //            foreach (var itemR in listaIdsReligiones)
//                //            {
//                //                foreach (var item in Alumnos)
//                //                {
//                //                    var idReligion = Convert.ToInt64(itemR);
//                //                    Religion = Religiones.FirstOrDefault(x => x.idReligion == idReligion);
//                //                    var edad = DateTime.Now.Year - ((DateTime)item.feNacimiento).Date.Year;
//                //                    if (edad == i && item.idReligion == Religion.idReligion)
//                //                    {
//                //                        IndicadoresVM IndicadorEdadR = new IndicadoresVM();
//                //                        IndicadorEdadR.nbCampo = i + " Años";
//                //                        IndicadorEdadR.nbCampo2 = Religion.nbReligion.Trim();
//                //                        IndicadorEdadR.numCampo = 1;
//                //                        ListaEdadReligion.Add(IndicadorEdadR);
//                //                    }
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (Book.numEdadMinima != null && Book.numEdadMinima != null && listaIdsReligiones.Count() == 0)
//                //    {
//                //        for (var i = Book.numEdadMinima; i <= Book.numEdadMaxima; i++)
//                //        {
//                //            foreach (var itemR in Religiones)
//                //            {
//                //                foreach (var item in Alumnos)
//                //                {
//                //                    //var idReligion = Convert.ToInt64(itemR);
//                //                    //Religion = Religiones.FirstOrDefault(x => x.idReligion == idReligion);
//                //                    var edad = DateTime.Now.Year - ((DateTime)item.feNacimiento).Date.Year;
//                //                    if (edad == i && item.idReligion == itemR.idReligion)
//                //                    {
//                //                        IndicadoresVM IndicadorEdadR = new IndicadoresVM();
//                //                        IndicadorEdadR.nbCampo = i + " Años";
//                //                        IndicadorEdadR.nbCampo2 = itemR.nbReligion.Trim();
//                //                        IndicadorEdadR.numCampo = 1;
//                //                        ListaEdadReligion.Add(IndicadorEdadR);
//                //                    }
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (Book.numEdadMinima == null && Book.numEdadMinima == null && listaIdsReligiones.Count() > 0)
//                //    {
//                //        for (var i = 15; i <= 80; i++)
//                //        {
//                //            foreach (var itemR in listaIdsReligiones)
//                //            {
//                //                foreach (var item in Alumnos)
//                //                {
//                //                    var idReligion = Convert.ToInt64(itemR);
//                //                    Religion = Religiones.FirstOrDefault(x => x.idReligion == idReligion);
//                //                    var edad = DateTime.Now.Year - ((DateTime)item.feNacimiento).Date.Year;
//                //                    if (edad == i && item.idReligion == Religion.idReligion)
//                //                    {
//                //                        IndicadoresVM IndicadorEdadR = new IndicadoresVM();
//                //                        IndicadorEdadR.nbCampo = i + " Años";
//                //                        IndicadorEdadR.nbCampo2 = Religion.nbReligion.Trim();
//                //                        IndicadorEdadR.numCampo = 1;
//                //                        ListaEdadReligion.Add(IndicadorEdadR);
//                //                    }
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (Book.numEdadMinima == null && Book.numEdadMinima == null && listaIdsReligiones.Count() == 0)
//                //    {
//                //        for (var i = 15; i <= 80; i++)
//                //        {
//                //            foreach (var itemR in Religiones)
//                //            {
//                //                foreach (var item in Alumnos)
//                //                {
//                //                    //var idReligion = Convert.ToInt64(itemR);
//                //                    //Religion = Religiones.FirstOrDefault(x => x.idReligion == idReligion);
//                //                    var edad = DateTime.Now.Year - ((DateTime)item.feNacimiento).Date.Year;
//                //                    if (edad == i && item.idReligion == itemR.idReligion)
//                //                    {
//                //                        IndicadoresVM IndicadorEdadR = new IndicadoresVM();
//                //                        IndicadorEdadR.nbCampo = i + " Años";
//                //                        IndicadorEdadR.nbCampo2 = itemR.nbReligion.Trim();
//                //                        IndicadorEdadR.numCampo = 1;
//                //                        ListaEdadReligion.Add(IndicadorEdadR);
//                //                    }
//                //                }
//                //            }
//                //        }
//                //    }

//                //    ListaEdadReligion.ToList().ForEach(t =>
//                //    {
//                //        var row = dt.NewRow();
//                //        row["nbCategoria"] = t.nbCampo;
//                //        row["nbCategoria2"] = t.nbCampo2;
//                //        row["numDatos"] = t.numCampo;
//                //        dt.Rows.Add(row);
//                //    });

//                //    #endregion
//                //}
//                //else if (listacaCampos[0] == 3 && listacaCampos[1] == 9)
//                //{
//                //    #region

//                //    TituloColumna1 = "Edad";
//                //    TituloColumna2 = "Estado";
//                //    TituloColumna3 = "Cantidad";
//                //    TituloGrafic = "Gráfica de barras por Edad y Estado";
//                //    CatEstados Estado = new CatEstados();
//                //    var Estados = db.CatEstados.ToList();
//                //    List<IndicadoresVM> ListaEdadEstado = new List<IndicadoresVM>();

//                //    if (Book.numEdadMinima != null && Book.numEdadMinima != null && listaIdsestados.Count() > 0)
//                //    {
//                //        for (var i = Book.numEdadMinima; i <= Book.numEdadMaxima; i++)
//                //        {
//                //            foreach (var itemE in listaIdsestados)
//                //            {
//                //                foreach (var item in Alumnos)
//                //                {
//                //                    var idEstado = Convert.ToInt64(itemE);
//                //                    Estado = Estados.FirstOrDefault(x => x.idEstado == idEstado);
//                //                    var edad = DateTime.Now.Year - ((DateTime)item.feNacimiento).Date.Year;
//                //                    if (edad == i && item.idReligion == Estado.idEstado)
//                //                    {
//                //                        IndicadoresVM IndicadorEdadE = new IndicadoresVM();
//                //                        IndicadorEdadE.nbCampo = i + " Años";
//                //                        IndicadorEdadE.nbCampo2 = Estado.nbEstado.Trim();
//                //                        IndicadorEdadE.numCampo = 1;
//                //                        ListaEdadEstado.Add(IndicadorEdadE);
//                //                    }
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (Book.numEdadMinima != null && Book.numEdadMinima != null && listaIdsestados.Count() == 0)
//                //    {
//                //        for (var i = Book.numEdadMinima; i <= Book.numEdadMaxima; i++)
//                //        {
//                //            foreach (var itemE in Estados)
//                //            {
//                //                foreach (var item in Alumnos)
//                //                {
//                //                    //var idEstado = Convert.ToInt64(itemE);
//                //                    //Estado = Estados.FirstOrDefault(x => x.idEstado == idEstado);
//                //                    var edad = DateTime.Now.Year - ((DateTime)item.feNacimiento).Date.Year;
//                //                    if (edad == i && item.idReligion == itemE.idEstado)
//                //                    {
//                //                        IndicadoresVM IndicadorEdadE = new IndicadoresVM();
//                //                        IndicadorEdadE.nbCampo = i + " Años";
//                //                        IndicadorEdadE.nbCampo2 = itemE.nbEstado.Trim();
//                //                        IndicadorEdadE.numCampo = 1;
//                //                        ListaEdadEstado.Add(IndicadorEdadE);
//                //                    }
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (Book.numEdadMinima == null && Book.numEdadMinima == null && listaIdsestados.Count() > 0)
//                //    {
//                //        for (var i = 15; i <= 80; i++)
//                //        {
//                //            foreach (var itemE in listaIdsestados)
//                //            {
//                //                foreach (var item in Alumnos)
//                //                {
//                //                    var idEstado = Convert.ToInt64(itemE);
//                //                    Estado = Estados.FirstOrDefault(x => x.idEstado == idEstado);
//                //                    var edad = DateTime.Now.Year - ((DateTime)item.feNacimiento).Date.Year;
//                //                    if (edad == i && item.idReligion == Estado.idEstado)
//                //                    {
//                //                        IndicadoresVM IndicadorEdadE = new IndicadoresVM();
//                //                        IndicadorEdadE.nbCampo = i + " Años";
//                //                        IndicadorEdadE.nbCampo2 = Estado.nbEstado.Trim();
//                //                        IndicadorEdadE.numCampo = 1;
//                //                        ListaEdadEstado.Add(IndicadorEdadE);
//                //                    }
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (Book.numEdadMinima == null && Book.numEdadMinima == null && listaIdsestados.Count() == 0)
//                //    {
//                //        for (var i = 15; i <= 80; i++)
//                //        {
//                //            foreach (var itemE in Estados)
//                //            {
//                //                foreach (var item in Alumnos)
//                //                {
//                //                    //var idEstado = Convert.ToInt64(itemE);
//                //                    //Estado = Estados.FirstOrDefault(x => x.idEstado == idEstado);
//                //                    var edad = DateTime.Now.Year - ((DateTime)item.feNacimiento).Date.Year;
//                //                    if (edad == i && item.idReligion == itemE.idEstado)
//                //                    {
//                //                        IndicadoresVM IndicadorEdadE = new IndicadoresVM();
//                //                        IndicadorEdadE.nbCampo = i + " Años";
//                //                        IndicadorEdadE.nbCampo2 = itemE.nbEstado.Trim();
//                //                        IndicadorEdadE.numCampo = 1;
//                //                        ListaEdadEstado.Add(IndicadorEdadE);
//                //                    }
//                //                }
//                //            }
//                //        }
//                //    }

//                //    ListaEdadEstado.ToList().ForEach(t =>
//                //    {
//                //        var row = dt.NewRow();
//                //        row["nbCategoria"] = t.nbCampo;
//                //        row["nbCategoria2"] = t.nbCampo2;
//                //        row["numDatos"] = t.numCampo;
//                //        dt.Rows.Add(row);
//                //    });

//                //    #endregion
//                //}
//                //else if (listacaCampos[0] == 3 && listacaCampos[1] == 10)
//                //{
//                //    #region

//                //    TituloColumna1 = "Edad";
//                //    TituloColumna2 = "Trabajo";
//                //    TituloColumna3 = "Cantidad";
//                //    TituloGrafic = "Gráfica de barras por Edad y Trabajo";
//                //    List<IndicadoresVM> ListaEdadTrabajo = new List<IndicadoresVM>();

//                //    if (Book.numEdadMinima != null && Book.numEdadMinima != null && Book.fgTrabajaActualmente != null)
//                //    {
//                //        for (var i = Book.numEdadMinima; i <= Book.numEdadMaxima; i++)
//                //        {
//                //            foreach (var item in Alumnos)
//                //            {
//                //                var edad = DateTime.Now.Year - ((DateTime)item.feNacimiento).Date.Year;
//                //                if (edad == i && item.fgTrabajaActualmente == Book.fgTrabajaActualmente)
//                //                {
//                //                    IndicadoresVM IndicadorEdadT = new IndicadoresVM();
//                //                    IndicadorEdadT.nbCampo = i + " Años";
//                //                    IndicadorEdadT.nbCampo2 = (Book.fgTrabajaActualmente == true) ? "SI" : "NO";
//                //                    IndicadorEdadT.numCampo = 1;
//                //                    ListaEdadTrabajo.Add(IndicadorEdadT);
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (Book.numEdadMinima != null && Book.numEdadMinima != null && Book.fgTrabajaActualmente == null)
//                //    {
//                //        for (var i = Book.numEdadMinima; i <= Book.numEdadMaxima; i++)
//                //        {
//                //            foreach (var item in Alumnos)
//                //            {
//                //                var edad = DateTime.Now.Year - ((DateTime)item.feNacimiento).Date.Year;
//                //                if (edad == i && item.fgTrabajaActualmente == true)
//                //                {
//                //                    IndicadoresVM IndicadorEdadT = new IndicadoresVM();
//                //                    IndicadorEdadT.nbCampo = i + " Años";
//                //                    IndicadorEdadT.nbCampo2 = "SI";
//                //                    IndicadorEdadT.numCampo = 1;
//                //                    ListaEdadTrabajo.Add(IndicadorEdadT);
//                //                }
//                //                else if (edad == i && item.fgTrabajaActualmente == false)
//                //                {
//                //                    IndicadoresVM IndicadorEdadT = new IndicadoresVM();
//                //                    IndicadorEdadT.nbCampo = i + " Años";
//                //                    IndicadorEdadT.nbCampo2 = "NO";
//                //                    IndicadorEdadT.numCampo = 1;
//                //                    ListaEdadTrabajo.Add(IndicadorEdadT);
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (Book.numEdadMinima == null && Book.numEdadMinima == null && Book.fgTrabajaActualmente != null)
//                //    {
//                //        for (var i = 15; i <= 80; i++)
//                //        {
//                //            foreach (var item in Alumnos)
//                //            {
//                //                var edad = DateTime.Now.Year - ((DateTime)item.feNacimiento).Date.Year;
//                //                if (edad == i && item.fgTrabajaActualmente == Book.fgTrabajaActualmente)
//                //                {
//                //                    IndicadoresVM IndicadorEdadT = new IndicadoresVM();
//                //                    IndicadorEdadT.nbCampo = i + " Años";
//                //                    IndicadorEdadT.nbCampo2 = (Book.fgTrabajaActualmente == true) ? "SI" : "NO";
//                //                    IndicadorEdadT.numCampo = 1;
//                //                    ListaEdadTrabajo.Add(IndicadorEdadT);
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (Book.numEdadMinima == null && Book.numEdadMinima == null && Book.fgTrabajaActualmente == null)
//                //    {
//                //        for (var i = 15; i <= 80; i++)
//                //        {
//                //            foreach (var item in Alumnos)
//                //            {
//                //                var edad = DateTime.Now.Year - ((DateTime)item.feNacimiento).Date.Year;
//                //                if (edad == i && item.fgTrabajaActualmente == true)
//                //                {
//                //                    IndicadoresVM IndicadorEdadT = new IndicadoresVM();
//                //                    IndicadorEdadT.nbCampo = i + " Años";
//                //                    IndicadorEdadT.nbCampo2 = "SI";
//                //                    IndicadorEdadT.numCampo = 1;
//                //                    ListaEdadTrabajo.Add(IndicadorEdadT);
//                //                }
//                //                else if (edad == i && item.fgTrabajaActualmente == false)
//                //                {
//                //                    IndicadoresVM IndicadorEdadT = new IndicadoresVM();
//                //                    IndicadorEdadT.nbCampo = i + " Años";
//                //                    IndicadorEdadT.nbCampo2 = "NO";
//                //                    IndicadorEdadT.numCampo = 1;
//                //                    ListaEdadTrabajo.Add(IndicadorEdadT);
//                //                }
//                //            }
//                //        }
//                //    }

//                //    ListaEdadTrabajo.ToList().ForEach(t =>
//                //    {
//                //        var row = dt.NewRow();
//                //        row["nbCategoria"] = t.nbCampo;
//                //        row["nbCategoria2"] = t.nbCampo2;
//                //        row["numDatos"] = t.numCampo;
//                //        dt.Rows.Add(row);
//                //    });

//                //    #endregion
//                //}
//                //else if (listacaCampos[0] == 3 && listacaCampos[1] == 11)
//                //{
//                //    #region

//                //    TituloColumna1 = "Edad";
//                //    TituloColumna2 = "Tipo de Sangre";
//                //    TituloColumna3 = "Cantidad";
//                //    TituloGrafic = "Gráfica de barras por Edad y Tipo de Sangre";

//                //    var CatTiposSangre = db.CatTiposSangre.ToList();
//                //    List<IndicadoresVM> ListaEdadTpSangre = new List<IndicadoresVM>();

//                //    if (Book.numEdadMinima != null && Book.numEdadMinima != null && Book.idTipoSangre != null)
//                //    {
//                //        for (var i = Book.numEdadMinima; i <= Book.numEdadMaxima; i++)
//                //        {
//                //            foreach (var item in Alumnos)
//                //            {
//                //                var TipoSangre = db.CatTiposSangre.Find(Book.idTipoSangre);
//                //                var edad = DateTime.Now.Year - ((DateTime)item.feNacimiento).Date.Year;
//                //                if (edad == i && item.idTipoSangre == TipoSangre.idTipoSangre)
//                //                {
//                //                    IndicadoresVM IndicadorEdadS = new IndicadoresVM();
//                //                    IndicadorEdadS.nbCampo = i + " Años";
//                //                    IndicadorEdadS.nbCampo2 = TipoSangre.nbTipoSangre.Trim();
//                //                    IndicadorEdadS.numCampo = 1;
//                //                    ListaEdadTpSangre.Add(IndicadorEdadS);
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (Book.numEdadMinima != null && Book.numEdadMinima != null && Book.idTipoSangre == null)
//                //    {
//                //        for (var i = Book.numEdadMinima; i <= Book.numEdadMaxima; i++)
//                //        {
//                //            foreach (var item in Alumnos)
//                //            {
//                //                foreach (var itemS in CatTiposSangre)
//                //                {
//                //                    var edad = DateTime.Now.Year - ((DateTime)item.feNacimiento).Date.Year;
//                //                    if (edad == i && item.Personas.idGenero == itemS.idTipoSangre)
//                //                    {
//                //                        IndicadoresVM IndicadorEdadS = new IndicadoresVM();
//                //                        IndicadorEdadS.nbCampo = i + " Años";
//                //                        IndicadorEdadS.nbCampo2 = itemS.nbTipoSangre.Trim();
//                //                        IndicadorEdadS.numCampo = 1;
//                //                        ListaEdadTpSangre.Add(IndicadorEdadS);
//                //                    }
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (Book.numEdadMinima == null && Book.numEdadMinima == null && Book.idTipoSangre != null)
//                //    {
//                //        for (var i = 15; i <= 80; i++)
//                //        {
//                //            foreach (var item in Alumnos)
//                //            {
//                //                var TipoSangre = db.CatTiposSangre.Find(Book.idTipoSangre);
//                //                var edad = DateTime.Now.Year - ((DateTime)item.feNacimiento).Date.Year;
//                //                if (edad == i && item.idTipoSangre == TipoSangre.idTipoSangre)
//                //                {
//                //                    IndicadoresVM IndicadorEdadS = new IndicadoresVM();
//                //                    IndicadorEdadS.nbCampo = i + " Años";
//                //                    IndicadorEdadS.nbCampo2 = TipoSangre.nbTipoSangre.Trim();
//                //                    IndicadorEdadS.numCampo = 1;
//                //                    ListaEdadTpSangre.Add(IndicadorEdadS);
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (Book.numEdadMinima == null && Book.numEdadMinima == null && Book.idTipoSangre == null)
//                //    {
//                //        for (var i = 15; i <= 80; i++)
//                //        {
//                //            foreach (var item in Alumnos)
//                //            {
//                //                foreach (var itemS in CatTiposSangre)
//                //                {
//                //                    var edad = DateTime.Now.Year - ((DateTime)item.feNacimiento).Date.Year;
//                //                    if (edad == i && item.Personas.idGenero == itemS.idTipoSangre)
//                //                    {
//                //                        IndicadoresVM IndicadorEdadS = new IndicadoresVM();
//                //                        IndicadorEdadS.nbCampo = i + " Años";
//                //                        IndicadorEdadS.nbCampo2 = itemS.nbTipoSangre.Trim();
//                //                        IndicadorEdadS.numCampo = 1;
//                //                        ListaEdadTpSangre.Add(IndicadorEdadS);
//                //                    }
//                //                }
//                //            }
//                //        }
//                //    }

//                //    ListaEdadTpSangre.ToList().ForEach(t =>
//                //    {
//                //        var row = dt.NewRow();
//                //        row["nbCategoria"] = t.nbCampo;
//                //        row["nbCategoria2"] = t.nbCampo2;
//                //        row["numDatos"] = t.numCampo;
//                //        dt.Rows.Add(row);
//                //    });

//                //    #endregion
//                //}
//                //else if (listacaCampos[0] == 3 && listacaCampos[1] == 12)
//                //{
//                //    #region

//                //    TituloColumna1 = "Edad";
//                //    TituloColumna2 = "Licencia";
//                //    TituloColumna3 = "Cantidad";
//                //    TituloGrafic = "Gráfica de barras por Edad y Licencia";
//                //    List<IndicadoresVM> ListaEdadLicencia = new List<IndicadoresVM>();

//                //    if (Book.numEdadMinima != null && Book.numEdadMinima != null && Book.fgLicencia != null)
//                //    {
//                //        for (var i = Book.numEdadMinima; i <= Book.numEdadMaxima; i++)
//                //        {
//                //            foreach (var item in Alumnos)
//                //            {
//                //                var edad = DateTime.Now.Year - ((DateTime)item.feNacimiento).Date.Year;
//                //                if (edad == i && item.fgLicencia == Book.fgLicencia)
//                //                {
//                //                    IndicadoresVM IndicadorEdadL = new IndicadoresVM();
//                //                    IndicadorEdadL.nbCampo = i + " Años";
//                //                    IndicadorEdadL.nbCampo2 = (Book.fgLicencia == true) ? "SI" : "NO";
//                //                    IndicadorEdadL.numCampo = 1;
//                //                    ListaEdadLicencia.Add(IndicadorEdadL);
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (Book.numEdadMinima != null && Book.numEdadMinima != null && Book.fgLicencia == null)
//                //    {
//                //        for (var i = Book.numEdadMinima; i <= Book.numEdadMaxima; i++)
//                //        {
//                //            foreach (var item in Alumnos)
//                //            {
//                //                var edad = DateTime.Now.Year - ((DateTime)item.feNacimiento).Date.Year;
//                //                if (edad == i && item.fgLicencia == true)
//                //                {
//                //                    IndicadoresVM IndicadorEdadL = new IndicadoresVM();
//                //                    IndicadorEdadL.nbCampo = i + " Años";
//                //                    IndicadorEdadL.nbCampo2 = "SI";
//                //                    IndicadorEdadL.numCampo = 1;
//                //                    ListaEdadLicencia.Add(IndicadorEdadL);
//                //                }
//                //                else if (edad == i && item.fgLicencia == false)
//                //                {
//                //                    IndicadoresVM IndicadorEdadL = new IndicadoresVM();
//                //                    IndicadorEdadL.nbCampo = i + " Años";
//                //                    IndicadorEdadL.nbCampo2 = "NO";
//                //                    IndicadorEdadL.numCampo = 1;
//                //                    ListaEdadLicencia.Add(IndicadorEdadL);
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (Book.numEdadMinima == null && Book.numEdadMinima == null && Book.fgLicencia != null)
//                //    {
//                //        for (var i = 15; i <= 80; i++)
//                //        {
//                //            foreach (var item in Alumnos)
//                //            {
//                //                var edad = DateTime.Now.Year - ((DateTime)item.feNacimiento).Date.Year;
//                //                if (edad == i && item.fgLicencia == Book.fgLicencia)
//                //                {
//                //                    IndicadoresVM IndicadorEdadL = new IndicadoresVM();
//                //                    IndicadorEdadL.nbCampo = i + " Años";
//                //                    IndicadorEdadL.nbCampo2 = (Book.fgLicencia == true) ? "SI" : "NO";
//                //                    IndicadorEdadL.numCampo = 1;
//                //                    ListaEdadLicencia.Add(IndicadorEdadL);
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (Book.numEdadMinima == null && Book.numEdadMinima == null && Book.fgLicencia == null)
//                //    {
//                //        for (var i = 15; i <= 80; i++)
//                //        {
//                //            foreach (var item in Alumnos)
//                //            {
//                //                var edad = DateTime.Now.Year - ((DateTime)item.feNacimiento).Date.Year;
//                //                if (edad == i && item.fgLicencia == true)
//                //                {
//                //                    IndicadoresVM IndicadorEdadL = new IndicadoresVM();
//                //                    IndicadorEdadL.nbCampo = i + " Años";
//                //                    IndicadorEdadL.nbCampo2 = "SI";
//                //                    IndicadorEdadL.numCampo = 1;
//                //                    ListaEdadLicencia.Add(IndicadorEdadL);
//                //                }
//                //                else if (edad == i && item.fgLicencia == false)
//                //                {
//                //                    IndicadoresVM IndicadorEdadL = new IndicadoresVM();
//                //                    IndicadorEdadL.nbCampo = i + " Años";
//                //                    IndicadorEdadL.nbCampo2 = "NO";
//                //                    IndicadorEdadL.numCampo = 1;
//                //                    ListaEdadLicencia.Add(IndicadorEdadL);
//                //                }
//                //            }
//                //        }
//                //    }

//                //    ListaEdadLicencia.ToList().ForEach(t =>
//                //    {
//                //        var row = dt.NewRow();
//                //        row["nbCategoria"] = t.nbCampo;
//                //        row["nbCategoria2"] = t.nbCampo2;
//                //        row["numDatos"] = t.numCampo;
//                //        dt.Rows.Add(row);
//                //    });

//                //    #endregion
//                //}
//                //else if (listacaCampos[0] == 3 && listacaCampos[1] == 13)
//                //{
//                //    #region

//                //    TituloColumna1 = "Edad";
//                //    TituloColumna2 = "Tipo de Egresado";
//                //    TituloColumna3 = "Cantidad";
//                //    TituloGrafic = "Gráfica de barras por Edad y Tipo de Egresado";
//                //    List<IndicadoresVM> ListaEdadtpEgresado = new List<IndicadoresVM>();

//                //    if (Book.numEdadMinima != null && Book.numEdadMinima != null && Book.tpEgresado != null)
//                //    {
//                //        for (var i = Book.numEdadMinima; i <= Book.numEdadMaxima; i++)
//                //        {
//                //            foreach (var item in Alumnos)
//                //            {
//                //                var edad = DateTime.Now.Year - ((DateTime)item.feNacimiento).Date.Year;
//                //                if (edad == i && item.tpEgresado == Book.tpEgresado)
//                //                {
//                //                    IndicadoresVM IndicadorEdadL = new IndicadoresVM();
//                //                    IndicadorEdadL.nbCampo = i + " Años";
//                //                    IndicadorEdadL.nbCampo2 = (Book.tpEgresado == "T") ? "Titulado" : "Pasante";
//                //                    IndicadorEdadL.numCampo = 1;
//                //                    ListaEdadtpEgresado.Add(IndicadorEdadL);
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (Book.numEdadMinima != null && Book.numEdadMinima != null && Book.tpEgresado == null)
//                //    {
//                //        for (var i = Book.numEdadMinima; i <= Book.numEdadMaxima; i++)
//                //        {
//                //            foreach (var item in Alumnos)
//                //            {
//                //                var edad = DateTime.Now.Year - ((DateTime)item.feNacimiento).Date.Year;
//                //                if (edad == i && item.tpEgresado == "T")
//                //                {
//                //                    IndicadoresVM IndicadorEdadL = new IndicadoresVM();
//                //                    IndicadorEdadL.nbCampo = i + " Años";
//                //                    IndicadorEdadL.nbCampo2 = "Titulado";
//                //                    IndicadorEdadL.numCampo = 1;
//                //                    ListaEdadtpEgresado.Add(IndicadorEdadL);
//                //                }
//                //                else if (edad == i && item.tpEgresado == "P")
//                //                {
//                //                    IndicadoresVM IndicadorEdadL = new IndicadoresVM();
//                //                    IndicadorEdadL.nbCampo = i + " Años";
//                //                    IndicadorEdadL.nbCampo2 = "Pasante";
//                //                    IndicadorEdadL.numCampo = 1;
//                //                    ListaEdadtpEgresado.Add(IndicadorEdadL);
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (Book.numEdadMinima == null && Book.numEdadMinima == null && Book.tpEgresado != null)
//                //    {
//                //        for (var i = 15; i <= 80; i++)
//                //        {
//                //            foreach (var item in Alumnos)
//                //            {
//                //                var edad = DateTime.Now.Year - ((DateTime)item.feNacimiento).Date.Year;
//                //                if (edad == i && item.tpEgresado == Book.tpEgresado)
//                //                {
//                //                    IndicadoresVM IndicadorEdadL = new IndicadoresVM();
//                //                    IndicadorEdadL.nbCampo = i + " Años";
//                //                    IndicadorEdadL.nbCampo2 = (Book.tpEgresado == "T") ? "Titulado" : "Pasante";
//                //                    IndicadorEdadL.numCampo = 1;
//                //                    ListaEdadtpEgresado.Add(IndicadorEdadL);
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (Book.numEdadMinima == null && Book.numEdadMinima == null && Book.tpEgresado == null)
//                //    {
//                //        for (var i = 15; i <= 80; i++)
//                //        {
//                //            foreach (var item in Alumnos)
//                //            {
//                //                var edad = DateTime.Now.Year - ((DateTime)item.feNacimiento).Date.Year;
//                //                if (edad == i && item.tpEgresado == "T")
//                //                {
//                //                    IndicadoresVM IndicadorEdadL = new IndicadoresVM();
//                //                    IndicadorEdadL.nbCampo = i + " Años";
//                //                    IndicadorEdadL.nbCampo2 = "Titulado";
//                //                    IndicadorEdadL.numCampo = 1;
//                //                    ListaEdadtpEgresado.Add(IndicadorEdadL);
//                //                }
//                //                else if (edad == i && item.tpEgresado == "P")
//                //                {
//                //                    IndicadoresVM IndicadorEdadL = new IndicadoresVM();
//                //                    IndicadorEdadL.nbCampo = i + " Años";
//                //                    IndicadorEdadL.nbCampo2 = "Pasante";
//                //                    IndicadorEdadL.numCampo = 1;
//                //                    ListaEdadtpEgresado.Add(IndicadorEdadL);
//                //                }
//                //            }
//                //        }
//                //    }

//                //    ListaEdadtpEgresado.ToList().ForEach(t =>
//                //    {
//                //        var row = dt.NewRow();
//                //        row["nbCategoria"] = t.nbCampo;
//                //        row["nbCategoria2"] = t.nbCampo2;
//                //        row["numDatos"] = t.numCampo;
//                //        dt.Rows.Add(row);
//                //    });

//                //    #endregion
//                //}
//                //else if (listacaCampos[0] == 3 && listacaCampos[1] == 14)
//                //{
//                //    #region

//                //    TituloColumna1 = "Edad";
//                //    TituloColumna2 = "Fallecimiento";
//                //    TituloColumna3 = "Cantidad";
//                //    TituloGrafic = "Gráfica de barras por Edad y Fallecimiento";
//                //    List<IndicadoresVM> ListaEdadTrabajo = new List<IndicadoresVM>();

//                //    if (Book.numEdadMinima != null && Book.numEdadMinima != null && Book.fgFallecido != null)
//                //    {
//                //        for (var i = Book.numEdadMinima; i <= Book.numEdadMaxima; i++)
//                //        {
//                //            foreach (var item in Alumnos)
//                //            {
//                //                var edad = DateTime.Now.Year - ((DateTime)item.feNacimiento).Date.Year;
//                //                if (edad == i && item.fgTrabajaActualmente == Book.fgTrabajaActualmente)
//                //                {
//                //                    IndicadoresVM IndicadorEdadT = new IndicadoresVM();
//                //                    IndicadorEdadT.nbCampo = i + " Años";
//                //                    IndicadorEdadT.nbCampo2 = (Book.fgFallecido == true) ? "SI" : "NO";
//                //                    IndicadorEdadT.numCampo = 1;
//                //                    ListaEdadTrabajo.Add(IndicadorEdadT);
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (Book.numEdadMinima != null && Book.numEdadMinima != null && Book.fgFallecido == null)
//                //    {
//                //        for (var i = Book.numEdadMinima; i <= Book.numEdadMaxima; i++)
//                //        {
//                //            foreach (var item in Alumnos)
//                //            {
//                //                var edad = DateTime.Now.Year - ((DateTime)item.feNacimiento).Date.Year;
//                //                if (edad == i && item.fgFallecido == true)
//                //                {
//                //                    IndicadoresVM IndicadorEdadT = new IndicadoresVM();
//                //                    IndicadorEdadT.nbCampo = i + " Años";
//                //                    IndicadorEdadT.nbCampo2 = "SI";
//                //                    IndicadorEdadT.numCampo = 1;
//                //                    ListaEdadTrabajo.Add(IndicadorEdadT);
//                //                }
//                //                else if (edad == i && item.fgFallecido == false)
//                //                {
//                //                    IndicadoresVM IndicadorEdadT = new IndicadoresVM();
//                //                    IndicadorEdadT.nbCampo = i + " Años";
//                //                    IndicadorEdadT.nbCampo2 = "NO";
//                //                    IndicadorEdadT.numCampo = 1;
//                //                    ListaEdadTrabajo.Add(IndicadorEdadT);
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (Book.numEdadMinima == null && Book.numEdadMinima == null && Book.fgFallecido != null)
//                //    {
//                //        for (var i = 15; i <= 80; i++)
//                //        {
//                //            foreach (var item in Alumnos)
//                //            {
//                //                var edad = DateTime.Now.Year - ((DateTime)item.feNacimiento).Date.Year;
//                //                if (edad == i && item.fgFallecido == Book.fgFallecido)
//                //                {
//                //                    IndicadoresVM IndicadorEdadT = new IndicadoresVM();
//                //                    IndicadorEdadT.nbCampo = i + " Años";
//                //                    IndicadorEdadT.nbCampo2 = (Book.fgFallecido == true) ? "SI" : "NO";
//                //                    IndicadorEdadT.numCampo = 1;
//                //                    ListaEdadTrabajo.Add(IndicadorEdadT);
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (Book.numEdadMinima == null && Book.numEdadMinima == null && Book.fgFallecido == null)
//                //    {
//                //        for (var i = 15; i <= 80; i++)
//                //        {
//                //            foreach (var item in Alumnos)
//                //            {
//                //                var edad = DateTime.Now.Year - ((DateTime)item.feNacimiento).Date.Year;
//                //                if (edad == i && item.fgFallecido == true)
//                //                {
//                //                    IndicadoresVM IndicadorEdadT = new IndicadoresVM();
//                //                    IndicadorEdadT.nbCampo = i + " Años";
//                //                    IndicadorEdadT.nbCampo2 = "SI";
//                //                    IndicadorEdadT.numCampo = 1;
//                //                    ListaEdadTrabajo.Add(IndicadorEdadT);
//                //                }
//                //                else if (edad == i && item.fgFallecido == false)
//                //                {
//                //                    IndicadoresVM IndicadorEdadT = new IndicadoresVM();
//                //                    IndicadorEdadT.nbCampo = i + " Años";
//                //                    IndicadorEdadT.nbCampo2 = "NO";
//                //                    IndicadorEdadT.numCampo = 1;
//                //                    ListaEdadTrabajo.Add(IndicadorEdadT);
//                //                }
//                //            }
//                //        }
//                //    }

//                //    ListaEdadTrabajo.ToList().ForEach(t =>
//                //    {
//                //        var row = dt.NewRow();
//                //        row["nbCategoria"] = t.nbCampo;
//                //        row["nbCategoria2"] = t.nbCampo2;
//                //        row["numDatos"] = t.numCampo;
//                //        dt.Rows.Add(row);
//                //    });

//                //    #endregion
//                //}
//                //else if (listacaCampos[0] == 6 && listacaCampos[1] == 2)
//                //{
//                //    #region

//                //    TituloColumna1 = "Género";
//                //    TituloColumna2 = "Estado Civil";
//                //    TituloColumna3 = "Cantidad";
//                //    TituloGrafic = "Gráfica de barras por Edad y Estado Civil";

//                //    var CatGeneros = db.CatGeneros.ToList();
//                //    var CatEstadosCiviles = db.CatEstadosCiviles.ToList();
//                //    List<IndicadoresVM> ListaEdoCivilSexo = new List<IndicadoresVM>();
//                //    if (Book.idEstadoCivil != null && Book.idGenero != null)
//                //    {
//                //        foreach (var item in Alumnos)
//                //        {
//                //            var EstadoCivil = db.CatEstadosCiviles.Find(Book.idEstadoCivil);
//                //            var Genero = db.CatGeneros.Find(Book.idGenero);
//                //            if (item.Personas.idGenero == Genero.idGenero && item.idEstadoCivil == EstadoCivil.idEstadoCivil)
//                //            {
//                //                IndicadoresVM IndicadorECS = new IndicadoresVM();
//                //                IndicadorECS.nbCampo = Genero.nbGenero;
//                //                IndicadorECS.nbCampo2 = EstadoCivil.nbEstadoCivil.Trim();
//                //                IndicadorECS.numCampo = 1;
//                //                ListaEdoCivilSexo.Add(IndicadorECS);
//                //            }
//                //        }
//                //    }
//                //    else if (Book.idEstadoCivil != null && Book.idGenero == null)
//                //    {
//                //        foreach (var itemG in CatGeneros)
//                //        {
//                //            foreach (var item in Alumnos)
//                //            {
//                //                var EstadoCivil = db.CatEstadosCiviles.Find(Book.idEstadoCivil);
//                //                var Genero = db.CatGeneros.Find(itemG.idGenero);
//                //                if (item.Personas.idGenero == Genero.idGenero && item.idEstadoCivil == EstadoCivil.idEstadoCivil)
//                //                {
//                //                    IndicadoresVM IndicadorECS = new IndicadoresVM();
//                //                    IndicadorECS.nbCampo = Genero.nbGenero;
//                //                    IndicadorECS.nbCampo2 = EstadoCivil.nbEstadoCivil.Trim();
//                //                    IndicadorECS.numCampo = 1;
//                //                    ListaEdoCivilSexo.Add(IndicadorECS);
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (Book.idEstadoCivil == null && Book.idGenero != null)
//                //    {
//                //        foreach (var itemEC in CatEstadosCiviles)
//                //        {
//                //            foreach (var item in Alumnos)
//                //            {
//                //                var EstadoCivil = db.CatEstadosCiviles.Find(itemEC.idEstadoCivil);
//                //                var Genero = db.CatGeneros.Find(Book.idGenero);
//                //                if (item.Personas.idGenero == Genero.idGenero && item.idEstadoCivil == EstadoCivil.idEstadoCivil)
//                //                {
//                //                    IndicadoresVM IndicadorECS = new IndicadoresVM();
//                //                    IndicadorECS.nbCampo = Genero.nbGenero;
//                //                    IndicadorECS.nbCampo2 = EstadoCivil.nbEstadoCivil.Trim();
//                //                    IndicadorECS.numCampo = 1;
//                //                    ListaEdoCivilSexo.Add(IndicadorECS);
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (Book.idEstadoCivil == null && Book.idGenero == null)
//                //    {
//                //        foreach (var itemEC in CatEstadosCiviles)
//                //        {
//                //            foreach (var itemG in CatGeneros)
//                //            {
//                //                foreach (var item in Alumnos)
//                //                {
//                //                    var EstadoCivil = db.CatEstadosCiviles.Find(itemEC.idEstadoCivil);
//                //                    var Genero = db.CatGeneros.Find(itemG.idGenero);
//                //                    if (item.Personas.idGenero == Genero.idGenero && item.idEstadoCivil == EstadoCivil.idEstadoCivil)
//                //                    {
//                //                        IndicadoresVM IndicadorECS = new IndicadoresVM();
//                //                        IndicadorECS.nbCampo = Genero.nbGenero;
//                //                        IndicadorECS.nbCampo2 = EstadoCivil.nbEstadoCivil.Trim();
//                //                        IndicadorECS.numCampo = 1;
//                //                        ListaEdoCivilSexo.Add(IndicadorECS);
//                //                    }
//                //                }
//                //            }
//                //        }
//                //    }

//                //    ListaEdoCivilSexo.ToList().ForEach(t =>
//                //    {
//                //        var row = dt.NewRow();
//                //        row["nbCategoria"] = t.nbCampo;
//                //        row["nbCategoria2"] = t.nbCampo2;
//                //        row["numDatos"] = t.numCampo;
//                //        dt.Rows.Add(row);
//                //    });

//                //    #endregion
//                //}
//                //else if (listacaCampos[0] == 6 && listacaCampos[1] == 3)
//                //{
//                //    #region

//                //    TituloColumna1 = "Género";
//                //    TituloColumna2 = "Edad";
//                //    TituloColumna3 = "Cantidad";
//                //    TituloGrafic = "Gráfica de barras por Género y Edad";

//                //    var CatGeneros = db.CatGeneros.ToList();
//                //    List<IndicadoresVM> ListaEdadGenero = new List<IndicadoresVM>();

//                //    if (Book.numEdadMinima != null && Book.numEdadMinima != null && Book.idGenero != null)
//                //    {
//                //        for (var i = Book.numEdadMinima; i <= Book.numEdadMaxima; i++)
//                //        {
//                //            foreach (var item in Alumnos)
//                //            {
//                //                var Genero = db.CatGeneros.Find(Book.idGenero);
//                //                var edad = DateTime.Now.Year - ((DateTime)item.feNacimiento).Date.Year;
//                //                if (edad == i && item.Personas.idGenero == Genero.idGenero)
//                //                {
//                //                    IndicadoresVM IndicadorEdadG = new IndicadoresVM();
//                //                    IndicadorEdadG.nbCampo = Genero.nbGenero.Trim();
//                //                    IndicadorEdadG.nbCampo2 = i + " Años";
//                //                    IndicadorEdadG.numCampo = 1;
//                //                    ListaEdadGenero.Add(IndicadorEdadG);
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (Book.numEdadMinima != null && Book.numEdadMinima != null && Book.idGenero == null)
//                //    {
//                //        for (var i = Book.numEdadMinima; i <= Book.numEdadMaxima; i++)
//                //        {
//                //            foreach (var item in Alumnos)
//                //            {
//                //                foreach (var itemG in CatGeneros)
//                //                {
//                //                    var edad = DateTime.Now.Year - ((DateTime)item.feNacimiento).Date.Year;
//                //                    if (edad == i && item.Personas.idGenero == itemG.idGenero)
//                //                    {
//                //                        IndicadoresVM IndicadorEdadG = new IndicadoresVM();
//                //                        IndicadorEdadG.nbCampo = itemG.nbGenero.Trim();
//                //                        IndicadorEdadG.nbCampo2 = i + " Años";
//                //                        IndicadorEdadG.numCampo = 1;
//                //                        ListaEdadGenero.Add(IndicadorEdadG);
//                //                    }
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (Book.numEdadMinima == null && Book.numEdadMinima == null && Book.idGenero != null)
//                //    {
//                //        for (var i = 15; i <= 80; i++)
//                //        {
//                //            foreach (var item in Alumnos)
//                //            {
//                //                var Genero = db.CatGeneros.Find(Book.idGenero);
//                //                var edad = DateTime.Now.Year - ((DateTime)item.feNacimiento).Date.Year;
//                //                if (edad == i && item.Personas.idGenero == Genero.idGenero)
//                //                {
//                //                    IndicadoresVM IndicadorEdadG = new IndicadoresVM();
//                //                    IndicadorEdadG.nbCampo = Genero.nbGenero.Trim();
//                //                    IndicadorEdadG.nbCampo2 = i + " Años";
//                //                    IndicadorEdadG.numCampo = 1;
//                //                    ListaEdadGenero.Add(IndicadorEdadG);
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (Book.numEdadMinima == null && Book.numEdadMinima == null && Book.idGenero == null)
//                //    {
//                //        for (var i = 15; i <= 80; i++)
//                //        {
//                //            foreach (var item in Alumnos)
//                //            {
//                //                foreach (var itemG in CatGeneros)
//                //                {
//                //                    var edad = DateTime.Now.Year - ((DateTime)item.feNacimiento).Date.Year;
//                //                    if (edad == i && item.Personas.idGenero == itemG.idGenero)
//                //                    {
//                //                        IndicadoresVM IndicadorEdadG = new IndicadoresVM();
//                //                        IndicadorEdadG.nbCampo = itemG.nbGenero.Trim();
//                //                        IndicadorEdadG.nbCampo2 = i + " Años";
//                //                        IndicadorEdadG.numCampo = 1;
//                //                        ListaEdadGenero.Add(IndicadorEdadG);
//                //                    }
//                //                }
//                //            }
//                //        }
//                //    }

//                //    ListaEdadGenero.ToList().ForEach(t =>
//                //    {
//                //        var row = dt.NewRow();
//                //        row["nbCategoria"] = t.nbCampo;
//                //        row["nbCategoria2"] = t.nbCampo2;
//                //        row["numDatos"] = t.numCampo;
//                //        dt.Rows.Add(row);
//                //    });

//                //    #endregion
//                //}
//                //else if (listacaCampos[0] == 6 && listacaCampos[1] == 7)
//                //{
//                //    #region

//                //    TituloColumna1 = "Género";
//                //    TituloColumna2 = "Licenciatura";
//                //    TituloColumna3 = "Cantidad";
//                //    TituloGrafic = "Gráfica de barras por Género y Licenciatura";

//                //    var CatGeneros = db.CatGeneros.ToList();
//                //    Licenciaturas Licenciatura = new Licenciaturas();
//                //    var Licenciaturas = db.Licenciaturas.ToList();
//                //    List<IndicadoresVM> IndicadoresGLic = new List<IndicadoresVM>();

//                //    if (Book.idGenero != null && listaIdsLicenciaturas.Count > 0)
//                //    {
//                //        foreach (var itemL in listaIdsLicenciaturas)
//                //        {
//                //            foreach (var item in Alumnos)
//                //            {
//                //                var idLicenciatura = Convert.ToInt64(itemL);
//                //                Licenciatura = Licenciaturas.FirstOrDefault(x => x.idLicenciatura == idLicenciatura);
//                //                var FormacionesA = db.FormacionesAcademicas.Where(x => x.idAlumno == item.idAlumno && x.idLicenciatura == Licenciatura.idLicenciatura).ToList();
//                //                var Genero = db.CatGeneros.Find(Book.idGenero);
//                //                if (item.Personas.idGenero == Genero.idGenero && FormacionesA.Count() > 0)
//                //                {
//                //                    IndicadoresVM IndicadorGL = new IndicadoresVM();
//                //                    IndicadorGL.nbCampo = Genero.nbGenero.Trim();
//                //                    IndicadorGL.nbCampo2 = Licenciatura.nbLicenciatura;
//                //                    IndicadorGL.numCampo = 1;
//                //                    IndicadoresGLic.Add(IndicadorGL);
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (Book.idGenero == null && listaIdsLicenciaturas.Count > 0)
//                //    {
//                //        foreach (var itemL in listaIdsLicenciaturas)
//                //        {
//                //            var idLicenciatura = Convert.ToInt64(itemL);
//                //            Licenciatura = Licenciaturas.FirstOrDefault(x => x.idLicenciatura == idLicenciatura);
//                //            foreach (var itemG in CatGeneros)
//                //            {
//                //                foreach (var item in Alumnos)
//                //                {
//                //                    var FormacionesA = db.FormacionesAcademicas.Where(x => x.idAlumno == item.idAlumno && x.idLicenciatura == Licenciatura.idLicenciatura).ToList();
//                //                    var Genero = db.CatGeneros.Find(itemG.idGenero);
//                //                    if (item.Personas.idGenero == Genero.idGenero && FormacionesA.Count() > 0)
//                //                    {
//                //                        IndicadoresVM IndicadorGL = new IndicadoresVM();
//                //                        IndicadorGL.nbCampo = Genero.nbGenero.Trim();
//                //                        IndicadorGL.nbCampo2 = Licenciatura.nbLicenciatura;
//                //                        IndicadorGL.numCampo = 1;
//                //                        IndicadoresGLic.Add(IndicadorGL);
//                //                    }
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (Book.idGenero == null && listaIdsLicenciaturas.Count == 0)
//                //    {
//                //        foreach (var itemL in Licenciaturas)
//                //        {
//                //            //var idLicenciatura = Convert.ToInt64(itemL);
//                //            Licenciatura = Licenciaturas.FirstOrDefault(x => x.idLicenciatura == itemL.idLicenciatura);
//                //            foreach (var itemG in CatGeneros)
//                //            {
//                //                foreach (var item in Alumnos)
//                //                {
//                //                    var FormacionesA = db.FormacionesAcademicas.Where(x => x.idAlumno == item.idAlumno && x.idLicenciatura == Licenciatura.idLicenciatura).ToList();
//                //                    var Genero = db.CatGeneros.Find(itemG.idGenero);
//                //                    if (item.Personas.idGenero == Genero.idGenero && FormacionesA.Count() > 0)
//                //                    {
//                //                        IndicadoresVM IndicadorGL = new IndicadoresVM();
//                //                        IndicadorGL.nbCampo = Genero.nbGenero.Trim();
//                //                        IndicadorGL.nbCampo2 = Licenciatura.nbLicenciatura;
//                //                        IndicadorGL.numCampo = 1;
//                //                        IndicadoresGLic.Add(IndicadorGL);
//                //                    }
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (Book.idGenero != null && listaIdsLicenciaturas.Count == 0)
//                //    {
//                //        foreach (var itemL in Licenciaturas)
//                //        {
//                //            foreach (var item in Alumnos)
//                //            {
//                //                //var idLicenciatura = Convert.ToInt64(itemL);
//                //                Licenciatura = Licenciaturas.FirstOrDefault(x => x.idLicenciatura == itemL.idLicenciatura);
//                //                var FormacionesA = db.FormacionesAcademicas.Where(x => x.idAlumno == item.idAlumno && x.idLicenciatura == Licenciatura.idLicenciatura).ToList();
//                //                var Genero = db.CatGeneros.Find(Book.idGenero);
//                //                if (item.Personas.idGenero == Genero.idGenero && FormacionesA.Count() > 0)
//                //                {
//                //                    IndicadoresVM IndicadorGL = new IndicadoresVM();
//                //                    IndicadorGL.nbCampo = Genero.nbGenero.Trim();
//                //                    IndicadorGL.nbCampo2 = Licenciatura.nbLicenciatura;
//                //                    IndicadorGL.numCampo = 1;
//                //                    IndicadoresGLic.Add(IndicadorGL);
//                //                }
//                //            }
//                //        }
//                //    }

//                //    IndicadoresGLic.ToList().ForEach(l =>
//                //    {
//                //        var row = dt.NewRow();
//                //        row["nbCategoria"] = l.nbCampo;
//                //        row["nbCategoria2"] = l.nbCampo2;
//                //        row["numDatos"] = l.numCampo;
//                //        dt.Rows.Add(row);
//                //    });

//                //    #endregion
//                //}
//                //else if (listacaCampos[0] == 6 && listacaCampos[1] == 8)
//                //{
//                //    #region

//                //    TituloColumna1 = "Género";
//                //    TituloColumna2 = "Religión";
//                //    TituloColumna3 = "Cantidad";
//                //    TituloGrafic = "Gráfica de barras por Género y Religión";

//                //    var CatGeneros = db.CatGeneros.ToList();
//                //    CatReligion Religion = new CatReligion();
//                //    var Religiones = db.CatReligion.ToList();
//                //    List<IndicadoresVM> IndicadoresGR = new List<IndicadoresVM>();
//                //    List<Alumnos> AlumnosLic = new List<Alumnos>();

//                //    if (Book.idGenero != null && listaIdsReligiones.Count > 0)
//                //    {
//                //        foreach (var item in listaIdsReligiones)
//                //        {
//                //            foreach (var itemA in Alumnos)
//                //            {
//                //                var idReligion = Convert.ToInt64(item);
//                //                Religion = Religiones.FirstOrDefault(x => x.idReligion == idReligion);
//                //                var Genero = db.CatGeneros.Find(Book.idGenero);
//                //                if (itemA.Personas.idGenero == Book.idGenero && itemA.idReligion == Religion.idReligion)
//                //                {
//                //                    IndicadoresVM IndicadorGR = new IndicadoresVM();
//                //                    IndicadorGR.nbCampo = Genero.nbGenero.Trim();
//                //                    IndicadorGR.nbCampo2 = Religion.nbReligion;
//                //                    IndicadorGR.numCampo = 1;
//                //                    IndicadoresGR.Add(IndicadorGR);
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (Book.idGenero == null && listaIdsReligiones.Count > 0)
//                //    {
//                //        foreach (var item in listaIdsReligiones)
//                //        {
//                //            foreach (var itemG in CatGeneros)
//                //            {
//                //                foreach (var itemA in Alumnos)
//                //                {
//                //                    var idReligion = Convert.ToInt64(item);
//                //                    Religion = Religiones.FirstOrDefault(x => x.idReligion == idReligion);
//                //                    var Genero = db.CatGeneros.Find(itemG.idGenero);
//                //                    if (itemA.Personas.idGenero == Genero.idGenero && itemA.idReligion == Religion.idReligion)
//                //                    {
//                //                        IndicadoresVM IndicadorGR = new IndicadoresVM();
//                //                        IndicadorGR.nbCampo = Genero.nbGenero.Trim();
//                //                        IndicadorGR.nbCampo2 = Religion.nbReligion;
//                //                        IndicadorGR.numCampo = 1;
//                //                        IndicadoresGR.Add(IndicadorGR);
//                //                    }
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (Book.idGenero == null && listaIdsReligiones.Count == 0)
//                //    {
//                //        foreach (var item in Religiones)
//                //        {
//                //            foreach (var itemG in CatGeneros)
//                //            {
//                //                foreach (var itemA in Alumnos)
//                //                {
//                //                    //var idReligion = Convert.ToInt64(item);
//                //                    Religion = Religiones.FirstOrDefault(x => x.idReligion == item.idReligion);
//                //                    var Genero = db.CatGeneros.Find(itemG.idGenero);
//                //                    if (itemA.Personas.idGenero == Genero.idGenero && itemA.idReligion == Religion.idReligion)
//                //                    {
//                //                        IndicadoresVM IndicadorGR = new IndicadoresVM();
//                //                        IndicadorGR.nbCampo = Genero.nbGenero.Trim();
//                //                        IndicadorGR.nbCampo2 = Religion.nbReligion;
//                //                        IndicadorGR.numCampo = 1;
//                //                        IndicadoresGR.Add(IndicadorGR);
//                //                    }
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (Book.idGenero != null && listaIdsLicenciaturas.Count == 0)
//                //    {
//                //        foreach (var item in Religiones)
//                //        {
//                //            foreach (var itemA in Alumnos)
//                //            {
//                //                //var idReligion = Convert.ToInt64(item);
//                //                Religion = Religiones.FirstOrDefault(x => x.idReligion == item.idReligion);
//                //                var Genero = db.CatGeneros.Find(Book.idGenero);
//                //                if (itemA.Personas.idGenero == Book.idGenero && itemA.idReligion == Religion.idReligion)
//                //                {
//                //                    IndicadoresVM IndicadorGR = new IndicadoresVM();
//                //                    IndicadorGR.nbCampo = Genero.nbGenero.Trim();
//                //                    IndicadorGR.nbCampo2 = Religion.nbReligion;
//                //                    IndicadorGR.numCampo = 1;
//                //                    IndicadoresGR.Add(IndicadorGR);
//                //                }
//                //            }
//                //        }
//                //    }

//                //    IndicadoresGR.ToList().ForEach(l =>
//                //    {
//                //        var row = dt.NewRow();
//                //        row["nbCategoria"] = l.nbCampo;
//                //        row["nbCategoria2"] = l.nbCampo2;
//                //        row["numDatos"] = l.numCampo;
//                //        dt.Rows.Add(row);
//                //    });

//                //    #endregion
//                //}
//                //else if (listacaCampos[0] == 6 && listacaCampos[1] == 9)
//                //{
//                //    #region

//                //    TituloColumna1 = "Género";
//                //    TituloColumna2 = "Estados";
//                //    TituloColumna3 = "Cantidad";
//                //    TituloGrafic = "Gráfica de barras por Género y Estados";

//                //    var CatGeneros = db.CatGeneros.ToList();
//                //    CatEstados Estado = new CatEstados();
//                //    var Estados = db.CatEstados.ToList();
//                //    List<IndicadoresVM> IndicadoresGEstados = new List<IndicadoresVM>();

//                //    if (Book.idGenero != null && listaIdsestados.Count > 0)
//                //    {
//                //        foreach (var item in listaIdsestados)
//                //        {
//                //            foreach (var itemA in Alumnos)
//                //            {
//                //                var idEstado = Convert.ToInt64(item);
//                //                Estado = Estados.FirstOrDefault(x => x.idEstado == idEstado);
//                //                var Genero = db.CatGeneros.Find(Book.idGenero);
//                //                if (itemA.Personas.idGenero == Genero.idGenero && itemA.Direcciones.nbEstado.Trim().ToUpper() == Estado.nbEstado.Trim().ToUpper())
//                //                {
//                //                    IndicadoresVM IndicadorGE = new IndicadoresVM();
//                //                    IndicadorGE.nbCampo = Genero.nbGenero.Trim();
//                //                    IndicadorGE.nbCampo2 = Estado.nbEstado;
//                //                    IndicadorGE.numCampo = 1;
//                //                    IndicadoresGEstados.Add(IndicadorGE);
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (Book.idGenero == null && listaIdsestados.Count > 0)
//                //    {
//                //        foreach (var item in listaIdsestados)
//                //        {
//                //            foreach (var itemG in CatGeneros)
//                //            {
//                //                foreach (var itemA in Alumnos)
//                //                {
//                //                    var idEstado = Convert.ToInt64(item);
//                //                    Estado = Estados.FirstOrDefault(x => x.idEstado == idEstado);
//                //                    var Genero = db.CatGeneros.Find(itemG.idGenero);
//                //                    if (itemA.Personas.idGenero == Genero.idGenero && itemA.Direcciones.nbEstado.Trim().ToUpper() == Estado.nbEstado.Trim().ToUpper())
//                //                    {
//                //                        IndicadoresVM IndicadorGE = new IndicadoresVM();
//                //                        IndicadorGE.nbCampo = Genero.nbGenero.Trim();
//                //                        IndicadorGE.nbCampo2 = Estado.nbEstado;
//                //                        IndicadorGE.numCampo = 1;
//                //                        IndicadoresGEstados.Add(IndicadorGE);
//                //                    }
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (Book.idGenero == null && listaIdsestados.Count == 0)
//                //    {
//                //        foreach (var item in Estados)
//                //        {
//                //            foreach (var itemG in CatGeneros)
//                //            {
//                //                foreach (var itemA in Alumnos)
//                //                {
//                //                    //var idEstado = Convert.ToInt64(item);
//                //                    Estado = Estados.FirstOrDefault(x => x.idEstado == item.idEstado);
//                //                    var Genero = db.CatGeneros.Find(itemG.idGenero);
//                //                    if (itemA.Personas.idGenero == Genero.idGenero && itemA.Direcciones.nbEstado.Trim().ToUpper() == Estado.nbEstado.Trim().ToUpper())
//                //                    {
//                //                        IndicadoresVM IndicadorGE = new IndicadoresVM();
//                //                        IndicadorGE.nbCampo = Genero.nbGenero.Trim();
//                //                        IndicadorGE.nbCampo2 = Estado.nbEstado;
//                //                        IndicadorGE.numCampo = 1;
//                //                        IndicadoresGEstados.Add(IndicadorGE);
//                //                    }
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (Book.idGenero != null && listaIdsestados.Count == 0)
//                //    {
//                //        foreach (var item in Estados)
//                //        {
//                //            foreach (var itemA in Alumnos)
//                //            {
//                //                //var idEstado = Convert.ToInt64(item);
//                //                Estado = Estados.FirstOrDefault(x => x.idEstado == item.idEstado);
//                //                var Genero = db.CatGeneros.Find(Book.idGenero);
//                //                if (itemA.Personas.idGenero == Genero.idGenero && itemA.Direcciones.nbEstado.Trim().ToUpper() == Estado.nbEstado.Trim().ToUpper())
//                //                {
//                //                    IndicadoresVM IndicadorGE = new IndicadoresVM();
//                //                    IndicadorGE.nbCampo = Genero.nbGenero.Trim();
//                //                    IndicadorGE.nbCampo2 = Estado.nbEstado;
//                //                    IndicadorGE.numCampo = 1;
//                //                    IndicadoresGEstados.Add(IndicadorGE);
//                //                }
//                //            }
//                //        }
//                //    }

//                //    IndicadoresGEstados.ToList().ForEach(l =>
//                //    {
//                //        var row = dt.NewRow();
//                //        row["nbCategoria"] = l.nbCampo;
//                //        row["nbCategoria2"] = l.nbCampo2;
//                //        row["numDatos"] = l.numCampo;
//                //        dt.Rows.Add(row);
//                //    });

//                //    #endregion
//                //}
//                //else if (listacaCampos[0] == 6 && listacaCampos[1] == 10)
//                //{
//                //    #region

//                //    TituloColumna1 = "Género";
//                //    TituloColumna2 = "Trabajo";
//                //    TituloColumna3 = "Cantidad";
//                //    TituloGrafic = "Gráfica de barras por Género y Trabajo";

//                //    var CatGeneros = db.CatGeneros.ToList();
//                //    List<IndicadoresVM> IndicadoresGTrabajo = new List<IndicadoresVM>();

//                //    if (Book.idGenero != null && Book.fgTrabajaActualmente != null)
//                //    {
//                //        foreach (var itemA in Alumnos)
//                //        {
//                //            var Genero = db.CatGeneros.Find(Book.idGenero);
//                //            if (itemA.Personas.idGenero == Genero.idGenero && itemA.fgTrabajaActualmente == Book.fgTrabajaActualmente)
//                //            {
//                //                IndicadoresVM IndicadorGT = new IndicadoresVM();
//                //                IndicadorGT.nbCampo = Genero.nbGenero.Trim();
//                //                IndicadorGT.nbCampo2 = (Book.fgTrabajaActualmente == true) ? "SI" : "NO";
//                //                IndicadorGT.numCampo = 1;
//                //                IndicadoresGTrabajo.Add(IndicadorGT);
//                //            }
//                //        }
//                //    }
//                //    else if (Book.idGenero == null && Book.fgTrabajaActualmente != null)
//                //    {
//                //        foreach (var itemG in CatGeneros)
//                //        {
//                //            foreach (var itemA in Alumnos)
//                //            {
//                //                var Genero = db.CatGeneros.Find(itemG.idGenero);
//                //                if (itemA.Personas.idGenero == Genero.idGenero && itemA.fgTrabajaActualmente == Book.fgTrabajaActualmente)
//                //                {
//                //                    IndicadoresVM IndicadorGT = new IndicadoresVM();
//                //                    IndicadorGT.nbCampo = Genero.nbGenero.Trim();
//                //                    IndicadorGT.nbCampo2 = (Book.fgTrabajaActualmente == true) ? "SI" : "NO";
//                //                    IndicadorGT.numCampo = 1;
//                //                    IndicadoresGTrabajo.Add(IndicadorGT);
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (Book.idGenero == null && Book.fgTrabajaActualmente == null)
//                //    {
//                //        foreach (var itemG in CatGeneros)
//                //        {
//                //            foreach (var itemA in Alumnos)
//                //            {
//                //                var Genero = db.CatGeneros.Find(itemG.idGenero);
//                //                if (itemA.Personas.idGenero == Genero.idGenero && itemA.fgTrabajaActualmente == true)
//                //                {
//                //                    IndicadoresVM IndicadorGT = new IndicadoresVM();
//                //                    IndicadorGT.nbCampo = Genero.nbGenero.Trim();
//                //                    IndicadorGT.nbCampo2 = "SI";
//                //                    IndicadorGT.numCampo = 1;
//                //                    IndicadoresGTrabajo.Add(IndicadorGT);
//                //                }
//                //                else if (itemA.Personas.idGenero == Genero.idGenero && itemA.fgTrabajaActualmente == false)
//                //                {
//                //                    IndicadoresVM IndicadorGTN = new IndicadoresVM();
//                //                    IndicadorGTN.nbCampo = Genero.nbGenero.Trim();
//                //                    IndicadorGTN.nbCampo2 = "NO";
//                //                    IndicadorGTN.numCampo = 1;
//                //                    IndicadoresGTrabajo.Add(IndicadorGTN);
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (Book.idGenero != null && Book.fgTrabajaActualmente == null)
//                //    {
//                //        foreach (var itemA in Alumnos)
//                //        {
//                //            var Genero = db.CatGeneros.Find(Book.idGenero);
//                //            if (itemA.Personas.idGenero == Genero.idGenero && itemA.fgTrabajaActualmente == true)
//                //            {
//                //                IndicadoresVM IndicadorGT = new IndicadoresVM();
//                //                IndicadorGT.nbCampo = Genero.nbGenero.Trim();
//                //                IndicadorGT.nbCampo2 = "SI";
//                //                IndicadorGT.numCampo = 1;
//                //                IndicadoresGTrabajo.Add(IndicadorGT);
//                //            }
//                //            else if (itemA.Personas.idGenero == Genero.idGenero && itemA.fgTrabajaActualmente == false)
//                //            {
//                //                IndicadoresVM IndicadorGTN = new IndicadoresVM();
//                //                IndicadorGTN.nbCampo = Genero.nbGenero.Trim();
//                //                IndicadorGTN.nbCampo2 = "NO";
//                //                IndicadorGTN.numCampo = 1;
//                //                IndicadoresGTrabajo.Add(IndicadorGTN);
//                //            }
//                //        }
//                //    }

//                //    IndicadoresGTrabajo.ToList().ForEach(l =>
//                //    {
//                //        var row = dt.NewRow();
//                //        row["nbCategoria"] = l.nbCampo;
//                //        row["nbCategoria2"] = l.nbCampo2;
//                //        row["numDatos"] = l.numCampo;
//                //        dt.Rows.Add(row);
//                //    });

//                //    #endregion
//                //}
//                //else if (listacaCampos[0] == 6 && listacaCampos[1] == 11)
//                //{
//                //    #region
//                //    TituloColumna1 = "Género";
//                //    TituloColumna2 = "Tipo de Sangre";
//                //    TituloColumna3 = "Cantidad";
//                //    TituloGrafic = "Gráfica de barras por Edad y Tipo de Sangre";

//                //    var CatGeneros = db.CatGeneros.ToList();
//                //    var CatTiposSangre = db.CatTiposSangre.ToList();
//                //    List<IndicadoresVM> ListaGenTipoSangre = new List<IndicadoresVM>();
//                //    if (Book.idTipoSangre != null && Book.idGenero != null)
//                //    {
//                //        foreach (var itemA in Alumnos)
//                //        {
//                //            var Genero = db.CatGeneros.Find(Book.idGenero);
//                //            var TipoSangre = db.CatTiposSangre.Find(Book.idTipoSangre);
//                //            if (itemA.Personas.idGenero == Genero.idGenero && itemA.idTipoSangre == TipoSangre.idTipoSangre)
//                //            {
//                //                IndicadoresVM IndicadorGS = new IndicadoresVM();
//                //                IndicadorGS.nbCampo = Genero.nbGenero;
//                //                IndicadorGS.nbCampo2 = TipoSangre.nbTipoSangre.Trim();
//                //                IndicadorGS.numCampo = 1;
//                //                ListaGenTipoSangre.Add(IndicadorGS);
//                //            }
//                //        }
//                //    }
//                //    else if (Book.idTipoSangre != null && Book.idGenero == null)
//                //    {
//                //        foreach (var itemG in CatGeneros)
//                //        {
//                //            foreach (var itemA in Alumnos)
//                //            {
//                //                var Genero = db.CatGeneros.Find(itemG.idGenero);
//                //                var TipoSangre = db.CatTiposSangre.Find(Book.idTipoSangre);
//                //                if (itemA.Personas.idGenero == Genero.idGenero && itemA.idTipoSangre == TipoSangre.idTipoSangre)
//                //                {
//                //                    IndicadoresVM IndicadorGS = new IndicadoresVM();
//                //                    IndicadorGS.nbCampo = Genero.nbGenero;
//                //                    IndicadorGS.nbCampo2 = TipoSangre.nbTipoSangre.Trim();
//                //                    IndicadorGS.numCampo = 1;
//                //                    ListaGenTipoSangre.Add(IndicadorGS);
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (Book.idTipoSangre == null && Book.idGenero != null)
//                //    {
//                //        foreach (var itemS in CatTiposSangre)
//                //        {
//                //            foreach (var itemA in Alumnos)
//                //            {
//                //                var Genero = db.CatGeneros.Find(Book.idGenero);
//                //                var TipoSangre = db.CatTiposSangre.Find(itemS.idTipoSangre);
//                //                if (itemA.Personas.idGenero == Genero.idGenero && itemA.idTipoSangre == TipoSangre.idTipoSangre)
//                //                {
//                //                    IndicadoresVM IndicadorGS = new IndicadoresVM();
//                //                    IndicadorGS.nbCampo = Genero.nbGenero;
//                //                    IndicadorGS.nbCampo2 = TipoSangre.nbTipoSangre.Trim();
//                //                    IndicadorGS.numCampo = 1;
//                //                    ListaGenTipoSangre.Add(IndicadorGS);
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (Book.idTipoSangre == null && Book.idGenero == null)
//                //    {
//                //        foreach (var itemS in CatTiposSangre)
//                //        {
//                //            foreach (var itemG in CatGeneros)
//                //            {
//                //                foreach (var itemA in Alumnos)
//                //                {
//                //                    var Genero = db.CatGeneros.Find(itemG.idGenero);
//                //                    var TipoSangre = db.CatTiposSangre.Find(itemS.idTipoSangre);
//                //                    if (itemA.Personas.idGenero == Genero.idGenero && itemA.idTipoSangre == TipoSangre.idTipoSangre)
//                //                    {
//                //                        IndicadoresVM IndicadorGS = new IndicadoresVM();
//                //                        IndicadorGS.nbCampo = Genero.nbGenero;
//                //                        IndicadorGS.nbCampo2 = TipoSangre.nbTipoSangre.Trim();
//                //                        IndicadorGS.numCampo = 1;
//                //                        ListaGenTipoSangre.Add(IndicadorGS);
//                //                    }
//                //                }
//                //            }
//                //        }
//                //    }

//                //    ListaGenTipoSangre.ToList().ForEach(t =>
//                //    {
//                //        var row = dt.NewRow();
//                //        row["nbCategoria"] = t.nbCampo;
//                //        row["nbCategoria2"] = t.nbCampo2;
//                //        row["numDatos"] = t.numCampo;
//                //        dt.Rows.Add(row);
//                //    });

//                //    #endregion
//                //}
//                //else if (listacaCampos[0] == 6 && listacaCampos[1] == 12)
//                //{
//                //    #region

//                //    TituloColumna1 = "Género";
//                //    TituloColumna2 = "Licencia";
//                //    TituloColumna3 = "Cantidad";
//                //    TituloGrafic = "Gráfica de barras por Género y Liciencia";

//                //    var CatGeneros = db.CatGeneros.ToList();
//                //    List<IndicadoresVM> IndicadoresGLicencia = new List<IndicadoresVM>();

//                //    if (Book.idGenero != null && Book.fgLicencia != null)
//                //    {
//                //        foreach (var itemA in Alumnos)
//                //        {
//                //            var Genero = db.CatGeneros.Find(Book.idGenero);
//                //            if (itemA.Personas.idGenero == Genero.idGenero && itemA.fgLicencia == Book.fgLicencia)
//                //            {
//                //                IndicadoresVM IndicadorGL = new IndicadoresVM();
//                //                IndicadorGL.nbCampo = Genero.nbGenero.Trim();
//                //                IndicadorGL.nbCampo2 = (Book.fgLicencia == true) ? "SI" : "NO";
//                //                IndicadorGL.numCampo = 1;
//                //                IndicadoresGLicencia.Add(IndicadorGL);
//                //            }
//                //        }
//                //    }
//                //    else if (Book.idGenero == null && Book.fgLicencia != null)
//                //    {
//                //        foreach (var itemG in CatGeneros)
//                //        {
//                //            foreach (var itemA in Alumnos)
//                //            {
//                //                var Genero = db.CatGeneros.Find(itemG.idGenero);
//                //                if (itemA.Personas.idGenero == Genero.idGenero && itemA.fgLicencia == Book.fgLicencia)
//                //                {
//                //                    IndicadoresVM IndicadorGL = new IndicadoresVM();
//                //                    IndicadorGL.nbCampo = Genero.nbGenero.Trim();
//                //                    IndicadorGL.nbCampo2 = (Book.fgLicencia == true) ? "SI" : "NO";
//                //                    IndicadorGL.numCampo = 1;
//                //                    IndicadoresGLicencia.Add(IndicadorGL);
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (Book.idGenero == null && Book.fgLicencia == null)
//                //    {
//                //        foreach (var itemG in CatGeneros)
//                //        {
//                //            foreach (var itemA in Alumnos)
//                //            {
//                //                var Genero = db.CatGeneros.Find(itemG.idGenero);
//                //                if (itemA.Personas.idGenero == Genero.idGenero && itemA.fgLicencia == true)
//                //                {
//                //                    IndicadoresVM IndicadorGL = new IndicadoresVM();
//                //                    IndicadorGL.nbCampo = Genero.nbGenero.Trim();
//                //                    IndicadorGL.nbCampo2 = "SI";
//                //                    IndicadorGL.numCampo = 1;
//                //                    IndicadoresGLicencia.Add(IndicadorGL);
//                //                }
//                //                else if (itemA.Personas.idGenero == Genero.idGenero && itemA.fgLicencia == false)
//                //                {
//                //                    IndicadoresVM IndicadorGLN = new IndicadoresVM();
//                //                    IndicadorGLN.nbCampo = Genero.nbGenero.Trim();
//                //                    IndicadorGLN.nbCampo2 = "NO";
//                //                    IndicadorGLN.numCampo = 1;
//                //                    IndicadoresGLicencia.Add(IndicadorGLN);
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (Book.idGenero != null && Book.fgLicencia == null)
//                //    {
//                //        foreach (var itemA in Alumnos)
//                //        {
//                //            var Genero = db.CatGeneros.Find(Book.idGenero);
//                //            if (itemA.Personas.idGenero == Genero.idGenero && itemA.fgLicencia == true)
//                //            {
//                //                IndicadoresVM IndicadorGL = new IndicadoresVM();
//                //                IndicadorGL.nbCampo = Genero.nbGenero.Trim();
//                //                IndicadorGL.nbCampo2 = "SI";
//                //                IndicadorGL.numCampo = 1;
//                //                IndicadoresGLicencia.Add(IndicadorGL);
//                //            }
//                //            else if (itemA.Personas.idGenero == Genero.idGenero && itemA.fgLicencia == false)
//                //            {
//                //                IndicadoresVM IndicadorGLN = new IndicadoresVM();
//                //                IndicadorGLN.nbCampo = Genero.nbGenero.Trim();
//                //                IndicadorGLN.nbCampo2 = "NO";
//                //                IndicadorGLN.numCampo = 1;
//                //                IndicadoresGLicencia.Add(IndicadorGLN);
//                //            }
//                //        }
//                //    }

//                //    IndicadoresGLicencia.ToList().ForEach(l =>
//                //    {
//                //        var row = dt.NewRow();
//                //        row["nbCategoria"] = l.nbCampo;
//                //        row["nbCategoria2"] = l.nbCampo2;
//                //        row["numDatos"] = l.numCampo;
//                //        dt.Rows.Add(row);
//                //    });

//                //    #endregion
//                //}
//                //else if (listacaCampos[0] == 6 && listacaCampos[1] == 13)
//                //{
//                //    #region

//                //    TituloColumna1 = "Género";
//                //    TituloColumna2 = "Tipo de Egresado";
//                //    TituloColumna3 = "Cantidad";
//                //    TituloGrafic = "Gráfica de barras por Género y Tipo de Egresado";

//                //    var CatGeneros = db.CatGeneros.ToList();
//                //    List<IndicadoresVM> IndicadoresGEgresado = new List<IndicadoresVM>();

//                //    if (Book.idGenero != null && Book.tpEgresado != null)
//                //    {
//                //        foreach (var itemA in Alumnos)
//                //        {
//                //            var Genero = db.CatGeneros.Find(Book.idGenero);
//                //            if (itemA.Personas.idGenero == Genero.idGenero && itemA.tpEgresado == Book.tpEgresado)
//                //            {
//                //                IndicadoresVM IndicadorGE = new IndicadoresVM();
//                //                IndicadorGE.nbCampo = Genero.nbGenero.Trim();
//                //                IndicadorGE.nbCampo2 = (Book.tpEgresado == "T") ? "Titulado" : "Pasante";
//                //                IndicadorGE.numCampo = 1;
//                //                IndicadoresGEgresado.Add(IndicadorGE);
//                //            }
//                //        }
//                //    }
//                //    else if (Book.idGenero == null && Book.tpEgresado != null)
//                //    {
//                //        foreach (var itemG in CatGeneros)
//                //        {
//                //            foreach (var itemA in Alumnos)
//                //            {
//                //                var Genero = db.CatGeneros.Find(itemG.idGenero);
//                //                if (itemA.Personas.idGenero == Genero.idGenero && itemA.tpEgresado == Book.tpEgresado)
//                //                {
//                //                    IndicadoresVM IndicadorGE = new IndicadoresVM();
//                //                    IndicadorGE.nbCampo = Genero.nbGenero.Trim();
//                //                    IndicadorGE.nbCampo2 = (Book.tpEgresado == "T") ? "Titulado" : "Pasante";
//                //                    IndicadorGE.numCampo = 1;
//                //                    IndicadoresGEgresado.Add(IndicadorGE);
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (Book.idGenero == null && Book.tpEgresado == null)
//                //    {
//                //        foreach (var itemG in CatGeneros)
//                //        {
//                //            foreach (var itemA in Alumnos)
//                //            {
//                //                var Genero = db.CatGeneros.Find(itemG.idGenero);
//                //                if (itemA.Personas.idGenero == Genero.idGenero && itemA.tpEgresado == "T")
//                //                {
//                //                    IndicadoresVM IndicadorGE = new IndicadoresVM();
//                //                    IndicadorGE.nbCampo = Genero.nbGenero.Trim();
//                //                    IndicadorGE.nbCampo2 = "Titulado";
//                //                    IndicadorGE.numCampo = 1;
//                //                    IndicadoresGEgresado.Add(IndicadorGE);
//                //                }
//                //                else if (itemA.Personas.idGenero == Genero.idGenero && itemA.tpEgresado == "P")
//                //                {
//                //                    IndicadoresVM IndicadorGEN = new IndicadoresVM();
//                //                    IndicadorGEN.nbCampo = Genero.nbGenero.Trim();
//                //                    IndicadorGEN.nbCampo2 = "Pasante";
//                //                    IndicadorGEN.numCampo = 1;
//                //                    IndicadoresGEgresado.Add(IndicadorGEN);
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (Book.idGenero != null && Book.tpEgresado == null)
//                //    {
//                //        foreach (var itemA in Alumnos)
//                //        {
//                //            var Genero = db.CatGeneros.Find(Book.idGenero);
//                //            if (itemA.Personas.idGenero == Genero.idGenero && itemA.tpEgresado == "T")
//                //            {
//                //                IndicadoresVM IndicadorGE = new IndicadoresVM();
//                //                IndicadorGE.nbCampo = Genero.nbGenero.Trim();
//                //                IndicadorGE.nbCampo2 = "Titulado";
//                //                IndicadorGE.numCampo = 1;
//                //                IndicadoresGEgresado.Add(IndicadorGE);
//                //            }
//                //            else if (itemA.Personas.idGenero == Genero.idGenero && itemA.tpEgresado == "P")
//                //            {
//                //                IndicadoresVM IndicadorGEN = new IndicadoresVM();
//                //                IndicadorGEN.nbCampo = Genero.nbGenero.Trim();
//                //                IndicadorGEN.nbCampo2 = "Pasante";
//                //                IndicadorGEN.numCampo = 1;
//                //                IndicadoresGEgresado.Add(IndicadorGEN);
//                //            }
//                //        }
//                //    }

//                //    IndicadoresGEgresado.ToList().ForEach(l =>
//                //    {
//                //        var row = dt.NewRow();
//                //        row["nbCategoria"] = l.nbCampo;
//                //        row["nbCategoria2"] = l.nbCampo2;
//                //        row["numDatos"] = l.numCampo;
//                //        dt.Rows.Add(row);
//                //    });

//                //    #endregion
//                //}
//                //else if (listacaCampos[0] == 6 && listacaCampos[1] == 14)
//                //{
//                //    #region

//                //    TituloColumna1 = "Género";
//                //    TituloColumna2 = "Fallecimiento";
//                //    TituloColumna3 = "Cantidad";
//                //    TituloGrafic = "Gráfica de barras por Género y Fallecimiento";

//                //    var CatGeneros = db.CatGeneros.ToList();
//                //    List<IndicadoresVM> IndicadoresGFallecido = new List<IndicadoresVM>();

//                //    if (Book.idGenero != null && Book.fgFallecido != null)
//                //    {
//                //        foreach (var itemA in Alumnos)
//                //        {
//                //            var Genero = db.CatGeneros.Find(Book.idGenero);
//                //            if (itemA.Personas.idGenero == Genero.idGenero && itemA.fgFallecido == Book.fgFallecido)
//                //            {
//                //                IndicadoresVM IndicadorGF = new IndicadoresVM();
//                //                IndicadorGF.nbCampo = Genero.nbGenero.Trim();
//                //                IndicadorGF.nbCampo2 = (Book.fgFallecido == true) ? "SI" : "NO";
//                //                IndicadorGF.numCampo = 1;
//                //                IndicadoresGFallecido.Add(IndicadorGF);
//                //            }
//                //        }
//                //    }
//                //    else if (Book.idGenero == null && Book.fgFallecido != null)
//                //    {
//                //        foreach (var itemG in CatGeneros)
//                //        {
//                //            foreach (var itemA in Alumnos)
//                //            {
//                //                var Genero = db.CatGeneros.Find(itemG.idGenero);
//                //                if (itemA.Personas.idGenero == Genero.idGenero && itemA.fgFallecido == Book.fgFallecido)
//                //                {
//                //                    IndicadoresVM IndicadorGF = new IndicadoresVM();
//                //                    IndicadorGF.nbCampo = Genero.nbGenero.Trim();
//                //                    IndicadorGF.nbCampo2 = (Book.fgFallecido == true) ? "SI" : "NO";
//                //                    IndicadorGF.numCampo = 1;
//                //                    IndicadoresGFallecido.Add(IndicadorGF);
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (Book.idGenero == null && Book.fgFallecido == null)
//                //    {
//                //        foreach (var itemG in CatGeneros)
//                //        {
//                //            foreach (var itemA in Alumnos)
//                //            {
//                //                var Genero = db.CatGeneros.Find(itemG.idGenero);
//                //                if (itemA.Personas.idGenero == Genero.idGenero && itemA.fgFallecido == true)
//                //                {
//                //                    IndicadoresVM IndicadorGF = new IndicadoresVM();
//                //                    IndicadorGF.nbCampo = Genero.nbGenero.Trim();
//                //                    IndicadorGF.nbCampo2 = "SI";
//                //                    IndicadorGF.numCampo = 1;
//                //                    IndicadoresGFallecido.Add(IndicadorGF);
//                //                }
//                //                else if (itemA.Personas.idGenero == Genero.idGenero && itemA.fgFallecido == false)
//                //                {
//                //                    IndicadoresVM IndicadorGFN = new IndicadoresVM();
//                //                    IndicadorGFN.nbCampo = Genero.nbGenero.Trim();
//                //                    IndicadorGFN.nbCampo2 = "NO";
//                //                    IndicadorGFN.numCampo = 1;
//                //                    IndicadoresGFallecido.Add(IndicadorGFN);
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (Book.idGenero != null && Book.fgFallecido == null)
//                //    {
//                //        foreach (var itemA in Alumnos)
//                //        {
//                //            var Genero = db.CatGeneros.Find(Book.idGenero);
//                //            if (itemA.Personas.idGenero == Genero.idGenero && itemA.fgFallecido == true)
//                //            {
//                //                IndicadoresVM IndicadorGF = new IndicadoresVM();
//                //                IndicadorGF.nbCampo = Genero.nbGenero.Trim();
//                //                IndicadorGF.nbCampo2 = "SI";
//                //                IndicadorGF.numCampo = 1;
//                //                IndicadoresGFallecido.Add(IndicadorGF);
//                //            }
//                //            else if (itemA.Personas.idGenero == Genero.idGenero && itemA.fgFallecido == false)
//                //            {
//                //                IndicadoresVM IndicadorGFN = new IndicadoresVM();
//                //                IndicadorGFN.nbCampo = Genero.nbGenero.Trim();
//                //                IndicadorGFN.nbCampo2 = "NO";
//                //                IndicadorGFN.numCampo = 1;
//                //                IndicadoresGFallecido.Add(IndicadorGFN);
//                //            }
//                //        }
//                //    }

//                //    IndicadoresGFallecido.ToList().ForEach(l =>
//                //    {
//                //        var row = dt.NewRow();
//                //        row["nbCategoria"] = l.nbCampo;
//                //        row["nbCategoria2"] = l.nbCampo2;
//                //        row["numDatos"] = l.numCampo;
//                //        dt.Rows.Add(row);
//                //    });

//                //    #endregion
//                //}
//                //else if (listacaCampos[0] == 7 && listacaCampos[1] == 2)
//                //{
//                //    #region

//                //    TituloColumna1 = "Licenciatura";
//                //    TituloColumna2 = "Estado Civil";
//                //    TituloColumna3 = "Cantidad";
//                //    TituloGrafic = "Gráfica de barras por Licenciatura y Estado Civil";

//                //    Licenciaturas Licenciatura = new Licenciaturas();
//                //    var Licenciaturas = db.Licenciaturas.ToList();
//                //    var CatEstadosCiviles = db.CatEstadosCiviles.ToList();
//                //    List<IndicadoresVM> IndicadoresECLic = new List<IndicadoresVM>();

//                //    if (Book.idEstadoCivil != null && listaIdsLicenciaturas.Count > 0)
//                //    {
//                //        foreach (var itemL in listaIdsLicenciaturas)
//                //        {
//                //            foreach (var itemA in Alumnos)
//                //            {
//                //                var idLicenciatura = Convert.ToInt64(itemL);
//                //                Licenciatura = Licenciaturas.FirstOrDefault(x => x.idLicenciatura == idLicenciatura);
//                //                var EstadoCivil = db.CatEstadosCiviles.Find(Book.idEstadoCivil);
//                //                var FormacionesA = db.FormacionesAcademicas.Where(x => x.idAlumno == itemA.idAlumno && x.idLicenciatura == Licenciatura.idLicenciatura).ToList();
//                //                if (itemA.idEstadoCivil == EstadoCivil.idEstadoCivil && FormacionesA.Count() > 0)
//                //                {
//                //                    IndicadoresVM IndicadorECL = new IndicadoresVM();
//                //                    IndicadorECL.nbCampo = Licenciatura.nbLicenciatura.Trim();
//                //                    IndicadorECL.nbCampo2 = EstadoCivil.nbEstadoCivil.Trim();
//                //                    IndicadorECL.numCampo = 1;
//                //                    IndicadoresECLic.Add(IndicadorECL);
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (Book.idEstadoCivil == null && listaIdsLicenciaturas.Count > 0)
//                //    {
//                //        foreach (var itemL in listaIdsLicenciaturas)
//                //        {
//                //            var idLicenciatura = Convert.ToInt64(itemL);
//                //            Licenciatura = Licenciaturas.FirstOrDefault(x => x.idLicenciatura == idLicenciatura);
//                //            foreach (var itemEC in CatEstadosCiviles)
//                //            {
//                //                foreach (var itemA in Alumnos)
//                //                {
//                //                    var EstadoCivil = db.CatEstadosCiviles.Find(itemEC.idEstadoCivil);
//                //                    var FormacionesA = db.FormacionesAcademicas.Where(x => x.idAlumno == itemA.idAlumno && x.idLicenciatura == Licenciatura.idLicenciatura).ToList();
//                //                    if (itemA.idEstadoCivil == EstadoCivil.idEstadoCivil && FormacionesA.Count() > 0)
//                //                    {
//                //                        IndicadoresVM IndicadorECL = new IndicadoresVM();
//                //                        IndicadorECL.nbCampo = Licenciatura.nbLicenciatura.Trim();
//                //                        IndicadorECL.nbCampo2 = EstadoCivil.nbEstadoCivil.Trim();
//                //                        IndicadorECL.numCampo = 1;
//                //                        IndicadoresECLic.Add(IndicadorECL);
//                //                    }
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (Book.idEstadoCivil == null && listaIdsLicenciaturas.Count == 0)
//                //    {
//                //        foreach (var itemL in Licenciaturas)
//                //        {
//                //            foreach (var itemEC in CatEstadosCiviles)
//                //            {
//                //                foreach (var itemA in Alumnos)
//                //                {
//                //                    //var idLicenciatura = Convert.ToInt64(itemL);
//                //                    Licenciatura = Licenciaturas.FirstOrDefault(x => x.idLicenciatura == itemL.idLicenciatura);
//                //                    var EstadoCivil = db.CatEstadosCiviles.Find(itemEC.idEstadoCivil);
//                //                    var FormacionesA = db.FormacionesAcademicas.Where(x => x.idAlumno == itemA.idAlumno && x.idLicenciatura == Licenciatura.idLicenciatura).ToList();
//                //                    if (itemA.idEstadoCivil == EstadoCivil.idEstadoCivil && FormacionesA.Count() > 0)
//                //                    {
//                //                        IndicadoresVM IndicadorECL = new IndicadoresVM();
//                //                        IndicadorECL.nbCampo = Licenciatura.nbLicenciatura.Trim();
//                //                        IndicadorECL.nbCampo2 = EstadoCivil.nbEstadoCivil.Trim();
//                //                        IndicadorECL.numCampo = 1;
//                //                        IndicadoresECLic.Add(IndicadorECL);
//                //                    }
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (Book.idEstadoCivil != null && listaIdsLicenciaturas.Count == 0)
//                //    {
//                //        foreach (var itemL in Licenciaturas)
//                //        {
//                //            foreach (var itemA in Alumnos)
//                //            {
//                //                //var idLicenciatura = Convert.ToInt64(itemL);
//                //                Licenciatura = Licenciaturas.FirstOrDefault(x => x.idLicenciatura == itemL.idLicenciatura);
//                //                var EstadoCivil = db.CatEstadosCiviles.Find(Book.idEstadoCivil);
//                //                var FormacionesA = db.FormacionesAcademicas.Where(x => x.idAlumno == itemA.idAlumno && x.idLicenciatura == Licenciatura.idLicenciatura).ToList();
//                //                if (itemA.idEstadoCivil == EstadoCivil.idEstadoCivil && FormacionesA.Count() > 0)
//                //                {
//                //                    IndicadoresVM IndicadorECL = new IndicadoresVM();
//                //                    IndicadorECL.nbCampo = Licenciatura.nbLicenciatura.Trim();
//                //                    IndicadorECL.nbCampo2 = EstadoCivil.nbEstadoCivil.Trim();
//                //                    IndicadorECL.numCampo = 1;
//                //                    IndicadoresECLic.Add(IndicadorECL);
//                //                }
//                //            }
//                //        }
//                //    }

//                //    IndicadoresECLic.ToList().ForEach(l =>
//                //    {
//                //        var row = dt.NewRow();
//                //        row["nbCategoria"] = l.nbCampo;
//                //        row["nbCategoria2"] = l.nbCampo2;
//                //        row["numDatos"] = l.numCampo;
//                //        dt.Rows.Add(row);
//                //    });

//                //    #endregion
//                //}
//                //else if (listacaCampos[0] == 7 && listacaCampos[1] == 3)
//                //{
//                //    #region

//                //    TituloColumna1 = "Licenciatura";
//                //    TituloColumna2 = "Edad";
//                //    TituloColumna3 = "Cantidad";
//                //    TituloGrafic = "Gráfica de barras por Licenciatura y Edad";
//                //    Licenciaturas Licenciatura = new Licenciaturas();
//                //    var Licenciaturas = db.Licenciaturas.ToList();
//                //    List<IndicadoresVM> ListaEdadLic = new List<IndicadoresVM>();

//                //    if (Book.numEdadMinima != null && Book.numEdadMinima != null && listaIdsLicenciaturas.Count() > 0)
//                //    {
//                //        for (var i = Book.numEdadMinima; i <= Book.numEdadMaxima; i++)
//                //        {
//                //            foreach (var itemL in listaIdsLicenciaturas)
//                //            {
//                //                foreach (var item in Alumnos)
//                //                {
//                //                    var idLicenciatura = Convert.ToInt64(itemL);
//                //                    Licenciatura = Licenciaturas.FirstOrDefault(x => x.idLicenciatura == idLicenciatura);
//                //                    var FormacionesA = db.FormacionesAcademicas.Where(x => x.idAlumno == item.idAlumno && x.idLicenciatura == Licenciatura.idLicenciatura).ToList();
//                //                    var edad = DateTime.Now.Year - ((DateTime)item.feNacimiento).Date.Year;
//                //                    if (edad == i && FormacionesA.Count() > 0)
//                //                    {
//                //                        IndicadoresVM IndicadorEdadL = new IndicadoresVM();
//                //                        IndicadorEdadL.nbCampo = Licenciatura.nbLicenciatura.Trim();
//                //                        IndicadorEdadL.nbCampo2 = i + " Años";
//                //                        IndicadorEdadL.numCampo = 1;
//                //                        ListaEdadLic.Add(IndicadorEdadL);
//                //                    }
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (Book.numEdadMinima != null && Book.numEdadMinima != null && listaIdsLicenciaturas.Count() == 0)
//                //    {
//                //        for (var i = Book.numEdadMinima; i <= Book.numEdadMaxima; i++)
//                //        {
//                //            foreach (var itemL in Licenciaturas)
//                //            {
//                //                foreach (var item in Alumnos)
//                //                {
//                //                    //var idLicenciatura = Convert.ToInt64(itemL);
//                //                    //Licenciatura = Licenciaturas.FirstOrDefault(x => x.idLicenciatura == idLicenciatura);
//                //                    var FormacionesA = db.FormacionesAcademicas.Where(x => x.idAlumno == item.idAlumno && x.idLicenciatura == itemL.idLicenciatura).ToList();
//                //                    var edad = DateTime.Now.Year - ((DateTime)item.feNacimiento).Date.Year;
//                //                    if (edad == i && FormacionesA.Count() > 0)
//                //                    {
//                //                        IndicadoresVM IndicadorEdadL = new IndicadoresVM();
//                //                        IndicadorEdadL.nbCampo = itemL.nbLicenciatura.Trim();
//                //                        IndicadorEdadL.nbCampo2 = i + " Años";
//                //                        IndicadorEdadL.numCampo = 1;
//                //                        ListaEdadLic.Add(IndicadorEdadL);
//                //                    }
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (Book.numEdadMinima == null && Book.numEdadMinima == null && listaIdsLicenciaturas.Count() > 0)
//                //    {
//                //        for (var i = 15; i <= 80; i++)
//                //        {
//                //            foreach (var itemL in listaIdsLicenciaturas)
//                //            {
//                //                foreach (var item in Alumnos)
//                //                {
//                //                    var idLicenciatura = Convert.ToInt64(itemL);
//                //                    Licenciatura = Licenciaturas.FirstOrDefault(x => x.idLicenciatura == idLicenciatura);
//                //                    var FormacionesA = db.FormacionesAcademicas.Where(x => x.idAlumno == item.idAlumno && x.idLicenciatura == Licenciatura.idLicenciatura).ToList();
//                //                    var edad = DateTime.Now.Year - ((DateTime)item.feNacimiento).Date.Year;
//                //                    if (edad == i && FormacionesA.Count() > 0)
//                //                    {
//                //                        IndicadoresVM IndicadorEdadL = new IndicadoresVM();
//                //                        IndicadorEdadL.nbCampo = Licenciatura.nbLicenciatura.Trim();
//                //                        IndicadorEdadL.nbCampo2 = i + " Años";
//                //                        IndicadorEdadL.numCampo = 1;
//                //                        ListaEdadLic.Add(IndicadorEdadL);
//                //                    }
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (Book.numEdadMinima == null && Book.numEdadMinima == null && listaIdsLicenciaturas.Count() == 0)
//                //    {
//                //        for (var i = 15; i <= 80; i++)
//                //        {
//                //            foreach (var itemL in Licenciaturas)
//                //            {
//                //                foreach (var item in Alumnos)
//                //                {
//                //                    //var idLicenciatura = Convert.ToInt64(itemL);
//                //                    //Licenciatura = Licenciaturas.FirstOrDefault(x => x.idLicenciatura == idLicenciatura);
//                //                    var FormacionesA = db.FormacionesAcademicas.Where(x => x.idAlumno == item.idAlumno && x.idLicenciatura == itemL.idLicenciatura).ToList();
//                //                    var edad = DateTime.Now.Year - ((DateTime)item.feNacimiento).Date.Year;
//                //                    if (edad == i && FormacionesA.Count() > 0)
//                //                    {
//                //                        IndicadoresVM IndicadorEdadL = new IndicadoresVM();
//                //                        IndicadorEdadL.nbCampo = itemL.nbLicenciatura.Trim();
//                //                        IndicadorEdadL.nbCampo2 = i + " Años";
//                //                        IndicadorEdadL.numCampo = 1;
//                //                        ListaEdadLic.Add(IndicadorEdadL);
//                //                    }
//                //                }
//                //            }
//                //        }
//                //    }

//                //    ListaEdadLic.ToList().ForEach(t =>
//                //    {
//                //        var row = dt.NewRow();
//                //        row["nbCategoria"] = t.nbCampo;
//                //        row["nbCategoria2"] = t.nbCampo2;
//                //        row["numDatos"] = t.numCampo;
//                //        dt.Rows.Add(row);
//                //    });

//                //    #endregion
//                //}
//                //else if (listacaCampos[0] == 7 && listacaCampos[1] == 6)
//                //{
//                //    #region

//                //    TituloColumna1 = "Licenciatura";
//                //    TituloColumna2 = "Género";
//                //    TituloColumna3 = "Cantidad";
//                //    TituloGrafic = "Gráfica de barras por Licenciatura y Género";

//                //    var CatGeneros = db.CatGeneros.ToList();
//                //    Licenciaturas Licenciatura = new Licenciaturas();
//                //    var Licenciaturas = db.Licenciaturas.ToList();
//                //    List<IndicadoresVM> IndicadoresGLic = new List<IndicadoresVM>();

//                //    if (Book.idGenero != null && listaIdsLicenciaturas.Count > 0)
//                //    {
//                //        foreach (var itemL in listaIdsLicenciaturas)
//                //        {
//                //            foreach (var item in Alumnos)
//                //            {
//                //                var idLicenciatura = Convert.ToInt64(itemL);
//                //                Licenciatura = Licenciaturas.FirstOrDefault(x => x.idLicenciatura == idLicenciatura);
//                //                var FormacionesA = db.FormacionesAcademicas.Where(x => x.idAlumno == item.idAlumno && x.idLicenciatura == Licenciatura.idLicenciatura).ToList();
//                //                var Genero = db.CatGeneros.Find(Book.idGenero);
//                //                if (item.Personas.idGenero == Genero.idGenero && FormacionesA.Count() > 0)
//                //                {
//                //                    IndicadoresVM IndicadorGL = new IndicadoresVM();
//                //                    IndicadorGL.nbCampo = Licenciatura.nbLicenciatura;
//                //                    IndicadorGL.nbCampo2 = Genero.nbGenero.Trim();
//                //                    IndicadorGL.numCampo = 1;
//                //                    IndicadoresGLic.Add(IndicadorGL);
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (Book.idGenero == null && listaIdsLicenciaturas.Count > 0)
//                //    {
//                //        foreach (var itemL in listaIdsLicenciaturas)
//                //        {
//                //            var idLicenciatura = Convert.ToInt64(itemL);
//                //            Licenciatura = Licenciaturas.FirstOrDefault(x => x.idLicenciatura == idLicenciatura);
//                //            foreach (var itemG in CatGeneros)
//                //            {
//                //                foreach (var item in Alumnos)
//                //                {
//                //                    var FormacionesA = db.FormacionesAcademicas.Where(x => x.idAlumno == item.idAlumno && x.idLicenciatura == Licenciatura.idLicenciatura).ToList();
//                //                    var Genero = db.CatGeneros.Find(itemG.idGenero);
//                //                    if (item.Personas.idGenero == Genero.idGenero && FormacionesA.Count() > 0)
//                //                    {
//                //                        IndicadoresVM IndicadorGL = new IndicadoresVM();
//                //                        IndicadorGL.nbCampo = Licenciatura.nbLicenciatura;
//                //                        IndicadorGL.nbCampo2 = Genero.nbGenero.Trim();
//                //                        IndicadorGL.numCampo = 1;
//                //                        IndicadoresGLic.Add(IndicadorGL);
//                //                    }
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (Book.idGenero == null && listaIdsLicenciaturas.Count == 0)
//                //    {
//                //        foreach (var itemL in Licenciaturas)
//                //        {
//                //            //var idLicenciatura = Convert.ToInt64(itemL);
//                //            Licenciatura = Licenciaturas.FirstOrDefault(x => x.idLicenciatura == itemL.idLicenciatura);
//                //            foreach (var itemG in CatGeneros)
//                //            {
//                //                foreach (var item in Alumnos)
//                //                {
//                //                    var FormacionesA = db.FormacionesAcademicas.Where(x => x.idAlumno == item.idAlumno && x.idLicenciatura == Licenciatura.idLicenciatura).ToList();
//                //                    var Genero = db.CatGeneros.Find(itemG.idGenero);
//                //                    if (item.Personas.idGenero == Genero.idGenero && FormacionesA.Count() > 0)
//                //                    {
//                //                        IndicadoresVM IndicadorGL = new IndicadoresVM();
//                //                        IndicadorGL.nbCampo = Licenciatura.nbLicenciatura;
//                //                        IndicadorGL.nbCampo2 = Genero.nbGenero.Trim();
//                //                        IndicadorGL.numCampo = 1;
//                //                        IndicadoresGLic.Add(IndicadorGL);
//                //                    }
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (Book.idGenero != null && listaIdsLicenciaturas.Count == 0)
//                //    {
//                //        foreach (var itemL in Licenciaturas)
//                //        {
//                //            foreach (var item in Alumnos)
//                //            {
//                //                //var idLicenciatura = Convert.ToInt64(itemL);
//                //                Licenciatura = Licenciaturas.FirstOrDefault(x => x.idLicenciatura == itemL.idLicenciatura);
//                //                var FormacionesA = db.FormacionesAcademicas.Where(x => x.idAlumno == item.idAlumno && x.idLicenciatura == Licenciatura.idLicenciatura).ToList();
//                //                var Genero = db.CatGeneros.Find(Book.idGenero);
//                //                if (item.Personas.idGenero == Genero.idGenero && FormacionesA.Count() > 0)
//                //                {
//                //                    IndicadoresVM IndicadorGL = new IndicadoresVM();
//                //                    IndicadorGL.nbCampo = Licenciatura.nbLicenciatura;
//                //                    IndicadorGL.nbCampo2 = Genero.nbGenero.Trim();
//                //                    IndicadorGL.numCampo = 1;
//                //                    IndicadoresGLic.Add(IndicadorGL);
//                //                }
//                //            }
//                //        }
//                //    }

//                //    IndicadoresGLic.ToList().ForEach(l =>
//                //    {
//                //        var row = dt.NewRow();
//                //        row["nbCategoria"] = l.nbCampo;
//                //        row["nbCategoria2"] = l.nbCampo2;
//                //        row["numDatos"] = l.numCampo;
//                //        dt.Rows.Add(row);
//                //    });

//                //    #endregion
//                //}
//                //else if (listacaCampos[0] == 7 && listacaCampos[1] == 8)
//                //{
//                //    #region
//                //    TituloColumna1 = "Licenciatura";
//                //    TituloColumna2 = "Religión";
//                //    TituloColumna3 = "Cantidad";
//                //    TituloGrafic = "Gráfica de barras por Licenciatura y Religión";

//                //    Licenciaturas Licenciatura = new Licenciaturas();
//                //    var Licenciaturas = db.Licenciaturas.ToList();
//                //    CatReligion Religion = new CatReligion();
//                //    var Religiones = db.CatReligion.ToList();

//                //    List<IndicadoresVM> IndicadoresLicRel = new List<IndicadoresVM>();

//                //    if (listaIdsLicenciaturas.Count() > 0 && listaIdsReligiones.Count() > 0)
//                //    {
//                //        foreach (var itemL in listaIdsLicenciaturas)
//                //        {
//                //            foreach (var itemR in listaIdsReligiones)
//                //            {
//                //                foreach (var item in Alumnos)
//                //                {
//                //                    var idLicenciatura = Convert.ToInt64(itemL);
//                //                    Licenciatura = Licenciaturas.FirstOrDefault(x => x.idLicenciatura == idLicenciatura);
//                //                    var idReligion = Convert.ToInt64(itemR);
//                //                    Religion = db.CatReligion.Find(idReligion);
//                //                    var FormacionesA = db.FormacionesAcademicas.Where(x => x.idAlumno == item.idAlumno && x.idLicenciatura == Licenciatura.idLicenciatura).ToList();
//                //                    if (item.idReligion == Religion.idReligion && FormacionesA.Count() > 0)
//                //                    {
//                //                        IndicadoresVM IndicadorLR = new IndicadoresVM();
//                //                        IndicadorLR.nbCampo = Licenciatura.nbLicenciatura;
//                //                        IndicadorLR.nbCampo2 = Religion.nbReligion;
//                //                        IndicadorLR.numCampo = 1;
//                //                        IndicadoresLicRel.Add(IndicadorLR);
//                //                    }
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (listaIdsLicenciaturas.Count() > 0 && listaIdsReligiones.Count() == 0)
//                //    {
//                //        foreach (var itemL in listaIdsLicenciaturas)
//                //        {
//                //            foreach (var itemR in Religiones)
//                //            {
//                //                foreach (var item in Alumnos)
//                //                {
//                //                    var idLicenciatura = Convert.ToInt64(itemL);
//                //                    Licenciatura = Licenciaturas.FirstOrDefault(x => x.idLicenciatura == idLicenciatura);
//                //                    //var idReligion = Convert.ToInt64(itemR);
//                //                    Religion = db.CatReligion.Find(itemR.idReligion);
//                //                    var FormacionesA = db.FormacionesAcademicas.Where(x => x.idAlumno == item.idAlumno && x.idLicenciatura == Licenciatura.idLicenciatura).ToList();
//                //                    if (item.idReligion == Religion.idReligion && FormacionesA.Count() > 0)
//                //                    {
//                //                        IndicadoresVM IndicadorLR = new IndicadoresVM();
//                //                        IndicadorLR.nbCampo = Licenciatura.nbLicenciatura;
//                //                        IndicadorLR.nbCampo2 = Religion.nbReligion;
//                //                        IndicadorLR.numCampo = 1;
//                //                        IndicadoresLicRel.Add(IndicadorLR);
//                //                    }
//                //                }

//                //            }
//                //        }
//                //    }
//                //    else if (listaIdsLicenciaturas.Count() == 0 && listaIdsReligiones.Count() > 0)
//                //    {
//                //        foreach (var itemL in Licenciaturas)
//                //        {
//                //            foreach (var itemR in listaIdsReligiones)
//                //            {
//                //                foreach (var item in Alumnos)
//                //                {
//                //                    //var idLicenciatura = Convert.ToInt64(itemL);
//                //                    Licenciatura = Licenciaturas.FirstOrDefault(x => x.idLicenciatura == itemL.idLicenciatura);
//                //                    var idReligion = Convert.ToInt64(itemR);
//                //                    Religion = db.CatReligion.Find(idReligion);
//                //                    var FormacionesA = db.FormacionesAcademicas.Where(x => x.idAlumno == item.idAlumno && x.idLicenciatura == Licenciatura.idLicenciatura).ToList();
//                //                    if (item.idReligion == Religion.idReligion && FormacionesA.Count() > 0)
//                //                    {
//                //                        IndicadoresVM IndicadorLR = new IndicadoresVM();
//                //                        IndicadorLR.nbCampo = Licenciatura.nbLicenciatura;
//                //                        IndicadorLR.nbCampo2 = Religion.nbReligion;
//                //                        IndicadorLR.numCampo = 1;
//                //                        IndicadoresLicRel.Add(IndicadorLR);
//                //                    }
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (listaIdsLicenciaturas.Count() == 0 && listaIdsReligiones.Count() == 0)
//                //    {
//                //        foreach (var itemL in Licenciaturas)
//                //        {
//                //            foreach (var itemR in Religiones)
//                //            {
//                //                foreach (var item in Alumnos)
//                //                {
//                //                    var idLicenciatura = Convert.ToInt64(itemL);
//                //                    Licenciatura = Licenciaturas.FirstOrDefault(x => x.idLicenciatura == itemL.idLicenciatura);
//                //                    //var idReligion = Convert.ToInt64(itemR);
//                //                    Religion = db.CatReligion.Find(itemR.idReligion);
//                //                    var FormacionesA = db.FormacionesAcademicas.Where(x => x.idAlumno == item.idAlumno && x.idLicenciatura == Licenciatura.idLicenciatura).ToList();
//                //                    if (item.idReligion == Religion.idReligion && FormacionesA.Count() > 0)
//                //                    {
//                //                        IndicadoresVM IndicadorLR = new IndicadoresVM();
//                //                        IndicadorLR.nbCampo = Licenciatura.nbLicenciatura;
//                //                        IndicadorLR.nbCampo2 = Religion.nbReligion;
//                //                        IndicadorLR.numCampo = 1;
//                //                        IndicadoresLicRel.Add(IndicadorLR);
//                //                    }
//                //                }
//                //            }
//                //        }
//                //    }

//                //    IndicadoresLicRel.ToList().ForEach(l =>
//                //    {
//                //        var row = dt.NewRow();
//                //        row["nbCategoria"] = l.nbCampo;
//                //        row["nbCategoria2"] = l.nbCampo2;
//                //        row["numDatos"] = l.numCampo;
//                //        dt.Rows.Add(row);
//                //    });

//                //    #endregion
//                //}
//                //else if (listacaCampos[0] == 7 && listacaCampos[1] == 9)
//                //{
//                //    #region

//                //    TituloColumna1 = "Licenciatura";
//                //    TituloColumna2 = "Estados";
//                //    TituloColumna3 = "Cantidad";
//                //    TituloGrafic = "Gráfica de barras por Licenciatura y Estados";

//                //    Licenciaturas Licenciatura = new Licenciaturas();
//                //    var Licenciaturas = db.Licenciaturas.ToList();
//                //    CatEstados Estado = new CatEstados();
//                //    var Estados = db.CatEstados.ToList();

//                //    List<IndicadoresVM> IndicadoresLicEdos = new List<IndicadoresVM>();

//                //    if (listaIdsLicenciaturas.Count() > 0 && listaIdsestados.Count() > 0)
//                //    {
//                //        foreach (var itemL in listaIdsLicenciaturas)
//                //        {
//                //            foreach (var itemE in listaIdsestados)
//                //            {
//                //                foreach (var item in Alumnos)
//                //                {
//                //                    var idLicenciatura = Convert.ToInt64(itemL);
//                //                    Licenciatura = Licenciaturas.FirstOrDefault(x => x.idLicenciatura == idLicenciatura);
//                //                    var idEstado = Convert.ToInt64(itemE);
//                //                    Estado = db.CatEstados.Find(idEstado);
//                //                    var FormacionesA = db.FormacionesAcademicas.Where(x => x.idAlumno == item.idAlumno && x.idLicenciatura == Licenciatura.idLicenciatura).ToList();
//                //                    if (item.Direcciones.nbEstado == Estado.nbEstado && FormacionesA.Count() > 0)
//                //                    {
//                //                        IndicadoresVM IndicadorLE = new IndicadoresVM();
//                //                        IndicadorLE.nbCampo = Licenciatura.nbLicenciatura;
//                //                        IndicadorLE.nbCampo2 = Estado.nbEstado;
//                //                        IndicadorLE.numCampo = 1;
//                //                        IndicadoresLicEdos.Add(IndicadorLE);
//                //                    }
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (listaIdsLicenciaturas.Count() > 0 && listaIdsestados.Count() == 0)
//                //    {
//                //        foreach (var itemL in listaIdsLicenciaturas)
//                //        {
//                //            foreach (var itemE in Estados)
//                //            {
//                //                foreach (var item in Alumnos)
//                //                {
//                //                    var idLicenciatura = Convert.ToInt64(itemL);
//                //                    Licenciatura = Licenciaturas.FirstOrDefault(x => x.idLicenciatura == idLicenciatura);
//                //                    //var idEstado = Convert.ToInt64(itemE);
//                //                    Estado = db.CatEstados.Find(itemE.idEstado);
//                //                    var FormacionesA = db.FormacionesAcademicas.Where(x => x.idAlumno == item.idAlumno && x.idLicenciatura == Licenciatura.idLicenciatura).ToList();
//                //                    if (item.Direcciones.nbEstado == Estado.nbEstado && FormacionesA.Count() > 0)
//                //                    {
//                //                        IndicadoresVM IndicadorLE = new IndicadoresVM();
//                //                        IndicadorLE.nbCampo = Licenciatura.nbLicenciatura;
//                //                        IndicadorLE.nbCampo2 = Estado.nbEstado;
//                //                        IndicadorLE.numCampo = 1;
//                //                        IndicadoresLicEdos.Add(IndicadorLE);
//                //                    }
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (listaIdsLicenciaturas.Count() == 0 && listaIdsestados.Count() > 0)
//                //    {
//                //        foreach (var itemL in Licenciaturas)
//                //        {
//                //            foreach (var itemE in listaIdsestados)
//                //            {
//                //                foreach (var item in Alumnos)
//                //                {
//                //                    //var idLicenciatura = Convert.ToInt64(itemL);
//                //                    Licenciatura = Licenciaturas.FirstOrDefault(x => x.idLicenciatura == itemL.idLicenciatura);
//                //                    var idEstado = Convert.ToInt64(itemE);
//                //                    Estado = db.CatEstados.Find(idEstado);
//                //                    var FormacionesA = db.FormacionesAcademicas.Where(x => x.idAlumno == item.idAlumno && x.idLicenciatura == Licenciatura.idLicenciatura).ToList();
//                //                    if (item.Direcciones.nbEstado == Estado.nbEstado && FormacionesA.Count() > 0)
//                //                    {
//                //                        IndicadoresVM IndicadorLE = new IndicadoresVM();
//                //                        IndicadorLE.nbCampo = Licenciatura.nbLicenciatura;
//                //                        IndicadorLE.nbCampo2 = Estado.nbEstado;
//                //                        IndicadorLE.numCampo = 1;
//                //                        IndicadoresLicEdos.Add(IndicadorLE);
//                //                    }
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (listaIdsLicenciaturas.Count() == 0 && listaIdsestados.Count() == 0)
//                //    {
//                //        foreach (var itemL in Licenciaturas)
//                //        {
//                //            foreach (var itemE in Estados)
//                //            {
//                //                foreach (var item in Alumnos)
//                //                {
//                //                    //var idLicenciatura = Convert.ToInt64(itemL);
//                //                    Licenciatura = Licenciaturas.FirstOrDefault(x => x.idLicenciatura == itemL.idLicenciatura);
//                //                    //var idEstado = Convert.ToInt64(itemE);
//                //                    Estado = db.CatEstados.Find(itemE.idEstado);
//                //                    var FormacionesA = db.FormacionesAcademicas.Where(x => x.idAlumno == item.idAlumno && x.idLicenciatura == Licenciatura.idLicenciatura).ToList();
//                //                    if (item.Direcciones.nbEstado == Estado.nbEstado && FormacionesA.Count() > 0)
//                //                    {
//                //                        IndicadoresVM IndicadorLE = new IndicadoresVM();
//                //                        IndicadorLE.nbCampo = Licenciatura.nbLicenciatura;
//                //                        IndicadorLE.nbCampo2 = Estado.nbEstado;
//                //                        IndicadorLE.numCampo = 1;
//                //                        IndicadoresLicEdos.Add(IndicadorLE);
//                //                    }
//                //                }
//                //            }
//                //        }
//                //    }

//                //    IndicadoresLicEdos.ToList().ForEach(l =>
//                //    {
//                //        var row = dt.NewRow();
//                //        row["nbCategoria"] = l.nbCampo;
//                //        row["nbCategoria2"] = l.nbCampo2;
//                //        row["numDatos"] = l.numCampo;
//                //        dt.Rows.Add(row);
//                //    });
//                //    #endregion
//                //}
//                //else if (listacaCampos[0] == 7 && listacaCampos[1] == 10)
//                //{
//                //    #region

//                //    TituloColumna1 = "Licenciatura";
//                //    TituloColumna2 = "Trabajo";
//                //    TituloColumna3 = "Cantidad";
//                //    TituloGrafic = "Gráfica de barras por Licenciatura y Trabajo";

//                //    Licenciaturas Licenciatura = new Licenciaturas();
//                //    var Licenciaturas = db.Licenciaturas.ToList();

//                //    List<IndicadoresVM> IndicadoresLicTrab = new List<IndicadoresVM>();

//                //    if (listaIdsLicenciaturas.Count() > 0 && Book.fgTrabajaActualmente != null)
//                //    {
//                //        foreach (var itemL in listaIdsLicenciaturas)
//                //        {
//                //            foreach (var item in Alumnos)
//                //            {
//                //                var idLicenciatura = Convert.ToInt64(itemL);
//                //                Licenciatura = Licenciaturas.FirstOrDefault(x => x.idLicenciatura == idLicenciatura);
//                //                var FormacionesA = db.FormacionesAcademicas.Where(x => x.idAlumno == item.idAlumno && x.idLicenciatura == Licenciatura.idLicenciatura).ToList();
//                //                if (item.fgTrabajaActualmente == Book.fgTrabajaActualmente && FormacionesA.Count() > 0)
//                //                {
//                //                    IndicadoresVM IndicadorLT = new IndicadoresVM();
//                //                    IndicadorLT.nbCampo = Licenciatura.nbLicenciatura;
//                //                    IndicadorLT.nbCampo2 = (Book.fgTrabajaActualmente == true) ? "SI" : "NO";
//                //                    IndicadorLT.numCampo = 1;
//                //                    IndicadoresLicTrab.Add(IndicadorLT);
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (listaIdsLicenciaturas.Count() > 0 && Book.fgTrabajaActualmente == null)
//                //    {
//                //        foreach (var itemL in listaIdsLicenciaturas)
//                //        {
//                //            foreach (var item in Alumnos)
//                //            {
//                //                var idLicenciatura = Convert.ToInt64(itemL);
//                //                Licenciatura = Licenciaturas.FirstOrDefault(x => x.idLicenciatura == idLicenciatura);
//                //                var FormacionesA = db.FormacionesAcademicas.Where(x => x.idAlumno == item.idAlumno && x.idLicenciatura == Licenciatura.idLicenciatura).ToList();
//                //                if (item.fgTrabajaActualmente == true && FormacionesA.Count() > 0)
//                //                {
//                //                    IndicadoresVM IndicadorLT = new IndicadoresVM();
//                //                    IndicadorLT.nbCampo = Licenciatura.nbLicenciatura;
//                //                    IndicadorLT.nbCampo2 = "SI";
//                //                    IndicadorLT.numCampo = 1;
//                //                    IndicadoresLicTrab.Add(IndicadorLT);
//                //                }
//                //                else if (item.fgTrabajaActualmente == false && FormacionesA.Count() > 0)
//                //                {
//                //                    IndicadoresVM IndicadorLNT = new IndicadoresVM();
//                //                    IndicadorLNT.nbCampo = Licenciatura.nbLicenciatura;
//                //                    IndicadorLNT.nbCampo2 = "NO";
//                //                    IndicadorLNT.numCampo = 1;
//                //                    IndicadoresLicTrab.Add(IndicadorLNT);
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (listaIdsLicenciaturas.Count() == 0 && Book.fgTrabajaActualmente != null)
//                //    {
//                //        foreach (var itemL in Licenciaturas)
//                //        {
//                //            foreach (var item in Alumnos)
//                //            {
//                //                //var idLicenciatura = Convert.ToInt64(itemL);
//                //                Licenciatura = Licenciaturas.FirstOrDefault(x => x.idLicenciatura == itemL.idLicenciatura);
//                //                var FormacionesA = db.FormacionesAcademicas.Where(x => x.idAlumno == item.idAlumno && x.idLicenciatura == Licenciatura.idLicenciatura).ToList();
//                //                if (item.fgTrabajaActualmente == Book.fgTrabajaActualmente && FormacionesA.Count() > 0)
//                //                {
//                //                    IndicadoresVM IndicadorLT = new IndicadoresVM();
//                //                    IndicadorLT.nbCampo = Licenciatura.nbLicenciatura;
//                //                    IndicadorLT.nbCampo2 = (Book.fgTrabajaActualmente == true) ? "SI" : "NO";
//                //                    IndicadorLT.numCampo = 1;
//                //                    IndicadoresLicTrab.Add(IndicadorLT);
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (listaIdsLicenciaturas.Count() == 0 && Book.fgTrabajaActualmente == null)
//                //    {
//                //        foreach (var itemL in Licenciaturas)
//                //        {
//                //            foreach (var item in Alumnos)
//                //            {
//                //                //var idLicenciatura = Convert.ToInt64(itemL);
//                //                Licenciatura = Licenciaturas.FirstOrDefault(x => x.idLicenciatura == itemL.idLicenciatura);
//                //                var FormacionesA = db.FormacionesAcademicas.Where(x => x.idAlumno == item.idAlumno && x.idLicenciatura == Licenciatura.idLicenciatura).ToList();
//                //                if (item.fgTrabajaActualmente == true && FormacionesA.Count() > 0)
//                //                {
//                //                    IndicadoresVM IndicadorLT = new IndicadoresVM();
//                //                    IndicadorLT.nbCampo = Licenciatura.nbLicenciatura;
//                //                    IndicadorLT.nbCampo2 = "SI";
//                //                    IndicadorLT.numCampo = 1;
//                //                    IndicadoresLicTrab.Add(IndicadorLT);
//                //                }
//                //                else if (item.fgTrabajaActualmente == false && FormacionesA.Count() > 0)
//                //                {
//                //                    IndicadoresVM IndicadorLNT = new IndicadoresVM();
//                //                    IndicadorLNT.nbCampo = Licenciatura.nbLicenciatura;
//                //                    IndicadorLNT.nbCampo2 = "NO";
//                //                    IndicadorLNT.numCampo = 1;
//                //                    IndicadoresLicTrab.Add(IndicadorLNT);
//                //                }
//                //            }
//                //        }
//                //    }

//                //    IndicadoresLicTrab.ToList().ForEach(l =>
//                //    {
//                //        var row = dt.NewRow();
//                //        row["nbCategoria"] = l.nbCampo;
//                //        row["nbCategoria2"] = l.nbCampo2;
//                //        row["numDatos"] = l.numCampo;
//                //        dt.Rows.Add(row);
//                //    });

//                //    #endregion
//                //}
//                //else if (listacaCampos[0] == 7 && listacaCampos[1] == 11)
//                //{
//                //    #region

//                //    TituloColumna1 = "Licenciatura";
//                //    TituloColumna2 = "Tipo de Sangre";
//                //    TituloColumna3 = "Cantidad";
//                //    TituloGrafic = "Gráfica de barras por Licenciatura y Tipo de Sangre";

//                //    Licenciaturas Licenciatura = new Licenciaturas();
//                //    var Licenciaturas = db.Licenciaturas.ToList();
//                //    var CatTiposSangre = db.CatTiposSangre.ToList();
//                //    List<IndicadoresVM> IndicadoresLicSangre = new List<IndicadoresVM>();
//                //    List<Alumnos> AlumnosLic = new List<Alumnos>();

//                //    if (Book.idTipoSangre != null && listaIdsLicenciaturas.Count > 0)
//                //    {
//                //        foreach (var itemL in listaIdsLicenciaturas)
//                //        {
//                //            foreach (var itemA in Alumnos)
//                //            {
//                //                var idLicenciatura = Convert.ToInt64(itemL);
//                //                Licenciatura = Licenciaturas.FirstOrDefault(x => x.idLicenciatura == idLicenciatura);
//                //                var TipoSangre = db.CatTiposSangre.Find(Book.idTipoSangre);
//                //                var FormacionesA = db.FormacionesAcademicas.Where(x => x.idAlumno == itemA.idAlumno && x.idLicenciatura == Licenciatura.idLicenciatura).ToList();
//                //                if (itemA.idTipoSangre == TipoSangre.idTipoSangre && FormacionesA.Count() > 0)
//                //                {
//                //                    IndicadoresVM IndicadorLS = new IndicadoresVM();
//                //                    IndicadorLS.nbCampo = Licenciatura.nbLicenciatura;
//                //                    IndicadorLS.nbCampo2 = TipoSangre.nbTipoSangre.Trim();
//                //                    IndicadorLS.numCampo = 1;
//                //                    IndicadoresLicSangre.Add(IndicadorLS);
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (Book.idTipoSangre == null && listaIdsLicenciaturas.Count > 0)
//                //    {
//                //        foreach (var itemL in listaIdsLicenciaturas)
//                //        {
//                //            foreach (var itemS in CatTiposSangre)
//                //            {
//                //                foreach (var itemA in Alumnos)
//                //                {
//                //                    var idLicenciatura = Convert.ToInt64(itemL);
//                //                    Licenciatura = Licenciaturas.FirstOrDefault(x => x.idLicenciatura == idLicenciatura);
//                //                    var TipoSangre = db.CatTiposSangre.Find(itemS.idTipoSangre);
//                //                    var FormacionesA = db.FormacionesAcademicas.Where(x => x.idAlumno == itemA.idAlumno && x.idLicenciatura == Licenciatura.idLicenciatura).ToList();
//                //                    if (itemA.idTipoSangre == TipoSangre.idTipoSangre && FormacionesA.Count() > 0)
//                //                    {
//                //                        IndicadoresVM IndicadorLS = new IndicadoresVM();
//                //                        IndicadorLS.nbCampo = Licenciatura.nbLicenciatura;
//                //                        IndicadorLS.nbCampo2 = TipoSangre.nbTipoSangre.Trim();
//                //                        IndicadorLS.numCampo = 1;
//                //                        IndicadoresLicSangre.Add(IndicadorLS);
//                //                    }
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (Book.idEstadoCivil == null && listaIdsLicenciaturas.Count == 0)
//                //    {
//                //        foreach (var itemL in Licenciaturas)
//                //        {
//                //            foreach (var itemS in CatTiposSangre)
//                //            {
//                //                foreach (var itemA in Alumnos)
//                //                {
//                //                    //var idLicenciatura = Convert.ToInt64(itemL);
//                //                    Licenciatura = Licenciaturas.FirstOrDefault(x => x.idLicenciatura == itemL.idLicenciatura);
//                //                    var TipoSangre = db.CatTiposSangre.Find(itemS.idTipoSangre);
//                //                    var FormacionesA = db.FormacionesAcademicas.Where(x => x.idAlumno == itemA.idAlumno && x.idLicenciatura == Licenciatura.idLicenciatura).ToList();
//                //                    if (itemA.idTipoSangre == TipoSangre.idTipoSangre && FormacionesA.Count() > 0)
//                //                    {
//                //                        IndicadoresVM IndicadorLS = new IndicadoresVM();
//                //                        IndicadorLS.nbCampo = Licenciatura.nbLicenciatura;
//                //                        IndicadorLS.nbCampo2 = TipoSangre.nbTipoSangre.Trim();
//                //                        IndicadorLS.numCampo = 1;
//                //                        IndicadoresLicSangre.Add(IndicadorLS);
//                //                    }
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (Book.idTipoSangre != null && listaIdsLicenciaturas.Count == 0)
//                //    {
//                //        foreach (var itemL in Licenciaturas)
//                //        {
//                //            foreach (var itemA in Alumnos)
//                //            {
//                //                //var idLicenciatura = Convert.ToInt64(itemL);
//                //                Licenciatura = Licenciaturas.FirstOrDefault(x => x.idLicenciatura == itemL.idLicenciatura);
//                //                var TipoSangre = db.CatTiposSangre.Find(Book.idTipoSangre);
//                //                var FormacionesA = db.FormacionesAcademicas.Where(x => x.idAlumno == itemA.idAlumno && x.idLicenciatura == Licenciatura.idLicenciatura).ToList();
//                //                if (itemA.idTipoSangre == TipoSangre.idTipoSangre && FormacionesA.Count() > 0)
//                //                {
//                //                    IndicadoresVM IndicadorLS = new IndicadoresVM();
//                //                    IndicadorLS.nbCampo = Licenciatura.nbLicenciatura;
//                //                    IndicadorLS.nbCampo2 = TipoSangre.nbTipoSangre.Trim();
//                //                    IndicadorLS.numCampo = 1;
//                //                    IndicadoresLicSangre.Add(IndicadorLS);
//                //                }
//                //            }
//                //        }
//                //    }

//                //    IndicadoresLicSangre.ToList().ForEach(l =>
//                //    {
//                //        var row = dt.NewRow();
//                //        row["nbCategoria"] = l.nbCampo;
//                //        row["nbCategoria2"] = l.nbCampo2;
//                //        row["numDatos"] = l.numCampo;
//                //        dt.Rows.Add(row);
//                //    });

//                //    #endregion
//                //}
//                //else if (listacaCampos[0] == 7 && listacaCampos[1] == 12)
//                //{
//                //    #region

//                //    TituloColumna1 = "Licenciatura";
//                //    TituloColumna2 = "Licencia";
//                //    TituloColumna3 = "Cantidad";
//                //    TituloGrafic = "Gráfica de barras por Licenciatura y Licencia";

//                //    Licenciaturas Licenciatura = new Licenciaturas();
//                //    var Licenciaturas = db.Licenciaturas.ToList();

//                //    List<IndicadoresVM> IndicadoresLicLicencia = new List<IndicadoresVM>();

//                //    if (listaIdsLicenciaturas.Count() > 0 && Book.fgLicencia != null)
//                //    {
//                //        foreach (var itemL in listaIdsLicenciaturas)
//                //        {
//                //            foreach (var item in Alumnos)
//                //            {
//                //                var idLicenciatura = Convert.ToInt64(itemL);
//                //                Licenciatura = Licenciaturas.FirstOrDefault(x => x.idLicenciatura == idLicenciatura);
//                //                var FormacionesA = db.FormacionesAcademicas.Where(x => x.idAlumno == item.idAlumno && x.idLicenciatura == Licenciatura.idLicenciatura).ToList();
//                //                if (item.fgLicencia == Book.fgLicencia && FormacionesA.Count() > 0)
//                //                {
//                //                    IndicadoresVM IndicadorLT = new IndicadoresVM();
//                //                    IndicadorLT.nbCampo = Licenciatura.nbLicenciatura;
//                //                    IndicadorLT.nbCampo2 = (Book.fgLicencia == true) ? "SI" : "NO";
//                //                    IndicadorLT.numCampo = 1;
//                //                    IndicadoresLicLicencia.Add(IndicadorLT);
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (listaIdsLicenciaturas.Count() > 0 && Book.fgLicencia == null)
//                //    {
//                //        foreach (var itemL in listaIdsLicenciaturas)
//                //        {
//                //            foreach (var item in Alumnos)
//                //            {
//                //                var idLicenciatura = Convert.ToInt64(itemL);
//                //                Licenciatura = Licenciaturas.FirstOrDefault(x => x.idLicenciatura == idLicenciatura);
//                //                var FormacionesA = db.FormacionesAcademicas.Where(x => x.idAlumno == item.idAlumno && x.idLicenciatura == Licenciatura.idLicenciatura).ToList();
//                //                if (item.fgLicencia == true && FormacionesA.Count() > 0)
//                //                {
//                //                    IndicadoresVM IndicadorLL = new IndicadoresVM();
//                //                    IndicadorLL.nbCampo = Licenciatura.nbLicenciatura;
//                //                    IndicadorLL.nbCampo2 = "SI";
//                //                    IndicadorLL.numCampo = 1;
//                //                    IndicadoresLicLicencia.Add(IndicadorLL);
//                //                }
//                //                else if (item.fgLicencia == false && FormacionesA.Count() > 0)
//                //                {
//                //                    IndicadoresVM IndicadorLNL = new IndicadoresVM();
//                //                    IndicadorLNL.nbCampo = Licenciatura.nbLicenciatura;
//                //                    IndicadorLNL.nbCampo2 = "NO";
//                //                    IndicadorLNL.numCampo = 1;
//                //                    IndicadoresLicLicencia.Add(IndicadorLNL);
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (listaIdsLicenciaturas.Count() == 0 && Book.fgLicencia != null)
//                //    {
//                //        foreach (var itemL in Licenciaturas)
//                //        {
//                //            foreach (var item in Alumnos)
//                //            {
//                //                //var idLicenciatura = Convert.ToInt64(itemL);
//                //                Licenciatura = Licenciaturas.FirstOrDefault(x => x.idLicenciatura == itemL.idLicenciatura);
//                //                var FormacionesA = db.FormacionesAcademicas.Where(x => x.idAlumno == item.idAlumno && x.idLicenciatura == Licenciatura.idLicenciatura).ToList();
//                //                if (item.fgLicencia == Book.fgLicencia && FormacionesA.Count() > 0)
//                //                {
//                //                    IndicadoresVM IndicadorLT = new IndicadoresVM();
//                //                    IndicadorLT.nbCampo = Licenciatura.nbLicenciatura;
//                //                    IndicadorLT.nbCampo2 = (Book.fgLicencia == true) ? "SI" : "NO";
//                //                    IndicadorLT.numCampo = 1;
//                //                    IndicadoresLicLicencia.Add(IndicadorLT);
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (listaIdsLicenciaturas.Count() == 0 && Book.fgLicencia == null)
//                //    {
//                //        foreach (var itemL in Licenciaturas)
//                //        {
//                //            foreach (var item in Alumnos)
//                //            {
//                //                //var idLicenciatura = Convert.ToInt64(itemL);
//                //                Licenciatura = Licenciaturas.FirstOrDefault(x => x.idLicenciatura == itemL.idLicenciatura);
//                //                var FormacionesA = db.FormacionesAcademicas.Where(x => x.idAlumno == item.idAlumno && x.idLicenciatura == Licenciatura.idLicenciatura).ToList();
//                //                if (item.fgLicencia == true && FormacionesA.Count() > 0)
//                //                {
//                //                    IndicadoresVM IndicadorLL = new IndicadoresVM();
//                //                    IndicadorLL.nbCampo = Licenciatura.nbLicenciatura;
//                //                    IndicadorLL.nbCampo2 = "SI";
//                //                    IndicadorLL.numCampo = 1;
//                //                    IndicadoresLicLicencia.Add(IndicadorLL);
//                //                }
//                //                else if (item.fgLicencia == false && FormacionesA.Count() > 0)
//                //                {
//                //                    IndicadoresVM IndicadorLNL = new IndicadoresVM();
//                //                    IndicadorLNL.nbCampo = Licenciatura.nbLicenciatura;
//                //                    IndicadorLNL.nbCampo2 = "NO";
//                //                    IndicadorLNL.numCampo = 1;
//                //                    IndicadoresLicLicencia.Add(IndicadorLNL);
//                //                }
//                //            }
//                //        }
//                //    }

//                //    IndicadoresLicLicencia.ToList().ForEach(l =>
//                //    {
//                //        var row = dt.NewRow();
//                //        row["nbCategoria"] = l.nbCampo;
//                //        row["nbCategoria2"] = l.nbCampo2;
//                //        row["numDatos"] = l.numCampo;
//                //        dt.Rows.Add(row);
//                //    });

//                //    #endregion
//                //}
//                //else if (listacaCampos[0] == 7 && listacaCampos[1] == 13)
//                //{
//                //    #region

//                //    TituloColumna1 = "Licenciatura";
//                //    TituloColumna2 = "Tipo de Egresado";
//                //    TituloColumna3 = "Cantidad";
//                //    TituloGrafic = "Gráfica de barras por Licenciatura y Tipo de Egresado";

//                //    Licenciaturas Licenciatura = new Licenciaturas();
//                //    var Licenciaturas = db.Licenciaturas.ToList();

//                //    List<IndicadoresVM> IndicadoresLicEgresado = new List<IndicadoresVM>();

//                //    if (listaIdsLicenciaturas.Count() > 0 && Book.tpEgresado != null)
//                //    {
//                //        foreach (var itemL in listaIdsLicenciaturas)
//                //        {
//                //            foreach (var item in Alumnos)
//                //            {
//                //                var idLicenciatura = Convert.ToInt64(itemL);
//                //                Licenciatura = Licenciaturas.FirstOrDefault(x => x.idLicenciatura == idLicenciatura);
//                //                var FormacionesA = db.FormacionesAcademicas.Where(x => x.idAlumno == item.idAlumno && x.idLicenciatura == Licenciatura.idLicenciatura).ToList();
//                //                if (item.tpEgresado == Book.tpEgresado && FormacionesA.Count() > 0)
//                //                {
//                //                    IndicadoresVM IndicadorLE = new IndicadoresVM();
//                //                    IndicadorLE.nbCampo = Licenciatura.nbLicenciatura;
//                //                    IndicadorLE.nbCampo2 = (Book.tpEgresado == "T") ? "Titulado" : "Pasante";
//                //                    IndicadorLE.numCampo = 1;
//                //                    IndicadoresLicEgresado.Add(IndicadorLE);
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (listaIdsLicenciaturas.Count() > 0 && Book.tpEgresado == null)
//                //    {
//                //        foreach (var itemL in listaIdsLicenciaturas)
//                //        {
//                //            foreach (var item in Alumnos)
//                //            {
//                //                var idLicenciatura = Convert.ToInt64(itemL);
//                //                Licenciatura = Licenciaturas.FirstOrDefault(x => x.idLicenciatura == idLicenciatura);
//                //                var FormacionesA = db.FormacionesAcademicas.Where(x => x.idAlumno == item.idAlumno && x.idLicenciatura == Licenciatura.idLicenciatura).ToList();
//                //                if (item.tpEgresado == "T" && FormacionesA.Count() > 0)
//                //                {
//                //                    IndicadoresVM IndicadorLE = new IndicadoresVM();
//                //                    IndicadorLE.nbCampo = Licenciatura.nbLicenciatura;
//                //                    IndicadorLE.nbCampo2 = "Titulado";
//                //                    IndicadorLE.numCampo = 1;
//                //                    IndicadoresLicEgresado.Add(IndicadorLE);
//                //                }
//                //                else if (item.tpEgresado == "P" && FormacionesA.Count() > 0)
//                //                {
//                //                    IndicadoresVM IndicadorLNE = new IndicadoresVM();
//                //                    IndicadorLNE.nbCampo = Licenciatura.nbLicenciatura;
//                //                    IndicadorLNE.nbCampo2 = "Pasante";
//                //                    IndicadorLNE.numCampo = 1;
//                //                    IndicadoresLicEgresado.Add(IndicadorLNE);
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (listaIdsLicenciaturas.Count() == 0 && Book.tpEgresado != null)
//                //    {
//                //        foreach (var itemL in Licenciaturas)
//                //        {
//                //            foreach (var item in Alumnos)
//                //            {
//                //                //var idLicenciatura = Convert.ToInt64(itemL);
//                //                Licenciatura = Licenciaturas.FirstOrDefault(x => x.idLicenciatura == itemL.idLicenciatura);
//                //                var FormacionesA = db.FormacionesAcademicas.Where(x => x.idAlumno == item.idAlumno && x.idLicenciatura == Licenciatura.idLicenciatura).ToList();
//                //                if (item.tpEgresado == Book.tpEgresado && FormacionesA.Count() > 0)
//                //                {
//                //                    IndicadoresVM IndicadorLE = new IndicadoresVM();
//                //                    IndicadorLE.nbCampo = Licenciatura.nbLicenciatura;
//                //                    IndicadorLE.nbCampo2 = (Book.tpEgresado == "T") ? "Titulado" : "Pasante";
//                //                    IndicadorLE.numCampo = 1;
//                //                    IndicadoresLicEgresado.Add(IndicadorLE);
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (listaIdsLicenciaturas.Count() == 0 && Book.tpEgresado == null)
//                //    {
//                //        foreach (var itemL in Licenciaturas)
//                //        {
//                //            foreach (var item in Alumnos)
//                //            {
//                //                //var idLicenciatura = Convert.ToInt64(itemL);
//                //                Licenciatura = Licenciaturas.FirstOrDefault(x => x.idLicenciatura == itemL.idLicenciatura);
//                //                var FormacionesA = db.FormacionesAcademicas.Where(x => x.idAlumno == item.idAlumno && x.idLicenciatura == Licenciatura.idLicenciatura).ToList();
//                //                if (item.tpEgresado == "T" && FormacionesA.Count() > 0)
//                //                {
//                //                    IndicadoresVM IndicadorLE = new IndicadoresVM();
//                //                    IndicadorLE.nbCampo = Licenciatura.nbLicenciatura;
//                //                    IndicadorLE.nbCampo2 = "Titulado";
//                //                    IndicadorLE.numCampo = 1;
//                //                    IndicadoresLicEgresado.Add(IndicadorLE);
//                //                }
//                //                else if (item.tpEgresado == "P" && FormacionesA.Count() > 0)
//                //                {
//                //                    IndicadoresVM IndicadorLNE = new IndicadoresVM();
//                //                    IndicadorLNE.nbCampo = Licenciatura.nbLicenciatura;
//                //                    IndicadorLNE.nbCampo2 = "Pasante";
//                //                    IndicadorLNE.numCampo = 1;
//                //                    IndicadoresLicEgresado.Add(IndicadorLNE);
//                //                }
//                //            }
//                //        }
//                //    }

//                //    IndicadoresLicEgresado.ToList().ForEach(l =>
//                //    {
//                //        var row = dt.NewRow();
//                //        row["nbCategoria"] = l.nbCampo;
//                //        row["nbCategoria2"] = l.nbCampo2;
//                //        row["numDatos"] = l.numCampo;
//                //        dt.Rows.Add(row);
//                //    });

//                //    #endregion
//                //}
//                //else if (listacaCampos[0] == 7 && listacaCampos[1] == 14)
//                //{
//                //    #region

//                //    TituloColumna1 = "Licenciatura";
//                //    TituloColumna2 = "Fallecimiento";
//                //    TituloColumna3 = "Cantidad";
//                //    TituloGrafic = "Gráfica de barras por Licenciatura y Fallecimiento";

//                //    Licenciaturas Licenciatura = new Licenciaturas();
//                //    var Licenciaturas = db.Licenciaturas.ToList();

//                //    List<IndicadoresVM> IndicadoresLicFallecido = new List<IndicadoresVM>();

//                //    if (listaIdsLicenciaturas.Count() > 0 && Book.fgFallecido != null)
//                //    {
//                //        foreach (var itemL in listaIdsLicenciaturas)
//                //        {
//                //            foreach (var item in Alumnos)
//                //            {
//                //                var idLicenciatura = Convert.ToInt64(itemL);
//                //                Licenciatura = Licenciaturas.FirstOrDefault(x => x.idLicenciatura == idLicenciatura);
//                //                var FormacionesA = db.FormacionesAcademicas.Where(x => x.idAlumno == item.idAlumno && x.idLicenciatura == Licenciatura.idLicenciatura).ToList();
//                //                if (item.fgFallecido == Book.fgFallecido && FormacionesA.Count() > 0)
//                //                {
//                //                    IndicadoresVM IndicadorLF = new IndicadoresVM();
//                //                    IndicadorLF.nbCampo = Licenciatura.nbLicenciatura;
//                //                    IndicadorLF.nbCampo2 = (Book.fgFallecido == true) ? "SI" : "NO";
//                //                    IndicadorLF.numCampo = 1;
//                //                    IndicadoresLicFallecido.Add(IndicadorLF);
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (listaIdsLicenciaturas.Count() > 0 && Book.fgFallecido == null)
//                //    {
//                //        foreach (var itemL in listaIdsLicenciaturas)
//                //        {
//                //            foreach (var item in Alumnos)
//                //            {
//                //                var idLicenciatura = Convert.ToInt64(itemL);
//                //                Licenciatura = Licenciaturas.FirstOrDefault(x => x.idLicenciatura == idLicenciatura);
//                //                var FormacionesA = db.FormacionesAcademicas.Where(x => x.idAlumno == item.idAlumno && x.idLicenciatura == Licenciatura.idLicenciatura).ToList();
//                //                if (item.fgFallecido == true && FormacionesA.Count() > 0)
//                //                {
//                //                    IndicadoresVM IndicadorLF = new IndicadoresVM();
//                //                    IndicadorLF.nbCampo = Licenciatura.nbLicenciatura;
//                //                    IndicadorLF.nbCampo2 = "SI";
//                //                    IndicadorLF.numCampo = 1;
//                //                    IndicadoresLicFallecido.Add(IndicadorLF);
//                //                }
//                //                else if (item.fgFallecido == false && FormacionesA.Count() > 0)
//                //                {
//                //                    IndicadoresVM IndicadorLNF = new IndicadoresVM();
//                //                    IndicadorLNF.nbCampo = Licenciatura.nbLicenciatura;
//                //                    IndicadorLNF.nbCampo2 = "NO";
//                //                    IndicadorLNF.numCampo = 1;
//                //                    IndicadoresLicFallecido.Add(IndicadorLNF);
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (listaIdsLicenciaturas.Count() == 0 && Book.fgFallecido != null)
//                //    {
//                //        foreach (var itemL in Licenciaturas)
//                //        {
//                //            foreach (var item in Alumnos)
//                //            {
//                //                //var idLicenciatura = Convert.ToInt64(itemL);
//                //                Licenciatura = Licenciaturas.FirstOrDefault(x => x.idLicenciatura == itemL.idLicenciatura);
//                //                var FormacionesA = db.FormacionesAcademicas.Where(x => x.idAlumno == item.idAlumno && x.idLicenciatura == Licenciatura.idLicenciatura).ToList();
//                //                if (item.fgFallecido == Book.fgFallecido && FormacionesA.Count() > 0)
//                //                {
//                //                    IndicadoresVM IndicadorLF = new IndicadoresVM();
//                //                    IndicadorLF.nbCampo = Licenciatura.nbLicenciatura;
//                //                    IndicadorLF.nbCampo2 = (Book.fgFallecido == true) ? "SI" : "NO";
//                //                    IndicadorLF.numCampo = 1;
//                //                    IndicadoresLicFallecido.Add(IndicadorLF);
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (listaIdsLicenciaturas.Count() == 0 && Book.fgFallecido == null)
//                //    {
//                //        foreach (var itemL in Licenciaturas)
//                //        {
//                //            foreach (var item in Alumnos)
//                //            {
//                //                //var idLicenciatura = Convert.ToInt64(itemL);
//                //                Licenciatura = Licenciaturas.FirstOrDefault(x => x.idLicenciatura == itemL.idLicenciatura);
//                //                var FormacionesA = db.FormacionesAcademicas.Where(x => x.idAlumno == item.idAlumno && x.idLicenciatura == Licenciatura.idLicenciatura).ToList();
//                //                if (item.fgFallecido == true && FormacionesA.Count() > 0)
//                //                {
//                //                    IndicadoresVM IndicadorLF = new IndicadoresVM();
//                //                    IndicadorLF.nbCampo = Licenciatura.nbLicenciatura;
//                //                    IndicadorLF.nbCampo2 = "SI";
//                //                    IndicadorLF.numCampo = 1;
//                //                    IndicadoresLicFallecido.Add(IndicadorLF);
//                //                }
//                //                else if (item.fgFallecido == false && FormacionesA.Count() > 0)
//                //                {
//                //                    IndicadoresVM IndicadorLNF = new IndicadoresVM();
//                //                    IndicadorLNF.nbCampo = Licenciatura.nbLicenciatura;
//                //                    IndicadorLNF.nbCampo2 = "NO";
//                //                    IndicadorLNF.numCampo = 1;
//                //                    IndicadoresLicFallecido.Add(IndicadorLNF);
//                //                }
//                //            }
//                //        }
//                //    }

//                //    IndicadoresLicFallecido.ToList().ForEach(l =>
//                //    {
//                //        var row = dt.NewRow();
//                //        row["nbCategoria"] = l.nbCampo;
//                //        row["nbCategoria2"] = l.nbCampo2;
//                //        row["numDatos"] = l.numCampo;
//                //        dt.Rows.Add(row);
//                //    });

//                //    #endregion
//                //}
//                //else if (listacaCampos[0] == 8 && listacaCampos[1] == 2)
//                //{
//                //    #region

//                //    TituloColumna1 = "Religión";
//                //    TituloColumna2 = "Estado Civil";
//                //    TituloColumna3 = "Cantidad";
//                //    TituloGrafic = "Gráfica de barras por Religión y Estado Civil";

//                //    CatReligion Religion = new CatReligion();
//                //    var Religiones = db.CatReligion.ToList();
//                //    var CatEstadosCiviles = db.CatEstadosCiviles.ToList();
//                //    List<IndicadoresVM> IndicadoresECR = new List<IndicadoresVM>();

//                //    if (Book.idEstadoCivil != null && listaIdsReligiones.Count > 0)
//                //    {
//                //        foreach (var item in listaIdsReligiones)
//                //        {
//                //            var idReligion = Convert.ToInt64(item);
//                //            Religion = Religiones.FirstOrDefault(x => x.idReligion == idReligion);
//                //            var EstadoCivil = db.CatEstadosCiviles.Find(Book.idEstadoCivil);
//                //            foreach (var itemA in Alumnos)
//                //            {
//                //                if (itemA.idEstadoCivil == Book.idEstadoCivil && itemA.idReligion == Religion.idReligion)
//                //                {
//                //                    IndicadoresVM IndicadorECR = new IndicadoresVM();
//                //                    IndicadorECR.nbCampo = Religion.nbReligion;
//                //                    IndicadorECR.nbCampo2 = EstadoCivil.nbEstadoCivil.Trim();
//                //                    IndicadorECR.numCampo = 1;
//                //                    IndicadoresECR.Add(IndicadorECR);
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (Book.idEstadoCivil == null && listaIdsReligiones.Count > 0)
//                //    {
//                //        foreach (var item in listaIdsLicenciaturas)
//                //        {
//                //            var idReligion = Convert.ToInt64(item);
//                //            Religion = Religiones.FirstOrDefault(x => x.idReligion == idReligion);
//                //            foreach (var itemEC in CatEstadosCiviles)
//                //            {
//                //                foreach (var itemA in Alumnos)
//                //                {
//                //                    if (itemA.idEstadoCivil == itemEC.idEstadoCivil && itemA.idReligion == Religion.idReligion)
//                //                    {
//                //                        IndicadoresVM IndicadorECR = new IndicadoresVM();
//                //                        IndicadorECR.nbCampo = Religion.nbReligion;
//                //                        IndicadorECR.nbCampo2 = itemEC.nbEstadoCivil.Trim();
//                //                        IndicadorECR.numCampo = 1;
//                //                        IndicadoresECR.Add(IndicadorECR);
//                //                    }
//                //                }
//                //                //var AlumnosECR = Alumnos.Where(x => x.idEstadoCivil == itemEC.idEstadoCivil && x.idReligion == Religion.idReligion).ToList();
//                //                //var EstadoCivil = db.CatEstadosCiviles.Find(Book.idEstadoCivil); 
//                //            }
//                //        }
//                //    }
//                //    else if (Book.idEstadoCivil == null && listaIdsReligiones.Count == 0)
//                //    {
//                //        foreach (var item in Religiones)
//                //        {
//                //            foreach (var itemEC in CatEstadosCiviles)
//                //            {
//                //                foreach (var itemA in Alumnos)
//                //                {
//                //                    Religion = Religiones.FirstOrDefault(x => x.idReligion == item.idReligion);
//                //                    if (itemA.idEstadoCivil == itemEC.idEstadoCivil && itemA.idReligion == Religion.idReligion)
//                //                    {
//                //                        IndicadoresVM IndicadorECR = new IndicadoresVM();
//                //                        IndicadorECR.nbCampo = Religion.nbReligion;
//                //                        IndicadorECR.nbCampo2 = itemEC.nbEstadoCivil.Trim();
//                //                        IndicadorECR.numCampo = 1;
//                //                        IndicadoresECR.Add(IndicadorECR);
//                //                    }
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (Book.idEstadoCivil != null && listaIdsReligiones.Count == 0)
//                //    {
//                //        foreach (var item in Religiones)
//                //        {
//                //            //var idReligion = Convert.ToInt64(item);
//                //            Religion = Religiones.FirstOrDefault(x => x.idReligion == item.idReligion);
//                //            var EstadoCivil = db.CatEstadosCiviles.Find(Book.idEstadoCivil);
//                //            foreach (var itemA in Alumnos)
//                //            {
//                //                if (itemA.idEstadoCivil == Book.idEstadoCivil && itemA.idReligion == Religion.idReligion)
//                //                {
//                //                    IndicadoresVM IndicadorECR = new IndicadoresVM();
//                //                    IndicadorECR.nbCampo = Religion.nbReligion;
//                //                    IndicadorECR.nbCampo2 = EstadoCivil.nbEstadoCivil.Trim();
//                //                    IndicadorECR.numCampo = 1;
//                //                    IndicadoresECR.Add(IndicadorECR);
//                //                }
//                //            }
//                //        }
//                //    }

//                //    IndicadoresECR.ToList().ForEach(l =>
//                //    {
//                //        var row = dt.NewRow();
//                //        row["nbCategoria"] = l.nbCampo;
//                //        row["nbCategoria2"] = l.nbCampo2;
//                //        row["numDatos"] = l.numCampo;
//                //        dt.Rows.Add(row);
//                //    });

//                //    #endregion
//                //}
//                //else if (listacaCampos[0] == 8 && listacaCampos[1] == 3)
//                //{
//                //    #region

//                //    TituloColumna1 = "Religión";
//                //    TituloColumna2 = "Edad";
//                //    TituloColumna3 = "Cantidad";
//                //    TituloGrafic = "Gráfica de barras por Religión y Edad";
//                //    CatReligion Religion = new CatReligion();
//                //    var Religiones = db.CatReligion.ToList();
//                //    List<IndicadoresVM> ListaEdadReligion = new List<IndicadoresVM>();

//                //    if (Book.numEdadMinima != null && Book.numEdadMinima != null && listaIdsReligiones.Count() > 0)
//                //    {
//                //        for (var i = Book.numEdadMinima; i <= Book.numEdadMaxima; i++)
//                //        {
//                //            foreach (var itemR in listaIdsReligiones)
//                //            {
//                //                foreach (var item in Alumnos)
//                //                {
//                //                    var idReligion = Convert.ToInt64(itemR);
//                //                    Religion = Religiones.FirstOrDefault(x => x.idReligion == idReligion);
//                //                    var edad = DateTime.Now.Year - ((DateTime)item.feNacimiento).Date.Year;
//                //                    if (edad == i && item.idReligion == Religion.idReligion)
//                //                    {
//                //                        IndicadoresVM IndicadorEdadR = new IndicadoresVM();
//                //                        IndicadorEdadR.nbCampo = Religion.nbReligion.Trim();
//                //                        IndicadorEdadR.nbCampo2 = i + " Años";
//                //                        IndicadorEdadR.numCampo = 1;
//                //                        ListaEdadReligion.Add(IndicadorEdadR);
//                //                    }
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (Book.numEdadMinima != null && Book.numEdadMinima != null && listaIdsReligiones.Count() == 0)
//                //    {
//                //        for (var i = Book.numEdadMinima; i <= Book.numEdadMaxima; i++)
//                //        {
//                //            foreach (var itemR in Religiones)
//                //            {
//                //                foreach (var item in Alumnos)
//                //                {
//                //                    //var idReligion = Convert.ToInt64(itemR);
//                //                    //Religion = Religiones.FirstOrDefault(x => x.idReligion == idReligion);
//                //                    var edad = DateTime.Now.Year - ((DateTime)item.feNacimiento).Date.Year;
//                //                    if (edad == i && item.idReligion == itemR.idReligion)
//                //                    {
//                //                        IndicadoresVM IndicadorEdadR = new IndicadoresVM();
//                //                        IndicadorEdadR.nbCampo = itemR.nbReligion.Trim();
//                //                        IndicadorEdadR.nbCampo2 = i + " Años";
//                //                        IndicadorEdadR.numCampo = 1;
//                //                        ListaEdadReligion.Add(IndicadorEdadR);
//                //                    }
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (Book.numEdadMinima == null && Book.numEdadMinima == null && listaIdsReligiones.Count() > 0)
//                //    {
//                //        for (var i = 15; i <= 80; i++)
//                //        {
//                //            foreach (var itemR in listaIdsReligiones)
//                //            {
//                //                foreach (var item in Alumnos)
//                //                {
//                //                    var idReligion = Convert.ToInt64(itemR);
//                //                    Religion = Religiones.FirstOrDefault(x => x.idReligion == idReligion);
//                //                    var edad = DateTime.Now.Year - ((DateTime)item.feNacimiento).Date.Year;
//                //                    if (edad == i && item.idReligion == Religion.idReligion)
//                //                    {
//                //                        IndicadoresVM IndicadorEdadR = new IndicadoresVM();
//                //                        IndicadorEdadR.nbCampo = Religion.nbReligion.Trim();
//                //                        IndicadorEdadR.nbCampo2 = i + " Años";
//                //                        IndicadorEdadR.numCampo = 1;
//                //                        ListaEdadReligion.Add(IndicadorEdadR);
//                //                    }
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (Book.numEdadMinima == null && Book.numEdadMinima == null && listaIdsReligiones.Count() == 0)
//                //    {
//                //        for (var i = 15; i <= 80; i++)
//                //        {
//                //            foreach (var itemR in Religiones)
//                //            {
//                //                foreach (var item in Alumnos)
//                //                {
//                //                    //var idReligion = Convert.ToInt64(itemR);
//                //                    //Religion = Religiones.FirstOrDefault(x => x.idReligion == idReligion);
//                //                    var edad = DateTime.Now.Year - ((DateTime)item.feNacimiento).Date.Year;
//                //                    if (edad == i && item.idReligion == itemR.idReligion)
//                //                    {
//                //                        IndicadoresVM IndicadorEdadR = new IndicadoresVM();
//                //                        IndicadorEdadR.nbCampo = itemR.nbReligion.Trim();
//                //                        IndicadorEdadR.nbCampo2 = i + " Años";
//                //                        IndicadorEdadR.numCampo = 1;
//                //                        ListaEdadReligion.Add(IndicadorEdadR);
//                //                    }
//                //                }
//                //            }
//                //        }
//                //    }

//                //    ListaEdadReligion.ToList().ForEach(t =>
//                //    {
//                //        var row = dt.NewRow();
//                //        row["nbCategoria"] = t.nbCampo;
//                //        row["nbCategoria2"] = t.nbCampo2;
//                //        row["numDatos"] = t.numCampo;
//                //        dt.Rows.Add(row);
//                //    });

//                //    #endregion
//                //}
//                //else if (listacaCampos[0] == 8 && listacaCampos[1] == 6)
//                //{
//                //    #region

//                //    TituloColumna1 = "Religión";
//                //    TituloColumna2 = "Género";
//                //    TituloColumna3 = "Cantidad";
//                //    TituloGrafic = "Gráfica de barras por Religión y Género";

//                //    var CatGeneros = db.CatGeneros.ToList();
//                //    CatReligion Religion = new CatReligion();
//                //    var Religiones = db.CatReligion.ToList();
//                //    List<IndicadoresVM> IndicadoresGR = new List<IndicadoresVM>();
//                //    List<Alumnos> AlumnosLic = new List<Alumnos>();

//                //    if (Book.idGenero != null && listaIdsReligiones.Count > 0)
//                //    {
//                //        foreach (var item in listaIdsReligiones)
//                //        {
//                //            foreach (var itemA in Alumnos)
//                //            {
//                //                var idReligion = Convert.ToInt64(item);
//                //                Religion = Religiones.FirstOrDefault(x => x.idReligion == idReligion);
//                //                var Genero = db.CatGeneros.Find(Book.idGenero);
//                //                if (itemA.Personas.idGenero == Book.idGenero && itemA.idReligion == Religion.idReligion)
//                //                {
//                //                    IndicadoresVM IndicadorGR = new IndicadoresVM();
//                //                    IndicadorGR.nbCampo = Religion.nbReligion;
//                //                    IndicadorGR.nbCampo2 = Genero.nbGenero.Trim();
//                //                    IndicadorGR.numCampo = 1;
//                //                    IndicadoresGR.Add(IndicadorGR);
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (Book.idGenero == null && listaIdsReligiones.Count > 0)
//                //    {
//                //        foreach (var item in listaIdsReligiones)
//                //        {
//                //            foreach (var itemG in CatGeneros)
//                //            {
//                //                foreach (var itemA in Alumnos)
//                //                {
//                //                    var idReligion = Convert.ToInt64(item);
//                //                    Religion = Religiones.FirstOrDefault(x => x.idReligion == idReligion);
//                //                    var Genero = db.CatGeneros.Find(itemG.idGenero);
//                //                    if (itemA.Personas.idGenero == Genero.idGenero && itemA.idReligion == Religion.idReligion)
//                //                    {
//                //                        IndicadoresVM IndicadorGR = new IndicadoresVM();
//                //                        IndicadorGR.nbCampo = Religion.nbReligion;
//                //                        IndicadorGR.nbCampo2 = Genero.nbGenero.Trim();
//                //                        IndicadorGR.numCampo = 1;
//                //                        IndicadoresGR.Add(IndicadorGR);
//                //                    }
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (Book.idGenero == null && listaIdsReligiones.Count == 0)
//                //    {
//                //        foreach (var item in Religiones)
//                //        {
//                //            foreach (var itemG in CatGeneros)
//                //            {
//                //                foreach (var itemA in Alumnos)
//                //                {
//                //                    //var idReligion = Convert.ToInt64(item);
//                //                    Religion = Religiones.FirstOrDefault(x => x.idReligion == item.idReligion);
//                //                    var Genero = db.CatGeneros.Find(itemG.idGenero);
//                //                    if (itemA.Personas.idGenero == Genero.idGenero && itemA.idReligion == Religion.idReligion)
//                //                    {
//                //                        IndicadoresVM IndicadorGR = new IndicadoresVM();
//                //                        IndicadorGR.nbCampo = Religion.nbReligion;
//                //                        IndicadorGR.nbCampo2 = Genero.nbGenero.Trim();
//                //                        IndicadorGR.numCampo = 1;
//                //                        IndicadoresGR.Add(IndicadorGR);
//                //                    }
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (Book.idGenero != null && listaIdsLicenciaturas.Count == 0)
//                //    {
//                //        foreach (var item in Religiones)
//                //        {
//                //            foreach (var itemA in Alumnos)
//                //            {
//                //                //var idReligion = Convert.ToInt64(item);
//                //                Religion = Religiones.FirstOrDefault(x => x.idReligion == item.idReligion);
//                //                var Genero = db.CatGeneros.Find(Book.idGenero);
//                //                if (itemA.Personas.idGenero == Book.idGenero && itemA.idReligion == Religion.idReligion)
//                //                {
//                //                    IndicadoresVM IndicadorGR = new IndicadoresVM();
//                //                    IndicadorGR.nbCampo = Religion.nbReligion;
//                //                    IndicadorGR.nbCampo2 = Genero.nbGenero.Trim();
//                //                    IndicadorGR.numCampo = 1;
//                //                    IndicadoresGR.Add(IndicadorGR);
//                //                }
//                //            }
//                //        }
//                //    }

//                //    IndicadoresGR.ToList().ForEach(l =>
//                //    {
//                //        var row = dt.NewRow();
//                //        row["nbCategoria"] = l.nbCampo;
//                //        row["nbCategoria2"] = l.nbCampo2;
//                //        row["numDatos"] = l.numCampo;
//                //        dt.Rows.Add(row);
//                //    });

//                //    #endregion
//                //}
//                //else if (listacaCampos[0] == 8 && listacaCampos[1] == 7)
//                //{
//                //    #region
//                //    TituloColumna1 = "Religión";
//                //    TituloColumna2 = "Licenciatura";
//                //    TituloColumna3 = "Cantidad";
//                //    TituloGrafic = "Gráfica de barras por Religión y Licenciatura";

//                //    Licenciaturas Licenciatura = new Licenciaturas();
//                //    var Licenciaturas = db.Licenciaturas.ToList();
//                //    CatReligion Religion = new CatReligion();
//                //    var Religiones = db.CatReligion.ToList();

//                //    List<IndicadoresVM> IndicadoresLicRel = new List<IndicadoresVM>();

//                //    if (listaIdsLicenciaturas.Count() > 0 && listaIdsReligiones.Count() > 0)
//                //    {
//                //        foreach (var itemL in listaIdsLicenciaturas)
//                //        {
//                //            foreach (var itemR in listaIdsReligiones)
//                //            {
//                //                foreach (var item in Alumnos)
//                //                {
//                //                    var idLicenciatura = Convert.ToInt64(itemL);
//                //                    Licenciatura = Licenciaturas.FirstOrDefault(x => x.idLicenciatura == idLicenciatura);
//                //                    var idReligion = Convert.ToInt64(itemR);
//                //                    Religion = db.CatReligion.Find(idReligion);
//                //                    var FormacionesA = db.FormacionesAcademicas.Where(x => x.idAlumno == item.idAlumno && x.idLicenciatura == Licenciatura.idLicenciatura).ToList();
//                //                    if (item.idReligion == Religion.idReligion && FormacionesA.Count() > 0)
//                //                    {
//                //                        IndicadoresVM IndicadorLR = new IndicadoresVM();
//                //                        IndicadorLR.nbCampo = Religion.nbReligion;
//                //                        IndicadorLR.nbCampo2 = Licenciatura.nbLicenciatura;
//                //                        IndicadorLR.numCampo = 1;
//                //                        IndicadoresLicRel.Add(IndicadorLR);
//                //                    }
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (listaIdsLicenciaturas.Count() > 0 && listaIdsReligiones.Count() == 0)
//                //    {
//                //        foreach (var itemL in listaIdsLicenciaturas)
//                //        {
//                //            foreach (var itemR in Religiones)
//                //            {
//                //                foreach (var item in Alumnos)
//                //                {
//                //                    var idLicenciatura = Convert.ToInt64(itemL);
//                //                    Licenciatura = Licenciaturas.FirstOrDefault(x => x.idLicenciatura == idLicenciatura);
//                //                    //var idReligion = Convert.ToInt64(itemR);
//                //                    Religion = db.CatReligion.Find(itemR.idReligion);
//                //                    var FormacionesA = db.FormacionesAcademicas.Where(x => x.idAlumno == item.idAlumno && x.idLicenciatura == Licenciatura.idLicenciatura).ToList();
//                //                    if (item.idReligion == Religion.idReligion && FormacionesA.Count() > 0)
//                //                    {
//                //                        IndicadoresVM IndicadorLR = new IndicadoresVM();
//                //                        IndicadorLR.nbCampo = Religion.nbReligion;
//                //                        IndicadorLR.nbCampo2 = Licenciatura.nbLicenciatura;
//                //                        IndicadorLR.numCampo = 1;
//                //                        IndicadoresLicRel.Add(IndicadorLR);
//                //                    }
//                //                }

//                //            }
//                //        }
//                //    }
//                //    else if (listaIdsLicenciaturas.Count() == 0 && listaIdsReligiones.Count() > 0)
//                //    {
//                //        foreach (var itemL in Licenciaturas)
//                //        {
//                //            foreach (var itemR in listaIdsReligiones)
//                //            {
//                //                foreach (var item in Alumnos)
//                //                {
//                //                    //var idLicenciatura = Convert.ToInt64(itemL);
//                //                    Licenciatura = Licenciaturas.FirstOrDefault(x => x.idLicenciatura == itemL.idLicenciatura);
//                //                    var idReligion = Convert.ToInt64(itemR);
//                //                    Religion = db.CatReligion.Find(idReligion);
//                //                    var FormacionesA = db.FormacionesAcademicas.Where(x => x.idAlumno == item.idAlumno && x.idLicenciatura == Licenciatura.idLicenciatura).ToList();
//                //                    if (item.idReligion == Religion.idReligion && FormacionesA.Count() > 0)
//                //                    {
//                //                        IndicadoresVM IndicadorLR = new IndicadoresVM();
//                //                        IndicadorLR.nbCampo = Religion.nbReligion;
//                //                        IndicadorLR.nbCampo2 = Licenciatura.nbLicenciatura;
//                //                        IndicadorLR.numCampo = 1;
//                //                        IndicadoresLicRel.Add(IndicadorLR);
//                //                    }
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (listaIdsLicenciaturas.Count() == 0 && listaIdsReligiones.Count() == 0)
//                //    {
//                //        foreach (var itemL in Licenciaturas)
//                //        {
//                //            foreach (var itemR in Religiones)
//                //            {
//                //                foreach (var item in Alumnos)
//                //                {
//                //                    var idLicenciatura = Convert.ToInt64(itemL);
//                //                    Licenciatura = Licenciaturas.FirstOrDefault(x => x.idLicenciatura == itemL.idLicenciatura);
//                //                    //var idReligion = Convert.ToInt64(itemR);
//                //                    Religion = db.CatReligion.Find(itemR.idReligion);
//                //                    var FormacionesA = db.FormacionesAcademicas.Where(x => x.idAlumno == item.idAlumno && x.idLicenciatura == Licenciatura.idLicenciatura).ToList();
//                //                    if (item.idReligion == Religion.idReligion && FormacionesA.Count() > 0)
//                //                    {
//                //                        IndicadoresVM IndicadorLR = new IndicadoresVM();
//                //                        IndicadorLR.nbCampo = Religion.nbReligion;
//                //                        IndicadorLR.nbCampo2 = Licenciatura.nbLicenciatura;
//                //                        IndicadorLR.numCampo = 1;
//                //                        IndicadoresLicRel.Add(IndicadorLR);
//                //                    }
//                //                }
//                //            }
//                //        }
//                //    }

//                //    IndicadoresLicRel.ToList().ForEach(l =>
//                //    {
//                //        var row = dt.NewRow();
//                //        row["nbCategoria"] = l.nbCampo;
//                //        row["nbCategoria2"] = l.nbCampo2;
//                //        row["numDatos"] = l.numCampo;
//                //        dt.Rows.Add(row);
//                //    });
//                //    #endregion
//                //}
//                //else if (listacaCampos[0] == 8 && listacaCampos[1] == 9)
//                //{
//                //    #region

//                //    TituloColumna1 = "Religión";
//                //    TituloColumna2 = "Estados";
//                //    TituloColumna3 = "Cantidad";
//                //    TituloGrafic = "Gráfica de barras por Religión y Estados";

//                //    CatReligion Religion = new CatReligion();
//                //    var Religiones = db.CatReligion.ToList();
//                //    CatEstados Estado = new CatEstados();
//                //    var Estados = db.CatEstados.ToList();

//                //    List<IndicadoresVM> IndicadoresRelEdos = new List<IndicadoresVM>();

//                //    if (listaIdsReligiones.Count() > 0 && listaIdsestados.Count() > 0)
//                //    {
//                //        foreach (var itemR in listaIdsReligiones)
//                //        {
//                //            foreach (var itemE in listaIdsestados)
//                //            {
//                //                foreach (var item in Alumnos)
//                //                {
//                //                    var idReligion = Convert.ToInt64(itemR);
//                //                    Religion = Religiones.FirstOrDefault(x => x.idReligion == idReligion);
//                //                    var idEstado = Convert.ToInt64(itemE);
//                //                    Estado = Estados.FirstOrDefault(x => x.idEstado == idEstado);
//                //                    if (item.idReligion == Religion.idReligion && item.Direcciones.nbEstado == Estado.nbEstado)
//                //                    {
//                //                        IndicadoresVM IndicadorRE = new IndicadoresVM();
//                //                        IndicadorRE.nbCampo = Religion.nbReligion;
//                //                        IndicadorRE.nbCampo2 = Estado.nbEstado;
//                //                        IndicadorRE.numCampo = 1;
//                //                        IndicadoresRelEdos.Add(IndicadorRE);
//                //                    }
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (listaIdsReligiones.Count() > 0 && listaIdsestados.Count() == 0)
//                //    {
//                //        foreach (var itemR in listaIdsReligiones)
//                //        {
//                //            foreach (var itemE in Estados)
//                //            {
//                //                foreach (var item in Alumnos)
//                //                {
//                //                    var idReligion = Convert.ToInt64(itemR);
//                //                    Religion = Religiones.FirstOrDefault(x => x.idReligion == idReligion);
//                //                    //var idEstado = Convert.ToInt64(itemE);
//                //                    Estado = Estados.FirstOrDefault(x => x.idEstado == itemE.idEstado);
//                //                    if (item.idReligion == Religion.idReligion && item.Direcciones.nbEstado == Estado.nbEstado)
//                //                    {
//                //                        IndicadoresVM IndicadorRE = new IndicadoresVM();
//                //                        IndicadorRE.nbCampo = Religion.nbReligion;
//                //                        IndicadorRE.nbCampo2 = Estado.nbEstado;
//                //                        IndicadorRE.numCampo = 1;
//                //                        IndicadoresRelEdos.Add(IndicadorRE);
//                //                    }
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (listaIdsReligiones.Count() == 0 && listaIdsestados.Count() > 0)
//                //    {
//                //        foreach (var itemR in Religiones)
//                //        {
//                //            foreach (var itemE in listaIdsestados)
//                //            {
//                //                foreach (var item in Alumnos)
//                //                {
//                //                    //var idReligion = Convert.ToInt64(itemR);
//                //                    Religion = Religiones.FirstOrDefault(x => x.idReligion == itemR.idReligion);
//                //                    var idEstado = Convert.ToInt64(itemE);
//                //                    Estado = Estados.FirstOrDefault(x => x.idEstado == idEstado);
//                //                    if (item.idReligion == Religion.idReligion && item.Direcciones.nbEstado == Estado.nbEstado)
//                //                    {
//                //                        IndicadoresVM IndicadorRE = new IndicadoresVM();
//                //                        IndicadorRE.nbCampo = Religion.nbReligion;
//                //                        IndicadorRE.nbCampo2 = Estado.nbEstado;
//                //                        IndicadorRE.numCampo = 1;
//                //                        IndicadoresRelEdos.Add(IndicadorRE);
//                //                    }
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (listaIdsReligiones.Count() == 0 && listaIdsestados.Count() == 0)
//                //    {
//                //        foreach (var itemR in Religiones)
//                //        {
//                //            foreach (var itemE in Estados)
//                //            {
//                //                foreach (var item in Alumnos)
//                //                {
//                //                    //var idReligion = Convert.ToInt64(itemR);
//                //                    Religion = Religiones.FirstOrDefault(x => x.idReligion == itemR.idReligion);
//                //                    //var idEstado = Convert.ToInt64(itemE);
//                //                    Estado = Estados.FirstOrDefault(x => x.idEstado == itemE.idEstado);
//                //                    if (item.idReligion == Religion.idReligion && item.Direcciones.nbEstado == Estado.nbEstado)
//                //                    {
//                //                        IndicadoresVM IndicadorRE = new IndicadoresVM();
//                //                        IndicadorRE.nbCampo = Religion.nbReligion;
//                //                        IndicadorRE.nbCampo2 = Estado.nbEstado;
//                //                        IndicadorRE.numCampo = 1;
//                //                        IndicadoresRelEdos.Add(IndicadorRE);
//                //                    }
//                //                }
//                //            }
//                //        }
//                //    }

//                //    IndicadoresRelEdos.ToList().ForEach(l =>
//                //    {
//                //        var row = dt.NewRow();
//                //        row["nbCategoria"] = l.nbCampo;
//                //        row["nbCategoria2"] = l.nbCampo2;
//                //        row["numDatos"] = l.numCampo;
//                //        dt.Rows.Add(row);
//                //    });
//                //    #endregion
//                //}
//                //else if (listacaCampos[0] == 8 && listacaCampos[1] == 10)
//                //{
//                //    #region

//                //    TituloColumna1 = "Religión";
//                //    TituloColumna2 = "Trabajo";
//                //    TituloColumna3 = "Cantidad";
//                //    TituloGrafic = "Gráfica de barras por Religión y Trabajo";

//                //    CatReligion Religion = new CatReligion();
//                //    var Religiones = db.CatReligion.ToList();

//                //    List<IndicadoresVM> IndicadoresRelTrab = new List<IndicadoresVM>();

//                //    if (listaIdsReligiones.Count() > 0 && Book.fgTrabajaActualmente != null)
//                //    {
//                //        foreach (var itemR in listaIdsReligiones)
//                //        {
//                //            foreach (var itemA in Alumnos)
//                //            {
//                //                var idReligion = Convert.ToInt64(itemR);
//                //                Religion = Religiones.FirstOrDefault(x => x.idReligion == idReligion);
//                //                if (itemA.idReligion == Religion.idReligion && itemA.fgTrabajaActualmente == Book.fgTrabajaActualmente)
//                //                {
//                //                    IndicadoresVM IndicadorRT = new IndicadoresVM();
//                //                    IndicadorRT.nbCampo = Religion.nbReligion;
//                //                    IndicadorRT.nbCampo2 = (Book.fgTrabajaActualmente == true) ? "SI" : "NO";
//                //                    IndicadorRT.numCampo = 1;
//                //                    IndicadoresRelTrab.Add(IndicadorRT);
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (listaIdsReligiones.Count() > 0 && Book.fgTrabajaActualmente == null)
//                //    {
//                //        foreach (var itemR in listaIdsReligiones)
//                //        {
//                //            foreach (var itemA in Alumnos)
//                //            {
//                //                var idReligion = Convert.ToInt64(itemR);
//                //                Religion = Religiones.FirstOrDefault(x => x.idReligion == idReligion);
//                //                if (itemA.idReligion == Religion.idReligion && itemA.fgTrabajaActualmente == true)
//                //                {
//                //                    IndicadoresVM IndicadorRT = new IndicadoresVM();
//                //                    IndicadorRT.nbCampo = Religion.nbReligion;
//                //                    IndicadorRT.nbCampo2 = "SI";
//                //                    IndicadorRT.numCampo = 1;
//                //                    IndicadoresRelTrab.Add(IndicadorRT);
//                //                }
//                //                else if (itemA.idReligion == Religion.idReligion && itemA.fgTrabajaActualmente == false)
//                //                {
//                //                    IndicadoresVM IndicadorRNT = new IndicadoresVM();
//                //                    IndicadorRNT.nbCampo = Religion.nbReligion;
//                //                    IndicadorRNT.nbCampo2 = "NO";
//                //                    IndicadorRNT.numCampo = 1;
//                //                    IndicadoresRelTrab.Add(IndicadorRNT);
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (listaIdsReligiones.Count() == 0 && Book.fgTrabajaActualmente != null)
//                //    {
//                //        foreach (var itemR in Religiones)
//                //        {
//                //            foreach (var itemA in Alumnos)
//                //            {
//                //                //var idReligion = Convert.ToInt64(itemR);
//                //                Religion = Religiones.FirstOrDefault(x => x.idReligion == itemR.idReligion);
//                //                if (itemA.idReligion == Religion.idReligion && itemA.fgTrabajaActualmente == Book.fgTrabajaActualmente)
//                //                {
//                //                    IndicadoresVM IndicadorRT = new IndicadoresVM();
//                //                    IndicadorRT.nbCampo = Religion.nbReligion;
//                //                    IndicadorRT.nbCampo2 = (Book.fgTrabajaActualmente == true) ? "SI" : "NO";
//                //                    IndicadorRT.numCampo = 1;
//                //                    IndicadoresRelTrab.Add(IndicadorRT);
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (listaIdsReligiones.Count() == 0 && Book.fgTrabajaActualmente == null)
//                //    {
//                //        foreach (var itemR in Religiones)
//                //        {
//                //            foreach (var itemA in Alumnos)
//                //            {
//                //                //var idReligion = Convert.ToInt64(itemR);
//                //                Religion = Religiones.FirstOrDefault(x => x.idReligion == itemR.idReligion);
//                //                if (itemA.idReligion == Religion.idReligion && itemA.fgTrabajaActualmente == true)
//                //                {
//                //                    IndicadoresVM IndicadorRT = new IndicadoresVM();
//                //                    IndicadorRT.nbCampo = Religion.nbReligion;
//                //                    IndicadorRT.nbCampo2 = "SI";
//                //                    IndicadorRT.numCampo = 1;
//                //                    IndicadoresRelTrab.Add(IndicadorRT);
//                //                }
//                //                else if (itemA.idReligion == Religion.idReligion && itemA.fgTrabajaActualmente == false)
//                //                {
//                //                    IndicadoresVM IndicadorRNT = new IndicadoresVM();
//                //                    IndicadorRNT.nbCampo = Religion.nbReligion;
//                //                    IndicadorRNT.nbCampo2 = "NO";
//                //                    IndicadorRNT.numCampo = 1;
//                //                    IndicadoresRelTrab.Add(IndicadorRNT);
//                //                }
//                //            }
//                //        }
//                //    }

//                //    IndicadoresRelTrab.ToList().ForEach(l =>
//                //    {
//                //        var row = dt.NewRow();
//                //        row["nbCategoria"] = l.nbCampo;
//                //        row["nbCategoria2"] = l.nbCampo2;
//                //        row["numDatos"] = l.numCampo;
//                //        dt.Rows.Add(row);
//                //    });

//                //    #endregion
//                //}
//                //else if (listacaCampos[0] == 8 && listacaCampos[1] == 11)
//                //{
//                //    #region

//                //    TituloColumna1 = "Religión";
//                //    TituloColumna2 = "Tipo de Sangre";
//                //    TituloColumna3 = "Cantidad";
//                //    TituloGrafic = "Gráfica de barras por Religión y Tipo de Sangre";

//                //    CatReligion Religion = new CatReligion();
//                //    var Religiones = db.CatReligion.ToList();
//                //    var CatTiposSangre = db.CatTiposSangre.ToList();
//                //    List<IndicadoresVM> IndicadoresRS = new List<IndicadoresVM>();

//                //    if (Book.idTipoSangre != null && listaIdsReligiones.Count > 0)
//                //    {
//                //        foreach (var item in listaIdsReligiones)
//                //        {
//                //            foreach (var itemA in Alumnos)
//                //            {
//                //                var idReligion = Convert.ToInt64(item);
//                //                Religion = Religiones.FirstOrDefault(x => x.idReligion == idReligion);
//                //                var TipoSangre = db.CatTiposSangre.Find(Book.idTipoSangre);
//                //                if (itemA.idTipoSangre == TipoSangre.idTipoSangre && itemA.idReligion == Religion.idReligion)
//                //                {
//                //                    IndicadoresVM IndicadoRS = new IndicadoresVM();
//                //                    IndicadoRS.nbCampo = Religion.nbReligion;
//                //                    IndicadoRS.nbCampo2 = TipoSangre.nbTipoSangre.Trim();
//                //                    IndicadoRS.numCampo = 1;
//                //                    IndicadoresRS.Add(IndicadoRS);
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (Book.idTipoSangre == null && listaIdsReligiones.Count > 0)
//                //    {
//                //        foreach (var item in listaIdsReligiones)
//                //        {
//                //            foreach (var itemS in CatTiposSangre)
//                //            {
//                //                foreach (var itemA in Alumnos)
//                //                {
//                //                    var idReligion = Convert.ToInt64(item);
//                //                    Religion = Religiones.FirstOrDefault(x => x.idReligion == idReligion);
//                //                    var TipoSangre = db.CatTiposSangre.Find(itemS.idTipoSangre);
//                //                    if (itemA.idTipoSangre == TipoSangre.idTipoSangre && itemA.idReligion == Religion.idReligion)
//                //                    {
//                //                        IndicadoresVM IndicadoRS = new IndicadoresVM();
//                //                        IndicadoRS.nbCampo = Religion.nbReligion;
//                //                        IndicadoRS.nbCampo2 = TipoSangre.nbTipoSangre.Trim();
//                //                        IndicadoRS.numCampo = 1;
//                //                        IndicadoresRS.Add(IndicadoRS);
//                //                    }
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (Book.idTipoSangre == null && listaIdsReligiones.Count == 0)
//                //    {
//                //        foreach (var item in Religiones)
//                //        {
//                //            foreach (var itemS in CatTiposSangre)
//                //            {
//                //                foreach (var itemA in Alumnos)
//                //                {
//                //                    //var idReligion = Convert.ToInt64(item);
//                //                    Religion = Religiones.FirstOrDefault(x => x.idReligion == item.idReligion);
//                //                    var TipoSangre = db.CatTiposSangre.Find(itemS.idTipoSangre);
//                //                    if (itemA.idTipoSangre == TipoSangre.idTipoSangre && itemA.idReligion == Religion.idReligion)
//                //                    {
//                //                        IndicadoresVM IndicadoRS = new IndicadoresVM();
//                //                        IndicadoRS.nbCampo = Religion.nbReligion;
//                //                        IndicadoRS.nbCampo2 = TipoSangre.nbTipoSangre.Trim();
//                //                        IndicadoRS.numCampo = 1;
//                //                        IndicadoresRS.Add(IndicadoRS);
//                //                    }
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (Book.idTipoSangre != null && listaIdsReligiones.Count == 0)
//                //    {
//                //        foreach (var item in Religiones)
//                //        {
//                //            foreach (var itemA in Alumnos)
//                //            {
//                //                //var idReligion = Convert.ToInt64(item);
//                //                Religion = Religiones.FirstOrDefault(x => x.idReligion == item.idReligion);
//                //                var TipoSangre = db.CatTiposSangre.Find(Book.idTipoSangre);
//                //                if (itemA.idTipoSangre == TipoSangre.idTipoSangre && itemA.idReligion == Religion.idReligion)
//                //                {
//                //                    IndicadoresVM IndicadoRS = new IndicadoresVM();
//                //                    IndicadoRS.nbCampo = Religion.nbReligion;
//                //                    IndicadoRS.nbCampo2 = TipoSangre.nbTipoSangre.Trim();
//                //                    IndicadoRS.numCampo = 1;
//                //                    IndicadoresRS.Add(IndicadoRS);
//                //                }
//                //            }
//                //        }
//                //    }

//                //    IndicadoresRS.ToList().ForEach(l =>
//                //    {
//                //        var row = dt.NewRow();
//                //        row["nbCategoria"] = l.nbCampo;
//                //        row["nbCategoria2"] = l.nbCampo2;
//                //        row["numDatos"] = l.numCampo;
//                //        dt.Rows.Add(row);
//                //    });

//                //    #endregion
//                //}
//                //else if (listacaCampos[0] == 8 && listacaCampos[1] == 12)
//                //{
//                //    #region

//                //    TituloColumna1 = "Religión";
//                //    TituloColumna2 = "Licencia";
//                //    TituloColumna3 = "Cantidad";
//                //    TituloGrafic = "Gráfica de barras por Religión y Licencia";

//                //    CatReligion Religion = new CatReligion();
//                //    var Religiones = db.CatReligion.ToList();

//                //    List<IndicadoresVM> IndicadoresRelLicencia = new List<IndicadoresVM>();

//                //    if (listaIdsReligiones.Count() > 0 && Book.fgLicencia != null)
//                //    {
//                //        foreach (var itemR in listaIdsReligiones)
//                //        {
//                //            foreach (var itemA in Alumnos)
//                //            {
//                //                var idReligion = Convert.ToInt64(itemR);
//                //                Religion = Religiones.FirstOrDefault(x => x.idReligion == idReligion);
//                //                if (itemA.fgLicencia == Book.fgLicencia && itemA.idReligion == Religion.idReligion)
//                //                {
//                //                    IndicadoresVM IndicadorRL = new IndicadoresVM();
//                //                    IndicadorRL.nbCampo = Religion.nbReligion;
//                //                    IndicadorRL.nbCampo2 = (Book.fgLicencia == true) ? "SI" : "NO";
//                //                    IndicadorRL.numCampo = 1;
//                //                    IndicadoresRelLicencia.Add(IndicadorRL);
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (listaIdsReligiones.Count() > 0 && Book.fgLicencia == null)
//                //    {
//                //        foreach (var itemR in listaIdsReligiones)
//                //        {
//                //            foreach (var itemA in Alumnos)
//                //            {
//                //                var idReligion = Convert.ToInt64(itemR);
//                //                Religion = Religiones.FirstOrDefault(x => x.idReligion == idReligion);
//                //                if (itemA.fgLicencia == true && itemA.idReligion == Religion.idReligion)
//                //                {
//                //                    IndicadoresVM IndicadorRL = new IndicadoresVM();
//                //                    IndicadorRL.nbCampo = Religion.nbReligion;
//                //                    IndicadorRL.nbCampo2 = "SI";
//                //                    IndicadorRL.numCampo = 1;
//                //                    IndicadoresRelLicencia.Add(IndicadorRL);
//                //                }
//                //                else if (itemA.fgLicencia == false && itemA.idReligion == Religion.idReligion)
//                //                {
//                //                    IndicadoresVM IndicadorRNL = new IndicadoresVM();
//                //                    IndicadorRNL.nbCampo = Religion.nbReligion;
//                //                    IndicadorRNL.nbCampo2 = "NO";
//                //                    IndicadorRNL.numCampo = 1;
//                //                    IndicadoresRelLicencia.Add(IndicadorRNL);
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (listaIdsReligiones.Count() == 0 && Book.fgLicencia != null)
//                //    {
//                //        foreach (var itemR in Religiones)
//                //        {
//                //            foreach (var itemA in Alumnos)
//                //            {
//                //                //var idReligion = Convert.ToInt64(itemR);
//                //                Religion = Religiones.FirstOrDefault(x => x.idReligion == itemR.idReligion);
//                //                if (itemA.fgLicencia == Book.fgLicencia && itemA.idReligion == Religion.idReligion)
//                //                {
//                //                    IndicadoresVM IndicadorRL = new IndicadoresVM();
//                //                    IndicadorRL.nbCampo = Religion.nbReligion;
//                //                    IndicadorRL.nbCampo2 = (Book.fgLicencia == true) ? "SI" : "NO";
//                //                    IndicadorRL.numCampo = 1;
//                //                    IndicadoresRelLicencia.Add(IndicadorRL);
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (listaIdsReligiones.Count() == 0 && Book.fgLicencia == null)
//                //    {
//                //        foreach (var itemR in Religiones)
//                //        {
//                //            foreach (var itemA in Alumnos)
//                //            {
//                //                //var idReligion = Convert.ToInt64(itemR);
//                //                Religion = Religiones.FirstOrDefault(x => x.idReligion == itemR.idReligion);
//                //                if (itemA.fgLicencia == true && itemA.idReligion == Religion.idReligion)
//                //                {
//                //                    IndicadoresVM IndicadorRL = new IndicadoresVM();
//                //                    IndicadorRL.nbCampo = Religion.nbReligion;
//                //                    IndicadorRL.nbCampo2 = "SI";
//                //                    IndicadorRL.numCampo = 1;
//                //                    IndicadoresRelLicencia.Add(IndicadorRL);
//                //                }
//                //                else if (itemA.fgLicencia == false && itemA.idReligion == Religion.idReligion)
//                //                {
//                //                    IndicadoresVM IndicadorRNL = new IndicadoresVM();
//                //                    IndicadorRNL.nbCampo = Religion.nbReligion;
//                //                    IndicadorRNL.nbCampo2 = "NO";
//                //                    IndicadorRNL.numCampo = 1;
//                //                    IndicadoresRelLicencia.Add(IndicadorRNL);
//                //                }
//                //            }
//                //        }
//                //    }

//                //    IndicadoresRelLicencia.ToList().ForEach(l =>
//                //    {
//                //        var row = dt.NewRow();
//                //        row["nbCategoria"] = l.nbCampo;
//                //        row["nbCategoria2"] = l.nbCampo2;
//                //        row["numDatos"] = l.numCampo;
//                //        dt.Rows.Add(row);
//                //    });

//                //    #endregion
//                //}
//                //else if (listacaCampos[0] == 8 && listacaCampos[1] == 13)
//                //{
//                //    #region

//                //    TituloColumna1 = "Religión";
//                //    TituloColumna2 = "Tipo de Egresado";
//                //    TituloColumna3 = "Cantidad";
//                //    TituloGrafic = "Gráfica de barras por Religión y Tipo de Egresado";

//                //    CatReligion Religion = new CatReligion();
//                //    var Religiones = db.CatReligion.ToList();

//                //    List<IndicadoresVM> IndicadoresRelEgresados = new List<IndicadoresVM>();

//                //    if (listaIdsReligiones.Count() > 0 && Book.tpEgresado != null)
//                //    {
//                //        foreach (var itemR in listaIdsReligiones)
//                //        {
//                //            foreach (var itemA in Alumnos)
//                //            {
//                //                var idReligion = Convert.ToInt64(itemR);
//                //                Religion = Religiones.FirstOrDefault(x => x.idReligion == idReligion);
//                //                if (itemA.tpEgresado == Book.tpEgresado && itemA.idReligion == Religion.idReligion)
//                //                {
//                //                    IndicadoresVM IndicadorRE = new IndicadoresVM();
//                //                    IndicadorRE.nbCampo = Religion.nbReligion;
//                //                    IndicadorRE.nbCampo2 = (Book.tpEgresado == "T") ? "Titulado" : "Pasante";
//                //                    IndicadorRE.numCampo = 1;
//                //                    IndicadoresRelEgresados.Add(IndicadorRE);
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (listaIdsReligiones.Count() > 0 && Book.tpEgresado == null)
//                //    {
//                //        foreach (var itemR in listaIdsReligiones)
//                //        {
//                //            foreach (var itemA in Alumnos)
//                //            {
//                //                var idReligion = Convert.ToInt64(itemR);
//                //                Religion = Religiones.FirstOrDefault(x => x.idReligion == idReligion);
//                //                if (itemA.tpEgresado == "T" && itemA.idReligion == Religion.idReligion)
//                //                {
//                //                    IndicadoresVM IndicadorRE = new IndicadoresVM();
//                //                    IndicadorRE.nbCampo = Religion.nbReligion;
//                //                    IndicadorRE.nbCampo2 = "Titulado";
//                //                    IndicadorRE.numCampo = 1;
//                //                    IndicadoresRelEgresados.Add(IndicadorRE);
//                //                }
//                //                else if (itemA.tpEgresado == "P" && itemA.idReligion == Religion.idReligion)
//                //                {
//                //                    IndicadoresVM IndicadorRNE = new IndicadoresVM();
//                //                    IndicadorRNE.nbCampo = Religion.nbReligion;
//                //                    IndicadorRNE.nbCampo2 = "Pasante";
//                //                    IndicadorRNE.numCampo = 1;
//                //                    IndicadoresRelEgresados.Add(IndicadorRNE);
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (listaIdsReligiones.Count() == 0 && Book.tpEgresado != null)
//                //    {
//                //        foreach (var itemR in Religiones)
//                //        {
//                //            foreach (var itemA in Alumnos)
//                //            {
//                //                //var idReligion = Convert.ToInt64(itemR);
//                //                Religion = Religiones.FirstOrDefault(x => x.idReligion == itemR.idReligion);
//                //                if (itemA.tpEgresado == Book.tpEgresado && itemA.idReligion == Religion.idReligion)
//                //                {
//                //                    IndicadoresVM IndicadorRE = new IndicadoresVM();
//                //                    IndicadorRE.nbCampo = Religion.nbReligion;
//                //                    IndicadorRE.nbCampo2 = (Book.tpEgresado == "T") ? "Titulado" : "Pasante";
//                //                    IndicadorRE.numCampo = 1;
//                //                    IndicadoresRelEgresados.Add(IndicadorRE);
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (listaIdsReligiones.Count() == 0 && Book.tpEgresado == null)
//                //    {
//                //        foreach (var itemR in Religiones)
//                //        {
//                //            foreach (var itemA in Alumnos)
//                //            {
//                //                //var idReligion = Convert.ToInt64(itemR);
//                //                Religion = Religiones.FirstOrDefault(x => x.idReligion == itemR.idReligion);
//                //                if (itemA.tpEgresado == "T" && itemA.idReligion == Religion.idReligion)
//                //                {
//                //                    IndicadoresVM IndicadorRE = new IndicadoresVM();
//                //                    IndicadorRE.nbCampo = Religion.nbReligion;
//                //                    IndicadorRE.nbCampo2 = "Titulado";
//                //                    IndicadorRE.numCampo = 1;
//                //                    IndicadoresRelEgresados.Add(IndicadorRE);
//                //                }
//                //                else if (itemA.tpEgresado == "P" && itemA.idReligion == Religion.idReligion)
//                //                {
//                //                    IndicadoresVM IndicadorRNE = new IndicadoresVM();
//                //                    IndicadorRNE.nbCampo = Religion.nbReligion;
//                //                    IndicadorRNE.nbCampo2 = "Pasante";
//                //                    IndicadorRNE.numCampo = 1;
//                //                    IndicadoresRelEgresados.Add(IndicadorRNE);
//                //                }
//                //            }
//                //        }
//                //    }

//                //    IndicadoresRelEgresados.ToList().ForEach(l =>
//                //    {
//                //        var row = dt.NewRow();
//                //        row["nbCategoria"] = l.nbCampo;
//                //        row["nbCategoria2"] = l.nbCampo2;
//                //        row["numDatos"] = l.numCampo;
//                //        dt.Rows.Add(row);
//                //    });

//                //    #endregion
//                //}
//                //else if (listacaCampos[0] == 8 && listacaCampos[1] == 14)
//                //{
//                //    #region

//                //    TituloColumna1 = "Religión";
//                //    TituloColumna2 = "Fallecimiento";
//                //    TituloColumna3 = "Cantidad";
//                //    TituloGrafic = "Gráfica de barras por Religión y Fallecimiento";

//                //    CatReligion Religion = new CatReligion();
//                //    var Religiones = db.CatReligion.ToList();

//                //    List<IndicadoresVM> IndicadoresRelLicencia = new List<IndicadoresVM>();

//                //    if (listaIdsReligiones.Count() > 0 && Book.fgFallecido != null)
//                //    {
//                //        foreach (var itemR in listaIdsReligiones)
//                //        {
//                //            foreach (var itemA in Alumnos)
//                //            {
//                //                var idReligion = Convert.ToInt64(itemR);
//                //                Religion = Religiones.FirstOrDefault(x => x.idReligion == idReligion);
//                //                if (itemA.fgFallecido == Book.fgFallecido && itemA.idReligion == Religion.idReligion)
//                //                {
//                //                    IndicadoresVM IndicadorRL = new IndicadoresVM();
//                //                    IndicadorRL.nbCampo = Religion.nbReligion;
//                //                    IndicadorRL.nbCampo2 = (Book.fgFallecido == true) ? "SI" : "NO";
//                //                    IndicadorRL.numCampo = 1;
//                //                    IndicadoresRelLicencia.Add(IndicadorRL);
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (listaIdsReligiones.Count() > 0 && Book.fgFallecido == null)
//                //    {
//                //        foreach (var itemR in listaIdsReligiones)
//                //        {
//                //            foreach (var itemA in Alumnos)
//                //            {
//                //                var idReligion = Convert.ToInt64(itemR);
//                //                Religion = Religiones.FirstOrDefault(x => x.idReligion == idReligion);
//                //                if (itemA.fgFallecido == true && itemA.idReligion == Religion.idReligion)
//                //                {
//                //                    IndicadoresVM IndicadorRL = new IndicadoresVM();
//                //                    IndicadorRL.nbCampo = Religion.nbReligion;
//                //                    IndicadorRL.nbCampo2 = "SI";
//                //                    IndicadorRL.numCampo = 1;
//                //                    IndicadoresRelLicencia.Add(IndicadorRL);
//                //                }
//                //                else if (itemA.fgFallecido == false && itemA.idReligion == Religion.idReligion)
//                //                {
//                //                    IndicadoresVM IndicadorRNL = new IndicadoresVM();
//                //                    IndicadorRNL.nbCampo = Religion.nbReligion;
//                //                    IndicadorRNL.nbCampo2 = "NO";
//                //                    IndicadorRNL.numCampo = 1;
//                //                    IndicadoresRelLicencia.Add(IndicadorRNL);
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (listaIdsReligiones.Count() == 0 && Book.fgFallecido != null)
//                //    {
//                //        foreach (var itemR in Religiones)
//                //        {
//                //            foreach (var itemA in Alumnos)
//                //            {
//                //                //var idReligion = Convert.ToInt64(itemR);
//                //                Religion = Religiones.FirstOrDefault(x => x.idReligion == itemR.idReligion);
//                //                if (itemA.fgFallecido == Book.fgFallecido && itemA.idReligion == Religion.idReligion)
//                //                {
//                //                    IndicadoresVM IndicadorRL = new IndicadoresVM();
//                //                    IndicadorRL.nbCampo = Religion.nbReligion;
//                //                    IndicadorRL.nbCampo2 = (Book.fgFallecido == true) ? "SI" : "NO";
//                //                    IndicadorRL.numCampo = 1;
//                //                    IndicadoresRelLicencia.Add(IndicadorRL);
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (listaIdsReligiones.Count() == 0 && Book.fgFallecido == null)
//                //    {
//                //        foreach (var itemR in Religiones)
//                //        {
//                //            foreach (var itemA in Alumnos)
//                //            {
//                //                //var idReligion = Convert.ToInt64(itemR);
//                //                Religion = Religiones.FirstOrDefault(x => x.idReligion == itemR.idReligion);
//                //                if (itemA.fgFallecido == true && itemA.idReligion == Religion.idReligion)
//                //                {
//                //                    IndicadoresVM IndicadorRL = new IndicadoresVM();
//                //                    IndicadorRL.nbCampo = Religion.nbReligion;
//                //                    IndicadorRL.nbCampo2 = "SI";
//                //                    IndicadorRL.numCampo = 1;
//                //                    IndicadoresRelLicencia.Add(IndicadorRL);
//                //                }
//                //                else if (itemA.fgFallecido == false && itemA.idReligion == Religion.idReligion)
//                //                {
//                //                    IndicadoresVM IndicadorRNL = new IndicadoresVM();
//                //                    IndicadorRNL.nbCampo = Religion.nbReligion;
//                //                    IndicadorRNL.nbCampo2 = "NO";
//                //                    IndicadorRNL.numCampo = 1;
//                //                    IndicadoresRelLicencia.Add(IndicadorRNL);
//                //                }
//                //            }
//                //        }
//                //    }

//                //    IndicadoresRelLicencia.ToList().ForEach(l =>
//                //    {
//                //        var row = dt.NewRow();
//                //        row["nbCategoria"] = l.nbCampo;
//                //        row["nbCategoria2"] = l.nbCampo2;
//                //        row["numDatos"] = l.numCampo;
//                //        dt.Rows.Add(row);
//                //    });

//                //    #endregion
//                //}
//                //else if (listacaCampos[0] == 9 && listacaCampos[1] == 2)
//                //{
//                //    #region

//                //    TituloColumna1 = "Estado";
//                //    TituloColumna2 = "Estado Civil";
//                //    TituloColumna3 = "Cantidad";
//                //    TituloGrafic = "Gráfica de barras por Estado y Estado Civil";

//                //    var Estado = new CatEstados();
//                //    var Estados = db.CatEstados.ToList();
//                //    var CatEstadosCiviles = db.CatEstadosCiviles.ToList();
//                //    List<IndicadoresVM> IndicadoresEdoCEdos = new List<IndicadoresVM>();
//                //    if (Book.idEstadoCivil != null && listaIdsestados.Count > 0)
//                //    {
//                //        foreach (var item in listaIdsestados)
//                //        {
//                //            foreach (var itemA in Alumnos)
//                //            {
//                //                var idEstado = Convert.ToInt64(item);
//                //                Estado = Estados.FirstOrDefault(x => x.idEstado == idEstado);
//                //                var EstadoCivil = db.CatEstadosCiviles.Find(Book.idEstadoCivil);
//                //                if (itemA.idEstadoCivil == EstadoCivil.idEstadoCivil && itemA.Direcciones.nbEstado.Trim().ToUpper() == Estado.nbEstado.Trim().ToUpper())
//                //                {
//                //                    IndicadoresVM IndicadorECEstados = new IndicadoresVM();
//                //                    IndicadorECEstados.nbCampo = Estado.nbEstado;
//                //                    IndicadorECEstados.nbCampo2 = EstadoCivil.nbEstadoCivil.Trim();
//                //                    IndicadorECEstados.numCampo = 1;
//                //                    IndicadoresEdoCEdos.Add(IndicadorECEstados);
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (Book.idEstadoCivil == null && listaIdsestados.Count > 0)
//                //    {
//                //        foreach (var item in listaIdsestados)
//                //        {
//                //            foreach (var itemEC in CatEstadosCiviles)
//                //            {
//                //                foreach (var itemA in Alumnos)
//                //                {
//                //                    var idEstado = Convert.ToInt64(item);
//                //                    Estado = Estados.FirstOrDefault(x => x.idEstado == idEstado);
//                //                    var EstadoCivil = db.CatEstadosCiviles.Find(itemEC.idEstadoCivil);
//                //                    if (itemA.idEstadoCivil == EstadoCivil.idEstadoCivil && itemA.Direcciones.nbEstado.Trim().ToUpper() == Estado.nbEstado.Trim().ToUpper())
//                //                    {
//                //                        IndicadoresVM IndicadorECEstados = new IndicadoresVM();
//                //                        IndicadorECEstados.nbCampo = Estado.nbEstado;
//                //                        IndicadorECEstados.nbCampo2 = EstadoCivil.nbEstadoCivil.Trim();
//                //                        IndicadorECEstados.numCampo = 1;
//                //                        IndicadoresEdoCEdos.Add(IndicadorECEstados);
//                //                    }
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (Book.idEstadoCivil == null && listaIdsestados.Count == 0)
//                //    {
//                //        foreach (var item in Estados)
//                //        {
//                //            foreach (var itemEC in CatEstadosCiviles)
//                //            {
//                //                foreach (var itemA in Alumnos)
//                //                {
//                //                    //var idEstado = Convert.ToInt64(item);
//                //                    Estado = Estados.FirstOrDefault(x => x.idEstado == item.idEstado);
//                //                    var EstadoCivil = db.CatEstadosCiviles.Find(itemEC.idEstadoCivil);
//                //                    if (itemA.idEstadoCivil == EstadoCivil.idEstadoCivil && itemA.Direcciones.nbEstado.Trim().ToUpper() == Estado.nbEstado.Trim().ToUpper())
//                //                    {
//                //                        IndicadoresVM IndicadorECEstados = new IndicadoresVM();
//                //                        IndicadorECEstados.nbCampo = Estado.nbEstado;
//                //                        IndicadorECEstados.nbCampo2 = EstadoCivil.nbEstadoCivil.Trim();
//                //                        IndicadorECEstados.numCampo = 1;
//                //                        IndicadoresEdoCEdos.Add(IndicadorECEstados);
//                //                    }
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (Book.idEstadoCivil != null && listaIdsestados.Count == 0)
//                //    {
//                //        foreach (var item in Estados)
//                //        {
//                //            foreach (var itemA in Alumnos)
//                //            {
//                //                //var idEstado = Convert.ToInt64(item);
//                //                Estado = Estados.FirstOrDefault(x => x.idEstado == item.idEstado);
//                //                var EstadoCivil = db.CatEstadosCiviles.Find(Book.idEstadoCivil);
//                //                if (itemA.idEstadoCivil == EstadoCivil.idEstadoCivil && itemA.Direcciones.nbEstado.Trim().ToUpper() == Estado.nbEstado.Trim().ToUpper())
//                //                {
//                //                    IndicadoresVM IndicadorECEstados = new IndicadoresVM();
//                //                    IndicadorECEstados.nbCampo = Estado.nbEstado;
//                //                    IndicadorECEstados.nbCampo2 = EstadoCivil.nbEstadoCivil.Trim();
//                //                    IndicadorECEstados.numCampo = 1;
//                //                    IndicadoresEdoCEdos.Add(IndicadorECEstados);
//                //                }
//                //            }
//                //        }
//                //    }

//                //    IndicadoresEdoCEdos.ToList().ForEach(l =>
//                //    {
//                //        var row = dt.NewRow();
//                //        row["nbCategoria"] = l.nbCampo;
//                //        row["nbCategoria2"] = l.nbCampo2;
//                //        row["numDatos"] = l.numCampo;
//                //        dt.Rows.Add(row);
//                //    });

//                //    #endregion
//                //}
//                //else if (listacaCampos[0] == 9 && listacaCampos[1] == 3)
//                //{
//                //    #region

//                //    TituloColumna1 = "Estado";
//                //    TituloColumna2 = "Edad";
//                //    TituloColumna3 = "Cantidad";
//                //    TituloGrafic = "Gráfica de barras por Estado y Edad";
//                //    CatEstados Estado = new CatEstados();
//                //    var Estados = db.CatEstados.ToList();
//                //    List<IndicadoresVM> ListaEdadEstado = new List<IndicadoresVM>();

//                //    if (Book.numEdadMinima != null && Book.numEdadMinima != null && listaIdsestados.Count() > 0)
//                //    {
//                //        for (var i = Book.numEdadMinima; i <= Book.numEdadMaxima; i++)
//                //        {
//                //            foreach (var itemE in listaIdsestados)
//                //            {
//                //                foreach (var item in Alumnos)
//                //                {
//                //                    var idEstado = Convert.ToInt64(itemE);
//                //                    Estado = Estados.FirstOrDefault(x => x.idEstado == idEstado);
//                //                    var edad = DateTime.Now.Year - ((DateTime)item.feNacimiento).Date.Year;
//                //                    if (edad == i && item.idReligion == Estado.idEstado)
//                //                    {
//                //                        IndicadoresVM IndicadorEdadE = new IndicadoresVM();
//                //                        IndicadorEdadE.nbCampo = Estado.nbEstado.Trim();
//                //                        IndicadorEdadE.nbCampo2 = i + " Años";
//                //                        IndicadorEdadE.numCampo = 1;
//                //                        ListaEdadEstado.Add(IndicadorEdadE);
//                //                    }
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (Book.numEdadMinima != null && Book.numEdadMinima != null && listaIdsestados.Count() == 0)
//                //    {
//                //        for (var i = Book.numEdadMinima; i <= Book.numEdadMaxima; i++)
//                //        {
//                //            foreach (var itemE in Estados)
//                //            {
//                //                foreach (var item in Alumnos)
//                //                {
//                //                    //var idEstado = Convert.ToInt64(itemE);
//                //                    //Estado = Estados.FirstOrDefault(x => x.idEstado == idEstado);
//                //                    var edad = DateTime.Now.Year - ((DateTime)item.feNacimiento).Date.Year;
//                //                    if (edad == i && item.idReligion == itemE.idEstado)
//                //                    {
//                //                        IndicadoresVM IndicadorEdadE = new IndicadoresVM();
//                //                        IndicadorEdadE.nbCampo = itemE.nbEstado.Trim();
//                //                        IndicadorEdadE.nbCampo2 = i + " Años";
//                //                        IndicadorEdadE.numCampo = 1;
//                //                        ListaEdadEstado.Add(IndicadorEdadE);
//                //                    }
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (Book.numEdadMinima == null && Book.numEdadMinima == null && listaIdsestados.Count() > 0)
//                //    {
//                //        for (var i = 15; i <= 80; i++)
//                //        {
//                //            foreach (var itemE in listaIdsestados)
//                //            {
//                //                foreach (var item in Alumnos)
//                //                {
//                //                    var idEstado = Convert.ToInt64(itemE);
//                //                    Estado = Estados.FirstOrDefault(x => x.idEstado == idEstado);
//                //                    var edad = DateTime.Now.Year - ((DateTime)item.feNacimiento).Date.Year;
//                //                    if (edad == i && item.idReligion == Estado.idEstado)
//                //                    {
//                //                        IndicadoresVM IndicadorEdadE = new IndicadoresVM();
//                //                        IndicadorEdadE.nbCampo = Estado.nbEstado.Trim();
//                //                        IndicadorEdadE.nbCampo2 = i + " Años";
//                //                        IndicadorEdadE.numCampo = 1;
//                //                        ListaEdadEstado.Add(IndicadorEdadE);
//                //                    }
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (Book.numEdadMinima == null && Book.numEdadMinima == null && listaIdsestados.Count() == 0)
//                //    {
//                //        for (var i = 15; i <= 80; i++)
//                //        {
//                //            foreach (var itemE in Estados)
//                //            {
//                //                foreach (var item in Alumnos)
//                //                {
//                //                    //var idEstado = Convert.ToInt64(itemE);
//                //                    //Estado = Estados.FirstOrDefault(x => x.idEstado == idEstado);
//                //                    var edad = DateTime.Now.Year - ((DateTime)item.feNacimiento).Date.Year;
//                //                    if (edad == i && item.idReligion == itemE.idEstado)
//                //                    {
//                //                        IndicadoresVM IndicadorEdadE = new IndicadoresVM();
//                //                        IndicadorEdadE.nbCampo = itemE.nbEstado.Trim();
//                //                        IndicadorEdadE.nbCampo2 = i + " Años";
//                //                        IndicadorEdadE.numCampo = 1;
//                //                        ListaEdadEstado.Add(IndicadorEdadE);
//                //                    }
//                //                }
//                //            }
//                //        }
//                //    }

//                //    ListaEdadEstado.ToList().ForEach(t =>
//                //    {
//                //        var row = dt.NewRow();
//                //        row["nbCategoria"] = t.nbCampo;
//                //        row["nbCategoria2"] = t.nbCampo2;
//                //        row["numDatos"] = t.numCampo;
//                //        dt.Rows.Add(row);
//                //    });

//                //    #endregion
//                //}
//                //else if (listacaCampos[0] == 9 && listacaCampos[1] == 6)
//                //{
//                //    #region

//                //    TituloColumna1 = "Estado";
//                //    TituloColumna2 = "Género";
//                //    TituloColumna3 = "Cantidad";
//                //    TituloGrafic = "Gráfica de barras por Estado y Género";

//                //    var CatGeneros = db.CatGeneros.ToList();
//                //    CatEstados Estado = new CatEstados();
//                //    var Estados = db.CatEstados.ToList();
//                //    List<IndicadoresVM> IndicadoresGEstados = new List<IndicadoresVM>();

//                //    if (Book.idGenero != null && listaIdsestados.Count > 0)
//                //    {
//                //        foreach (var item in listaIdsestados)
//                //        {
//                //            foreach (var itemA in Alumnos)
//                //            {
//                //                var idEstado = Convert.ToInt64(item);
//                //                Estado = Estados.FirstOrDefault(x => x.idEstado == idEstado);
//                //                var Genero = db.CatGeneros.Find(Book.idGenero);
//                //                if (itemA.Personas.idGenero == Genero.idGenero && itemA.Direcciones.nbEstado.Trim().ToUpper() == Estado.nbEstado.Trim().ToUpper())
//                //                {
//                //                    IndicadoresVM IndicadorGE = new IndicadoresVM();
//                //                    IndicadorGE.nbCampo = Estado.nbEstado;
//                //                    IndicadorGE.nbCampo2 = Genero.nbGenero.Trim();
//                //                    IndicadorGE.numCampo = 1;
//                //                    IndicadoresGEstados.Add(IndicadorGE);
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (Book.idGenero == null && listaIdsestados.Count > 0)
//                //    {
//                //        foreach (var item in listaIdsestados)
//                //        {
//                //            foreach (var itemG in CatGeneros)
//                //            {
//                //                foreach (var itemA in Alumnos)
//                //                {
//                //                    var idEstado = Convert.ToInt64(item);
//                //                    Estado = Estados.FirstOrDefault(x => x.idEstado == idEstado);
//                //                    var Genero = db.CatGeneros.Find(itemG.idGenero);
//                //                    if (itemA.Personas.idGenero == Genero.idGenero && itemA.Direcciones.nbEstado.Trim().ToUpper() == Estado.nbEstado.Trim().ToUpper())
//                //                    {
//                //                        IndicadoresVM IndicadorGE = new IndicadoresVM();
//                //                        IndicadorGE.nbCampo = Estado.nbEstado;
//                //                        IndicadorGE.nbCampo2 = Genero.nbGenero.Trim();
//                //                        IndicadorGE.numCampo = 1;
//                //                        IndicadoresGEstados.Add(IndicadorGE);
//                //                    }
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (Book.idGenero == null && listaIdsestados.Count == 0)
//                //    {
//                //        foreach (var item in Estados)
//                //        {
//                //            foreach (var itemG in CatGeneros)
//                //            {
//                //                foreach (var itemA in Alumnos)
//                //                {
//                //                    //var idEstado = Convert.ToInt64(item);
//                //                    Estado = Estados.FirstOrDefault(x => x.idEstado == item.idEstado);
//                //                    var Genero = db.CatGeneros.Find(itemG.idGenero);
//                //                    if (itemA.Personas.idGenero == Genero.idGenero && itemA.Direcciones.nbEstado.Trim().ToUpper() == Estado.nbEstado.Trim().ToUpper())
//                //                    {
//                //                        IndicadoresVM IndicadorGE = new IndicadoresVM();
//                //                        IndicadorGE.nbCampo = Estado.nbEstado;
//                //                        IndicadorGE.nbCampo2 = Genero.nbGenero.Trim();
//                //                        IndicadorGE.numCampo = 1;
//                //                        IndicadoresGEstados.Add(IndicadorGE);
//                //                    }
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (Book.idGenero != null && listaIdsestados.Count == 0)
//                //    {
//                //        foreach (var item in Estados)
//                //        {
//                //            foreach (var itemA in Alumnos)
//                //            {
//                //                //var idEstado = Convert.ToInt64(item);
//                //                Estado = Estados.FirstOrDefault(x => x.idEstado == item.idEstado);
//                //                var Genero = db.CatGeneros.Find(Book.idGenero);
//                //                if (itemA.Personas.idGenero == Genero.idGenero && itemA.Direcciones.nbEstado.Trim().ToUpper() == Estado.nbEstado.Trim().ToUpper())
//                //                {
//                //                    IndicadoresVM IndicadorGE = new IndicadoresVM();
//                //                    IndicadorGE.nbCampo = Estado.nbEstado;
//                //                    IndicadorGE.nbCampo2 = Genero.nbGenero.Trim();
//                //                    IndicadorGE.numCampo = 1;
//                //                    IndicadoresGEstados.Add(IndicadorGE);
//                //                }
//                //            }
//                //        }
//                //    }

//                //    IndicadoresGEstados.ToList().ForEach(l =>
//                //    {
//                //        var row = dt.NewRow();
//                //        row["nbCategoria"] = l.nbCampo;
//                //        row["nbCategoria2"] = l.nbCampo2;
//                //        row["numDatos"] = l.numCampo;
//                //        dt.Rows.Add(row);
//                //    });

//                //    #endregion
//                //}
//                //else if (listacaCampos[0] == 9 && listacaCampos[1] == 7)
//                //{
//                //    #region

//                //    TituloColumna1 = "Estado";
//                //    TituloColumna2 = "Licenciatura";
//                //    TituloColumna3 = "Cantidad";
//                //    TituloGrafic = "Gráfica de barras por Estado y Licenciatura";

//                //    Licenciaturas Licenciatura = new Licenciaturas();
//                //    var Licenciaturas = db.Licenciaturas.ToList();
//                //    CatEstados Estado = new CatEstados();
//                //    var Estados = db.CatEstados.ToList();

//                //    List<IndicadoresVM> IndicadoresLicEdos = new List<IndicadoresVM>();

//                //    if (listaIdsLicenciaturas.Count() > 0 && listaIdsestados.Count() > 0)
//                //    {
//                //        foreach (var itemL in listaIdsLicenciaturas)
//                //        {
//                //            foreach (var itemE in listaIdsestados)
//                //            {
//                //                foreach (var item in Alumnos)
//                //                {
//                //                    var idLicenciatura = Convert.ToInt64(itemL);
//                //                    Licenciatura = Licenciaturas.FirstOrDefault(x => x.idLicenciatura == idLicenciatura);
//                //                    var idEstado = Convert.ToInt64(itemE);
//                //                    Estado = db.CatEstados.Find(idEstado);
//                //                    var FormacionesA = db.FormacionesAcademicas.Where(x => x.idAlumno == item.idAlumno && x.idLicenciatura == Licenciatura.idLicenciatura).ToList();
//                //                    if (item.Direcciones.nbEstado == Estado.nbEstado && FormacionesA.Count() > 0)
//                //                    {
//                //                        IndicadoresVM IndicadorLE = new IndicadoresVM();
//                //                        IndicadorLE.nbCampo = Estado.nbEstado;
//                //                        IndicadorLE.nbCampo2 = Licenciatura.nbLicenciatura;
//                //                        IndicadorLE.numCampo = 1;
//                //                        IndicadoresLicEdos.Add(IndicadorLE);
//                //                    }
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (listaIdsLicenciaturas.Count() > 0 && listaIdsestados.Count() == 0)
//                //    {
//                //        foreach (var itemL in listaIdsLicenciaturas)
//                //        {
//                //            foreach (var itemE in Estados)
//                //            {
//                //                foreach (var item in Alumnos)
//                //                {
//                //                    var idLicenciatura = Convert.ToInt64(itemL);
//                //                    Licenciatura = Licenciaturas.FirstOrDefault(x => x.idLicenciatura == idLicenciatura);
//                //                    //var idEstado = Convert.ToInt64(itemE);
//                //                    Estado = db.CatEstados.Find(itemE.idEstado);
//                //                    var FormacionesA = db.FormacionesAcademicas.Where(x => x.idAlumno == item.idAlumno && x.idLicenciatura == Licenciatura.idLicenciatura).ToList();
//                //                    if (item.Direcciones.nbEstado == Estado.nbEstado && FormacionesA.Count() > 0)
//                //                    {
//                //                        IndicadoresVM IndicadorLE = new IndicadoresVM();
//                //                        IndicadorLE.nbCampo = Estado.nbEstado;
//                //                        IndicadorLE.nbCampo2 = Licenciatura.nbLicenciatura;
//                //                        IndicadorLE.numCampo = 1;
//                //                        IndicadoresLicEdos.Add(IndicadorLE);
//                //                    }
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (listaIdsLicenciaturas.Count() == 0 && listaIdsestados.Count() > 0)
//                //    {
//                //        foreach (var itemL in Licenciaturas)
//                //        {
//                //            foreach (var itemE in listaIdsestados)
//                //            {
//                //                foreach (var item in Alumnos)
//                //                {
//                //                    //var idLicenciatura = Convert.ToInt64(itemL);
//                //                    Licenciatura = Licenciaturas.FirstOrDefault(x => x.idLicenciatura == itemL.idLicenciatura);
//                //                    var idEstado = Convert.ToInt64(itemE);
//                //                    Estado = db.CatEstados.Find(idEstado);
//                //                    var FormacionesA = db.FormacionesAcademicas.Where(x => x.idAlumno == item.idAlumno && x.idLicenciatura == Licenciatura.idLicenciatura).ToList();
//                //                    if (item.Direcciones.nbEstado == Estado.nbEstado && FormacionesA.Count() > 0)
//                //                    {
//                //                        IndicadoresVM IndicadorLE = new IndicadoresVM();
//                //                        IndicadorLE.nbCampo = Estado.nbEstado;
//                //                        IndicadorLE.nbCampo2 = Licenciatura.nbLicenciatura;
//                //                        IndicadorLE.numCampo = 1;
//                //                        IndicadoresLicEdos.Add(IndicadorLE);
//                //                    }
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (listaIdsLicenciaturas.Count() == 0 && listaIdsestados.Count() == 0)
//                //    {
//                //        foreach (var itemL in Licenciaturas)
//                //        {
//                //            foreach (var itemE in Estados)
//                //            {
//                //                foreach (var item in Alumnos)
//                //                {
//                //                    //var idLicenciatura = Convert.ToInt64(itemL);
//                //                    Licenciatura = Licenciaturas.FirstOrDefault(x => x.idLicenciatura == itemL.idLicenciatura);
//                //                    //var idEstado = Convert.ToInt64(itemE);
//                //                    Estado = db.CatEstados.Find(itemE.idEstado);
//                //                    var FormacionesA = db.FormacionesAcademicas.Where(x => x.idAlumno == item.idAlumno && x.idLicenciatura == Licenciatura.idLicenciatura).ToList();
//                //                    if (item.Direcciones.nbEstado == Estado.nbEstado && FormacionesA.Count() > 0)
//                //                    {
//                //                        IndicadoresVM IndicadorLE = new IndicadoresVM();
//                //                        IndicadorLE.nbCampo = Estado.nbEstado;
//                //                        IndicadorLE.nbCampo2 = Licenciatura.nbLicenciatura;
//                //                        IndicadorLE.numCampo = 1;
//                //                        IndicadoresLicEdos.Add(IndicadorLE);
//                //                    }
//                //                }
//                //            }
//                //        }
//                //    }

//                //    IndicadoresLicEdos.ToList().ForEach(l =>
//                //    {
//                //        var row = dt.NewRow();
//                //        row["nbCategoria"] = l.nbCampo;
//                //        row["nbCategoria2"] = l.nbCampo2;
//                //        row["numDatos"] = l.numCampo;
//                //        dt.Rows.Add(row);
//                //    });
//                //    #endregion
//                //}
//                //else if (listacaCampos[0] == 9 && listacaCampos[1] == 8)
//                //{
//                //    #region

//                //    TituloColumna1 = "Estado";
//                //    TituloColumna2 = "Religión";
//                //    TituloColumna3 = "Cantidad";
//                //    TituloGrafic = "Gráfica de barras por Estado y Religión";


//                //    CatReligion Religion = new CatReligion();
//                //    var Religiones = db.CatReligion.ToList();
//                //    CatEstados Estado = new CatEstados();
//                //    var Estados = db.CatEstados.ToList();

//                //    List<IndicadoresVM> IndicadoresRelEdos = new List<IndicadoresVM>();

//                //    if (listaIdsReligiones.Count() > 0 && listaIdsestados.Count() > 0)
//                //    {
//                //        foreach (var itemR in listaIdsReligiones)
//                //        {
//                //            foreach (var itemE in listaIdsestados)
//                //            {
//                //                foreach (var item in Alumnos)
//                //                {
//                //                    var idReligion = Convert.ToInt64(itemR);
//                //                    Religion = Religiones.FirstOrDefault(x => x.idReligion == idReligion);
//                //                    var idEstado = Convert.ToInt64(itemE);
//                //                    Estado = Estados.FirstOrDefault(x => x.idEstado == idEstado);
//                //                    if (item.idReligion == Religion.idReligion && item.Direcciones.nbEstado == Estado.nbEstado)
//                //                    {
//                //                        IndicadoresVM IndicadorRE = new IndicadoresVM();
//                //                        IndicadorRE.nbCampo = Estado.nbEstado;
//                //                        IndicadorRE.nbCampo2 = Religion.nbReligion;
//                //                        IndicadorRE.numCampo = 1;
//                //                        IndicadoresRelEdos.Add(IndicadorRE);
//                //                    }
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (listaIdsReligiones.Count() > 0 && listaIdsestados.Count() == 0)
//                //    {
//                //        foreach (var itemR in listaIdsReligiones)
//                //        {
//                //            foreach (var itemE in Estados)
//                //            {
//                //                foreach (var item in Alumnos)
//                //                {
//                //                    var idReligion = Convert.ToInt64(itemR);
//                //                    Religion = Religiones.FirstOrDefault(x => x.idReligion == idReligion);
//                //                    //var idEstado = Convert.ToInt64(itemE);
//                //                    Estado = Estados.FirstOrDefault(x => x.idEstado == itemE.idEstado);
//                //                    if (item.idReligion == Religion.idReligion && item.Direcciones.nbEstado == Estado.nbEstado)
//                //                    {
//                //                        IndicadoresVM IndicadorRE = new IndicadoresVM();
//                //                        IndicadorRE.nbCampo = Estado.nbEstado;
//                //                        IndicadorRE.nbCampo2 = Religion.nbReligion;
//                //                        IndicadorRE.numCampo = 1;
//                //                        IndicadoresRelEdos.Add(IndicadorRE);
//                //                    }
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (listaIdsReligiones.Count() == 0 && listaIdsestados.Count() > 0)
//                //    {
//                //        foreach (var itemR in Religiones)
//                //        {
//                //            foreach (var itemE in listaIdsestados)
//                //            {
//                //                foreach (var item in Alumnos)
//                //                {
//                //                    //var idReligion = Convert.ToInt64(itemR);
//                //                    Religion = Religiones.FirstOrDefault(x => x.idReligion == itemR.idReligion);
//                //                    var idEstado = Convert.ToInt64(itemE);
//                //                    Estado = Estados.FirstOrDefault(x => x.idEstado == idEstado);
//                //                    if (item.idReligion == Religion.idReligion && item.Direcciones.nbEstado == Estado.nbEstado)
//                //                    {
//                //                        IndicadoresVM IndicadorRE = new IndicadoresVM();
//                //                        IndicadorRE.nbCampo = Estado.nbEstado;
//                //                        IndicadorRE.nbCampo2 = Religion.nbReligion;
//                //                        IndicadorRE.numCampo = 1;
//                //                        IndicadoresRelEdos.Add(IndicadorRE);
//                //                    }
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (listaIdsReligiones.Count() == 0 && listaIdsestados.Count() == 0)
//                //    {
//                //        foreach (var itemR in Religiones)
//                //        {
//                //            foreach (var itemE in Estados)
//                //            {
//                //                foreach (var item in Alumnos)
//                //                {
//                //                    //var idReligion = Convert.ToInt64(itemR);
//                //                    Religion = Religiones.FirstOrDefault(x => x.idReligion == itemR.idReligion);
//                //                    //var idEstado = Convert.ToInt64(itemE);
//                //                    Estado = Estados.FirstOrDefault(x => x.idEstado == itemE.idEstado);
//                //                    if (item.idReligion == Religion.idReligion && item.Direcciones.nbEstado == Estado.nbEstado)
//                //                    {
//                //                        IndicadoresVM IndicadorRE = new IndicadoresVM();
//                //                        IndicadorRE.nbCampo = Estado.nbEstado;
//                //                        IndicadorRE.nbCampo2 = Religion.nbReligion;
//                //                        IndicadorRE.numCampo = 1;
//                //                        IndicadoresRelEdos.Add(IndicadorRE);
//                //                    }
//                //                }
//                //            }
//                //        }
//                //    }

//                //    IndicadoresRelEdos.ToList().ForEach(l =>
//                //    {
//                //        var row = dt.NewRow();
//                //        row["nbCategoria"] = l.nbCampo;
//                //        row["nbCategoria2"] = l.nbCampo2;
//                //        row["numDatos"] = l.numCampo;
//                //        dt.Rows.Add(row);
//                //    });

//                //    #endregion
//                //}
//                //else if (listacaCampos[0] == 9 && listacaCampos[1] == 10)
//                //{
//                //    #region

//                //    TituloColumna1 = "Estado";
//                //    TituloColumna2 = "Trabajo";
//                //    TituloColumna3 = "Cantidad";
//                //    TituloGrafic = "Gráfica de barras por Estado y Trabajo";

//                //    CatEstados Estado = new CatEstados();
//                //    var Estados = db.CatEstados.ToList();

//                //    List<IndicadoresVM> IndicadoresEdosTrab = new List<IndicadoresVM>();

//                //    if (listaIdsestados.Count() > 0 && Book.fgTrabajaActualmente != null)
//                //    {
//                //        foreach (var itemE in listaIdsestados)
//                //        {
//                //            foreach (var itemA in Alumnos)
//                //            {
//                //                var idEstado = Convert.ToInt64(itemE);
//                //                Estado = Estados.FirstOrDefault(x => x.idEstado == idEstado);
//                //                if (itemA.fgTrabajaActualmente == Book.fgTrabajaActualmente && itemA.Direcciones.nbEstado.Trim().ToUpper() == Estado.nbEstado.Trim().ToUpper())
//                //                {
//                //                    IndicadoresVM IndicadorRT = new IndicadoresVM();
//                //                    IndicadorRT.nbCampo = Estado.nbEstado;
//                //                    IndicadorRT.nbCampo2 = (Book.fgTrabajaActualmente == true) ? "SI" : "NO";
//                //                    IndicadorRT.numCampo = 1;
//                //                    IndicadoresEdosTrab.Add(IndicadorRT);
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (listaIdsestados.Count() > 0 && Book.fgTrabajaActualmente == null)
//                //    {
//                //        foreach (var itemE in listaIdsestados)
//                //        {
//                //            foreach (var itemA in Alumnos)
//                //            {
//                //                var idEstado = Convert.ToInt64(itemE);
//                //                Estado = Estados.FirstOrDefault(x => x.idEstado == idEstado);
//                //                if (itemA.fgTrabajaActualmente == true && itemA.Direcciones.nbEstado.Trim().ToUpper() == Estado.nbEstado.Trim().ToUpper())
//                //                {
//                //                    IndicadoresVM IndicadorRT = new IndicadoresVM();
//                //                    IndicadorRT.nbCampo = Estado.nbEstado;
//                //                    IndicadorRT.nbCampo2 = "SI";
//                //                    IndicadorRT.numCampo = 1;
//                //                    IndicadoresEdosTrab.Add(IndicadorRT);
//                //                }
//                //                else if (itemA.fgTrabajaActualmente == false && itemA.Direcciones.nbEstado.Trim().ToUpper() == Estado.nbEstado.Trim().ToUpper())
//                //                {
//                //                    IndicadoresVM IndicadorRNT = new IndicadoresVM();
//                //                    IndicadorRNT.nbCampo = Estado.nbEstado;
//                //                    IndicadorRNT.nbCampo2 = "NO";
//                //                    IndicadorRNT.numCampo = 1;
//                //                    IndicadoresEdosTrab.Add(IndicadorRNT);
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (listaIdsestados.Count() == 0 && Book.fgTrabajaActualmente != null)
//                //    {
//                //        foreach (var itemE in Estados)
//                //        {
//                //            foreach (var itemA in Alumnos)
//                //            {
//                //                //var idEstado = Convert.ToInt64(itemE);
//                //                Estado = Estados.FirstOrDefault(x => x.idEstado == itemE.idEstado);
//                //                if (itemA.fgTrabajaActualmente == Book.fgTrabajaActualmente && itemA.Direcciones.nbEstado.Trim().ToUpper() == Estado.nbEstado.Trim().ToUpper())
//                //                {
//                //                    IndicadoresVM IndicadorRT = new IndicadoresVM();
//                //                    IndicadorRT.nbCampo = Estado.nbEstado;
//                //                    IndicadorRT.nbCampo2 = (Book.fgTrabajaActualmente == true) ? "SI" : "NO";
//                //                    IndicadorRT.numCampo = 1;
//                //                    IndicadoresEdosTrab.Add(IndicadorRT);
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (listaIdsestados.Count() == 0 && Book.fgTrabajaActualmente == null)
//                //    {
//                //        foreach (var itemE in Estados)
//                //        {
//                //            foreach (var itemA in Alumnos)
//                //            {
//                //                //var idEstado = Convert.ToInt64(itemE);
//                //                Estado = Estados.FirstOrDefault(x => x.idEstado == itemE.idEstado);
//                //                if (itemA.fgTrabajaActualmente == true && itemA.Direcciones.nbEstado.Trim().ToUpper() == Estado.nbEstado.Trim().ToUpper())
//                //                {
//                //                    IndicadoresVM IndicadorRT = new IndicadoresVM();
//                //                    IndicadorRT.nbCampo = Estado.nbEstado;
//                //                    IndicadorRT.nbCampo2 = "SI";
//                //                    IndicadorRT.numCampo = 1;
//                //                    IndicadoresEdosTrab.Add(IndicadorRT);
//                //                }
//                //                else if (itemA.fgTrabajaActualmente == false && itemA.Direcciones.nbEstado.Trim().ToUpper() == Estado.nbEstado.Trim().ToUpper())
//                //                {
//                //                    IndicadoresVM IndicadorRNT = new IndicadoresVM();
//                //                    IndicadorRNT.nbCampo = Estado.nbEstado;
//                //                    IndicadorRNT.nbCampo2 = "NO";
//                //                    IndicadorRNT.numCampo = 1;
//                //                    IndicadoresEdosTrab.Add(IndicadorRNT);
//                //                }
//                //            }
//                //        }
//                //    }

//                //    IndicadoresEdosTrab.ToList().ForEach(l =>
//                //    {
//                //        var row = dt.NewRow();
//                //        row["nbCategoria"] = l.nbCampo;
//                //        row["nbCategoria2"] = l.nbCampo2;
//                //        row["numDatos"] = l.numCampo;
//                //        dt.Rows.Add(row);
//                //    });

//                //    #endregion
//                //}
//                //else if (listacaCampos[0] == 9 && listacaCampos[1] == 11)
//                //{
//                //    #region

//                //    TituloColumna1 = "Estado";
//                //    TituloColumna2 = "Tipo de Sangre";
//                //    TituloColumna3 = "Cantidad";
//                //    TituloGrafic = "Gráfica de barras por Estado y Tipo de Sangre";

//                //    var Estado = new CatEstados();
//                //    var Estados = db.CatEstados.ToList();
//                //    var CatTiposSangre = db.CatTiposSangre.ToList();
//                //    List<IndicadoresVM> IndicadoresEdosSangre = new List<IndicadoresVM>();
//                //    if (Book.idTipoSangre != null && listaIdsestados.Count > 0)
//                //    {
//                //        foreach (var item in listaIdsestados)
//                //        {
//                //            foreach (var itemA in Alumnos)
//                //            {
//                //                var idEstado = Convert.ToInt64(item);
//                //                Estado = Estados.FirstOrDefault(x => x.idEstado == idEstado);
//                //                var TipoSangre = db.CatTiposSangre.Find(Book.idTipoSangre);
//                //                if (itemA.idTipoSangre == TipoSangre.idTipoSangre && itemA.Direcciones.nbEstado.Trim().ToUpper() == Estado.nbEstado.Trim().ToUpper())
//                //                {
//                //                    IndicadoresVM IndicadorES = new IndicadoresVM();
//                //                    IndicadorES.nbCampo = Estado.nbEstado;
//                //                    IndicadorES.nbCampo2 = TipoSangre.nbTipoSangre.Trim();
//                //                    IndicadorES.numCampo = 1;
//                //                    IndicadoresEdosSangre.Add(IndicadorES);
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (Book.idTipoSangre == null && listaIdsestados.Count > 0)
//                //    {
//                //        foreach (var item in listaIdsestados)
//                //        {
//                //            foreach (var itemS in CatTiposSangre)
//                //            {
//                //                foreach (var itemA in Alumnos)
//                //                {
//                //                    var idEstado = Convert.ToInt64(item);
//                //                    Estado = Estados.FirstOrDefault(x => x.idEstado == idEstado);
//                //                    var TipoSangre = db.CatTiposSangre.Find(itemS.idTipoSangre);
//                //                    if (itemA.idTipoSangre == TipoSangre.idTipoSangre && itemA.Direcciones.nbEstado.Trim().ToUpper() == Estado.nbEstado.Trim().ToUpper())
//                //                    {
//                //                        IndicadoresVM IndicadorES = new IndicadoresVM();
//                //                        IndicadorES.nbCampo = Estado.nbEstado;
//                //                        IndicadorES.nbCampo2 = TipoSangre.nbTipoSangre.Trim();
//                //                        IndicadorES.numCampo = 1;
//                //                        IndicadoresEdosSangre.Add(IndicadorES);
//                //                    }
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (Book.idTipoSangre == null && listaIdsestados.Count == 0)
//                //    {
//                //        foreach (var item in Estados)
//                //        {
//                //            foreach (var itemS in CatTiposSangre)
//                //            {
//                //                foreach (var itemA in Alumnos)
//                //                {
//                //                    //var idEstado = Convert.ToInt64(item);
//                //                    Estado = Estados.FirstOrDefault(x => x.idEstado == item.idEstado);
//                //                    var TipoSangre = db.CatTiposSangre.Find(itemS.idTipoSangre);
//                //                    if (itemA.idTipoSangre == TipoSangre.idTipoSangre && itemA.Direcciones.nbEstado.Trim().ToUpper() == Estado.nbEstado.Trim().ToUpper())
//                //                    {
//                //                        IndicadoresVM IndicadorES = new IndicadoresVM();
//                //                        IndicadorES.nbCampo = Estado.nbEstado;
//                //                        IndicadorES.nbCampo2 = TipoSangre.nbTipoSangre.Trim();
//                //                        IndicadorES.numCampo = 1;
//                //                        IndicadoresEdosSangre.Add(IndicadorES);
//                //                    }
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (Book.idTipoSangre != null && listaIdsestados.Count == 0)
//                //    {
//                //        foreach (var item in Estados)
//                //        {
//                //            foreach (var itemA in Alumnos)
//                //            {
//                //                //var idEstado = Convert.ToInt64(item);
//                //                Estado = Estados.FirstOrDefault(x => x.idEstado == item.idEstado);
//                //                var TipoSangre = db.CatTiposSangre.Find(Book.idTipoSangre);
//                //                if (itemA.idTipoSangre == TipoSangre.idTipoSangre && itemA.Direcciones.nbEstado.Trim().ToUpper() == Estado.nbEstado.Trim().ToUpper())
//                //                {
//                //                    IndicadoresVM IndicadorES = new IndicadoresVM();
//                //                    IndicadorES.nbCampo = Estado.nbEstado;
//                //                    IndicadorES.nbCampo2 = TipoSangre.nbTipoSangre.Trim();
//                //                    IndicadorES.numCampo = 1;
//                //                    IndicadoresEdosSangre.Add(IndicadorES);
//                //                }
//                //            }
//                //        }
//                //    }

//                //    IndicadoresEdosSangre.ToList().ForEach(l =>
//                //    {
//                //        var row = dt.NewRow();
//                //        row["nbCategoria"] = l.nbCampo;
//                //        row["nbCategoria2"] = l.nbCampo2;
//                //        row["numDatos"] = l.numCampo;
//                //        dt.Rows.Add(row);
//                //    });

//                //    #endregion
//                //}
//                //else if (listacaCampos[0] == 9 && listacaCampos[1] == 12)
//                //{
//                //    #region

//                //    TituloColumna1 = "Estado";
//                //    TituloColumna2 = "Licencia";
//                //    TituloColumna3 = "Cantidad";
//                //    TituloGrafic = "Gráfica de barras por Estado y Licencia";

//                //    CatEstados Estado = new CatEstados();
//                //    var Estados = db.CatEstados.ToList();

//                //    List<IndicadoresVM> IndicadoresEdosLic = new List<IndicadoresVM>();

//                //    if (listaIdsestados.Count() > 0 && Book.fgLicencia != null)
//                //    {
//                //        foreach (var itemE in listaIdsestados)
//                //        {
//                //            foreach (var itemA in Alumnos)
//                //            {
//                //                var idEstado = Convert.ToInt64(itemE);
//                //                Estado = Estados.FirstOrDefault(x => x.idEstado == idEstado);
//                //                if (itemA.fgLicencia == Book.fgLicencia && itemA.Direcciones.nbEstado.Trim().ToUpper() == Estado.nbEstado.Trim().ToUpper())
//                //                {
//                //                    IndicadoresVM IndicadorRT = new IndicadoresVM();
//                //                    IndicadorRT.nbCampo = Estado.nbEstado;
//                //                    IndicadorRT.nbCampo2 = (Book.fgLicencia == true) ? "SI" : "NO";
//                //                    IndicadorRT.numCampo = 1;
//                //                    IndicadoresEdosLic.Add(IndicadorRT);
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (listaIdsestados.Count() > 0 && Book.fgLicencia == null)
//                //    {
//                //        foreach (var itemE in listaIdsestados)
//                //        {
//                //            foreach (var itemA in Alumnos)
//                //            {
//                //                var idEstado = Convert.ToInt64(itemE);
//                //                Estado = Estados.FirstOrDefault(x => x.idEstado == idEstado);
//                //                if (itemA.fgLicencia == true && itemA.Direcciones.nbEstado.Trim().ToUpper() == Estado.nbEstado.Trim().ToUpper())
//                //                {
//                //                    IndicadoresVM IndicadorRT = new IndicadoresVM();
//                //                    IndicadorRT.nbCampo = Estado.nbEstado;
//                //                    IndicadorRT.nbCampo2 = "SI";
//                //                    IndicadorRT.numCampo = 1;
//                //                    IndicadoresEdosLic.Add(IndicadorRT);
//                //                }
//                //                else if (itemA.fgLicencia == false && itemA.Direcciones.nbEstado.Trim().ToUpper() == Estado.nbEstado.Trim().ToUpper())
//                //                {
//                //                    IndicadoresVM IndicadorRNT = new IndicadoresVM();
//                //                    IndicadorRNT.nbCampo = Estado.nbEstado;
//                //                    IndicadorRNT.nbCampo2 = "NO";
//                //                    IndicadorRNT.numCampo = 1;
//                //                    IndicadoresEdosLic.Add(IndicadorRNT);
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (listaIdsestados.Count() == 0 && Book.fgLicencia != null)
//                //    {
//                //        foreach (var itemE in Estados)
//                //        {
//                //            foreach (var itemA in Alumnos)
//                //            {
//                //                //var idEstado = Convert.ToInt64(itemE);
//                //                Estado = Estados.FirstOrDefault(x => x.idEstado == itemE.idEstado);
//                //                if (itemA.fgLicencia == Book.fgLicencia && itemA.Direcciones.nbEstado.Trim().ToUpper() == Estado.nbEstado.Trim().ToUpper())
//                //                {
//                //                    IndicadoresVM IndicadorRT = new IndicadoresVM();
//                //                    IndicadorRT.nbCampo = Estado.nbEstado;
//                //                    IndicadorRT.nbCampo2 = (Book.fgLicencia == true) ? "SI" : "NO";
//                //                    IndicadorRT.numCampo = 1;
//                //                    IndicadoresEdosLic.Add(IndicadorRT);
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (listaIdsestados.Count() == 0 && Book.fgLicencia == null)
//                //    {
//                //        foreach (var itemE in Estados)
//                //        {
//                //            foreach (var itemA in Alumnos)
//                //            {
//                //                //var idEstado = Convert.ToInt64(itemE);
//                //                Estado = Estados.FirstOrDefault(x => x.idEstado == itemE.idEstado);
//                //                if (itemA.fgLicencia == true && itemA.Direcciones.nbEstado.Trim().ToUpper() == Estado.nbEstado.Trim().ToUpper())
//                //                {
//                //                    IndicadoresVM IndicadorRT = new IndicadoresVM();
//                //                    IndicadorRT.nbCampo = Estado.nbEstado;
//                //                    IndicadorRT.nbCampo2 = "SI";
//                //                    IndicadorRT.numCampo = 1;
//                //                    IndicadoresEdosLic.Add(IndicadorRT);
//                //                }
//                //                else if (itemA.fgLicencia == false && itemA.Direcciones.nbEstado.Trim().ToUpper() == Estado.nbEstado.Trim().ToUpper())
//                //                {
//                //                    IndicadoresVM IndicadorRNT = new IndicadoresVM();
//                //                    IndicadorRNT.nbCampo = Estado.nbEstado;
//                //                    IndicadorRNT.nbCampo2 = "NO";
//                //                    IndicadorRNT.numCampo = 1;
//                //                    IndicadoresEdosLic.Add(IndicadorRNT);
//                //                }
//                //            }
//                //        }
//                //    }

//                //    IndicadoresEdosLic.ToList().ForEach(l =>
//                //    {
//                //        var row = dt.NewRow();
//                //        row["nbCategoria"] = l.nbCampo;
//                //        row["nbCategoria2"] = l.nbCampo2;
//                //        row["numDatos"] = l.numCampo;
//                //        dt.Rows.Add(row);
//                //    });

//                //    #endregion
//                //}
//                //else if (listacaCampos[0] == 9 && listacaCampos[1] == 13)
//                //{
//                //    #region

//                //    TituloColumna1 = "Estado";
//                //    TituloColumna2 = "Tipo de Egresado";
//                //    TituloColumna3 = "Cantidad";
//                //    TituloGrafic = "Gráfica de barras por Estado y Tipo de Egresado";

//                //    CatEstados Estado = new CatEstados();
//                //    var Estados = db.CatEstados.ToList();

//                //    List<IndicadoresVM> IndicadoresEdosEgresados = new List<IndicadoresVM>();

//                //    if (listaIdsestados.Count() > 0 && Book.tpEgresado != null)
//                //    {
//                //        foreach (var itemE in listaIdsestados)
//                //        {
//                //            foreach (var itemA in Alumnos)
//                //            {
//                //                var idEstado = Convert.ToInt64(itemE);
//                //                Estado = Estados.FirstOrDefault(x => x.idEstado == idEstado);
//                //                if (itemA.tpEgresado == Book.tpEgresado && itemA.Direcciones.nbEstado.Trim().ToUpper() == Estado.nbEstado.Trim().ToUpper())
//                //                {
//                //                    IndicadoresVM IndicadorEE = new IndicadoresVM();
//                //                    IndicadorEE.nbCampo = Estado.nbEstado;
//                //                    IndicadorEE.nbCampo2 = (Book.tpEgresado == "T") ? "Titulado" : "Pasante";
//                //                    IndicadorEE.numCampo = 1;
//                //                    IndicadoresEdosEgresados.Add(IndicadorEE);
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (listaIdsestados.Count() > 0 && Book.tpEgresado == null)
//                //    {
//                //        foreach (var itemE in listaIdsestados)
//                //        {
//                //            foreach (var itemA in Alumnos)
//                //            {
//                //                var idEstado = Convert.ToInt64(itemE);
//                //                Estado = Estados.FirstOrDefault(x => x.idEstado == idEstado);
//                //                if (itemA.tpEgresado == "T" && itemA.Direcciones.nbEstado.Trim().ToUpper() == Estado.nbEstado.Trim().ToUpper())
//                //                {
//                //                    IndicadoresVM IndicadorEE = new IndicadoresVM();
//                //                    IndicadorEE.nbCampo = Estado.nbEstado;
//                //                    IndicadorEE.nbCampo2 = "Titulado";
//                //                    IndicadorEE.numCampo = 1;
//                //                    IndicadoresEdosEgresados.Add(IndicadorEE);
//                //                }
//                //                else if (itemA.tpEgresado == "P" && itemA.Direcciones.nbEstado.Trim().ToUpper() == Estado.nbEstado.Trim().ToUpper())
//                //                {
//                //                    IndicadoresVM IndicadorENE = new IndicadoresVM();
//                //                    IndicadorENE.nbCampo = Estado.nbEstado;
//                //                    IndicadorENE.nbCampo2 = "Pasante";
//                //                    IndicadorENE.numCampo = 1;
//                //                    IndicadoresEdosEgresados.Add(IndicadorENE);
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (listaIdsestados.Count() == 0 && Book.tpEgresado != null)
//                //    {
//                //        foreach (var itemE in Estados)
//                //        {
//                //            foreach (var itemA in Alumnos)
//                //            {
//                //                //var idEstado = Convert.ToInt64(itemE);
//                //                Estado = Estados.FirstOrDefault(x => x.idEstado == itemE.idEstado);
//                //                if (itemA.tpEgresado == Book.tpEgresado && itemA.Direcciones.nbEstado.Trim().ToUpper() == Estado.nbEstado.Trim().ToUpper())
//                //                {
//                //                    IndicadoresVM IndicadorEE = new IndicadoresVM();
//                //                    IndicadorEE.nbCampo = Estado.nbEstado;
//                //                    IndicadorEE.nbCampo2 = (Book.tpEgresado == "T") ? "Titulado" : "Pasante";
//                //                    IndicadorEE.numCampo = 1;
//                //                    IndicadoresEdosEgresados.Add(IndicadorEE);
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (listaIdsestados.Count() == 0 && Book.tpEgresado == null)
//                //    {
//                //        foreach (var itemE in Estados)
//                //        {
//                //            foreach (var itemA in Alumnos)
//                //            {
//                //                //var idEstado = Convert.ToInt64(itemE);
//                //                Estado = Estados.FirstOrDefault(x => x.idEstado == itemE.idEstado);
//                //                if (itemA.tpEgresado == "T" && itemA.Direcciones.nbEstado.Trim().ToUpper() == Estado.nbEstado.Trim().ToUpper())
//                //                {
//                //                    IndicadoresVM IndicadorEE = new IndicadoresVM();
//                //                    IndicadorEE.nbCampo = Estado.nbEstado;
//                //                    IndicadorEE.nbCampo2 = "Titulado";
//                //                    IndicadorEE.numCampo = 1;
//                //                    IndicadoresEdosEgresados.Add(IndicadorEE);
//                //                }
//                //                else if (itemA.tpEgresado == "P" && itemA.Direcciones.nbEstado.Trim().ToUpper() == Estado.nbEstado.Trim().ToUpper())
//                //                {
//                //                    IndicadoresVM IndicadorENE = new IndicadoresVM();
//                //                    IndicadorENE.nbCampo = Estado.nbEstado;
//                //                    IndicadorENE.nbCampo2 = "Pasante";
//                //                    IndicadorENE.numCampo = 1;
//                //                    IndicadoresEdosEgresados.Add(IndicadorENE);
//                //                }
//                //            }
//                //        }
//                //    }

//                //    IndicadoresEdosEgresados.ToList().ForEach(l =>
//                //    {
//                //        var row = dt.NewRow();
//                //        row["nbCategoria"] = l.nbCampo;
//                //        row["nbCategoria2"] = l.nbCampo2;
//                //        row["numDatos"] = l.numCampo;
//                //        dt.Rows.Add(row);
//                //    });

//                //    #endregion
//                //}
//                //else if (listacaCampos[0] == 9 && listacaCampos[1] == 14)
//                //{
//                //    #region

//                //    TituloColumna1 = "Estado";
//                //    TituloColumna2 = "Fallecimiento";
//                //    TituloColumna3 = "Cantidad";
//                //    TituloGrafic = "Gráfica de barras por Estado y Fallecimiento";

//                //    CatEstados Estado = new CatEstados();
//                //    var Estados = db.CatEstados.ToList();

//                //    List<IndicadoresVM> IndicadoresEdosFallecido = new List<IndicadoresVM>();

//                //    if (listaIdsestados.Count() > 0 && Book.fgFallecido != null)
//                //    {
//                //        foreach (var itemE in listaIdsestados)
//                //        {
//                //            foreach (var itemA in Alumnos)
//                //            {
//                //                var idEstado = Convert.ToInt64(itemE);
//                //                Estado = Estados.FirstOrDefault(x => x.idEstado == idEstado);
//                //                if (itemA.fgFallecido == Book.fgFallecido && itemA.Direcciones.nbEstado.Trim().ToUpper() == Estado.nbEstado.Trim().ToUpper())
//                //                {
//                //                    IndicadoresVM IndicadorRT = new IndicadoresVM();
//                //                    IndicadorRT.nbCampo = Estado.nbEstado;
//                //                    IndicadorRT.nbCampo2 = (Book.fgFallecido == true) ? "SI" : "NO";
//                //                    IndicadorRT.numCampo = 1;
//                //                    IndicadoresEdosFallecido.Add(IndicadorRT);
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (listaIdsestados.Count() > 0 && Book.fgFallecido == null)
//                //    {
//                //        foreach (var itemE in listaIdsestados)
//                //        {
//                //            foreach (var itemA in Alumnos)
//                //            {
//                //                var idEstado = Convert.ToInt64(itemE);
//                //                Estado = Estados.FirstOrDefault(x => x.idEstado == idEstado);
//                //                if (itemA.fgFallecido == true && itemA.Direcciones.nbEstado.Trim().ToUpper() == Estado.nbEstado.Trim().ToUpper())
//                //                {
//                //                    IndicadoresVM IndicadorRT = new IndicadoresVM();
//                //                    IndicadorRT.nbCampo = Estado.nbEstado;
//                //                    IndicadorRT.nbCampo2 = "SI";
//                //                    IndicadorRT.numCampo = 1;
//                //                    IndicadoresEdosFallecido.Add(IndicadorRT);
//                //                }
//                //                else if (itemA.fgFallecido == false && itemA.Direcciones.nbEstado.Trim().ToUpper() == Estado.nbEstado.Trim().ToUpper())
//                //                {
//                //                    IndicadoresVM IndicadorRNT = new IndicadoresVM();
//                //                    IndicadorRNT.nbCampo = Estado.nbEstado;
//                //                    IndicadorRNT.nbCampo2 = "NO";
//                //                    IndicadorRNT.numCampo = 1;
//                //                    IndicadoresEdosFallecido.Add(IndicadorRNT);
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (listaIdsestados.Count() == 0 && Book.fgFallecido != null)
//                //    {
//                //        foreach (var itemE in Estados)
//                //        {
//                //            foreach (var itemA in Alumnos)
//                //            {
//                //                //var idEstado = Convert.ToInt64(itemE);
//                //                Estado = Estados.FirstOrDefault(x => x.idEstado == itemE.idEstado);
//                //                if (itemA.fgFallecido == Book.fgFallecido && itemA.Direcciones.nbEstado.Trim().ToUpper() == Estado.nbEstado.Trim().ToUpper())
//                //                {
//                //                    IndicadoresVM IndicadorRT = new IndicadoresVM();
//                //                    IndicadorRT.nbCampo = Estado.nbEstado;
//                //                    IndicadorRT.nbCampo2 = (Book.fgFallecido == true) ? "SI" : "NO";
//                //                    IndicadorRT.numCampo = 1;
//                //                    IndicadoresEdosFallecido.Add(IndicadorRT);
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (listaIdsestados.Count() == 0 && Book.fgFallecido == null)
//                //    {
//                //        foreach (var itemE in Estados)
//                //        {
//                //            foreach (var itemA in Alumnos)
//                //            {
//                //                //var idEstado = Convert.ToInt64(itemE);
//                //                Estado = Estados.FirstOrDefault(x => x.idEstado == itemE.idEstado);
//                //                if (itemA.fgFallecido == true && itemA.Direcciones.nbEstado.Trim().ToUpper() == Estado.nbEstado.Trim().ToUpper())
//                //                {
//                //                    IndicadoresVM IndicadorRT = new IndicadoresVM();
//                //                    IndicadorRT.nbCampo = Estado.nbEstado;
//                //                    IndicadorRT.nbCampo2 = "SI";
//                //                    IndicadorRT.numCampo = 1;
//                //                    IndicadoresEdosFallecido.Add(IndicadorRT);
//                //                }
//                //                else if (itemA.fgFallecido == false && itemA.Direcciones.nbEstado.Trim().ToUpper() == Estado.nbEstado.Trim().ToUpper())
//                //                {
//                //                    IndicadoresVM IndicadorRNT = new IndicadoresVM();
//                //                    IndicadorRNT.nbCampo = Estado.nbEstado;
//                //                    IndicadorRNT.nbCampo2 = "NO";
//                //                    IndicadorRNT.numCampo = 1;
//                //                    IndicadoresEdosFallecido.Add(IndicadorRNT);
//                //                }
//                //            }
//                //        }
//                //    }

//                //    IndicadoresEdosFallecido.ToList().ForEach(l =>
//                //    {
//                //        var row = dt.NewRow();
//                //        row["nbCategoria"] = l.nbCampo;
//                //        row["nbCategoria2"] = l.nbCampo2;
//                //        row["numDatos"] = l.numCampo;
//                //        dt.Rows.Add(row);
//                //    });

//                //    #endregion
//                //}
//                //else if (listacaCampos[0] == 10 && listacaCampos[1] == 2)
//                //{
//                //    #region

//                //    TituloColumna1 = "Trabajo";
//                //    TituloColumna2 = "Estado Civil";
//                //    TituloColumna3 = "Cantidad";
//                //    TituloGrafic = "Gráfica de barras por Trabajo y Estado Civil";
//                //    var CatEstadosCiviles = db.CatEstadosCiviles.ToList();
//                //    List<IndicadoresVM> IndicadoresEdoCTrabajo = new List<IndicadoresVM>();
//                //    if (Book.idEstadoCivil != null && Book.fgTrabajaActualmente != null)
//                //    {
//                //        foreach (var item in Alumnos)
//                //        {
//                //            var EstadoCivil = db.CatEstadosCiviles.Find(Book.idEstadoCivil);
//                //            if (item.fgTrabajaActualmente == Book.fgTrabajaActualmente && item.idEstadoCivil == EstadoCivil.idEstadoCivil)
//                //            {
//                //                IndicadoresVM IndicadorECT = new IndicadoresVM();
//                //                IndicadorECT.nbCampo = (Book.fgTrabajaActualmente == true) ? "SI" : "NO";
//                //                IndicadorECT.nbCampo2 = EstadoCivil.nbEstadoCivil;
//                //                IndicadorECT.numCampo = 1;
//                //                IndicadoresEdoCTrabajo.Add(IndicadorECT);
//                //            }
//                //        }
//                //    }
//                //    else if (Book.idEstadoCivil != null && Book.fgTrabajaActualmente == null)
//                //    {
//                //        foreach (var item in Alumnos)
//                //        {
//                //            var EstadoCivil = db.CatEstadosCiviles.Find(Book.idEstadoCivil);
//                //            if (item.fgTrabajaActualmente == true && item.idEstadoCivil == EstadoCivil.idEstadoCivil)
//                //            {
//                //                IndicadoresVM IndicadorECT = new IndicadoresVM();
//                //                IndicadorECT.nbCampo = "SI";
//                //                IndicadorECT.nbCampo2 = EstadoCivil.nbEstadoCivil;
//                //                IndicadorECT.numCampo = 1;
//                //                IndicadoresEdoCTrabajo.Add(IndicadorECT);
//                //            }
//                //            else if (item.fgTrabajaActualmente == false && item.idEstadoCivil == EstadoCivil.idEstadoCivil)
//                //            {
//                //                IndicadoresVM IndicadorECTN = new IndicadoresVM();
//                //                IndicadorECTN.nbCampo = "NO";
//                //                IndicadorECTN.nbCampo2 = EstadoCivil.nbEstadoCivil;
//                //                IndicadorECTN.numCampo = 1;
//                //                IndicadoresEdoCTrabajo.Add(IndicadorECTN);
//                //            }
//                //        }
//                //    }
//                //    else if (Book.idEstadoCivil == null && Book.fgTrabajaActualmente == null)
//                //    {
//                //        foreach (var itemEC in CatEstadosCiviles)
//                //        {
//                //            foreach (var item in Alumnos)
//                //            {
//                //                var EstadoCivil = db.CatEstadosCiviles.Find(itemEC.idEstadoCivil);
//                //                if (item.fgTrabajaActualmente == true && item.idEstadoCivil == EstadoCivil.idEstadoCivil)
//                //                {
//                //                    IndicadoresVM IndicadorECT = new IndicadoresVM();
//                //                    IndicadorECT.nbCampo = "SI";
//                //                    IndicadorECT.nbCampo2 = EstadoCivil.nbEstadoCivil;
//                //                    IndicadorECT.numCampo = 1;
//                //                    IndicadoresEdoCTrabajo.Add(IndicadorECT);
//                //                }
//                //                else if (item.fgTrabajaActualmente == false && item.idEstadoCivil == EstadoCivil.idEstadoCivil)
//                //                {
//                //                    IndicadoresVM IndicadorECTN = new IndicadoresVM();
//                //                    IndicadorECTN.nbCampo = "NO";
//                //                    IndicadorECTN.nbCampo2 = EstadoCivil.nbEstadoCivil;
//                //                    IndicadorECTN.numCampo = 1;
//                //                    IndicadoresEdoCTrabajo.Add(IndicadorECTN);
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (Book.idEstadoCivil == null && Book.fgTrabajaActualmente != null)
//                //    {
//                //        foreach (var itemEC in CatEstadosCiviles)
//                //        {
//                //            foreach (var item in Alumnos)
//                //            {
//                //                var EstadoCivil = db.CatEstadosCiviles.Find(itemEC.idEstadoCivil);
//                //                if (item.fgTrabajaActualmente == Book.fgTrabajaActualmente && item.idEstadoCivil == EstadoCivil.idEstadoCivil)
//                //                {
//                //                    IndicadoresVM IndicadorECT = new IndicadoresVM();
//                //                    IndicadorECT.nbCampo = (Book.fgTrabajaActualmente == true) ? "SI" : "NO";
//                //                    IndicadorECT.nbCampo2 = EstadoCivil.nbEstadoCivil;
//                //                    IndicadorECT.numCampo = 1;
//                //                    IndicadoresEdoCTrabajo.Add(IndicadorECT);
//                //                }
//                //            }

//                //        }
//                //    }

//                //    IndicadoresEdoCTrabajo.ToList().ForEach(l =>
//                //    {
//                //        var row = dt.NewRow();
//                //        row["nbCategoria"] = l.nbCampo;
//                //        row["nbCategoria2"] = l.nbCampo2;
//                //        row["numDatos"] = l.numCampo;
//                //        dt.Rows.Add(row);
//                //    });

//                //    #endregion
//                //}
//                //else if (listacaCampos[0] == 10 && listacaCampos[1] == 3)
//                //{
//                //    #region

//                //    TituloColumna1 = "Trabajo";
//                //    TituloColumna2 = "Edad";
//                //    TituloColumna3 = "Cantidad";
//                //    TituloGrafic = "Gráfica de barras por Trabajo y Edad";
//                //    List<IndicadoresVM> ListaEdadTrabajo = new List<IndicadoresVM>();

//                //    if (Book.numEdadMinima != null && Book.numEdadMinima != null && Book.fgTrabajaActualmente != null)
//                //    {
//                //        for (var i = Book.numEdadMinima; i <= Book.numEdadMaxima; i++)
//                //        {
//                //            foreach (var item in Alumnos)
//                //            {
//                //                var edad = DateTime.Now.Year - ((DateTime)item.feNacimiento).Date.Year;
//                //                if (edad == i && item.fgTrabajaActualmente == Book.fgTrabajaActualmente)
//                //                {
//                //                    IndicadoresVM IndicadorEdadT = new IndicadoresVM();
//                //                    IndicadorEdadT.nbCampo = (Book.fgTrabajaActualmente == true) ? "SI" : "NO";
//                //                    IndicadorEdadT.nbCampo2 = i + " Años";
//                //                    IndicadorEdadT.numCampo = 1;
//                //                    ListaEdadTrabajo.Add(IndicadorEdadT);
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (Book.numEdadMinima != null && Book.numEdadMinima != null && Book.fgTrabajaActualmente == null)
//                //    {
//                //        for (var i = Book.numEdadMinima; i <= Book.numEdadMaxima; i++)
//                //        {
//                //            foreach (var item in Alumnos)
//                //            {
//                //                var edad = DateTime.Now.Year - ((DateTime)item.feNacimiento).Date.Year;
//                //                if (edad == i && item.fgTrabajaActualmente == true)
//                //                {
//                //                    IndicadoresVM IndicadorEdadT = new IndicadoresVM();
//                //                    IndicadorEdadT.nbCampo = "SI";
//                //                    IndicadorEdadT.nbCampo2 = i + " Años";
//                //                    IndicadorEdadT.numCampo = 1;
//                //                    ListaEdadTrabajo.Add(IndicadorEdadT);
//                //                }
//                //                else if (edad == i && item.fgTrabajaActualmente == false)
//                //                {
//                //                    IndicadoresVM IndicadorEdadT = new IndicadoresVM();
//                //                    IndicadorEdadT.nbCampo = "NO";
//                //                    IndicadorEdadT.nbCampo2 = i + " Años";
//                //                    IndicadorEdadT.numCampo = 1;
//                //                    ListaEdadTrabajo.Add(IndicadorEdadT);
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (Book.numEdadMinima == null && Book.numEdadMinima == null && Book.fgTrabajaActualmente != null)
//                //    {
//                //        for (var i = 15; i <= 80; i++)
//                //        {
//                //            foreach (var item in Alumnos)
//                //            {
//                //                var edad = DateTime.Now.Year - ((DateTime)item.feNacimiento).Date.Year;
//                //                if (edad == i && item.fgTrabajaActualmente == Book.fgTrabajaActualmente)
//                //                {
//                //                    IndicadoresVM IndicadorEdadT = new IndicadoresVM();
//                //                    IndicadorEdadT.nbCampo = (Book.fgTrabajaActualmente == true) ? "SI" : "NO";
//                //                    IndicadorEdadT.nbCampo2 = i + " Años";
//                //                    IndicadorEdadT.numCampo = 1;
//                //                    ListaEdadTrabajo.Add(IndicadorEdadT);
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (Book.numEdadMinima == null && Book.numEdadMinima == null && Book.fgTrabajaActualmente == null)
//                //    {
//                //        for (var i = 15; i <= 80; i++)
//                //        {
//                //            foreach (var item in Alumnos)
//                //            {
//                //                var edad = DateTime.Now.Year - ((DateTime)item.feNacimiento).Date.Year;
//                //                if (edad == i && item.fgTrabajaActualmente == true)
//                //                {
//                //                    IndicadoresVM IndicadorEdadT = new IndicadoresVM();
//                //                    IndicadorEdadT.nbCampo = "SI";
//                //                    IndicadorEdadT.nbCampo2 = i + " Años";
//                //                    IndicadorEdadT.numCampo = 1;
//                //                    ListaEdadTrabajo.Add(IndicadorEdadT);
//                //                }
//                //                else if (edad == i && item.fgTrabajaActualmente == false)
//                //                {
//                //                    IndicadoresVM IndicadorEdadT = new IndicadoresVM();
//                //                    IndicadorEdadT.nbCampo = "NO";
//                //                    IndicadorEdadT.nbCampo2 = i + " Años";
//                //                    IndicadorEdadT.numCampo = 1;
//                //                    ListaEdadTrabajo.Add(IndicadorEdadT);
//                //                }
//                //            }
//                //        }
//                //    }

//                //    ListaEdadTrabajo.ToList().ForEach(t =>
//                //    {
//                //        var row = dt.NewRow();
//                //        row["nbCategoria"] = t.nbCampo;
//                //        row["nbCategoria2"] = t.nbCampo2;
//                //        row["numDatos"] = t.numCampo;
//                //        dt.Rows.Add(row);
//                //    });

//                //    #endregion
//                //}
//                //else if (listacaCampos[0] == 10 && listacaCampos[1] == 6)
//                //{
//                //    #region

//                //    TituloColumna1 = "Trabajo";
//                //    TituloColumna2 = "Género";
//                //    TituloColumna3 = "Cantidad";
//                //    TituloGrafic = "Gráfica de barras por Trabajo y Género";

//                //    var CatGeneros = db.CatGeneros.ToList();
//                //    List<IndicadoresVM> IndicadoresGTrabajo = new List<IndicadoresVM>();

//                //    if (Book.idGenero != null && Book.fgTrabajaActualmente != null)
//                //    {
//                //        foreach (var itemA in Alumnos)
//                //        {
//                //            var Genero = db.CatGeneros.Find(Book.idGenero);
//                //            if (itemA.Personas.idGenero == Genero.idGenero && itemA.fgTrabajaActualmente == Book.fgTrabajaActualmente)
//                //            {
//                //                IndicadoresVM IndicadorGT = new IndicadoresVM();
//                //                IndicadorGT.nbCampo = (Book.fgTrabajaActualmente == true) ? "SI" : "NO";
//                //                IndicadorGT.nbCampo2 = Genero.nbGenero.Trim();
//                //                IndicadorGT.numCampo = 1;
//                //                IndicadoresGTrabajo.Add(IndicadorGT);
//                //            }
//                //        }
//                //    }
//                //    else if (Book.idGenero == null && Book.fgTrabajaActualmente != null)
//                //    {
//                //        foreach (var itemG in CatGeneros)
//                //        {
//                //            foreach (var itemA in Alumnos)
//                //            {
//                //                var Genero = db.CatGeneros.Find(itemG.idGenero);
//                //                if (itemA.Personas.idGenero == Genero.idGenero && itemA.fgTrabajaActualmente == Book.fgTrabajaActualmente)
//                //                {
//                //                    IndicadoresVM IndicadorGT = new IndicadoresVM();
//                //                    IndicadorGT.nbCampo = (Book.fgTrabajaActualmente == true) ? "SI" : "NO";
//                //                    IndicadorGT.nbCampo2 = Genero.nbGenero.Trim();
//                //                    IndicadorGT.numCampo = 1;
//                //                    IndicadoresGTrabajo.Add(IndicadorGT);
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (Book.idGenero == null && Book.fgTrabajaActualmente == null)
//                //    {
//                //        foreach (var itemG in CatGeneros)
//                //        {
//                //            foreach (var itemA in Alumnos)
//                //            {
//                //                var Genero = db.CatGeneros.Find(itemG.idGenero);
//                //                if (itemA.Personas.idGenero == Genero.idGenero && itemA.fgTrabajaActualmente == true)
//                //                {
//                //                    IndicadoresVM IndicadorGT = new IndicadoresVM();
//                //                    IndicadorGT.nbCampo = "SI";
//                //                    IndicadorGT.nbCampo2 = Genero.nbGenero.Trim();
//                //                    IndicadorGT.numCampo = 1;
//                //                    IndicadoresGTrabajo.Add(IndicadorGT);
//                //                }
//                //                else if (itemA.Personas.idGenero == Genero.idGenero && itemA.fgTrabajaActualmente == false)
//                //                {
//                //                    IndicadoresVM IndicadorGTN = new IndicadoresVM();
//                //                    IndicadorGTN.nbCampo = "NO";
//                //                    IndicadorGTN.nbCampo2 = Genero.nbGenero.Trim();
//                //                    IndicadorGTN.numCampo = 1;
//                //                    IndicadoresGTrabajo.Add(IndicadorGTN);
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (Book.idGenero != null && Book.fgTrabajaActualmente == null)
//                //    {
//                //        foreach (var itemA in Alumnos)
//                //        {
//                //            var Genero = db.CatGeneros.Find(Book.idGenero);
//                //            if (itemA.Personas.idGenero == Genero.idGenero && itemA.fgTrabajaActualmente == true)
//                //            {
//                //                IndicadoresVM IndicadorGT = new IndicadoresVM();
//                //                IndicadorGT.nbCampo = "SI";
//                //                IndicadorGT.nbCampo2 = Genero.nbGenero.Trim();
//                //                IndicadorGT.numCampo = 1;
//                //                IndicadoresGTrabajo.Add(IndicadorGT);
//                //            }
//                //            else if (itemA.Personas.idGenero == Genero.idGenero && itemA.fgTrabajaActualmente == false)
//                //            {
//                //                IndicadoresVM IndicadorGTN = new IndicadoresVM();
//                //                IndicadorGTN.nbCampo = "NO";
//                //                IndicadorGTN.nbCampo2 = Genero.nbGenero.Trim();
//                //                IndicadorGTN.numCampo = 1;
//                //                IndicadoresGTrabajo.Add(IndicadorGTN);
//                //            }
//                //        }
//                //    }

//                //    IndicadoresGTrabajo.ToList().ForEach(l =>
//                //    {
//                //        var row = dt.NewRow();
//                //        row["nbCategoria"] = l.nbCampo;
//                //        row["nbCategoria2"] = l.nbCampo2;
//                //        row["numDatos"] = l.numCampo;
//                //        dt.Rows.Add(row);
//                //    });

//                //    #endregion
//                //}
//                //else if (listacaCampos[0] == 10 && listacaCampos[1] == 7)
//                //{
//                //    #region

//                //    TituloColumna1 = "Trabajo";
//                //    TituloColumna2 = "Licenciatura";
//                //    TituloColumna3 = "Cantidad";
//                //    TituloGrafic = "Gráfica de barras por Trabajo y Licenciatura";

//                //    Licenciaturas Licenciatura = new Licenciaturas();
//                //    var Licenciaturas = db.Licenciaturas.ToList();

//                //    List<IndicadoresVM> IndicadoresLicTrab = new List<IndicadoresVM>();

//                //    if (listaIdsLicenciaturas.Count() > 0 && Book.fgTrabajaActualmente != null)
//                //    {
//                //        foreach (var itemL in listaIdsLicenciaturas)
//                //        {
//                //            foreach (var item in Alumnos)
//                //            {
//                //                var idLicenciatura = Convert.ToInt64(itemL);
//                //                Licenciatura = Licenciaturas.FirstOrDefault(x => x.idLicenciatura == idLicenciatura);
//                //                var FormacionesA = db.FormacionesAcademicas.Where(x => x.idAlumno == item.idAlumno && x.idLicenciatura == Licenciatura.idLicenciatura).ToList();
//                //                if (item.fgTrabajaActualmente == Book.fgTrabajaActualmente && FormacionesA.Count() > 0)
//                //                {
//                //                    IndicadoresVM IndicadorLT = new IndicadoresVM();
//                //                    IndicadorLT.nbCampo = (Book.fgTrabajaActualmente == true) ? "SI" : "NO";
//                //                    IndicadorLT.nbCampo2 = Licenciatura.nbLicenciatura;
//                //                    IndicadorLT.numCampo = 1;
//                //                    IndicadoresLicTrab.Add(IndicadorLT);
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (listaIdsLicenciaturas.Count() > 0 && Book.fgTrabajaActualmente == null)
//                //    {
//                //        foreach (var itemL in listaIdsLicenciaturas)
//                //        {
//                //            foreach (var item in Alumnos)
//                //            {
//                //                var idLicenciatura = Convert.ToInt64(itemL);
//                //                Licenciatura = Licenciaturas.FirstOrDefault(x => x.idLicenciatura == idLicenciatura);
//                //                var FormacionesA = db.FormacionesAcademicas.Where(x => x.idAlumno == item.idAlumno && x.idLicenciatura == Licenciatura.idLicenciatura).ToList();
//                //                if (item.fgTrabajaActualmente == true && FormacionesA.Count() > 0)
//                //                {
//                //                    IndicadoresVM IndicadorLT = new IndicadoresVM();
//                //                    IndicadorLT.nbCampo = "SI";
//                //                    IndicadorLT.nbCampo2 = Licenciatura.nbLicenciatura;
//                //                    IndicadorLT.numCampo = 1;
//                //                    IndicadoresLicTrab.Add(IndicadorLT);
//                //                }
//                //                else if (item.fgTrabajaActualmente == false && FormacionesA.Count() > 0)
//                //                {
//                //                    IndicadoresVM IndicadorLNT = new IndicadoresVM();
//                //                    IndicadorLNT.nbCampo = "NO";
//                //                    IndicadorLNT.nbCampo2 = Licenciatura.nbLicenciatura;
//                //                    IndicadorLNT.numCampo = 1;
//                //                    IndicadoresLicTrab.Add(IndicadorLNT);
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (listaIdsLicenciaturas.Count() == 0 && Book.fgTrabajaActualmente != null)
//                //    {
//                //        foreach (var itemL in Licenciaturas)
//                //        {
//                //            foreach (var item in Alumnos)
//                //            {
//                //                //var idLicenciatura = Convert.ToInt64(itemL);
//                //                Licenciatura = Licenciaturas.FirstOrDefault(x => x.idLicenciatura == itemL.idLicenciatura);
//                //                var FormacionesA = db.FormacionesAcademicas.Where(x => x.idAlumno == item.idAlumno && x.idLicenciatura == Licenciatura.idLicenciatura).ToList();
//                //                if (item.fgTrabajaActualmente == Book.fgTrabajaActualmente && FormacionesA.Count() > 0)
//                //                {
//                //                    IndicadoresVM IndicadorLT = new IndicadoresVM();
//                //                    IndicadorLT.nbCampo = (Book.fgTrabajaActualmente == true) ? "SI" : "NO";
//                //                    IndicadorLT.nbCampo2 = Licenciatura.nbLicenciatura;
//                //                    IndicadorLT.numCampo = 1;
//                //                    IndicadoresLicTrab.Add(IndicadorLT);
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (listaIdsLicenciaturas.Count() == 0 && Book.fgTrabajaActualmente == null)
//                //    {
//                //        foreach (var itemL in Licenciaturas)
//                //        {
//                //            foreach (var item in Alumnos)
//                //            {
//                //                //var idLicenciatura = Convert.ToInt64(itemL);
//                //                Licenciatura = Licenciaturas.FirstOrDefault(x => x.idLicenciatura == itemL.idLicenciatura);
//                //                var FormacionesA = db.FormacionesAcademicas.Where(x => x.idAlumno == item.idAlumno && x.idLicenciatura == Licenciatura.idLicenciatura).ToList();
//                //                if (item.fgTrabajaActualmente == true && FormacionesA.Count() > 0)
//                //                {
//                //                    IndicadoresVM IndicadorLT = new IndicadoresVM();
//                //                    IndicadorLT.nbCampo = "SI";
//                //                    IndicadorLT.nbCampo2 = Licenciatura.nbLicenciatura;
//                //                    IndicadorLT.numCampo = 1;
//                //                    IndicadoresLicTrab.Add(IndicadorLT);
//                //                }
//                //                else if (item.fgTrabajaActualmente == false && FormacionesA.Count() > 0)
//                //                {
//                //                    IndicadoresVM IndicadorLNT = new IndicadoresVM();
//                //                    IndicadorLNT.nbCampo = "NO";
//                //                    IndicadorLNT.nbCampo2 = Licenciatura.nbLicenciatura;
//                //                    IndicadorLNT.numCampo = 1;
//                //                    IndicadoresLicTrab.Add(IndicadorLNT);
//                //                }
//                //            }
//                //        }
//                //    }

//                //    IndicadoresLicTrab.ToList().ForEach(l =>
//                //    {
//                //        var row = dt.NewRow();
//                //        row["nbCategoria"] = l.nbCampo;
//                //        row["nbCategoria2"] = l.nbCampo2;
//                //        row["numDatos"] = l.numCampo;
//                //        dt.Rows.Add(row);
//                //    });

//                //    #endregion
//                //}
//                //else if (listacaCampos[0] == 10 && listacaCampos[1] == 8)
//                //{
//                //    #region

//                //    TituloColumna1 = "Trabajo";
//                //    TituloColumna2 = "Religión";
//                //    TituloColumna3 = "Cantidad";
//                //    TituloGrafic = "Gráfica de barras por Trabajo y Religión";

//                //    CatReligion Religion = new CatReligion();
//                //    var Religiones = db.CatReligion.ToList();

//                //    List<IndicadoresVM> IndicadoresRelTrab = new List<IndicadoresVM>();

//                //    if (listaIdsReligiones.Count() > 0 && Book.fgTrabajaActualmente != null)
//                //    {
//                //        foreach (var itemR in listaIdsReligiones)
//                //        {
//                //            foreach (var itemA in Alumnos)
//                //            {
//                //                var idReligion = Convert.ToInt64(itemR);
//                //                Religion = Religiones.FirstOrDefault(x => x.idReligion == idReligion);
//                //                if (itemA.idReligion == Religion.idReligion && itemA.fgTrabajaActualmente == Book.fgTrabajaActualmente)
//                //                {
//                //                    IndicadoresVM IndicadorRT = new IndicadoresVM();
//                //                    IndicadorRT.nbCampo = (Book.fgTrabajaActualmente == true) ? "SI" : "NO";
//                //                    IndicadorRT.nbCampo2 = Religion.nbReligion;
//                //                    IndicadorRT.numCampo = 1;
//                //                    IndicadoresRelTrab.Add(IndicadorRT);
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (listaIdsReligiones.Count() > 0 && Book.fgTrabajaActualmente == null)
//                //    {
//                //        foreach (var itemR in listaIdsReligiones)
//                //        {
//                //            foreach (var itemA in Alumnos)
//                //            {
//                //                var idReligion = Convert.ToInt64(itemR);
//                //                Religion = Religiones.FirstOrDefault(x => x.idReligion == idReligion);
//                //                if (itemA.idReligion == Religion.idReligion && itemA.fgTrabajaActualmente == true)
//                //                {
//                //                    IndicadoresVM IndicadorRT = new IndicadoresVM();
//                //                    IndicadorRT.nbCampo = "SI";
//                //                    IndicadorRT.nbCampo2 = Religion.nbReligion;
//                //                    IndicadorRT.numCampo = 1;
//                //                    IndicadoresRelTrab.Add(IndicadorRT);
//                //                }
//                //                else if (itemA.idReligion == Religion.idReligion && itemA.fgTrabajaActualmente == false)
//                //                {
//                //                    IndicadoresVM IndicadorRNT = new IndicadoresVM();
//                //                    IndicadorRNT.nbCampo = "NO";
//                //                    IndicadorRNT.nbCampo2 = Religion.nbReligion;
//                //                    IndicadorRNT.numCampo = 1;
//                //                    IndicadoresRelTrab.Add(IndicadorRNT);
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (listaIdsReligiones.Count() == 0 && Book.fgTrabajaActualmente != null)
//                //    {
//                //        foreach (var itemR in Religiones)
//                //        {
//                //            foreach (var itemA in Alumnos)
//                //            {
//                //                //var idReligion = Convert.ToInt64(itemR);
//                //                Religion = Religiones.FirstOrDefault(x => x.idReligion == itemR.idReligion);
//                //                if (itemA.idReligion == Religion.idReligion && itemA.fgTrabajaActualmente == Book.fgTrabajaActualmente)
//                //                {
//                //                    IndicadoresVM IndicadorRT = new IndicadoresVM();
//                //                    IndicadorRT.nbCampo = (Book.fgTrabajaActualmente == true) ? "SI" : "NO";
//                //                    IndicadorRT.nbCampo2 = Religion.nbReligion;
//                //                    IndicadorRT.numCampo = 1;
//                //                    IndicadoresRelTrab.Add(IndicadorRT);
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (listaIdsReligiones.Count() == 0 && Book.fgTrabajaActualmente == null)
//                //    {
//                //        foreach (var itemR in Religiones)
//                //        {
//                //            foreach (var itemA in Alumnos)
//                //            {
//                //                //var idReligion = Convert.ToInt64(itemR);
//                //                Religion = Religiones.FirstOrDefault(x => x.idReligion == itemR.idReligion);
//                //                if (itemA.idReligion == Religion.idReligion && itemA.fgTrabajaActualmente == true)
//                //                {
//                //                    IndicadoresVM IndicadorRT = new IndicadoresVM();
//                //                    IndicadorRT.nbCampo = "SI";
//                //                    IndicadorRT.nbCampo2 = Religion.nbReligion;
//                //                    IndicadorRT.numCampo = 1;
//                //                    IndicadoresRelTrab.Add(IndicadorRT);
//                //                }
//                //                else if (itemA.idReligion == Religion.idReligion && itemA.fgTrabajaActualmente == false)
//                //                {
//                //                    IndicadoresVM IndicadorRNT = new IndicadoresVM();
//                //                    IndicadorRNT.nbCampo = "NO";
//                //                    IndicadorRNT.nbCampo2 = Religion.nbReligion;
//                //                    IndicadorRNT.numCampo = 1;
//                //                    IndicadoresRelTrab.Add(IndicadorRNT);
//                //                }
//                //            }
//                //        }
//                //    }

//                //    IndicadoresRelTrab.ToList().ForEach(l =>
//                //    {
//                //        var row = dt.NewRow();
//                //        row["nbCategoria"] = l.nbCampo;
//                //        row["nbCategoria2"] = l.nbCampo2;
//                //        row["numDatos"] = l.numCampo;
//                //        dt.Rows.Add(row);
//                //    });

//                //    #endregion
//                //}
//                //else if (listacaCampos[0] == 10 && listacaCampos[1] == 9)
//                //{
//                //    #region

//                //    TituloColumna1 = "Trabajo";
//                //    TituloColumna2 = "Estado";
//                //    TituloColumna3 = "Cantidad";
//                //    TituloGrafic = "Gráfica de barras por Trabajo y Estado";

//                //    CatEstados Estado = new CatEstados();
//                //    var Estados = db.CatEstados.ToList();

//                //    List<IndicadoresVM> IndicadoresEdosTrab = new List<IndicadoresVM>();

//                //    if (listaIdsestados.Count() > 0 && Book.fgTrabajaActualmente != null)
//                //    {
//                //        foreach (var itemE in listaIdsestados)
//                //        {
//                //            foreach (var itemA in Alumnos)
//                //            {
//                //                var idEstado = Convert.ToInt64(itemE);
//                //                Estado = Estados.FirstOrDefault(x => x.idEstado == idEstado);
//                //                if (itemA.fgTrabajaActualmente == Book.fgTrabajaActualmente && itemA.Direcciones.nbEstado.Trim().ToUpper() == Estado.nbEstado.Trim().ToUpper())
//                //                {
//                //                    IndicadoresVM IndicadorRT = new IndicadoresVM();
//                //                    IndicadorRT.nbCampo = (Book.fgTrabajaActualmente == true) ? "SI" : "NO";
//                //                    IndicadorRT.nbCampo2 = Estado.nbEstado;
//                //                    IndicadorRT.numCampo = 1;
//                //                    IndicadoresEdosTrab.Add(IndicadorRT);
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (listaIdsestados.Count() > 0 && Book.fgTrabajaActualmente == null)
//                //    {
//                //        foreach (var itemE in listaIdsestados)
//                //        {
//                //            foreach (var itemA in Alumnos)
//                //            {
//                //                var idEstado = Convert.ToInt64(itemE);
//                //                Estado = Estados.FirstOrDefault(x => x.idEstado == idEstado);
//                //                if (itemA.fgTrabajaActualmente == true && itemA.Direcciones.nbEstado.Trim().ToUpper() == Estado.nbEstado.Trim().ToUpper())
//                //                {
//                //                    IndicadoresVM IndicadorRT = new IndicadoresVM();
//                //                    IndicadorRT.nbCampo = "SI";
//                //                    IndicadorRT.nbCampo2 = Estado.nbEstado;
//                //                    IndicadorRT.numCampo = 1;
//                //                    IndicadoresEdosTrab.Add(IndicadorRT);
//                //                }
//                //                else if (itemA.fgTrabajaActualmente == false && itemA.Direcciones.nbEstado.Trim().ToUpper() == Estado.nbEstado.Trim().ToUpper())
//                //                {
//                //                    IndicadoresVM IndicadorRNT = new IndicadoresVM();
//                //                    IndicadorRNT.nbCampo = "NO";
//                //                    IndicadorRNT.nbCampo2 = Estado.nbEstado;
//                //                    IndicadorRNT.numCampo = 1;
//                //                    IndicadoresEdosTrab.Add(IndicadorRNT);
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (listaIdsestados.Count() == 0 && Book.fgTrabajaActualmente != null)
//                //    {
//                //        foreach (var itemE in Estados)
//                //        {
//                //            foreach (var itemA in Alumnos)
//                //            {
//                //                //var idEstado = Convert.ToInt64(itemE);
//                //                Estado = Estados.FirstOrDefault(x => x.idEstado == itemE.idEstado);
//                //                if (itemA.fgTrabajaActualmente == Book.fgTrabajaActualmente && itemA.Direcciones.nbEstado.Trim().ToUpper() == Estado.nbEstado.Trim().ToUpper())
//                //                {
//                //                    IndicadoresVM IndicadorRT = new IndicadoresVM();
//                //                    IndicadorRT.nbCampo = (Book.fgTrabajaActualmente == true) ? "SI" : "NO";
//                //                    IndicadorRT.nbCampo2 = Estado.nbEstado;
//                //                    IndicadorRT.numCampo = 1;
//                //                    IndicadoresEdosTrab.Add(IndicadorRT);
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (listaIdsestados.Count() == 0 && Book.fgTrabajaActualmente == null)
//                //    {
//                //        foreach (var itemE in Estados)
//                //        {
//                //            foreach (var itemA in Alumnos)
//                //            {
//                //                //var idEstado = Convert.ToInt64(itemE);
//                //                Estado = Estados.FirstOrDefault(x => x.idEstado == itemE.idEstado);
//                //                if (itemA.fgTrabajaActualmente == true && itemA.Direcciones.nbEstado.Trim().ToUpper() == Estado.nbEstado.Trim().ToUpper())
//                //                {
//                //                    IndicadoresVM IndicadorRT = new IndicadoresVM();
//                //                    IndicadorRT.nbCampo = "SI";
//                //                    IndicadorRT.nbCampo2 = Estado.nbEstado;
//                //                    IndicadorRT.numCampo = 1;
//                //                    IndicadoresEdosTrab.Add(IndicadorRT);
//                //                }
//                //                else if (itemA.fgTrabajaActualmente == false && itemA.Direcciones.nbEstado.Trim().ToUpper() == Estado.nbEstado.Trim().ToUpper())
//                //                {
//                //                    IndicadoresVM IndicadorRNT = new IndicadoresVM();
//                //                    IndicadorRNT.nbCampo = "NO";
//                //                    IndicadorRNT.nbCampo2 = Estado.nbEstado;
//                //                    IndicadorRNT.numCampo = 1;
//                //                    IndicadoresEdosTrab.Add(IndicadorRNT);
//                //                }
//                //            }
//                //        }
//                //    }

//                //    IndicadoresEdosTrab.ToList().ForEach(l =>
//                //    {
//                //        var row = dt.NewRow();
//                //        row["nbCategoria"] = l.nbCampo;
//                //        row["nbCategoria2"] = l.nbCampo2;
//                //        row["numDatos"] = l.numCampo;
//                //        dt.Rows.Add(row);
//                //    });

//                //    #endregion
//                //}
//                //else if (listacaCampos[0] == 10 && listacaCampos[1] == 11)
//                //{
//                //    #region

//                //    TituloColumna1 = "Trabajo";
//                //    TituloColumna2 = "Tipo de Sangre";
//                //    TituloColumna3 = "Cantidad";
//                //    TituloGrafic = "Gráfica de barras por Trabajo y Tipo de Sangre";
//                //    var CatTiposSangre = db.CatTiposSangre.ToList();
//                //    List<IndicadoresVM> IndicadoresTS = new List<IndicadoresVM>();
//                //    if (Book.idTipoSangre != null && Book.fgTrabajaActualmente != null)
//                //    {
//                //        foreach (var itemA in Alumnos)
//                //        {
//                //            var TipoSangre = db.CatTiposSangre.Find(Book.idTipoSangre);
//                //            if (itemA.fgTrabajaActualmente == Book.fgTrabajaActualmente && itemA.idTipoSangre == Book.idTipoSangre)
//                //            {
//                //                IndicadoresVM IndicadorTS = new IndicadoresVM();
//                //                IndicadorTS.nbCampo = (Book.fgTrabajaActualmente == true) ? "SI" : "NO";
//                //                IndicadorTS.nbCampo2 = TipoSangre.nbTipoSangre;
//                //                IndicadorTS.numCampo = 1;
//                //                IndicadoresTS.Add(IndicadorTS);
//                //            }
//                //        }
//                //    }
//                //    else if (Book.idTipoSangre != null && Book.fgTrabajaActualmente == null)
//                //    {
//                //        foreach (var itemA in Alumnos)
//                //        {
//                //            var TipoSangre = db.CatTiposSangre.Find(Book.idTipoSangre);
//                //            if (itemA.fgTrabajaActualmente == true && itemA.idTipoSangre == TipoSangre.idTipoSangre)
//                //            {
//                //                IndicadoresVM IndicadorTS = new IndicadoresVM();
//                //                IndicadorTS.nbCampo = "SI";
//                //                IndicadorTS.nbCampo2 = TipoSangre.nbTipoSangre;
//                //                IndicadorTS.numCampo = 1;
//                //                IndicadoresTS.Add(IndicadorTS);
//                //            }
//                //            else if (itemA.fgTrabajaActualmente == false && itemA.idTipoSangre == TipoSangre.idTipoSangre)
//                //            {
//                //                IndicadoresVM IndicadorTSN = new IndicadoresVM();
//                //                IndicadorTSN.nbCampo = "NO";
//                //                IndicadorTSN.nbCampo2 = TipoSangre.nbTipoSangre;
//                //                IndicadorTSN.numCampo = 1;
//                //                IndicadoresTS.Add(IndicadorTSN);
//                //            }
//                //        }
//                //    }
//                //    else if (Book.idTipoSangre == null && Book.fgTrabajaActualmente == null)
//                //    {
//                //        foreach (var itemS in CatTiposSangre)
//                //        {
//                //            foreach (var itemA in Alumnos)
//                //            {
//                //                var TipoSangre = db.CatTiposSangre.Find(itemS.idTipoSangre);
//                //                if (itemA.fgTrabajaActualmente == true && itemA.idTipoSangre == TipoSangre.idTipoSangre)
//                //                {
//                //                    IndicadoresVM IndicadorTS = new IndicadoresVM();
//                //                    IndicadorTS.nbCampo = "SI";
//                //                    IndicadorTS.nbCampo2 = TipoSangre.nbTipoSangre;
//                //                    IndicadorTS.numCampo = 1;
//                //                    IndicadoresTS.Add(IndicadorTS);
//                //                }
//                //                else if (itemA.fgTrabajaActualmente == false && itemA.idTipoSangre == TipoSangre.idTipoSangre)
//                //                {
//                //                    IndicadoresVM IndicadorTSN = new IndicadoresVM();
//                //                    IndicadorTSN.nbCampo = "NO";
//                //                    IndicadorTSN.nbCampo2 = TipoSangre.nbTipoSangre;
//                //                    IndicadorTSN.numCampo = 1;
//                //                    IndicadoresTS.Add(IndicadorTSN);
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (Book.idTipoSangre == null && Book.fgTrabajaActualmente != null)
//                //    {
//                //        foreach (var itemS in CatTiposSangre)
//                //        {
//                //            foreach (var itemA in Alumnos)
//                //            {
//                //                var TipoSangre = db.CatTiposSangre.Find(itemS.idTipoSangre);
//                //                if (itemA.fgTrabajaActualmente == Book.fgTrabajaActualmente && itemA.idTipoSangre == TipoSangre.idTipoSangre)
//                //                {
//                //                    IndicadoresVM IndicadorTS = new IndicadoresVM();
//                //                    IndicadorTS.nbCampo = (Book.fgTrabajaActualmente == true) ? "SI" : "NO";
//                //                    IndicadorTS.nbCampo2 = TipoSangre.nbTipoSangre;
//                //                    IndicadorTS.numCampo = 1;
//                //                    IndicadoresTS.Add(IndicadorTS);
//                //                }
//                //            }

//                //        }
//                //    }

//                //    IndicadoresTS.ToList().ForEach(l =>
//                //    {
//                //        var row = dt.NewRow();
//                //        row["nbCategoria"] = l.nbCampo;
//                //        row["nbCategoria2"] = l.nbCampo2;
//                //        row["numDatos"] = l.numCampo;
//                //        dt.Rows.Add(row);
//                //    });

//                //    #endregion
//                //}
//                //else if (listacaCampos[0] == 10 && listacaCampos[1] == 12)
//                //{
//                //    #region

//                //    TituloColumna1 = "Trabajo";
//                //    TituloColumna2 = "Licencia";
//                //    TituloColumna3 = "Cantidad";
//                //    TituloGrafic = "Gráfica de barras por Trabajo y Licencia";
//                //    List<IndicadoresVM> IndicadoresTL = new List<IndicadoresVM>();
//                //    if (Book.fgLicencia != null && Book.fgTrabajaActualmente != null)
//                //    {
//                //        foreach (var itemA in Alumnos)
//                //        {
//                //            if (itemA.fgTrabajaActualmente == Book.fgTrabajaActualmente && itemA.fgLicencia == Book.fgLicencia)
//                //            {
//                //                IndicadoresVM IndicadorTL = new IndicadoresVM();
//                //                IndicadorTL.nbCampo = (Book.fgTrabajaActualmente == true) ? "SI" : "NO";
//                //                IndicadorTL.nbCampo2 = (Book.fgLicencia == true) ? "SI" : "NO";
//                //                IndicadorTL.numCampo = 1;
//                //                IndicadoresTL.Add(IndicadorTL);
//                //            }
//                //        }
//                //    }
//                //    else if (Book.fgLicencia != null && Book.fgTrabajaActualmente == null)
//                //    {
//                //        foreach (var itemA in Alumnos)
//                //        {
//                //            if (itemA.fgTrabajaActualmente == true && itemA.fgLicencia == Book.fgLicencia)
//                //            {
//                //                IndicadoresVM IndicadorTL = new IndicadoresVM();
//                //                IndicadorTL.nbCampo = "SI";
//                //                IndicadorTL.nbCampo2 = (Book.fgLicencia == true) ? "SI" : "NO";
//                //                IndicadorTL.numCampo = 1;
//                //                IndicadoresTL.Add(IndicadorTL);
//                //            }
//                //            else if (itemA.fgTrabajaActualmente == false && itemA.fgLicencia == Book.fgLicencia)
//                //            {
//                //                IndicadoresVM IndicadorTLN = new IndicadoresVM();
//                //                IndicadorTLN.nbCampo = "NO";
//                //                IndicadorTLN.nbCampo2 = (Book.fgLicencia == true) ? "SI" : "NO";
//                //                IndicadorTLN.numCampo = 1;
//                //                IndicadoresTL.Add(IndicadorTLN);
//                //            }
//                //        }
//                //    }
//                //    else if (Book.fgLicencia == null && Book.fgTrabajaActualmente == null)
//                //    {
//                //        foreach (var itemA in Alumnos)
//                //        {
//                //            if (itemA.fgTrabajaActualmente == true && itemA.fgLicencia == true)
//                //            {
//                //                IndicadoresVM IndicadorTL = new IndicadoresVM();
//                //                IndicadorTL.nbCampo = "SI";
//                //                IndicadorTL.nbCampo2 = "SI";
//                //                IndicadorTL.numCampo = 1;
//                //                IndicadoresTL.Add(IndicadorTL);
//                //            }
//                //            else if (itemA.fgTrabajaActualmente == false && itemA.fgLicencia == true)
//                //            {
//                //                IndicadoresVM IndicadorNTL = new IndicadoresVM();
//                //                IndicadorNTL.nbCampo = "NO";
//                //                IndicadorNTL.nbCampo2 = "SI";
//                //                IndicadorNTL.numCampo = 1;
//                //                IndicadoresTL.Add(IndicadorNTL);
//                //            }
//                //            else if (itemA.fgTrabajaActualmente == true && itemA.fgLicencia == false)
//                //            {
//                //                IndicadoresVM IndicadorTNL = new IndicadoresVM();
//                //                IndicadorTNL.nbCampo = "SI";
//                //                IndicadorTNL.nbCampo2 = "NO";
//                //                IndicadorTNL.numCampo = 1;
//                //                IndicadoresTL.Add(IndicadorTNL);
//                //            }
//                //            else if (itemA.fgTrabajaActualmente == false && itemA.fgLicencia == false)
//                //            {
//                //                IndicadoresVM IndicadorNTNL = new IndicadoresVM();
//                //                IndicadorNTNL.nbCampo = "NO";
//                //                IndicadorNTNL.nbCampo2 = "NO";
//                //                IndicadorNTNL.numCampo = 1;
//                //                IndicadoresTL.Add(IndicadorNTNL);
//                //            }
//                //        }
//                //    }
//                //    else if (Book.fgLicencia == null && Book.fgTrabajaActualmente != null)
//                //    {
//                //        foreach (var itemA in Alumnos)
//                //        {
//                //            if (itemA.fgTrabajaActualmente == Book.fgTrabajaActualmente && itemA.fgLicencia == true)
//                //            {
//                //                IndicadoresVM IndicadorTL = new IndicadoresVM();
//                //                IndicadorTL.nbCampo = "SI";
//                //                IndicadorTL.nbCampo2 = (Book.fgLicencia == true) ? "SI" : "NO";
//                //                IndicadorTL.numCampo = 1;
//                //                IndicadoresTL.Add(IndicadorTL);
//                //            }
//                //            else if (itemA.fgTrabajaActualmente == Book.fgTrabajaActualmente && itemA.fgLicencia == false)
//                //            {
//                //                IndicadoresVM IndicadorTLN = new IndicadoresVM();
//                //                IndicadorTLN.nbCampo = "NO";
//                //                IndicadorTLN.nbCampo2 = (Book.fgLicencia == true) ? "SI" : "NO";
//                //                IndicadorTLN.numCampo = 1;
//                //                IndicadoresTL.Add(IndicadorTLN);
//                //            }
//                //        }
//                //    }

//                //    IndicadoresTL.ToList().ForEach(l =>
//                //    {
//                //        var row = dt.NewRow();
//                //        row["nbCategoria"] = l.nbCampo;
//                //        row["nbCategoria2"] = l.nbCampo2;
//                //        row["numDatos"] = l.numCampo;
//                //        dt.Rows.Add(row);
//                //    });

//                //    #endregion
//                //}
//                //else if (listacaCampos[0] == 10 && listacaCampos[1] == 13)
//                //{
//                //    #region

//                //    TituloColumna1 = "Trabajo";
//                //    TituloColumna2 = "Tipo de Egresado";
//                //    TituloColumna3 = "Cantidad";
//                //    TituloGrafic = "Gráfica de barras por Trabajo y Tipo de Egresado";
//                //    List<IndicadoresVM> IndicadoresTL = new List<IndicadoresVM>();
//                //    if (Book.tpEgresado != null && Book.fgTrabajaActualmente != null)
//                //    {
//                //        foreach (var itemA in Alumnos)
//                //        {
//                //            if (itemA.fgTrabajaActualmente == Book.fgTrabajaActualmente && itemA.tpEgresado == Book.tpEgresado)
//                //            {
//                //                IndicadoresVM IndicadorTL = new IndicadoresVM();
//                //                IndicadorTL.nbCampo = (Book.fgTrabajaActualmente == true) ? "SI" : "NO";
//                //                IndicadorTL.nbCampo2 = (Book.tpEgresado == "T") ? "Titulado" : "Pasante";
//                //                IndicadorTL.numCampo = 1;
//                //                IndicadoresTL.Add(IndicadorTL);
//                //            }
//                //        }
//                //    }
//                //    else if (Book.tpEgresado != null && Book.fgTrabajaActualmente == null)
//                //    {
//                //        foreach (var itemA in Alumnos)
//                //        {
//                //            if (itemA.fgTrabajaActualmente == true && itemA.tpEgresado == Book.tpEgresado)
//                //            {
//                //                IndicadoresVM IndicadorTL = new IndicadoresVM();
//                //                IndicadorTL.nbCampo = "SI";
//                //                IndicadorTL.nbCampo2 = (Book.tpEgresado == "T") ? "Titulado" : "Pasante";
//                //                IndicadorTL.numCampo = 1;
//                //                IndicadoresTL.Add(IndicadorTL);
//                //            }
//                //            else if (itemA.fgTrabajaActualmente == false && itemA.tpEgresado == Book.tpEgresado)
//                //            {
//                //                IndicadoresVM IndicadorTLN = new IndicadoresVM();
//                //                IndicadorTLN.nbCampo = "NO";
//                //                IndicadorTLN.nbCampo2 = (Book.tpEgresado == "T") ? "Titulado" : "Pasante";
//                //                IndicadorTLN.numCampo = 1;
//                //                IndicadoresTL.Add(IndicadorTLN);
//                //            }
//                //        }
//                //    }
//                //    else if (Book.tpEgresado == null && Book.fgTrabajaActualmente == null)
//                //    {
//                //        foreach (var itemA in Alumnos)
//                //        {
//                //            if (itemA.fgTrabajaActualmente == true && itemA.tpEgresado == "T")
//                //            {
//                //                IndicadoresVM IndicadorTL = new IndicadoresVM();
//                //                IndicadorTL.nbCampo = "SI";
//                //                IndicadorTL.nbCampo2 = "Titulado";
//                //                IndicadorTL.numCampo = 1;
//                //                IndicadoresTL.Add(IndicadorTL);
//                //            }
//                //            else if (itemA.fgTrabajaActualmente == false && itemA.tpEgresado == "T")
//                //            {
//                //                IndicadoresVM IndicadorNTL = new IndicadoresVM();
//                //                IndicadorNTL.nbCampo = "NO";
//                //                IndicadorNTL.nbCampo2 = "Titulado";
//                //                IndicadorNTL.numCampo = 1;
//                //                IndicadoresTL.Add(IndicadorNTL);
//                //            }
//                //            else if (itemA.fgTrabajaActualmente == true && itemA.tpEgresado == "P")
//                //            {
//                //                IndicadoresVM IndicadorTNL = new IndicadoresVM();
//                //                IndicadorTNL.nbCampo = "SI";
//                //                IndicadorTNL.nbCampo2 = "Pasante";
//                //                IndicadorTNL.numCampo = 1;
//                //                IndicadoresTL.Add(IndicadorTNL);
//                //            }
//                //            else if (itemA.fgTrabajaActualmente == false && itemA.tpEgresado == "P")
//                //            {
//                //                IndicadoresVM IndicadorNTNL = new IndicadoresVM();
//                //                IndicadorNTNL.nbCampo = "NO";
//                //                IndicadorNTNL.nbCampo2 = "Pasante";
//                //                IndicadorNTNL.numCampo = 1;
//                //                IndicadoresTL.Add(IndicadorNTNL);
//                //            }
//                //        }
//                //    }
//                //    else if (Book.tpEgresado == null && Book.fgTrabajaActualmente != null)
//                //    {
//                //        foreach (var itemA in Alumnos)
//                //        {
//                //            if (itemA.fgTrabajaActualmente == Book.fgTrabajaActualmente && itemA.tpEgresado == "T")
//                //            {
//                //                IndicadoresVM IndicadorTL = new IndicadoresVM();
//                //                IndicadorTL.nbCampo = "SI";
//                //                IndicadorTL.nbCampo2 = "Titulado";
//                //                IndicadorTL.numCampo = 1;
//                //                IndicadoresTL.Add(IndicadorTL);
//                //            }
//                //            else if (itemA.fgTrabajaActualmente == Book.fgTrabajaActualmente && itemA.tpEgresado == "P")
//                //            {
//                //                IndicadoresVM IndicadorNTL = new IndicadoresVM();
//                //                IndicadorNTL.nbCampo = "NO";
//                //                IndicadorNTL.nbCampo2 = "Pasante";
//                //                IndicadorNTL.numCampo = 1;
//                //                IndicadoresTL.Add(IndicadorNTL);
//                //            }
//                //        }
//                //    }

//                //    IndicadoresTL.ToList().ForEach(l =>
//                //    {
//                //        var row = dt.NewRow();
//                //        row["nbCategoria"] = l.nbCampo;
//                //        row["nbCategoria2"] = l.nbCampo2;
//                //        row["numDatos"] = l.numCampo;
//                //        dt.Rows.Add(row);
//                //    });

//                //    #endregion
//                //}
//                //else if (listacaCampos[0] == 10 && listacaCampos[1] == 14)
//                //{
//                //    #region

//                //    TituloColumna1 = "Trabajo";
//                //    TituloColumna2 = "Fallecimiento";
//                //    TituloColumna3 = "Cantidad";
//                //    TituloGrafic = "Gráfica de barras por Trabajo y Fallecimiento";
//                //    List<IndicadoresVM> IndicadoresTF = new List<IndicadoresVM>();
//                //    if (Book.fgFallecido != null && Book.fgTrabajaActualmente != null)
//                //    {
//                //        foreach (var itemA in Alumnos)
//                //        {
//                //            if (itemA.fgTrabajaActualmente == Book.fgTrabajaActualmente && itemA.fgFallecido == Book.fgFallecido)
//                //            {
//                //                IndicadoresVM IndicadorTL = new IndicadoresVM();
//                //                IndicadorTL.nbCampo = (Book.fgTrabajaActualmente == true) ? "SI" : "NO";
//                //                IndicadorTL.nbCampo2 = (Book.fgFallecido == true) ? "SI" : "NO";
//                //                IndicadorTL.numCampo = 1;
//                //                IndicadoresTF.Add(IndicadorTL);
//                //            }
//                //        }
//                //    }
//                //    else if (Book.fgFallecido != null && Book.fgTrabajaActualmente == null)
//                //    {
//                //        foreach (var itemA in Alumnos)
//                //        {
//                //            if (itemA.fgTrabajaActualmente == true && itemA.fgFallecido == Book.fgFallecido)
//                //            {
//                //                IndicadoresVM IndicadorTL = new IndicadoresVM();
//                //                IndicadorTL.nbCampo = "SI";
//                //                IndicadorTL.nbCampo2 = (Book.fgFallecido == true) ? "SI" : "NO";
//                //                IndicadorTL.numCampo = 1;
//                //                IndicadoresTF.Add(IndicadorTL);
//                //            }
//                //            else if (itemA.fgTrabajaActualmente == false && itemA.fgFallecido == Book.fgFallecido)
//                //            {
//                //                IndicadoresVM IndicadorTLN = new IndicadoresVM();
//                //                IndicadorTLN.nbCampo = "NO";
//                //                IndicadorTLN.nbCampo2 = (Book.fgFallecido == true) ? "SI" : "NO";
//                //                IndicadorTLN.numCampo = 1;
//                //                IndicadoresTF.Add(IndicadorTLN);
//                //            }
//                //        }
//                //    }
//                //    else if (Book.fgFallecido == null && Book.fgTrabajaActualmente == null)
//                //    {
//                //        foreach (var itemA in Alumnos)
//                //        {
//                //            if (itemA.fgTrabajaActualmente == true && itemA.fgFallecido == true)
//                //            {
//                //                IndicadoresVM IndicadorTL = new IndicadoresVM();
//                //                IndicadorTL.nbCampo = "SI";
//                //                IndicadorTL.nbCampo2 = "SI";
//                //                IndicadorTL.numCampo = 1;
//                //                IndicadoresTF.Add(IndicadorTL);
//                //            }
//                //            else if (itemA.fgTrabajaActualmente == false && itemA.fgFallecido == true)
//                //            {
//                //                IndicadoresVM IndicadorNTL = new IndicadoresVM();
//                //                IndicadorNTL.nbCampo = "NO";
//                //                IndicadorNTL.nbCampo2 = "SI";
//                //                IndicadorNTL.numCampo = 1;
//                //                IndicadoresTF.Add(IndicadorNTL);
//                //            }
//                //            else if (itemA.fgTrabajaActualmente == true && itemA.fgFallecido == false)
//                //            {
//                //                IndicadoresVM IndicadorTNL = new IndicadoresVM();
//                //                IndicadorTNL.nbCampo = "SI";
//                //                IndicadorTNL.nbCampo2 = "NO";
//                //                IndicadorTNL.numCampo = 1;
//                //                IndicadoresTF.Add(IndicadorTNL);
//                //            }
//                //            else if (itemA.fgTrabajaActualmente == false && itemA.fgFallecido == false)
//                //            {
//                //                IndicadoresVM IndicadorTNL = new IndicadoresVM();
//                //                IndicadorTNL.nbCampo = "NO";
//                //                IndicadorTNL.nbCampo2 = "NO";
//                //                IndicadorTNL.numCampo = 1;
//                //                IndicadoresTF.Add(IndicadorTNL);
//                //            }
//                //        }
//                //    }
//                //    else if (Book.fgFallecido == null && Book.fgTrabajaActualmente != null)
//                //    {
//                //        foreach (var itemA in Alumnos)
//                //        {
//                //            if (itemA.fgTrabajaActualmente == Book.fgTrabajaActualmente && itemA.fgFallecido == true)
//                //            {
//                //                IndicadoresVM IndicadorTNL = new IndicadoresVM();
//                //                IndicadorTNL.nbCampo = (Book.fgTrabajaActualmente == true) ? "SI" : "NO";
//                //                IndicadorTNL.nbCampo2 = "SI";
//                //                IndicadorTNL.numCampo = 1;
//                //                IndicadoresTF.Add(IndicadorTNL);
//                //            }
//                //            else if (itemA.fgTrabajaActualmente == Book.fgTrabajaActualmente && itemA.fgFallecido == false)
//                //            {
//                //                IndicadoresVM IndicadorNTNL = new IndicadoresVM();
//                //                IndicadorNTNL.nbCampo = (Book.fgTrabajaActualmente == true) ? "SI" : "NO";
//                //                IndicadorNTNL.nbCampo2 = "NO";
//                //                IndicadorNTNL.numCampo = 1;
//                //                IndicadoresTF.Add(IndicadorNTNL);
//                //            }
//                //        }
//                //    }

//                //    IndicadoresTF.ToList().ForEach(l =>
//                //    {
//                //        var row = dt.NewRow();
//                //        row["nbCategoria"] = l.nbCampo;
//                //        row["nbCategoria2"] = l.nbCampo2;
//                //        row["numDatos"] = l.numCampo;
//                //        dt.Rows.Add(row);
//                //    });

//                //    #endregion
//                //}
//                //else if (listacaCampos[0] == 11 && listacaCampos[1] == 2)
//                //{
//                //    #region

//                //    TituloColumna1 = "Tipo de Sangre";
//                //    TituloColumna2 = "Estado Civil";
//                //    TituloColumna3 = "Cantidad";
//                //    TituloGrafic = "Gráfica de barras por Tipo de Sangre y Estado Civil";
//                //    var CatEstadosCiviles = db.CatEstadosCiviles.ToList();
//                //    var CatTiposSangre = db.CatTiposSangre.ToList();
//                //    List<IndicadoresVM> IndicadoresEdoCTpSangre = new List<IndicadoresVM>();
//                //    if (Book.idEstadoCivil != null && Book.idTipoSangre != null)
//                //    {
//                //        foreach (var item in Alumnos)
//                //        {
//                //            var EstadoCivil = db.CatEstadosCiviles.Find(Book.idEstadoCivil);
//                //            var TipoSangre = db.CatTiposSangre.Find(Book.idTipoSangre);
//                //            if (item.idTipoSangre == TipoSangre.idTipoSangre && item.idEstadoCivil == EstadoCivil.idEstadoCivil)
//                //            {
//                //                IndicadoresVM IndicadorECtpSangre = new IndicadoresVM();
//                //                IndicadorECtpSangre.nbCampo = TipoSangre.nbTipoSangre;
//                //                IndicadorECtpSangre.nbCampo2 = EstadoCivil.nbEstadoCivil;
//                //                IndicadorECtpSangre.numCampo = 1;
//                //                IndicadoresEdoCTpSangre.Add(IndicadorECtpSangre);
//                //            }
//                //        }
//                //    }
//                //    else if (Book.idEstadoCivil != null && Book.idTipoSangre == null)
//                //    {
//                //        foreach (var itemTS in CatTiposSangre)
//                //        {
//                //            foreach (var item in Alumnos)
//                //            {
//                //                var EstadoCivil = db.CatEstadosCiviles.Find(Book.idEstadoCivil);
//                //                var TipoSangre = db.CatTiposSangre.Find(itemTS.idTipoSangre);
//                //                if (item.idTipoSangre == TipoSangre.idTipoSangre && item.idEstadoCivil == EstadoCivil.idEstadoCivil)
//                //                {
//                //                    IndicadoresVM IndicadorECtpSangre = new IndicadoresVM();
//                //                    IndicadorECtpSangre.nbCampo = TipoSangre.nbTipoSangre;
//                //                    IndicadorECtpSangre.nbCampo2 = EstadoCivil.nbEstadoCivil;
//                //                    IndicadorECtpSangre.numCampo = 1;
//                //                    IndicadoresEdoCTpSangre.Add(IndicadorECtpSangre);
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (Book.idEstadoCivil == null && Book.idTipoSangre == null)
//                //    {
//                //        foreach (var itemEC in CatEstadosCiviles)
//                //        {
//                //            foreach (var itemTS in CatTiposSangre)
//                //            {
//                //                foreach (var item in Alumnos)
//                //                {
//                //                    var EstadoCivil = db.CatEstadosCiviles.Find(itemEC.idEstadoCivil);
//                //                    var TipoSangre = db.CatTiposSangre.Find(itemTS.idTipoSangre);
//                //                    if (item.idTipoSangre == TipoSangre.idTipoSangre && item.idEstadoCivil == EstadoCivil.idEstadoCivil)
//                //                    {
//                //                        IndicadoresVM IndicadorECtpSangre = new IndicadoresVM();
//                //                        IndicadorECtpSangre.nbCampo = TipoSangre.nbTipoSangre;
//                //                        IndicadorECtpSangre.nbCampo2 = EstadoCivil.nbEstadoCivil;
//                //                        IndicadorECtpSangre.numCampo = 1;
//                //                        IndicadoresEdoCTpSangre.Add(IndicadorECtpSangre);
//                //                    }
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (Book.idEstadoCivil == null && Book.idTipoSangre != null)
//                //    {
//                //        foreach (var itemEC in CatEstadosCiviles)
//                //        {
//                //            foreach (var item in Alumnos)
//                //            {
//                //                var EstadoCivil = db.CatEstadosCiviles.Find(itemEC.idEstadoCivil);
//                //                var TipoSangre = db.CatTiposSangre.Find(Book.idTipoSangre);
//                //                if (item.idTipoSangre == TipoSangre.idTipoSangre && item.idEstadoCivil == EstadoCivil.idEstadoCivil)
//                //                {
//                //                    IndicadoresVM IndicadorECtpSangre = new IndicadoresVM();
//                //                    IndicadorECtpSangre.nbCampo = TipoSangre.nbTipoSangre;
//                //                    IndicadorECtpSangre.nbCampo2 = EstadoCivil.nbEstadoCivil;
//                //                    IndicadorECtpSangre.numCampo = 1;
//                //                    IndicadoresEdoCTpSangre.Add(IndicadorECtpSangre);
//                //                }
//                //            }
//                //        }
//                //    }

//                //    IndicadoresEdoCTpSangre.ToList().ForEach(l =>
//                //    {
//                //        var row = dt.NewRow();
//                //        row["nbCategoria"] = l.nbCampo;
//                //        row["nbCategoria2"] = l.nbCampo2;
//                //        row["numDatos"] = l.numCampo;
//                //        dt.Rows.Add(row);
//                //    });

//                //    #endregion
//                //}
//                //else if (listacaCampos[0] == 11 && listacaCampos[1] == 3)
//                //{
//                //    #region

//                //    TituloColumna1 = "Tipo de Sangre";
//                //    TituloColumna2 = "Edad";
//                //    TituloColumna3 = "Cantidad";
//                //    TituloGrafic = "Gráfica de barras por Tipo de Sangre y Edad";

//                //    var CatTiposSangre = db.CatTiposSangre.ToList();
//                //    List<IndicadoresVM> ListaEdadTpSangre = new List<IndicadoresVM>();

//                //    if (Book.numEdadMinima != null && Book.numEdadMinima != null && Book.idTipoSangre != null)
//                //    {
//                //        for (var i = Book.numEdadMinima; i <= Book.numEdadMaxima; i++)
//                //        {
//                //            foreach (var item in Alumnos)
//                //            {
//                //                var TipoSangre = db.CatTiposSangre.Find(Book.idTipoSangre);
//                //                var edad = DateTime.Now.Year - ((DateTime)item.feNacimiento).Date.Year;
//                //                if (edad == i && item.idTipoSangre == TipoSangre.idTipoSangre)
//                //                {
//                //                    IndicadoresVM IndicadorEdadS = new IndicadoresVM();
//                //                    IndicadorEdadS.nbCampo = TipoSangre.nbTipoSangre.Trim();
//                //                    IndicadorEdadS.nbCampo2 = i + " Años";
//                //                    IndicadorEdadS.numCampo = 1;
//                //                    ListaEdadTpSangre.Add(IndicadorEdadS);
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (Book.numEdadMinima != null && Book.numEdadMinima != null && Book.idTipoSangre == null)
//                //    {
//                //        for (var i = Book.numEdadMinima; i <= Book.numEdadMaxima; i++)
//                //        {
//                //            foreach (var item in Alumnos)
//                //            {
//                //                foreach (var itemS in CatTiposSangre)
//                //                {
//                //                    var edad = DateTime.Now.Year - ((DateTime)item.feNacimiento).Date.Year;
//                //                    if (edad == i && item.Personas.idGenero == itemS.idTipoSangre)
//                //                    {
//                //                        IndicadoresVM IndicadorEdadS = new IndicadoresVM();
//                //                        IndicadorEdadS.nbCampo = itemS.nbTipoSangre.Trim();
//                //                        IndicadorEdadS.nbCampo2 = i + " Años";
//                //                        IndicadorEdadS.numCampo = 1;
//                //                        ListaEdadTpSangre.Add(IndicadorEdadS);
//                //                    }
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (Book.numEdadMinima == null && Book.numEdadMinima == null && Book.idTipoSangre != null)
//                //    {
//                //        for (var i = 15; i <= 80; i++)
//                //        {
//                //            foreach (var item in Alumnos)
//                //            {
//                //                var TipoSangre = db.CatTiposSangre.Find(Book.idTipoSangre);
//                //                var edad = DateTime.Now.Year - ((DateTime)item.feNacimiento).Date.Year;
//                //                if (edad == i && item.idTipoSangre == TipoSangre.idTipoSangre)
//                //                {
//                //                    IndicadoresVM IndicadorEdadS = new IndicadoresVM();
//                //                    IndicadorEdadS.nbCampo = TipoSangre.nbTipoSangre.Trim();
//                //                    IndicadorEdadS.nbCampo2 = i + " Años";
//                //                    IndicadorEdadS.numCampo = 1;
//                //                    ListaEdadTpSangre.Add(IndicadorEdadS);
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (Book.numEdadMinima == null && Book.numEdadMinima == null && Book.idTipoSangre == null)
//                //    {
//                //        for (var i = 15; i <= 80; i++)
//                //        {
//                //            foreach (var item in Alumnos)
//                //            {
//                //                foreach (var itemS in CatTiposSangre)
//                //                {
//                //                    var edad = DateTime.Now.Year - ((DateTime)item.feNacimiento).Date.Year;
//                //                    if (edad == i && item.Personas.idGenero == itemS.idTipoSangre)
//                //                    {
//                //                        IndicadoresVM IndicadorEdadS = new IndicadoresVM();
//                //                        IndicadorEdadS.nbCampo = itemS.nbTipoSangre.Trim();
//                //                        IndicadorEdadS.nbCampo2 = i + " Años";
//                //                        IndicadorEdadS.numCampo = 1;
//                //                        ListaEdadTpSangre.Add(IndicadorEdadS);
//                //                    }
//                //                }
//                //            }
//                //        }
//                //    }

//                //    ListaEdadTpSangre.ToList().ForEach(t =>
//                //    {
//                //        var row = dt.NewRow();
//                //        row["nbCategoria"] = t.nbCampo;
//                //        row["nbCategoria2"] = t.nbCampo2;
//                //        row["numDatos"] = t.numCampo;
//                //        dt.Rows.Add(row);
//                //    });

//                //    #endregion
//                //}
//                //else if (listacaCampos[0] == 11 && listacaCampos[1] == 6)
//                //{
//                //    #region
//                //    TituloColumna1 = "Tipo de Sangre";
//                //    TituloColumna2 = "Edad";
//                //    TituloColumna3 = "Cantidad";
//                //    TituloGrafic = "Gráfica de barras por Tipo de Sangre y Edad";


//                //    var CatGeneros = db.CatGeneros.ToList();
//                //    var CatTiposSangre = db.CatTiposSangre.ToList();
//                //    List<IndicadoresVM> ListaGenTipoSangre = new List<IndicadoresVM>();
//                //    if (Book.idTipoSangre != null && Book.idGenero != null)
//                //    {
//                //        foreach (var itemA in Alumnos)
//                //        {
//                //            var Genero = db.CatGeneros.Find(Book.idGenero);
//                //            var TipoSangre = db.CatTiposSangre.Find(Book.idTipoSangre);
//                //            if (itemA.Personas.idGenero == Genero.idGenero && itemA.idTipoSangre == TipoSangre.idTipoSangre)
//                //            {
//                //                IndicadoresVM IndicadorGS = new IndicadoresVM();
//                //                IndicadorGS.nbCampo = TipoSangre.nbTipoSangre.Trim();
//                //                IndicadorGS.nbCampo2 = Genero.nbGenero;
//                //                IndicadorGS.numCampo = 1;
//                //                ListaGenTipoSangre.Add(IndicadorGS);
//                //            }
//                //        }
//                //    }
//                //    else if (Book.idTipoSangre != null && Book.idGenero == null)
//                //    {
//                //        foreach (var itemG in CatGeneros)
//                //        {
//                //            foreach (var itemA in Alumnos)
//                //            {
//                //                var Genero = db.CatGeneros.Find(itemG.idGenero);
//                //                var TipoSangre = db.CatTiposSangre.Find(Book.idTipoSangre);
//                //                if (itemA.Personas.idGenero == Genero.idGenero && itemA.idTipoSangre == TipoSangre.idTipoSangre)
//                //                {
//                //                    IndicadoresVM IndicadorGS = new IndicadoresVM();
//                //                    IndicadorGS.nbCampo = TipoSangre.nbTipoSangre.Trim();
//                //                    IndicadorGS.nbCampo2 = Genero.nbGenero;
//                //                    IndicadorGS.numCampo = 1;
//                //                    ListaGenTipoSangre.Add(IndicadorGS);
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (Book.idTipoSangre == null && Book.idGenero != null)
//                //    {
//                //        foreach (var itemS in CatTiposSangre)
//                //        {
//                //            foreach (var itemA in Alumnos)
//                //            {
//                //                var Genero = db.CatGeneros.Find(Book.idGenero);
//                //                var TipoSangre = db.CatTiposSangre.Find(itemS.idTipoSangre);
//                //                if (itemA.Personas.idGenero == Genero.idGenero && itemA.idTipoSangre == TipoSangre.idTipoSangre)
//                //                {
//                //                    IndicadoresVM IndicadorGS = new IndicadoresVM();
//                //                    IndicadorGS.nbCampo = TipoSangre.nbTipoSangre.Trim();
//                //                    IndicadorGS.nbCampo2 = Genero.nbGenero;
//                //                    IndicadorGS.numCampo = 1;
//                //                    ListaGenTipoSangre.Add(IndicadorGS);
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (Book.idTipoSangre == null && Book.idGenero == null)
//                //    {
//                //        foreach (var itemS in CatTiposSangre)
//                //        {
//                //            foreach (var itemG in CatGeneros)
//                //            {
//                //                foreach (var itemA in Alumnos)
//                //                {
//                //                    var Genero = db.CatGeneros.Find(itemG.idGenero);
//                //                    var TipoSangre = db.CatTiposSangre.Find(itemS.idTipoSangre);
//                //                    if (itemA.Personas.idGenero == Genero.idGenero && itemA.idTipoSangre == TipoSangre.idTipoSangre)
//                //                    {
//                //                        IndicadoresVM IndicadorGS = new IndicadoresVM();
//                //                        IndicadorGS.nbCampo = TipoSangre.nbTipoSangre.Trim();
//                //                        IndicadorGS.nbCampo2 = Genero.nbGenero;
//                //                        IndicadorGS.numCampo = 1;
//                //                        ListaGenTipoSangre.Add(IndicadorGS);
//                //                    }
//                //                }
//                //            }
//                //        }
//                //    }

//                //    ListaGenTipoSangre.ToList().ForEach(t =>
//                //    {
//                //        var row = dt.NewRow();
//                //        row["nbCategoria"] = t.nbCampo;
//                //        row["nbCategoria2"] = t.nbCampo2;
//                //        row["numDatos"] = t.numCampo;
//                //        dt.Rows.Add(row);
//                //    });

//                //    #endregion
//                //}
//                //else if (listacaCampos[0] == 11 && listacaCampos[1] == 7)
//                //{
//                //    #region

//                //    TituloColumna1 = "Tipo de Sangre";
//                //    TituloColumna2 = "Licenciatura";
//                //    TituloColumna3 = "Cantidad";
//                //    TituloGrafic = "Gráfica de barras por Tipo de Sangre y Licenciatura";

//                //    Licenciaturas Licenciatura = new Licenciaturas();
//                //    var Licenciaturas = db.Licenciaturas.ToList();
//                //    var CatTiposSangre = db.CatTiposSangre.ToList();
//                //    List<IndicadoresVM> IndicadoresLicSangre = new List<IndicadoresVM>();
//                //    List<Alumnos> AlumnosLic = new List<Alumnos>();

//                //    if (Book.idTipoSangre != null && listaIdsLicenciaturas.Count > 0)
//                //    {
//                //        foreach (var itemL in listaIdsLicenciaturas)
//                //        {
//                //            foreach (var itemA in Alumnos)
//                //            {
//                //                var idLicenciatura = Convert.ToInt64(itemL);
//                //                Licenciatura = Licenciaturas.FirstOrDefault(x => x.idLicenciatura == idLicenciatura);
//                //                var TipoSangre = db.CatTiposSangre.Find(Book.idTipoSangre);
//                //                var FormacionesA = db.FormacionesAcademicas.Where(x => x.idAlumno == itemA.idAlumno && x.idLicenciatura == Licenciatura.idLicenciatura).ToList();
//                //                if (itemA.idTipoSangre == TipoSangre.idTipoSangre && FormacionesA.Count() > 0)
//                //                {
//                //                    IndicadoresVM IndicadorLS = new IndicadoresVM();
//                //                    IndicadorLS.nbCampo = TipoSangre.nbTipoSangre.Trim();
//                //                    IndicadorLS.nbCampo2 = Licenciatura.nbLicenciatura;
//                //                    IndicadorLS.numCampo = 1;
//                //                    IndicadoresLicSangre.Add(IndicadorLS);
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (Book.idTipoSangre == null && listaIdsLicenciaturas.Count > 0)
//                //    {
//                //        foreach (var itemL in listaIdsLicenciaturas)
//                //        {
//                //            foreach (var itemS in CatTiposSangre)
//                //            {
//                //                foreach (var itemA in Alumnos)
//                //                {
//                //                    var idLicenciatura = Convert.ToInt64(itemL);
//                //                    Licenciatura = Licenciaturas.FirstOrDefault(x => x.idLicenciatura == idLicenciatura);
//                //                    var TipoSangre = db.CatTiposSangre.Find(itemS.idTipoSangre);
//                //                    var FormacionesA = db.FormacionesAcademicas.Where(x => x.idAlumno == itemA.idAlumno && x.idLicenciatura == Licenciatura.idLicenciatura).ToList();
//                //                    if (itemA.idTipoSangre == TipoSangre.idTipoSangre && FormacionesA.Count() > 0)
//                //                    {
//                //                        IndicadoresVM IndicadorLS = new IndicadoresVM();
//                //                        IndicadorLS.nbCampo = TipoSangre.nbTipoSangre.Trim();
//                //                        IndicadorLS.nbCampo2 = Licenciatura.nbLicenciatura;
//                //                        IndicadorLS.numCampo = 1;
//                //                        IndicadoresLicSangre.Add(IndicadorLS);
//                //                    }
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (Book.idEstadoCivil == null && listaIdsLicenciaturas.Count == 0)
//                //    {
//                //        foreach (var itemL in Licenciaturas)
//                //        {
//                //            foreach (var itemS in CatTiposSangre)
//                //            {
//                //                foreach (var itemA in Alumnos)
//                //                {
//                //                    //var idLicenciatura = Convert.ToInt64(itemL);
//                //                    Licenciatura = Licenciaturas.FirstOrDefault(x => x.idLicenciatura == itemL.idLicenciatura);
//                //                    var TipoSangre = db.CatTiposSangre.Find(itemS.idTipoSangre);
//                //                    var FormacionesA = db.FormacionesAcademicas.Where(x => x.idAlumno == itemA.idAlumno && x.idLicenciatura == Licenciatura.idLicenciatura).ToList();
//                //                    if (itemA.idTipoSangre == TipoSangre.idTipoSangre && FormacionesA.Count() > 0)
//                //                    {
//                //                        IndicadoresVM IndicadorLS = new IndicadoresVM();
//                //                        IndicadorLS.nbCampo = TipoSangre.nbTipoSangre.Trim();
//                //                        IndicadorLS.nbCampo2 = Licenciatura.nbLicenciatura;
//                //                        IndicadorLS.numCampo = 1;
//                //                        IndicadoresLicSangre.Add(IndicadorLS);
//                //                    }
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (Book.idTipoSangre != null && listaIdsLicenciaturas.Count == 0)
//                //    {
//                //        foreach (var itemL in Licenciaturas)
//                //        {
//                //            foreach (var itemA in Alumnos)
//                //            {
//                //                //var idLicenciatura = Convert.ToInt64(itemL);
//                //                Licenciatura = Licenciaturas.FirstOrDefault(x => x.idLicenciatura == itemL.idLicenciatura);
//                //                var TipoSangre = db.CatTiposSangre.Find(Book.idTipoSangre);
//                //                var FormacionesA = db.FormacionesAcademicas.Where(x => x.idAlumno == itemA.idAlumno && x.idLicenciatura == Licenciatura.idLicenciatura).ToList();
//                //                if (itemA.idTipoSangre == TipoSangre.idTipoSangre && FormacionesA.Count() > 0)
//                //                {
//                //                    IndicadoresVM IndicadorLS = new IndicadoresVM();
//                //                    IndicadorLS.nbCampo = TipoSangre.nbTipoSangre.Trim();
//                //                    IndicadorLS.nbCampo2 = Licenciatura.nbLicenciatura;
//                //                    IndicadorLS.numCampo = 1;
//                //                    IndicadoresLicSangre.Add(IndicadorLS);
//                //                }
//                //            }
//                //        }
//                //    }

//                //    IndicadoresLicSangre.ToList().ForEach(l =>
//                //    {
//                //        var row = dt.NewRow();
//                //        row["nbCategoria"] = l.nbCampo;
//                //        row["nbCategoria2"] = l.nbCampo2;
//                //        row["numDatos"] = l.numCampo;
//                //        dt.Rows.Add(row);
//                //    });

//                //    #endregion
//                //}
//                //else if (listacaCampos[0] == 11 && listacaCampos[1] == 8)
//                //{
//                //    #region

//                //    TituloColumna1 = "Tipo de Sangre";
//                //    TituloColumna2 = "Religión";
//                //    TituloColumna3 = "Cantidad";
//                //    TituloGrafic = "Gráfica de barras por Tipo de Sangre y Religión";


//                //    CatReligion Religion = new CatReligion();
//                //    var Religiones = db.CatReligion.ToList();
//                //    var CatTiposSangre = db.CatTiposSangre.ToList();
//                //    List<IndicadoresVM> IndicadoresRS = new List<IndicadoresVM>();

//                //    if (Book.idTipoSangre != null && listaIdsReligiones.Count > 0)
//                //    {
//                //        foreach (var item in listaIdsReligiones)
//                //        {
//                //            foreach (var itemA in Alumnos)
//                //            {
//                //                var idReligion = Convert.ToInt64(item);
//                //                Religion = Religiones.FirstOrDefault(x => x.idReligion == idReligion);
//                //                var TipoSangre = db.CatTiposSangre.Find(Book.idTipoSangre);
//                //                if (itemA.idTipoSangre == TipoSangre.idTipoSangre && itemA.idReligion == Religion.idReligion)
//                //                {
//                //                    IndicadoresVM IndicadoRS = new IndicadoresVM();
//                //                    IndicadoRS.nbCampo = TipoSangre.nbTipoSangre.Trim();
//                //                    IndicadoRS.nbCampo2 = Religion.nbReligion;
//                //                    IndicadoRS.numCampo = 1;
//                //                    IndicadoresRS.Add(IndicadoRS);
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (Book.idTipoSangre == null && listaIdsReligiones.Count > 0)
//                //    {
//                //        foreach (var item in listaIdsReligiones)
//                //        {
//                //            foreach (var itemS in CatTiposSangre)
//                //            {
//                //                foreach (var itemA in Alumnos)
//                //                {
//                //                    var idReligion = Convert.ToInt64(item);
//                //                    Religion = Religiones.FirstOrDefault(x => x.idReligion == idReligion);
//                //                    var TipoSangre = db.CatTiposSangre.Find(itemS.idTipoSangre);
//                //                    if (itemA.idTipoSangre == TipoSangre.idTipoSangre && itemA.idReligion == Religion.idReligion)
//                //                    {
//                //                        IndicadoresVM IndicadoRS = new IndicadoresVM();
//                //                        IndicadoRS.nbCampo = TipoSangre.nbTipoSangre.Trim();
//                //                        IndicadoRS.nbCampo2 = Religion.nbReligion;
//                //                        IndicadoRS.numCampo = 1;
//                //                        IndicadoresRS.Add(IndicadoRS);
//                //                    }
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (Book.idTipoSangre == null && listaIdsReligiones.Count == 0)
//                //    {
//                //        foreach (var item in Religiones)
//                //        {
//                //            foreach (var itemS in CatTiposSangre)
//                //            {
//                //                foreach (var itemA in Alumnos)
//                //                {
//                //                    //var idReligion = Convert.ToInt64(item);
//                //                    Religion = Religiones.FirstOrDefault(x => x.idReligion == item.idReligion);
//                //                    var TipoSangre = db.CatTiposSangre.Find(itemS.idTipoSangre);
//                //                    if (itemA.idTipoSangre == TipoSangre.idTipoSangre && itemA.idReligion == Religion.idReligion)
//                //                    {
//                //                        IndicadoresVM IndicadoRS = new IndicadoresVM();
//                //                        IndicadoRS.nbCampo = TipoSangre.nbTipoSangre.Trim();
//                //                        IndicadoRS.nbCampo2 = Religion.nbReligion;
//                //                        IndicadoRS.numCampo = 1;
//                //                        IndicadoresRS.Add(IndicadoRS);
//                //                    }
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (Book.idTipoSangre != null && listaIdsReligiones.Count == 0)
//                //    {
//                //        foreach (var item in Religiones)
//                //        {
//                //            foreach (var itemA in Alumnos)
//                //            {
//                //                //var idReligion = Convert.ToInt64(item);
//                //                Religion = Religiones.FirstOrDefault(x => x.idReligion == item.idReligion);
//                //                var TipoSangre = db.CatTiposSangre.Find(Book.idTipoSangre);
//                //                if (itemA.idTipoSangre == TipoSangre.idTipoSangre && itemA.idReligion == Religion.idReligion)
//                //                {
//                //                    IndicadoresVM IndicadoRS = new IndicadoresVM();
//                //                    IndicadoRS.nbCampo = TipoSangre.nbTipoSangre.Trim();
//                //                    IndicadoRS.nbCampo2 = Religion.nbReligion;
//                //                    IndicadoRS.numCampo = 1;
//                //                    IndicadoresRS.Add(IndicadoRS);
//                //                }
//                //            }
//                //        }
//                //    }

//                //    IndicadoresRS.ToList().ForEach(l =>
//                //    {
//                //        var row = dt.NewRow();
//                //        row["nbCategoria"] = l.nbCampo;
//                //        row["nbCategoria2"] = l.nbCampo2;
//                //        row["numDatos"] = l.numCampo;
//                //        dt.Rows.Add(row);
//                //    });

//                //    #endregion
//                //}
//                //else if (listacaCampos[0] == 11 && listacaCampos[1] == 9)
//                //{
//                //    #region

//                //    TituloColumna1 = "Tipo de Sangre";
//                //    TituloColumna2 = "Estado";
//                //    TituloColumna3 = "Cantidad";
//                //    TituloGrafic = "Gráfica de barras por Tipo de Sangre y Estado";
//                //    var Estado = new CatEstados();
//                //    var Estados = db.CatEstados.ToList();
//                //    var CatTiposSangre = db.CatTiposSangre.ToList();
//                //    List<IndicadoresVM> IndicadoresEdosSangre = new List<IndicadoresVM>();
//                //    if (Book.idTipoSangre != null && listaIdsestados.Count > 0)
//                //    {
//                //        foreach (var item in listaIdsestados)
//                //        {
//                //            foreach (var itemA in Alumnos)
//                //            {
//                //                var idEstado = Convert.ToInt64(item);
//                //                Estado = Estados.FirstOrDefault(x => x.idEstado == idEstado);
//                //                var TipoSangre = db.CatTiposSangre.Find(Book.idTipoSangre);
//                //                if (itemA.idTipoSangre == TipoSangre.idTipoSangre && itemA.Direcciones.nbEstado.Trim().ToUpper() == Estado.nbEstado.Trim().ToUpper())
//                //                {
//                //                    IndicadoresVM IndicadorES = new IndicadoresVM();
//                //                    IndicadorES.nbCampo = TipoSangre.nbTipoSangre.Trim();
//                //                    IndicadorES.nbCampo2 = Estado.nbEstado;
//                //                    IndicadorES.numCampo = 1;
//                //                    IndicadoresEdosSangre.Add(IndicadorES);
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (Book.idTipoSangre == null && listaIdsestados.Count > 0)
//                //    {
//                //        foreach (var item in listaIdsestados)
//                //        {
//                //            foreach (var itemS in CatTiposSangre)
//                //            {
//                //                foreach (var itemA in Alumnos)
//                //                {
//                //                    var idEstado = Convert.ToInt64(item);
//                //                    Estado = Estados.FirstOrDefault(x => x.idEstado == idEstado);
//                //                    var TipoSangre = db.CatTiposSangre.Find(itemS.idTipoSangre);
//                //                    if (itemA.idTipoSangre == TipoSangre.idTipoSangre && itemA.Direcciones.nbEstado.Trim().ToUpper() == Estado.nbEstado.Trim().ToUpper())
//                //                    {
//                //                        IndicadoresVM IndicadorES = new IndicadoresVM();
//                //                        IndicadorES.nbCampo = TipoSangre.nbTipoSangre.Trim();
//                //                        IndicadorES.nbCampo2 = Estado.nbEstado;
//                //                        IndicadorES.numCampo = 1;
//                //                        IndicadoresEdosSangre.Add(IndicadorES);
//                //                    }
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (Book.idTipoSangre == null && listaIdsestados.Count == 0)
//                //    {
//                //        foreach (var item in Estados)
//                //        {
//                //            foreach (var itemS in CatTiposSangre)
//                //            {
//                //                foreach (var itemA in Alumnos)
//                //                {
//                //                    //var idEstado = Convert.ToInt64(item);
//                //                    Estado = Estados.FirstOrDefault(x => x.idEstado == item.idEstado);
//                //                    var TipoSangre = db.CatTiposSangre.Find(itemS.idTipoSangre);
//                //                    if (itemA.idTipoSangre == TipoSangre.idTipoSangre && itemA.Direcciones.nbEstado.Trim().ToUpper() == Estado.nbEstado.Trim().ToUpper())
//                //                    {
//                //                        IndicadoresVM IndicadorES = new IndicadoresVM();
//                //                        IndicadorES.nbCampo = TipoSangre.nbTipoSangre.Trim();
//                //                        IndicadorES.nbCampo2 = Estado.nbEstado;
//                //                        IndicadorES.numCampo = 1;
//                //                        IndicadoresEdosSangre.Add(IndicadorES);
//                //                    }
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (Book.idTipoSangre != null && listaIdsestados.Count == 0)
//                //    {
//                //        foreach (var item in Estados)
//                //        {
//                //            foreach (var itemA in Alumnos)
//                //            {
//                //                //var idEstado = Convert.ToInt64(item);
//                //                Estado = Estados.FirstOrDefault(x => x.idEstado == item.idEstado);
//                //                var TipoSangre = db.CatTiposSangre.Find(Book.idTipoSangre);
//                //                if (itemA.idTipoSangre == TipoSangre.idTipoSangre && itemA.Direcciones.nbEstado.Trim().ToUpper() == Estado.nbEstado.Trim().ToUpper())
//                //                {
//                //                    IndicadoresVM IndicadorES = new IndicadoresVM();
//                //                    IndicadorES.nbCampo = TipoSangre.nbTipoSangre.Trim();
//                //                    IndicadorES.nbCampo2 = Estado.nbEstado;
//                //                    IndicadorES.numCampo = 1;
//                //                    IndicadoresEdosSangre.Add(IndicadorES);
//                //                }
//                //            }
//                //        }
//                //    }

//                //    IndicadoresEdosSangre.ToList().ForEach(l =>
//                //    {
//                //        var row = dt.NewRow();
//                //        row["nbCategoria"] = l.nbCampo;
//                //        row["nbCategoria2"] = l.nbCampo2;
//                //        row["numDatos"] = l.numCampo;
//                //        dt.Rows.Add(row);
//                //    });

//                //    #endregion
//                //}
//                //else if (listacaCampos[0] == 11 && listacaCampos[1] == 10)
//                //{
//                //    #region

//                //    TituloColumna1 = "Tipo de Sangre";
//                //    TituloColumna2 = "Trabajo";
//                //    TituloColumna3 = "Cantidad";
//                //    TituloGrafic = "Gráfica de barras por Tipo de Sangre y Trabajo";
//                //    var CatTiposSangre = db.CatTiposSangre.ToList();
//                //    List<IndicadoresVM> IndicadoresTS = new List<IndicadoresVM>();
//                //    if (Book.idTipoSangre != null && Book.fgTrabajaActualmente != null)
//                //    {
//                //        foreach (var itemA in Alumnos)
//                //        {
//                //            var TipoSangre = db.CatTiposSangre.Find(Book.idTipoSangre);
//                //            if (itemA.fgTrabajaActualmente == Book.fgTrabajaActualmente && itemA.idTipoSangre == TipoSangre.idTipoSangre)
//                //            {
//                //                IndicadoresVM IndicadorTS = new IndicadoresVM();
//                //                IndicadorTS.nbCampo = TipoSangre.nbTipoSangre;
//                //                IndicadorTS.nbCampo2 = (Book.fgTrabajaActualmente == true) ? "SI" : "NO";
//                //                IndicadorTS.numCampo = 1;
//                //                IndicadoresTS.Add(IndicadorTS);
//                //            }
//                //        }
//                //    }
//                //    else if (Book.idTipoSangre != null && Book.fgTrabajaActualmente == null)
//                //    {
//                //        foreach (var itemA in Alumnos)
//                //        {
//                //            var TipoSangre = db.CatTiposSangre.Find(Book.idTipoSangre);
//                //            if (itemA.fgTrabajaActualmente == true && itemA.idTipoSangre == TipoSangre.idTipoSangre)
//                //            {
//                //                IndicadoresVM IndicadorTS = new IndicadoresVM();
//                //                IndicadorTS.nbCampo = TipoSangre.nbTipoSangre;
//                //                IndicadorTS.nbCampo2 = "SI";
//                //                IndicadorTS.numCampo = 1;
//                //                IndicadoresTS.Add(IndicadorTS);
//                //            }
//                //            else if (itemA.fgTrabajaActualmente == false && itemA.idTipoSangre == TipoSangre.idTipoSangre)
//                //            {
//                //                IndicadoresVM IndicadorTSN = new IndicadoresVM();
//                //                IndicadorTSN.nbCampo = TipoSangre.nbTipoSangre;
//                //                IndicadorTSN.nbCampo2 = "NO";
//                //                IndicadorTSN.numCampo = 1;
//                //                IndicadoresTS.Add(IndicadorTSN);
//                //            }
//                //        }
//                //    }
//                //    else if (Book.idTipoSangre == null && Book.fgTrabajaActualmente == null)
//                //    {
//                //        foreach (var itemS in CatTiposSangre)
//                //        {
//                //            foreach (var itemA in Alumnos)
//                //            {
//                //                var TipoSangre = db.CatTiposSangre.Find(itemS.idTipoSangre);
//                //                if (itemA.fgTrabajaActualmente == true && itemA.idTipoSangre == TipoSangre.idTipoSangre)
//                //                {
//                //                    IndicadoresVM IndicadorTS = new IndicadoresVM();
//                //                    IndicadorTS.nbCampo = TipoSangre.nbTipoSangre;
//                //                    IndicadorTS.nbCampo2 = "SI";
//                //                    IndicadorTS.numCampo = 1;
//                //                    IndicadoresTS.Add(IndicadorTS);
//                //                }
//                //                else if (itemA.fgTrabajaActualmente == false && itemA.idTipoSangre == TipoSangre.idTipoSangre)
//                //                {
//                //                    IndicadoresVM IndicadorTSN = new IndicadoresVM();
//                //                    IndicadorTSN.nbCampo = TipoSangre.nbTipoSangre;
//                //                    IndicadorTSN.nbCampo2 = "NO";
//                //                    IndicadorTSN.numCampo = 1;
//                //                    IndicadoresTS.Add(IndicadorTSN);
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (Book.idTipoSangre == null && Book.fgTrabajaActualmente != null)
//                //    {
//                //        foreach (var itemS in CatTiposSangre)
//                //        {
//                //            foreach (var itemA in Alumnos)
//                //            {
//                //                var TipoSangre = db.CatTiposSangre.Find(itemS.idTipoSangre);
//                //                if (itemA.fgTrabajaActualmente == Book.fgTrabajaActualmente && itemA.idTipoSangre == TipoSangre.idTipoSangre)
//                //                {
//                //                    IndicadoresVM IndicadorTS = new IndicadoresVM();
//                //                    IndicadorTS.nbCampo = TipoSangre.nbTipoSangre;
//                //                    IndicadorTS.nbCampo2 = (Book.fgTrabajaActualmente == true) ? "SI" : "NO";
//                //                    IndicadorTS.numCampo = 1;
//                //                    IndicadoresTS.Add(IndicadorTS);
//                //                }
//                //            }

//                //        }
//                //    }

//                //    IndicadoresTS.ToList().ForEach(l =>
//                //    {
//                //        var row = dt.NewRow();
//                //        row["nbCategoria"] = l.nbCampo;
//                //        row["nbCategoria2"] = l.nbCampo2;
//                //        row["numDatos"] = l.numCampo;
//                //        dt.Rows.Add(row);
//                //    });

//                //    #endregion
//                //}
//                //else if (listacaCampos[0] == 11 && listacaCampos[1] == 12)
//                //{
//                //    #region

//                //    TituloColumna1 = "Tipo de Sangre";
//                //    TituloColumna2 = "Licencia";
//                //    TituloColumna3 = "Cantidad";
//                //    TituloGrafic = "Gráfica de barras por Tipo de Sangre y Licencia";
//                //    var CatTiposSangre = db.CatTiposSangre.ToList();
//                //    List<IndicadoresVM> IndicadoresTS = new List<IndicadoresVM>();
//                //    if (Book.idTipoSangre != null && Book.fgLicencia != null)
//                //    {
//                //        foreach (var itemA in Alumnos)
//                //        {
//                //            var TipoSangre = db.CatTiposSangre.Find(Book.idTipoSangre);
//                //            if (itemA.fgLicencia == Book.fgLicencia && itemA.idTipoSangre == TipoSangre.idTipoSangre)
//                //            {
//                //                IndicadoresVM IndicadorTS = new IndicadoresVM();
//                //                IndicadorTS.nbCampo = TipoSangre.nbTipoSangre;
//                //                IndicadorTS.nbCampo2 = (Book.fgLicencia == true) ? "SI" : "NO";
//                //                IndicadorTS.numCampo = 1;
//                //                IndicadoresTS.Add(IndicadorTS);
//                //            }
//                //        }
//                //    }
//                //    else if (Book.idTipoSangre != null && Book.fgLicencia == null)
//                //    {
//                //        foreach (var itemA in Alumnos)
//                //        {
//                //            var TipoSangre = db.CatTiposSangre.Find(Book.idTipoSangre);
//                //            if (itemA.fgLicencia == true && itemA.idTipoSangre == TipoSangre.idTipoSangre)
//                //            {
//                //                IndicadoresVM IndicadorTS = new IndicadoresVM();
//                //                IndicadorTS.nbCampo = TipoSangre.nbTipoSangre;
//                //                IndicadorTS.nbCampo2 = "SI";
//                //                IndicadorTS.numCampo = 1;
//                //                IndicadoresTS.Add(IndicadorTS);
//                //            }
//                //            else if (itemA.fgLicencia == false && itemA.idTipoSangre == TipoSangre.idTipoSangre)
//                //            {
//                //                IndicadoresVM IndicadorTSN = new IndicadoresVM();
//                //                IndicadorTSN.nbCampo = TipoSangre.nbTipoSangre;
//                //                IndicadorTSN.nbCampo2 = "NO";
//                //                IndicadorTSN.numCampo = 1;
//                //                IndicadoresTS.Add(IndicadorTSN);
//                //            }
//                //        }
//                //    }
//                //    else if (Book.idTipoSangre == null && Book.fgLicencia == null)
//                //    {
//                //        foreach (var itemS in CatTiposSangre)
//                //        {
//                //            foreach (var itemA in Alumnos)
//                //            {
//                //                var TipoSangre = db.CatTiposSangre.Find(itemS.idTipoSangre);
//                //                if (itemA.fgLicencia == true && itemA.idTipoSangre == TipoSangre.idTipoSangre)
//                //                {
//                //                    IndicadoresVM IndicadorTS = new IndicadoresVM();
//                //                    IndicadorTS.nbCampo = TipoSangre.nbTipoSangre;
//                //                    IndicadorTS.nbCampo2 = "SI";
//                //                    IndicadorTS.numCampo = 1;
//                //                    IndicadoresTS.Add(IndicadorTS);
//                //                }
//                //                else if (itemA.fgFallecido == false && itemA.idTipoSangre == TipoSangre.idTipoSangre)
//                //                {
//                //                    IndicadoresVM IndicadorTSN = new IndicadoresVM();
//                //                    IndicadorTSN.nbCampo = TipoSangre.nbTipoSangre;
//                //                    IndicadorTSN.nbCampo2 = "NO";
//                //                    IndicadorTSN.numCampo = 1;
//                //                    IndicadoresTS.Add(IndicadorTSN);
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (Book.idEstadoCivil == null && Book.fgLicencia != null)
//                //    {
//                //        foreach (var itemS in CatTiposSangre)
//                //        {
//                //            foreach (var itemA in Alumnos)
//                //            {
//                //                var TipoSangre = db.CatTiposSangre.Find(itemS.idTipoSangre);
//                //                if (itemA.fgLicencia == Book.fgLicencia && itemA.idTipoSangre == TipoSangre.idTipoSangre)
//                //                {
//                //                    IndicadoresVM IndicadorTS = new IndicadoresVM();
//                //                    IndicadorTS.nbCampo = TipoSangre.nbTipoSangre;
//                //                    IndicadorTS.nbCampo2 = (Book.fgLicencia == true) ? "SI" : "NO";
//                //                    IndicadorTS.numCampo = 1;
//                //                    IndicadoresTS.Add(IndicadorTS);
//                //                }
//                //            }

//                //        }
//                //    }

//                //    IndicadoresTS.ToList().ForEach(l =>
//                //    {
//                //        var row = dt.NewRow();
//                //        row["nbCategoria"] = l.nbCampo;
//                //        row["nbCategoria2"] = l.nbCampo2;
//                //        row["numDatos"] = l.numCampo;
//                //        dt.Rows.Add(row);
//                //    });

//                //    #endregion
//                //}
//                //else if (listacaCampos[0] == 11 && listacaCampos[1] == 13)
//                //{
//                //    #region

//                //    TituloColumna1 = "Tipo de Sangre";
//                //    TituloColumna2 = "Tipo de Egresado";
//                //    TituloColumna3 = "Cantidad";
//                //    TituloGrafic = "Gráfica de barras por Tipo de Sangre y Tipo de Egresado";
//                //    var CatTiposSangre = db.CatTiposSangre.ToList();
//                //    List<IndicadoresVM> IndicadoresTS = new List<IndicadoresVM>();
//                //    if (Book.idTipoSangre != null && Book.tpEgresado != null)
//                //    {
//                //        foreach (var itemA in Alumnos)
//                //        {
//                //            var TipoSangre = db.CatTiposSangre.Find(Book.idTipoSangre);
//                //            if (itemA.tpEgresado == Book.tpEgresado && itemA.idTipoSangre == Book.idTipoSangre)
//                //            {
//                //                IndicadoresVM IndicadorTS = new IndicadoresVM();
//                //                IndicadorTS.nbCampo = TipoSangre.nbTipoSangre;
//                //                IndicadorTS.nbCampo2 = (Book.tpEgresado == "T") ? "Titulado" : "Pasante";
//                //                IndicadorTS.numCampo = 1;
//                //                IndicadoresTS.Add(IndicadorTS);
//                //            }
//                //        }
//                //    }
//                //    else if (Book.idTipoSangre != null && Book.tpEgresado == null)
//                //    {
//                //        foreach (var itemA in Alumnos)
//                //        {
//                //            var TipoSangre = db.CatTiposSangre.Find(Book.idTipoSangre);
//                //            if (itemA.tpEgresado == "T" && itemA.idTipoSangre == Book.idTipoSangre)
//                //            {
//                //                IndicadoresVM IndicadorTS = new IndicadoresVM();
//                //                IndicadorTS.nbCampo = TipoSangre.nbTipoSangre;
//                //                IndicadorTS.nbCampo2 = "Titulado";
//                //                IndicadorTS.numCampo = 1;
//                //                IndicadoresTS.Add(IndicadorTS);
//                //            }
//                //            else if (itemA.tpEgresado == "P" && itemA.idTipoSangre == Book.idTipoSangre)
//                //            {
//                //                IndicadoresVM IndicadorTSN = new IndicadoresVM();
//                //                IndicadorTSN.nbCampo = TipoSangre.nbTipoSangre;
//                //                IndicadorTSN.nbCampo2 = "Pasante";
//                //                IndicadorTSN.numCampo = 1;
//                //                IndicadoresTS.Add(IndicadorTSN);
//                //            }
//                //        }
//                //    }
//                //    else if (Book.idTipoSangre == null && Book.tpEgresado == null)
//                //    {
//                //        foreach (var itemS in CatTiposSangre)
//                //        {
//                //            foreach (var itemA in Alumnos)
//                //            {
//                //                var TipoSangre = db.CatTiposSangre.Find(itemS.idTipoSangre);
//                //                if (itemA.tpEgresado == "T" && itemA.idTipoSangre == Book.idTipoSangre)
//                //                {
//                //                    IndicadoresVM IndicadorTS = new IndicadoresVM();
//                //                    IndicadorTS.nbCampo = TipoSangre.nbTipoSangre;
//                //                    IndicadorTS.nbCampo2 = "Titulado";
//                //                    IndicadorTS.numCampo = 1;
//                //                    IndicadoresTS.Add(IndicadorTS);
//                //                }
//                //                else if (itemA.tpEgresado == "P" && itemA.idTipoSangre == Book.idTipoSangre)
//                //                {
//                //                    IndicadoresVM IndicadorTSN = new IndicadoresVM();
//                //                    IndicadorTSN.nbCampo = TipoSangre.nbTipoSangre;
//                //                    IndicadorTSN.nbCampo2 = "Pasante";
//                //                    IndicadorTSN.numCampo = 1;
//                //                    IndicadoresTS.Add(IndicadorTSN);
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (Book.idEstadoCivil == null && Book.tpEgresado != null)
//                //    {
//                //        foreach (var itemS in CatTiposSangre)
//                //        {
//                //            foreach (var itemA in Alumnos)
//                //            {
//                //                var TipoSangre = db.CatTiposSangre.Find(itemS.idTipoSangre);
//                //                if (itemA.tpEgresado == Book.tpEgresado && itemA.idTipoSangre == Book.idTipoSangre)
//                //                {
//                //                    IndicadoresVM IndicadorTS = new IndicadoresVM();
//                //                    IndicadorTS.nbCampo = TipoSangre.nbTipoSangre;
//                //                    IndicadorTS.nbCampo2 = (Book.tpEgresado == "T") ? "Titulado" : "Pasante";
//                //                    IndicadorTS.numCampo = 1;
//                //                    IndicadoresTS.Add(IndicadorTS);
//                //                }
//                //            }

//                //        }
//                //    }

//                //    IndicadoresTS.ToList().ForEach(l =>
//                //    {
//                //        var row = dt.NewRow();
//                //        row["nbCategoria"] = l.nbCampo;
//                //        row["nbCategoria2"] = l.nbCampo2;
//                //        row["numDatos"] = l.numCampo;
//                //        dt.Rows.Add(row);
//                //    });

//                //    #endregion
//                //}
//                //else if (listacaCampos[0] == 11 && listacaCampos[1] == 14)
//                //{
//                //    #region

//                //    TituloColumna1 = "Tipo de Sangre";
//                //    TituloColumna2 = "Fallecimiento";
//                //    TituloColumna3 = "Cantidad";
//                //    TituloGrafic = "Gráfica de barras por Tipo de Sangre y Fallecimiento";
//                //    var CatTiposSangre = db.CatTiposSangre.ToList();
//                //    List<IndicadoresVM> IndicadoresTS = new List<IndicadoresVM>();
//                //    if (Book.idTipoSangre != null && Book.fgFallecido != null)
//                //    {
//                //        foreach (var itemA in Alumnos)
//                //        {
//                //            var TipoSangre = db.CatTiposSangre.Find(Book.idTipoSangre);
//                //            if (itemA.fgFallecido == Book.fgFallecido && itemA.idTipoSangre == TipoSangre.idTipoSangre)
//                //            {
//                //                IndicadoresVM IndicadorTS = new IndicadoresVM();
//                //                IndicadorTS.nbCampo = TipoSangre.nbTipoSangre;
//                //                IndicadorTS.nbCampo2 = (Book.fgFallecido == true) ? "SI" : "NO";
//                //                IndicadorTS.numCampo = 1;
//                //                IndicadoresTS.Add(IndicadorTS);
//                //            }
//                //        }
//                //    }
//                //    else if (Book.idTipoSangre != null && Book.fgFallecido == null)
//                //    {
//                //        foreach (var itemA in Alumnos)
//                //        {
//                //            var TipoSangre = db.CatTiposSangre.Find(Book.idTipoSangre);
//                //            if (itemA.fgFallecido == true && itemA.idTipoSangre == TipoSangre.idTipoSangre)
//                //            {
//                //                IndicadoresVM IndicadorTS = new IndicadoresVM();
//                //                IndicadorTS.nbCampo = TipoSangre.nbTipoSangre;
//                //                IndicadorTS.nbCampo2 = "SI";
//                //                IndicadorTS.numCampo = 1;
//                //                IndicadoresTS.Add(IndicadorTS);
//                //            }
//                //            else if (itemA.fgFallecido == false && itemA.idTipoSangre == TipoSangre.idTipoSangre)
//                //            {
//                //                IndicadoresVM IndicadorTSN = new IndicadoresVM();
//                //                IndicadorTSN.nbCampo = TipoSangre.nbTipoSangre;
//                //                IndicadorTSN.nbCampo2 = "NO";
//                //                IndicadorTSN.numCampo = 1;
//                //                IndicadoresTS.Add(IndicadorTSN);
//                //            }
//                //        }
//                //    }
//                //    else if (Book.idTipoSangre == null && Book.fgFallecido == null)
//                //    {
//                //        foreach (var itemS in CatTiposSangre)
//                //        {
//                //            foreach (var itemA in Alumnos)
//                //            {
//                //                var TipoSangre = db.CatTiposSangre.Find(itemS.idTipoSangre);
//                //                if (itemA.fgFallecido == true && itemA.idTipoSangre == TipoSangre.idTipoSangre)
//                //                {
//                //                    IndicadoresVM IndicadorTS = new IndicadoresVM();
//                //                    IndicadorTS.nbCampo = TipoSangre.nbTipoSangre;
//                //                    IndicadorTS.nbCampo2 = "SI";
//                //                    IndicadorTS.numCampo = 1;
//                //                    IndicadoresTS.Add(IndicadorTS);
//                //                }
//                //                else if (itemA.fgFallecido == false && itemA.idTipoSangre == TipoSangre.idTipoSangre)
//                //                {
//                //                    IndicadoresVM IndicadorTSN = new IndicadoresVM();
//                //                    IndicadorTSN.nbCampo = TipoSangre.nbTipoSangre;
//                //                    IndicadorTSN.nbCampo2 = "NO";
//                //                    IndicadorTSN.numCampo = 1;
//                //                    IndicadoresTS.Add(IndicadorTSN);
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (Book.idEstadoCivil == null && Book.fgFallecido != null)
//                //    {
//                //        foreach (var itemS in CatTiposSangre)
//                //        {
//                //            foreach (var itemA in Alumnos)
//                //            {
//                //                var TipoSangre = db.CatTiposSangre.Find(itemS.idTipoSangre);
//                //                if (itemA.fgFallecido == Book.fgFallecido && itemA.idTipoSangre == TipoSangre.idTipoSangre)
//                //                {
//                //                    IndicadoresVM IndicadorTS = new IndicadoresVM();
//                //                    IndicadorTS.nbCampo = TipoSangre.nbTipoSangre;
//                //                    IndicadorTS.nbCampo2 = (Book.fgFallecido == true) ? "SI" : "NO";
//                //                    IndicadorTS.numCampo = 1;
//                //                    IndicadoresTS.Add(IndicadorTS);
//                //                }
//                //            }
//                //        }
//                //    }

//                //    IndicadoresTS.ToList().ForEach(l =>
//                //    {
//                //        var row = dt.NewRow();
//                //        row["nbCategoria"] = l.nbCampo;
//                //        row["nbCategoria2"] = l.nbCampo2;
//                //        row["numDatos"] = l.numCampo;
//                //        dt.Rows.Add(row);
//                //    });

//                //    #endregion
//                //}
//                //else if (listacaCampos[0] == 12 && listacaCampos[1] == 2)
//                //{
//                //    #region

//                //    TituloColumna1 = "Licencia";
//                //    TituloColumna2 = "Estado Civil";
//                //    TituloColumna3 = "Cantidad";
//                //    TituloGrafic = "Gráfica de barras por Licencia y Estado Civil";
//                //    var CatEstadosCiviles = db.CatEstadosCiviles.ToList();
//                //    List<IndicadoresVM> IndicadoresEdoCLicencia = new List<IndicadoresVM>();

//                //    if (Book.idEstadoCivil != null && Book.fgLicencia != null)
//                //    {
//                //        foreach (var item in Alumnos)
//                //        {
//                //            var EstadoCivil = db.CatEstadosCiviles.Find(Book.idEstadoCivil);
//                //            if (item.fgLicencia == Book.fgLicencia && item.idEstadoCivil == EstadoCivil.idEstadoCivil)
//                //            {
//                //                IndicadoresVM IndicadorECL = new IndicadoresVM();
//                //                IndicadorECL.nbCampo = (Book.fgLicencia == true) ? "SI" : "NO";
//                //                IndicadorECL.nbCampo2 = EstadoCivil.nbEstadoCivil;
//                //                IndicadorECL.numCampo = 1;
//                //                IndicadoresEdoCLicencia.Add(IndicadorECL);
//                //            }
//                //        }
//                //    }
//                //    else if (Book.idEstadoCivil != null && Book.fgLicencia == null)
//                //    {
//                //        foreach (var item in Alumnos)
//                //        {
//                //            var EstadoCivil = db.CatEstadosCiviles.Find(Book.idEstadoCivil);
//                //            if (item.fgLicencia == true && item.idEstadoCivil == EstadoCivil.idEstadoCivil)
//                //            {
//                //                IndicadoresVM IndicadorECL = new IndicadoresVM();
//                //                IndicadorECL.nbCampo = "SI";
//                //                IndicadorECL.nbCampo2 = EstadoCivil.nbEstadoCivil;
//                //                IndicadorECL.numCampo = 1;
//                //                IndicadoresEdoCLicencia.Add(IndicadorECL);
//                //            }
//                //            else if (item.fgLicencia == false && item.idEstadoCivil == EstadoCivil.idEstadoCivil)
//                //            {
//                //                IndicadoresVM IndicadorECLN = new IndicadoresVM();
//                //                IndicadorECLN.nbCampo = "NO";
//                //                IndicadorECLN.nbCampo2 = EstadoCivil.nbEstadoCivil;
//                //                IndicadorECLN.numCampo = 1;
//                //                IndicadoresEdoCLicencia.Add(IndicadorECLN);
//                //            }
//                //        }
//                //    }
//                //    else if (Book.idEstadoCivil == null && Book.fgLicencia == null)
//                //    {
//                //        foreach (var itemEC in CatEstadosCiviles)
//                //        {
//                //            foreach (var item in Alumnos)
//                //            {
//                //                var EstadoCivil = db.CatEstadosCiviles.Find(itemEC.idEstadoCivil);
//                //                if (item.fgLicencia == true && item.idEstadoCivil == EstadoCivil.idEstadoCivil)
//                //                {
//                //                    IndicadoresVM IndicadorECL = new IndicadoresVM();
//                //                    IndicadorECL.nbCampo = "SI";
//                //                    IndicadorECL.nbCampo2 = EstadoCivil.nbEstadoCivil;
//                //                    IndicadorECL.numCampo = 1;
//                //                    IndicadoresEdoCLicencia.Add(IndicadorECL);
//                //                }
//                //                else if (item.fgLicencia == false && item.idEstadoCivil == EstadoCivil.idEstadoCivil)
//                //                {
//                //                    IndicadoresVM IndicadorECLN = new IndicadoresVM();
//                //                    IndicadorECLN.nbCampo = "NO";
//                //                    IndicadorECLN.nbCampo2 = EstadoCivil.nbEstadoCivil;
//                //                    IndicadorECLN.numCampo = 1;
//                //                    IndicadoresEdoCLicencia.Add(IndicadorECLN);
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (Book.idEstadoCivil == null && Book.fgLicencia != null)
//                //    {
//                //        foreach (var itemEC in CatEstadosCiviles)
//                //        {
//                //            foreach (var item in Alumnos)
//                //            {
//                //                var EstadoCivil = db.CatEstadosCiviles.Find(itemEC.idEstadoCivil);
//                //                if (item.fgLicencia == Book.fgLicencia && item.idEstadoCivil == EstadoCivil.idEstadoCivil)
//                //                {
//                //                    IndicadoresVM IndicadorECL = new IndicadoresVM();
//                //                    IndicadorECL.nbCampo = (Book.fgLicencia == true) ? "SI" : "NO";
//                //                    IndicadorECL.nbCampo2 = EstadoCivil.nbEstadoCivil;
//                //                    IndicadorECL.numCampo = 1;
//                //                    IndicadoresEdoCLicencia.Add(IndicadorECL);
//                //                }
//                //            }

//                //        }
//                //    }

//                //    IndicadoresEdoCLicencia.ToList().ForEach(l =>
//                //    {
//                //        var row = dt.NewRow();
//                //        row["nbCategoria"] = l.nbCampo;
//                //        row["nbCategoria2"] = l.nbCampo2;
//                //        row["numDatos"] = l.numCampo;
//                //        dt.Rows.Add(row);
//                //    });

//                //    #endregion
//                //}
//                //else if (listacaCampos[0] == 12 && listacaCampos[1] == 3)
//                //{
//                //    #region

//                //    TituloColumna1 = "Licencia";
//                //    TituloColumna2 = "Edad";
//                //    TituloColumna3 = "Cantidad";
//                //    TituloGrafic = "Gráfica de barras por Licencia y Edad";
//                //    List<IndicadoresVM> ListaEdadLicencia = new List<IndicadoresVM>();

//                //    if (Book.numEdadMinima != null && Book.numEdadMinima != null && Book.fgLicencia != null)
//                //    {
//                //        for (var i = Book.numEdadMinima; i <= Book.numEdadMaxima; i++)
//                //        {
//                //            foreach (var item in Alumnos)
//                //            {
//                //                var edad = DateTime.Now.Year - ((DateTime)item.feNacimiento).Date.Year;
//                //                if (edad == i && item.fgLicencia == Book.fgLicencia)
//                //                {
//                //                    IndicadoresVM IndicadorEdadL = new IndicadoresVM();
//                //                    IndicadorEdadL.nbCampo = (Book.fgLicencia == true) ? "SI" : "NO";
//                //                    IndicadorEdadL.nbCampo2 = i + " Años";
//                //                    IndicadorEdadL.numCampo = 1;
//                //                    ListaEdadLicencia.Add(IndicadorEdadL);
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (Book.numEdadMinima != null && Book.numEdadMinima != null && Book.fgLicencia == null)
//                //    {
//                //        for (var i = Book.numEdadMinima; i <= Book.numEdadMaxima; i++)
//                //        {
//                //            foreach (var item in Alumnos)
//                //            {
//                //                var edad = DateTime.Now.Year - ((DateTime)item.feNacimiento).Date.Year;
//                //                if (edad == i && item.fgLicencia == true)
//                //                {
//                //                    IndicadoresVM IndicadorEdadL = new IndicadoresVM();
//                //                    IndicadorEdadL.nbCampo = "SI";
//                //                    IndicadorEdadL.nbCampo2 = i + " Años";
//                //                    IndicadorEdadL.numCampo = 1;
//                //                    ListaEdadLicencia.Add(IndicadorEdadL);
//                //                }
//                //                else if (edad == i && item.fgLicencia == false)
//                //                {
//                //                    IndicadoresVM IndicadorEdadL = new IndicadoresVM();
//                //                    IndicadorEdadL.nbCampo = "NO";
//                //                    IndicadorEdadL.nbCampo2 = i + " Años";
//                //                    IndicadorEdadL.numCampo = 1;
//                //                    ListaEdadLicencia.Add(IndicadorEdadL);
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (Book.numEdadMinima == null && Book.numEdadMinima == null && Book.fgLicencia != null)
//                //    {
//                //        for (var i = 15; i <= 80; i++)
//                //        {
//                //            foreach (var item in Alumnos)
//                //            {
//                //                var edad = DateTime.Now.Year - ((DateTime)item.feNacimiento).Date.Year;
//                //                if (edad == i && item.fgLicencia == Book.fgLicencia)
//                //                {
//                //                    IndicadoresVM IndicadorEdadL = new IndicadoresVM();
//                //                    IndicadorEdadL.nbCampo = (Book.fgLicencia == true) ? "SI" : "NO";
//                //                    IndicadorEdadL.nbCampo2 = i + " Años";
//                //                    IndicadorEdadL.numCampo = 1;
//                //                    ListaEdadLicencia.Add(IndicadorEdadL);
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (Book.numEdadMinima == null && Book.numEdadMinima == null && Book.fgLicencia == null)
//                //    {
//                //        for (var i = 15; i <= 80; i++)
//                //        {
//                //            foreach (var item in Alumnos)
//                //            {
//                //                var edad = DateTime.Now.Year - ((DateTime)item.feNacimiento).Date.Year;
//                //                if (edad == i && item.fgLicencia == true)
//                //                {
//                //                    IndicadoresVM IndicadorEdadL = new IndicadoresVM();
//                //                    IndicadorEdadL.nbCampo = "SI";
//                //                    IndicadorEdadL.nbCampo2 = i + " Años";
//                //                    IndicadorEdadL.numCampo = 1;
//                //                    ListaEdadLicencia.Add(IndicadorEdadL);
//                //                }
//                //                else if (edad == i && item.fgLicencia == false)
//                //                {
//                //                    IndicadoresVM IndicadorEdadL = new IndicadoresVM();
//                //                    IndicadorEdadL.nbCampo = "NO";
//                //                    IndicadorEdadL.nbCampo2 = i + " Años";
//                //                    IndicadorEdadL.numCampo = 1;
//                //                    ListaEdadLicencia.Add(IndicadorEdadL);
//                //                }
//                //            }
//                //        }
//                //    }

//                //    ListaEdadLicencia.ToList().ForEach(t =>
//                //    {
//                //        var row = dt.NewRow();
//                //        row["nbCategoria"] = t.nbCampo;
//                //        row["nbCategoria2"] = t.nbCampo2;
//                //        row["numDatos"] = t.numCampo;
//                //        dt.Rows.Add(row);
//                //    });

//                //    #endregion
//                //}
//                //else if (listacaCampos[0] == 12 && listacaCampos[1] == 6)
//                //{
//                //    #region

//                //    TituloColumna1 = "Licencia";
//                //    TituloColumna2 = "Género";
//                //    TituloColumna3 = "Cantidad";
//                //    TituloGrafic = "Gráfica de barras por Licencia y Género";

//                //    var CatGeneros = db.CatGeneros.ToList();
//                //    List<IndicadoresVM> IndicadoresGLicencia = new List<IndicadoresVM>();

//                //    if (Book.idGenero != null && Book.fgLicencia != null)
//                //    {
//                //        foreach (var itemA in Alumnos)
//                //        {
//                //            var Genero = db.CatGeneros.Find(Book.idGenero);
//                //            if (itemA.Personas.idGenero == Genero.idGenero && itemA.fgLicencia == Book.fgLicencia)
//                //            {
//                //                IndicadoresVM IndicadorGL = new IndicadoresVM();
//                //                IndicadorGL.nbCampo = (Book.fgLicencia == true) ? "SI" : "NO";
//                //                IndicadorGL.nbCampo2 = Genero.nbGenero.Trim();
//                //                IndicadorGL.numCampo = 1;
//                //                IndicadoresGLicencia.Add(IndicadorGL);
//                //            }
//                //        }
//                //    }
//                //    else if (Book.idGenero == null && Book.fgLicencia != null)
//                //    {
//                //        foreach (var itemG in CatGeneros)
//                //        {
//                //            foreach (var itemA in Alumnos)
//                //            {
//                //                var Genero = db.CatGeneros.Find(itemG.idGenero);
//                //                if (itemA.Personas.idGenero == Genero.idGenero && itemA.fgLicencia == Book.fgLicencia)
//                //                {
//                //                    IndicadoresVM IndicadorGL = new IndicadoresVM();
//                //                    IndicadorGL.nbCampo = (Book.fgLicencia == true) ? "SI" : "NO";
//                //                    IndicadorGL.nbCampo2 = Genero.nbGenero.Trim();
//                //                    IndicadorGL.numCampo = 1;
//                //                    IndicadoresGLicencia.Add(IndicadorGL);
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (Book.idGenero == null && Book.fgLicencia == null)
//                //    {
//                //        foreach (var itemG in CatGeneros)
//                //        {
//                //            foreach (var itemA in Alumnos)
//                //            {
//                //                var Genero = db.CatGeneros.Find(itemG.idGenero);
//                //                if (itemA.Personas.idGenero == Genero.idGenero && itemA.fgLicencia == true)
//                //                {
//                //                    IndicadoresVM IndicadorGL = new IndicadoresVM();
//                //                    IndicadorGL.nbCampo = "SI";
//                //                    IndicadorGL.nbCampo2 = Genero.nbGenero.Trim();
//                //                    IndicadorGL.numCampo = 1;
//                //                    IndicadoresGLicencia.Add(IndicadorGL);
//                //                }
//                //                else if (itemA.Personas.idGenero == Genero.idGenero && itemA.fgLicencia == false)
//                //                {
//                //                    IndicadoresVM IndicadorGLN = new IndicadoresVM();
//                //                    IndicadorGLN.nbCampo = "NO";
//                //                    IndicadorGLN.nbCampo2 = Genero.nbGenero.Trim();
//                //                    IndicadorGLN.numCampo = 1;
//                //                    IndicadoresGLicencia.Add(IndicadorGLN);
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (Book.idGenero != null && Book.fgLicencia == null)
//                //    {
//                //        foreach (var itemA in Alumnos)
//                //        {
//                //            var Genero = db.CatGeneros.Find(Book.idGenero);
//                //            if (itemA.Personas.idGenero == Genero.idGenero && itemA.fgLicencia == true)
//                //            {
//                //                IndicadoresVM IndicadorGL = new IndicadoresVM();
//                //                IndicadorGL.nbCampo = "SI";
//                //                IndicadorGL.nbCampo2 = Genero.nbGenero.Trim();
//                //                IndicadorGL.numCampo = 1;
//                //                IndicadoresGLicencia.Add(IndicadorGL);
//                //            }
//                //            else if (itemA.Personas.idGenero == Genero.idGenero && itemA.fgLicencia == false)
//                //            {
//                //                IndicadoresVM IndicadorGLN = new IndicadoresVM();
//                //                IndicadorGLN.nbCampo = "NO";
//                //                IndicadorGLN.nbCampo2 = Genero.nbGenero.Trim();
//                //                IndicadorGLN.numCampo = 1;
//                //                IndicadoresGLicencia.Add(IndicadorGLN);
//                //            }
//                //        }
//                //    }

//                //    IndicadoresGLicencia.ToList().ForEach(l =>
//                //    {
//                //        var row = dt.NewRow();
//                //        row["nbCategoria"] = l.nbCampo;
//                //        row["nbCategoria2"] = l.nbCampo2;
//                //        row["numDatos"] = l.numCampo;
//                //        dt.Rows.Add(row);
//                //    });

//                //    #endregion
//                //}
//                //else if (listacaCampos[0] == 12 && listacaCampos[1] == 7)
//                //{
//                //    #region

//                //    TituloColumna1 = "Licencia";
//                //    TituloColumna2 = "Licenciatura";
//                //    TituloColumna3 = "Cantidad";
//                //    TituloGrafic = "Gráfica de barras por Licencia y Licenciatura";
//                //    Licenciaturas Licenciatura = new Licenciaturas();
//                //    var Licenciaturas = db.Licenciaturas.ToList();

//                //    List<IndicadoresVM> IndicadoresLicLicencia = new List<IndicadoresVM>();

//                //    if (listaIdsLicenciaturas.Count() > 0 && Book.fgLicencia != null)
//                //    {
//                //        foreach (var itemL in listaIdsLicenciaturas)
//                //        {
//                //            foreach (var item in Alumnos)
//                //            {
//                //                var idLicenciatura = Convert.ToInt64(itemL);
//                //                Licenciatura = Licenciaturas.FirstOrDefault(x => x.idLicenciatura == idLicenciatura);
//                //                var FormacionesA = db.FormacionesAcademicas.Where(x => x.idAlumno == item.idAlumno && x.idLicenciatura == Licenciatura.idLicenciatura).ToList();
//                //                if (item.fgLicencia == Book.fgLicencia && FormacionesA.Count() > 0)
//                //                {
//                //                    IndicadoresVM IndicadorLT = new IndicadoresVM();
//                //                    IndicadorLT.nbCampo = (Book.fgLicencia == true) ? "SI" : "NO";
//                //                    IndicadorLT.nbCampo2 = Licenciatura.nbLicenciatura;
//                //                    IndicadorLT.numCampo = 1;
//                //                    IndicadoresLicLicencia.Add(IndicadorLT);
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (listaIdsLicenciaturas.Count() > 0 && Book.fgLicencia == null)
//                //    {
//                //        foreach (var itemL in listaIdsLicenciaturas)
//                //        {
//                //            foreach (var item in Alumnos)
//                //            {
//                //                var idLicenciatura = Convert.ToInt64(itemL);
//                //                Licenciatura = Licenciaturas.FirstOrDefault(x => x.idLicenciatura == idLicenciatura);
//                //                var FormacionesA = db.FormacionesAcademicas.Where(x => x.idAlumno == item.idAlumno && x.idLicenciatura == Licenciatura.idLicenciatura).ToList();
//                //                if (item.fgLicencia == true && FormacionesA.Count() > 0)
//                //                {
//                //                    IndicadoresVM IndicadorLL = new IndicadoresVM();
//                //                    IndicadorLL.nbCampo = "SI";
//                //                    IndicadorLL.nbCampo2 = Licenciatura.nbLicenciatura;
//                //                    IndicadorLL.numCampo = 1;
//                //                    IndicadoresLicLicencia.Add(IndicadorLL);
//                //                }
//                //                else if (item.fgLicencia == false && FormacionesA.Count() > 0)
//                //                {
//                //                    IndicadoresVM IndicadorLNL = new IndicadoresVM();
//                //                    IndicadorLNL.nbCampo = "NO";
//                //                    IndicadorLNL.nbCampo2 = Licenciatura.nbLicenciatura;
//                //                    IndicadorLNL.numCampo = 1;
//                //                    IndicadoresLicLicencia.Add(IndicadorLNL);
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (listaIdsLicenciaturas.Count() == 0 && Book.fgLicencia != null)
//                //    {
//                //        foreach (var itemL in Licenciaturas)
//                //        {
//                //            foreach (var item in Alumnos)
//                //            {
//                //                //var idLicenciatura = Convert.ToInt64(itemL);
//                //                Licenciatura = Licenciaturas.FirstOrDefault(x => x.idLicenciatura == itemL.idLicenciatura);
//                //                var FormacionesA = db.FormacionesAcademicas.Where(x => x.idAlumno == item.idAlumno && x.idLicenciatura == Licenciatura.idLicenciatura).ToList();
//                //                if (item.fgLicencia == Book.fgLicencia && FormacionesA.Count() > 0)
//                //                {
//                //                    IndicadoresVM IndicadorLT = new IndicadoresVM();
//                //                    IndicadorLT.nbCampo = (Book.fgLicencia == true) ? "SI" : "NO";
//                //                    IndicadorLT.nbCampo2 = Licenciatura.nbLicenciatura;
//                //                    IndicadorLT.numCampo = 1;
//                //                    IndicadoresLicLicencia.Add(IndicadorLT);
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (listaIdsLicenciaturas.Count() == 0 && Book.fgLicencia == null)
//                //    {
//                //        foreach (var itemL in Licenciaturas)
//                //        {
//                //            foreach (var item in Alumnos)
//                //            {
//                //                //var idLicenciatura = Convert.ToInt64(itemL);
//                //                Licenciatura = Licenciaturas.FirstOrDefault(x => x.idLicenciatura == itemL.idLicenciatura);
//                //                var FormacionesA = db.FormacionesAcademicas.Where(x => x.idAlumno == item.idAlumno && x.idLicenciatura == Licenciatura.idLicenciatura).ToList();
//                //                if (item.fgLicencia == true && FormacionesA.Count() > 0)
//                //                {
//                //                    IndicadoresVM IndicadorLL = new IndicadoresVM();
//                //                    IndicadorLL.nbCampo = "SI";
//                //                    IndicadorLL.nbCampo2 = Licenciatura.nbLicenciatura;
//                //                    IndicadorLL.numCampo = 1;
//                //                    IndicadoresLicLicencia.Add(IndicadorLL);
//                //                }
//                //                else if (item.fgLicencia == false && FormacionesA.Count() > 0)
//                //                {
//                //                    IndicadoresVM IndicadorLNL = new IndicadoresVM();
//                //                    IndicadorLNL.nbCampo = "NO";
//                //                    IndicadorLNL.nbCampo2 = Licenciatura.nbLicenciatura;
//                //                    IndicadorLNL.numCampo = 1;
//                //                    IndicadoresLicLicencia.Add(IndicadorLNL);
//                //                }
//                //            }
//                //        }
//                //    }

//                //    IndicadoresLicLicencia.ToList().ForEach(l =>
//                //    {
//                //        var row = dt.NewRow();
//                //        row["nbCategoria"] = l.nbCampo;
//                //        row["nbCategoria2"] = l.nbCampo2;
//                //        row["numDatos"] = l.numCampo;
//                //        dt.Rows.Add(row);
//                //    });

//                //    #endregion
//                //}
//                //else if (listacaCampos[0] == 12 && listacaCampos[1] == 8)
//                //{
//                //    #region

//                //    TituloColumna1 = "Licencia";
//                //    TituloColumna2 = "Religión";
//                //    TituloColumna3 = "Cantidad";
//                //    TituloGrafic = "Gráfica de barras por Licencia y Religión";

//                //    CatReligion Religion = new CatReligion();
//                //    var Religiones = db.CatReligion.ToList();

//                //    List<IndicadoresVM> IndicadoresRelLicencia = new List<IndicadoresVM>();

//                //    if (listaIdsReligiones.Count() > 0 && Book.fgLicencia != null)
//                //    {
//                //        foreach (var itemR in listaIdsReligiones)
//                //        {
//                //            foreach (var itemA in Alumnos)
//                //            {
//                //                var idReligion = Convert.ToInt64(itemR);
//                //                Religion = Religiones.FirstOrDefault(x => x.idReligion == idReligion);
//                //                if (itemA.fgLicencia == Book.fgLicencia && itemA.idReligion == Religion.idReligion)
//                //                {
//                //                    IndicadoresVM IndicadorRL = new IndicadoresVM();
//                //                    IndicadorRL.nbCampo = (Book.fgLicencia == true) ? "SI" : "NO";
//                //                    IndicadorRL.nbCampo2 = Religion.nbReligion;
//                //                    IndicadorRL.numCampo = 1;
//                //                    IndicadoresRelLicencia.Add(IndicadorRL);
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (listaIdsReligiones.Count() > 0 && Book.fgLicencia == null)
//                //    {
//                //        foreach (var itemR in listaIdsReligiones)
//                //        {
//                //            foreach (var itemA in Alumnos)
//                //            {
//                //                var idReligion = Convert.ToInt64(itemR);
//                //                Religion = Religiones.FirstOrDefault(x => x.idReligion == idReligion);
//                //                if (itemA.fgLicencia == true && itemA.idReligion == Religion.idReligion)
//                //                {
//                //                    IndicadoresVM IndicadorRL = new IndicadoresVM();
//                //                    IndicadorRL.nbCampo = "SI";
//                //                    IndicadorRL.nbCampo2 = Religion.nbReligion;
//                //                    IndicadorRL.numCampo = 1;
//                //                    IndicadoresRelLicencia.Add(IndicadorRL);
//                //                }
//                //                else if (itemA.fgLicencia == false && itemA.idReligion == Religion.idReligion)
//                //                {
//                //                    IndicadoresVM IndicadorRNL = new IndicadoresVM();
//                //                    IndicadorRNL.nbCampo = "NO";
//                //                    IndicadorRNL.nbCampo2 = Religion.nbReligion;
//                //                    IndicadorRNL.numCampo = 1;
//                //                    IndicadoresRelLicencia.Add(IndicadorRNL);
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (listaIdsReligiones.Count() == 0 && Book.fgLicencia != null)
//                //    {
//                //        foreach (var itemR in Religiones)
//                //        {
//                //            foreach (var itemA in Alumnos)
//                //            {
//                //                //var idReligion = Convert.ToInt64(itemR);
//                //                Religion = Religiones.FirstOrDefault(x => x.idReligion == itemR.idReligion);
//                //                if (itemA.fgLicencia == Book.fgLicencia && itemA.idReligion == Religion.idReligion)
//                //                {
//                //                    IndicadoresVM IndicadorRL = new IndicadoresVM();
//                //                    IndicadorRL.nbCampo = (Book.fgLicencia == true) ? "SI" : "NO";
//                //                    IndicadorRL.nbCampo2 = Religion.nbReligion;
//                //                    IndicadorRL.numCampo = 1;
//                //                    IndicadoresRelLicencia.Add(IndicadorRL);
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (listaIdsReligiones.Count() == 0 && Book.fgLicencia == null)
//                //    {
//                //        foreach (var itemR in Religiones)
//                //        {
//                //            foreach (var itemA in Alumnos)
//                //            {
//                //                //var idReligion = Convert.ToInt64(itemR);
//                //                Religion = Religiones.FirstOrDefault(x => x.idReligion == itemR.idReligion);
//                //                if (itemA.fgLicencia == true && itemA.idReligion == Religion.idReligion)
//                //                {
//                //                    IndicadoresVM IndicadorRL = new IndicadoresVM();
//                //                    IndicadorRL.nbCampo = "SI";
//                //                    IndicadorRL.nbCampo2 = Religion.nbReligion;
//                //                    IndicadorRL.numCampo = 1;
//                //                    IndicadoresRelLicencia.Add(IndicadorRL);
//                //                }
//                //                else if (itemA.fgLicencia == false && itemA.idReligion == Religion.idReligion)
//                //                {
//                //                    IndicadoresVM IndicadorRNL = new IndicadoresVM();
//                //                    IndicadorRNL.nbCampo = "NO";
//                //                    IndicadorRNL.nbCampo2 = Religion.nbReligion;
//                //                    IndicadorRNL.numCampo = 1;
//                //                    IndicadoresRelLicencia.Add(IndicadorRNL);
//                //                }
//                //            }
//                //        }
//                //    }

//                //    IndicadoresRelLicencia.ToList().ForEach(l =>
//                //    {
//                //        var row = dt.NewRow();
//                //        row["nbCategoria"] = l.nbCampo;
//                //        row["nbCategoria2"] = l.nbCampo2;
//                //        row["numDatos"] = l.numCampo;
//                //        dt.Rows.Add(row);
//                //    });

//                //    #endregion
//                //}
//                //else if (listacaCampos[0] == 12 && listacaCampos[1] == 9)
//                //{
//                //    #region

//                //    TituloColumna1 = "Licencia";
//                //    TituloColumna2 = "Estado";
//                //    TituloColumna3 = "Cantidad";
//                //    TituloGrafic = "Gráfica de barras por Licencia y Estado";

//                //    CatEstados Estado = new CatEstados();
//                //    var Estados = db.CatEstados.ToList();

//                //    List<IndicadoresVM> IndicadoresEdosLic = new List<IndicadoresVM>();

//                //    if (listaIdsestados.Count() > 0 && Book.fgLicencia != null)
//                //    {
//                //        foreach (var itemE in listaIdsestados)
//                //        {
//                //            foreach (var itemA in Alumnos)
//                //            {
//                //                var idEstado = Convert.ToInt64(itemE);
//                //                Estado = Estados.FirstOrDefault(x => x.idEstado == idEstado);
//                //                if (itemA.fgLicencia == Book.fgLicencia && itemA.Direcciones.nbEstado.Trim().ToUpper() == Estado.nbEstado.Trim().ToUpper())
//                //                {
//                //                    IndicadoresVM IndicadorRT = new IndicadoresVM();
//                //                    IndicadorRT.nbCampo = (Book.fgLicencia == true) ? "SI" : "NO";
//                //                    IndicadorRT.nbCampo2 = Estado.nbEstado;
//                //                    IndicadorRT.numCampo = 1;
//                //                    IndicadoresEdosLic.Add(IndicadorRT);
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (listaIdsestados.Count() > 0 && Book.fgLicencia == null)
//                //    {
//                //        foreach (var itemE in listaIdsestados)
//                //        {
//                //            foreach (var itemA in Alumnos)
//                //            {
//                //                var idEstado = Convert.ToInt64(itemE);
//                //                Estado = Estados.FirstOrDefault(x => x.idEstado == idEstado);
//                //                if (itemA.fgLicencia == true && itemA.Direcciones.nbEstado.Trim().ToUpper() == Estado.nbEstado.Trim().ToUpper())
//                //                {
//                //                    IndicadoresVM IndicadorRT = new IndicadoresVM();
//                //                    IndicadorRT.nbCampo = "SI";
//                //                    IndicadorRT.nbCampo2 = Estado.nbEstado;
//                //                    IndicadorRT.numCampo = 1;
//                //                    IndicadoresEdosLic.Add(IndicadorRT);
//                //                }
//                //                else if (itemA.fgLicencia == false && itemA.Direcciones.nbEstado.Trim().ToUpper() == Estado.nbEstado.Trim().ToUpper())
//                //                {
//                //                    IndicadoresVM IndicadorRNT = new IndicadoresVM();
//                //                    IndicadorRNT.nbCampo = "NO";
//                //                    IndicadorRNT.nbCampo2 = Estado.nbEstado;
//                //                    IndicadorRNT.numCampo = 1;
//                //                    IndicadoresEdosLic.Add(IndicadorRNT);
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (listaIdsestados.Count() == 0 && Book.fgLicencia != null)
//                //    {
//                //        foreach (var itemE in Estados)
//                //        {
//                //            foreach (var itemA in Alumnos)
//                //            {
//                //                //var idEstado = Convert.ToInt64(itemE);
//                //                Estado = Estados.FirstOrDefault(x => x.idEstado == itemE.idEstado);
//                //                if (itemA.fgLicencia == Book.fgLicencia && itemA.Direcciones.nbEstado.Trim().ToUpper() == Estado.nbEstado.Trim().ToUpper())
//                //                {
//                //                    IndicadoresVM IndicadorRT = new IndicadoresVM();
//                //                    IndicadorRT.nbCampo = (Book.fgLicencia == true) ? "SI" : "NO";
//                //                    IndicadorRT.nbCampo2 = Estado.nbEstado;
//                //                    IndicadorRT.numCampo = 1;
//                //                    IndicadoresEdosLic.Add(IndicadorRT);
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (listaIdsestados.Count() == 0 && Book.fgLicencia == null)
//                //    {
//                //        foreach (var itemE in Estados)
//                //        {
//                //            foreach (var itemA in Alumnos)
//                //            {
//                //                //var idEstado = Convert.ToInt64(itemE);
//                //                Estado = Estados.FirstOrDefault(x => x.idEstado == itemE.idEstado);
//                //                if (itemA.fgLicencia == true && itemA.Direcciones.nbEstado.Trim().ToUpper() == Estado.nbEstado.Trim().ToUpper())
//                //                {
//                //                    IndicadoresVM IndicadorRT = new IndicadoresVM();
//                //                    IndicadorRT.nbCampo = "SI";
//                //                    IndicadorRT.nbCampo2 = Estado.nbEstado;
//                //                    IndicadorRT.numCampo = 1;
//                //                    IndicadoresEdosLic.Add(IndicadorRT);
//                //                }
//                //                else if (itemA.fgLicencia == false && itemA.Direcciones.nbEstado.Trim().ToUpper() == Estado.nbEstado.Trim().ToUpper())
//                //                {
//                //                    IndicadoresVM IndicadorRNT = new IndicadoresVM();
//                //                    IndicadorRNT.nbCampo = "NO";
//                //                    IndicadorRNT.nbCampo2 = Estado.nbEstado;
//                //                    IndicadorRNT.numCampo = 1;
//                //                    IndicadoresEdosLic.Add(IndicadorRNT);
//                //                }
//                //            }
//                //        }
//                //    }

//                //    IndicadoresEdosLic.ToList().ForEach(l =>
//                //    {
//                //        var row = dt.NewRow();
//                //        row["nbCategoria"] = l.nbCampo;
//                //        row["nbCategoria2"] = l.nbCampo2;
//                //        row["numDatos"] = l.numCampo;
//                //        dt.Rows.Add(row);
//                //    });

//                //    #endregion
//                //}
//                //else if (listacaCampos[0] == 12 && listacaCampos[1] == 10)
//                //{
//                //    #region

//                //    TituloColumna1 = "Licencia";
//                //    TituloColumna2 = "Trabajo";
//                //    TituloColumna3 = "Cantidad";
//                //    TituloGrafic = "Gráfica de barras por Licencia y Trabajo";
//                //    List<IndicadoresVM> IndicadoresTL = new List<IndicadoresVM>();
//                //    if (Book.fgLicencia != null && Book.fgTrabajaActualmente != null)
//                //    {
//                //        foreach (var itemA in Alumnos)
//                //        {
//                //            if (itemA.fgTrabajaActualmente == Book.fgTrabajaActualmente && itemA.fgLicencia == Book.fgLicencia)
//                //            {
//                //                IndicadoresVM IndicadorTL = new IndicadoresVM();
//                //                IndicadorTL.nbCampo = (Book.fgLicencia == true) ? "SI" : "NO";
//                //                IndicadorTL.nbCampo2 = (Book.fgTrabajaActualmente == true) ? "SI" : "NO";
//                //                IndicadorTL.numCampo = 1;
//                //                IndicadoresTL.Add(IndicadorTL);
//                //            }
//                //        }
//                //    }
//                //    else if (Book.fgLicencia != null && Book.fgTrabajaActualmente == null)
//                //    {
//                //        foreach (var itemA in Alumnos)
//                //        {
//                //            if (itemA.fgTrabajaActualmente == true && itemA.fgLicencia == Book.fgLicencia)
//                //            {
//                //                IndicadoresVM IndicadorTL = new IndicadoresVM();
//                //                IndicadorTL.nbCampo = (Book.fgLicencia == true) ? "SI" : "NO";
//                //                IndicadorTL.nbCampo2 = "SI";
//                //                IndicadorTL.numCampo = 1;
//                //                IndicadoresTL.Add(IndicadorTL);
//                //            }
//                //            else if (itemA.fgTrabajaActualmente == false && itemA.fgLicencia == Book.fgLicencia)
//                //            {
//                //                IndicadoresVM IndicadorTLN = new IndicadoresVM();
//                //                IndicadorTLN.nbCampo = (Book.fgLicencia == true) ? "SI" : "NO";
//                //                IndicadorTLN.nbCampo2 = "NO";
//                //                IndicadorTLN.numCampo = 1;
//                //                IndicadoresTL.Add(IndicadorTLN);
//                //            }
//                //        }
//                //    }
//                //    else if (Book.fgLicencia == null && Book.fgTrabajaActualmente == null)
//                //    {
//                //        foreach (var itemA in Alumnos)
//                //        {
//                //            if (itemA.fgTrabajaActualmente == true && itemA.fgLicencia == true)
//                //            {
//                //                IndicadoresVM IndicadorTL = new IndicadoresVM();
//                //                IndicadorTL.nbCampo = "SI";
//                //                IndicadorTL.nbCampo2 = "SI";
//                //                IndicadorTL.numCampo = 1;
//                //                IndicadoresTL.Add(IndicadorTL);
//                //            }
//                //            else if (itemA.fgTrabajaActualmente == false && itemA.fgLicencia == true)
//                //            {
//                //                IndicadoresVM IndicadorNTL = new IndicadoresVM();
//                //                IndicadorNTL.nbCampo = "SI";
//                //                IndicadorNTL.nbCampo2 = "NO";
//                //                IndicadorNTL.numCampo = 1;
//                //                IndicadoresTL.Add(IndicadorNTL);
//                //            }
//                //            else if (itemA.fgTrabajaActualmente == true && itemA.fgLicencia == false)
//                //            {
//                //                IndicadoresVM IndicadorTNL = new IndicadoresVM();
//                //                IndicadorTNL.nbCampo = "NO";
//                //                IndicadorTNL.nbCampo2 = "SI";
//                //                IndicadorTNL.numCampo = 1;
//                //                IndicadoresTL.Add(IndicadorTNL);
//                //            }
//                //            else if (itemA.fgTrabajaActualmente == false && itemA.fgLicencia == false)
//                //            {
//                //                IndicadoresVM IndicadorNTNL = new IndicadoresVM();
//                //                IndicadorNTNL.nbCampo = "NO";
//                //                IndicadorNTNL.nbCampo2 = "NO";
//                //                IndicadorNTNL.numCampo = 1;
//                //                IndicadoresTL.Add(IndicadorNTNL);
//                //            }
//                //        }
//                //    }
//                //    else if (Book.fgLicencia == null && Book.fgTrabajaActualmente != null)
//                //    {
//                //        foreach (var itemA in Alumnos)
//                //        {
//                //            if (itemA.fgTrabajaActualmente == Book.fgTrabajaActualmente && itemA.fgLicencia == true)
//                //            {
//                //                IndicadoresVM IndicadorTL = new IndicadoresVM();
//                //                IndicadorTL.nbCampo = (Book.fgLicencia == true) ? "SI" : "NO";
//                //                IndicadorTL.nbCampo2 = "SI";
//                //                IndicadorTL.numCampo = 1;
//                //                IndicadoresTL.Add(IndicadorTL);
//                //            }
//                //            else if (itemA.fgTrabajaActualmente == Book.fgTrabajaActualmente && itemA.fgLicencia == false)
//                //            {
//                //                IndicadoresVM IndicadorTLN = new IndicadoresVM();
//                //                IndicadorTLN.nbCampo = (Book.fgLicencia == true) ? "SI" : "NO";
//                //                IndicadorTLN.nbCampo2 = "NO";
//                //                IndicadorTLN.numCampo = 1;
//                //                IndicadoresTL.Add(IndicadorTLN);
//                //            }
//                //        }
//                //    }

//                //    IndicadoresTL.ToList().ForEach(l =>
//                //    {
//                //        var row = dt.NewRow();
//                //        row["nbCategoria"] = l.nbCampo;
//                //        row["nbCategoria2"] = l.nbCampo2;
//                //        row["numDatos"] = l.numCampo;
//                //        dt.Rows.Add(row);
//                //    });

//                //    #endregion
//                //}
//                //else if (listacaCampos[0] == 12 && listacaCampos[1] == 11)
//                //{
//                //    #region

//                //    TituloColumna1 = "Licencia";
//                //    TituloColumna2 = "Tipo de Sangre";
//                //    TituloColumna3 = "Cantidad";
//                //    TituloGrafic = "Gráfica de barras por Licenciay Tipo de Sangre";
//                //    var CatTiposSangre = db.CatTiposSangre.ToList();
//                //    List<IndicadoresVM> IndicadoresTS = new List<IndicadoresVM>();
//                //    if (Book.idTipoSangre != null && Book.fgLicencia != null)
//                //    {
//                //        foreach (var itemA in Alumnos)
//                //        {
//                //            var TipoSangre = db.CatTiposSangre.Find(Book.idTipoSangre);
//                //            if (itemA.fgLicencia == Book.fgLicencia && itemA.idTipoSangre == TipoSangre.idTipoSangre)
//                //            {
//                //                IndicadoresVM IndicadorTS = new IndicadoresVM();
//                //                IndicadorTS.nbCampo = (Book.fgLicencia == true) ? "SI" : "NO";
//                //                IndicadorTS.nbCampo2 = TipoSangre.nbTipoSangre;
//                //                IndicadorTS.numCampo = 1;
//                //                IndicadoresTS.Add(IndicadorTS);
//                //            }
//                //        }
//                //    }
//                //    else if (Book.idTipoSangre != null && Book.fgLicencia == null)
//                //    {
//                //        foreach (var itemA in Alumnos)
//                //        {
//                //            var TipoSangre = db.CatTiposSangre.Find(Book.idTipoSangre);
//                //            if (itemA.fgLicencia == true && itemA.idTipoSangre == TipoSangre.idTipoSangre)
//                //            {
//                //                IndicadoresVM IndicadorTS = new IndicadoresVM();
//                //                IndicadorTS.nbCampo = "SI";
//                //                IndicadorTS.nbCampo2 = TipoSangre.nbTipoSangre;
//                //                IndicadorTS.numCampo = 1;
//                //                IndicadoresTS.Add(IndicadorTS);
//                //            }
//                //            else if (itemA.fgLicencia == false && itemA.idTipoSangre == TipoSangre.idTipoSangre)
//                //            {
//                //                IndicadoresVM IndicadorTSN = new IndicadoresVM();
//                //                IndicadorTSN.nbCampo = "NO";
//                //                IndicadorTSN.nbCampo2 = TipoSangre.nbTipoSangre;
//                //                IndicadorTSN.numCampo = 1;
//                //                IndicadoresTS.Add(IndicadorTSN);
//                //            }
//                //        }
//                //    }
//                //    else if (Book.idTipoSangre == null && Book.fgLicencia == null)
//                //    {
//                //        foreach (var itemS in CatTiposSangre)
//                //        {
//                //            foreach (var itemA in Alumnos)
//                //            {
//                //                var TipoSangre = db.CatTiposSangre.Find(itemS.idTipoSangre);
//                //                if (itemA.fgLicencia == true && itemA.idTipoSangre == TipoSangre.idTipoSangre)
//                //                {
//                //                    IndicadoresVM IndicadorTS = new IndicadoresVM();
//                //                    IndicadorTS.nbCampo = "SI";
//                //                    IndicadorTS.nbCampo2 = TipoSangre.nbTipoSangre;
//                //                    IndicadorTS.numCampo = 1;
//                //                    IndicadoresTS.Add(IndicadorTS);
//                //                }
//                //                else if (itemA.fgFallecido == false && itemA.idTipoSangre == TipoSangre.idTipoSangre)
//                //                {
//                //                    IndicadoresVM IndicadorTSN = new IndicadoresVM();
//                //                    IndicadorTSN.nbCampo = "NO";
//                //                    IndicadorTSN.nbCampo2 = TipoSangre.nbTipoSangre;
//                //                    IndicadorTSN.numCampo = 1;
//                //                    IndicadoresTS.Add(IndicadorTSN);
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (Book.idEstadoCivil == null && Book.fgLicencia != null)
//                //    {
//                //        foreach (var itemS in CatTiposSangre)
//                //        {
//                //            foreach (var itemA in Alumnos)
//                //            {
//                //                var TipoSangre = db.CatTiposSangre.Find(itemS.idTipoSangre);
//                //                if (itemA.fgLicencia == Book.fgLicencia && itemA.idTipoSangre == TipoSangre.idTipoSangre)
//                //                {
//                //                    IndicadoresVM IndicadorTS = new IndicadoresVM();
//                //                    IndicadorTS.nbCampo = (Book.fgLicencia == true) ? "SI" : "NO";
//                //                    IndicadorTS.nbCampo2 = TipoSangre.nbTipoSangre;
//                //                    IndicadorTS.numCampo = 1;
//                //                    IndicadoresTS.Add(IndicadorTS);
//                //                }
//                //            }

//                //        }
//                //    }

//                //    IndicadoresTS.ToList().ForEach(l =>
//                //    {
//                //        var row = dt.NewRow();
//                //        row["nbCategoria"] = l.nbCampo;
//                //        row["nbCategoria2"] = l.nbCampo2;
//                //        row["numDatos"] = l.numCampo;
//                //        dt.Rows.Add(row);
//                //    });

//                //    #endregion
//                //}
//                //else if (listacaCampos[0] == 12 && listacaCampos[1] == 13)
//                //{
//                //    #region

//                //    TituloColumna1 = "Licencia";
//                //    TituloColumna2 = "Tipo de Egresado";
//                //    TituloColumna3 = "Cantidad";
//                //    TituloGrafic = "Gráfica de barras por Licencia y Tipo de Egresado";
//                //    List<IndicadoresVM> IndicadoresTL = new List<IndicadoresVM>();
//                //    if (Book.tpEgresado != null && Book.fgLicencia != null)
//                //    {
//                //        foreach (var itemA in Alumnos)
//                //        {
//                //            if (itemA.fgLicencia == Book.fgLicencia && itemA.tpEgresado == Book.tpEgresado)
//                //            {
//                //                IndicadoresVM IndicadorTL = new IndicadoresVM();
//                //                IndicadorTL.nbCampo = (Book.fgLicencia == true) ? "SI" : "NO";
//                //                IndicadorTL.nbCampo2 = (Book.tpEgresado == "T") ? "Titulado" : "Pasante";
//                //                IndicadorTL.numCampo = 1;
//                //                IndicadoresTL.Add(IndicadorTL);
//                //            }
//                //        }
//                //    }
//                //    else if (Book.tpEgresado != null && Book.fgLicencia == null)
//                //    {
//                //        foreach (var itemA in Alumnos)
//                //        {
//                //            if (itemA.fgLicencia == true && itemA.tpEgresado == Book.tpEgresado)
//                //            {
//                //                IndicadoresVM IndicadorTL = new IndicadoresVM();
//                //                IndicadorTL.nbCampo = "SI";
//                //                IndicadorTL.nbCampo2 = (Book.tpEgresado == "T") ? "Titulado" : "Pasante";
//                //                IndicadorTL.numCampo = 1;
//                //                IndicadoresTL.Add(IndicadorTL);
//                //            }
//                //            else if (itemA.fgLicencia == false && itemA.tpEgresado == Book.tpEgresado)
//                //            {
//                //                IndicadoresVM IndicadorTLN = new IndicadoresVM();
//                //                IndicadorTLN.nbCampo = "NO";
//                //                IndicadorTLN.nbCampo2 = (Book.tpEgresado == "T") ? "Titulado" : "Pasante";
//                //                IndicadorTLN.numCampo = 1;
//                //                IndicadoresTL.Add(IndicadorTLN);
//                //            }
//                //        }
//                //    }
//                //    else if (Book.tpEgresado == null && Book.fgLicencia == null)
//                //    {
//                //        foreach (var itemA in Alumnos)
//                //        {
//                //            if (itemA.fgLicencia == true && itemA.tpEgresado == "T")
//                //            {
//                //                IndicadoresVM IndicadorTL = new IndicadoresVM();
//                //                IndicadorTL.nbCampo = "SI";
//                //                IndicadorTL.nbCampo2 = "Titulado";
//                //                IndicadorTL.numCampo = 1;
//                //                IndicadoresTL.Add(IndicadorTL);
//                //            }
//                //            else if (itemA.fgLicencia == false && itemA.tpEgresado == "T")
//                //            {
//                //                IndicadoresVM IndicadorNTL = new IndicadoresVM();
//                //                IndicadorNTL.nbCampo = "NO";
//                //                IndicadorNTL.nbCampo2 = "Titulado";
//                //                IndicadorNTL.numCampo = 1;
//                //                IndicadoresTL.Add(IndicadorNTL);
//                //            }
//                //            else if (itemA.fgLicencia == true && itemA.tpEgresado == "P")
//                //            {
//                //                IndicadoresVM IndicadorTNL = new IndicadoresVM();
//                //                IndicadorTNL.nbCampo = "SI";
//                //                IndicadorTNL.nbCampo2 = "Pasante";
//                //                IndicadorTNL.numCampo = 1;
//                //                IndicadoresTL.Add(IndicadorTNL);
//                //            }
//                //            else if (itemA.fgLicencia == false && itemA.tpEgresado == "P")
//                //            {
//                //                IndicadoresVM IndicadorNTNL = new IndicadoresVM();
//                //                IndicadorNTNL.nbCampo = "NO";
//                //                IndicadorNTNL.nbCampo2 = "Pasante";
//                //                IndicadorNTNL.numCampo = 1;
//                //                IndicadoresTL.Add(IndicadorNTNL);
//                //            }
//                //        }
//                //    }
//                //    else if (Book.tpEgresado == null && Book.fgLicencia != null)
//                //    {
//                //        foreach (var itemA in Alumnos)
//                //        {
//                //            if (itemA.fgLicencia == Book.fgLicencia && itemA.tpEgresado == "T")
//                //            {
//                //                IndicadoresVM IndicadorTNL = new IndicadoresVM();
//                //                IndicadorTNL.nbCampo = (Book.fgLicencia == true) ? "SI" : "NO";
//                //                IndicadorTNL.nbCampo2 = "Titulado";
//                //                IndicadorTNL.numCampo = 1;
//                //                IndicadoresTL.Add(IndicadorTNL);
//                //            }
//                //            else if (itemA.fgLicencia == Book.fgLicencia && itemA.tpEgresado == "P")
//                //            {
//                //                IndicadoresVM IndicadorNTNL = new IndicadoresVM();
//                //                IndicadorNTNL.nbCampo = (Book.fgLicencia == true) ? "SI" : "NO";
//                //                IndicadorNTNL.nbCampo2 = "Pasante";
//                //                IndicadorNTNL.numCampo = 1;
//                //                IndicadoresTL.Add(IndicadorNTNL);
//                //            }
//                //        }
//                //    }

//                //    IndicadoresTL.ToList().ForEach(l =>
//                //    {
//                //        var row = dt.NewRow();
//                //        row["nbCategoria"] = l.nbCampo;
//                //        row["nbCategoria2"] = l.nbCampo2;
//                //        row["numDatos"] = l.numCampo;
//                //        dt.Rows.Add(row);
//                //    });

//                //    #endregion
//                //}
//                //else if (listacaCampos[0] == 12 && listacaCampos[1] == 14)
//                //{
//                //    #region

//                //    TituloColumna1 = "Licencia";
//                //    TituloColumna2 = "Fallecimiento";
//                //    TituloColumna3 = "Cantidad";
//                //    TituloGrafic = "Gráfica de barras por Licencia y Fallecimiento";
//                //    List<IndicadoresVM> IndicadoresTL = new List<IndicadoresVM>();
//                //    if (Book.fgLicencia != null && Book.fgFallecido != null)
//                //    {
//                //        foreach (var itemA in Alumnos)
//                //        {
//                //            if (itemA.fgFallecido == Book.fgFallecido && itemA.fgLicencia == Book.fgLicencia)
//                //            {
//                //                IndicadoresVM IndicadorTL = new IndicadoresVM();
//                //                IndicadorTL.nbCampo = (Book.fgLicencia == true) ? "SI" : "NO";
//                //                IndicadorTL.nbCampo2 = (Book.fgFallecido == true) ? "SI" : "NO";
//                //                IndicadorTL.numCampo = 1;
//                //                IndicadoresTL.Add(IndicadorTL);
//                //            }
//                //        }
//                //    }
//                //    else if (Book.fgLicencia != null && Book.fgFallecido == null)
//                //    {
//                //        foreach (var itemA in Alumnos)
//                //        {
//                //            if (itemA.fgFallecido == true && itemA.fgLicencia == Book.fgLicencia)
//                //            {
//                //                IndicadoresVM IndicadorTL = new IndicadoresVM();
//                //                IndicadorTL.nbCampo = "SI";
//                //                IndicadorTL.nbCampo2 = (Book.fgFallecido == true) ? "SI" : "NO";
//                //                IndicadorTL.numCampo = 1;
//                //                IndicadoresTL.Add(IndicadorTL);
//                //            }
//                //            else if (itemA.fgFallecido == false && itemA.fgLicencia == Book.fgLicencia)
//                //            {
//                //                IndicadoresVM IndicadorTLN = new IndicadoresVM();
//                //                IndicadorTLN.nbCampo = "NO";
//                //                IndicadorTLN.nbCampo2 = (Book.fgFallecido == true) ? "SI" : "NO";
//                //                IndicadorTLN.numCampo = 1;
//                //                IndicadoresTL.Add(IndicadorTLN);
//                //            }
//                //        }
//                //    }
//                //    else if (Book.fgLicencia == null && Book.fgFallecido == null)
//                //    {
//                //        foreach (var itemA in Alumnos)
//                //        {
//                //            if (itemA.fgFallecido == true && itemA.fgLicencia == true)
//                //            {
//                //                IndicadoresVM IndicadorTL = new IndicadoresVM();
//                //                IndicadorTL.nbCampo = "SI";
//                //                IndicadorTL.nbCampo2 = "SI";
//                //                IndicadorTL.numCampo = 1;
//                //                IndicadoresTL.Add(IndicadorTL);
//                //            }
//                //            else if (itemA.fgFallecido == false && itemA.fgLicencia == true)
//                //            {
//                //                IndicadoresVM IndicadorNTL = new IndicadoresVM();
//                //                IndicadorNTL.nbCampo = "SI";
//                //                IndicadorNTL.nbCampo2 = "NO";
//                //                IndicadorNTL.numCampo = 1;
//                //                IndicadoresTL.Add(IndicadorNTL);
//                //            }
//                //            else if (itemA.fgFallecido == true && itemA.fgLicencia == false)
//                //            {
//                //                IndicadoresVM IndicadorTNL = new IndicadoresVM();
//                //                IndicadorTNL.nbCampo = "NO";
//                //                IndicadorTNL.nbCampo2 = "SI";
//                //                IndicadorTNL.numCampo = 1;
//                //                IndicadoresTL.Add(IndicadorTNL);
//                //            }
//                //            else if (itemA.fgFallecido == false && itemA.fgLicencia == false)
//                //            {
//                //                IndicadoresVM IndicadorNTNL = new IndicadoresVM();
//                //                IndicadorNTNL.nbCampo = "NO";
//                //                IndicadorNTNL.nbCampo2 = "NO";
//                //                IndicadorNTNL.numCampo = 1;
//                //                IndicadoresTL.Add(IndicadorNTNL);
//                //            }
//                //        }
//                //    }
//                //    else if (Book.fgLicencia == null && Book.fgFallecido != null)
//                //    {
//                //        foreach (var itemA in Alumnos)
//                //        {
//                //            if (itemA.fgFallecido == Book.fgFallecido && itemA.fgLicencia == true)
//                //            {
//                //                IndicadoresVM IndicadorTNL = new IndicadoresVM();
//                //                IndicadorTNL.nbCampo = "SI";
//                //                IndicadorTNL.nbCampo2 = (Book.fgFallecido == true) ? "SI" : "NO";
//                //                IndicadorTNL.numCampo = 1;
//                //                IndicadoresTL.Add(IndicadorTNL);
//                //            }
//                //            else if (itemA.fgFallecido == Book.fgFallecido && itemA.fgLicencia == false)
//                //            {
//                //                IndicadoresVM IndicadorNTNL = new IndicadoresVM();
//                //                IndicadorNTNL.nbCampo = "NO";
//                //                IndicadorNTNL.nbCampo2 = (Book.fgFallecido == true) ? "SI" : "NO";
//                //                IndicadorNTNL.numCampo = 1;
//                //                IndicadoresTL.Add(IndicadorNTNL);
//                //            }
//                //        }
//                //    }

//                //    IndicadoresTL.ToList().ForEach(l =>
//                //    {
//                //        var row = dt.NewRow();
//                //        row["nbCategoria"] = l.nbCampo;
//                //        row["nbCategoria2"] = l.nbCampo2;
//                //        row["numDatos"] = l.numCampo;
//                //        dt.Rows.Add(row);
//                //    });

//                //    #endregion
//                //}
//                //else if (listacaCampos[0] == 13 && listacaCampos[1] == 2)
//                //{
//                //    #region

//                //    TituloColumna1 = "Tipo de Egresado";
//                //    TituloColumna2 = "Estado Civil";
//                //    TituloColumna3 = "Cantidad";
//                //    TituloGrafic = "Gráfica de barras por Tipo de Egresado y Estado Civil";
//                //    var CatEstadosCiviles = db.CatEstadosCiviles.ToList();
//                //    List<IndicadoresVM> IndicadoresEdoCtpEgresado = new List<IndicadoresVM>();

//                //    if (Book.idEstadoCivil != null && Book.tpEgresado != null)
//                //    {
//                //        foreach (var item in Alumnos)
//                //        {
//                //            var EstadoCivil = db.CatEstadosCiviles.Find(Book.idEstadoCivil);
//                //            if (item.tpEgresado == Book.tpEgresado && item.idEstadoCivil == EstadoCivil.idEstadoCivil)
//                //            {
//                //                IndicadoresVM IndicadorECL = new IndicadoresVM();
//                //                IndicadorECL.nbCampo = (Book.tpEgresado == "P") ? "Pasante" : "Titulado";
//                //                IndicadorECL.nbCampo2 = EstadoCivil.nbEstadoCivil;
//                //                IndicadorECL.numCampo = 1;
//                //                IndicadoresEdoCtpEgresado.Add(IndicadorECL);
//                //            }
//                //        }
//                //    }
//                //    else if (Book.idEstadoCivil != null && Book.tpEgresado == null)
//                //    {
//                //        foreach (var item in Alumnos)
//                //        {
//                //            var EstadoCivil = db.CatEstadosCiviles.Find(Book.idEstadoCivil);
//                //            if (item.tpEgresado == "T" && item.idEstadoCivil == EstadoCivil.idEstadoCivil)
//                //            {
//                //                IndicadoresVM IndicadorECL = new IndicadoresVM();
//                //                IndicadorECL.nbCampo = "Titulado";
//                //                IndicadorECL.nbCampo2 = EstadoCivil.nbEstadoCivil;
//                //                IndicadorECL.numCampo = 1;
//                //                IndicadoresEdoCtpEgresado.Add(IndicadorECL);
//                //            }
//                //            else if (item.tpEgresado == "P" && item.idEstadoCivil == EstadoCivil.idEstadoCivil)
//                //            {
//                //                IndicadoresVM IndicadorECLN = new IndicadoresVM();
//                //                IndicadorECLN.nbCampo = "Pasante";
//                //                IndicadorECLN.nbCampo2 = EstadoCivil.nbEstadoCivil;
//                //                IndicadorECLN.numCampo = 1;
//                //                IndicadoresEdoCtpEgresado.Add(IndicadorECLN);
//                //            }
//                //        }
//                //    }
//                //    else if (Book.idEstadoCivil == null && Book.tpEgresado == null)
//                //    {
//                //        foreach (var itemEC in CatEstadosCiviles)
//                //        {
//                //            foreach (var item in Alumnos)
//                //            {
//                //                var EstadoCivil = db.CatEstadosCiviles.Find(itemEC.idEstadoCivil);
//                //                if (item.tpEgresado == "T" && item.idEstadoCivil == EstadoCivil.idEstadoCivil)
//                //                {
//                //                    IndicadoresVM IndicadorECL = new IndicadoresVM();
//                //                    IndicadorECL.nbCampo = "Titulado";
//                //                    IndicadorECL.nbCampo2 = EstadoCivil.nbEstadoCivil;
//                //                    IndicadorECL.numCampo = 1;
//                //                    IndicadoresEdoCtpEgresado.Add(IndicadorECL);
//                //                }
//                //                else if (item.tpEgresado == "P" && item.idEstadoCivil == EstadoCivil.idEstadoCivil)
//                //                {
//                //                    IndicadoresVM IndicadorECLN = new IndicadoresVM();
//                //                    IndicadorECLN.nbCampo = "Pasante";
//                //                    IndicadorECLN.nbCampo2 = EstadoCivil.nbEstadoCivil;
//                //                    IndicadorECLN.numCampo = 1;
//                //                    IndicadoresEdoCtpEgresado.Add(IndicadorECLN);
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (Book.idEstadoCivil == null && Book.tpEgresado != null)
//                //    {
//                //        foreach (var itemEC in CatEstadosCiviles)
//                //        {
//                //            foreach (var item in Alumnos)
//                //            {
//                //                var EstadoCivil = db.CatEstadosCiviles.Find(itemEC.idEstadoCivil);
//                //                if (item.tpEgresado == Book.tpEgresado && item.idEstadoCivil == EstadoCivil.idEstadoCivil)
//                //                {
//                //                    IndicadoresVM IndicadorECL = new IndicadoresVM();
//                //                    IndicadorECL.nbCampo = (Book.tpEgresado == "P") ? "Pasante" : "Titulado";
//                //                    IndicadorECL.nbCampo2 = EstadoCivil.nbEstadoCivil;
//                //                    IndicadorECL.numCampo = 1;
//                //                    IndicadoresEdoCtpEgresado.Add(IndicadorECL);
//                //                }
//                //            }
//                //        }
//                //    }

//                //    IndicadoresEdoCtpEgresado.ToList().ForEach(l =>
//                //    {
//                //        var row = dt.NewRow();
//                //        row["nbCategoria"] = l.nbCampo;
//                //        row["nbCategoria2"] = l.nbCampo2;
//                //        row["numDatos"] = l.numCampo;
//                //        dt.Rows.Add(row);
//                //    });

//                //    #endregion
//                //}
//                //else if (listacaCampos[0] == 13 && listacaCampos[1] == 3)
//                //{
//                //    #region

//                //    TituloColumna1 = "Tipo de Egresado";
//                //    TituloColumna2 = "Edad";
//                //    TituloColumna3 = "Cantidad";
//                //    TituloGrafic = "Gráfica de barras por Tipo de Egresado y Edad";
//                //    List<IndicadoresVM> ListaEdadtpEgresado = new List<IndicadoresVM>();

//                //    if (Book.numEdadMinima != null && Book.numEdadMinima != null && Book.tpEgresado != null)
//                //    {
//                //        for (var i = Book.numEdadMinima; i <= Book.numEdadMaxima; i++)
//                //        {
//                //            foreach (var item in Alumnos)
//                //            {
//                //                var edad = DateTime.Now.Year - ((DateTime)item.feNacimiento).Date.Year;
//                //                if (edad == i && item.tpEgresado == Book.tpEgresado)
//                //                {
//                //                    IndicadoresVM IndicadorEdadL = new IndicadoresVM();
//                //                    IndicadorEdadL.nbCampo = (Book.tpEgresado == "T") ? "Titulado" : "Pasante";
//                //                    IndicadorEdadL.nbCampo2 = i + " Años";
//                //                    IndicadorEdadL.numCampo = 1;
//                //                    ListaEdadtpEgresado.Add(IndicadorEdadL);
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (Book.numEdadMinima != null && Book.numEdadMinima != null && Book.tpEgresado == null)
//                //    {
//                //        for (var i = Book.numEdadMinima; i <= Book.numEdadMaxima; i++)
//                //        {
//                //            foreach (var item in Alumnos)
//                //            {
//                //                var edad = DateTime.Now.Year - ((DateTime)item.feNacimiento).Date.Year;
//                //                if (edad == i && item.tpEgresado == "T")
//                //                {
//                //                    IndicadoresVM IndicadorEdadL = new IndicadoresVM();
//                //                    IndicadorEdadL.nbCampo = "Titulado";
//                //                    IndicadorEdadL.nbCampo2 = i + " Años";
//                //                    IndicadorEdadL.numCampo = 1;
//                //                    ListaEdadtpEgresado.Add(IndicadorEdadL);
//                //                }
//                //                else if (edad == i && item.tpEgresado == "P")
//                //                {
//                //                    IndicadoresVM IndicadorEdadL = new IndicadoresVM();
//                //                    IndicadorEdadL.nbCampo = "Pasante";
//                //                    IndicadorEdadL.nbCampo2 = i + " Años";
//                //                    IndicadorEdadL.numCampo = 1;
//                //                    ListaEdadtpEgresado.Add(IndicadorEdadL);
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (Book.numEdadMinima == null && Book.numEdadMinima == null && Book.tpEgresado != null)
//                //    {
//                //        for (var i = 15; i <= 80; i++)
//                //        {
//                //            foreach (var item in Alumnos)
//                //            {
//                //                var edad = DateTime.Now.Year - ((DateTime)item.feNacimiento).Date.Year;
//                //                if (edad == i && item.tpEgresado == Book.tpEgresado)
//                //                {
//                //                    IndicadoresVM IndicadorEdadL = new IndicadoresVM();
//                //                    IndicadorEdadL.nbCampo = (Book.tpEgresado == "T") ? "Titulado" : "Pasante";
//                //                    IndicadorEdadL.nbCampo2 = i + " Años";
//                //                    IndicadorEdadL.numCampo = 1;
//                //                    ListaEdadtpEgresado.Add(IndicadorEdadL);
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (Book.numEdadMinima == null && Book.numEdadMinima == null && Book.tpEgresado == null)
//                //    {
//                //        for (var i = 15; i <= 80; i++)
//                //        {
//                //            foreach (var item in Alumnos)
//                //            {
//                //                var edad = DateTime.Now.Year - ((DateTime)item.feNacimiento).Date.Year;
//                //                if (edad == i && item.tpEgresado == "T")
//                //                {
//                //                    IndicadoresVM IndicadorEdadL = new IndicadoresVM();
//                //                    IndicadorEdadL.nbCampo = "Titulado";
//                //                    IndicadorEdadL.nbCampo2 = i + " Años";
//                //                    IndicadorEdadL.numCampo = 1;
//                //                    ListaEdadtpEgresado.Add(IndicadorEdadL);
//                //                }
//                //                else if (edad == i && item.tpEgresado == "P")
//                //                {
//                //                    IndicadoresVM IndicadorEdadL = new IndicadoresVM();
//                //                    IndicadorEdadL.nbCampo = "Pasante";
//                //                    IndicadorEdadL.nbCampo2 = i + " Años";
//                //                    IndicadorEdadL.numCampo = 1;
//                //                    ListaEdadtpEgresado.Add(IndicadorEdadL);
//                //                }
//                //            }
//                //        }
//                //    }

//                //    ListaEdadtpEgresado.ToList().ForEach(t =>
//                //    {
//                //        var row = dt.NewRow();
//                //        row["nbCategoria"] = t.nbCampo;
//                //        row["nbCategoria2"] = t.nbCampo2;
//                //        row["numDatos"] = t.numCampo;
//                //        dt.Rows.Add(row);
//                //    });

//                //    #endregion
//                //}
//                //else if (listacaCampos[0] == 13 && listacaCampos[1] == 6)
//                //{
//                //    #region

//                //    TituloColumna1 = "Tipo de Egresado";
//                //    TituloColumna2 = "Género";
//                //    TituloColumna3 = "Cantidad";
//                //    TituloGrafic = "Gráfica de barras por Tipo de Egresado y Género";

//                //    var CatGeneros = db.CatGeneros.ToList();
//                //    List<IndicadoresVM> IndicadoresGEgresado = new List<IndicadoresVM>();

//                //    if (Book.idGenero != null && Book.tpEgresado != null)
//                //    {
//                //        foreach (var itemA in Alumnos)
//                //        {
//                //            var Genero = db.CatGeneros.Find(Book.idGenero);
//                //            if (itemA.Personas.idGenero == Genero.idGenero && itemA.tpEgresado == Book.tpEgresado)
//                //            {
//                //                IndicadoresVM IndicadorGE = new IndicadoresVM();
//                //                IndicadorGE.nbCampo = (Book.tpEgresado == "T") ? "Titulado" : "Pasante";
//                //                IndicadorGE.nbCampo2 = Genero.nbGenero.Trim();
//                //                IndicadorGE.numCampo = 1;
//                //                IndicadoresGEgresado.Add(IndicadorGE);
//                //            }
//                //        }
//                //    }
//                //    else if (Book.idGenero == null && Book.tpEgresado != null)
//                //    {
//                //        foreach (var itemG in CatGeneros)
//                //        {
//                //            foreach (var itemA in Alumnos)
//                //            {
//                //                var Genero = db.CatGeneros.Find(itemG.idGenero);
//                //                if (itemA.Personas.idGenero == Genero.idGenero && itemA.tpEgresado == Book.tpEgresado)
//                //                {
//                //                    IndicadoresVM IndicadorGE = new IndicadoresVM();
//                //                    IndicadorGE.nbCampo = (Book.tpEgresado == "T") ? "Titulado" : "Pasante";
//                //                    IndicadorGE.nbCampo2 = Genero.nbGenero.Trim();
//                //                    IndicadorGE.numCampo = 1;
//                //                    IndicadoresGEgresado.Add(IndicadorGE);
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (Book.idGenero == null && Book.tpEgresado == null)
//                //    {
//                //        foreach (var itemG in CatGeneros)
//                //        {
//                //            foreach (var itemA in Alumnos)
//                //            {
//                //                var Genero = db.CatGeneros.Find(itemG.idGenero);
//                //                if (itemA.Personas.idGenero == Genero.idGenero && itemA.tpEgresado == "T")
//                //                {
//                //                    IndicadoresVM IndicadorGE = new IndicadoresVM();
//                //                    IndicadorGE.nbCampo = "Titulado";
//                //                    IndicadorGE.nbCampo2 = Genero.nbGenero.Trim();
//                //                    IndicadorGE.numCampo = 1;
//                //                    IndicadoresGEgresado.Add(IndicadorGE);
//                //                }
//                //                else if (itemA.Personas.idGenero == Genero.idGenero && itemA.tpEgresado == "P")
//                //                {
//                //                    IndicadoresVM IndicadorGEN = new IndicadoresVM();
//                //                    IndicadorGEN.nbCampo = "Pasante";
//                //                    IndicadorGEN.nbCampo2 = Genero.nbGenero.Trim();
//                //                    IndicadorGEN.numCampo = 1;
//                //                    IndicadoresGEgresado.Add(IndicadorGEN);
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (Book.idGenero != null && Book.tpEgresado == null)
//                //    {
//                //        foreach (var itemA in Alumnos)
//                //        {
//                //            var Genero = db.CatGeneros.Find(Book.idGenero);
//                //            if (itemA.Personas.idGenero == Genero.idGenero && itemA.tpEgresado == "T")
//                //            {
//                //                IndicadoresVM IndicadorGE = new IndicadoresVM();
//                //                IndicadorGE.nbCampo = "Titulado";
//                //                IndicadorGE.nbCampo2 = Genero.nbGenero.Trim();
//                //                IndicadorGE.numCampo = 1;
//                //                IndicadoresGEgresado.Add(IndicadorGE);
//                //            }
//                //            else if (itemA.Personas.idGenero == Genero.idGenero && itemA.tpEgresado == "P")
//                //            {
//                //                IndicadoresVM IndicadorGEN = new IndicadoresVM();
//                //                IndicadorGEN.nbCampo = "Pasante";
//                //                IndicadorGEN.nbCampo2 = Genero.nbGenero.Trim();
//                //                IndicadorGEN.numCampo = 1;
//                //                IndicadoresGEgresado.Add(IndicadorGEN);
//                //            }
//                //        }
//                //    }

//                //    IndicadoresGEgresado.ToList().ForEach(l =>
//                //    {
//                //        var row = dt.NewRow();
//                //        row["nbCategoria"] = l.nbCampo;
//                //        row["nbCategoria2"] = l.nbCampo2;
//                //        row["numDatos"] = l.numCampo;
//                //        dt.Rows.Add(row);
//                //    });

//                //    #endregion
//                //}
//                //else if (listacaCampos[0] == 13 && listacaCampos[1] == 7)
//                //{
//                //    #region

//                //    TituloColumna1 = "Tipo de Egresado";
//                //    TituloColumna2 = "Licenciatura";
//                //    TituloColumna3 = "Cantidad";
//                //    TituloGrafic = "Gráfica de barras por Tipo de Egresado y Licenciatura";
//                //    Licenciaturas Licenciatura = new Licenciaturas();
//                //    var Licenciaturas = db.Licenciaturas.ToList();

//                //    List<IndicadoresVM> IndicadoresLicEgresado = new List<IndicadoresVM>();

//                //    if (listaIdsLicenciaturas.Count() > 0 && Book.tpEgresado != null)
//                //    {
//                //        foreach (var itemL in listaIdsLicenciaturas)
//                //        {
//                //            foreach (var item in Alumnos)
//                //            {
//                //                var idLicenciatura = Convert.ToInt64(itemL);
//                //                Licenciatura = Licenciaturas.FirstOrDefault(x => x.idLicenciatura == idLicenciatura);
//                //                var FormacionesA = db.FormacionesAcademicas.Where(x => x.idAlumno == item.idAlumno && x.idLicenciatura == Licenciatura.idLicenciatura).ToList();
//                //                if (item.tpEgresado == Book.tpEgresado && FormacionesA.Count() > 0)
//                //                {
//                //                    IndicadoresVM IndicadorLE = new IndicadoresVM();
//                //                    IndicadorLE.nbCampo = (Book.tpEgresado == "T") ? "Titulado" : "Pasante";
//                //                    IndicadorLE.nbCampo2 = Licenciatura.nbLicenciatura;
//                //                    IndicadorLE.numCampo = 1;
//                //                    IndicadoresLicEgresado.Add(IndicadorLE);
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (listaIdsLicenciaturas.Count() > 0 && Book.tpEgresado == null)
//                //    {
//                //        foreach (var itemL in listaIdsLicenciaturas)
//                //        {
//                //            foreach (var item in Alumnos)
//                //            {
//                //                var idLicenciatura = Convert.ToInt64(itemL);
//                //                Licenciatura = Licenciaturas.FirstOrDefault(x => x.idLicenciatura == idLicenciatura);
//                //                var FormacionesA = db.FormacionesAcademicas.Where(x => x.idAlumno == item.idAlumno && x.idLicenciatura == Licenciatura.idLicenciatura).ToList();
//                //                if (item.tpEgresado == "T" && FormacionesA.Count() > 0)
//                //                {
//                //                    IndicadoresVM IndicadorLE = new IndicadoresVM();
//                //                    IndicadorLE.nbCampo = "Titulado";
//                //                    IndicadorLE.nbCampo2 = Licenciatura.nbLicenciatura;
//                //                    IndicadorLE.numCampo = 1;
//                //                    IndicadoresLicEgresado.Add(IndicadorLE);
//                //                }
//                //                else if (item.tpEgresado == "P" && FormacionesA.Count() > 0)
//                //                {
//                //                    IndicadoresVM IndicadorLNE = new IndicadoresVM();
//                //                    IndicadorLNE.nbCampo = "Pasante";
//                //                    IndicadorLNE.nbCampo2 = Licenciatura.nbLicenciatura;
//                //                    IndicadorLNE.numCampo = 1;
//                //                    IndicadoresLicEgresado.Add(IndicadorLNE);
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (listaIdsLicenciaturas.Count() == 0 && Book.tpEgresado != null)
//                //    {
//                //        foreach (var itemL in Licenciaturas)
//                //        {
//                //            foreach (var item in Alumnos)
//                //            {
//                //                //var idLicenciatura = Convert.ToInt64(itemL);
//                //                Licenciatura = Licenciaturas.FirstOrDefault(x => x.idLicenciatura == itemL.idLicenciatura);
//                //                var FormacionesA = db.FormacionesAcademicas.Where(x => x.idAlumno == item.idAlumno && x.idLicenciatura == Licenciatura.idLicenciatura).ToList();
//                //                if (item.tpEgresado == Book.tpEgresado && FormacionesA.Count() > 0)
//                //                {
//                //                    IndicadoresVM IndicadorLE = new IndicadoresVM();
//                //                    IndicadorLE.nbCampo = (Book.tpEgresado == "T") ? "Titulado" : "Pasante";
//                //                    IndicadorLE.nbCampo2 = Licenciatura.nbLicenciatura;
//                //                    IndicadorLE.numCampo = 1;
//                //                    IndicadoresLicEgresado.Add(IndicadorLE);
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (listaIdsLicenciaturas.Count() == 0 && Book.tpEgresado == null)
//                //    {
//                //        foreach (var itemL in Licenciaturas)
//                //        {
//                //            foreach (var item in Alumnos)
//                //            {
//                //                //var idLicenciatura = Convert.ToInt64(itemL);
//                //                Licenciatura = Licenciaturas.FirstOrDefault(x => x.idLicenciatura == itemL.idLicenciatura);
//                //                var FormacionesA = db.FormacionesAcademicas.Where(x => x.idAlumno == item.idAlumno && x.idLicenciatura == Licenciatura.idLicenciatura).ToList();
//                //                if (item.tpEgresado == "T" && FormacionesA.Count() > 0)
//                //                {
//                //                    IndicadoresVM IndicadorLE = new IndicadoresVM();
//                //                    IndicadorLE.nbCampo = "Titulado";
//                //                    IndicadorLE.nbCampo2 = Licenciatura.nbLicenciatura;
//                //                    IndicadorLE.numCampo = 1;
//                //                    IndicadoresLicEgresado.Add(IndicadorLE);
//                //                }
//                //                else if (item.tpEgresado == "P" && FormacionesA.Count() > 0)
//                //                {
//                //                    IndicadoresVM IndicadorLNE = new IndicadoresVM();
//                //                    IndicadorLNE.nbCampo = "Pasante";
//                //                    IndicadorLNE.nbCampo2 = Licenciatura.nbLicenciatura;
//                //                    IndicadorLNE.numCampo = 1;
//                //                    IndicadoresLicEgresado.Add(IndicadorLNE);
//                //                }
//                //            }
//                //        }
//                //    }

//                //    IndicadoresLicEgresado.ToList().ForEach(l =>
//                //    {
//                //        var row = dt.NewRow();
//                //        row["nbCategoria"] = l.nbCampo;
//                //        row["nbCategoria2"] = l.nbCampo2;
//                //        row["numDatos"] = l.numCampo;
//                //        dt.Rows.Add(row);
//                //    });

//                //    #endregion
//                //}
//                //else if (listacaCampos[0] == 13 && listacaCampos[1] == 8)
//                //{
//                //    #region

//                //    TituloColumna1 = "Tipo de Egresado";
//                //    TituloColumna2 = "Religión";
//                //    TituloColumna3 = "Cantidad";
//                //    TituloGrafic = "Gráfica de barras por Tipo de Egresado y Religión";

//                //    CatReligion Religion = new CatReligion();
//                //    var Religiones = db.CatReligion.ToList();

//                //    List<IndicadoresVM> IndicadoresRelEgresados = new List<IndicadoresVM>();

//                //    if (listaIdsReligiones.Count() > 0 && Book.tpEgresado != null)
//                //    {
//                //        foreach (var itemR in listaIdsReligiones)
//                //        {
//                //            foreach (var itemA in Alumnos)
//                //            {
//                //                var idReligion = Convert.ToInt64(itemR);
//                //                Religion = Religiones.FirstOrDefault(x => x.idReligion == idReligion);
//                //                if (itemA.tpEgresado == Book.tpEgresado && itemA.idReligion == Religion.idReligion)
//                //                {
//                //                    IndicadoresVM IndicadorRE = new IndicadoresVM();
//                //                    IndicadorRE.nbCampo = (Book.tpEgresado == "T") ? "Titulado" : "Pasante";
//                //                    IndicadorRE.nbCampo2 = Religion.nbReligion;
//                //                    IndicadorRE.numCampo = 1;
//                //                    IndicadoresRelEgresados.Add(IndicadorRE);
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (listaIdsReligiones.Count() > 0 && Book.tpEgresado == null)
//                //    {
//                //        foreach (var itemR in listaIdsReligiones)
//                //        {
//                //            foreach (var itemA in Alumnos)
//                //            {
//                //                var idReligion = Convert.ToInt64(itemR);
//                //                Religion = Religiones.FirstOrDefault(x => x.idReligion == idReligion);
//                //                if (itemA.tpEgresado == "T" && itemA.idReligion == Religion.idReligion)
//                //                {
//                //                    IndicadoresVM IndicadorRE = new IndicadoresVM();
//                //                    IndicadorRE.nbCampo = "Titulado";
//                //                    IndicadorRE.nbCampo2 = Religion.nbReligion;
//                //                    IndicadorRE.numCampo = 1;
//                //                    IndicadoresRelEgresados.Add(IndicadorRE);
//                //                }
//                //                else if (itemA.tpEgresado == "P" && itemA.idReligion == Religion.idReligion)
//                //                {
//                //                    IndicadoresVM IndicadorRNE = new IndicadoresVM();
//                //                    IndicadorRNE.nbCampo = "Pasante";
//                //                    IndicadorRNE.nbCampo2 = Religion.nbReligion;
//                //                    IndicadorRNE.numCampo = 1;
//                //                    IndicadoresRelEgresados.Add(IndicadorRNE);
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (listaIdsReligiones.Count() == 0 && Book.tpEgresado != null)
//                //    {
//                //        foreach (var itemR in Religiones)
//                //        {
//                //            foreach (var itemA in Alumnos)
//                //            {
//                //                //var idReligion = Convert.ToInt64(itemR);
//                //                Religion = Religiones.FirstOrDefault(x => x.idReligion == itemR.idReligion);
//                //                if (itemA.tpEgresado == Book.tpEgresado && itemA.idReligion == Religion.idReligion)
//                //                {
//                //                    IndicadoresVM IndicadorRE = new IndicadoresVM();
//                //                    IndicadorRE.nbCampo = (Book.tpEgresado == "T") ? "Titulado" : "Pasante";
//                //                    IndicadorRE.nbCampo2 = Religion.nbReligion;
//                //                    IndicadorRE.numCampo = 1;
//                //                    IndicadoresRelEgresados.Add(IndicadorRE);
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (listaIdsReligiones.Count() == 0 && Book.tpEgresado == null)
//                //    {
//                //        foreach (var itemR in Religiones)
//                //        {
//                //            foreach (var itemA in Alumnos)
//                //            {
//                //                //var idReligion = Convert.ToInt64(itemR);
//                //                Religion = Religiones.FirstOrDefault(x => x.idReligion == itemR.idReligion);
//                //                if (itemA.tpEgresado == "T" && itemA.idReligion == Religion.idReligion)
//                //                {
//                //                    IndicadoresVM IndicadorRE = new IndicadoresVM();
//                //                    IndicadorRE.nbCampo = "Titulado";
//                //                    IndicadorRE.nbCampo2 = Religion.nbReligion;
//                //                    IndicadorRE.numCampo = 1;
//                //                    IndicadoresRelEgresados.Add(IndicadorRE);
//                //                }
//                //                else if (itemA.tpEgresado == "P" && itemA.idReligion == Religion.idReligion)
//                //                {
//                //                    IndicadoresVM IndicadorRNE = new IndicadoresVM();
//                //                    IndicadorRNE.nbCampo = "Pasante";
//                //                    IndicadorRNE.nbCampo2 = Religion.nbReligion;
//                //                    IndicadorRNE.numCampo = 1;
//                //                    IndicadoresRelEgresados.Add(IndicadorRNE);
//                //                }
//                //            }
//                //        }
//                //    }

//                //    IndicadoresRelEgresados.ToList().ForEach(l =>
//                //    {
//                //        var row = dt.NewRow();
//                //        row["nbCategoria"] = l.nbCampo;
//                //        row["nbCategoria2"] = l.nbCampo2;
//                //        row["numDatos"] = l.numCampo;
//                //        dt.Rows.Add(row);
//                //    });

//                //    #endregion
//                //}
//                //else if (listacaCampos[0] == 13 && listacaCampos[1] == 9)
//                //{
//                //    #region

//                //    TituloColumna1 = "Tipo de Egresado";
//                //    TituloColumna2 = "Estado";
//                //    TituloColumna3 = "Cantidad";
//                //    TituloGrafic = "Gráfica de barras por Tipo de Egresado y Estado";
//                //    CatEstados Estado = new CatEstados();
//                //    var Estados = db.CatEstados.ToList();

//                //    List<IndicadoresVM> IndicadoresEdosEgresados = new List<IndicadoresVM>();

//                //    if (listaIdsestados.Count() > 0 && Book.tpEgresado != null)
//                //    {
//                //        foreach (var itemE in listaIdsestados)
//                //        {
//                //            foreach (var itemA in Alumnos)
//                //            {
//                //                var idEstado = Convert.ToInt64(itemE);
//                //                Estado = Estados.FirstOrDefault(x => x.idEstado == idEstado);
//                //                if (itemA.tpEgresado == Book.tpEgresado && itemA.Direcciones.nbEstado.Trim().ToUpper() == Estado.nbEstado.Trim().ToUpper())
//                //                {
//                //                    IndicadoresVM IndicadorEE = new IndicadoresVM();
//                //                    IndicadorEE.nbCampo = (Book.tpEgresado == "T") ? "Titulado" : "Pasante";
//                //                    IndicadorEE.nbCampo2 = Estado.nbEstado;
//                //                    IndicadorEE.numCampo = 1;
//                //                    IndicadoresEdosEgresados.Add(IndicadorEE);
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (listaIdsestados.Count() > 0 && Book.tpEgresado == null)
//                //    {
//                //        foreach (var itemE in listaIdsestados)
//                //        {
//                //            foreach (var itemA in Alumnos)
//                //            {
//                //                var idEstado = Convert.ToInt64(itemE);
//                //                Estado = Estados.FirstOrDefault(x => x.idEstado == idEstado);
//                //                if (itemA.tpEgresado == "T" && itemA.Direcciones.nbEstado.Trim().ToUpper() == Estado.nbEstado.Trim().ToUpper())
//                //                {
//                //                    IndicadoresVM IndicadorEE = new IndicadoresVM();
//                //                    IndicadorEE.nbCampo = "Titulado";
//                //                    IndicadorEE.nbCampo2 = Estado.nbEstado;
//                //                    IndicadorEE.numCampo = 1;
//                //                    IndicadoresEdosEgresados.Add(IndicadorEE);
//                //                }
//                //                else if (itemA.tpEgresado == "P" && itemA.Direcciones.nbEstado.Trim().ToUpper() == Estado.nbEstado.Trim().ToUpper())
//                //                {
//                //                    IndicadoresVM IndicadorENE = new IndicadoresVM();
//                //                    IndicadorENE.nbCampo = "Pasante";
//                //                    IndicadorENE.nbCampo2 = Estado.nbEstado;
//                //                    IndicadorENE.numCampo = 1;
//                //                    IndicadoresEdosEgresados.Add(IndicadorENE);
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (listaIdsestados.Count() == 0 && Book.tpEgresado != null)
//                //    {
//                //        foreach (var itemE in Estados)
//                //        {
//                //            foreach (var itemA in Alumnos)
//                //            {
//                //                //var idEstado = Convert.ToInt64(itemE);
//                //                Estado = Estados.FirstOrDefault(x => x.idEstado == itemE.idEstado);
//                //                if (itemA.tpEgresado == Book.tpEgresado && itemA.Direcciones.nbEstado.Trim().ToUpper() == Estado.nbEstado.Trim().ToUpper())
//                //                {
//                //                    IndicadoresVM IndicadorEE = new IndicadoresVM();
//                //                    IndicadorEE.nbCampo = (Book.tpEgresado == "T") ? "Titulado" : "Pasante";
//                //                    IndicadorEE.nbCampo2 = Estado.nbEstado;
//                //                    IndicadorEE.numCampo = 1;
//                //                    IndicadoresEdosEgresados.Add(IndicadorEE);
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (listaIdsestados.Count() == 0 && Book.tpEgresado == null)
//                //    {
//                //        foreach (var itemE in Estados)
//                //        {
//                //            foreach (var itemA in Alumnos)
//                //            {
//                //                //var idEstado = Convert.ToInt64(itemE);
//                //                Estado = Estados.FirstOrDefault(x => x.idEstado == itemE.idEstado);
//                //                if (itemA.tpEgresado == "T" && itemA.Direcciones.nbEstado.Trim().ToUpper() == Estado.nbEstado.Trim().ToUpper())
//                //                {
//                //                    IndicadoresVM IndicadorEE = new IndicadoresVM();
//                //                    IndicadorEE.nbCampo = "Titulado";
//                //                    IndicadorEE.nbCampo2 = Estado.nbEstado;
//                //                    IndicadorEE.numCampo = 1;
//                //                    IndicadoresEdosEgresados.Add(IndicadorEE);
//                //                }
//                //                else if (itemA.tpEgresado == "P" && itemA.Direcciones.nbEstado.Trim().ToUpper() == Estado.nbEstado.Trim().ToUpper())
//                //                {
//                //                    IndicadoresVM IndicadorENE = new IndicadoresVM();
//                //                    IndicadorENE.nbCampo = "Pasante";
//                //                    IndicadorENE.nbCampo2 = Estado.nbEstado;
//                //                    IndicadorENE.numCampo = 1;
//                //                    IndicadoresEdosEgresados.Add(IndicadorENE);
//                //                }
//                //            }
//                //        }
//                //    }

//                //    IndicadoresEdosEgresados.ToList().ForEach(l =>
//                //    {
//                //        var row = dt.NewRow();
//                //        row["nbCategoria"] = l.nbCampo;
//                //        row["nbCategoria2"] = l.nbCampo2;
//                //        row["numDatos"] = l.numCampo;
//                //        dt.Rows.Add(row);
//                //    });

//                //    #endregion
//                //}
//                //else if (listacaCampos[0] == 13 && listacaCampos[1] == 10)
//                //{
//                //    #region

//                //    TituloColumna1 = "Tipo de Egresado";
//                //    TituloColumna2 = "Trabajo";
//                //    TituloColumna3 = "Cantidad";
//                //    TituloGrafic = "Gráfica de barras por Tipo de Egresado y Trabajo";
//                //    List<IndicadoresVM> IndicadoresTL = new List<IndicadoresVM>();
//                //    if (Book.tpEgresado != null && Book.fgTrabajaActualmente != null)
//                //    {
//                //        foreach (var itemA in Alumnos)
//                //        {
//                //            if (itemA.fgTrabajaActualmente == Book.fgTrabajaActualmente && itemA.tpEgresado == Book.tpEgresado)
//                //            {
//                //                IndicadoresVM IndicadorTL = new IndicadoresVM();
//                //                IndicadorTL.nbCampo = (Book.tpEgresado == "T") ? "Titulado" : "Pasante";
//                //                IndicadorTL.nbCampo2 = (Book.fgTrabajaActualmente == true) ? "SI" : "NO";
//                //                IndicadorTL.numCampo = 1;
//                //                IndicadoresTL.Add(IndicadorTL);
//                //            }
//                //        }
//                //    }
//                //    else if (Book.tpEgresado != null && Book.fgTrabajaActualmente == null)
//                //    {
//                //        foreach (var itemA in Alumnos)
//                //        {
//                //            if (itemA.fgTrabajaActualmente == true && itemA.tpEgresado == Book.tpEgresado)
//                //            {
//                //                IndicadoresVM IndicadorTL = new IndicadoresVM();
//                //                IndicadorTL.nbCampo = (Book.tpEgresado == "T") ? "Titulado" : "Pasante";
//                //                IndicadorTL.nbCampo2 = "SI";
//                //                IndicadorTL.numCampo = 1;
//                //                IndicadoresTL.Add(IndicadorTL);
//                //            }
//                //            else if (itemA.fgTrabajaActualmente == false && itemA.tpEgresado == Book.tpEgresado)
//                //            {
//                //                IndicadoresVM IndicadorTLN = new IndicadoresVM();
//                //                IndicadorTLN.nbCampo = (Book.tpEgresado == "T") ? "Titulado" : "Pasante";
//                //                IndicadorTLN.nbCampo2 = "NO";
//                //                IndicadorTLN.numCampo = 1;
//                //                IndicadoresTL.Add(IndicadorTLN);
//                //            }
//                //        }
//                //    }
//                //    else if (Book.tpEgresado == null && Book.fgTrabajaActualmente == null)
//                //    {
//                //        foreach (var itemA in Alumnos)
//                //        {
//                //            if (itemA.fgTrabajaActualmente == true && itemA.tpEgresado == "T")
//                //            {
//                //                IndicadoresVM IndicadorTL = new IndicadoresVM();
//                //                IndicadorTL.nbCampo = "Titulado";
//                //                IndicadorTL.nbCampo2 = "SI";
//                //                IndicadorTL.numCampo = 1;
//                //                IndicadoresTL.Add(IndicadorTL);
//                //            }
//                //            else if (itemA.fgTrabajaActualmente == false && itemA.tpEgresado == "T")
//                //            {
//                //                IndicadoresVM IndicadorNTL = new IndicadoresVM();
//                //                IndicadorNTL.nbCampo = "Titulado";
//                //                IndicadorNTL.nbCampo2 = "NO";
//                //                IndicadorNTL.numCampo = 1;
//                //                IndicadoresTL.Add(IndicadorNTL);
//                //            }
//                //            else if (itemA.fgTrabajaActualmente == true && itemA.tpEgresado == "P")
//                //            {
//                //                IndicadoresVM IndicadorTNL = new IndicadoresVM();
//                //                IndicadorTNL.nbCampo = "Pasante";
//                //                IndicadorTNL.nbCampo2 = "SI";
//                //                IndicadorTNL.numCampo = 1;
//                //                IndicadoresTL.Add(IndicadorTNL);
//                //            }
//                //            else if (itemA.fgTrabajaActualmente == false && itemA.tpEgresado == "P")
//                //            {
//                //                IndicadoresVM IndicadorNTNL = new IndicadoresVM();
//                //                IndicadorNTNL.nbCampo = "Pasante";
//                //                IndicadorNTNL.nbCampo2 = "NO";
//                //                IndicadorNTNL.numCampo = 1;
//                //                IndicadoresTL.Add(IndicadorNTNL);
//                //            }
//                //        }
//                //    }
//                //    else if (Book.tpEgresado == null && Book.fgTrabajaActualmente != null)
//                //    {
//                //        foreach (var itemA in Alumnos)
//                //        {
//                //            if (itemA.fgTrabajaActualmente == Book.fgTrabajaActualmente && itemA.tpEgresado == "T")
//                //            {
//                //                IndicadoresVM IndicadorTL = new IndicadoresVM();
//                //                IndicadorTL.nbCampo = "Titulado";
//                //                IndicadorTL.nbCampo2 = "SI";
//                //                IndicadorTL.numCampo = 1;
//                //                IndicadoresTL.Add(IndicadorTL);
//                //            }
//                //            else if (itemA.fgTrabajaActualmente == Book.fgTrabajaActualmente && itemA.tpEgresado == "P")
//                //            {
//                //                IndicadoresVM IndicadorNTL = new IndicadoresVM();
//                //                IndicadorNTL.nbCampo = "Pasante";
//                //                IndicadorNTL.nbCampo2 = "NO";
//                //                IndicadorNTL.numCampo = 1;
//                //                IndicadoresTL.Add(IndicadorNTL);
//                //            }
//                //        }
//                //    }

//                //    IndicadoresTL.ToList().ForEach(l =>
//                //    {
//                //        var row = dt.NewRow();
//                //        row["nbCategoria"] = l.nbCampo;
//                //        row["nbCategoria2"] = l.nbCampo2;
//                //        row["numDatos"] = l.numCampo;
//                //        dt.Rows.Add(row);
//                //    });

//                //    #endregion
//                //}
//                //else if (listacaCampos[0] == 13 && listacaCampos[1] == 11)
//                //{
//                //    #region

//                //    TituloColumna1 = "Tipo de Egresado";
//                //    TituloColumna2 = "Tipo de Sangre";
//                //    TituloColumna3 = "Cantidad";
//                //    TituloGrafic = "Gráfica de barras por Tipo de Egresado y Tipo de Sangre";
//                //    var CatTiposSangre = db.CatTiposSangre.ToList();
//                //    List<IndicadoresVM> IndicadoresTS = new List<IndicadoresVM>();
//                //    if (Book.idTipoSangre != null && Book.tpEgresado != null)
//                //    {
//                //        foreach (var itemA in Alumnos)
//                //        {
//                //            var TipoSangre = db.CatTiposSangre.Find(Book.idTipoSangre);
//                //            if (itemA.tpEgresado == Book.tpEgresado && itemA.idTipoSangre == Book.idTipoSangre)
//                //            {
//                //                IndicadoresVM IndicadorTS = new IndicadoresVM();
//                //                IndicadorTS.nbCampo = (Book.tpEgresado == "T") ? "Titulado" : "Pasante";
//                //                IndicadorTS.nbCampo2 = TipoSangre.nbTipoSangre;
//                //                IndicadorTS.numCampo = 1;
//                //                IndicadoresTS.Add(IndicadorTS);
//                //            }
//                //        }
//                //    }
//                //    else if (Book.idTipoSangre != null && Book.tpEgresado == null)
//                //    {
//                //        foreach (var itemA in Alumnos)
//                //        {
//                //            var TipoSangre = db.CatTiposSangre.Find(Book.idTipoSangre);
//                //            if (itemA.tpEgresado == "T" && itemA.idTipoSangre == Book.idTipoSangre)
//                //            {
//                //                IndicadoresVM IndicadorTS = new IndicadoresVM();
//                //                IndicadorTS.nbCampo = "Titulado";
//                //                IndicadorTS.nbCampo2 = TipoSangre.nbTipoSangre;
//                //                IndicadorTS.numCampo = 1;
//                //                IndicadoresTS.Add(IndicadorTS);
//                //            }
//                //            else if (itemA.tpEgresado == "P" && itemA.idTipoSangre == Book.idTipoSangre)
//                //            {
//                //                IndicadoresVM IndicadorTSN = new IndicadoresVM();
//                //                IndicadorTSN.nbCampo = "Pasante";
//                //                IndicadorTSN.nbCampo2 = TipoSangre.nbTipoSangre;
//                //                IndicadorTSN.numCampo = 1;
//                //                IndicadoresTS.Add(IndicadorTSN);
//                //            }
//                //        }
//                //    }
//                //    else if (Book.idTipoSangre == null && Book.tpEgresado == null)
//                //    {
//                //        foreach (var itemS in CatTiposSangre)
//                //        {
//                //            foreach (var itemA in Alumnos)
//                //            {
//                //                var TipoSangre = db.CatTiposSangre.Find(itemS.idTipoSangre);
//                //                if (itemA.tpEgresado == "T" && itemA.idTipoSangre == Book.idTipoSangre)
//                //                {
//                //                    IndicadoresVM IndicadorTS = new IndicadoresVM();
//                //                    IndicadorTS.nbCampo = "Titulado";
//                //                    IndicadorTS.nbCampo2 = TipoSangre.nbTipoSangre;
//                //                    IndicadorTS.numCampo = 1;
//                //                    IndicadoresTS.Add(IndicadorTS);
//                //                }
//                //                else if (itemA.tpEgresado == "P" && itemA.idTipoSangre == Book.idTipoSangre)
//                //                {
//                //                    IndicadoresVM IndicadorTSN = new IndicadoresVM();
//                //                    IndicadorTSN.nbCampo = "Pasante";
//                //                    IndicadorTSN.nbCampo2 = TipoSangre.nbTipoSangre;
//                //                    IndicadorTSN.numCampo = 1;
//                //                    IndicadoresTS.Add(IndicadorTSN);
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (Book.idEstadoCivil == null && Book.tpEgresado != null)
//                //    {
//                //        foreach (var itemS in CatTiposSangre)
//                //        {
//                //            foreach (var itemA in Alumnos)
//                //            {
//                //                var TipoSangre = db.CatTiposSangre.Find(itemS.idTipoSangre);
//                //                if (itemA.tpEgresado == Book.tpEgresado && itemA.idTipoSangre == Book.idTipoSangre)
//                //                {
//                //                    IndicadoresVM IndicadorTS = new IndicadoresVM();
//                //                    IndicadorTS.nbCampo = (Book.tpEgresado == "T") ? "Titulado" : "Pasante";
//                //                    IndicadorTS.nbCampo2 = TipoSangre.nbTipoSangre;
//                //                    IndicadorTS.numCampo = 1;
//                //                    IndicadoresTS.Add(IndicadorTS);
//                //                }
//                //            }

//                //        }
//                //    }

//                //    IndicadoresTS.ToList().ForEach(l =>
//                //    {
//                //        var row = dt.NewRow();
//                //        row["nbCategoria"] = l.nbCampo;
//                //        row["nbCategoria2"] = l.nbCampo2;
//                //        row["numDatos"] = l.numCampo;
//                //        dt.Rows.Add(row);
//                //    });

//                //    #endregion
//                //}
//                //else if (listacaCampos[0] == 13 && listacaCampos[1] == 12)
//                //{
//                //    #region

//                //    TituloColumna1 = "Tipo de Egresado";
//                //    TituloColumna2 = "Licencia";
//                //    TituloColumna3 = "Cantidad";
//                //    TituloGrafic = "Gráfica de barras por Tipo de Egresado y Licencia";
//                //    List<IndicadoresVM> IndicadoresTL = new List<IndicadoresVM>();
//                //    if (Book.tpEgresado != null && Book.fgLicencia != null)
//                //    {
//                //        foreach (var itemA in Alumnos)
//                //        {
//                //            if (itemA.fgLicencia == Book.fgLicencia && itemA.tpEgresado == Book.tpEgresado)
//                //            {
//                //                IndicadoresVM IndicadorTL = new IndicadoresVM();
//                //                IndicadorTL.nbCampo = (Book.tpEgresado == "T") ? "Titulado" : "Pasante";
//                //                IndicadorTL.nbCampo2 = (Book.fgLicencia == true) ? "SI" : "NO";
//                //                IndicadorTL.numCampo = 1;
//                //                IndicadoresTL.Add(IndicadorTL);
//                //            }
//                //        }
//                //    }
//                //    else if (Book.tpEgresado != null && Book.fgLicencia == null)
//                //    {
//                //        foreach (var itemA in Alumnos)
//                //        {
//                //            if (itemA.fgLicencia == true && itemA.tpEgresado == Book.tpEgresado)
//                //            {
//                //                IndicadoresVM IndicadorTL = new IndicadoresVM();
//                //                IndicadorTL.nbCampo = (Book.tpEgresado == "T") ? "Titulado" : "Pasante";
//                //                IndicadorTL.nbCampo2 = "SI";
//                //                IndicadorTL.numCampo = 1;
//                //                IndicadoresTL.Add(IndicadorTL);
//                //            }
//                //            else if (itemA.fgLicencia == false && itemA.tpEgresado == Book.tpEgresado)
//                //            {
//                //                IndicadoresVM IndicadorTLN = new IndicadoresVM();
//                //                IndicadorTLN.nbCampo = (Book.tpEgresado == "T") ? "Titulado" : "Pasante";
//                //                IndicadorTLN.nbCampo2 = "NO";
//                //                IndicadorTLN.numCampo = 1;
//                //                IndicadoresTL.Add(IndicadorTLN);
//                //            }
//                //        }
//                //    }
//                //    else if (Book.tpEgresado == null && Book.fgLicencia == null)
//                //    {
//                //        foreach (var itemA in Alumnos)
//                //        {
//                //            if (itemA.fgLicencia == true && itemA.tpEgresado == "T")
//                //            {
//                //                IndicadoresVM IndicadorTL = new IndicadoresVM();
//                //                IndicadorTL.nbCampo = "Titulado";
//                //                IndicadorTL.nbCampo2 = "SI";
//                //                IndicadorTL.numCampo = 1;
//                //                IndicadoresTL.Add(IndicadorTL);
//                //            }
//                //            else if (itemA.fgLicencia == false && itemA.tpEgresado == "T")
//                //            {
//                //                IndicadoresVM IndicadorNTL = new IndicadoresVM();
//                //                IndicadorNTL.nbCampo = "Titulado";
//                //                IndicadorNTL.nbCampo2 = "NO";
//                //                IndicadorNTL.numCampo = 1;
//                //                IndicadoresTL.Add(IndicadorNTL);
//                //            }
//                //            else if (itemA.fgLicencia == true && itemA.tpEgresado == "P")
//                //            {
//                //                IndicadoresVM IndicadorTNL = new IndicadoresVM();
//                //                IndicadorTNL.nbCampo = "Pasante";
//                //                IndicadorTNL.nbCampo2 = "SI";
//                //                IndicadorTNL.numCampo = 1;
//                //                IndicadoresTL.Add(IndicadorTNL);
//                //            }
//                //            else if (itemA.fgLicencia == false && itemA.tpEgresado == "P")
//                //            {
//                //                IndicadoresVM IndicadorNTNL = new IndicadoresVM();
//                //                IndicadorNTNL.nbCampo = "Pasante";
//                //                IndicadorNTNL.nbCampo2 = "NO";
//                //                IndicadorNTNL.numCampo = 1;
//                //                IndicadoresTL.Add(IndicadorNTNL);
//                //            }
//                //        }
//                //    }
//                //    else if (Book.tpEgresado == null && Book.fgLicencia != null)
//                //    {
//                //        foreach (var itemA in Alumnos)
//                //        {
//                //            if (itemA.fgLicencia == Book.fgLicencia && itemA.tpEgresado == "T")
//                //            {
//                //                IndicadoresVM IndicadorTNL = new IndicadoresVM();
//                //                IndicadorTNL.nbCampo = "Titulado";
//                //                IndicadorTNL.nbCampo2 = (Book.fgLicencia == true) ? "SI" : "NO";
//                //                IndicadorTNL.numCampo = 1;
//                //                IndicadoresTL.Add(IndicadorTNL);
//                //            }
//                //            else if (itemA.fgLicencia == Book.fgLicencia && itemA.tpEgresado == "P")
//                //            {
//                //                IndicadoresVM IndicadorNTNL = new IndicadoresVM();
//                //                IndicadorNTNL.nbCampo = "Pasante";
//                //                IndicadorNTNL.nbCampo2 = (Book.fgLicencia == true) ? "SI" : "NO";
//                //                IndicadorNTNL.numCampo = 1;
//                //                IndicadoresTL.Add(IndicadorNTNL);
//                //            }
//                //        }
//                //    }

//                //    IndicadoresTL.ToList().ForEach(l =>
//                //    {
//                //        var row = dt.NewRow();
//                //        row["nbCategoria"] = l.nbCampo;
//                //        row["nbCategoria2"] = l.nbCampo2;
//                //        row["numDatos"] = l.numCampo;
//                //        dt.Rows.Add(row);
//                //    });

//                //    #endregion
//                //}
//                //else if (listacaCampos[0] == 13 && listacaCampos[1] == 14)
//                //{
//                //    #region

//                //    TituloColumna1 = "Tipo de Egresado";
//                //    TituloColumna2 = "Fallecimiento";
//                //    TituloColumna3 = "Cantidad";
//                //    TituloGrafic = "Gráfica de barras por Tipo de Egresado y Fallecimiento";
//                //    List<IndicadoresVM> IndicadoresTL = new List<IndicadoresVM>();
//                //    if (Book.tpEgresado != null && Book.fgFallecido != null)
//                //    {
//                //        foreach (var itemA in Alumnos)
//                //        {
//                //            if (itemA.fgFallecido == Book.fgFallecido && itemA.tpEgresado == Book.tpEgresado)
//                //            {
//                //                IndicadoresVM IndicadorTL = new IndicadoresVM();
//                //                IndicadorTL.nbCampo = (Book.tpEgresado == "T") ? "Titulado" : "Pasante";
//                //                IndicadorTL.nbCampo2 = (Book.fgFallecido == true) ? "SI" : "NO";
//                //                IndicadorTL.numCampo = 1;
//                //                IndicadoresTL.Add(IndicadorTL);
//                //            }
//                //        }
//                //    }
//                //    else if (Book.tpEgresado != null && Book.fgFallecido == null)
//                //    {
//                //        foreach (var itemA in Alumnos)
//                //        {
//                //            if (itemA.fgFallecido == true && itemA.tpEgresado == Book.tpEgresado)
//                //            {
//                //                IndicadoresVM IndicadorTL = new IndicadoresVM();
//                //                IndicadorTL.nbCampo = (Book.tpEgresado == "T") ? "Titulado" : "Pasante";
//                //                IndicadorTL.nbCampo2 = "SI";
//                //                IndicadorTL.numCampo = 1;
//                //                IndicadoresTL.Add(IndicadorTL);
//                //            }
//                //            else if (itemA.fgFallecido == false && itemA.tpEgresado == Book.tpEgresado)
//                //            {
//                //                IndicadoresVM IndicadorTLN = new IndicadoresVM();
//                //                IndicadorTLN.nbCampo = (Book.tpEgresado == "T") ? "Titulado" : "Pasante";
//                //                IndicadorTLN.nbCampo2 = "NO";
//                //                IndicadorTLN.numCampo = 1;
//                //                IndicadoresTL.Add(IndicadorTLN);
//                //            }
//                //        }
//                //    }
//                //    else if (Book.tpEgresado == null && Book.fgFallecido == null)
//                //    {
//                //        foreach (var itemA in Alumnos)
//                //        {
//                //            if (itemA.fgFallecido == true && itemA.tpEgresado == "T")
//                //            {
//                //                IndicadoresVM IndicadorTL = new IndicadoresVM();
//                //                IndicadorTL.nbCampo = "Titulado";
//                //                IndicadorTL.nbCampo2 = "SI";
//                //                IndicadorTL.numCampo = 1;
//                //                IndicadoresTL.Add(IndicadorTL);
//                //            }
//                //            else if (itemA.fgFallecido == false && itemA.tpEgresado == "T")
//                //            {
//                //                IndicadoresVM IndicadorNTL = new IndicadoresVM();
//                //                IndicadorNTL.nbCampo = "Titulado";
//                //                IndicadorNTL.nbCampo2 = "NO";
//                //                IndicadorNTL.numCampo = 1;
//                //                IndicadoresTL.Add(IndicadorNTL);
//                //            }
//                //            else if (itemA.fgFallecido == true && itemA.tpEgresado == "P")
//                //            {
//                //                IndicadoresVM IndicadorTNL = new IndicadoresVM();
//                //                IndicadorTNL.nbCampo = "Pasante";
//                //                IndicadorTNL.nbCampo2 = "SI";
//                //                IndicadorTNL.numCampo = 1;
//                //                IndicadoresTL.Add(IndicadorTNL);
//                //            }
//                //            else if (itemA.fgFallecido == false && itemA.tpEgresado == "P")
//                //            {
//                //                IndicadoresVM IndicadorNTNL = new IndicadoresVM();
//                //                IndicadorNTNL.nbCampo = "Pasante";
//                //                IndicadorNTNL.nbCampo2 = "NO";
//                //                IndicadorNTNL.numCampo = 1;
//                //                IndicadoresTL.Add(IndicadorNTNL);
//                //            }
//                //        }
//                //    }
//                //    else if (Book.tpEgresado == null && Book.fgFallecido != null)
//                //    {
//                //        foreach (var itemA in Alumnos)
//                //        {
//                //            if (itemA.fgFallecido == Book.fgFallecido && itemA.tpEgresado == "T")
//                //            {
//                //                IndicadoresVM IndicadorTNL = new IndicadoresVM();
//                //                IndicadorTNL.nbCampo = "Titulado";
//                //                IndicadorTNL.nbCampo2 = (Book.fgFallecido == true) ? "SI" : "NO";
//                //                IndicadorTNL.numCampo = 1;
//                //                IndicadoresTL.Add(IndicadorTNL);
//                //            }
//                //            else if (itemA.fgFallecido == Book.fgFallecido && itemA.tpEgresado == "P")
//                //            {
//                //                IndicadoresVM IndicadorNTNL = new IndicadoresVM();
//                //                IndicadorNTNL.nbCampo = "Pasante";
//                //                IndicadorNTNL.nbCampo2 = (Book.fgFallecido == true) ? "SI" : "NO";
//                //                IndicadorNTNL.numCampo = 1;
//                //                IndicadoresTL.Add(IndicadorNTNL);
//                //            }
//                //        }
//                //    }

//                //    IndicadoresTL.ToList().ForEach(l =>
//                //    {
//                //        var row = dt.NewRow();
//                //        row["nbCategoria"] = l.nbCampo;
//                //        row["nbCategoria2"] = l.nbCampo2;
//                //        row["numDatos"] = l.numCampo;
//                //        dt.Rows.Add(row);
//                //    });

//                //    #endregion
//                //}
//                //else if (listacaCampos[0] == 14 && listacaCampos[1] == 2)
//                //{
//                //    #region

//                //    TituloColumna1 = "Fallecimiento";
//                //    TituloColumna2 = "Estado Civil";
//                //    TituloColumna3 = "Cantidad";
//                //    TituloGrafic = "Gráfica de barras por Fallecimiento y Estado Civil";
//                //    var CatEstadosCiviles = db.CatEstadosCiviles.ToList();
//                //    List<IndicadoresVM> IndicadoresEdoCFallecido = new List<IndicadoresVM>();


//                //    if (Book.idEstadoCivil != null && Book.fgFallecido != null)
//                //    {
//                //        foreach (var item in Alumnos)
//                //        {
//                //            var EstadoCivil = db.CatEstadosCiviles.Find(Book.idEstadoCivil);
//                //            if (item.fgFallecido == Book.fgFallecido && item.idEstadoCivil == EstadoCivil.idEstadoCivil)
//                //            {
//                //                IndicadoresVM IndicadorECF = new IndicadoresVM();
//                //                IndicadorECF.nbCampo = (Book.fgFallecido == true) ? "SI" : "NO";
//                //                IndicadorECF.nbCampo2 = EstadoCivil.nbEstadoCivil;
//                //                IndicadorECF.numCampo = 1;
//                //                IndicadoresEdoCFallecido.Add(IndicadorECF);
//                //            }
//                //        }
//                //    }
//                //    else if (Book.idEstadoCivil != null && Book.fgFallecido == null)
//                //    {
//                //        foreach (var item in Alumnos)
//                //        {
//                //            var EstadoCivil = db.CatEstadosCiviles.Find(Book.idEstadoCivil);
//                //            if (item.fgFallecido == true && item.idEstadoCivil == EstadoCivil.idEstadoCivil)
//                //            {
//                //                IndicadoresVM IndicadorECF = new IndicadoresVM();
//                //                IndicadorECF.nbCampo = "SI";
//                //                IndicadorECF.nbCampo2 = EstadoCivil.nbEstadoCivil;
//                //                IndicadorECF.numCampo = 1;
//                //                IndicadoresEdoCFallecido.Add(IndicadorECF);
//                //            }
//                //            else if (item.fgFallecido == false && item.idEstadoCivil == EstadoCivil.idEstadoCivil)
//                //            {
//                //                IndicadoresVM IndicadorECFN = new IndicadoresVM();
//                //                IndicadorECFN.nbCampo = "NO";
//                //                IndicadorECFN.nbCampo2 = EstadoCivil.nbEstadoCivil;
//                //                IndicadorECFN.numCampo = 1;
//                //                IndicadoresEdoCFallecido.Add(IndicadorECFN);
//                //            }
//                //        }
//                //    }
//                //    else if (Book.idEstadoCivil == null && Book.fgFallecido == null)
//                //    {
//                //        foreach (var itemEC in CatEstadosCiviles)
//                //        {
//                //            foreach (var item in Alumnos)
//                //            {
//                //                var EstadoCivil = db.CatEstadosCiviles.Find(itemEC.idEstadoCivil);
//                //                if (item.fgFallecido == true && item.idEstadoCivil == EstadoCivil.idEstadoCivil)
//                //                {
//                //                    IndicadoresVM IndicadorECF = new IndicadoresVM();
//                //                    IndicadorECF.nbCampo = "SI";
//                //                    IndicadorECF.nbCampo2 = EstadoCivil.nbEstadoCivil;
//                //                    IndicadorECF.numCampo = 1;
//                //                    IndicadoresEdoCFallecido.Add(IndicadorECF);
//                //                }
//                //                else if (item.fgFallecido == false && item.idEstadoCivil == EstadoCivil.idEstadoCivil)
//                //                {
//                //                    IndicadoresVM IndicadorECFN = new IndicadoresVM();
//                //                    IndicadorECFN.nbCampo = "NO";
//                //                    IndicadorECFN.nbCampo2 = EstadoCivil.nbEstadoCivil;
//                //                    IndicadorECFN.numCampo = 1;
//                //                    IndicadoresEdoCFallecido.Add(IndicadorECFN);
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (Book.idEstadoCivil == null && Book.fgFallecido != null)
//                //    {
//                //        foreach (var itemEC in CatEstadosCiviles)
//                //        {
//                //            foreach (var item in Alumnos)
//                //            {
//                //                var EstadoCivil = db.CatEstadosCiviles.Find(itemEC.idEstadoCivil);
//                //                if (item.fgFallecido == Book.fgFallecido && item.idEstadoCivil == EstadoCivil.idEstadoCivil)
//                //                {
//                //                    IndicadoresVM IndicadorECF = new IndicadoresVM();
//                //                    IndicadorECF.nbCampo = (Book.fgFallecido == true) ? "SI" : "NO";
//                //                    IndicadorECF.nbCampo2 = EstadoCivil.nbEstadoCivil;
//                //                    IndicadorECF.numCampo = 1;
//                //                    IndicadoresEdoCFallecido.Add(IndicadorECF);
//                //                }
//                //            }
//                //        }
//                //    }

//                //    IndicadoresEdoCFallecido.ToList().ForEach(l =>
//                //    {
//                //        var row = dt.NewRow();
//                //        row["nbCategoria"] = l.nbCampo;
//                //        row["nbCategoria2"] = l.nbCampo2;
//                //        row["numDatos"] = l.numCampo;
//                //        dt.Rows.Add(row);
//                //    });

//                //    #endregion
//                //}
//                //else if (listacaCampos[0] == 14 && listacaCampos[1] == 3)
//                //{
//                //    #region

//                //    TituloColumna1 = "Fallecimiento";
//                //    TituloColumna2 = "Edad";
//                //    TituloColumna3 = "Cantidad";
//                //    TituloGrafic = "Gráfica de barras por Fallecimiento y Edad";
//                //    List<IndicadoresVM> ListaEdadTrabajo = new List<IndicadoresVM>();

//                //    if (Book.numEdadMinima != null && Book.numEdadMinima != null && Book.fgFallecido != null)
//                //    {
//                //        for (var i = Book.numEdadMinima; i <= Book.numEdadMaxima; i++)
//                //        {
//                //            foreach (var item in Alumnos)
//                //            {
//                //                var edad = DateTime.Now.Year - ((DateTime)item.feNacimiento).Date.Year;
//                //                if (edad == i && item.fgTrabajaActualmente == Book.fgTrabajaActualmente)
//                //                {
//                //                    IndicadoresVM IndicadorEdadT = new IndicadoresVM();
//                //                    IndicadorEdadT.nbCampo = (Book.fgFallecido == true) ? "SI" : "NO";
//                //                    IndicadorEdadT.nbCampo2 = i + " Años";
//                //                    IndicadorEdadT.numCampo = 1;
//                //                    ListaEdadTrabajo.Add(IndicadorEdadT);
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (Book.numEdadMinima != null && Book.numEdadMinima != null && Book.fgFallecido == null)
//                //    {
//                //        for (var i = Book.numEdadMinima; i <= Book.numEdadMaxima; i++)
//                //        {
//                //            foreach (var item in Alumnos)
//                //            {
//                //                var edad = DateTime.Now.Year - ((DateTime)item.feNacimiento).Date.Year;
//                //                if (edad == i && item.fgFallecido == true)
//                //                {
//                //                    IndicadoresVM IndicadorEdadT = new IndicadoresVM();
//                //                    IndicadorEdadT.nbCampo = "SI";
//                //                    IndicadorEdadT.nbCampo2 = i + " Años";
//                //                    IndicadorEdadT.numCampo = 1;
//                //                    ListaEdadTrabajo.Add(IndicadorEdadT);
//                //                }
//                //                else if (edad == i && item.fgFallecido == false)
//                //                {
//                //                    IndicadoresVM IndicadorEdadT = new IndicadoresVM();
//                //                    IndicadorEdadT.nbCampo = "NO";
//                //                    IndicadorEdadT.nbCampo2 = i + " Años";
//                //                    IndicadorEdadT.numCampo = 1;
//                //                    ListaEdadTrabajo.Add(IndicadorEdadT);
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (Book.numEdadMinima == null && Book.numEdadMinima == null && Book.fgFallecido != null)
//                //    {
//                //        for (var i = 15; i <= 80; i++)
//                //        {
//                //            foreach (var item in Alumnos)
//                //            {
//                //                var edad = DateTime.Now.Year - ((DateTime)item.feNacimiento).Date.Year;
//                //                if (edad == i && item.fgFallecido == Book.fgFallecido)
//                //                {
//                //                    IndicadoresVM IndicadorEdadT = new IndicadoresVM();
//                //                    IndicadorEdadT.nbCampo = (Book.fgFallecido == true) ? "SI" : "NO";
//                //                    IndicadorEdadT.nbCampo2 = i + " Años";
//                //                    IndicadorEdadT.numCampo = 1;
//                //                    ListaEdadTrabajo.Add(IndicadorEdadT);
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (Book.numEdadMinima == null && Book.numEdadMinima == null && Book.fgFallecido == null)
//                //    {
//                //        for (var i = 15; i <= 80; i++)
//                //        {
//                //            foreach (var item in Alumnos)
//                //            {
//                //                var edad = DateTime.Now.Year - ((DateTime)item.feNacimiento).Date.Year;
//                //                if (edad == i && item.fgFallecido == true)
//                //                {
//                //                    IndicadoresVM IndicadorEdadT = new IndicadoresVM();
//                //                    IndicadorEdadT.nbCampo = "SI";
//                //                    IndicadorEdadT.nbCampo2 = i + " Años";
//                //                    IndicadorEdadT.numCampo = 1;
//                //                    ListaEdadTrabajo.Add(IndicadorEdadT);
//                //                }
//                //                else if (edad == i && item.fgFallecido == false)
//                //                {
//                //                    IndicadoresVM IndicadorEdadT = new IndicadoresVM();
//                //                    IndicadorEdadT.nbCampo = "NO";
//                //                    IndicadorEdadT.nbCampo2 = i + " Años";
//                //                    IndicadorEdadT.numCampo = 1;
//                //                    ListaEdadTrabajo.Add(IndicadorEdadT);
//                //                }
//                //            }
//                //        }
//                //    }

//                //    ListaEdadTrabajo.ToList().ForEach(t =>
//                //    {
//                //        var row = dt.NewRow();
//                //        row["nbCategoria"] = t.nbCampo;
//                //        row["nbCategoria2"] = t.nbCampo2;
//                //        row["numDatos"] = t.numCampo;
//                //        dt.Rows.Add(row);
//                //    });

//                //    #endregion
//                //}
//                //else if (listacaCampos[0] == 14 && listacaCampos[1] == 6)
//                //{
//                //    #region

//                //    TituloColumna1 = "Fallecimiento";
//                //    TituloColumna2 = "Género";
//                //    TituloColumna3 = "Cantidad";
//                //    TituloGrafic = "Gráfica de barras por Fallecimiento y Género";

//                //    var CatGeneros = db.CatGeneros.ToList();
//                //    List<IndicadoresVM> IndicadoresGFallecido = new List<IndicadoresVM>();

//                //    if (Book.idGenero != null && Book.fgFallecido != null)
//                //    {
//                //        foreach (var itemA in Alumnos)
//                //        {
//                //            var Genero = db.CatGeneros.Find(Book.idGenero);
//                //            if (itemA.Personas.idGenero == Genero.idGenero && itemA.fgFallecido == Book.fgFallecido)
//                //            {
//                //                IndicadoresVM IndicadorGF = new IndicadoresVM();
//                //                IndicadorGF.nbCampo = (Book.fgFallecido == true) ? "SI" : "NO";
//                //                IndicadorGF.nbCampo2 = Genero.nbGenero.Trim();
//                //                IndicadorGF.numCampo = 1;
//                //                IndicadoresGFallecido.Add(IndicadorGF);
//                //            }
//                //        }
//                //    }
//                //    else if (Book.idGenero == null && Book.fgFallecido != null)
//                //    {
//                //        foreach (var itemG in CatGeneros)
//                //        {
//                //            foreach (var itemA in Alumnos)
//                //            {
//                //                var Genero = db.CatGeneros.Find(itemG.idGenero);
//                //                if (itemA.Personas.idGenero == Genero.idGenero && itemA.fgFallecido == Book.fgFallecido)
//                //                {
//                //                    IndicadoresVM IndicadorGF = new IndicadoresVM();
//                //                    IndicadorGF.nbCampo = (Book.fgFallecido == true) ? "SI" : "NO";
//                //                    IndicadorGF.nbCampo2 = Genero.nbGenero.Trim();
//                //                    IndicadorGF.numCampo = 1;
//                //                    IndicadoresGFallecido.Add(IndicadorGF);
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (Book.idGenero == null && Book.fgFallecido == null)
//                //    {
//                //        foreach (var itemG in CatGeneros)
//                //        {
//                //            foreach (var itemA in Alumnos)
//                //            {
//                //                var Genero = db.CatGeneros.Find(itemG.idGenero);
//                //                if (itemA.Personas.idGenero == Genero.idGenero && itemA.fgFallecido == true)
//                //                {
//                //                    IndicadoresVM IndicadorGF = new IndicadoresVM();
//                //                    IndicadorGF.nbCampo = "SI";
//                //                    IndicadorGF.nbCampo2 = Genero.nbGenero.Trim();
//                //                    IndicadorGF.numCampo = 1;
//                //                    IndicadoresGFallecido.Add(IndicadorGF);
//                //                }
//                //                else if (itemA.Personas.idGenero == Genero.idGenero && itemA.fgFallecido == false)
//                //                {
//                //                    IndicadoresVM IndicadorGFN = new IndicadoresVM();
//                //                    IndicadorGFN.nbCampo = "NO";
//                //                    IndicadorGFN.nbCampo2 = Genero.nbGenero.Trim();
//                //                    IndicadorGFN.numCampo = 1;
//                //                    IndicadoresGFallecido.Add(IndicadorGFN);
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (Book.idGenero != null && Book.fgFallecido == null)
//                //    {
//                //        foreach (var itemA in Alumnos)
//                //        {
//                //            var Genero = db.CatGeneros.Find(Book.idGenero);
//                //            if (itemA.Personas.idGenero == Genero.idGenero && itemA.fgFallecido == true)
//                //            {
//                //                IndicadoresVM IndicadorGF = new IndicadoresVM();
//                //                IndicadorGF.nbCampo = "SI";
//                //                IndicadorGF.nbCampo2 = Genero.nbGenero.Trim();
//                //                IndicadorGF.numCampo = 1;
//                //                IndicadoresGFallecido.Add(IndicadorGF);
//                //            }
//                //            else if (itemA.Personas.idGenero == Genero.idGenero && itemA.fgFallecido == false)
//                //            {
//                //                IndicadoresVM IndicadorGFN = new IndicadoresVM();
//                //                IndicadorGFN.nbCampo = "NO";
//                //                IndicadorGFN.nbCampo2 = Genero.nbGenero.Trim();
//                //                IndicadorGFN.numCampo = 1;
//                //                IndicadoresGFallecido.Add(IndicadorGFN);
//                //            }
//                //        }
//                //    }

//                //    IndicadoresGFallecido.ToList().ForEach(l =>
//                //    {
//                //        var row = dt.NewRow();
//                //        row["nbCategoria"] = l.nbCampo;
//                //        row["nbCategoria2"] = l.nbCampo2;
//                //        row["numDatos"] = l.numCampo;
//                //        dt.Rows.Add(row);
//                //    });

//                //    #endregion
//                //}
//                //else if (listacaCampos[0] == 14 && listacaCampos[1] == 7)
//                //{
//                //    #region

//                //    TituloColumna1 = "Fallecimiento";
//                //    TituloColumna2 = "Licenciatura";
//                //    TituloColumna3 = "Cantidad";
//                //    TituloGrafic = "Gráfica de barras por Fallecimiento y Licenciatura";
//                //    Licenciaturas Licenciatura = new Licenciaturas();
//                //    var Licenciaturas = db.Licenciaturas.ToList();

//                //    List<IndicadoresVM> IndicadoresLicFallecido = new List<IndicadoresVM>();

//                //    if (listaIdsLicenciaturas.Count() > 0 && Book.fgFallecido != null)
//                //    {
//                //        foreach (var itemL in listaIdsLicenciaturas)
//                //        {
//                //            foreach (var item in Alumnos)
//                //            {
//                //                var idLicenciatura = Convert.ToInt64(itemL);
//                //                Licenciatura = Licenciaturas.FirstOrDefault(x => x.idLicenciatura == idLicenciatura);
//                //                var FormacionesA = db.FormacionesAcademicas.Where(x => x.idAlumno == item.idAlumno && x.idLicenciatura == Licenciatura.idLicenciatura).ToList();
//                //                if (item.fgFallecido == Book.fgFallecido && FormacionesA.Count() > 0)
//                //                {
//                //                    IndicadoresVM IndicadorLF = new IndicadoresVM();
//                //                    IndicadorLF.nbCampo = (Book.fgFallecido == true) ? "SI" : "NO";
//                //                    IndicadorLF.nbCampo2 = Licenciatura.nbLicenciatura;
//                //                    IndicadorLF.numCampo = 1;
//                //                    IndicadoresLicFallecido.Add(IndicadorLF);
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (listaIdsLicenciaturas.Count() > 0 && Book.fgFallecido == null)
//                //    {
//                //        foreach (var itemL in listaIdsLicenciaturas)
//                //        {
//                //            foreach (var item in Alumnos)
//                //            {
//                //                var idLicenciatura = Convert.ToInt64(itemL);
//                //                Licenciatura = Licenciaturas.FirstOrDefault(x => x.idLicenciatura == idLicenciatura);
//                //                var FormacionesA = db.FormacionesAcademicas.Where(x => x.idAlumno == item.idAlumno && x.idLicenciatura == Licenciatura.idLicenciatura).ToList();
//                //                if (item.fgFallecido == true && FormacionesA.Count() > 0)
//                //                {
//                //                    IndicadoresVM IndicadorLF = new IndicadoresVM();
//                //                    IndicadorLF.nbCampo = "SI";
//                //                    IndicadorLF.nbCampo2 = Licenciatura.nbLicenciatura;
//                //                    IndicadorLF.numCampo = 1;
//                //                    IndicadoresLicFallecido.Add(IndicadorLF);
//                //                }
//                //                else if (item.fgFallecido == false && FormacionesA.Count() > 0)
//                //                {
//                //                    IndicadoresVM IndicadorLNF = new IndicadoresVM();
//                //                    IndicadorLNF.nbCampo = "NO";
//                //                    IndicadorLNF.nbCampo2 = Licenciatura.nbLicenciatura;
//                //                    IndicadorLNF.numCampo = 1;
//                //                    IndicadoresLicFallecido.Add(IndicadorLNF);
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (listaIdsLicenciaturas.Count() == 0 && Book.fgFallecido != null)
//                //    {
//                //        foreach (var itemL in Licenciaturas)
//                //        {
//                //            foreach (var item in Alumnos)
//                //            {
//                //                //var idLicenciatura = Convert.ToInt64(itemL);
//                //                Licenciatura = Licenciaturas.FirstOrDefault(x => x.idLicenciatura == itemL.idLicenciatura);
//                //                var FormacionesA = db.FormacionesAcademicas.Where(x => x.idAlumno == item.idAlumno && x.idLicenciatura == Licenciatura.idLicenciatura).ToList();
//                //                if (item.fgFallecido == Book.fgFallecido && FormacionesA.Count() > 0)
//                //                {
//                //                    IndicadoresVM IndicadorLF = new IndicadoresVM();
//                //                    IndicadorLF.nbCampo = (Book.fgFallecido == true) ? "SI" : "NO";
//                //                    IndicadorLF.nbCampo2 = Licenciatura.nbLicenciatura;
//                //                    IndicadorLF.numCampo = 1;
//                //                    IndicadoresLicFallecido.Add(IndicadorLF);
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (listaIdsLicenciaturas.Count() == 0 && Book.fgFallecido == null)
//                //    {
//                //        foreach (var itemL in Licenciaturas)
//                //        {
//                //            foreach (var item in Alumnos)
//                //            {
//                //                //var idLicenciatura = Convert.ToInt64(itemL);
//                //                Licenciatura = Licenciaturas.FirstOrDefault(x => x.idLicenciatura == itemL.idLicenciatura);
//                //                var FormacionesA = db.FormacionesAcademicas.Where(x => x.idAlumno == item.idAlumno && x.idLicenciatura == Licenciatura.idLicenciatura).ToList();
//                //                if (item.fgFallecido == true && FormacionesA.Count() > 0)
//                //                {
//                //                    IndicadoresVM IndicadorLF = new IndicadoresVM();
//                //                    IndicadorLF.nbCampo = "SI";
//                //                    IndicadorLF.nbCampo2 = Licenciatura.nbLicenciatura;
//                //                    IndicadorLF.numCampo = 1;
//                //                    IndicadoresLicFallecido.Add(IndicadorLF);
//                //                }
//                //                else if (item.fgFallecido == false && FormacionesA.Count() > 0)
//                //                {
//                //                    IndicadoresVM IndicadorLNF = new IndicadoresVM();
//                //                    IndicadorLNF.nbCampo = "NO";
//                //                    IndicadorLNF.nbCampo2 = Licenciatura.nbLicenciatura;
//                //                    IndicadorLNF.numCampo = 1;
//                //                    IndicadoresLicFallecido.Add(IndicadorLNF);
//                //                }
//                //            }
//                //        }
//                //    }

//                //    IndicadoresLicFallecido.ToList().ForEach(l =>
//                //    {
//                //        var row = dt.NewRow();
//                //        row["nbCategoria"] = l.nbCampo;
//                //        row["nbCategoria2"] = l.nbCampo2;
//                //        row["numDatos"] = l.numCampo;
//                //        dt.Rows.Add(row);
//                //    });

//                //    #endregion
//                //}
//                //else if (listacaCampos[0] == 14 && listacaCampos[1] == 8)
//                //{
//                //    #region

//                //    TituloColumna1 = "Fallecimiento";
//                //    TituloColumna2 = "Religión";
//                //    TituloColumna3 = "Cantidad";
//                //    TituloGrafic = "Gráfica de barras por Fallecimiento y Religión";

//                //    CatReligion Religion = new CatReligion();
//                //    var Religiones = db.CatReligion.ToList();

//                //    List<IndicadoresVM> IndicadoresRelLicencia = new List<IndicadoresVM>();

//                //    if (listaIdsReligiones.Count() > 0 && Book.fgFallecido != null)
//                //    {
//                //        foreach (var itemR in listaIdsReligiones)
//                //        {
//                //            foreach (var itemA in Alumnos)
//                //            {
//                //                var idReligion = Convert.ToInt64(itemR);
//                //                Religion = Religiones.FirstOrDefault(x => x.idReligion == idReligion);
//                //                if (itemA.fgFallecido == Book.fgFallecido && itemA.idReligion == Religion.idReligion)
//                //                {
//                //                    IndicadoresVM IndicadorRL = new IndicadoresVM();
//                //                    IndicadorRL.nbCampo = (Book.fgFallecido == true) ? "SI" : "NO";
//                //                    IndicadorRL.nbCampo2 = Religion.nbReligion;
//                //                    IndicadorRL.numCampo = 1;
//                //                    IndicadoresRelLicencia.Add(IndicadorRL);
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (listaIdsReligiones.Count() > 0 && Book.fgFallecido == null)
//                //    {
//                //        foreach (var itemR in listaIdsReligiones)
//                //        {
//                //            foreach (var itemA in Alumnos)
//                //            {
//                //                var idReligion = Convert.ToInt64(itemR);
//                //                Religion = Religiones.FirstOrDefault(x => x.idReligion == idReligion);
//                //                if (itemA.fgFallecido == true && itemA.idReligion == Religion.idReligion)
//                //                {
//                //                    IndicadoresVM IndicadorRL = new IndicadoresVM();
//                //                    IndicadorRL.nbCampo = "SI";
//                //                    IndicadorRL.nbCampo2 = Religion.nbReligion;
//                //                    IndicadorRL.numCampo = 1;
//                //                    IndicadoresRelLicencia.Add(IndicadorRL);
//                //                }
//                //                else if (itemA.fgFallecido == false && itemA.idReligion == Religion.idReligion)
//                //                {
//                //                    IndicadoresVM IndicadorRNL = new IndicadoresVM();
//                //                    IndicadorRNL.nbCampo = "NO";
//                //                    IndicadorRNL.nbCampo2 = Religion.nbReligion;
//                //                    IndicadorRNL.numCampo = 1;
//                //                    IndicadoresRelLicencia.Add(IndicadorRNL);
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (listaIdsReligiones.Count() == 0 && Book.fgFallecido != null)
//                //    {
//                //        foreach (var itemR in Religiones)
//                //        {
//                //            foreach (var itemA in Alumnos)
//                //            {
//                //                //var idReligion = Convert.ToInt64(itemR);
//                //                Religion = Religiones.FirstOrDefault(x => x.idReligion == itemR.idReligion);
//                //                if (itemA.fgFallecido == Book.fgFallecido && itemA.idReligion == Religion.idReligion)
//                //                {
//                //                    IndicadoresVM IndicadorRL = new IndicadoresVM();
//                //                    IndicadorRL.nbCampo = (Book.fgFallecido == true) ? "SI" : "NO";
//                //                    IndicadorRL.nbCampo2 = Religion.nbReligion;
//                //                    IndicadorRL.numCampo = 1;
//                //                    IndicadoresRelLicencia.Add(IndicadorRL);
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (listaIdsReligiones.Count() == 0 && Book.fgFallecido == null)
//                //    {
//                //        foreach (var itemR in Religiones)
//                //        {
//                //            foreach (var itemA in Alumnos)
//                //            {
//                //                //var idReligion = Convert.ToInt64(itemR);
//                //                Religion = Religiones.FirstOrDefault(x => x.idReligion == itemR.idReligion);
//                //                if (itemA.fgFallecido == true && itemA.idReligion == Religion.idReligion)
//                //                {
//                //                    IndicadoresVM IndicadorRL = new IndicadoresVM();
//                //                    IndicadorRL.nbCampo = "SI";
//                //                    IndicadorRL.nbCampo2 = Religion.nbReligion;
//                //                    IndicadorRL.numCampo = 1;
//                //                    IndicadoresRelLicencia.Add(IndicadorRL);
//                //                }
//                //                else if (itemA.fgFallecido == false && itemA.idReligion == Religion.idReligion)
//                //                {
//                //                    IndicadoresVM IndicadorRNL = new IndicadoresVM();
//                //                    IndicadorRNL.nbCampo = "NO";
//                //                    IndicadorRNL.nbCampo2 = Religion.nbReligion;
//                //                    IndicadorRNL.numCampo = 1;
//                //                    IndicadoresRelLicencia.Add(IndicadorRNL);
//                //                }
//                //            }
//                //        }
//                //    }

//                //    IndicadoresRelLicencia.ToList().ForEach(l =>
//                //    {
//                //        var row = dt.NewRow();
//                //        row["nbCategoria"] = l.nbCampo;
//                //        row["nbCategoria2"] = l.nbCampo2;
//                //        row["numDatos"] = l.numCampo;
//                //        dt.Rows.Add(row);
//                //    });

//                //    #endregion
//                //}
//                //else if (listacaCampos[0] == 14 && listacaCampos[1] == 9)
//                //{
//                //    #region

//                //    TituloColumna1 = "Fallecimiento";
//                //    TituloColumna2 = "Estado";
//                //    TituloColumna3 = "Cantidad";
//                //    TituloGrafic = "Gráfica de barras por Fallecimiento y Estado";

//                //    CatEstados Estado = new CatEstados();
//                //    var Estados = db.CatEstados.ToList();

//                //    List<IndicadoresVM> IndicadoresEdosFallecido = new List<IndicadoresVM>();

//                //    if (listaIdsestados.Count() > 0 && Book.fgFallecido != null)
//                //    {
//                //        foreach (var itemE in listaIdsestados)
//                //        {
//                //            foreach (var itemA in Alumnos)
//                //            {
//                //                var idEstado = Convert.ToInt64(itemE);
//                //                Estado = Estados.FirstOrDefault(x => x.idEstado == idEstado);
//                //                if (itemA.fgFallecido == Book.fgFallecido && itemA.Direcciones.nbEstado.Trim().ToUpper() == Estado.nbEstado.Trim().ToUpper())
//                //                {
//                //                    IndicadoresVM IndicadorRT = new IndicadoresVM();
//                //                    IndicadorRT.nbCampo = (Book.fgFallecido == true) ? "SI" : "NO";
//                //                    IndicadorRT.nbCampo2 = Estado.nbEstado;
//                //                    IndicadorRT.numCampo = 1;
//                //                    IndicadoresEdosFallecido.Add(IndicadorRT);
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (listaIdsestados.Count() > 0 && Book.fgFallecido == null)
//                //    {
//                //        foreach (var itemE in listaIdsestados)
//                //        {
//                //            foreach (var itemA in Alumnos)
//                //            {
//                //                var idEstado = Convert.ToInt64(itemE);
//                //                Estado = Estados.FirstOrDefault(x => x.idEstado == idEstado);
//                //                if (itemA.fgFallecido == true && itemA.Direcciones.nbEstado.Trim().ToUpper() == Estado.nbEstado.Trim().ToUpper())
//                //                {
//                //                    IndicadoresVM IndicadorRT = new IndicadoresVM();
//                //                    IndicadorRT.nbCampo = "SI";
//                //                    IndicadorRT.nbCampo2 = Estado.nbEstado;
//                //                    IndicadorRT.numCampo = 1;
//                //                    IndicadoresEdosFallecido.Add(IndicadorRT);
//                //                }
//                //                else if (itemA.fgFallecido == false && itemA.Direcciones.nbEstado.Trim().ToUpper() == Estado.nbEstado.Trim().ToUpper())
//                //                {
//                //                    IndicadoresVM IndicadorRNT = new IndicadoresVM();
//                //                    IndicadorRNT.nbCampo = "NO";
//                //                    IndicadorRNT.nbCampo2 = Estado.nbEstado;
//                //                    IndicadorRNT.numCampo = 1;
//                //                    IndicadoresEdosFallecido.Add(IndicadorRNT);
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (listaIdsestados.Count() == 0 && Book.fgFallecido != null)
//                //    {
//                //        foreach (var itemE in Estados)
//                //        {
//                //            foreach (var itemA in Alumnos)
//                //            {
//                //                //var idEstado = Convert.ToInt64(itemE);
//                //                Estado = Estados.FirstOrDefault(x => x.idEstado == itemE.idEstado);
//                //                if (itemA.fgFallecido == Book.fgFallecido && itemA.Direcciones.nbEstado.Trim().ToUpper() == Estado.nbEstado.Trim().ToUpper())
//                //                {
//                //                    IndicadoresVM IndicadorRT = new IndicadoresVM();
//                //                    IndicadorRT.nbCampo = (Book.fgFallecido == true) ? "SI" : "NO";
//                //                    IndicadorRT.nbCampo2 = Estado.nbEstado;
//                //                    IndicadorRT.numCampo = 1;
//                //                    IndicadoresEdosFallecido.Add(IndicadorRT);
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (listaIdsestados.Count() == 0 && Book.fgFallecido == null)
//                //    {
//                //        foreach (var itemE in Estados)
//                //        {
//                //            foreach (var itemA in Alumnos)
//                //            {
//                //                //var idEstado = Convert.ToInt64(itemE);
//                //                Estado = Estados.FirstOrDefault(x => x.idEstado == itemE.idEstado);
//                //                if (itemA.fgFallecido == true && itemA.Direcciones.nbEstado.Trim().ToUpper() == Estado.nbEstado.Trim().ToUpper())
//                //                {
//                //                    IndicadoresVM IndicadorRT = new IndicadoresVM();
//                //                    IndicadorRT.nbCampo = "SI";
//                //                    IndicadorRT.nbCampo2 = Estado.nbEstado;
//                //                    IndicadorRT.numCampo = 1;
//                //                    IndicadoresEdosFallecido.Add(IndicadorRT);
//                //                }
//                //                else if (itemA.fgFallecido == false && itemA.Direcciones.nbEstado.Trim().ToUpper() == Estado.nbEstado.Trim().ToUpper())
//                //                {
//                //                    IndicadoresVM IndicadorRNT = new IndicadoresVM();
//                //                    IndicadorRNT.nbCampo = "NO";
//                //                    IndicadorRNT.nbCampo2 = Estado.nbEstado;
//                //                    IndicadorRNT.numCampo = 1;
//                //                    IndicadoresEdosFallecido.Add(IndicadorRNT);
//                //                }
//                //            }
//                //        }
//                //    }

//                //    IndicadoresEdosFallecido.ToList().ForEach(l =>
//                //    {
//                //        var row = dt.NewRow();
//                //        row["nbCategoria"] = l.nbCampo;
//                //        row["nbCategoria2"] = l.nbCampo2;
//                //        row["numDatos"] = l.numCampo;
//                //        dt.Rows.Add(row);
//                //    });

//                //    #endregion
//                //}
//                //else if (listacaCampos[0] == 14 && listacaCampos[1] == 10)
//                //{
//                //    #region

//                //    TituloColumna1 = "Fallecimiento";
//                //    TituloColumna2 = "Trabajo";
//                //    TituloColumna3 = "Cantidad";
//                //    TituloGrafic = "Gráfica de barras por Fallecimiento y Trabajo";
//                //    List<IndicadoresVM> IndicadoresTF = new List<IndicadoresVM>();
//                //    if (Book.fgFallecido != null && Book.fgTrabajaActualmente != null)
//                //    {
//                //        foreach (var itemA in Alumnos)
//                //        {
//                //            if (itemA.fgTrabajaActualmente == Book.fgTrabajaActualmente && itemA.fgFallecido == Book.fgFallecido)
//                //            {
//                //                IndicadoresVM IndicadorTL = new IndicadoresVM();
//                //                IndicadorTL.nbCampo = (Book.fgFallecido == true) ? "SI" : "NO";
//                //                IndicadorTL.nbCampo2 = (Book.fgTrabajaActualmente == true) ? "SI" : "NO";
//                //                IndicadorTL.numCampo = 1;
//                //                IndicadoresTF.Add(IndicadorTL);
//                //            }
//                //        }
//                //    }
//                //    else if (Book.fgFallecido != null && Book.fgTrabajaActualmente == null)
//                //    {
//                //        foreach (var itemA in Alumnos)
//                //        {
//                //            if (itemA.fgTrabajaActualmente == true && itemA.fgFallecido == Book.fgFallecido)
//                //            {
//                //                IndicadoresVM IndicadorTL = new IndicadoresVM();
//                //                IndicadorTL.nbCampo = (Book.fgFallecido == true) ? "SI" : "NO";
//                //                IndicadorTL.nbCampo2 = "SI";
//                //                IndicadorTL.numCampo = 1;
//                //                IndicadoresTF.Add(IndicadorTL);
//                //            }
//                //            else if (itemA.fgTrabajaActualmente == false && itemA.fgFallecido == Book.fgFallecido)
//                //            {
//                //                IndicadoresVM IndicadorTLN = new IndicadoresVM();
//                //                IndicadorTLN.nbCampo = (Book.fgFallecido == true) ? "SI" : "NO";
//                //                IndicadorTLN.nbCampo2 = "NO";
//                //                IndicadorTLN.numCampo = 1;
//                //                IndicadoresTF.Add(IndicadorTLN);
//                //            }
//                //        }
//                //    }
//                //    else if (Book.fgFallecido == null && Book.fgTrabajaActualmente == null)
//                //    {
//                //        foreach (var itemA in Alumnos)
//                //        {
//                //            if (itemA.fgTrabajaActualmente == true && itemA.fgFallecido == true)
//                //            {
//                //                IndicadoresVM IndicadorTL = new IndicadoresVM();
//                //                IndicadorTL.nbCampo = "SI";
//                //                IndicadorTL.nbCampo2 = "SI";
//                //                IndicadorTL.numCampo = 1;
//                //                IndicadoresTF.Add(IndicadorTL);
//                //            }
//                //            else if (itemA.fgTrabajaActualmente == true && itemA.fgFallecido == false)
//                //            {
//                //                IndicadoresVM IndicadorNTL = new IndicadoresVM();
//                //                IndicadorNTL.nbCampo = "NO";
//                //                IndicadorNTL.nbCampo2 = "SI";
//                //                IndicadorNTL.numCampo = 1;
//                //                IndicadoresTF.Add(IndicadorNTL);
//                //            }
//                //            else if (itemA.fgTrabajaActualmente == false && itemA.fgFallecido == true)
//                //            {
//                //                IndicadoresVM IndicadorTNL = new IndicadoresVM();
//                //                IndicadorTNL.nbCampo = "SI";
//                //                IndicadorTNL.nbCampo2 = "NO";
//                //                IndicadorTNL.numCampo = 1;
//                //                IndicadoresTF.Add(IndicadorTNL);
//                //            }
//                //            else if (itemA.fgTrabajaActualmente == false && itemA.fgFallecido == false)
//                //            {
//                //                IndicadoresVM IndicadorTNL = new IndicadoresVM();
//                //                IndicadorTNL.nbCampo = "NO";
//                //                IndicadorTNL.nbCampo2 = "NO";
//                //                IndicadorTNL.numCampo = 1;
//                //                IndicadoresTF.Add(IndicadorTNL);
//                //            }
//                //        }
//                //    }
//                //    else if (Book.fgFallecido == null && Book.fgTrabajaActualmente != null)
//                //    {
//                //        foreach (var itemA in Alumnos)
//                //        {
//                //            if (itemA.fgTrabajaActualmente == Book.fgTrabajaActualmente && itemA.fgFallecido == true)
//                //            {
//                //                IndicadoresVM IndicadorTNL = new IndicadoresVM();
//                //                IndicadorTNL.nbCampo = "SI";
//                //                IndicadorTNL.nbCampo2 = (Book.fgTrabajaActualmente == true) ? "SI" : "NO";
//                //                IndicadorTNL.numCampo = 1;
//                //                IndicadoresTF.Add(IndicadorTNL);
//                //            }
//                //            else if (itemA.fgTrabajaActualmente == Book.fgTrabajaActualmente && itemA.fgFallecido == false)
//                //            {
//                //                IndicadoresVM IndicadorNTNL = new IndicadoresVM();
//                //                IndicadorNTNL.nbCampo = "NO";
//                //                IndicadorNTNL.nbCampo2 = (Book.fgTrabajaActualmente == true) ? "SI" : "NO";
//                //                IndicadorNTNL.numCampo = 1;
//                //                IndicadoresTF.Add(IndicadorNTNL);
//                //            }
//                //        }
//                //    }

//                //    IndicadoresTF.ToList().ForEach(l =>
//                //    {
//                //        var row = dt.NewRow();
//                //        row["nbCategoria"] = l.nbCampo;
//                //        row["nbCategoria2"] = l.nbCampo2;
//                //        row["numDatos"] = l.numCampo;
//                //        dt.Rows.Add(row);
//                //    });

//                //    #endregion
//                //}
//                //else if (listacaCampos[0] == 14 && listacaCampos[1] == 11)
//                //{
//                //    #region

//                //    TituloColumna1 = "Fallecimiento";
//                //    TituloColumna2 = "Tipo de Sangre";
//                //    TituloColumna3 = "Cantidad";
//                //    TituloGrafic = "Gráfica de barras por Fallecimiento y Tipo de Sangre";
//                //    var CatTiposSangre = db.CatTiposSangre.ToList();
//                //    List<IndicadoresVM> IndicadoresTS = new List<IndicadoresVM>();
//                //    if (Book.idTipoSangre != null && Book.fgFallecido != null)
//                //    {
//                //        foreach (var itemA in Alumnos)
//                //        {
//                //            var TipoSangre = db.CatTiposSangre.Find(Book.idTipoSangre);
//                //            if (itemA.fgFallecido == Book.fgFallecido && itemA.idTipoSangre == TipoSangre.idTipoSangre)
//                //            {
//                //                IndicadoresVM IndicadorTS = new IndicadoresVM();
//                //                IndicadorTS.nbCampo = (Book.fgFallecido == true) ? "SI" : "NO";
//                //                IndicadorTS.nbCampo2 = TipoSangre.nbTipoSangre;
//                //                IndicadorTS.numCampo = 1;
//                //                IndicadoresTS.Add(IndicadorTS);
//                //            }
//                //        }
//                //    }
//                //    else if (Book.idTipoSangre != null && Book.fgFallecido == null)
//                //    {
//                //        foreach (var itemA in Alumnos)
//                //        {
//                //            var TipoSangre = db.CatTiposSangre.Find(Book.idTipoSangre);
//                //            if (itemA.fgFallecido == true && itemA.idTipoSangre == TipoSangre.idTipoSangre)
//                //            {
//                //                IndicadoresVM IndicadorTS = new IndicadoresVM();
//                //                IndicadorTS.nbCampo = "SI";
//                //                IndicadorTS.nbCampo2 = TipoSangre.nbTipoSangre;
//                //                IndicadorTS.numCampo = 1;
//                //                IndicadoresTS.Add(IndicadorTS);
//                //            }
//                //            else if (itemA.fgFallecido == false && itemA.idTipoSangre == TipoSangre.idTipoSangre)
//                //            {
//                //                IndicadoresVM IndicadorTSN = new IndicadoresVM();
//                //                IndicadorTSN.nbCampo = "NO";
//                //                IndicadorTSN.nbCampo2 = TipoSangre.nbTipoSangre;
//                //                IndicadorTSN.numCampo = 1;
//                //                IndicadoresTS.Add(IndicadorTSN);
//                //            }
//                //        }
//                //    }
//                //    else if (Book.idTipoSangre == null && Book.fgFallecido == null)
//                //    {
//                //        foreach (var itemS in CatTiposSangre)
//                //        {
//                //            foreach (var itemA in Alumnos)
//                //            {
//                //                var TipoSangre = db.CatTiposSangre.Find(itemS.idTipoSangre);
//                //                if (itemA.fgFallecido == true && itemA.idTipoSangre == TipoSangre.idTipoSangre)
//                //                {
//                //                    IndicadoresVM IndicadorTS = new IndicadoresVM();
//                //                    IndicadorTS.nbCampo = "SI";
//                //                    IndicadorTS.nbCampo2 = TipoSangre.nbTipoSangre;
//                //                    IndicadorTS.numCampo = 1;
//                //                    IndicadoresTS.Add(IndicadorTS);
//                //                }
//                //                else if (itemA.fgFallecido == false && itemA.idTipoSangre == TipoSangre.idTipoSangre)
//                //                {
//                //                    IndicadoresVM IndicadorTSN = new IndicadoresVM();
//                //                    IndicadorTSN.nbCampo = "NO";
//                //                    IndicadorTSN.nbCampo2 = TipoSangre.nbTipoSangre;
//                //                    IndicadorTSN.numCampo = 1;
//                //                    IndicadoresTS.Add(IndicadorTSN);
//                //                }
//                //            }
//                //        }
//                //    }
//                //    else if (Book.idEstadoCivil == null && Book.fgFallecido != null)
//                //    {
//                //        foreach (var itemS in CatTiposSangre)
//                //        {
//                //            foreach (var itemA in Alumnos)
//                //            {
//                //                var TipoSangre = db.CatTiposSangre.Find(itemS.idTipoSangre);
//                //                if (itemA.fgFallecido == Book.fgFallecido && itemA.idTipoSangre == TipoSangre.idTipoSangre)
//                //                {
//                //                    IndicadoresVM IndicadorTS = new IndicadoresVM();
//                //                    IndicadorTS.nbCampo = (Book.fgFallecido == true) ? "SI" : "NO";
//                //                    IndicadorTS.nbCampo2 = TipoSangre.nbTipoSangre;
//                //                    IndicadorTS.numCampo = 1;
//                //                    IndicadoresTS.Add(IndicadorTS);
//                //                }
//                //            }
//                //        }
//                //    }

//                //    IndicadoresTS.ToList().ForEach(l =>
//                //    {
//                //        var row = dt.NewRow();
//                //        row["nbCategoria"] = l.nbCampo;
//                //        row["nbCategoria2"] = l.nbCampo2;
//                //        row["numDatos"] = l.numCampo;
//                //        dt.Rows.Add(row);
//                //    });

//                //    #endregion
//                //}
//                //else if (listacaCampos[0] == 14 && listacaCampos[1] == 12)
//                //{
//                //    #region

//                //    TituloColumna1 = "Fallecimiento";
//                //    TituloColumna2 = "Licencia";
//                //    TituloColumna3 = "Cantidad";
//                //    TituloGrafic = "Gráfica de barras por Fallecimiento y Licencia";
//                //    List<IndicadoresVM> IndicadoresTL = new List<IndicadoresVM>();
//                //    if (Book.fgLicencia != null && Book.fgFallecido != null)
//                //    {
//                //        foreach (var itemA in Alumnos)
//                //        {
//                //            if (itemA.fgFallecido == Book.fgFallecido && itemA.fgLicencia == Book.fgLicencia)
//                //            {
//                //                IndicadoresVM IndicadorTL = new IndicadoresVM();
//                //                IndicadorTL.nbCampo = (Book.fgFallecido == true) ? "SI" : "NO";
//                //                IndicadorTL.nbCampo2 = (Book.fgLicencia == true) ? "SI" : "NO";
//                //                IndicadorTL.numCampo = 1;
//                //                IndicadoresTL.Add(IndicadorTL);
//                //            }
//                //        }
//                //    }
//                //    else if (Book.fgLicencia != null && Book.fgFallecido == null)
//                //    {
//                //        foreach (var itemA in Alumnos)
//                //        {
//                //            if (itemA.fgFallecido == true && itemA.fgLicencia == Book.fgLicencia)
//                //            {
//                //                IndicadoresVM IndicadorTL = new IndicadoresVM();
//                //                IndicadorTL.nbCampo = (Book.fgFallecido == true) ? "SI" : "NO";
//                //                IndicadorTL.nbCampo2 = "SI";
//                //                IndicadorTL.numCampo = 1;
//                //                IndicadoresTL.Add(IndicadorTL);
//                //            }
//                //            else if (itemA.fgFallecido == false && itemA.fgLicencia == Book.fgLicencia)
//                //            {
//                //                IndicadoresVM IndicadorTLN = new IndicadoresVM();
//                //                IndicadorTLN.nbCampo = (Book.fgFallecido == true) ? "SI" : "NO";
//                //                IndicadorTLN.nbCampo2 = "NO";
//                //                IndicadorTLN.numCampo = 1;
//                //                IndicadoresTL.Add(IndicadorTLN);
//                //            }
//                //        }
//                //    }
//                //    else if (Book.fgLicencia == null && Book.fgFallecido == null)
//                //    {
//                //        foreach (var itemA in Alumnos)
//                //        {
//                //            if (itemA.fgFallecido == true && itemA.fgLicencia == true)
//                //            {
//                //                IndicadoresVM IndicadorTL = new IndicadoresVM();
//                //                IndicadorTL.nbCampo = "SI";
//                //                IndicadorTL.nbCampo2 = "SI";
//                //                IndicadorTL.numCampo = 1;
//                //                IndicadoresTL.Add(IndicadorTL);
//                //            }
//                //            else if (itemA.fgFallecido == false && itemA.fgLicencia == true)
//                //            {
//                //                IndicadoresVM IndicadorNTL = new IndicadoresVM();
//                //                IndicadorNTL.nbCampo = "NO";
//                //                IndicadorNTL.nbCampo2 = "SI";
//                //                IndicadorNTL.numCampo = 1;
//                //                IndicadoresTL.Add(IndicadorNTL);
//                //            }
//                //            else if (itemA.fgFallecido == true && itemA.fgLicencia == false)
//                //            {
//                //                IndicadoresVM IndicadorTNL = new IndicadoresVM();
//                //                IndicadorTNL.nbCampo = "SI";
//                //                IndicadorTNL.nbCampo2 = "NO";
//                //                IndicadorTNL.numCampo = 1;
//                //                IndicadoresTL.Add(IndicadorTNL);
//                //            }
//                //            else if (itemA.fgFallecido == false && itemA.fgLicencia == false)
//                //            {
//                //                IndicadoresVM IndicadorNTNL = new IndicadoresVM();
//                //                IndicadorNTNL.nbCampo = "NO";
//                //                IndicadorNTNL.nbCampo2 = "NO";
//                //                IndicadorNTNL.numCampo = 1;
//                //                IndicadoresTL.Add(IndicadorNTNL);
//                //            }
//                //        }
//                //    }
//                //    else if (Book.fgLicencia == null && Book.fgFallecido != null)
//                //    {
//                //        foreach (var itemA in Alumnos)
//                //        {
//                //            if (itemA.fgFallecido == Book.fgFallecido && itemA.fgLicencia == true)
//                //            {
//                //                IndicadoresVM IndicadorTNL = new IndicadoresVM();
//                //                IndicadorTNL.nbCampo = (Book.fgFallecido == true) ? "SI" : "NO";
//                //                IndicadorTNL.nbCampo2 = "SI";
//                //                IndicadorTNL.numCampo = 1;
//                //                IndicadoresTL.Add(IndicadorTNL);
//                //            }
//                //            else if (itemA.fgFallecido == Book.fgFallecido && itemA.fgLicencia == false)
//                //            {
//                //                IndicadoresVM IndicadorNTNL = new IndicadoresVM();
//                //                IndicadorNTNL.nbCampo = (Book.fgFallecido == true) ? "SI" : "NO";
//                //                IndicadorNTNL.nbCampo2 = "NO";
//                //                IndicadorNTNL.numCampo = 1;
//                //                IndicadoresTL.Add(IndicadorNTNL);
//                //            }
//                //        }
//                //    }

//                //    IndicadoresTL.ToList().ForEach(l =>
//                //    {
//                //        var row = dt.NewRow();
//                //        row["nbCategoria"] = l.nbCampo;
//                //        row["nbCategoria2"] = l.nbCampo2;
//                //        row["numDatos"] = l.numCampo;
//                //        dt.Rows.Add(row);
//                //    });

//                //    #endregion
//                //}
//                //else if (listacaCampos[0] == 14 && listacaCampos[1] == 13)
//                //{
//                //    #region

//                //    TituloColumna1 = "Fallecimiento";
//                //    TituloColumna2 = "Tipo de Egresado";
//                //    TituloColumna3 = "Cantidad";
//                //    TituloGrafic = "Gráfica de barras por Fallecimiento y Tipo de Egresado";
//                //    List<IndicadoresVM> IndicadoresTL = new List<IndicadoresVM>();
//                //    if (Book.tpEgresado != null && Book.fgFallecido != null)
//                //    {
//                //        foreach (var itemA in Alumnos)
//                //        {
//                //            if (itemA.fgFallecido == Book.fgFallecido && itemA.tpEgresado == Book.tpEgresado)
//                //            {
//                //                IndicadoresVM IndicadorTL = new IndicadoresVM();
//                //                IndicadorTL.nbCampo = (Book.fgFallecido == true) ? "SI" : "NO";
//                //                IndicadorTL.nbCampo2 = (Book.tpEgresado == "T") ? "Titulado" : "Pasante";
//                //                IndicadorTL.numCampo = 1;
//                //                IndicadoresTL.Add(IndicadorTL);
//                //            }
//                //        }
//                //    }
//                //    else if (Book.tpEgresado != null && Book.fgFallecido == null)
//                //    {
//                //        foreach (var itemA in Alumnos)
//                //        {
//                //            if (itemA.fgFallecido == true && itemA.tpEgresado == Book.tpEgresado)
//                //            {
//                //                IndicadoresVM IndicadorTL = new IndicadoresVM();
//                //                IndicadorTL.nbCampo = "SI";
//                //                IndicadorTL.nbCampo2 = (Book.tpEgresado == "T") ? "Titulado" : "Pasante";
//                //                IndicadorTL.numCampo = 1;
//                //                IndicadoresTL.Add(IndicadorTL);
//                //            }
//                //            else if (itemA.fgFallecido == false && itemA.tpEgresado == Book.tpEgresado)
//                //            {
//                //                IndicadoresVM IndicadorTLN = new IndicadoresVM();
//                //                IndicadorTLN.nbCampo = "NO";
//                //                IndicadorTLN.nbCampo2 = (Book.tpEgresado == "T") ? "Titulado" : "Pasante";
//                //                IndicadorTLN.numCampo = 1;
//                //                IndicadoresTL.Add(IndicadorTLN);
//                //            }
//                //        }
//                //    }
//                //    else if (Book.tpEgresado == null && Book.fgFallecido == null)
//                //    {
//                //        foreach (var itemA in Alumnos)
//                //        {
//                //            if (itemA.fgFallecido == true && itemA.tpEgresado == "T")
//                //            {
//                //                IndicadoresVM IndicadorTL = new IndicadoresVM();
//                //                IndicadorTL.nbCampo = "SI";
//                //                IndicadorTL.nbCampo2 = "Titulado";
//                //                IndicadorTL.numCampo = 1;
//                //                IndicadoresTL.Add(IndicadorTL);
//                //            }
//                //            else if (itemA.fgFallecido == false && itemA.tpEgresado == "T")
//                //            {
//                //                IndicadoresVM IndicadorNTL = new IndicadoresVM();
//                //                IndicadorNTL.nbCampo = "NO";
//                //                IndicadorNTL.nbCampo2 = "Titulado";
//                //                IndicadorNTL.numCampo = 1;
//                //                IndicadoresTL.Add(IndicadorNTL);
//                //            }
//                //            else if (itemA.fgFallecido == true && itemA.tpEgresado == "P")
//                //            {
//                //                IndicadoresVM IndicadorTNL = new IndicadoresVM();
//                //                IndicadorTNL.nbCampo = "SI";
//                //                IndicadorTNL.nbCampo2 = "Pasante";
//                //                IndicadorTNL.numCampo = 1;
//                //                IndicadoresTL.Add(IndicadorTNL);
//                //            }
//                //            else if (itemA.fgFallecido == false && itemA.tpEgresado == "P")
//                //            {
//                //                IndicadoresVM IndicadorNTNL = new IndicadoresVM();
//                //                IndicadorNTNL.nbCampo = "NO";
//                //                IndicadorNTNL.nbCampo2 = "Pasante";
//                //                IndicadorNTNL.numCampo = 1;
//                //                IndicadoresTL.Add(IndicadorNTNL);
//                //            }
//                //        }
//                //    }
//                //    else if (Book.tpEgresado == null && Book.fgFallecido != null)
//                //    {
//                //        foreach (var itemA in Alumnos)
//                //        {
//                //            if (itemA.fgFallecido == Book.fgFallecido && itemA.tpEgresado == "T")
//                //            {
//                //                IndicadoresVM IndicadorTNL = new IndicadoresVM();
//                //                IndicadorTNL.nbCampo = (Book.fgFallecido == true) ? "SI" : "NO";
//                //                IndicadorTNL.nbCampo2 = "Titulado";
//                //                IndicadorTNL.numCampo = 1;
//                //                IndicadoresTL.Add(IndicadorTNL);
//                //            }
//                //            else if (itemA.fgFallecido == Book.fgFallecido && itemA.tpEgresado == "P")
//                //            {
//                //                IndicadoresVM IndicadorNTNL = new IndicadoresVM();
//                //                IndicadorNTNL.nbCampo = (Book.fgFallecido == true) ? "SI" : "NO";
//                //                IndicadorNTNL.nbCampo2 = "Pasante";
//                //                IndicadorNTNL.numCampo = 1;
//                //                IndicadoresTL.Add(IndicadorNTNL);
//                //            }
//                //        }
//                //    }

//                //    IndicadoresTL.ToList().ForEach(l =>
//                //    {
//                //        var row = dt.NewRow();
//                //        row["nbCategoria"] = l.nbCampo;
//                //        row["nbCategoria2"] = l.nbCampo2;
//                //        row["numDatos"] = l.numCampo;
//                //        dt.Rows.Add(row);
//                //    });

//                //    #endregion
//                //}

//            string path = string.Empty;
//            LocalReport localReport = new LocalReport();
//            path = Path.Combine(Server.MapPath("~/Reportes/"), "IndicadoresGraficaBarras.rdlc");
//            localReport.ReportPath = path;
//            ReportDataSource reporte = new ReportDataSource("GraficaBarras", dt);
//            localReport.DataSources.Add(reporte);
//            ReportDataSource reporte1 = new ReportDataSource("Reportes", dt1);
//            localReport.DataSources.Add(reporte1);

//            if (tpGrafica == 1)
//            {
//                ReportParameter Total = new ReportParameter("Total", TotalDatos.ToString());
//                ReportParameter Porcentaje = new ReportParameter("Porcentaje", "1");
//                localReport.SetParameters(Total);
//                localReport.SetParameters(Porcentaje);
//            }

//            ReportParameter TituloGrafica = new ReportParameter("TituloGrafica", TituloGrafic);
//            ReportParameter Titulo1 = new ReportParameter("Titulo1", TituloColumna1);
//            ReportParameter Titulo2 = new ReportParameter("Titulo2", TituloColumna2);
//            if (tpGrafica == 2 || tpGrafica == 3)
//            {
//                ReportParameter Titulo3 = new ReportParameter("Titulo3", TituloColumna3);
//                ReportParameter Titulo4 = new ReportParameter("Titulo4", TituloColumna4);
//                ////Parametros a enviar en el reporte
//                localReport.SetParameters(Titulo3);
//                localReport.SetParameters(Titulo4);
//            }

//            ////Parametros a enviar en el reporte

//            localReport.SetParameters(Titulo1);
//            localReport.SetParameters(Titulo2);
//            localReport.SetParameters(TituloGrafica);

//            string reportType = "EXCELOPENXML";
//            string mimeType;
//            string encoding;
//            string fileNameExtension;
//            Warning[] warnings;
//            string[] streams;
//            byte[] renderedBytes;
//            string fileName = "";

//            renderedBytes = localReport.Render(reportType, "", out mimeType, out encoding, out fileNameExtension, out streams, out warnings);
//            fileName = "Indicadores.xlsx";

//            return File(renderedBytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", fileName);
//        }
//        public ActionResult GenerarReporte(cat_indicadores Book, string idsLicenciaturas, string idsReligiones, string idsEstados, string Campos)
//        {
//            if (!User.Identity.IsAuthenticated)
//            {
//                return RedirectToAction("Index", "AccesoView");
//            }
//            var licenciaturas = new JavaScriptSerializer();
//            var listaIdsLicenciaturas = licenciaturas.Deserialize<List<object>>(idsLicenciaturas);
//            var religiones = new JavaScriptSerializer();
//            var listaIdsReligiones = religiones.Deserialize<List<object>>(idsReligiones);
//            var estados = new JavaScriptSerializer();
//            var listaIdsestados = estados.Deserialize<List<object>>(idsEstados);
//            var campos = new JavaScriptSerializer();
//            var listacaCampos = campos.Deserialize<List<int>>(Campos);
//            listacaCampos.Add(16);

//            List<Alumnos> Alumnos = db.Alumnos.ToList();
//            List<Alumnos> AlumnosEdad = new List<Alumnos>();
//            List<Alumnos> AlumnosCumple = new List<Alumnos>();
//            var TituloColumna1 = string.Empty;
//            var TituloColumna2 = string.Empty;
//            var TituloColumna3 = string.Empty;
//            var TituloColumna4 = string.Empty;
//            var TituloColumna5 = string.Empty;
//            var TituloColumna6 = string.Empty;
//            var TituloColumna7 = string.Empty;
//            var TituloColumna8 = string.Empty;
//            var TituloColumna9 = string.Empty;
//            var TituloColumna10 = string.Empty;
//            var TituloColumna11 = string.Empty;
//            var TituloColumna12 = string.Empty;
//            var TituloColumna13 = string.Empty;
//            var TituloColumna14 = string.Empty;
//            var TituloColumna15 = string.Empty;
//            var TituloColumna16 = string.Empty;

//            if (Book.feInicio != null && Book.feFinal != null)
//            {
//                foreach (var itemA in Alumnos)
//                {
//                    if (itemA.feNacimiento != null)
//                    {
//                        var fechaInicial = Book.feInicio.Split('/');
//                        var fechaFinal = Book.feFinal.Split('/');
//                        var feInicio = Convert.ToInt32("2017" + fechaInicial[1] + fechaInicial[0]);
//                        var feFinal = Convert.ToInt32("2017" + fechaFinal[1] + fechaFinal[0]);
//                        var fecha = itemA.feNacimiento.ToString().Split('/');
//                        var feNacimiento = Convert.ToInt32("2017" + fecha[1] + fecha[0]);

//                        if (feNacimiento >= feInicio && feNacimiento <= feFinal)
//                        {
//                            AlumnosCumple.Add(itemA);
//                        }

//                    }
//                }
//                Alumnos = new List<Alumnos>();
//                Alumnos = AlumnosCumple;
//            }

//            if (listaIdsLicenciaturas.Count() > 0)
//            {
//                foreach (var item in listaIdsLicenciaturas)
//                {
//                    var idLicenciatura = Convert.ToInt64(item);
//                    Alumnos = Alumnos.Where(x => x.FormacionesAcademicas.FirstOrDefault().idLicenciatura == idLicenciatura).ToList();
//                }

//            }

//            if (listaIdsReligiones.Count() > 0)
//            {
//                foreach (var item in listaIdsReligiones)
//                {
//                    var idReligion = Convert.ToInt64(item);
//                    Alumnos = Alumnos.Where(x => x.idReligion == idReligion).ToList();
//                }

//            }


//            if (listaIdsestados.Count() > 0)
//            {
//                List<CatEstados> ListaEstados = db.CatEstados.ToList();
//                foreach (var item in listaIdsestados)
//                {
//                    var idEstado = Convert.ToInt64(item);
//                    ListaEstados = ListaEstados.Where(x => x.idEstado == idEstado).ToList();
//                }

//                foreach (var item in ListaEstados)
//                {
//                    Alumnos = Alumnos.Where(x => x.Direcciones.nbEstado == item.nbEstado).ToList();
//                }

//            }

//            if (Book.fgTrabajaActualmente != null)
//            {
//                Alumnos = Alumnos.Where(x => x.fgTrabajaActualmente == Book.fgTrabajaActualmente).ToList();
//            }
//            if (Book.fgDonarSangre != null)
//            {
//                Alumnos = Alumnos.Where(x => x.fgDonarSangre == Book.fgDonarSangre).ToList();
//            }
//            if (Book.fgFallecido != null)
//            {
//                Alumnos = Alumnos.Where(x => x.fgFallecido == Book.fgFallecido).ToList();
//            }
//            if (Book.fgLicencia != null)
//            {
//                Alumnos = Alumnos.Where(x => x.fgLicencia == Book.fgLicencia).ToList();
//            }
//            if (Book.tpEgresado != null)
//            {
//                Alumnos = Alumnos.Where(x => x.tpEgresado == Book.tpEgresado).ToList();
//            }

//            if (Book.idEstadoCivil != null)
//            {
//                Alumnos = Alumnos.Where(x => x.idEstadoCivil == Book.idEstadoCivil).ToList();
//            }

//            if (Book.idGenero != null)
//            {
//                Alumnos = Alumnos.Where(x => x.Personas.idGenero == Book.idGenero).ToList();
//            }
//            if (Book.idTipoSangre != null)
//            {
//                Alumnos = Alumnos.Where(x => x.idTipoSangre == Book.idTipoSangre).ToList();
//            }
//            if (Book.numEdadMinima != null && Book.numEdadMaxima != null)
//            {
//                foreach (var item in Alumnos)
//                {
//                    var edad = DateTime.Now.Year - ((DateTime)item.feNacimiento).Date.Year;
//                    if (edad >= Book.numEdadMinima && edad <= Book.numEdadMaxima)
//                    {
//                        AlumnosEdad.Add(item);
//                    }
//                }
//                Alumnos = new List<Models.Alumnos>();
//                Alumnos = AlumnosEdad;
//            }
//            DataTable dt = new DataTable();
//            dt.Columns.Add("Valor1", typeof(string));
//            dt.Columns.Add("Valor2", typeof(string));
//            dt.Columns.Add("Valor3", typeof(string));
//            dt.Columns.Add("Valor4", typeof(string));
//            dt.Columns.Add("Valor5", typeof(string));
//            dt.Columns.Add("Valor6", typeof(string));
//            dt.Columns.Add("Valor7", typeof(string));
//            dt.Columns.Add("Valor8", typeof(string));
//            dt.Columns.Add("Valor9", typeof(string));
//            dt.Columns.Add("Valor10", typeof(string));
//            dt.Columns.Add("Valor11", typeof(string));
//            dt.Columns.Add("Valor12", typeof(string));
//            dt.Columns.Add("Valor13", typeof(string));
//            dt.Columns.Add("Valor14", typeof(string));
//            dt.Columns.Add("Valor15", typeof(string));
//            dt.Columns.Add("Valor16", typeof(string));

//            //campo = 1 = "Nombre"
//            //campo = 2 = "Estado Civil"
//            //campo = 3 = "Edad"
//            //campo = 4 = "Telefono"
//            //campo = 5 = "Correo"
//            //campo = 6 = "Género"
//            //campo = 7 = "Licenciatura"
//            //campo = 8 = "Religón"
//            //campo = 9 = "Estado"
//            //campo = 10 = "Trabajo"
//            //campo = 11 = "Tipo de Sangre"
//            //campo = 12 = "Licencia"
//            //campo = 13 = "Tipo Egresado"
//            //campo = 14 = "Fallecido"
//            //campo = 15 = "cumpleaños"

//            var ListaAlumnosReporte = new List<ReportesVM>();
//            var Count = listacaCampos.Count();
//            foreach (var itemA in Alumnos)
//            {
//                var ListaAlumnos = new ReportesVM();
//                for (var i = 0; i < Count; i++)
//                {
//                    if (i == 0)
//                    {
//                        if (listacaCampos[i] == 1)
//                        {
//                            TituloColumna1 = "Nombre Completo";
//                            ListaAlumnos.Valor1 = itemA.Personas.nbCompleto;
//                        }
//                        else if (listacaCampos[i] == 2)
//                        {
//                            TituloColumna1 = "Estado Civil";
//                            ListaAlumnos.Valor1 = itemA.CatEstadosCiviles.nbEstadoCivil;
//                        }
//                        else if (listacaCampos[i] == 3)
//                        {
//                            TituloColumna1 = "Edad";
//                            var edad = DateTime.Now.Year - ((DateTime)itemA.feNacimiento).Date.Year;
//                            ListaAlumnos.Valor1 = edad.ToString() + " Años";
//                        }
//                        else if (listacaCampos[i] == 4)
//                        {
//                            TituloColumna1 = "Teléfono";
//                            ListaAlumnos.Valor1 = (itemA.Personas.MediosContactos.FirstOrDefault(x => x.idTipoMedioContacto == 2) != null) ? itemA.Personas.MediosContactos.FirstOrDefault(x => x.idTipoMedioContacto == 2).desMedioContacto : "S/N";
//                        }
//                        else if (listacaCampos[i] == 5)
//                        {
//                            TituloColumna1 = "Correo";
//                            ListaAlumnos.Valor1 = (itemA.Personas.MediosContactos.FirstOrDefault(x => x.idTipoMedioContacto == 1) != null) ? itemA.Personas.MediosContactos.FirstOrDefault(x => x.idTipoMedioContacto == 1).desMedioContacto : "S/C";
//                        }
//                        else if (listacaCampos[i] == 6)
//                        {
//                            TituloColumna1 = "Género";
//                            ListaAlumnos.Valor1 = itemA.Personas.CatGeneros.nbGenero;
//                        }
//                        else if (listacaCampos[i] == 7)
//                        {
//                            TituloColumna1 = "Licenciatura";
//                            ListaAlumnos.Valor1 = itemA.FormacionesAcademicas.OrderByDescending(x => x.idLicenciatura).FirstOrDefault().Licenciaturas.nbLicenciatura;
//                        }
//                        else if (listacaCampos[i] == 8)
//                        {
//                            TituloColumna1 = "Religión";
//                            ListaAlumnos.Valor1 = itemA.CatReligion.nbReligion;
//                        }
//                        else if (listacaCampos[i] == 9)
//                        {
//                            TituloColumna1 = "Estado";
//                            ListaAlumnos.Valor1 = itemA.Direcciones.nbEstado;
//                        }
//                        else if (listacaCampos[i] == 10)
//                        {
//                            TituloColumna1 = "trabaja";
//                            ListaAlumnos.Valor1 = (itemA.fgTrabajaActualmente == true) ? "SI" : "NO";
//                        }
//                        else if (listacaCampos[i] == 11)
//                        {
//                            TituloColumna1 = "Tipo de Sangre";
//                            ListaAlumnos.Valor1 = itemA.CatTiposSangre.nbTipoSangre;
//                        }
//                        else if (listacaCampos[i] == 12)
//                        {
//                            TituloColumna1 = "Licencia";
//                            ListaAlumnos.Valor1 = (itemA.fgLicencia == true) ? "SI" : "NO";
//                        }
//                        else if (listacaCampos[i] == 13)
//                        {
//                            TituloColumna1 = "Tipo de Egresado";
//                            ListaAlumnos.Valor1 = (itemA.tpEgresado == "T") ? "TItulado" : "Pasante";
//                        }
//                        else if (listacaCampos[i] == 14)
//                        {
//                            TituloColumna1 = "Fallecido";
//                            ListaAlumnos.Valor1 = (itemA.fgFallecido == true) ? "SI" : "NO";
//                        }
//                        else if (listacaCampos[i] == 15)
//                        {
//                            TituloColumna1 = "Cumpleaños";
//                            ListaAlumnos.Valor1 = Convert.ToDateTime(itemA.feNacimiento).ToShortDateString();
//                        }
//                        else if (listacaCampos[i] == 16)
//                        {
//                            TituloColumna1 = "Última fecha de actualización";
//                            ListaAlumnos.Valor1 = Convert.ToDateTime(itemA.feActualizacion).ToShortDateString();
//                        }
//                    }
//                    else if (i == 1)
//                    {
//                        if (listacaCampos[i] == 1)
//                        {
//                            TituloColumna1 = "Nombre Completo";
//                            ListaAlumnos.Valor1 = itemA.Personas.nbCompleto;
//                        }
//                        else if (listacaCampos[i] == 2)
//                        {
//                            TituloColumna2 = "Estado Civil";
//                            ListaAlumnos.Valor2 = itemA.CatEstadosCiviles.nbEstadoCivil;
//                        }
//                        else if (listacaCampos[i] == 3)
//                        {
//                            TituloColumna2 = "Edad";
//                            var edad = DateTime.Now.Year - ((DateTime)itemA.feNacimiento).Date.Year;
//                            ListaAlumnos.Valor2 = edad.ToString() + " Años";
//                        }
//                        else if (listacaCampos[i] == 4)
//                        {
//                            TituloColumna2 = "Teléfono";
//                            ListaAlumnos.Valor2 = (itemA.Personas.MediosContactos.FirstOrDefault(x => x.idTipoMedioContacto == 2) != null) ? itemA.Personas.MediosContactos.FirstOrDefault(x => x.idTipoMedioContacto == 2).desMedioContacto : "S/N";
//                        }
//                        else if (listacaCampos[i] == 5)
//                        {
//                            TituloColumna2 = "Correo";
//                            ListaAlumnos.Valor2 = (itemA.Personas.MediosContactos.FirstOrDefault(x => x.idTipoMedioContacto == 1) != null) ? itemA.Personas.MediosContactos.FirstOrDefault(x => x.idTipoMedioContacto == 1).desMedioContacto : "S/C";
//                        }
//                        else if (listacaCampos[i] == 6)
//                        {
//                            TituloColumna2 = "Género";
//                            ListaAlumnos.Valor2 = itemA.Personas.CatGeneros.nbGenero;
//                        }
//                        else if (listacaCampos[i] == 7)
//                        {
//                            TituloColumna2 = "Licenciatura";
//                            ListaAlumnos.Valor2 = itemA.FormacionesAcademicas.OrderByDescending(x => x.idLicenciatura).FirstOrDefault().Licenciaturas.nbLicenciatura;
//                        }
//                        else if (listacaCampos[i] == 8)
//                        {
//                            TituloColumna2 = "Religión";
//                            ListaAlumnos.Valor2 = itemA.CatReligion.nbReligion;
//                        }
//                        else if (listacaCampos[i] == 9)
//                        {
//                            TituloColumna2 = "Estado";
//                            ListaAlumnos.Valor2 = itemA.Direcciones.nbEstado;
//                        }
//                        else if (listacaCampos[i] == 10)
//                        {
//                            TituloColumna2 = "Trabaja";
//                            ListaAlumnos.Valor2 = (itemA.fgTrabajaActualmente == true) ? "SI" : "NO";
//                        }
//                        else if (listacaCampos[i] == 11)
//                        {
//                            TituloColumna2 = "Tipo de Sangre";
//                            ListaAlumnos.Valor2 = itemA.CatTiposSangre.nbTipoSangre;
//                        }
//                        else if (listacaCampos[i] == 12)
//                        {
//                            TituloColumna2 = "Licencia";
//                            ListaAlumnos.Valor2 = (itemA.fgLicencia == true) ? "SI" : "NO";
//                        }
//                        else if (listacaCampos[i] == 13)
//                        {
//                            TituloColumna2 = "Tipo de Egresado";
//                            ListaAlumnos.Valor2 = (itemA.tpEgresado == "T") ? "TItulado" : "Pasante";
//                        }
//                        else if (listacaCampos[i] == 14)
//                        {
//                            TituloColumna2 = "Fallecido";
//                            ListaAlumnos.Valor2 = (itemA.fgFallecido == true) ? "SI" : "NO";
//                        }
//                        else if (listacaCampos[i] == 15)
//                        {
//                            TituloColumna2 = "Cumpleaños";
//                            ListaAlumnos.Valor2 = Convert.ToDateTime(itemA.feNacimiento).ToShortDateString();
//                        }
//                        else if (listacaCampos[i] == 16)
//                        {
//                            TituloColumna2 = "Última fecha de actualización";
//                            ListaAlumnos.Valor2 = Convert.ToDateTime(itemA.feActualizacion).ToShortDateString();
//                        }
//                    }
//                    else if (i == 2)
//                    {
//                        if (listacaCampos[i] == 1)
//                        {
//                            TituloColumna3 = "Nombre Completo";
//                            ListaAlumnos.Valor3 = itemA.Personas.nbCompleto;
//                        }
//                        else if (listacaCampos[i] == 2)
//                        {
//                            TituloColumna3 = "Estado Civil";
//                            ListaAlumnos.Valor3 = itemA.CatEstadosCiviles.nbEstadoCivil;
//                        }
//                        else if (listacaCampos[i] == 3)
//                        {
//                            TituloColumna3 = "Edad";
//                            var edad = DateTime.Now.Year - ((DateTime)itemA.feNacimiento).Date.Year;
//                            ListaAlumnos.Valor3 = edad.ToString() + " Años";
//                        }
//                        else if (listacaCampos[i] == 4)
//                        {
//                            TituloColumna3 = "Teléfono";
//                            ListaAlumnos.Valor3 = (itemA.Personas.MediosContactos.FirstOrDefault(x => x.idTipoMedioContacto == 2) != null) ? itemA.Personas.MediosContactos.FirstOrDefault(x => x.idTipoMedioContacto == 2).desMedioContacto : "S/N";
//                        }
//                        else if (listacaCampos[i] == 5)
//                        {
//                            TituloColumna3 = "Correo";
//                            ListaAlumnos.Valor3 = (itemA.Personas.MediosContactos.FirstOrDefault(x => x.idTipoMedioContacto == 1) != null) ? itemA.Personas.MediosContactos.FirstOrDefault(x => x.idTipoMedioContacto == 1).desMedioContacto : "S/C";
//                        }
//                        else if (listacaCampos[i] == 6)
//                        {
//                            TituloColumna3 = "Género";
//                            ListaAlumnos.Valor3 = itemA.Personas.CatGeneros.nbGenero;
//                        }
//                        else if (listacaCampos[i] == 7)
//                        {
//                            TituloColumna3 = "Licenciatura";
//                            ListaAlumnos.Valor3 = itemA.FormacionesAcademicas.OrderByDescending(x => x.idLicenciatura).FirstOrDefault().Licenciaturas.nbLicenciatura;
//                        }
//                        else if (listacaCampos[i] == 8)
//                        {
//                            TituloColumna3 = "Religión";
//                            ListaAlumnos.Valor3 = itemA.CatReligion.nbReligion;
//                        }
//                        else if (listacaCampos[i] == 9)
//                        {
//                            TituloColumna3 = "Estado";
//                            ListaAlumnos.Valor3 = itemA.Direcciones.nbEstado;
//                        }
//                        else if (listacaCampos[i] == 10)
//                        {
//                            TituloColumna3 = "Trabaja";
//                            ListaAlumnos.Valor3 = (itemA.fgTrabajaActualmente == true) ? "SI" : "NO";
//                        }
//                        else if (listacaCampos[i] == 11)
//                        {
//                            TituloColumna3 = "Tipo de Sangre";
//                            ListaAlumnos.Valor3 = itemA.CatTiposSangre.nbTipoSangre;
//                        }
//                        else if (listacaCampos[i] == 12)
//                        {
//                            TituloColumna3 = "Licencia";
//                            ListaAlumnos.Valor3 = (itemA.fgLicencia == true) ? "SI" : "NO";
//                        }
//                        else if (listacaCampos[i] == 13)
//                        {
//                            TituloColumna3 = "Tipo de Egresado";
//                            ListaAlumnos.Valor3 = (itemA.tpEgresado == "T") ? "TItulado" : "Pasante";
//                        }
//                        else if (listacaCampos[i] == 14)
//                        {
//                            TituloColumna3 = "Fallecido";
//                            ListaAlumnos.Valor3 = (itemA.fgFallecido == true) ? "SI" : "NO";
//                        }
//                        else if (listacaCampos[i] == 15)
//                        {
//                            TituloColumna3 = "Cumpleaños";
//                            ListaAlumnos.Valor3 = Convert.ToDateTime(itemA.feNacimiento).ToShortDateString();
//                        }
//                        else if (listacaCampos[i] == 16)
//                        {
//                            TituloColumna3 = "Última fecha de actualización";
//                            ListaAlumnos.Valor3 = Convert.ToDateTime(itemA.feActualizacion).ToShortDateString();
//                        }
//                    }
//                    else if (i == 3)
//                    {
//                        if (listacaCampos[i] == 1)
//                        {
//                            TituloColumna4 = "Nombre Completo";
//                            ListaAlumnos.Valor4 = itemA.Personas.nbCompleto;
//                        }
//                        else if (listacaCampos[i] == 2)
//                        {
//                            TituloColumna4 = "Estado Civil";
//                            ListaAlumnos.Valor4 = itemA.CatEstadosCiviles.nbEstadoCivil;
//                        }
//                        else if (listacaCampos[i] == 3)
//                        {
//                            TituloColumna4 = "Edad";
//                            var edad = DateTime.Now.Year - ((DateTime)itemA.feNacimiento).Date.Year;
//                            ListaAlumnos.Valor4 = edad.ToString() + " Años";
//                        }
//                        else if (listacaCampos[i] == 4)
//                        {
//                            TituloColumna4 = "Teléfono";
//                            ListaAlumnos.Valor4 = (itemA.Personas.MediosContactos.FirstOrDefault(x => x.idTipoMedioContacto == 2) != null) ? itemA.Personas.MediosContactos.FirstOrDefault(x => x.idTipoMedioContacto == 2).desMedioContacto : "S/N";
//                        }
//                        else if (listacaCampos[i] == 5)
//                        {
//                            TituloColumna4 = "Correo";
//                            ListaAlumnos.Valor4 = (itemA.Personas.MediosContactos.FirstOrDefault(x => x.idTipoMedioContacto == 1) != null) ? itemA.Personas.MediosContactos.FirstOrDefault(x => x.idTipoMedioContacto == 1).desMedioContacto : "S/C";
//                        }
//                        else if (listacaCampos[i] == 6)
//                        {
//                            TituloColumna4 = "Género";
//                            ListaAlumnos.Valor4 = itemA.Personas.CatGeneros.nbGenero;
//                        }
//                        else if (listacaCampos[i] == 7)
//                        {
//                            TituloColumna4 = "Licenciatura";
//                            ListaAlumnos.Valor4 = itemA.FormacionesAcademicas.OrderByDescending(x => x.idLicenciatura).FirstOrDefault().Licenciaturas.nbLicenciatura;
//                        }
//                        else if (listacaCampos[i] == 8)
//                        {
//                            TituloColumna4 = "Religión";
//                            ListaAlumnos.Valor4 = itemA.CatReligion.nbReligion;
//                        }
//                        else if (listacaCampos[i] == 9)
//                        {
//                            TituloColumna4 = "Estado";
//                            ListaAlumnos.Valor4 = itemA.Direcciones.nbEstado;
//                        }
//                        else if (listacaCampos[i] == 10)
//                        {
//                            TituloColumna4 = "Trabaja";
//                            ListaAlumnos.Valor4 = (itemA.fgTrabajaActualmente == true) ? "SI" : "NO";
//                        }
//                        else if (listacaCampos[i] == 11)
//                        {
//                            TituloColumna4 = "Tipo de Sangre";
//                            ListaAlumnos.Valor4 = itemA.CatTiposSangre.nbTipoSangre;
//                        }
//                        else if (listacaCampos[i] == 12)
//                        {
//                            TituloColumna4 = "Licencia";
//                            ListaAlumnos.Valor4 = (itemA.fgLicencia == true) ? "SI" : "NO";
//                        }
//                        else if (listacaCampos[i] == 13)
//                        {
//                            TituloColumna4 = "Tipo de Egresado";
//                            ListaAlumnos.Valor4 = (itemA.tpEgresado == "T") ? "TItulado" : "Pasante";
//                        }
//                        else if (listacaCampos[i] == 14)
//                        {
//                            TituloColumna4 = "Fallecido";
//                            ListaAlumnos.Valor4 = (itemA.fgFallecido == true) ? "SI" : "NO";
//                        }
//                        else if (listacaCampos[i] == 15)
//                        {
//                            TituloColumna4 = "Cumpleaños";
//                            ListaAlumnos.Valor4 = itemA.feNacimiento.ToString();
//                        }
//                        else if (listacaCampos[i] == 16)
//                        {
//                            TituloColumna4 = "Última fecha de actualización";
//                            ListaAlumnos.Valor4 = Convert.ToDateTime(itemA.feActualizacion).ToShortDateString();
//                        }
//                    }
//                    else if (i == 4)
//                    {
//                        if (listacaCampos[i] == 1)
//                        {
//                            TituloColumna5 = "Nombre Completo";
//                            ListaAlumnos.Valor5 = itemA.Personas.nbCompleto;
//                        }
//                        else if (listacaCampos[i] == 2)
//                        {
//                            TituloColumna5 = "Estado Civil";
//                            ListaAlumnos.Valor5 = itemA.CatEstadosCiviles.nbEstadoCivil;
//                        }
//                        else if (listacaCampos[i] == 3)
//                        {
//                            TituloColumna5 = "Edad";
//                            var edad = DateTime.Now.Year - ((DateTime)itemA.feNacimiento).Date.Year;
//                            ListaAlumnos.Valor5 = edad.ToString() + " Años";
//                        }
//                        else if (listacaCampos[i] == 4)
//                        {
//                            TituloColumna5 = "Teléfono";
//                            ListaAlumnos.Valor5 = (itemA.Personas.MediosContactos.FirstOrDefault(x => x.idTipoMedioContacto == 2) != null) ? itemA.Personas.MediosContactos.FirstOrDefault(x => x.idTipoMedioContacto == 2).desMedioContacto : "S/N";
//                        }
//                        else if (listacaCampos[i] == 5)
//                        {
//                            TituloColumna5 = "Correo";
//                            ListaAlumnos.Valor5 = (itemA.Personas.MediosContactos.FirstOrDefault(x => x.idTipoMedioContacto == 1) != null) ? itemA.Personas.MediosContactos.FirstOrDefault(x => x.idTipoMedioContacto == 1).desMedioContacto : "S/C";
//                        }
//                        else if (listacaCampos[i] == 6)
//                        {
//                            TituloColumna5 = "Género";
//                            ListaAlumnos.Valor5 = itemA.Personas.CatGeneros.nbGenero;
//                        }
//                        else if (listacaCampos[i] == 7)
//                        {
//                            TituloColumna5 = "Licenciatura";
//                            ListaAlumnos.Valor5 = itemA.FormacionesAcademicas.OrderByDescending(x => x.idLicenciatura).FirstOrDefault().Licenciaturas.nbLicenciatura;
//                        }
//                        else if (listacaCampos[i] == 8)
//                        {
//                            TituloColumna5 = "Religión";
//                            ListaAlumnos.Valor5 = itemA.CatReligion.nbReligion;
//                        }
//                        else if (listacaCampos[i] == 9)
//                        {
//                            TituloColumna5 = "Estado";
//                            ListaAlumnos.Valor5 = itemA.Direcciones.nbEstado;
//                        }
//                        else if (listacaCampos[i] == 10)
//                        {
//                            TituloColumna5 = "Trabaja";
//                            ListaAlumnos.Valor5 = (itemA.fgTrabajaActualmente == true) ? "SI" : "NO";
//                        }
//                        else if (listacaCampos[i] == 11)
//                        {
//                            TituloColumna5 = "Tipo de Sangre";
//                            ListaAlumnos.Valor5 = itemA.CatTiposSangre.nbTipoSangre;
//                        }
//                        else if (listacaCampos[i] == 12)
//                        {
//                            TituloColumna5 = "Licencia";
//                            ListaAlumnos.Valor5 = (itemA.fgLicencia == true) ? "SI" : "NO";
//                        }
//                        else if (listacaCampos[i] == 13)
//                        {
//                            TituloColumna5 = "Tipo de Egresado";
//                            ListaAlumnos.Valor5 = (itemA.tpEgresado == "T") ? "TItulado" : "Pasante";
//                        }
//                        else if (listacaCampos[i] == 14)
//                        {
//                            TituloColumna5 = "Fallecido";
//                            ListaAlumnos.Valor5 = (itemA.fgFallecido == true) ? "SI" : "NO";
//                        }
//                        else if (listacaCampos[i] == 15)
//                        {
//                            TituloColumna5 = "Cumpleaños";
//                            ListaAlumnos.Valor5 = Convert.ToDateTime(itemA.feNacimiento).ToShortDateString();
//                        }
//                        else if (listacaCampos[i] == 16)
//                        {
//                            TituloColumna5 = "Última fecha de actualización";
//                            ListaAlumnos.Valor5 = Convert.ToDateTime(itemA.feActualizacion).ToShortDateString();
//                        }
//                    }
//                    else if (i == 5)
//                    {
//                        if (listacaCampos[i] == 1)
//                        {
//                            TituloColumna6 = "Nombre Completo";
//                            ListaAlumnos.Valor6 = itemA.Personas.nbCompleto;
//                        }
//                        else if (listacaCampos[i] == 2)
//                        {
//                            TituloColumna6 = "Estado Civil";
//                            ListaAlumnos.Valor6 = itemA.CatEstadosCiviles.nbEstadoCivil;
//                        }
//                        else if (listacaCampos[i] == 3)
//                        {
//                            TituloColumna6 = "Edad";
//                            var edad = DateTime.Now.Year - ((DateTime)itemA.feNacimiento).Date.Year;
//                            ListaAlumnos.Valor6 = edad.ToString() + " Años";
//                        }
//                        else if (listacaCampos[i] == 4)
//                        {
//                            TituloColumna6 = "Teléfono";
//                            ListaAlumnos.Valor6 = (itemA.Personas.MediosContactos.FirstOrDefault(x => x.idTipoMedioContacto == 2) != null) ? itemA.Personas.MediosContactos.FirstOrDefault(x => x.idTipoMedioContacto == 2).desMedioContacto : "S/N";
//                        }
//                        else if (listacaCampos[i] == 5)
//                        {
//                            TituloColumna6 = "Correo";
//                            ListaAlumnos.Valor6 = (itemA.Personas.MediosContactos.FirstOrDefault(x => x.idTipoMedioContacto == 1) != null) ? itemA.Personas.MediosContactos.FirstOrDefault(x => x.idTipoMedioContacto == 1).desMedioContacto : "S/C";
//                        }
//                        else if (listacaCampos[i] == 6)
//                        {
//                            TituloColumna6 = "Género";
//                            ListaAlumnos.Valor6 = itemA.Personas.CatGeneros.nbGenero;
//                        }
//                        else if (listacaCampos[i] == 7)
//                        {
//                            TituloColumna6 = "Licenciatura";
//                            ListaAlumnos.Valor6 = itemA.FormacionesAcademicas.OrderByDescending(x => x.idLicenciatura).FirstOrDefault().Licenciaturas.nbLicenciatura;
//                        }
//                        else if (listacaCampos[i] == 8)
//                        {
//                            TituloColumna6 = "Religión";
//                            ListaAlumnos.Valor6 = itemA.CatReligion.nbReligion;
//                        }
//                        else if (listacaCampos[i] == 9)
//                        {
//                            TituloColumna6 = "Estado";
//                            ListaAlumnos.Valor6 = itemA.Direcciones.nbEstado;
//                        }
//                        else if (listacaCampos[i] == 10)
//                        {
//                            TituloColumna6 = "trabaja";
//                            ListaAlumnos.Valor6 = (itemA.fgTrabajaActualmente == true) ? "SI" : "NO";
//                        }
//                        else if (listacaCampos[i] == 11)
//                        {
//                            TituloColumna6 = "Tipo de Sangre";
//                            ListaAlumnos.Valor6 = itemA.CatTiposSangre.nbTipoSangre;
//                        }
//                        else if (listacaCampos[i] == 12)
//                        {
//                            TituloColumna6 = "Licencia";
//                            ListaAlumnos.Valor6 = (itemA.fgLicencia == true) ? "SI" : "NO";
//                        }
//                        else if (listacaCampos[i] == 13)
//                        {
//                            TituloColumna6 = "Tipo de Egresado";
//                            ListaAlumnos.Valor6 = (itemA.tpEgresado == "T") ? "TItulado" : "Pasante";
//                        }
//                        else if (listacaCampos[i] == 14)
//                        {
//                            TituloColumna6 = "Fallecido";
//                            ListaAlumnos.Valor6 = (itemA.fgFallecido == true) ? "SI" : "NO";
//                        }
//                        else if (listacaCampos[i] == 15)
//                        {
//                            TituloColumna6 = "Cumpleaños";
//                            ListaAlumnos.Valor6 = Convert.ToDateTime(itemA.feNacimiento).ToShortDateString();
//                        }
//                        else if (listacaCampos[i] == 16)
//                        {
//                            TituloColumna6 = "Última fecha de actualización";
//                            ListaAlumnos.Valor6 = Convert.ToDateTime(itemA.feActualizacion).ToShortDateString();
//                        }
//                    }
//                    else if (i == 6)
//                    {
//                        if (listacaCampos[i] == 1)
//                        {
//                            TituloColumna7 = "Nombre Completo";
//                            ListaAlumnos.Valor7 = itemA.Personas.nbCompleto;
//                        }
//                        else if (listacaCampos[i] == 2)
//                        {
//                            TituloColumna7 = "Estado Civil";
//                            ListaAlumnos.Valor7 = itemA.CatEstadosCiviles.nbEstadoCivil;
//                        }
//                        else if (listacaCampos[i] == 3)
//                        {
//                            TituloColumna7 = "Edad";
//                            var edad = DateTime.Now.Year - ((DateTime)itemA.feNacimiento).Date.Year;
//                            ListaAlumnos.Valor7 = edad.ToString() + " Años";
//                        }
//                        else if (listacaCampos[i] == 4)
//                        {
//                            TituloColumna7 = "Teléfono";
//                            ListaAlumnos.Valor7 = (itemA.Personas.MediosContactos.FirstOrDefault(x => x.idTipoMedioContacto == 2) != null) ? itemA.Personas.MediosContactos.FirstOrDefault(x => x.idTipoMedioContacto == 2).desMedioContacto : "S/N";
//                        }
//                        else if (listacaCampos[i] == 5)
//                        {
//                            TituloColumna7 = "Correo";
//                            ListaAlumnos.Valor7 = (itemA.Personas.MediosContactos.FirstOrDefault(x => x.idTipoMedioContacto == 1) != null) ? itemA.Personas.MediosContactos.FirstOrDefault(x => x.idTipoMedioContacto == 1).desMedioContacto : "S/C";
//                        }
//                        else if (listacaCampos[i] == 6)
//                        {
//                            TituloColumna7 = "Género";
//                            ListaAlumnos.Valor7 = itemA.Personas.CatGeneros.nbGenero;
//                        }
//                        else if (listacaCampos[i] == 7)
//                        {
//                            TituloColumna7 = "Licenciatura";
//                            ListaAlumnos.Valor7 = itemA.FormacionesAcademicas.OrderByDescending(x => x.idLicenciatura).FirstOrDefault().Licenciaturas.nbLicenciatura;
//                        }
//                        else if (listacaCampos[i] == 8)
//                        {
//                            TituloColumna7 = "Religión";
//                            ListaAlumnos.Valor7 = itemA.CatReligion.nbReligion;
//                        }
//                        else if (listacaCampos[i] == 9)
//                        {
//                            TituloColumna7 = "Estado";
//                            ListaAlumnos.Valor7 = itemA.Direcciones.nbEstado;
//                        }
//                        else if (listacaCampos[i] == 10)
//                        {
//                            TituloColumna7 = "trabaja";
//                            ListaAlumnos.Valor7 = (itemA.fgTrabajaActualmente == true) ? "SI" : "NO";
//                        }
//                        else if (listacaCampos[i] == 11)
//                        {
//                            TituloColumna7 = "Tipo de Sangre";
//                            ListaAlumnos.Valor7 = itemA.CatTiposSangre.nbTipoSangre;
//                        }
//                        else if (listacaCampos[i] == 12)
//                        {
//                            TituloColumna7 = "Licencia";
//                            ListaAlumnos.Valor7 = (itemA.fgLicencia == true) ? "SI" : "NO";
//                        }
//                        else if (listacaCampos[i] == 13)
//                        {
//                            TituloColumna7 = "Tipo de Egresado";
//                            ListaAlumnos.Valor7 = (itemA.tpEgresado == "T") ? "TItulado" : "Pasante";
//                        }
//                        else if (listacaCampos[i] == 14)
//                        {
//                            TituloColumna7 = "Fallecido";
//                            ListaAlumnos.Valor7 = (itemA.fgFallecido == true) ? "SI" : "NO";
//                        }
//                        else if (listacaCampos[i] == 15)
//                        {
//                            TituloColumna7 = "Cumpleaños";
//                            ListaAlumnos.Valor7 = Convert.ToDateTime(itemA.feNacimiento).ToShortDateString();
//                        }
//                        else if (listacaCampos[i] == 16)
//                        {
//                            TituloColumna7 = "Última fecha de actualización";
//                            ListaAlumnos.Valor7 = Convert.ToDateTime(itemA.feActualizacion).ToShortDateString();
//                        }
//                    }
//                    else if (i == 7)
//                    {
//                        if (listacaCampos[i] == 1)
//                        {
//                            TituloColumna8 = "Nombre Completo";
//                            ListaAlumnos.Valor8 = itemA.Personas.nbCompleto;
//                        }
//                        else if (listacaCampos[i] == 2)
//                        {
//                            TituloColumna8 = "Estado Civil";
//                            ListaAlumnos.Valor8 = itemA.CatEstadosCiviles.nbEstadoCivil;
//                        }
//                        else if (listacaCampos[i] == 3)
//                        {
//                            TituloColumna8 = "Edad";
//                            var edad = DateTime.Now.Year - ((DateTime)itemA.feNacimiento).Date.Year;
//                            ListaAlumnos.Valor8 = edad.ToString() + " Años";
//                        }
//                        else if (listacaCampos[i] == 4)
//                        {
//                            TituloColumna8 = "Teléfono";
//                            ListaAlumnos.Valor8 = (itemA.Personas.MediosContactos.FirstOrDefault(x => x.idTipoMedioContacto == 2) != null) ? itemA.Personas.MediosContactos.FirstOrDefault(x => x.idTipoMedioContacto == 2).desMedioContacto : "S/N";
//                        }
//                        else if (listacaCampos[i] == 5)
//                        {
//                            TituloColumna8 = "Correo";
//                            ListaAlumnos.Valor8 = (itemA.Personas.MediosContactos.FirstOrDefault(x => x.idTipoMedioContacto == 1) != null) ? itemA.Personas.MediosContactos.FirstOrDefault(x => x.idTipoMedioContacto == 1).desMedioContacto : "S/C";
//                        }
//                        else if (listacaCampos[i] == 6)
//                        {
//                            TituloColumna8 = "Género";
//                            ListaAlumnos.Valor8 = itemA.Personas.CatGeneros.nbGenero;
//                        }
//                        else if (listacaCampos[i] == 7)
//                        {
//                            TituloColumna8 = "Licenciatura";
//                            ListaAlumnos.Valor8 = itemA.FormacionesAcademicas.OrderByDescending(x => x.idLicenciatura).FirstOrDefault().Licenciaturas.nbLicenciatura;
//                        }
//                        else if (listacaCampos[i] == 8)
//                        {
//                            TituloColumna8 = "Religión";
//                            ListaAlumnos.Valor8 = itemA.CatReligion.nbReligion;
//                        }
//                        else if (listacaCampos[i] == 9)
//                        {
//                            TituloColumna8 = "Estado";
//                            ListaAlumnos.Valor8 = itemA.Direcciones.nbEstado;
//                        }
//                        else if (listacaCampos[i] == 10)
//                        {
//                            TituloColumna8 = "trabaja";
//                            ListaAlumnos.Valor8 = (itemA.fgTrabajaActualmente == true) ? "SI" : "NO";
//                        }
//                        else if (listacaCampos[i] == 11)
//                        {
//                            TituloColumna8 = "Tipo de Sangre";
//                            ListaAlumnos.Valor8 = itemA.CatTiposSangre.nbTipoSangre;
//                        }
//                        else if (listacaCampos[i] == 12)
//                        {
//                            TituloColumna8 = "Licencia";
//                            ListaAlumnos.Valor8 = (itemA.fgLicencia == true) ? "SI" : "NO";
//                        }
//                        else if (listacaCampos[i] == 13)
//                        {
//                            TituloColumna8 = "Tipo de Egresado";
//                            ListaAlumnos.Valor8 = (itemA.tpEgresado == "T") ? "TItulado" : "Pasante";
//                        }
//                        else if (listacaCampos[i] == 14)
//                        {
//                            TituloColumna8 = "Fallecido";
//                            ListaAlumnos.Valor8 = (itemA.fgFallecido == true) ? "SI" : "NO";
//                        }
//                        else if (listacaCampos[i] == 15)
//                        {
//                            TituloColumna8 = "Cumpleaños";
//                            ListaAlumnos.Valor8 = Convert.ToDateTime(itemA.feNacimiento).ToShortDateString();
//                        }
//                        else if (listacaCampos[i] == 16)
//                        {
//                            TituloColumna8 = "Última fecha de actualización";
//                            ListaAlumnos.Valor8 = Convert.ToDateTime(itemA.feActualizacion).ToShortDateString();
//                        }
//                    }
//                    else if (i == 8)
//                    {
//                        if (listacaCampos[i] == 1)
//                        {
//                            TituloColumna9 = "Nombre Completo";
//                            ListaAlumnos.Valor9 = itemA.Personas.nbCompleto;
//                        }
//                        else if (listacaCampos[i] == 2)
//                        {
//                            TituloColumna9 = "Estado Civil";
//                            ListaAlumnos.Valor9 = itemA.CatEstadosCiviles.nbEstadoCivil;
//                        }
//                        else if (listacaCampos[i] == 3)
//                        {
//                            TituloColumna9 = "Edad";
//                            var edad = DateTime.Now.Year - ((DateTime)itemA.feNacimiento).Date.Year;
//                            ListaAlumnos.Valor9 = edad.ToString() + " Años";
//                        }
//                        else if (listacaCampos[i] == 4)
//                        {
//                            TituloColumna9 = "Teléfono";
//                            ListaAlumnos.Valor9 = (itemA.Personas.MediosContactos.FirstOrDefault(x => x.idTipoMedioContacto == 2) != null) ? itemA.Personas.MediosContactos.FirstOrDefault(x => x.idTipoMedioContacto == 2).desMedioContacto : "S/N";
//                        }
//                        else if (listacaCampos[i] == 5)
//                        {
//                            TituloColumna9 = "Correo";
//                            ListaAlumnos.Valor9 = (itemA.Personas.MediosContactos.FirstOrDefault(x => x.idTipoMedioContacto == 1) != null) ? itemA.Personas.MediosContactos.FirstOrDefault(x => x.idTipoMedioContacto == 1).desMedioContacto : "S/C";
//                        }
//                        else if (listacaCampos[i] == 6)
//                        {
//                            TituloColumna9 = "Género";
//                            ListaAlumnos.Valor9 = itemA.Personas.CatGeneros.nbGenero;
//                        }
//                        else if (listacaCampos[i] == 7)
//                        {
//                            TituloColumna9 = "Licenciatura";
//                            ListaAlumnos.Valor9 = itemA.FormacionesAcademicas.OrderByDescending(x => x.idLicenciatura).FirstOrDefault().Licenciaturas.nbLicenciatura;
//                        }
//                        else if (listacaCampos[i] == 8)
//                        {
//                            TituloColumna9 = "Religión";
//                            ListaAlumnos.Valor9 = itemA.CatReligion.nbReligion;
//                        }
//                        else if (listacaCampos[i] == 9)
//                        {
//                            TituloColumna9 = "Estado";
//                            ListaAlumnos.Valor9 = itemA.Direcciones.nbEstado;
//                        }
//                        else if (listacaCampos[i] == 10)
//                        {
//                            TituloColumna9 = "trabaja";
//                            ListaAlumnos.Valor9 = (itemA.fgTrabajaActualmente == true) ? "SI" : "NO";
//                        }
//                        else if (listacaCampos[i] == 11)
//                        {
//                            TituloColumna9 = "Tipo de Sangre";
//                            ListaAlumnos.Valor9 = itemA.CatTiposSangre.nbTipoSangre;
//                        }
//                        else if (listacaCampos[i] == 12)
//                        {
//                            TituloColumna9 = "Licencia";
//                            ListaAlumnos.Valor9 = (itemA.fgLicencia == true) ? "SI" : "NO";
//                        }
//                        else if (listacaCampos[i] == 13)
//                        {
//                            TituloColumna9 = "Tipo de Egresado";
//                            ListaAlumnos.Valor9 = (itemA.tpEgresado == "T") ? "TItulado" : "Pasante";
//                        }
//                        else if (listacaCampos[i] == 14)
//                        {
//                            TituloColumna9 = "Fallecido";
//                            ListaAlumnos.Valor9 = (itemA.fgFallecido == true) ? "SI" : "NO";
//                        }
//                        else if (listacaCampos[i] == 15)
//                        {
//                            TituloColumna9 = "Cumpleaños";
//                            ListaAlumnos.Valor9 = Convert.ToDateTime(itemA.feNacimiento).ToShortDateString();
//                        }
//                        else if (listacaCampos[i] == 16)
//                        {
//                            TituloColumna9 = "Última fecha de actualización";
//                            ListaAlumnos.Valor9 = Convert.ToDateTime(itemA.feActualizacion).ToShortDateString();
//                        }
//                    }
//                    else if (i == 9)
//                    {
//                        if (listacaCampos[i] == 1)
//                        {
//                            TituloColumna10 = "Nombre Completo";
//                            ListaAlumnos.Valor10 = itemA.Personas.nbCompleto;
//                        }
//                        else if (listacaCampos[i] == 2)
//                        {
//                            TituloColumna10 = "Estado Civil";
//                            ListaAlumnos.Valor10 = itemA.CatEstadosCiviles.nbEstadoCivil;
//                        }
//                        else if (listacaCampos[i] == 3)
//                        {
//                            TituloColumna10 = "Edad";
//                            var edad = DateTime.Now.Year - ((DateTime)itemA.feNacimiento).Date.Year;
//                            ListaAlumnos.Valor10 = edad.ToString() + " Años";
//                        }
//                        else if (listacaCampos[i] == 4)
//                        {
//                            TituloColumna10 = "Teléfono";
//                            ListaAlumnos.Valor10 = (itemA.Personas.MediosContactos.FirstOrDefault(x => x.idTipoMedioContacto == 2) != null) ? itemA.Personas.MediosContactos.FirstOrDefault(x => x.idTipoMedioContacto == 2).desMedioContacto : "S/N";
//                        }
//                        else if (listacaCampos[i] == 5)
//                        {
//                            TituloColumna10 = "Correo";
//                            ListaAlumnos.Valor10 = (itemA.Personas.MediosContactos.FirstOrDefault(x => x.idTipoMedioContacto == 1) != null) ? itemA.Personas.MediosContactos.FirstOrDefault(x => x.idTipoMedioContacto == 1).desMedioContacto : "S/C";
//                        }
//                        else if (listacaCampos[i] == 6)
//                        {
//                            TituloColumna10 = "Género";
//                            ListaAlumnos.Valor10 = itemA.Personas.CatGeneros.nbGenero;
//                        }
//                        else if (listacaCampos[i] == 7)
//                        {
//                            TituloColumna10 = "Licenciatura";
//                            ListaAlumnos.Valor10 = itemA.FormacionesAcademicas.OrderByDescending(x => x.idLicenciatura).FirstOrDefault().Licenciaturas.nbLicenciatura;
//                        }
//                        else if (listacaCampos[i] == 8)
//                        {
//                            TituloColumna10 = "Religión";
//                            ListaAlumnos.Valor10 = itemA.CatReligion.nbReligion;
//                        }
//                        else if (listacaCampos[i] == 9)
//                        {
//                            TituloColumna10 = "Estado";
//                            ListaAlumnos.Valor10 = itemA.Direcciones.nbEstado;
//                        }
//                        else if (listacaCampos[i] == 10)
//                        {
//                            TituloColumna10 = "trabaja";
//                            ListaAlumnos.Valor10 = (itemA.fgTrabajaActualmente == true) ? "SI" : "NO";
//                        }
//                        else if (listacaCampos[i] == 11)
//                        {
//                            TituloColumna10 = "Tipo de Sangre";
//                            ListaAlumnos.Valor10 = itemA.CatTiposSangre.nbTipoSangre;
//                        }
//                        else if (listacaCampos[i] == 12)
//                        {
//                            TituloColumna10 = "Licencia";
//                            ListaAlumnos.Valor10 = (itemA.fgLicencia == true) ? "SI" : "NO";
//                        }
//                        else if (listacaCampos[i] == 13)
//                        {
//                            TituloColumna10 = "Tipo de Egresado";
//                            ListaAlumnos.Valor10 = (itemA.tpEgresado == "T") ? "TItulado" : "Pasante";
//                        }
//                        else if (listacaCampos[i] == 14)
//                        {
//                            TituloColumna10 = "Fallecido";
//                            ListaAlumnos.Valor10 = (itemA.fgFallecido == true) ? "SI" : "NO";
//                        }
//                        else if (listacaCampos[i] == 15)
//                        {
//                            TituloColumna10 = "Cumpleaños";
//                            ListaAlumnos.Valor10 = Convert.ToDateTime(itemA.feNacimiento).ToShortDateString();
//                        }
//                        else if (listacaCampos[i] == 16)
//                        {
//                            TituloColumna10 = "Última fecha de actualización";
//                            ListaAlumnos.Valor10 = Convert.ToDateTime(itemA.feActualizacion).ToShortDateString();
//                        }
//                    }
//                    else if (i == 10)
//                    {
//                        if (listacaCampos[i] == 1)
//                        {
//                            TituloColumna11 = "Nombre Completo";
//                            ListaAlumnos.Valor11 = itemA.Personas.nbCompleto;
//                        }
//                        else if (listacaCampos[i] == 2)
//                        {
//                            TituloColumna11 = "Estado Civil";
//                            ListaAlumnos.Valor11 = itemA.CatEstadosCiviles.nbEstadoCivil;
//                        }
//                        else if (listacaCampos[i] == 3)
//                        {
//                            TituloColumna11 = "Edad";
//                            var edad = DateTime.Now.Year - ((DateTime)itemA.feNacimiento).Date.Year;
//                            ListaAlumnos.Valor11 = edad.ToString() + " Años";
//                        }
//                        else if (listacaCampos[i] == 4)
//                        {
//                            TituloColumna11 = "Teléfono";
//                            ListaAlumnos.Valor11 = (itemA.Personas.MediosContactos.FirstOrDefault(x => x.idTipoMedioContacto == 2) != null) ? itemA.Personas.MediosContactos.FirstOrDefault(x => x.idTipoMedioContacto == 2).desMedioContacto : "S/N";
//                        }
//                        else if (listacaCampos[i] == 5)
//                        {
//                            TituloColumna11 = "Correo";
//                            ListaAlumnos.Valor11 = (itemA.Personas.MediosContactos.FirstOrDefault(x => x.idTipoMedioContacto == 1) != null) ? itemA.Personas.MediosContactos.FirstOrDefault(x => x.idTipoMedioContacto == 1).desMedioContacto : "S/C";
//                        }
//                        else if (listacaCampos[i] == 6)
//                        {
//                            TituloColumna11 = "Género";
//                            ListaAlumnos.Valor11 = itemA.Personas.CatGeneros.nbGenero;
//                        }
//                        else if (listacaCampos[i] == 7)
//                        {
//                            TituloColumna11 = "Licenciatura";
//                            ListaAlumnos.Valor11 = itemA.FormacionesAcademicas.OrderByDescending(x => x.idLicenciatura).FirstOrDefault().Licenciaturas.nbLicenciatura;
//                        }
//                        else if (listacaCampos[i] == 8)
//                        {
//                            TituloColumna11 = "Religión";
//                            ListaAlumnos.Valor11 = itemA.CatReligion.nbReligion;
//                        }
//                        else if (listacaCampos[i] == 9)
//                        {
//                            TituloColumna11 = "Estado";
//                            ListaAlumnos.Valor11 = itemA.Direcciones.nbEstado;
//                        }
//                        else if (listacaCampos[i] == 10)
//                        {
//                            TituloColumna11 = "trabaja";
//                            ListaAlumnos.Valor11 = (itemA.fgTrabajaActualmente == true) ? "SI" : "NO";
//                        }
//                        else if (listacaCampos[i] == 11)
//                        {
//                            TituloColumna11 = "Tipo de Sangre";
//                            ListaAlumnos.Valor11 = itemA.CatTiposSangre.nbTipoSangre;
//                        }
//                        else if (listacaCampos[i] == 12)
//                        {
//                            TituloColumna11 = "Licencia";
//                            ListaAlumnos.Valor11 = (itemA.fgLicencia == true) ? "SI" : "NO";
//                        }
//                        else if (listacaCampos[i] == 13)
//                        {
//                            TituloColumna11 = "Tipo de Egresado";
//                            ListaAlumnos.Valor11 = (itemA.tpEgresado == "T") ? "TItulado" : "Pasante";
//                        }
//                        else if (listacaCampos[i] == 14)
//                        {
//                            TituloColumna11 = "Fallecido";
//                            ListaAlumnos.Valor11 = (itemA.fgFallecido == true) ? "SI" : "NO";
//                        }
//                        else if (listacaCampos[i] == 15)
//                        {
//                            TituloColumna11 = "Cumpleaños";
//                            ListaAlumnos.Valor11 = Convert.ToDateTime(itemA.feNacimiento).ToShortDateString();
//                        }
//                        else if (listacaCampos[i] == 16)
//                        {
//                            TituloColumna11 = "Última fecha de actualización";
//                            ListaAlumnos.Valor11 = Convert.ToDateTime(itemA.feActualizacion).ToShortDateString();
//                        }
//                    }
//                    else if (i == 11)
//                    {
//                        if (listacaCampos[i] == 1)
//                        {
//                            TituloColumna12 = "Nombre Completo";
//                            ListaAlumnos.Valor12 = itemA.Personas.nbCompleto;
//                        }
//                        else if (listacaCampos[i] == 2)
//                        {
//                            TituloColumna12 = "Estado Civil";
//                            ListaAlumnos.Valor12 = itemA.CatEstadosCiviles.nbEstadoCivil;
//                        }
//                        else if (listacaCampos[i] == 3)
//                        {
//                            TituloColumna12 = "Edad";
//                            var edad = DateTime.Now.Year - ((DateTime)itemA.feNacimiento).Date.Year;
//                            ListaAlumnos.Valor12 = edad.ToString() + " Años";
//                        }
//                        else if (listacaCampos[i] == 4)
//                        {
//                            TituloColumna12 = "Teléfono";
//                            ListaAlumnos.Valor12 = (itemA.Personas.MediosContactos.FirstOrDefault(x => x.idTipoMedioContacto == 2) != null) ? itemA.Personas.MediosContactos.FirstOrDefault(x => x.idTipoMedioContacto == 2).desMedioContacto : "S/N";
//                        }
//                        else if (listacaCampos[i] == 5)
//                        {
//                            TituloColumna12 = "Correo";
//                            ListaAlumnos.Valor12 = (itemA.Personas.MediosContactos.FirstOrDefault(x => x.idTipoMedioContacto == 1) != null) ? itemA.Personas.MediosContactos.FirstOrDefault(x => x.idTipoMedioContacto == 1).desMedioContacto : "S/C";
//                        }
//                        else if (listacaCampos[i] == 6)
//                        {
//                            TituloColumna12 = "Género";
//                            ListaAlumnos.Valor12 = itemA.Personas.CatGeneros.nbGenero;
//                        }
//                        else if (listacaCampos[i] == 7)
//                        {
//                            TituloColumna12 = "Licenciatura";
//                            ListaAlumnos.Valor12 = itemA.FormacionesAcademicas.OrderByDescending(x => x.idLicenciatura).FirstOrDefault().Licenciaturas.nbLicenciatura;
//                        }
//                        else if (listacaCampos[i] == 8)
//                        {
//                            TituloColumna12 = "Religión";
//                            ListaAlumnos.Valor12 = itemA.CatReligion.nbReligion;
//                        }
//                        else if (listacaCampos[i] == 9)
//                        {
//                            TituloColumna12 = "Estado";
//                            ListaAlumnos.Valor12 = itemA.Direcciones.nbEstado;
//                        }
//                        else if (listacaCampos[i] == 10)
//                        {
//                            TituloColumna12 = "trabaja";
//                            ListaAlumnos.Valor12 = (itemA.fgTrabajaActualmente == true) ? "SI" : "NO";
//                        }
//                        else if (listacaCampos[i] == 11)
//                        {
//                            TituloColumna12 = "Tipo de Sangre";
//                            ListaAlumnos.Valor12 = itemA.CatTiposSangre.nbTipoSangre;
//                        }
//                        else if (listacaCampos[i] == 12)
//                        {
//                            TituloColumna12 = "Licencia";
//                            ListaAlumnos.Valor12 = (itemA.fgLicencia == true) ? "SI" : "NO";
//                        }
//                        else if (listacaCampos[i] == 13)
//                        {
//                            TituloColumna12 = "Tipo de Egresado";
//                            ListaAlumnos.Valor12 = (itemA.tpEgresado == "T") ? "TItulado" : "Pasante";
//                        }
//                        else if (listacaCampos[i] == 14)
//                        {
//                            TituloColumna12 = "Fallecido";
//                            ListaAlumnos.Valor12 = (itemA.fgFallecido == true) ? "SI" : "NO";
//                        }
//                        else if (listacaCampos[i] == 15)
//                        {
//                            TituloColumna12 = "Cumpleaños";
//                            ListaAlumnos.Valor12 = Convert.ToDateTime(itemA.feNacimiento).ToShortDateString();
//                        }
//                        else if (listacaCampos[i] == 16)
//                        {
//                            TituloColumna12 = "Última fecha de actualización";
//                            ListaAlumnos.Valor12 = Convert.ToDateTime(itemA.feActualizacion).ToShortDateString();
//                        }
//                    }
//                    else if (i == 12)
//                    {
//                        if (listacaCampos[i] == 1)
//                        {
//                            TituloColumna13 = "Nombre Completo";
//                            ListaAlumnos.Valor13 = itemA.Personas.nbCompleto;
//                        }
//                        else if (listacaCampos[i] == 2)
//                        {
//                            TituloColumna13 = "Estado Civil";
//                            ListaAlumnos.Valor13 = itemA.CatEstadosCiviles.nbEstadoCivil;
//                        }
//                        else if (listacaCampos[i] == 3)
//                        {
//                            TituloColumna13 = "Edad";
//                            var edad = DateTime.Now.Year - ((DateTime)itemA.feNacimiento).Date.Year;
//                            ListaAlumnos.Valor13 = edad.ToString() + " Años";
//                        }
//                        else if (listacaCampos[i] == 4)
//                        {
//                            TituloColumna13 = "Teléfono";
//                            ListaAlumnos.Valor13 = (itemA.Personas.MediosContactos.FirstOrDefault(x => x.idTipoMedioContacto == 2) != null) ? itemA.Personas.MediosContactos.FirstOrDefault(x => x.idTipoMedioContacto == 2).desMedioContacto : "S/N";
//                        }
//                        else if (listacaCampos[i] == 5)
//                        {
//                            TituloColumna13 = "Correo";
//                            ListaAlumnos.Valor13 = (itemA.Personas.MediosContactos.FirstOrDefault(x => x.idTipoMedioContacto == 1) != null) ? itemA.Personas.MediosContactos.FirstOrDefault(x => x.idTipoMedioContacto == 1).desMedioContacto : "S/C";
//                        }
//                        else if (listacaCampos[i] == 6)
//                        {
//                            TituloColumna13 = "Género";
//                            ListaAlumnos.Valor13 = itemA.Personas.CatGeneros.nbGenero;
//                        }
//                        else if (listacaCampos[i] == 7)
//                        {
//                            TituloColumna13 = "Licenciatura";
//                            ListaAlumnos.Valor13 = itemA.FormacionesAcademicas.OrderByDescending(x => x.idLicenciatura).FirstOrDefault().Licenciaturas.nbLicenciatura;
//                        }
//                        else if (listacaCampos[i] == 8)
//                        {
//                            TituloColumna13 = "Religión";
//                            ListaAlumnos.Valor13 = itemA.CatReligion.nbReligion;
//                        }
//                        else if (listacaCampos[i] == 9)
//                        {
//                            TituloColumna13 = "Estado";
//                            ListaAlumnos.Valor13 = itemA.Direcciones.nbEstado;
//                        }
//                        else if (listacaCampos[i] == 10)
//                        {
//                            TituloColumna13 = "trabaja";
//                            ListaAlumnos.Valor13 = (itemA.fgTrabajaActualmente == true) ? "SI" : "NO";
//                        }
//                        else if (listacaCampos[i] == 11)
//                        {
//                            TituloColumna13 = "Tipo de Sangre";
//                            ListaAlumnos.Valor13 = itemA.CatTiposSangre.nbTipoSangre;
//                        }
//                        else if (listacaCampos[i] == 12)
//                        {
//                            TituloColumna13 = "Licencia";
//                            ListaAlumnos.Valor13 = (itemA.fgLicencia == true) ? "SI" : "NO";
//                        }
//                        else if (listacaCampos[i] == 13)
//                        {
//                            TituloColumna13 = "Tipo de Egresado";
//                            ListaAlumnos.Valor13 = (itemA.tpEgresado == "T") ? "TItulado" : "Pasante";
//                        }
//                        else if (listacaCampos[i] == 14)
//                        {
//                            TituloColumna13 = "Fallecido";
//                            ListaAlumnos.Valor13 = (itemA.fgFallecido == true) ? "SI" : "NO";
//                        }
//                        else if (listacaCampos[i] == 15)
//                        {
//                            TituloColumna13 = "Cumpleaños";
//                            ListaAlumnos.Valor13 = Convert.ToDateTime(itemA.feNacimiento).ToShortDateString();
//                        }
//                        else if (listacaCampos[i] == 16)
//                        {
//                            TituloColumna13 = "Última fecha de actualización";
//                            ListaAlumnos.Valor13 = Convert.ToDateTime(itemA.feActualizacion).ToShortDateString();
//                        }
//                    }
//                    else if (i == 13)
//                    {
//                        if (listacaCampos[i] == 1)
//                        {
//                            TituloColumna14 = "Nombre Completo";
//                            ListaAlumnos.Valor14 = itemA.Personas.nbCompleto;
//                        }
//                        else if (listacaCampos[i] == 2)
//                        {
//                            TituloColumna14 = "Estado Civil";
//                            ListaAlumnos.Valor14 = itemA.CatEstadosCiviles.nbEstadoCivil;
//                        }
//                        else if (listacaCampos[i] == 3)
//                        {
//                            TituloColumna14 = "Edad";
//                            var edad = DateTime.Now.Year - ((DateTime)itemA.feNacimiento).Date.Year;
//                            ListaAlumnos.Valor14 = edad.ToString() + " Años";
//                        }
//                        else if (listacaCampos[i] == 4)
//                        {
//                            TituloColumna14 = "Teléfono";
//                            ListaAlumnos.Valor14 = (itemA.Personas.MediosContactos.FirstOrDefault(x => x.idTipoMedioContacto == 2) != null) ? itemA.Personas.MediosContactos.FirstOrDefault(x => x.idTipoMedioContacto == 2).desMedioContacto : "S/N";
//                        }
//                        else if (listacaCampos[i] == 5)
//                        {
//                            TituloColumna14 = "Correo";
//                            ListaAlumnos.Valor14 = (itemA.Personas.MediosContactos.FirstOrDefault(x => x.idTipoMedioContacto == 1) != null) ? itemA.Personas.MediosContactos.FirstOrDefault(x => x.idTipoMedioContacto == 1).desMedioContacto : "S/C";
//                        }
//                        else if (listacaCampos[i] == 6)
//                        {
//                            TituloColumna14 = "Género";
//                            ListaAlumnos.Valor14 = itemA.Personas.CatGeneros.nbGenero;
//                        }
//                        else if (listacaCampos[i] == 7)
//                        {
//                            TituloColumna14 = "Licenciatura";
//                            ListaAlumnos.Valor14 = itemA.FormacionesAcademicas.OrderByDescending(x => x.idLicenciatura).FirstOrDefault().Licenciaturas.nbLicenciatura;
//                        }
//                        else if (listacaCampos[i] == 8)
//                        {
//                            TituloColumna14 = "Religión";
//                            ListaAlumnos.Valor14 = itemA.CatReligion.nbReligion;
//                        }
//                        else if (listacaCampos[i] == 9)
//                        {
//                            TituloColumna14 = "Estado";
//                            ListaAlumnos.Valor14 = itemA.Direcciones.nbEstado;
//                        }
//                        else if (listacaCampos[i] == 10)
//                        {
//                            TituloColumna14 = "trabaja";
//                            ListaAlumnos.Valor14 = (itemA.fgTrabajaActualmente == true) ? "SI" : "NO";
//                        }
//                        else if (listacaCampos[i] == 11)
//                        {
//                            TituloColumna14 = "Tipo de Sangre";
//                            ListaAlumnos.Valor14 = itemA.CatTiposSangre.nbTipoSangre;
//                        }
//                        else if (listacaCampos[i] == 12)
//                        {
//                            TituloColumna14 = "Licencia";
//                            ListaAlumnos.Valor14 = (itemA.fgLicencia == true) ? "SI" : "NO";
//                        }
//                        else if (listacaCampos[i] == 13)
//                        {
//                            TituloColumna14 = "Tipo de Egresado";
//                            ListaAlumnos.Valor14 = (itemA.tpEgresado == "T") ? "TItulado" : "Pasante";
//                        }
//                        else if (listacaCampos[i] == 14)
//                        {
//                            TituloColumna14 = "Fallecido";
//                            ListaAlumnos.Valor14 = (itemA.fgFallecido == true) ? "SI" : "NO";
//                        }
//                        else if (listacaCampos[i] == 15)
//                        {
//                            TituloColumna14 = "Cumpleaños";
//                            ListaAlumnos.Valor14 = Convert.ToDateTime(itemA.feNacimiento).ToShortDateString();
//                        }
//                        else if (listacaCampos[i] == 16)
//                        {
//                            TituloColumna14 = "Última fecha de actualización";
//                            ListaAlumnos.Valor14 = Convert.ToDateTime(itemA.feActualizacion).ToShortDateString();
//                        }
//                    }
//                    else if (i == 14)
//                    {
//                        if (listacaCampos[i] == 1)
//                        {
//                            TituloColumna15 = "Nombre Completo";
//                            ListaAlumnos.Valor15 = itemA.Personas.nbCompleto;
//                        }
//                        else if (listacaCampos[i] == 2)
//                        {
//                            TituloColumna15 = "Estado Civil";
//                            ListaAlumnos.Valor15 = itemA.CatEstadosCiviles.nbEstadoCivil;
//                        }
//                        else if (listacaCampos[i] == 3)
//                        {
//                            TituloColumna15 = "Edad";
//                            var edad = DateTime.Now.Year - ((DateTime)itemA.feNacimiento).Date.Year;
//                            ListaAlumnos.Valor15 = edad.ToString() + " Años";
//                        }
//                        else if (listacaCampos[i] == 4)
//                        {
//                            TituloColumna15 = "Teléfono";
//                            ListaAlumnos.Valor15 = (itemA.Personas.MediosContactos.FirstOrDefault(x => x.idTipoMedioContacto == 2) != null) ? itemA.Personas.MediosContactos.FirstOrDefault(x => x.idTipoMedioContacto == 2).desMedioContacto : "S/N";
//                        }
//                        else if (listacaCampos[i] == 5)
//                        {
//                            TituloColumna15 = "Correo";
//                            ListaAlumnos.Valor15 = (itemA.Personas.MediosContactos.FirstOrDefault(x => x.idTipoMedioContacto == 1) != null) ? itemA.Personas.MediosContactos.FirstOrDefault(x => x.idTipoMedioContacto == 1).desMedioContacto : "S/C";
//                        }
//                        else if (listacaCampos[i] == 6)
//                        {
//                            TituloColumna15 = "Género";
//                            ListaAlumnos.Valor15 = itemA.Personas.CatGeneros.nbGenero;
//                        }
//                        else if (listacaCampos[i] == 7)
//                        {
//                            TituloColumna15 = "Licenciatura";
//                            ListaAlumnos.Valor15 = itemA.FormacionesAcademicas.OrderByDescending(x => x.idLicenciatura).FirstOrDefault().Licenciaturas.nbLicenciatura;
//                        }
//                        else if (listacaCampos[i] == 8)
//                        {
//                            TituloColumna15 = "Religión";
//                            ListaAlumnos.Valor15 = itemA.CatReligion.nbReligion;
//                        }
//                        else if (listacaCampos[i] == 9)
//                        {
//                            TituloColumna15 = "Estado";
//                            ListaAlumnos.Valor15 = itemA.Direcciones.nbEstado;
//                        }
//                        else if (listacaCampos[i] == 10)
//                        {
//                            TituloColumna15 = "trabaja";
//                            ListaAlumnos.Valor15 = (itemA.fgTrabajaActualmente == true) ? "SI" : "NO";
//                        }
//                        else if (listacaCampos[i] == 11)
//                        {
//                            TituloColumna15 = "Tipo de Sangre";
//                            ListaAlumnos.Valor15 = itemA.CatTiposSangre.nbTipoSangre;
//                        }
//                        else if (listacaCampos[i] == 12)
//                        {
//                            TituloColumna15 = "Licencia";
//                            ListaAlumnos.Valor15 = (itemA.fgLicencia == true) ? "SI" : "NO";
//                        }
//                        else if (listacaCampos[i] == 13)
//                        {
//                            TituloColumna15 = "Tipo de Egresado";
//                            ListaAlumnos.Valor15 = (itemA.tpEgresado == "T") ? "TItulado" : "Pasante";
//                        }
//                        else if (listacaCampos[i] == 14)
//                        {
//                            TituloColumna15 = "Fallecido";
//                            ListaAlumnos.Valor15 = (itemA.fgFallecido == true) ? "SI" : "NO";
//                        }
//                        else if (listacaCampos[i] == 15)
//                        {
//                            TituloColumna15 = "Cumpleaños";
//                            ListaAlumnos.Valor15 = Convert.ToDateTime(itemA.feNacimiento).ToShortDateString();
//                        }
//                        else if (listacaCampos[i] == 16)
//                        {
//                            TituloColumna15 = "Última fecha de actualización";
//                            ListaAlumnos.Valor15 = Convert.ToDateTime(itemA.feActualizacion).ToShortDateString();
//                        }
//                    }
//                    else if (i == 15)
//                    {
//                        if (listacaCampos[i] == 1)
//                        {
//                            TituloColumna16 = "Nombre Completo";
//                            ListaAlumnos.Valor16 = itemA.Personas.nbCompleto;
//                        }
//                        else if (listacaCampos[i] == 2)
//                        {
//                            TituloColumna16 = "Estado Civil";
//                            ListaAlumnos.Valor16 = itemA.CatEstadosCiviles.nbEstadoCivil;
//                        }
//                        else if (listacaCampos[i] == 3)
//                        {
//                            TituloColumna16 = "Edad";
//                            var edad = DateTime.Now.Year - ((DateTime)itemA.feNacimiento).Date.Year;
//                            ListaAlumnos.Valor16 = edad.ToString() + " Años";
//                        }
//                        else if (listacaCampos[i] == 4)
//                        {
//                            TituloColumna16 = "Teléfono";
//                            ListaAlumnos.Valor16 = (itemA.Personas.MediosContactos.FirstOrDefault(x => x.idTipoMedioContacto == 2) != null) ? itemA.Personas.MediosContactos.FirstOrDefault(x => x.idTipoMedioContacto == 2).desMedioContacto : "S/N";
//                        }
//                        else if (listacaCampos[i] == 5)
//                        {
//                            TituloColumna16 = "Correo";
//                            ListaAlumnos.Valor16 = (itemA.Personas.MediosContactos.FirstOrDefault(x => x.idTipoMedioContacto == 1) != null) ? itemA.Personas.MediosContactos.FirstOrDefault(x => x.idTipoMedioContacto == 1).desMedioContacto : "S/C";
//                        }
//                        else if (listacaCampos[i] == 6)
//                        {
//                            TituloColumna16 = "Género";
//                            ListaAlumnos.Valor16 = itemA.Personas.CatGeneros.nbGenero;
//                        }
//                        else if (listacaCampos[i] == 7)
//                        {
//                            TituloColumna16 = "Licenciatura";
//                            ListaAlumnos.Valor16 = itemA.FormacionesAcademicas.OrderByDescending(x => x.idLicenciatura).FirstOrDefault().Licenciaturas.nbLicenciatura;
//                        }
//                        else if (listacaCampos[i] == 8)
//                        {
//                            TituloColumna16 = "Religión";
//                            ListaAlumnos.Valor16 = itemA.CatReligion.nbReligion;
//                        }
//                        else if (listacaCampos[i] == 9)
//                        {
//                            TituloColumna16 = "Estado";
//                            ListaAlumnos.Valor16 = itemA.Direcciones.nbEstado;
//                        }
//                        else if (listacaCampos[i] == 10)
//                        {
//                            TituloColumna16 = "trabaja";
//                            ListaAlumnos.Valor16 = (itemA.fgTrabajaActualmente == true) ? "SI" : "NO";
//                        }
//                        else if (listacaCampos[i] == 11)
//                        {
//                            TituloColumna16 = "Tipo de Sangre";
//                            ListaAlumnos.Valor16 = itemA.CatTiposSangre.nbTipoSangre;
//                        }
//                        else if (listacaCampos[i] == 12)
//                        {
//                            TituloColumna16 = "Licencia";
//                            ListaAlumnos.Valor16 = (itemA.fgLicencia == true) ? "SI" : "NO";
//                        }
//                        else if (listacaCampos[i] == 13)
//                        {
//                            TituloColumna16 = "Tipo de Egresado";
//                            ListaAlumnos.Valor16 = (itemA.tpEgresado == "T") ? "TItulado" : "Pasante";
//                        }
//                        else if (listacaCampos[i] == 14)
//                        {
//                            TituloColumna16 = "Fallecido";
//                            ListaAlumnos.Valor16 = (itemA.fgFallecido == true) ? "SI" : "NO";
//                        }
//                        else if (listacaCampos[i] == 15)
//                        {
//                            TituloColumna16 = "Cumpleaños";
//                            ListaAlumnos.Valor16 = Convert.ToDateTime(itemA.feNacimiento).ToShortDateString();
//                        }
//                        else if (listacaCampos[i] == 16)
//                        {
//                            TituloColumna16 = "Última fecha de actualización";
//                            ListaAlumnos.Valor16 = Convert.ToDateTime(itemA.feActualizacion).ToShortDateString();
//                        }
//                    }

//                }

//                ListaAlumnosReporte.Add(ListaAlumnos);

//            }

//            ListaAlumnosReporte.ToList().ForEach(a =>
//            {
//                var row = dt.NewRow();

//                row["Valor1"] = a.Valor1;
//                row["Valor2"] = a.Valor2;
//                row["Valor3"] = a.Valor3;
//                row["Valor4"] = a.Valor4;
//                row["Valor5"] = a.Valor5;
//                row["Valor6"] = a.Valor6;
//                row["Valor7"] = a.Valor7;
//                row["Valor8"] = a.Valor8;
//                row["Valor9"] = a.Valor9;
//                row["Valor10"] = a.Valor10;
//                row["Valor11"] = a.Valor11;
//                row["Valor12"] = a.Valor12;
//                row["Valor13"] = a.Valor13;
//                row["Valor14"] = a.Valor14;
//                row["Valor15"] = a.Valor15;
//                row["Valor16"] = a.Valor16;
//                dt.Rows.Add(row);
//            });

//            string path = string.Empty;
//            LocalReport localReport = new LocalReport();
//            path = Path.Combine(Server.MapPath("~/Reportes/"), "Reportes.rdlc");

//            localReport.ReportPath = path;
//            ReportDataSource reporte = new ReportDataSource("Reportes1", dt);
//            localReport.DataSources.Add(reporte);

//            ReportParameter Titulo1 = new ReportParameter("Titulo1", TituloColumna1);
//            ReportParameter Titulo2 = new ReportParameter("Titulo2", TituloColumna2);
//            ReportParameter Titulo3 = new ReportParameter("Titulo3", TituloColumna3);
//            ReportParameter Titulo4 = new ReportParameter("Titulo4", TituloColumna4);
//            ReportParameter Titulo5 = new ReportParameter("Titulo5", TituloColumna5);
//            ReportParameter Titulo6 = new ReportParameter("Titulo6", TituloColumna6);
//            ReportParameter Titulo7 = new ReportParameter("Titulo7", TituloColumna7);
//            ReportParameter Titulo8 = new ReportParameter("Titulo8", TituloColumna8);
//            ReportParameter Titulo9 = new ReportParameter("Titulo9", TituloColumna9);
//            ReportParameter Titulo10 = new ReportParameter("Titulo10", TituloColumna10);
//            ReportParameter Titulo11 = new ReportParameter("Titulo11", TituloColumna11);
//            ReportParameter Titulo12 = new ReportParameter("Titulo12", TituloColumna12);
//            ReportParameter Titulo13 = new ReportParameter("Titulo13", TituloColumna13);
//            ReportParameter Titulo14 = new ReportParameter("Titulo14", TituloColumna14);
//            ReportParameter Titulo15 = new ReportParameter("Titulo15", TituloColumna15);
//            ReportParameter Titulo16 = new ReportParameter("Titulo16", TituloColumna16);
//            ReportParameter FechaReporte = new ReportParameter("FechaReporte", DateTime.Now.ToString());

//            //Parametros a enviar en el reporte
//            localReport.SetParameters(Titulo1);
//            localReport.SetParameters(Titulo2);
//            localReport.SetParameters(Titulo3);
//            localReport.SetParameters(Titulo4);
//            localReport.SetParameters(Titulo5);
//            localReport.SetParameters(Titulo6);
//            localReport.SetParameters(Titulo7);
//            localReport.SetParameters(Titulo8);
//            localReport.SetParameters(Titulo9);
//            localReport.SetParameters(Titulo10);
//            localReport.SetParameters(Titulo11);
//            localReport.SetParameters(Titulo12);
//            localReport.SetParameters(Titulo13);
//            localReport.SetParameters(Titulo14);
//            localReport.SetParameters(Titulo15);
//            localReport.SetParameters(Titulo16);
//            localReport.SetParameters(FechaReporte);

//            string reportType = "EXCELOPENXML";
//            string mimeType;
//            string encoding;
//            string fileNameExtension;
//            Warning[] warnings;
//            string[] streams;
//            byte[] renderedBytes;
//            string fileName = "";

//            renderedBytes = localReport.Render(reportType, "", out mimeType, out encoding, out fileNameExtension, out streams, out warnings);
//            fileName = "Indicadores.xlsx";

//            return File(renderedBytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", fileName);
//        }

//    }
//}