using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace BL
{
    public class VentaProducto
    {
        public static ML.Result Add(ML.VentaProducto ventaProducto) //metodo para añadir producto mediante SP
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    string Query = "VentaProductoAdd";

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = Query;
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter[] collection = new SqlParameter[3];

                        collection[0] = new SqlParameter("IdProducto", SqlDbType.Int);
                        collection[0].Value = ventaProducto.Producto.IdProducto;

                        collection[1] = new SqlParameter("IdVenta", SqlDbType.Int);
                        collection[1].Value = ventaProducto.Venta.IdVenta;

                        collection[2] = new SqlParameter("Cantidad", SqlDbType.Int);
                        collection[2].Value = ventaProducto.Cantidad;

                        cmd.Parameters.AddRange(collection);

                        cmd.Connection.Open();

                        int RowsAffected = cmd.ExecuteNonQuery();

                        cmd.Connection.Close();

                        if (RowsAffected > 0)
                        {
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                            result.ErrorMessage = "El producto no se pudo insertar correctamente.";
                        }
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


        public static ML.Result AddEF(ML.Producto producto)
        {
            ML.Result result = new ML.Result();
          
            try
            {
                using (DL_EF.PGonzalezNCapaEntities context = new DL_EF.PGonzalezNCapaEntities())
                {
                    var query = context.VentaProductoAdd(producto.IdProducto, producto.VentaProducto.Venta.IdVenta, producto.Cantidad);


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
    }
}