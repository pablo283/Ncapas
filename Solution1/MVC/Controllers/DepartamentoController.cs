using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

namespace MVC.Controllers
{
    public class DepartamentoController : Controller
    {
        [HttpGet]
        public ActionResult GetAll() //webAPI
        {
            ML.Result result = BL.Departamento.GetAllWebAPI();
            ML.Departamento departamento = new ML.Departamento();
            departamento.Departamentos = result.Objects;

            return View(departamento);
                
        
        }
        // GET: Departamento
        /*[HttpGet]
        public ActionResult GetAll()
        {
            ML.Result result = BL.Departamento.GetAllEF();

            ML.Departamento departamento = new ML.Departamento();
            departamento.Departamentos = result.Objects;

            return View(departamento);

        }*/

        [HttpGet]//Mostrar el formulario
        public ActionResult Form(int? IdDepartamento) //Add , UpdateC:\Users\ALIEN 16\Documents\PGonzalez\ejemploMVC\JTorresEjemploProgramacionNCapas\PL_MVC2\Scripts\
        {
            ML.Departamento departamento = new ML.Departamento();

            ML.Result resultAreas = BL.Area.GetAllEF();
            departamento.Area = new ML.Area();
            departamento.Area.Areas = resultAreas.Objects;
            //ML.Result resultAreas= BL.Area.GetAll();


            //materia.Semestre = new ML.Semestre();
            //materia.Semestre.Semestres = resultSemestres.Objects;

            //materia.Area = new ML.Area();
            //materia.Area.Areas = resultAreas.Objects;


            if (IdDepartamento == null)//Add
            {
                return View(departamento);
            }
            else //Update
            {
                ML.Result result = BL.Departamento.GetByIdWebAPI(IdDepartamento.Value);

                if (result.Correct)
                {
                    departamento.IdDepartamento = ((ML.Departamento)result.Object).IdDepartamento;
                    departamento.Nombre = ((ML.Departamento)result.Object).Nombre;
                 
                    departamento.Area.IdArea = ((ML.Departamento)result.Object).Area.IdArea;
                   
                    //materia.Semestre.IdSemestre = ((ML.Materia)result.Object).Semestre.IdSemestre;


                    return View(departamento);
                }
                else
                {
                    ViewBag.Message = result.ErrorMessage;
                    return PartialView("Modal");
                }
            }


        }

        //public byte[] ConvertToBytes(HttpPostedFileBase Imagen)
        //{
        //    byte[] data = null;
        //    System.IO.BinaryReader reader = new System.IO.BinaryReader(Imagen.InputStream);
        //    data = reader.ReadBytes((int)Imagen.ContentLength);

        //    return data;
        //}



        [HttpPost] //Recibir datos del formulario
        public ActionResult Form(ML.Departamento departamento)
        {
            // ML.Materia materia = new ML.Materia();
            ML.Result result = new ML.Result();

            //HttpPostedFileBase file = Request.Files["ImagenData"];
            //if (file.ContentLength > 0)
            //{
            //    materia.Imagen = ConvertToBytes(file);
            //}

            if (departamento.IdDepartamento == 0)//Add
            {
                result = BL.Departamento.AddWebAPI(departamento);
                ViewBag.Message = "El departamento se agregó correctamente ";
            }
            else //Update
            {
                 
                result = BL.Departamento.UpdateWebAPI(departamento);

                ViewBag.Message = "El departamento se actualizó correctamente ";
            }

            if (!result.Correct)
            {
                ViewBag.Message = "No se pudo agregar correctamente el departamento " + result.ErrorMessage;
            }

            return PartialView("Modal");
        }

        [HttpGet]
        public ActionResult Delete(int IdDepartamento)
        {

            ML.Result result = BL.Departamento.DeleteWebAPI(IdDepartamento);

            return RedirectToAction("GetAll");
        }

      
	}
}