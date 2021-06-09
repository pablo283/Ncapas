using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class VentaController : Controller
    {
        // GET: Venta
        [HttpGet]
        public ActionResult ProductoGetAll()
        {
            ML.Result result = BL.Producto.GetAllEF();

            ML.Producto producto = new ML.Producto();
            producto.Productos = result.Objects;

            return View(producto);

        }

        public ActionResult GetAll()
        {
            var result = BL.Producto.GetAllEF();
            List<ML.Producto>ProductoList=new List <ML.Producto>();

            foreach(var productoItem in result.Objects)
            {
                ML.Producto producto = new ML.Producto();
                producto.IdProducto = ((ML.Producto)productoItem).IdProducto;
                producto.Nombre = ((ML.Producto)productoItem).Nombre;
                producto.PrecioUnitario = ((ML.Producto)productoItem).PrecioUnitario;
                producto.Stock = ((ML.Producto)productoItem).Stock;
                producto.Descripcion = ((ML.Producto)productoItem).Descripcion;       
                producto.Imagen = ((ML.Producto)productoItem).Imagen;
                producto.Proveedor = new ML.Proveedor();
                producto.Proveedor.IdProveedor = ((ML.Producto)productoItem).Proveedor.IdProveedor;
                producto.Departamento = new ML.Departamento();
                producto.Departamento.IdDepartamento = ((ML.Producto)productoItem).Departamento.IdDepartamento;

                ProductoList.Add(producto);
            }
            return View(ProductoList);
        }
	}
}