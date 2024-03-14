﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity.Validation;
using CRME.Models;
using PagedList;
using System.Web.Script.Serialization;
using System.IO;

namespace CRME.Controllers
{
    public class UsuarioViewController : Controller
    {
        private SIRE_Context db = new SIRE_Context();

        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "UsuarioView");
                ViewBag.HiddenMenu = 1;
            }
            return View();
        }

        public ActionResult SaveUsuarios(cat_sistemas usuario)
        {
            Auditoria auditoria = new Auditoria();
            var serializerCat = new JavaScriptSerializer();
            bool success = false;
            string mensajefound = "";
            var found = db.cat_sistemas.FirstOrDefault(x => x.username == usuario.username && x.sistemas_ID != usuario.sistemas_ID);

            if (found != null)
            {
                mensajefound = "¡Ya existe un usuario que coincide con el nombre de usuario ingresado!";

            }
            else
            {
                if (usuario.sistemas_ID == 0)
                {
                    try
                    {
                        cat_sistemas Usuario = new cat_sistemas();
                        
                        //Usuarios
                        Usuario.nombre = usuario.nombre;
                        Usuario.apellido_paterno = usuario.apellido_paterno;
                        Usuario.apellido_materno = usuario.apellido_materno;
                        Usuario.username = usuario.username;
                        Usuario.perfil_ID = usuario.perfil_ID;                        
                        var pathCat = serializerCat.Deserialize<string>(usuario.foto);
                        Usuario.foto = "~/Upload/Usuarios/" + pathCat;
                        Usuario.estatus_ID = 1;
                        Usuario.SetPassword(usuario.password);                                               

                        db.cat_sistemas.Add(Usuario);
                        

                        if (db.SaveChanges() > 0)
                        {
                            success = true;
                        }

                        auditoria.modulo = "Usuario Registro";
                        auditoria.idregistro = Usuario.sistemas_ID;
                        auditoria.accion = "Registro";
                        auditoria.tabla = "cat_sistemas";
                        auditoria.idusuario = Auth.Usuario.sistemas_ID;
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

                      cat_sistemas   Usuario = db.cat_sistemas.Find(usuario.sistemas_ID);

                        //Usuarios
                        Usuario.nombre = usuario.nombre;
                        Usuario.apellido_paterno = usuario.apellido_paterno;
                        Usuario.apellido_materno = usuario.apellido_materno;
                        Usuario.username = usuario.username;
                        Usuario.perfil_ID = usuario.perfil_ID;
                        if (Usuario.foto == usuario.foto)
                        {
                            Usuario.foto = usuario.foto;
                        }
                        else
                        {
                            var pathCat = serializerCat.Deserialize<string>(usuario.foto);
                            Usuario.foto = "~/Upload/Usuarios/" + pathCat;
                        }                        

                        int lengthfoto1 = Usuario.foto.Length;
                        var quitar1 = Usuario.foto.Remove(1, lengthfoto1 - 1);
                        if (quitar1 == "~")
                        {
                            Usuario.foto = Usuario.foto;
                        }

                        ////Usuarios
                        //Usuario.idPerfil = 1;
                        if (Usuario.password != "QWERTY123*")
                        {
                            Usuario.SetPassword(usuario.password);
                        }
                        //Usuario.feVigencia = usuario.feVigencia;
                        //Usuario.feRegistro = DateTime.Now;
                        //Usuario.idEstatus = usuario.idEstatus;
                        //Usuario.nbUsuario = usuario.nbUsuario;
                        //db.Entry(personas).State = EntityState.Modified;
                        db.Entry(Usuario).State = EntityState.Modified;


                        if (db.SaveChanges() > 0)
                        {
                            success = true;
                        }

                        auditoria.modulo = "Usuario Modificacion";
                        auditoria.idregistro = usuario.sistemas_ID;
                        auditoria.accion = "Modificacion";
                        auditoria.tabla = "cat_sistemas";
                        auditoria.idusuario = Auth.Usuario.sistemas_ID;
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

            return Json(new { success = success, mensajefound }, JsonRequestBehavior.AllowGet);

        }
        public ActionResult _Formulario(long? idUsuario)
        {
            //codigo para agregar y editar usuarios
            //UsuariosPersonas Personas = new UsuariosPersonas();
            cat_sistemas Usuarios = new cat_sistemas();
            //Personas Persona = new Personas();

            if (idUsuario != null)
            {

                ViewBag.edit = 1;
                Usuarios = db.cat_sistemas.Find(idUsuario);

                Usuarios.password = "QWERTY123*";
                ViewBag.idEstatus = new SelectList(db.Cat_Estatus.ToList(), "Id", "Estatus", Usuarios.estatus_ID);
                ViewBag.idPerfil = new SelectList(db.cat_perfiles.ToList(), "perfil_ID", "perfil", Usuarios.perfil_ID);
                //ViewBag.idGenero = new SelectList(db.CatGeneros.ToList(), "idGenero", "nbGenero", Usuarios.Personas.idGenero);
            }
            else
            {
                ViewBag.idEstatus = new SelectList(db.Cat_Estatus.ToList(), "Id", "Estatus");                
                ViewBag.idPerfil = new SelectList(db.cat_perfiles.ToList(), "perfil_ID", "perfil");
            }


            return PartialView(Usuarios);
        }
        public ActionResult _TablaUsuarios(int? page, string filtroBusqueda)
        {
            const int pageSize = 10;
            int pageNumber = (page ?? 1);

            //obtener lista de usuarios
            List<cat_sistemas> Usuarios = new List<cat_sistemas>();

            Usuarios = db.cat_sistemas.Where(x => x.estatus_ID == 1).OrderBy(x => x.nombre).ToList();
            if (!string.IsNullOrEmpty(filtroBusqueda))
            {
                Usuarios = Usuarios.Where(x => x.nombre.ToUpper().Contains(filtroBusqueda.ToUpper().Trim()) || x.apellido_paterno.ToUpper().Contains(filtroBusqueda.ToUpper().Trim())
                || x.apellido_materno.ToUpper().Contains(filtroBusqueda.ToUpper().Trim())).ToList();
            }
            ViewBag.filtro = filtroBusqueda;
            return PartialView(Usuarios.ToPagedList(pageNumber, pageSize));
        }
        public ActionResult DeleteUsuario(long? idUsuario)
        {
            Auditoria auditoria = new Auditoria();
            bool success = false; ;
            string mensajefound = "";

            try
            {
                var Usuario = db.cat_sistemas.Find(idUsuario);
                //var Personas = db.Personas.Find(Usuario.idPersona);
                //var MediosContacto = db.MediosContactos.Find(Personas.MediosContactos);
                Usuario.estatus_ID = 2;

                db.Entry(Usuario).State = EntityState.Modified;
                //db.Entry(Personas).State = EntityState.Deleted;
                //db.Entry(MediosContacto).State = EntityState.Deleted;

                auditoria.modulo = "Usuarios";
                auditoria.idregistro = Usuario.sistemas_ID;
                auditoria.accion = "BAJA";
                auditoria.tabla = "cat_sistemas";
                auditoria.idusuario = Auth.Usuario.sistemas_ID;
                auditoria.fecha = DateTime.Now;

                db.Auditoria.Add(auditoria);

                if (db.SaveChanges() > 0)
                {
                    success = true;
                }
            }
            catch (Exception ex)
            {
                mensajefound = "Ocurrio un error al eliminar la regla";
            }


            return Json(new { success = success, mensajefound }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult CargarLogo()
        {
            bool success = false;
            string error = "";
            var savedFileNameDownload = "";
            string savedFileName = "";
            string completeName = "";
            try
            {
                foreach (string file in Request.Files)
                {

                    HttpPostedFileBase hpf = Request.Files[file] as HttpPostedFileBase;
                    string name = Path.GetRandomFileName();
                    string extension = Path.GetExtension(Path.GetFileName(hpf.FileName));
                    completeName = name + extension;
                    savedFileName = Path.Combine(Server.MapPath("~/Upload/Usuarios/"), completeName);
                    hpf.SaveAs(savedFileName);
                    success = true;

                }
            }
            catch (Exception ex)
            {
                error = "Archivo Invalido, Error al procesar el archivo";
            }

            return Json(new { success = success, error = error, savedFileName = completeName }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult EliminarLogo(string path)
        {
            bool success = false;
            try
            {
                var serializer = new JavaScriptSerializer();
                var pathh = serializer.Deserialize<string>(path);
                var rutapath = "~/Upload/Usuarios/" + pathh;
                if (System.IO.File.Exists(Server.MapPath(rutapath)))
                {
                    try
                    {
                        System.IO.File.Delete(Server.MapPath(rutapath));
                        success = true;
                    }
                    catch (System.IO.IOException e)
                    {
                        Console.WriteLine(e.Message);
                    }

                }

            }
            catch (Exception exp)
            {
                ViewBag.ResultMessage = "Error occured." + exp;
            }
            return Json(new { success = success }, JsonRequestBehavior.AllowGet);
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