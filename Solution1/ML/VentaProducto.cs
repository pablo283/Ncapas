﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class VentaProducto
    {
        public int IdVentaProducto { get; set; }
        public ML.Venta Venta { get; set; } //id venta
        public ML.Producto Producto { get; set; }
        public int Cantidad { get; set; }

        
    }
}
