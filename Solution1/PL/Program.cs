using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PL
{
    class Program
    {
        public class Empleado
        {
            public int IdEmpleado { get; set; }
            public string Nombre { get; set; }
            public string Apellido { get; set; }
            public int SueldoDiario { get; set; }


            public int SueldoDIario(int SueldoDiario, int diasTrabajados)
            {
                int SueldoTotal = SueldoDiario * diasTrabajados;
                return SueldoTotal;
            }
        }
            static void Main(string[] args)
            {


                //Empleado empleado1 = new Empleado();
                //empleado1.Nombre = "Jacobo";
                //empleado1.Apellido = "Agami";
                //empleado1.SueldoDiario = 500;

                //Empleado empleado2 = new Empleado();
                //empleado2.Nombre = "Alvaro";
                //empleado2.Apellido = "Gonzalez";
                //empleado2.SueldoDiario = 400;

                //Empleado empleado3 = new Empleado();
                //empleado3.Nombre = "Mario";
                //empleado3.Apellido = "Ramon";
                //empleado3.SueldoDiario = 300;

                //Console.WriteLine(empleado1.Nombre + " " + empleado1.Apellido + ", SalarioMensual: " + empleado1.SueldoDIario(empleado1.SueldoDiario, 30));
                //Console.WriteLine(empleado2.Nombre + " " + empleado2.Apellido + ", SalarioMensual: " + empleado2.SueldoDIario(empleado2.SueldoDiario, 30));
                //Console.WriteLine(empleado3.Nombre + " " + empleado3.Apellido + ", SalarioMensual: " + empleado3.SueldoDIario(empleado3.SueldoDiario, 30));
                //Console.ReadKey();

                /*
                    //PL.Producto.Delete();
                    //PL.Producto.Update();
                    //PL.Producto.GetAll();       
                    //PL.Producto.Add();
                int caseSwitch;
                Console.WriteLine("1. PL.Producto.AddStoredProcedure();");
                Console.WriteLine("2. PL.Producto.DeleteStoredProcedure(); ");
                Console.WriteLine("3. PL.Producto.UpdateStoreProcedure();");
                Console.WriteLine("4. PL.Producto.GetAllStoredProcedure();");


                Console.WriteLine("5. PL.Departamento.AddStoredProcedure();");
                Console.WriteLine("6. PL.Departamento.DeleteStoredProcedure();");
                Console.WriteLine("7. PL.Departamento.UpdateStoreProcedure();");
                Console.WriteLine("8. PL.Departamento.GetAllStoredProcedure();");

                Console.WriteLine("9. PL.Venta.Add();");

                Console.WriteLine("Ingrese el numero de metodo");
                caseSwitch = int.Parse(Console.ReadLine());
            
            
                switch(caseSwitch)
                {
                    case 1:
                            PL.Producto.AddStoredProcedure();
                            break;
                    case 2:
                            PL.Producto.DeleteStoredProcedure();  
                            break;
                    case 3:
                            PL.Producto.UpdateStoreProcedure();
                            break;
                    case 4:
                            PL.Producto.GetAllStoredProcedure();
                            break;
                    case 5:
                            PL.Departamento.AddStoredProcedure(); 
                            break;
                    case 6:
                            PL.Departamento.DeleteStoredProcedure();
                            break;
                    case 7:
                            PL.Departamento.UpdateStoreProcedure();
                            break;
                    case 8:
                            PL.Departamento.GetAllStoredProcedure();
                            break;
                    case 9:
                            PL.Venta.Add();
                            break;
                }
           
                */
                //PL.Departamento.AddEF();
                //PL.Departamento.DeleteEF();          
                //PL.Departamento.UpdateEF();
                //PL.Departamento.GetAllEF();

                //PL.Departamento.AddLINQ();
                //PL.Departamento.DeleteLINQ();
                //PL.Departamento.UpdateLINQ();
                //PL.Departamento.GetAllLINQ();

                //PL.Producto.AddEF();
                //PL.Producto.DeleteEF();          
                //PL.Producto.UpdateEF();
                //PL.Producto.GetAllEF();

                //PL.Producto.AddLINQ();
                //PL.Producto.DeleteLINQ();
                //PL.Producto.UpdateLINQ();
                //PL.Producto.GetAllLINQ();
                //PL.Departamento.GetAllEF();
                /*
                            ServiceReferenceCalculadora.CalculadoraClient ServicioSuma = new ServiceReferenceCalculadora.CalculadoraClient();
                            var resultServicio = ServicioSuma.Suma(5,5);
                            Console.WriteLine(resultServicio);

                            ServiceReferenceCalculadora.CalculadoraClient ServicioResta = new ServiceReferenceCalculadora.CalculadoraClient();
                            var resultServicio2 = ServicioResta.Resta(5,1);
                            Console.WriteLine(resultServicio2);

                            ServiceReferenceCalculadora.CalculadoraClient ServicioMulti = new ServiceReferenceCalculadora.CalculadoraClient();
                            var resultServicio3 = ServicioMulti.Multiplicacion(5, 3);
                            Console.WriteLine(resultServicio3);*/
                //ML.Usuario usuario = new ML.Usuario();
                //usuario.Email = "abc@hotmail.com";
                //usuario.Contrasenia = "JHop98@//";
                //BL.Usuario.Login(usuario);
                //Console.ReadKey();

                //int i = 0;
                //int menorEdad = 0;
                //int mayorEdad = 0;
                //for(i=0; i<199 ; i++)
                //{
                //    Console.WriteLine("Ingrese la edad:");
                //    usuario.Edad = int.Parse(Console.ReadLine());
                //    if (usuario.Edad < 19)
                //    {
                //        menorEdad++;
                //    }
                //    else
                //    {
                //        mayorEdad++;
                //    }
                //}
                //Console.WriteLine("Los usuarios menores de edad son" + menorEdad);

                //Console.WriteLine("Los usuarios mayores de edad son" + mayorEdad);


                int[] voto = new int[160];
                int candidato1=0;
                int candidato2=0;
                int candidato3=0;
                int swap = 0;

                for (int i = 0; i < 160; i++)
                {
                    if (voto[i] == 1)
                    {
                        candidato1++;
                    }
                    if (voto[i] == 2)
                    {
                        candidato2++;
                    }
                    else
                    {
                        candidato3++;
                    }
                }

                if (candidato1 < candidato2)
                {
                    swap = candidato1;
                    candidato1 = candidato2;
                    candidato2 = swap;
                }

                if (candidato1 < candidato3)
                {
                    swap = candidato1;
                    candidato1 = candidato3;
                    candidato3 = swap;
                }

                if (candidato2 < candidato3)
                {
                    swap = candidato2;
                    candidato2 = candidato3;
                    candidato3 = swap;
                }
                if (candidato1 == candidato2)
                {
                    Console.WriteLine("Existe un empate en el el 1er lugar con estos votos " + candidato1);
                    Console.WriteLine("El segundo lugar tiene estos votos " + candidato3);
                    Console.ReadKey();
                }
                if (candidato2 == candidato3)
                {
                    Console.WriteLine("El primer lugar tiene estos votos " + candidato1);
                    Console.WriteLine("Existe un empate en el el 2do lugar con estos votos " + candidato2);
                    Console.ReadKey();
                }
                else
                { 
                    Console.WriteLine("El primer lugar tiene estos votos " + candidato1);
                    Console.WriteLine("El segundo lugar tiene estos votos " + candidato2);
                    Console.WriteLine("El tercer lugar tiene estos votos " + candidato3);
                    Console.ReadKey();
                }
            }

        
    }
}