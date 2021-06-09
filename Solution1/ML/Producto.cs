using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML // atributos de clases, aqui se declaran las clases por 1era vez
{
    public class Producto
    {
        //atributos
        public int IdProducto { get; set; }
        public string Nombre { get; set; }
        public decimal PrecioUnitario { get; set; }
        public int Stock  { get; set; }
        public string Descripcion { get; set; }
       
        public DateTime FechaRegistro { get; set; }


        public ML.Proveedor Proveedor { get; set; }

        public ML.Departamento Departamento { get; set; }

        public List<object> Productos { get; set; }
        public byte[] Imagen { get; set; }

        public ML.VentaProducto VentaProducto { get; set; }
        public int Cantidad { get; set; }
    }
}
