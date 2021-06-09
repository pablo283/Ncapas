using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    public class Area
    {
        public static void GetAllEF()
        {

            ML.Result result = BL.Area.GetAllEF();
            if (result.Correct)
            {
                foreach (ML.Area area in result.Objects)
                {
                    Console.WriteLine("IdDepartamento: " + area.IdArea);
                    Console.WriteLine("NombreDepartamento: " + area.Nombre);
                    

                }
                Console.WriteLine("El area se obtuvo correctamente");
            }
            else
            {
                Console.WriteLine("El area no pudo ser obtenido correctamente " + result.ErrorMessage);
            }

        }


    }
}
