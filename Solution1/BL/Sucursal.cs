using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Sucursal
    {
        public static ML.Result AddEF(ML.Sucursal sucursal)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.PGonzalezNCapaEntities context = new DL_EF.PGonzalezNCapaEntities())
                {
                    var query = context.SucursalAdd(sucursal.Nombre);


                    if (query >= 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se insertó el registro";
                    }

                    result.Correct = true;

                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }

        public static ML.Result DeleteEF(ML.Sucursal sucursal) //ML.Departamento departamento
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.PGonzalezNCapaEntities context = new DL_EF.PGonzalezNCapaEntities())
                {

                    var query = context.SucursalDelete(sucursal.IdSucursal);

                    if (query >= 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se eliminó el registro";
                    }

                    result.Correct = true;
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }

            return result;
        }

        public static ML.Result UpdateEF(ML.Sucursal sucursal)
        {
            ML.Result result = new ML.Result();
            try
            {

                using (DL_EF.PGonzalezNCapaEntities context = new DL_EF.PGonzalezNCapaEntities())
                {
                    var updateResult = context.SucursalUpdate(sucursal.IdSucursal, sucursal.Nombre);
                    if (updateResult >= 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se actualizó el status de la credencial";
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

        public static ML.Result GetAllEF()
        {

            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.PGonzalezNCapaEntities context = new DL_EF.PGonzalezNCapaEntities())
                {

                    var sucursales = context.SucursalGetAll().ToList();

                    result.Objects = new List<object>();

                    if (sucursales != null)
                    {
                        foreach (var obj in sucursales)
                        {
                            ML.Sucursal sucursal = new ML.Sucursal();
                           
                            sucursal.IdSucursal = obj.IdSucursal;
                            sucursal.Nombre = obj.Nombre;
                           
                            result.Objects.Add(sucursal);
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
