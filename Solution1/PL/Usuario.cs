using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    public class Usuario
    {
        public static void Add() //Metodo para capturar inf de usuario al insertar
        {
            ML.Usuario usuario = new ML.Usuario();

            Console.WriteLine("Ingrese el nombre del usuario");
            usuario.Nombre = Console.ReadLine();

            Console.WriteLine("Ingrese el apellido paterno del usuario");
            usuario.ApellidoPaterno = Console.ReadLine();

            Console.WriteLine("Ingrese el apellido materno del usuario");
            usuario.ApellidoMaterno = Console.ReadLine();

            Console.WriteLine("Ingrese la contraseña ");
            usuario.Contrasenia = Console.ReadLine();

            Console.WriteLine("Ingrese el numero de celular");
            usuario.NumeroCelular = Console.ReadLine();

            Console.WriteLine("Ingrese el email");
            usuario.Email = Console.ReadLine();

            Console.WriteLine("Ingrese la fecha de nacimiento ");
            usuario.FechaNacimiento = DateTime.Parse(Console.ReadLine());
           

            Console.WriteLine("Ingrese el sexo ");
            usuario.Sexo = Console.ReadLine();

            Console.WriteLine("Ingrese el Estatus");
            usuario.Estatus = Boolean.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese IdDireccion");
            usuario.IdDireccion = int.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese IdRol");
            usuario.Rol = new ML.Rol();
            usuario.Rol.IdRol =int.Parse(Console.ReadLine());


            ML.Result result = BL.Usuario.Add(usuario);
            if (result.Correct)
            {
                Console.WriteLine("El usuario se insertó correctamente");
            }
            else
            {
                Console.WriteLine("El usuario no pudo ser insertado correctamente " + result.ErrorMessage);
            }

        }
        
        public static void Delete() //Metodo para capturar inf de usuario al borrar
        {
            ML.Usuario usuario = new ML.Usuario();

            Console.WriteLine("Ingrese el Id del Usuario a borrar");
            usuario.IdUsuario = int.Parse(Console.ReadLine());

            ML.Result result = BL.Usuario.Delete(usuario.IdUsuario);
            if (result.Correct)
            {
                Console.WriteLine("El usuario se borro correctamente");
            }
            else
            {
                Console.WriteLine("El producto no pudo ser borrado correctamente " + result.ErrorMessage);
            }

        }

        public static void Update() //Metodo para capturar inf de usuario al insertar
        {
            ML.Usuario usuario = new ML.Usuario();

            Console.WriteLine("Ingrese el Id del Usuario a actualizar");
            usuario.IdUsuario = int.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese el nombre del usuario");
            usuario.Nombre = Console.ReadLine();

            Console.WriteLine("Ingrese el apellido paterno del usuario");
            usuario.ApellidoPaterno = Console.ReadLine();

            Console.WriteLine("Ingrese el apellido materno del usuario");
            usuario.ApellidoMaterno = Console.ReadLine();

            Console.WriteLine("Ingrese la contraseña ");
            usuario.Contrasenia = Console.ReadLine();

            Console.WriteLine("Ingrese el numero de celular");
            usuario.NumeroCelular = Console.ReadLine();

            Console.WriteLine("Ingrese el email");
            usuario.Email = Console.ReadLine();

            Console.WriteLine("Ingrese la fecha de nacimiento ");
            usuario.FechaNacimiento = DateTime.Parse(Console.ReadLine());


            Console.WriteLine("Ingrese el sexo ");
            usuario.Sexo = Console.ReadLine();

            Console.WriteLine("Ingrese el Estatus");
            usuario.Estatus = Boolean.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese IdDireccion");
            usuario.IdDireccion = int.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese IdRol");
            usuario.Rol = new ML.Rol();
            usuario.Rol.IdRol = int.Parse(Console.ReadLine());


            ML.Result result = BL.Usuario.Update(usuario);
            if (result.Correct)
            {
                Console.WriteLine("El usuario se actualizo correctamente");
            }
            else
            {
                Console.WriteLine("El usuario no pudo ser actualizado correctamente " + result.ErrorMessage);
            }

        }

        public static void GetAll()
        {

            ML.Result result = BL.Usuario.GetAll();
            if (result.Correct)
            {
                foreach (ML.Usuario usuario in result.Objects)
                {
                    Console.WriteLine("IdUsuario: " + usuario.IdUsuario);
                    Console.WriteLine("Nombre: " + usuario.Nombre);
                    Console.WriteLine("ApellidoPaterno: " + usuario.ApellidoPaterno);
                    Console.WriteLine("ApellidoMaterno: " + usuario.ApellidoMaterno);
                    Console.WriteLine("Contrasenia: " + usuario.Contrasenia);
                    Console.WriteLine("NumeroCelular: " + usuario.NumeroCelular);
                    Console.WriteLine("Email: " + usuario.Email);
                    Console.WriteLine("FechaNacimiento: " + usuario.FechaNacimiento);
                    Console.WriteLine("Sexo: " + usuario.Sexo);
                    Console.WriteLine("Estatus: " + usuario.Estatus);
                    Console.WriteLine("IdDireccion: " + usuario.IdDireccion);
                    Console.WriteLine("IdRol: " + usuario.Rol.IdRol);

                }
                Console.WriteLine("El usuario se obtuvo correctamente");
            }
            else
            {
                Console.WriteLine("El usuario no pudo ser obtenido correctamente " + result.ErrorMessage);
            }

        }
        
    }
}
