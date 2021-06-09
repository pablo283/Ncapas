using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

namespace MVC.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Departamento
        [HttpGet]
        public ActionResult GetAll()
        {
            ML.Result result = BL.Usuario.GetAll();

            ML.Usuario usuario = new ML.Usuario();
            usuario.Usuarios = result.Objects;

            return View(usuario);

        }

        [HttpGet]//Mostrar el formulario
        public ActionResult Form(int? IdUsuario) //Add , UpdateC:\Users\ALIEN 16\Documents\PGonzalez\ejemploMVC\JTorresEjemploProgramacionNCapas\PL_MVC2\Scripts\
        {
            ML.Usuario usuario = new ML.Usuario();
            ML.Result resultRol = BL.Rol.GetAllEF();
            usuario.Rol = new ML.Rol();
            usuario.Rol.Roles = resultRol.Objects;
            

            if (IdUsuario == null)//Add
            {
                return View(usuario);
            }
            else //Update
            {
                ML.Result result = BL.Usuario.GetByIdEF(IdUsuario.Value);

                if (result.Correct)
                {
                    usuario.IdUsuario = ((ML.Usuario)result.Object).IdUsuario;
                    usuario.Nombre = ((ML.Usuario)result.Object).Nombre;
                    usuario.ApellidoPaterno = ((ML.Usuario)result.Object).ApellidoPaterno;
                    usuario.ApellidoMaterno= ((ML.Usuario)result.Object).ApellidoMaterno;
                    usuario.Contrasenia = ((ML.Usuario)result.Object).Contrasenia;
                    usuario.NumeroCelular = ((ML.Usuario)result.Object).NumeroCelular;
                    usuario.Email = ((ML.Usuario)result.Object).Email;
                    usuario.FechaNacimiento = ((ML.Usuario)result.Object).FechaNacimiento;
                    usuario.Sexo=((ML.Usuario)result.Object).Sexo;
                    usuario.Estatus = ((ML.Usuario)result.Object).Estatus;
                    usuario.IdDireccion = ((ML.Usuario)result.Object).IdDireccion;
                    usuario.Rol.IdRol = ((ML.Usuario)result.Object).Rol.IdRol;

                    return View(usuario);
                }
                else
                {
                    ViewBag.Message = result.ErrorMessage;
                    return PartialView("Modal");
                }
            }


        }

        public byte[] ConvertToBytes(HttpPostedFileBase Imagen)
        {
            byte[] data = null;
            System.IO.BinaryReader reader = new System.IO.BinaryReader(Imagen.InputStream);
            data = reader.ReadBytes((int)Imagen.ContentLength);

            return data;
        }



        [HttpPost] //Recibir datos del formulario
        public ActionResult Form(ML.Usuario usuario)
        {
            // ML.Materia materia = new ML.Materia();
            ML.Result result = new ML.Result();

           /* HttpPostedFileBase file = Request.Files["ImagenData"];
            if (file.ContentLength > 0)
            {
                producto.Imagen = ConvertToBytes(file);
            }*/

            if (usuario.IdUsuario == 0)//Add
            {
                result = BL.Usuario.Add(usuario);
                ViewBag.Message = "El usuario se agregó correctamente ";
            }
            else //Update
            {
                //BL.Materia.Update();
                result = BL.Usuario.Update(usuario);

                ViewBag.Message = "El usuario se actualizó correctamente ";
            }

            if (!result.Correct)
            {
                ViewBag.Message = "No se pudo agregar correctamente el usuario " + result.ErrorMessage;
            }

            return PartialView("Modal");
        }

        [HttpGet]
        public ActionResult Delete(int IdUsuario)
        {

            ML.Result result = BL.Usuario.Delete(IdUsuario);

            return RedirectToAction("GetAll");
        }

       /* public JsonResult GetDepartamento(int IdArea) //para drop down list cascade
        {
            var result = BL.Departamento.GetByIdArea(IdArea);
            List<SelectListItem> opciones = new List<SelectListItem>();

            opciones.Add(new SelectListItem { Text = "--Seleccione una opción--", Value = "0" });

            if (result.Objects != null)
            {
                foreach (ML.Departamento departamento in result.Objects)
                {
                    opciones.Add(new SelectListItem { Text = departamento.Nombre.ToString(), Value = departamento.IdDepartamento.ToString() });
                }
            }

            return Json(new SelectList(opciones, "Value", "Text", JsonRequestBehavior.AllowGet));
        }*/


        public ActionResult UpdateStatus(int IdUsuario, bool Estatus)
        {
            ML.Result result = BL.Usuario.UpdateStatus(IdUsuario, Estatus);
            return PartialView("Modal");
        }


        [HttpPost]
        public ActionResult GetAll(ML.Usuario usuario) //datos para la búsqueda abierta
        {
            ML.Result result = new ML.Result();

	        if (usuario.Nombre == null)  usuario.Nombre ="";
	        if (usuario.ApellidoPaterno == null) usuario.ApellidoPaterno="";
	        if (usuario.ApellidoMaterno == null) usuario.ApellidoMaterno="";
            result = BL.Usuario.GetBusquedaAbierta(usuario.Nombre, usuario.ApellidoPaterno, usuario.ApellidoMaterno);
            usuario.Usuarios = result.Objects;


            return View(usuario);

        }

        [HttpPost]
        public ActionResult Index(HttpPostedFileBase file) ///funcion para leer y añadir usuarios desde txt
        {
            if (file != null && file.ContentLength > 0)
            {
                string Ruta = Server.MapPath("~/ArchivoCargaUsuarios");           ///ruta 
                //string Nombre = Path.GetFileNameWithoutExtension(file.FileName); ///nombre carga
                string Nombre = file.FileName;                                              ///carga.txt
                string datetime = DateTime.Now.ToString("yyyyMMddHHmmss");      //fecha y hora

                string path = Ruta + datetime + Nombre;

                // string path = Path.Combine(Server.MapPath("~/ArchivoCargaUsuarios"),Path.GetFileName(file.FileName));
                file.SaveAs(path);
                ViewBag.Message = "File uploaded successfully";
               //file.inputstring sin guardarlo 
                     string linea;
                     string[] Datos;
           
                    using (StreamReader file2 = new StreamReader(@path))
                    {
                        while ((linea = file2.ReadLine())!= null)
                        {
                            Datos = linea.Split('|');
                            ML.Usuario usuario = new ML.Usuario();
                            usuario.IdUsuario= int.Parse(Datos[0]);
                            usuario.Nombre = Datos[1];
                            usuario.ApellidoPaterno = Datos[2];
                            usuario.ApellidoMaterno = Datos[3];
                            usuario.Contrasenia = Datos[4];
                            usuario.NumeroCelular = Datos[5];
                            usuario.Email = Datos[6];
                            usuario.FechaNacimiento = DateTime.Parse(Datos[7]);
                            usuario.Sexo = Datos[8];
                            usuario.Estatus = bool.Parse(Datos[9]);
                            usuario.IdDireccion = int.Parse(Datos[10]);
                            usuario.Rol = new ML.Rol();
                            usuario.Rol.IdRol = int.Parse(Datos[11]);
                            BL.Usuario.Add(usuario);
                        }
                        file2.Close();
                    }
            }
            else
            {
                ViewBag.Message = "You have not specified a file.";
            }
                
            return RedirectToAction("GetAll");
        }

    }
}