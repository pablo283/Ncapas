using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Rol
    {
        public static ML.Result GetAllEF()
        {

            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.PGonzalezNCapaEntities context = new DL_EF.PGonzalezNCapaEntities())
                {

                    var roles = context.RolGetAll().ToList();

                    result.Objects = new List<object>();

                    if (roles != null)
                    {
                        foreach (var obj in roles)
                        {
                            ML.Rol rol = new ML.Rol();


                            rol.IdRol = obj.IdRol;
                            rol.Nombre = obj.Nombre;

                            result.Objects.Add(rol);
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
