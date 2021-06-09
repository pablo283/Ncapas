using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace SL_WebAPI.Controllers
{
   
    public class UsuarioController : ApiController
    {
        [HttpPost]
        [Route("api/usuario/Login")]
        public IHttpActionResult Post([FromBody]ML.Usuario usuario)
        {
            ML.Result result = BL.Usuario.Login(usuario);
            usuario = (ML.Usuario)result.Object;

            if (result.Correct)
            {
                bool isCredentialValid = (usuario.Contrasenia == "JHop98@//");
                if (isCredentialValid)
                {
                    var token = TokenGenerator.GenerateTokenJwt(usuario.Email, usuario.Contrasenia);
                    return Ok(token);
                }
                else
                {
                    return Unauthorized();
                }
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
