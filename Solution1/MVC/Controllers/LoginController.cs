using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class LoginController : Controller
    {
        public ActionResult Add()
        {
            return RedirectToAction("Add", "Usuario");
        }

        [HttpGet]
        public ActionResult login()
        {
            ML.Usuario login = new ML.Usuario();
            return View(login);
        }

        public ActionResult IniciarSesion()
        {
            ML.Usuario login = new ML.Usuario();
            return View();
        }

        [HttpPost]
        public ActionResult login(ML.Usuario usuario)
        {

            /*EN VARIALE var, llamamos al metodo desde BL.Categoria.CategoriaAddEF(); */

            //var result = BL.Usuario.Login(usuario);
            var result = BL.Usuario.LoginWebAPI(usuario); //metodo para usar 
            //Aqui redireccionamos al index (GetAll)
            if (result.Correct)
            {
                usuario = (ML.Usuario)result.Object;
                if (usuario.Rol.IdRol == 1) {
                    Session["TipoUsuario"] = "Administrador";
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    Session["TipoUsuario"] = "Cliente";
                    return RedirectToAction("GetAll","Carrito");
                } 
            }
            else
            {
                    return RedirectToAction("IniciarSesion");
            }          
            }
        
    ///cierra class y namesapce    
    }
}
