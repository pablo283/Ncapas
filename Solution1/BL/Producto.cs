using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http;

namespace BL
{
    public class Producto //Aqui van los metodos del producto delete, add, update
    {
        public static ML.Result Add(ML.Producto producto) //metodo para añadir producto
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    string Query = "INSERT INTO [Producto]([Nombre],[PrecioUnitario],[Stock],[Descripcion],[IdProveedor],[IdDepartamento]) VALUES (@Nombre, @PrecioUnitario, @Stock, @Descripcion, @IdProveedor, @IdDepartamento)";

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = Query;


                        SqlParameter[] collection = new SqlParameter[6];

                        collection[0] = new SqlParameter("Nombre", SqlDbType.VarChar);
                        collection[0].Value = producto.Nombre;

                        collection[1] = new SqlParameter("PrecioUnitario", SqlDbType.Decimal);
                        collection[1].Value = producto.PrecioUnitario;

                        collection[2] = new SqlParameter("Stock", SqlDbType.Int);
                        collection[2].Value = producto.Stock;

                        collection[3] = new SqlParameter("Descripcion", SqlDbType.VarChar);
                        collection[3].Value = producto.Descripcion;

                        collection[4] = new SqlParameter("IdProveedor", SqlDbType.Int);
                        collection[4].Value = producto.Proveedor.IdProveedor;

                        collection[5] = new SqlParameter("IdDepartamento", SqlDbType.Int);
                        collection[5].Value = producto.Departamento.IdDepartamento;


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

        public static ML.Result Delete(ML.Producto producto) //metodo para borrar producto 
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    string Query = "DELETE FROM [Producto] WHERE IdProducto=@IdProducto";

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = Query;


                        SqlParameter[] collection = new SqlParameter[1];

                        collection[0] = new SqlParameter("IdProducto", SqlDbType.Int);
                        collection[0].Value = producto.IdProducto;

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
                            result.ErrorMessage = "El producto no se pudo borrar correctamente.";
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


        public static ML.Result Update(ML.Producto producto) //metodo para actualizar producto 
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    string Query = "UPDATE [Producto] SET Nombre = @Nombre, PrecioUnitario = @PrecioUnitario, Stock = @Stock,  Descripcion = @Descripcion, IdProveedor = @IdProveedor, IdDepartamento = @IdDepartamento  WHERE IdProducto = @IdProducto";

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = Query;


                        SqlParameter[] collection = new SqlParameter[7];

                        collection[0] = new SqlParameter("IdProducto", SqlDbType.Int);
                        collection[0].Value = producto.IdProducto;

                        collection[1] = new SqlParameter("Nombre", SqlDbType.VarChar);
                        collection[1].Value = producto.Nombre;

                        collection[2] = new SqlParameter("PrecioUnitario", SqlDbType.Decimal);
                        collection[2].Value = producto.PrecioUnitario;

                        collection[3] = new SqlParameter("Stock", SqlDbType.Int);
                        collection[3].Value = producto.Stock;

                        collection[4] = new SqlParameter("Descripcion", SqlDbType.VarChar);
                        collection[4].Value = producto.Descripcion;

                        collection[5] = new SqlParameter("IdProveedor", SqlDbType.Int);
                        collection[5].Value = producto.Proveedor.IdProveedor;

                        collection[6] = new SqlParameter("IdDepartamento", SqlDbType.Int);
                        collection[6].Value = producto.Departamento.IdDepartamento;


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
                            result.ErrorMessage = "El producto no se pudo actualizar correctamente.";
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

        public static ML.Result GetAll() ///metodo para mostrar todos los datos de una tabla 
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    string Query = "SELECT [IdProducto],[Nombre],[PrecioUnitario],[Stock],[Descripcion], [IdProveedor],[IdDepartamento] FROM [Producto]";

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = Query;
                        cmd.Connection.Open();

                        DataTable productos = new DataTable();

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(productos);

