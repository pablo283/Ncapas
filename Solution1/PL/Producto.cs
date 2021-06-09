using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    public class Producto
    {
        public static void Add() //Metodo para capturar inf de usuario al insertar
        {
            ML.Producto producto = new ML.Producto();

            Console.WriteLine("Ingrese el nombre del Producto");
            producto.Nombre = Console.ReadLine();

            Console.WriteLine("Ingrese el precio del producto");
            producto.PrecioUnitario = decimal.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese el stock del producto");
            producto.Stock = int.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese la descripcion del producto");
            producto.Descripcion = Console.ReadLine();

            Console.WriteLine("Ingrese el IdProveedor");
            producto.Proveedor.IdProveedor = int.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese el IdDepartamento");
            producto.Departamento = new ML.Departamento();
            producto.Departamento.IdDepartamento = int.Parse(Console.ReadLine());
           


            ML.Result result = BL.Producto.Add(producto);
            if (result.Correct)
            {
                Console.WriteLine("El producto se insertó correctamente");
            }
            else
            {
                Console.WriteLine("El producto no pudo ser insertado correctamente " + result.ErrorMessage);
            }

        }

        public static void Delete() //Metodo para capturar inf de usuario al borrar
        {
            ML.Producto producto = new ML.Producto();

            Console.WriteLine("Ingrese el Id del Producto a borrar");
            producto.IdProducto = int.Parse(Console.ReadLine());
            
            ML.Result result = BL.Producto.Delete(producto);
            if (result.Correct)
            {
                Console.WriteLine("El producto se borro correctamente");
            }
            else
            {
                Console.WriteLine("El producto no pudo ser borrado correctamente " + result.ErrorMessage);
            }

        }

        public static void Update() //Metodo para capturar inf de usuario al actualizar
        {
            ML.Producto producto = new ML.Producto();

            Console.WriteLine("Ingrese el Id del Producto a actualizar");
            producto.IdProducto = int.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese el nuevo nombre");
            producto.Nombre = Console.ReadLine();
         
            Console.WriteLine("Ingrese el nuevo precio unitario");
            producto.PrecioUnitario = decimal.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese el nuevo stock");
            producto.Stock = int.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese la nueva descripcion");
            producto.Descripcion = Console.ReadLine();

            Console.WriteLine("Ingrese el IdProveedor");
            producto.Proveedor.IdProveedor = int.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese el IdDepartamento");
            producto.Departamento = new ML.Departamento();
            producto.Departamento.IdDepartamento = int.Parse(Console.ReadLine());

            ML.Result result = BL.Producto.Update(producto);
            if (result.Correct)
            {
                Console.WriteLine("El producto se actualizo correctamente");
            }
            else
            {
                Console.WriteLine("El producto no pudo ser actualizado correctamente " + result.ErrorMessage);
            }

        }

        public static void GetAll() // Metodo para mostrar todos los datos de una tabla
        {
                 
            ML.Result result = BL.Producto.GetAll();
            if (result.Correct)
            {
                foreach (ML.Producto producto in result.Objects)
                {
                    Console.WriteLine("IdProducto: " + producto.IdProducto);
                    Console.WriteLine("Nombre: " + producto.Nombre);
                    Console.WriteLine("PrecioUnitario: " + producto.PrecioUnitario);
                    Console.WriteLine("Stock: " + producto.Stock);
                    Console.WriteLine("Descripcion: " + producto.Descripcion);
                    producto.Proveedor = new ML.Proveedor();
                    Console.WriteLine("IdProveedor: " + producto.Proveedor.IdProveedor);
                    producto.Departamento = new ML.Departamento();
                    Console.WriteLine("IdDepartamento: " + producto.Departamento.IdDepartamento);

                }
                Console.WriteLine("El producto se obtuvo correctamente");
            }
            else
            {
                Console.WriteLine("El producto no pudo ser obtenido correctamente " + result.ErrorMessage);
            }

        }

        //Procedimientos Almacenados

        public static void AddStoredProcedure() //Metodo para capturar inf de usuario al insertar
        {
            ML.Producto producto = new ML.Producto();

            Console.WriteLine("Ingrese el nombre del Producto");
            producto.Nombre = Console.ReadLine();

            Console.WriteLine("Ingrese el precio del producto");
            producto.PrecioUnitario = decimal.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese el stock del producto");
            producto.Stock = int.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese la descripcion del producto");
            producto.Descripcion = Console.ReadLine();

            Console.WriteLine("Ingrese el IdProveedor");
            producto.Proveedor = new ML.Proveedor();
            producto.Proveedor.IdProveedor = int.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese el IdDepartamento");
            producto.Departamento = new ML.Departamento();
            producto.Departamento.IdDepartamento = int.Parse(Console.ReadLine());

            ML.Result result = BL.Producto.AddStoredProcedure(producto);
            if (result.Correct)
            {
                Console.WriteLine("El producto se insertó correctamente");
            }
            else
            {
                Console.WriteLine("El producto no pudo ser insertado correctamente " + result.ErrorMessage);
            }

        }

        public static void DeleteStoredProcedure()
        {
            ML.Producto producto = new ML.Producto();

            Console.WriteLine("Ingrese el Id del Producto a borrar");
            producto.IdProducto = int.Parse(Console.ReadLine());

            ML.Result result = BL.Producto.DeleteStoredProcedure(producto);
            if (result.Correct)
            {
                Console.WriteLine("El producto se borro correctamente");
            }
            else
            {
                Console.WriteLine("El producto no pudo ser borrado correctamente " + result.ErrorMessage);
            }

        } ///Metodo para capturar inf del usuario para borra mediante SP
          ///
        public static void UpdateStoreProcedure()
        {
            ML.Producto producto = new ML.Producto();

            Console.WriteLine("Ingrese el Id del Producto a actualizar");
            producto.IdProducto = int.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese el nombre del Producto");
            producto.Nombre = Console.ReadLine();

            Console.WriteLine("Ingrese el precio del producto");
            producto.PrecioUnitario = decimal.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese el stock del producto");
            producto.Stock = int.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese la descripcion del producto");
            producto.Descripcion = Console.ReadLine();

            Console.WriteLine("Ingrese el IdProveedor");
            producto.Proveedor = new ML.Proveedor();
            producto.Proveedor.IdProveedor = int.Parse(Console.ReadLine());
            
            Console.WriteLine("Ingrese el IdDepartamento");
            producto.Departamento = new ML.Departamento();
            producto.Departamento.IdDepartamento = int.Parse(Console.ReadLine());

            ML.Result result = BL.Producto.UpdateStoredProcedure(producto);
            if (result.Correct)
            {
                Console.WriteLine("El producto se actualizo correctamente");
            }
            else
            {
                Console.WriteLine("El producto no pudo ser actualizado correctamente " + result.ErrorMessage);
            }
        }

        public static void GetAllStoredProcedure()
        {

            ML.Result result = BL.Producto.GetAllStoredProcedure();
            if (result.Correct)
            {
                foreach (ML.Producto producto in result.Objects)
                {
                    Console.WriteLine("IdProducto: " + producto.IdProducto);
                    Console.WriteLine("Nombre: " + producto.Nombre);
                    Console.WriteLine("PrecioUnitario: " + producto.PrecioUnitario);
                    Console.WriteLine("Stock: " + producto.Stock);
                    Console.WriteLine("Descripcion: " + producto.Descripcion);

                    //producto.Proveedor = new ML.Proveedor();
                    Console.WriteLine("IdProveedor: " + producto.Proveedor.IdProveedor);

                    //producto.Departamento = new ML.Departamento();
                    Console.WriteLine("IdDepartamento: " + producto.Departamento.IdDepartamento);

                }
                Console.WriteLine("El producto se obtuvo correctamente");
            }
            else
            {
                Console.WriteLine("El producto no pudo ser obtenido correctamente " + result.ErrorMessage);
            }

        }

        //CRUD CON EF
        public static void AddEF() //Metodo para capturar inf de usuario al insertar
        {
            ML.Producto producto = new ML.Producto();

            Console.WriteLine("Ingrese el nombre del Producto");
            producto.Nombre = Console.ReadLine();

            Console.WriteLine("Ingrese el precio del producto");
            producto.PrecioUnitario = decimal.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese el stock del producto");
            producto.Stock = int.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese la descripcion del producto");
            producto.Descripcion = Console.ReadLine();

            Console.WriteLine("Ingrese el IdProveedor");
            producto.Proveedor = new ML.Proveedor();
            producto.Proveedor.IdProveedor = int.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese el IdDepartamento");
            producto.Departamento = new ML.Departamento();
            producto.Departamento.IdDepartamento = int.Parse(Console.ReadLine());



            //ML.Result result = BL.Producto.Add(producto);


            //para usar SL_WCF servicios web
            ServiceReferenceProducto.ProductoClient ServicioProducto = new ServiceReferenceProducto.ProductoClient();
            var result = ServicioProducto.Add(producto);


            if (result.Correct)
            {
                Console.WriteLine("El producto se insertó correctamente");
            }
            else
            {
                Console.WriteLine("El producto no pudo ser insertado correctamente " + result.ErrorMessage);
            }

        }

        public static void DeleteEF() //Metodo para capturar inf de usuario al borrar
        {
            ML.Producto producto = new ML.Producto();

            Console.WriteLine("Ingrese el Id del Producto a borrar");
            producto.IdProducto = int.Parse(Console.ReadLine());

            //ML.Result result = BL.Producto.DeleteEF(producto);


            //para usar SL_WCF servicios web
             ServiceReferenceProducto.ProductoClient ServicioProducto = new ServiceReferenceProducto.ProductoClient();
            var result = ServicioProducto.Delete(producto);
            if (result.Correct)
            {
                Console.WriteLine("El producto se borro correctamente");
            }
            else
            {
                Console.WriteLine("El producto no pudo ser borrado correctamente " + result.ErrorMessage);
            }

        }

        public static void UpdateEF()
        {
            ML.Producto producto = new ML.Producto();

            Console.WriteLine("Ingrese el Id del Producto a actualizar");
            producto.IdProducto = int.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese el nombre del Producto");
            producto.Nombre = Console.ReadLine();

            Console.WriteLine("Ingrese el precio del producto");
            producto.PrecioUnitario = decimal.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese el stock del producto");
            producto.Stock = int.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese la descripcion del producto");
            producto.Descripcion = Console.ReadLine();

            Console.WriteLine("Ingrese el IdProveedor");
            producto.Proveedor = new ML.Proveedor();
            producto.Proveedor.IdProveedor = int.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese el IdDepartamento");
            producto.Departamento = new ML.Departamento();
            producto.Departamento.IdDepartamento = int.Parse(Console.ReadLine());

           // ML.Result result = BL.Producto.UpdateEF(producto);



            //para usar SL_WCF servicios web
            ServiceReferenceProducto.ProductoClient ServicioProducto = new ServiceReferenceProducto.ProductoClient();
            var result = ServicioProducto.Update(producto);

            if (result.Correct)
            {
                Console.WriteLine("El producto se actualizo correctamente");
            }
            else
            {
                Console.WriteLine("El producto no pudo ser actualizado correctamente " + result.ErrorMessage);
            }
        }

        public static void GetAllEF()
        {

            ML.Result result = BL.Producto.GetAllEF();
            if (result.Correct)
            {
                foreach (ML.Producto producto in result.Objects)
                {
                    Console.WriteLine("IdProducto: " + producto.IdProducto);
                    Console.WriteLine("Nombre: " + producto.Nombre);
                    Console.WriteLine("PrecioUnitario: " + producto.PrecioUnitario);
                    Console.WriteLine("Stock: " + producto.Stock);
                    Console.WriteLine("Descripcion: " + producto.Descripcion);

                    //producto.Proveedor = new ML.Proveedor();
                    Console.WriteLine("IdProveedor: " + producto.Proveedor.IdProveedor);

                    //producto.Departamento = new ML.Departamento();
                    Console.WriteLine("IdDepartamento: " + producto.Departamento.IdDepartamento);

                }
                Console.WriteLine("El producto se obtuvo correctamente");
            }
            else
            {
                Console.WriteLine("El producto no pudo ser obtenido correctamente " + result.ErrorMessage);
            }

        }

        //CRUD CON LINQ
        public static void AddLINQ() //Metodo para capturar inf de usuario al insertar
        {
            ML.Producto producto = new ML.Producto();

            Console.WriteLine("Ingrese el nombre del Producto");
            producto.Nombre = Console.ReadLine();

            Console.WriteLine("Ingrese el precio del producto");
            producto.PrecioUnitario = decimal.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese el stock del producto");
            producto.Stock = int.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese la descripcion del producto");
            producto.Descripcion = Console.ReadLine();

            Console.WriteLine("Ingrese el IdProveedor");
            producto.Proveedor = new ML.Proveedor();
            producto.Proveedor.IdProveedor = int.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese el IdDepartamento");
            producto.Departamento = new ML.Departamento();
            producto.Departamento.IdDepartamento = int.Parse(Console.ReadLine());



            ML.Result result = BL.Producto.AddLINQ(producto);
            if (result.Correct)
            {
                Console.WriteLine("El producto se insertó correctamente");
            }
            else
            {
                Console.WriteLine("El producto no pudo ser insertado correctamente " + result.ErrorMessage);
            }

        }

        public static void DeleteLINQ() //Metodo para capturar inf de usuario al borrar
        {
            ML.Producto producto = new ML.Producto();

            Console.WriteLine("Ingrese el Id del Producto a borrar");
            producto.IdProducto = int.Parse(Console.ReadLine());

            ML.Result result = BL.Producto.DeleteLINQ(producto);
            if (result.Correct)
            {
                Console.WriteLine("El producto se borro correctamente");
            }
            else
            {
                Console.WriteLine("El producto no pudo ser borrado correctamente " + result.ErrorMessage);
            }

        }

        public static void UpdateLINQ()
        {
            ML.Producto producto = new ML.Producto();

            Console.WriteLine("Ingrese el Id del Producto a actualizar");
            producto.IdProducto = int.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese el nombre del Producto");
            producto.Nombre = Console.ReadLine();

            Console.WriteLine("Ingrese el precio del producto");
            producto.PrecioUnitario = decimal.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese el stock del producto");
            producto.Stock = int.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese la descripcion del producto");
            producto.Descripcion = Console.ReadLine();

            Console.WriteLine("Ingrese el IdProveedor");
            producto.Proveedor = new ML.Proveedor();
            producto.Proveedor.IdProveedor = int.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese el IdDepartamento");
            producto.Departamento = new ML.Departamento();
            producto.Departamento.IdDepartamento = int.Parse(Console.ReadLine());

            ML.Result result = BL.Producto.UpdateLINQ(producto);
            if (result.Correct)
            {
                Console.WriteLine("El producto se actualizo correctamente");
            }
            else
            {
                Console.WriteLine("El producto no pudo ser actualizado correctamente " + result.ErrorMessage);
            }
        }

        public static void GetAllLINQ()
        {

            ML.Result result = BL.Producto.GetAllLINQ();
            if (result.Correct)
            {
                foreach (ML.Producto producto in result.Objects)
                {
                    Console.WriteLine("IdProducto: " + producto.IdProducto);
                    Console.WriteLine("Nombre: " + producto.Nombre);
                    Console.WriteLine("PrecioUnitario: " + producto.PrecioUnitario);
                    Console.WriteLine("Stock: " + producto.Stock);
                    Console.WriteLine("Descripcion: " + producto.Descripcion);

                    //producto.Proveedor = new ML.Proveedor();
                    Console.WriteLine("IdProveedor: " + producto.Proveedor.IdProveedor);

                    //producto.Departamento = new ML.Departamento();
                    Console.WriteLine("IdDepartamento: " + producto.Departamento.IdDepartamento);

                }
                Console.WriteLine("El producto se obtuvo correctamente");
            }
            else
            {
                Console.WriteLine("El producto no pudo ser obtenido correctamente " + result.ErrorMessage);
            }

        }
    }
}