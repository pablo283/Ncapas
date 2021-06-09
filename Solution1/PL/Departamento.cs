using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PL
{
    public class Departamento
    {
        //METODOS EN SQL EN STORED PROCEDURE
        public static void AddStoredProcedure()
        {
            ML.Departamento departamento = new ML.Departamento();

            Console.WriteLine("Ingrese el nombre del Departamento");
            departamento.Nombre = Console.ReadLine();

            Console.WriteLine("Ingrese el IdArea");

            departamento.Area = new ML.Area();
            departamento.Area.IdArea = int.Parse(Console.ReadLine());

            ML.Result result = BL.Departamento.AddStoredProcedure(departamento);
            if (result.Correct)
            {
                Console.WriteLine("El departamento se insertó correctamente");
            }
            else
            {
                Console.WriteLine("El departamento no pudo ser insertado correctamente " + result.ErrorMessage);
            }
        }

        public static void DeleteStoredProcedure()
         {
             ML.Departamento departamento = new ML.Departamento();

             Console.WriteLine("Ingrese el Id del Producto a borrar");
             departamento.IdDepartamento = int.Parse(Console.ReadLine());

             ML.Result result = BL.Departamento.DeleteStoredProcedure(departamento);
             if (result.Correct)
             {
                 Console.WriteLine("El departamento se borro correctamente");
             }
             else
             {
                 Console.WriteLine("El departamento no pudo ser borrado correctamente " + result.ErrorMessage);
             }
         }

        public static void UpdateStoreProcedure()
        {
            ML.Departamento departamento = new ML.Departamento();

            Console.WriteLine("Ingrese el Id del Departamento a actualizar");
            departamento.IdDepartamento = int.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese el nombre del Departamento");
            departamento.Nombre = Console.ReadLine();

            Console.WriteLine("Ingrese el IdArea");
            departamento.Area = new ML.Area();
            departamento.Area.IdArea = int.Parse(Console.ReadLine());

            ML.Result result = BL.Departamento.UpdateStoredProcedure(departamento);
            if (result.Correct)
            {
                Console.WriteLine("El departamento se actualizo correctamente");
            }
            else
            {
                Console.WriteLine("El departamento no pudo ser actualizado correctamente " + result.ErrorMessage);
            }
        }

        public static void GetAllStoredProcedure()
        {

            ML.Result result = BL.Departamento.GetAllStoredProcedure();
            if (result.Correct)
            {
                foreach (ML.Departamento departamento in result.Objects)
                {
                    Console.WriteLine("IdDepartamento: " + departamento.IdDepartamento);
                    Console.WriteLine("Nombre: " + departamento.Nombre);
                    //departamento.Area= new ML.Area();
                    Console.WriteLine("IdArea: " + departamento.Area.IdArea);

                }
                Console.WriteLine("El departamento se obtuvo correctamente");
            }
            else
            {
                Console.WriteLine("El departamento no pudo ser obtenido correctamente " + result.ErrorMessage);
            }

        }

        //METODOS EN ENTITY FRAMEWORK MEDIANTE STORED PROCEDURE 
        public static void AddEF()
        {
            ML.Departamento departamento = new ML.Departamento();

            Console.WriteLine("Ingrese el nombre del Departamento");
            departamento.Nombre = Console.ReadLine();

            Console.WriteLine("Ingrese el IdArea");

            departamento.Area = new ML.Area();
            departamento.Area.IdArea = int.Parse(Console.ReadLine());

            
            
            //ML.Result result = BL.Departamento.AddEF(departamento);

            ServiceReferenceDepartamento.DepartamentoClient ServicioDepartamento = new ServiceReferenceDepartamento.DepartamentoClient();
            var result = ServicioDepartamento.Add(departamento);

            if (result.Correct)
            {
                Console.WriteLine("El departamento se insertó correctamente");
            }
            else
            {
                Console.WriteLine("El departamento no pudo ser insertado correctamente " + result.ErrorMessage);
            }
        }

        public static void DeleteEF()
        {
            ML.Departamento departamento = new ML.Departamento();

            Console.WriteLine("Ingrese el Id del Producto a borrar");
            departamento.IdDepartamento = int.Parse(Console.ReadLine());

            //ML.Result result = BL.Departamento.DeleteEF(departamento);

            ServiceReferenceDepartamento.DepartamentoClient ServicioDepartamento = new ServiceReferenceDepartamento.DepartamentoClient();
            var result = ServicioDepartamento.Delete(departamento);
            

            if (result.Correct)
            {
                Console.WriteLine("El departamento se borro correctamente");
            }
            else
            {
                Console.WriteLine("El departamento no pudo ser borrado correctamente " + result.ErrorMessage);
            }
        }

        public static void UpdateEF()
        {
            ML.Departamento departamento = new ML.Departamento();

            Console.WriteLine("Ingrese el Id del Departamento a actualizar");
            departamento.IdDepartamento = int.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese el nombre del Departamento");
            departamento.Nombre = Console.ReadLine();

            Console.WriteLine("Ingrese el IdArea");
            departamento.Area = new ML.Area();
            departamento.Area.IdArea = int.Parse(Console.ReadLine());

            //ML.Result result = BL.Departamento.UpdateEF(departamento);

            ServiceReferenceDepartamento.DepartamentoClient ServicioDepartamento = new ServiceReferenceDepartamento.DepartamentoClient();
            var result = ServicioDepartamento.Update(departamento);

            if (result.Correct)
            {
                Console.WriteLine("El departamento se actualizo correctamente");
            }
            else
            {
                Console.WriteLine("El departamento no pudo ser actualizado correctamente " + result.ErrorMessage);
            }
        }

        public static void GetAllEF()
        {

            ML.Result result = BL.Departamento.GetAllEF();
            if (result.Correct)
            {
                foreach (ML.Departamento departamento in result.Objects)
                {
                    Console.WriteLine("IdDepartamento: " + departamento.IdDepartamento);
                    Console.WriteLine("NombreDepartamento: " + departamento.Nombre);
                    //departamento.Area= new ML.Area();
                    Console.WriteLine("IdArea: " + departamento.Area.IdArea);
                    Console.WriteLine("NombreArea: " + departamento.Area.Nombre);

                }
                Console.WriteLine("El departamento se obtuvo correctamente");
            }
            else
            {
                Console.WriteLine("El departamento no pudo ser obtenido correctamente " + result.ErrorMessage);
            }

        }

        //METODOS EN ENTITY FRAMEWORK MEDIANTE LINQ 
        public static void AddLINQ()
        {
            ML.Departamento departamento = new ML.Departamento();

            Console.WriteLine("Ingrese el nombre del Departamento");
            departamento.Nombre = Console.ReadLine();

            Console.WriteLine("Ingrese el IdArea");

            departamento.Area = new ML.Area();
            departamento.Area.IdArea = int.Parse(Console.ReadLine());

            ML.Result result = BL.Departamento.AddLINQ(departamento);
            if (result.Correct)
            {
                Console.WriteLine("El departamento se insertó correctamente");
            }
            else
            {
                Console.WriteLine("El departamento no pudo ser insertado correctamente " + result.ErrorMessage);
            }
        }

        public static void DeleteLINQ()
        {
            ML.Departamento departamento = new ML.Departamento();

            Console.WriteLine("Ingrese el Id del Departamento a borrar");
            departamento.IdDepartamento = int.Parse(Console.ReadLine());

            ML.Result result = BL.Departamento.DeleteLINQ(departamento);
            if (result.Correct)
            {
                Console.WriteLine("El departamento se borro correctamente");
            }
            else
            {
                Console.WriteLine("El departamento no pudo ser borrado correctamente " + result.ErrorMessage);
            }
        }

        public static void UpdateLINQ()
        {
            ML.Departamento departamento = new ML.Departamento();

            Console.WriteLine("Ingrese el Id del Departamento a actualizar");
            departamento.IdDepartamento = int.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese el nombre del Departamento");
            departamento.Nombre = Console.ReadLine();

            Console.WriteLine("Ingrese el IdArea");
            departamento.Area = new ML.Area();
            departamento.Area.IdArea = int.Parse(Console.ReadLine());

            ML.Result result = BL.Departamento.UpdateLINQ(departamento);
            if (result.Correct)
            {
                Console.WriteLine("El departamento se actualizo correctamente");
            }
            else
            {
                Console.WriteLine("El departamento no pudo ser actualizado correctamente " + result.ErrorMessage);
            }
        }

        public static void GetAllLINQ()
        {

            ML.Result result = BL.Departamento.GetAllLINQ();
            if (result.Correct)
            {
                foreach (ML.Departamento departamento in result.Objects)
                {
                    Console.WriteLine("IdDepartamento: " + departamento.IdDepartamento);
                    Console.WriteLine("Nombre: " + departamento.Nombre);
                    //departamento.Area= new ML.Area();
                    Console.WriteLine("IdArea: " + departamento.Area.IdArea);

                }
                Console.WriteLine("El departamento se obtuvo correctamente");
            }
            else
            {
                Console.WriteLine("El departamento no pudo ser obtenido correctamente " + result.ErrorMessage);
            }

        }

    }
}
