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
    public class Departamento
    {
        //METODOS EN SQL EN STORED PROCEDURE
        public static ML.Result AddStoredProcedure(ML.Departamento departamento) //metodo para añadir producto mediante SP
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    string Query = "DepartamentoAdd";

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = Query;
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter[] collection = new SqlParameter[3];

                        collection[0] = new SqlParameter("IdDepartamento", SqlDbType.Int);
                        collection[0].Value = departamento.IdDepartamento;

                        collection[1] = new SqlParameter("Nombre", SqlDbType.VarChar);
                        collection[1].Value = departamento.Nombre;

                        collection[2] = new SqlParameter("IdArea", SqlDbType.Int);
                        collection[2].Value = departamento.Area.IdArea;

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
                            result.ErrorMessage = "El departamento no se pudo insertar correctamente.";
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

        public static ML.Result DeleteStoredProcedure(ML.Departamento departamento)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    string Query = "DepartamentoDelete";

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = Query;
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter[] collection = new SqlParameter[1];

                        collection[0] = new SqlParameter("IdDepartamento", SqlDbType.VarChar);
                        collection[0].Value = departamento.IdDepartamento;

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
                            result.ErrorMessage = "El departamento no se pudo insertar correctamente.";
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

        public static ML.Result UpdateStoredProcedure(ML.Departamento departamento)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    string Query = "DepartamentoUpdate";

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = Query;
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter[] collection = new SqlParameter[3];

                        collection[0] = new SqlParameter("IdDepartamento", SqlDbType.Int);
                        collection[0].Value = departamento.IdDepartamento;

                        collection[1] = new SqlParameter("Nombre", SqlDbType.VarChar);
                        collection[1].Value = departamento.Nombre;

                        collection[2] = new SqlParameter("IdArea", SqlDbType.Int);
                        collection[2].Value = departamento.Area.IdArea;

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
                            result.ErrorMessage = "El departamento no se pudo actualizar correctamente.";
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

        }  //metodo

        public static ML.Result GetAllStoredProcedure()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    string Query = "DepartamentoGetAll";


                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = Query;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection.Open();

                        DataTable departamentos = new DataTable();

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(departamentos);

                        if (departamentos.Rows.Count > 0)
                        {
                            result.Objects = new List<object>();
                            foreach (DataRow row in departamentos.Rows) //for sin necesidad de poner ciclos 
                            {
                                ML.Departamento departamento = new ML.Departamento();
                                departamento.Area = new ML.Area();
                                departamento.IdDepartamento = int.Parse(row[0].ToString());
                                departamento.Nombre = row[1].ToString();

                                departamento.Area.IdArea = int.Parse(row[2].ToString());

                                result.Objects.Add(departamento);
                            }
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                            result.ErrorMessage = "No existen registros en la tabla Departamento";
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

        public static ML.Result GetById(int IdDepartamento)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    string Query = "DepartamentoGetById";

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = Query;
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter[] collection = new SqlParameter[1];

                        collection[0] = new SqlParameter("IdDepartamento", SqlDbType.Int);
                        collection[0].Value = IdDepartamento;

                        cmd.Parameters.AddRange(collection);
                        cmd.Connection.Open();

                        DataTable departamentos = new DataTable();

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(departamentos);

                        if (departamentos.Rows.Count > 0)
                        {

                            DataRow row = departamentos.Rows[0];

                            ML.Departamento departamento = new ML.Departamento();
                            departamento.IdDepartamento = int.Parse(row[0].ToString());
                            departamento.Nombre = row[1].ToString();
                            departamento.Area = new ML.Area();
                            departamento.Area.IdArea = int.Parse(row[3].ToString());

                            result.Object = departamento;

                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                            result.ErrorMessage = "No existen registros en la tabla Departamento";
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

        //METODOS EN ENTITY FRAMEWORK MEDIANTE STORED PROCEDURE 

        public static ML.Result GetByIdEF(int IdDepartamento)
        {


            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.PGonzalezNCapaEntities context = new DL_EF.PGonzalezNCapaEntities())
                {

                    var departamentos = context.DepartamentoGetById(IdDepartamento).FirstOrDefault();

                    result.Object = new List<object>();

                    if (departamentos != null)
                    {

                        ML.Departamento departamento = new ML.Departamento();

                        departamento.IdDepartamento = departamentos.IdDepartamento;
                        departamento.Nombre = departamentos.Nombre;
                        departamento.Area = new ML.Area();
                        departamento.Area.IdArea = (int)departamentos.IdArea;

                        result.Object = departamento;


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

        public static ML.Result AddEF(ML.Departamento departamento)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.PGonzalezNCapaEntities context = new DL_EF.PGonzalezNCapaEntities())
                {
                    var query = context.DepartamentoAdd(departamento.Nombre, departamento.Area.IdArea);


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

        public static ML.Result DeleteEF2(int IdDepartamento) //ML.Departamento departamento
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.PGonzalezNCapaEntities context = new DL_EF.PGonzalezNCapaEntities())
                {

                    var query = context.DepartamentoDelete(IdDepartamento);

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
        public static ML.Result DeleteEF(ML.Departamento departamento) //ML.Departamento departamento
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.PGonzalezNCapaEntities context = new DL_EF.PGonzalezNCapaEntities())
                {

                    var query = context.DepartamentoDelete(departamento.IdDepartamento);
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

        public static ML.Result UpdateEF(ML.Departamento departamento)
        {
            ML.Result result = new ML.Result();
            try
            {

                using (DL_EF.PGonzalezNCapaEntities context = new DL_EF.PGonzalezNCapaEntities())
                {
                    var updateResult = context.DepartamentoUpdate(departamento.IdDepartamento, departamento.Nombre, departamento.Area.IdArea);
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

                    var departamentos = context.DepartamentoGetAll().ToList();

                    result.Objects = new List<object>();

                    if (departamentos != null)
                    {
                        foreach (var obj in departamentos)
                        {
                            ML.Departamento departamento = new ML.Departamento();
                            departamento.Area = new ML.Area();

                            departamento.IdDepartamento = obj.IdDepartamento;
                            departamento.Nombre = obj.DepartamentoNombre;
                            departamento.Area.IdArea = (int)obj.IdArea;
                            departamento.Area.Nombre = obj.AreaNombre;
                            result.Objects.Add(departamento);
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

        //METODOS EN LINQ 
        public static ML.Result AddLINQ(ML.Departamento departamento)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.PGonzalezNCapaEntities context = new DL_EF.PGonzalezNCapaEntities())
                {
                    DL_EF.Departamento deptoDL = new DL_EF.Departamento();
                    deptoDL.Nombre = departamento.Nombre;
                    deptoDL.IdArea = departamento.Area.IdArea;

                    context.Departamentoes.Add(deptoDL);
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

        public static ML.Result DeleteLINQ(ML.Departamento departamento)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.PGonzalezNCapaEntities context = new DL_EF.PGonzalezNCapaEntities())
                {
                    var query = (from a in context.Departamentoes
                                 where a.IdDepartamento == departamento.IdDepartamento
                                 select a).First();

                    context.Departamentoes.Remove(query);
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

        public static ML.Result UpdateLINQ(ML.Departamento departamento)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.PGonzalezNCapaEntities context = new DL_EF.PGonzalezNCapaEntities())
                {
                    var query = (from a in context.Departamentoes
                                 where a.IdDepartamento == departamento.IdDepartamento
                                 select a).SingleOrDefault();

                    if (query != null)
                    {
                        query.Nombre = departamento.Nombre;
                        query.IdArea = departamento.Area.IdArea;
                        context.SaveChanges();

                        result.Correct = true;
                    }

                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se encontró el departamento" + departamento.IdDepartamento;
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
                    var deptoList = (from depto in context.Departamentoes
                                     select depto).ToList();
                    result.Objects = new List<object>();

                    if (deptoList.Count > 0)
                    {
                        foreach (var obj in deptoList)
                        {
                            ML.Departamento departamento = new ML.Departamento();
                            departamento.IdDepartamento = int.Parse(obj.IdDepartamento.ToString());
                            departamento.Nombre = obj.Nombre;
                            departamento.Area = new ML.Area();
                            departamento.Area.IdArea = int.Parse(obj.IdArea.ToString());
                            result.Objects.Add(departamento);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No existen registros en la tabla departamento";
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

        public static ML.Result GetByIdArea(int IdArea)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.PGonzalezNCapaEntities context = new DL_EF.PGonzalezNCapaEntities())
                {

                    var areas = context.AreaGetById(IdArea).ToList();

                    result.Objects = new List<object>();

                    if (areas != null)
                    {
                        foreach (var obj in areas)
                        {

                            ML.Departamento departamento = new ML.Departamento();
                            departamento.Area = new ML.Area();

                            departamento.Area.IdArea = (int)obj.IdArea;
                            departamento.IdDepartamento = obj.IdDepartamento;
                            departamento.Nombre = obj.NombreDepartamento;
                            //departamento.Area.Nombre= obj.;


                            result.Objects.Add(departamento);

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
                    var responseTask = client.GetAsync("departamento");
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
                            ML.Departamento resultItemList = Newtonsoft.Json.JsonConvert.DeserializeObject<ML.Departamento>(resultItem.ToString());
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


        public static ML.Result AddWebAPI(ML.Departamento departamento)
        {
            ML.Result result = new ML.Result();
            try
            {

                string urlAPI = System.Configuration.ConfigurationManager.AppSettings["URLapi"];
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(urlAPI);
                    //HTTP POST
                    var postTask = client.PostAsJsonAsync<ML.Departamento>("departamento/Add", departamento);
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

        public static ML.Result UpdateWebAPI(ML.Departamento departamento)
        {
            ML.Result result = new ML.Result();
            try
            {

                string urlAPI = System.Configuration.ConfigurationManager.AppSettings["URLapi"];
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(urlAPI);
                    //HTTP POST
                    var putTask = client.PutAsJsonAsync<ML.Departamento>("departamento/Update/" + departamento.IdDepartamento, departamento);
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

        public static ML.Result DeleteWebAPI(int IdDepartamento)
        {
            ML.Result result = new ML.Result();
            try
            {
                string urlAPI = System.Configuration.ConfigurationManager.AppSettings["URLapi"];

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(urlAPI);
                    //HTTP GET
                    var responseTask = client.DeleteAsync("departamento/Delete/" + IdDepartamento);
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

        public static ML.Result GetByIdWebAPI(int IdDepartamento)
        {
            ML.Result result = new ML.Result();
            try
            {
                string urlAPI = System.Configuration.ConfigurationManager.AppSettings["URLapi"];
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(urlAPI);
                    var responseTask = client.GetAsync("departamento/" + IdDepartamento);
                    responseTask.Wait();
                    var resultAPI = responseTask.Result;
                    if (resultAPI.IsSuccessStatusCode)
                    {
                        var readTask = resultAPI.Content.ReadAsAsync<ML.Result>();
                        readTask.Wait();
                        ML.Departamento resultItemList = new ML.Departamento();
                        resultItemList = Newtonsoft.Json.JsonConvert.DeserializeObject<ML.Departamento>(readTask.Result.Object.ToString());
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