using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class ProductoController : Controller
    {
        // GET: Departamento
        [HttpGet]
        public ActionResult GetAll()
        {
            ML.Result result = BL.Producto.GetAllWebAPI();

            ML.Producto producto = new ML.Producto();
            producto.Productos = result.Objects;

            return View(producto);

        }

        [HttpGet]//Mostrar el formulario
        public ActionResult Form(int? IdProducto) //Add , UpdateC:\Users\ALIEN 16\Documents\PGonzalez\ejemploMVC\JTorresEjemploProgramacionNCapas\PL_MVC2\Scripts\
        {
            ML.Producto producto = new ML.Producto();
            //para utilizar drop list de proveedor
            ML.Result resultProveedor = BL.Proveedor.GetAllEF();
            producto.Proveedor = new ML.Proveedor();
            producto.Proveedor.Proveedores = resultProveedor.Objects;
            //para utilizar drop list de departamento
            ML.Result resultDepartamento = BL.Departamento.GetAllEF();
            producto.Departamento = new ML.Departamento();
            producto.Departamento.Departamentos = resultDepartamento.Objects;
            //para utilizar drop list de area       
            ML.Result resultAreas = BL.Area.GetAllEF();
            producto.Departamento.Area = new ML.Area();
            producto.Departamento.Area.Areas = resultAreas.Objects;

            if (IdProducto == null)//Add
            {
                return View(producto);
            }
            else //Update
            {
                ML.Result result = BL.Producto.GetByIdWebAPI(IdProducto.Value);

                if (result.Correct)
                {
                    producto.IdProducto = ((ML.Producto)result.Object).IdProducto;
                    producto.Nombre = ((ML.Producto)result.Object).Nombre;
                    producto.PrecioUnitario = ((ML.Producto)result.Object).PrecioUnitario;
                    producto.Stock =        ((ML.Producto)result.Object).Stock;  
                    producto.Descripcion =  ((ML.Producto)result.Object).Descripcion;
                    producto.Imagen = ((ML.Producto)result.Object).Imagen; 
                    producto.Proveedor.IdProveedor = ((ML.Producto)result.Object).Proveedor.IdProveedor;                    
                    producto.Departamento.IdDepartamento = ((ML.Producto)result.Object).Departamento.IdDepartamento;
                    producto.Departamento.Area.IdArea = ((ML.Producto)result.Object).Departamento.Area.IdArea;


                    return View(producto);
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
        public ActionResult Form(ML.Producto producto)
        {
            // ML.Materia materia = new ML.Materia();
            ML.Result result = new ML.Result();

            HttpPostedFileBase file = Request.Files["ImagenData"];
            if (file.ContentLength > 0)
            {
                producto.Imagen = ConvertToBytes(file);
            }

            if (producto.IdProducto == 0)//Add
            {
                result = BL.Producto.AddWebAPI(producto);
                ViewBag.Message = "El producto se agregó correctamente ";
            }
            else //Update
            {
                //BL.Materia.Update();
                result = BL.Producto.UpdateWebAPI(producto);

                ViewBag.Message = "El producto se actualizó correctamente ";
            }

            if (!result.Correct)
            {
                ViewBag.Message = "No se pudo agregar correctamente el producto " + result.ErrorMessage;
            }

            return PartialView("Modal");
        }

        [HttpGet]
        public ActionResult Delete(int IdProducto)
        {

            ML.Result result = BL.Producto.DeleteWebAPI(IdProducto);

            return RedirectToAction("GetAll");
        }

        public JsonResult GetDepartamento(int IdArea) //para drop down list cascade
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
        }

	}
}