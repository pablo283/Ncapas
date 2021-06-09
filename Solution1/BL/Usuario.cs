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
using System.IO;

namespace BL
{
    public class Usuario
    {
        public static ML.Result Add(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.PGonzalezNCapaEntities context = new DL_EF.PGonzalezNCapaEntities())
                {
                    var query = context.UsuarioAdd(usuario.Nombre, usuario.ApellidoPaterno, usuario.ApellidoMaterno,usuario.Contrasenia, usuario.NumeroCelular, usuario.Email,
                        usuario.FechaNacimiento, usuario.Sexo, usuario.Estatus, usuario.IdDireccion, usuario.Rol.IdRol);

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

                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }

        public static ML.Result Delete(int IdUsuario)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.PGonzalezNCapaEntities context = new DL_EF.PGonzalezNCapaEntities())
                {

                    var query = context.UsuarioDelete(IdUsuario);

                    if (query != 1)
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

        public static ML.Result Update(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {

                using (DL_EF.PGonzalezNCapaEntities context = new DL_EF.PGonzalezNCapaEntities())
                {
                    var updateResult = context.UsuarioUpdate (usuario.IdUsuario, usuario.Nombre, usuario.ApellidoPaterno, usuario.ApellidoMaterno,usuario.Contrasenia, usuario.NumeroCelular, usuario.Email,
                        usuario.FechaNacimiento, usuario.Sexo, usuario.Estatus, usuario.IdDireccion, usuario.Rol.IdRol);

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

        public static ML.Result GetAll()
        {

            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.PGonzalezNCapaEntities context = new DL_EF.PGonzalezNCapaEntities())
                {

                    var usuarios = context.UsuarioGetAll().ToList();

                    result.Objects = new List<object>();

                    if (usuarios != null)
                    {
                        foreach (var obj in usuarios)
                        {
                            ML.Usuario usuario = new ML.Usuario();

                            usuario.IdUsuario = obj.IdUsuario;
                            usuario.Nombre  = obj.UsuarioNombre  ;
                            usuario.ApellidoPaterno = obj.ApellidoPaterno;
                            usuario.ApellidoMaterno = obj.ApellidoMaterno;
                            usuario.Contrasenia = obj.Contrasenia;
                            usuario.NumeroCelular = obj.NumeroCelular;
                            usuario.Email = obj.Email;
                            usuario.FechaNacimiento = (DateTime)obj.FechaNacimiento;
                            usuario.Sexo = obj.Sexo;
                            usuario.Estatus = (Boolean)obj.Estatus;
                            usuario.IdDireccion = (int)obj.IdDireccion;
                            usuario.Rol = new ML.Rol();
                            usuario.Rol.IdRol = (int)obj.IdRol;
                            usuario.Rol.Nombre = obj.RolNombre;
                            result.Objects.Add(usuario);
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

        public static ML.Result GetByIdEF(int IdUsuario)
        {

            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.PGonzalezNCapaEntities context = new DL_EF.PGonzalezNCapaEntities())
                {

                    var usuarios = context.UsuarioGetById(IdUsuario).FirstOrDefault();

                    result.Object = new List<object>();

                    if (usuarios != null)
                    {

                        ML.Usuario usuario = new ML.Usuario();

                        usuario.IdUsuario = usuarios.IdUsuario;
                        usuario.Nombre = usuarios.Nombre;
                        usuario.ApellidoPaterno = usuarios.ApellidoPaterno;
                        usuario.ApellidoMaterno = usuarios.ApellidoMaterno;
                        usuario.Contrasenia = usuarios.Contrasenia;
                        usuario.NumeroCelular = usuarios.NumeroCelular;
                        usuario.Email = usuarios.Email;
                        usuario.FechaNacimiento =(DateTime) usuarios.FechaNacimiento;
                        usuario.Sexo = usuarios.Sexo;
                        usuario.Estatus = (bool)usuarios.Estatus;
                        usuario.IdDireccion = (int)usuarios.IdDireccion;


                        usuario.Rol = new ML.Rol();
                        usuario.Rol.IdRol = (int)usuarios.IdRol;
                        
                        result.Object = usuario;


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

        public static ML.Result UpdateStatus(int IdUsuario , bool Estatus)
        {
            ML.Result result = new ML.Result();
            try
            {

                using (DL_EF.PGonzalezNCapaEntities context = new DL_EF.PGonzalezNCapaEntities())
                {
                    var updateResult = context.UsuarioUpdateEstatus(IdUsuario,Estatus);

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

        public static ML.Result GetBusquedaAbierta(string Nombre,string ApellidoPaterno,string ApellidoMaterno)
        {

            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.PGonzalezNCapaEntities context = new DL_EF.PGonzalezNCapaEntities())
                {

                    var usuarios = context.UsuarioGetBusquedaAbierta(Nombre,ApellidoPaterno,ApellidoMaterno).ToList();

                    result.Objects = new List<object>();

                    if (usuarios != null)
                    {
                        foreach (var obj in usuarios)
                        {
                            ML.Usuario usuario = new ML.Usuario();

                            usuario.IdUsuario = obj.IdUsuario;
                            usuario.Nombre = obj.UsuarioNombre;
                            usuario.ApellidoPaterno = obj.ApellidoPaterno;
                            usuario.ApellidoMaterno = obj.ApellidoMaterno;
                            usuario.Contrasenia = obj.Contrasenia;
                            usuario.NumeroCelular = obj.NumeroCelular;
                            usuario.Email = obj.Email;
                            usuario.FechaNacimiento = (DateTime)obj.FechaNacimiento;
                            usuario.Sexo = obj.Sexo;
                            usuario.Estatus = (Boolean)obj.Estatus;
                            usuario.IdDireccion = (int)obj.IdDireccion;
                            usuario.Rol = new ML.Rol();
                            usuario.Rol.IdRol = (int)obj.IdRol;
                            usuario.Rol.Nombre = obj.RolNombre;
                            result.Objects.Add(usuario);
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

        public static void AddFile() ///lee un archivo txt que ingresa el usuario, lo usamos en mvc 
        {
             string linea;
             string[] Datos;
            try
            {
                using (StreamReader file = new StreamReader(@"C:\Users\ALIEN 16\Documents\PGonzalez\Solution1\MVC\ArchivoCargaUsuarios/carga.txt"))
                {
                    while ((linea = file.ReadLine())!= null)
                    {
                        Datos = linea.Split('|');
                        ML.Usuario usuario = new ML.Usuario();
                        usuario.IdUsuario= int.Parse(Datos[0]);
                        usuario.Nombre = Datos[1];
                        usuario.ApellidoPaterno = Datos[2];
                        usuario.ApellidoMaterno = Datos[3];
                        usuario.Contrasenia = Datos[4];
                        usuario.NumeroCelular = Datos[5];
                        usuario.Email = Datos[6];
                        usuario.FechaNacimiento = DateTime.Parse(Datos[7]);
                        usuario.Sexo = Datos[8];
                        usuario.Estatus = bool.Parse(Datos[9]);
                        usuario.IdDireccion = int.Parse(Datos[10]);
                        usuario.Rol = new ML.Rol();
                        usuario.Rol.IdRol = int.Parse(Datos[11]);
                        BL.Usuario.Add(usuario);
                    }
                    file.Close();
                }
            }
            catch (Exception ex)
            {
               
            }
        }  ///

        public static ML.Result Login(ML.Usuario usuario)
        {

            ML.Result result = new ML.Result();
            string PasswordLogin = usuario.Contrasenia;
            try
            {
                using (DL_EF.PGonzalezNCapaEntities context = new DL_EF.PGonzalezNCapaEntities())
                {

                    var usuarios = context.UsuarioLogin(usuario.Email).FirstOrDefault();

                    result.Object = new List<object>();

                    if (usuarios != null)
                    {
                        usuario.Contrasenia = usuarios.Contrasenia;
                        if (PasswordLogin != usuario.Contrasenia)//mover a PL
                        {
                            result.Correct = false;
                            return result;
                        }           
                        usuario.Email = usuarios.Email;                     
                        usuario.Rol = new ML.Rol();
                        usuario.Rol.IdRol = (int)usuarios.IdRol;

                        result.Object = usuario;
                      
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

        public static ML.Result LoginWebAPI(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {

                string urlAPI = System.Configuration.ConfigurationManager.AppSettings["URLapi"];
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(urlAPI);
                    //HTTP POST
                    var postTask = client.PostAsJsonAsync("usuario/Login", usuario);
                    postTask.Wait();
                    var resultAPI = postTask.Result;
                    if (resultAPI.IsSuccessStatusCode)
                    {
                        var readTask = resultAPI.Content.ReadAsAsync<ML.Result>();
                        readTask.Wait();
                        ML.Usuario resultItemList = new ML.Usuario();
                        resultItemList.Rol = new ML.Rol();
                        resultItemList = Newtonsoft.Json.JsonConvert.DeserializeObject<ML.Usuario>(readTask.Result.Object.ToString());
                        result.Object = resultItemList;
                        result.Correct = true;
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
