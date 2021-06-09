using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SL_WebAPI.Controllers
{
    public class ProductoController : ApiController
    {
        [HttpGet]
        [Route("api/producto")]
        public IHttpActionResult Get()
        {
            ML.Result result = BL.Producto.GetAllEF();
            return Ok(result);
        }

        [HttpGet]
        [Route("api/producto/{Idproducto}")]
        public IHttpActionResult GetById(int IdProducto)
        {
            ML.Result result = BL.Producto.GetByIdEF(IdProducto);
            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        [Route("api/producto/Add")]
        public IHttpActionResult Post([FromBody]ML.Producto producto)
        {
            ML.Result result = BL.Producto.AddEF(producto);
            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPut]
        [Route("api/producto/Update/{IdProducto}")]
        public IHttpActionResult Put(int IdProducto, [FromBody]ML.Producto producto)
        {
            producto.IdProducto = IdProducto;
            ML.Result result = BL.Producto.UpdateEF(producto);
            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete]
        [Route("api/producto/Delete/{IdProducto}")]
        public IHttpActionResult Delete(int IdProducto)
        {
            ML.Result result = BL.Producto.DeleteEF2(IdProducto);
            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }

    }
}