                        if (productos.Rows.Count > 0)
                        {
                            result.Objects = new List<object>();
                            foreach (DataRow row in productos.Rows) //for sin necesidad de poner ciclos 
                            {
                                ML.Producto producto = new ML.Producto();

                                producto.IdProducto = int.Parse(row[0].ToString());
                                producto.Nombre = row[1].ToString();
                                producto.PrecioUnitario = decimal.Parse(row[2].ToString());
                                producto.Stock = int.Parse(row[3].ToString());
                                producto.Descripcion = row[4].ToString();
                                producto.Proveedor = new ML.Proveedor();
                                producto.Proveedor.IdProveedor = int.Parse(row[5].ToString());
                                producto.Departamento = new ML.Departamento();
                                producto.Departamento.IdDepartamento = int.Parse(row[6].ToString());

                                result.Objects.Add(producto);
                            }
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                            result.ErrorMessage = "No existen registros en la tabla Producto";
                        }

                        cmd.Connection.Close();

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


        //STORED PROCEDURE
        public static ML.Result AddStoredProcedure(ML.Producto producto) //metodo para añadir producto mediante SP
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    string Query = "ProductoAdd";

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = Query;
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter[] collection = new SqlParameter[6];

                        collection[0] = new SqlParameter("Nombre", SqlDbType.VarChar);
                        collection[0].Value = producto.Nombre;

                        collection[1] = new SqlParameter("PrecioUnitario", SqlDbType.Decimal);
                        collection[1].Value = producto.PrecioUnitario;

                        collection[2] = new SqlParameter("Stock", SqlDbType.Int);
                        collection[2].Value = producto.Stock;

                        collection[3] = new SqlParameter("Descripcion", SqlDbType.VarChar);
                        collection[3].Value = producto.Descripcion;

                        collection[4] = new SqlParameter("IdProveedor", SqlDbType.Int);
                        collection[4].Value = producto.Proveedor.IdProveedor;

                        collection[5] = new SqlParameter("IdDepartamento", SqlDbType.Int);
                        collection[5].Value = producto.Departamento.IdDepartamento;

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

        public static ML.Result DeleteStoredProcedure(ML.Producto producto)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    string Query = "ProductoDelete";

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = Query;
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter[] collection = new SqlParameter[1];

                        collection[0] = new SqlParameter("IdProducto", SqlDbType.VarChar);
                        collection[0].Value = producto.IdProducto;

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


        }///metodo para eliminar un producto mediante SP
         
        public static ML.Result UpdateStoredProcedure(ML.Producto producto)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    string Query = "ProductoUpdate";

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = Query;
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter[] collection = new SqlParameter[7];

                        collection[0] = new SqlParameter("IdProducto", SqlDbType.Int);
                        collection[0].Value = producto.IdProducto;

                        collection[1] = new SqlParameter("Nombre", SqlDbType.VarChar);
                        collection[1].Value = producto.Nombre;

                        collection[2] = new SqlParameter("PrecioUnitario", SqlDbType.Decimal);
                        collection[2].Value = producto.PrecioUnitario;

                        collection[3] = new SqlParameter("Stock", SqlDbType.Int);
                        collection[3].Value = producto.Stock;

                        collection[4] = new SqlParameter("Descripcion", SqlDbType.VarChar);
                        collection[4].Value = producto.Descripcion;

                        collection[5] = new SqlParameter("IdProveedor", SqlDbType.Int);
                        collection[5].Value = producto.Proveedor.IdProveedor;

