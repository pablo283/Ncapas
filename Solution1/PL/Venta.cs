using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    public class Venta
    {
        public static int opcion;
        public static void Add()
        {

            Console.WriteLine("Ingrese 1 si desea iniciar una compra");
            opcion = int.Parse(Console.ReadLine());

            ML.Result result = new ML.Result();
            result.Objects = new List<object>(); //creamos un objeto para almcenar Ids Producto

            ML.Venta venta = new ML.Venta();  //creamos un objeto venta para almacenar IdCliente y Ids de productos seleccionados
           

            Console.WriteLine("ingresa el id del cliente");

            venta.Cliente = new ML.Cliente();
            venta.Cliente.IdCliente = int.Parse(Console.ReadLine());

            Console.WriteLine("Ingresa el id del metodo de pago");

            venta.MetodoPago = new ML.MetodoPago();
            venta.MetodoPago.IdMetodoPago = int.Parse(Console.ReadLine());

            while (opcion == 1)
            {


                PL.Producto.GetAllEF(); //Mostramos en consola todos los productos

                Console.WriteLine("Dame el Id del producto que quieras comprar");

                ML.VentaProducto ventaProducto = new ML.VentaProducto();
  
                ventaProducto.Producto = new ML.Producto();
                ventaProducto.Producto.IdProducto = int.Parse(Console.ReadLine());

                Console.WriteLine("Ingresa la cantidad del producto");
                ventaProducto.Cantidad = int.Parse(Console.ReadLine());

                ML.Result resultProducto = BL.Producto.GetByIdEF(ventaProducto.Producto.IdProducto);


                venta.Total = venta.Total + (ventaProducto.Cantidad * ((ML.Producto)resultProducto.Object).PrecioUnitario);

                Console.WriteLine("Venta total: ", venta.Total);

                result.Objects.Add(ventaProducto);
                Console.WriteLine("Deseas continuar con la compra 1. Si 2. No");
                opcion = int.Parse(Console.ReadLine());

              
            }
            BL.Venta.AddEF(venta, result.Objects);
            

        }

      


    }
}
