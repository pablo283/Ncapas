using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class CarritoController : Controller
    {
       
        //
        // GET: /Carrito/

        public ActionResult GetAll()
        {
            ML.Result result = new ML.Result();
            result.Objects = new List<Object>();
            result.Objects = (List<Object>)Session["Carrito"];
            return View(result);
        }

        public ActionResult AddProduct(int Id)
        {
            ML.Producto producto = new ML.Producto();

            if (Session["Carrito"] == null)
            {
                ML.Result result = new ML.Result();
                producto.IdProducto = Id;
                var resultProducto = BL.Producto.GetByIdEF(producto.IdProducto);
                result.Objects = new List<Object>();

                ML.Producto productoItem = new ML.Producto();
                ML.Producto productos = new ML.Producto();
                productoItem = (ML.Producto)resultProducto.Object;
                productoItem.VentaProducto = new ML.VentaProducto();
                productoItem.Cantidad = 1;
                productoItem.VentaProducto.Venta = new ML.Venta();


                result.Objects.Add(productoItem);
                Session["Carrito"] = result.Objects;

                return View("GetAll", result);
            }
            else
            {
                              

                                producto.IdProducto = Id;
                                
                                var result = BL.Producto.GetByIdEF(producto.IdProducto);
                               
                                result.Objects = (List<Object>)Session["Carrito"];
  
                                int pos = 0;
                                bool comprobar = false;

                                foreach (ML.Producto productos in result.Objects) //compara toda la lista que ya tenemos con el nuevo producto
                                {
                                    if (productos.IdProducto == Id)
                                    {
                                        comprobar = true;
                                        pos = productos.IdProducto;
                                    }
                                   // else
                                   // {
                                   //     comprobar = false;
                                   // }
                                }


                                if (comprobar == true) //cuando es el mismo producto
                                {
                                    foreach (ML.Producto productos in result.Objects.ToList())
                                    {
                     
                                        if (productos.IdProducto == pos)
                                        {   
                                                                                                                        
                                            productos.Cantidad++;
                                            productos.VentaProducto.Venta.Total = productos.Cantidad * productos.PrecioUnitario;                  
                                            break;
                                        }
                                    }
                                }
                                else //cuando es un nuevo producto
                                {
                                    ML.Producto productoItem = new ML.Producto(); //se crea para aumentar Cantidad
                                    productoItem = (ML.Producto)result.Object; // cast de result object a producto
                                    productoItem.Cantidad = 1;                   //asigno valor
                                    result.Objects.Add(result.Object);             //despues de añadir Cantidad lo añadimos nuevamente a la lista
                                    Session["Carrito"] = result.Objects;
                                }

                                return View("GetAll", result);

            }
        }

        public ActionResult DeleteProduct(int Id)
        {

            TempData["alertMessage"] = "Producto Eliminado";
            ML.Result result = new ML.Result();
            result.Objects = new List<Object>();
            result.Objects = (List<Object>)Session["Carrito"];
            int pos = 0;

            if (result.Objects.Count == 0)
            {
                TempData["alertMessage"] = "No Existen Productos Agrega uno";
                return View("GetAll", result);
            }
            else
            {
                foreach (ML.Producto producto in result.Objects.ToList())
                {
                    pos++;
                    if (producto.IdProducto == Id)
                    {
                        break;
                    }
                }

                result.Objects.RemoveAt(pos - 1);

                return View("GetAll", result);
            }

        }

        public ActionResult IncrementaProduct(int Id)
        {
            ML.Result result = new ML.Result();
            result.Objects = new List<Object>();
            result.Objects = (List<Object>)Session["Carrito"];
           

           foreach (ML.Producto producto in result.Objects)
            {
                
               
                if (producto.IdProducto == Id)
                {
                    
                    producto.Cantidad++;
                    producto.VentaProducto.Venta.Total = producto.VentaProducto.Cantidad * producto.PrecioUnitario;
                    
                    break;
                }
            }

            return View("GetAll", result);

        }

        public ActionResult DecrementaProduct(int id)
        {
            ML.Result result = new ML.Result();
            result.Objects = new List<Object>();
            result.Objects = (List<Object>)Session["Carrito"];

            int pos = 0;
            bool comprobar = false;
            foreach (ML.Producto producto in result.Objects)
            {
                pos++;
                if (producto.IdProducto == id)
                {
                    producto.Cantidad--;
                    producto.VentaProducto.Venta.Total = producto.Cantidad * producto.PrecioUnitario;
                    comprobar = false;
                    if (producto.Cantidad <= 0)
                    {
                        comprobar = true;
                    }
                    break;
                }

            }

            if (comprobar == true)
            {
                result.Objects.RemoveAt(pos - 1);
            }

            return View("GetAll", result);

        }
   
        /*     public ActionResult ListProduct(List<ML.Producto> producto)
        {
            ML.Producto productos = new ML.Producto();
 
 
            if (Session["Carrito"] == null)
            {
                var result = new ML.Result();
                result.Objects = new List<Object>();
                //Existe
                foreach (ML.Producto productoItem in producto)
                {
 
                    if (productoItem.Selected == true)
                    {
                        productos.IdProducto = productoItem.IdProducto;
                        var consult = BL.Producto.GetByIdEF(productos.IdProducto);
 
 
                        result.Objects.Add(consult.Object);
                    }
                    else
                    {
                        //No esta Seleccionado
                    }
 
                }
 
                Session["Carrito"] = result.Objects;
                return View("GetAll", result);
            }
 
            else
            {
                var result = new ML.Result();
                result.Objects = new List<Object>();
                result.Objects = (List<Object>)Session["Carrito"];
                int pos = 0;
 
 
                foreach (ML.Producto productoItem in producto.ToList())
                {
 
                    if (productoItem.Selected == true)
                    {
 
                        if (productoItem.IdProducto == producto[pos].IdProducto)
                        {
                            producto[pos].VentaProducto = new ML.VentaProducto();
                            producto[pos].VentaProducto.Cantidad++;
                             producto[pos].VentaProducto.Venta = new ML.Venta();
                            producto[pos].DetallePedido.Total = producto[pos].DetallePedido.Cantidad * producto[pos].Precio;
                        }
                        else
                        {
                            productos.IdProducto = productoItem.IdProducto;
                            var consult = BL.Producto.ProductoGetById(productos);
                            result.Objects.Add(consult.Object);
                            Session["Carrito"] = result.Objects;
                        }
 
 
                    }
                    else
                    {
                        //No esta Seleccionado
                    }
                    pos++;
                }
                return View("GetAll", result);
 
            }
        }
           * */

        public ActionResult ProcesarCompra()
        {
            ML.Venta venta = new ML.Venta ();
            venta.Cliente = new ML.Cliente();
            venta.Cliente.IdCliente = 1;
            venta.MetodoPago = new ML.MetodoPago();
            venta.MetodoPago.IdMetodoPago = 1;
            

            ML.Result result = new ML.Result();
            result.Objects = new List<object>();
            result.Objects = (List<Object>)Session["Carrito"];

            decimal total = 0;

            foreach (ML.Producto producto in result.Objects.ToList())
            {
                 producto.VentaProducto = new ML.VentaProducto();
                 producto.VentaProducto.Venta = new ML.Venta();

                 total = total + (producto.Cantidad *producto.PrecioUnitario);                 
            }
            venta.Total = total;

            BL.Venta.AddEF(venta, result.Objects);

            return View("GetAll", result);
        }  
    }
}