                        collection[6] = new SqlParameter("IdDepartamento", SqlDbType.Int);
                        collection[6].Value = producto.Departamento.IdDepartamento;

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
                            result.ErrorMessage = "El producto no se pudo actualizar correctamente.";
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

        }  //metodo para actualizar un producto mediante SP

        public static ML.Result GetAllStoredProcedure()
         {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    string Query = "ProductoGetAll";
                      

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = Query;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection.Open();

                        DataTable productos = new DataTable();

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(productos);

                        if (productos.Rows.Count > 0)
                        {
                            result.Objects = new List<object>();
                            foreach (DataRow row in productos.Rows) //for sin necesidad de poner ciclos 
                            {
                                ML.Producto producto = new ML.Producto();

                                producto.IdProducto = int.Parse(row[0].ToString());
                                producto.Nombre = row[1].ToString();
                                producto.PrecioUnitario = decimal.Parse(row[2].ToString());
                                producto.Stock = int.Parse(row[3].ToString());
                                producto.Descripcion = row[4].ToString();
                              
                                producto.Proveedor = new ML.Proveedor();                             
                                producto.Proveedor.IdProveedor = int.Parse(row[5].ToString());

                                producto.Departamento = new ML.Departamento();
                                producto.Departamento.IdDepartamento = int.Parse(row[6].ToString());

                                result.Objects.Add(producto);
                            }
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                            result.ErrorMessage = "No existen registros en la tabla Producto";
                        }

                        cmd.Connection.Close();

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

        public static ML.Result GetById(int IdProducto)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    string Query = "ProductoGetById";

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = Query;
                        cmd.CommandType = CommandType.StoredProcedure;
             
                        SqlParameter[] collection= new SqlParameter[1];

                        collection[0]= new SqlParameter("IdProducto",SqlDbType.Int);
                        collection[0].Value=IdProducto;

                        cmd.Parameters.AddRange(collection);
                        cmd.Connection.Open();

                        DataTable productos = new DataTable();

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(productos);

                        if (productos.Rows.Count > 0)
                        {

                                DataRow row = productos.Rows[0];  
           
                                ML.Producto producto = new ML.Producto();
                                producto.IdProducto = int.Parse(row[0].ToString());
                                producto.Nombre = row[1].ToString();
                                producto.PrecioUnitario = decimal.Parse(row[2].ToString());
                                producto.Stock = int.Parse(row[3].ToString());
                                producto.Descripcion = row[4].ToString();
                                producto.Proveedor = new ML.Proveedor();
                                producto.Proveedor.IdProveedor = int.Parse(row[5].ToString());

                                producto.Departamento = new ML.Departamento();
                                producto.Departamento.IdDepartamento = int.Parse(row[6].ToString());

                                producto.Departamento.Area = new ML.Area();
                                producto.Departamento.Area.IdArea = int.Parse(row[7].ToString());

                                result.Object = producto;
                            
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                            result.ErrorMessage = "No existen registros en la tabla Producto";
                        }

                        cmd.Connection.Close();

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

        //METODOS EF
        public static ML.Result AddEF(ML.Producto producto)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.PGonzalezNCapaEntities context = new DL_EF.PGonzalezNCapaEntities())
                {
                    var query = context.ProductoAdd(producto.Nombre, producto.PrecioUnitario, producto.Stock, producto.Descripcion, producto.Imagen, producto.Proveedor.IdProveedor, producto.Departamento.IdDepartamento);

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

        public static ML.Result DeleteEF(ML.Producto producto)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.PGonzalezNCapaEntities context = new DL_EF.PGonzalezNCapaEntities())
                {

                    var query = context.ProductoDelete(producto.IdProducto);

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

        public static ML.Result DeleteEF2(int IdProducto)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.PGonzalezNCapaEntities context = new DL_EF.PGonzalezNCapaEntities())
                {

                    var query = context.ProductoDelete(IdProducto);

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
        public static ML.Result UpdateEF(ML.Producto producto)
        {
            ML.Result result = new ML.Result();
            try
            {

                using (DL_EF.PGonzalezNCapaEntities context = new DL_EF.PGonzalezNCapaEntities())
                {
                    var updateResult = context.ProductoUpdate(producto.IdProducto,producto.Nombre,producto.PrecioUnitario,producto.Stock,producto.Descripcion, producto.Imagen, producto.Proveedor.IdProveedor, producto.Departamento.IdDepartamento);
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

                    var productos = context.ProductoGetAll().ToList();

                    result.Objects = new List<object>();

                    if (productos != null)
                    {
                        foreach (var obj in productos)
                        {
                            ML.Producto producto = new ML.Producto();

                            producto.IdProducto = obj.IdProducto;
                            producto.Nombre = obj.ProductoNombre;
                            producto.PrecioUnitario = obj.PrecioUnitario;
                            producto.Stock = obj.Stock;
                            producto.Descripcion = obj.Descripcion;
                            producto.Imagen = obj.Imagen;

                            producto.Proveedor = new ML.Proveedor();
                            producto.Proveedor.IdProveedor = obj.IdProveedor;
                            producto.Proveedor.Nombre =obj.ProveedorNombre;

                            producto.Departamento = new ML.Departamento();
                            producto.Departamento.IdDepartamento = obj.IdDepartamento;
                            producto.Departamento.Nombre = obj.DepartamentoNombre;

                            producto.Departamento.Area = new ML.Area();
                            producto.Departamento.Area.IdArea = obj.IdArea;
                            producto.Departamento.Area.Nombre = obj.AreaNombre;

                            result.Objects.Add(producto);
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

        //METODOS LINQ

        public static ML.Result AddLINQ(ML.Producto producto)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.PGonzalezNCapaEntities context = new DL_EF.PGonzalezNCapaEntities())
                {
                    DL_EF.Producto productoDL = new DL_EF.Producto();

                    productoDL.Nombre = producto.Nombre;
                    productoDL.PrecioUnitario = producto.PrecioUnitario;
                    productoDL.Stock = producto.Stock;
                    productoDL.Descripcion = producto.Descripcion;
                    productoDL.IdProveedor = producto.Proveedor.IdProveedor;
                    productoDL.IdDepartamento = producto.Departamento.IdDepartamento;

                    context.Productoes.Add(productoDL);                
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }

        public static ML.Result DeleteLINQ(ML.Producto producto)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.PGonzalezNCapaEntities context = new DL_EF.PGonzalezNCapaEntities())
                {
                    var query = (from a in context.Productoes
                                 where a.IdProducto == producto.IdProducto
                                 select a).First();

                    context.Productoes.Remove(query);
                    context.SaveChanges();
                }
            }

            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }

            return result;
        }

        public static ML.Result UpdateLINQ(ML.Producto producto)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.PGonzalezNCapaEntities context = new DL_EF.PGonzalezNCapaEntities())
                {
                    var query = (from a in context.Productoes
                                 where a.IdProducto == producto.IdProducto
                                 select a).SingleOrDefault();

                    if (query != null)
                    {
                        query.Nombre = producto.Nombre;
                        query.PrecioUnitario = producto.PrecioUnitario;
                        query.Stock = producto.Stock;
                        query.Descripcion = producto.Descripcion;
                        query.IdProveedor = producto.Proveedor.IdProveedor;
                        query.IdDepartamento = producto.Departamento.IdDepartamento;
                        context.SaveChanges();

                        result.Correct = true;
                    }

                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se encontró el producto" + producto.IdProducto;
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

        public static ML.Result GetAllLINQ()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.PGonzalezNCapaEntities context = new DL_EF.PGonzalezNCapaEntities())
                {
                    var productoList = (from producto in context.Productoes
                                     select producto).ToList();
                    result.Objects = new List<object>();

                    if (productoList.Count > 0)
                    {
                        foreach (var obj in productoList)
                        {
                            ML.Producto producto = new ML.Producto();
                            producto.IdProducto = int.Parse(obj.IdProducto.ToString());
                            producto.Nombre = obj.Nombre;
                            producto.PrecioUnitario = int.Parse(obj.PrecioUnitario.ToString());
                            producto.Stock = int.Parse(obj.Stock.ToString());
                            producto.Descripcion = obj.Descripcion;

                            producto.Proveedor = new ML.Proveedor();
                            producto.Proveedor.IdProveedor = int.Parse(obj.IdProveedor.ToString());

                            producto.Departamento = new ML.Departamento();
                            producto.Departamento.IdDepartamento = int.Parse(obj.IdDepartamento.ToString());


                            result.Objects.Add(producto);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No existen registros en la tabla producto";
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

        public static ML.Result GetByIdEF(int IdProducto)
        {

            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.PGonzalezNCapaEntities context = new DL_EF.PGonzalezNCapaEntities())
                {

                    var productos = context.ProductoGetById(IdProducto).FirstOrDefault();

                    result.Object = new List<object>();

                    if (productos != null)
                    {
                        
                            ML.Producto producto = new ML.Producto();

                            producto.IdProducto =productos.IdProducto;
                            producto.Nombre = productos.Nombre;
                            producto.PrecioUnitario = productos.PrecioUnitario;
                            producto.Stock = productos.Stock;
                            producto.Descripcion = productos.Descripcion;
                            producto.Imagen = productos.Imagen;

                            producto.Proveedor = new ML.Proveedor();
                            producto.Proveedor.IdProveedor = (int)productos.IdProveedor;

                            producto.Departamento = new ML.Departamento();
                            producto.Departamento.IdDepartamento = (int)productos.IdDepartamento;

                            producto.Departamento.Area = new ML.Area();
                            producto.Departamento.Area.IdArea = (int)productos.IdArea;

                            result.Object=producto;
                        

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


        ///METDODO DE WEB API
        public static ML.Result GetAllWebAPI()
        {
            ML.Result result = new ML.Result();

            try
            {
                string urlAPI = System.Configuration.ConfigurationManager.AppSettings["URLapi"];


                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(urlAPI);
                    //HTTP GET
                    var responseTask = client.GetAsync("producto");
                    responseTask.Wait();
                    result.Objects = new List<object>();
                    var resultAPI = responseTask.Result;
                    if (resultAPI.IsSuccessStatusCode)
                    {

                        var readTask = resultAPI.Content.ReadAsAsync<ML.Result>();
                        readTask.Wait();

                        var students = readTask.Result;

                        foreach (var resultItem in readTask.Result.Objects)
                        {
                            ML.Producto resultItemList = Newtonsoft.Json.JsonConvert.DeserializeObject<ML.Producto>(resultItem.ToString());
                            result.Objects.Add(resultItemList);

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


        public static ML.Result AddWebAPI(ML.Producto producto)
        {
            ML.Result result = new ML.Result();
            try
            {

                string urlAPI = System.Configuration.ConfigurationManager.AppSettings["URLapi"];
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(urlAPI);
                    //HTTP POST
                    var postTask = client.PostAsJsonAsync<ML.Producto>("producto/Add", producto);
                    postTask.Wait();
                    var resultAPI = postTask.Result;
                    if (resultAPI.IsSuccessStatusCode)
                    {
                        result.Correct = true;
                        return result;
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

        public static ML.Result UpdateWebAPI(ML.Producto producto)
        {
            ML.Result result = new ML.Result();
            try
            {

                string urlAPI = System.Configuration.ConfigurationManager.AppSettings["URLapi"];
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(urlAPI);
                    //HTTP POST
                    var putTask = client.PutAsJsonAsync<ML.Producto>("producto/Update/" + producto.IdProducto, producto);
                    putTask.Wait();
                    var resultAPI = putTask.Result;
                    if (resultAPI.IsSuccessStatusCode)
                    {
                        result.Correct = true;
                        return result;
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

        public static ML.Result DeleteWebAPI(int IdProducto)
        {
            ML.Result result = new ML.Result();
            try
            {
                string urlAPI = System.Configuration.ConfigurationManager.AppSettings["URLapi"];

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(urlAPI);
                    //HTTP GET
                    var responseTask = client.DeleteAsync("producto/Delete/" + IdProducto);
                    responseTask.Wait();

                    var resultAPI = responseTask.Result;
                    if (resultAPI.IsSuccessStatusCode)
                    {
                        result.Correct = true;
                        return result;
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

        public static ML.Result GetByIdWebAPI(int IdProducto)
        {
            ML.Result result = new ML.Result();
            try
            {
                string urlAPI = System.Configuration.ConfigurationManager.AppSettings["URLapi"];
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(urlAPI);
                    var responseTask = client.GetAsync("producto/" + IdProducto);
                    responseTask.Wait();
                    var resultAPI = responseTask.Result;
                    if (resultAPI.IsSuccessStatusCode)
                    {
                        var readTask = resultAPI.Content.ReadAsAsync<ML.Result>();
                        readTask.Wait();
                        ML.Producto resultItemList = new ML.Producto();
                        resultItemList = Newtonsoft.Json.JsonConvert.DeserializeObject<ML.Producto>(readTask.Result.Object.ToString());
                        result.Object = resultItemList;
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No existen registros en la tabla Departamento";
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