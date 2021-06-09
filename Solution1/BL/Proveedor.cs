using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Proveedor
    {
        public static ML.Result GetAllEF()
        {

            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.PGonzalezNCapaEntities context = new DL_EF.PGonzalezNCapaEntities())
                {

                    var proveedores = context.ProveedorGetAll().ToList();

                    result.Objects = new List<object>();

                    if (proveedores != null)
                    {
                        foreach (var obj in proveedores)
                        {
                            ML.Proveedor proveedor = new ML.Proveedor();


                            proveedor.IdProveedor = obj.IdProveedor;
                            proveedor.Nombre = obj.Nombre;

                            result.Objects.Add(proveedor);
                        }

                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se encontraron registros.";
                    }
                }
            }
            catch (Exception ex)
            {

                result.Correct = false;
                result.ErrorMessage = ex.Message;

            }

            return result;
        }
    }
}
