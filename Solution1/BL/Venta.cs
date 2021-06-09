using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Data.Entity.Core.Objects;
namespace BL
{
    public class Venta
    {
        public static ML.Result Add(ML.Venta venta, List<object> Objects)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    string Query = "VentaAdd";
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = Query;
                        cmd.CommandType = CommandType.StoredProcedure;



                        SqlParameter[] collection = new SqlParameter[4];

                        collection[0] = new SqlParameter("IdVenta", SqlDbType.Int);
                        collection[0].Direction = ParameterDirection.Output;

                        collection[1] = new SqlParameter("IdCliente", SqlDbType.Int);
                        collection[1].Value = venta.Cliente.IdCliente;

                        collection[2] = new SqlParameter("IdMetodoPago", SqlDbType.Int);
                        collection[2].Value = venta.MetodoPago.IdMetodoPago;

                        collection[3] = new SqlParameter("Total", SqlDbType.Decimal);
                        collection[3].Value = venta.Total;

                        cmd.Parameters.AddRange(collection);

                        cmd.Connection.Open();

                        int RowsAffected = cmd.ExecuteNonQuery();

                        venta.IdVenta = (int)collection[0].Value;

                        foreach (ML.VentaProducto ventaProducto in Objects)
                        {
                            ventaProducto.Venta = venta;

                            BL.VentaProducto.Add(ventaProducto);
                        }


                        cmd.Connection.Close();

                        if (RowsAffected > 0)
                        {
                            result.Correct = true;
                            result.ErrorMessage = "La venta se inserto correctamente.";
                        }
                        else
                        {
                            result.Correct = false;
                            result.ErrorMessage = "La venta no se pudo insertar correctamente.";
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


        public static ML.Result AddEF(ML.Venta venta, List<object> Objects)
        {
            ML.Result result = new ML.Result();
           

            ObjectParameter paramOutPageTotal = new ObjectParameter("IdVenta",typeof(int));
           
            try
            {
                using (DL_EF.PGonzalezNCapaEntities context = new DL_EF.PGonzalezNCapaEntities())
                {
                    var query = context.VentaAdd(paramOutPageTotal, venta.Cliente.IdCliente, venta.MetodoPago.IdMetodoPago, venta.Total);

                    venta.IdVenta = (int)paramOutPageTotal.Value;
                  
               
                    if (query >= 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se insertó el registro";
                    }

                    result.Correct = true;  

                    foreach (ML.Producto producto in Objects)
                    {
                       
                        producto.VentaProducto.Venta = venta;

                        BL.VentaProducto.AddEF(producto);
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
