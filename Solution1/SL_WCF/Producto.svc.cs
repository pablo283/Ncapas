﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SL_WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Producto" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Producto.svc or Producto.svc.cs at the Solution Explorer and start debugging.
    public class Producto : IProducto
    {
        public SL_WCF.Result Add(ML.Producto producto)
        {
            ML.Result result = BL.Producto.AddEF(producto);

            return new Result { Correct = result.Correct, ErrorMessage = result.ErrorMessage, Ex = result.Ex };
        }

        public SL_WCF.Result Delete(ML.Producto producto)
        {

            ML.Result result = BL.Producto.DeleteEF(producto);
            return new Result { Correct = result.Correct, ErrorMessage = result.ErrorMessage, Ex = result.Ex };
        }
        public SL_WCF.Result Update(ML.Producto producto)
        {

            ML.Result result = BL.Producto.UpdateEF(producto);
            return new Result { Correct = result.Correct, ErrorMessage = result.ErrorMessage, Ex = result.Ex };
        }
    }
}
