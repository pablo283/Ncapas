using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SL_WebAPI.Controllers
{

    public class DepartamentoController : ApiController
    {
         
        // GET api/departamento
        [HttpGet]
        [Route("api/departamento")]
        public IHttpActionResult Get()
        {
            ML.Result result = BL.Departamento.GetAllEF();
            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }
        //cw+2tab
        [HttpGet]
        [Route("api/departamento/{IdDepartamento}")]
        public IHttpActionResult GetById(int IdDepartamento)
        {
            ML.Result result = BL.Departamento.GetByIdEF(IdDepartamento);
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
        [Route("api/departamento/Add")]
        public IHttpActionResult Post([FromBody]ML.Departamento departamento)
        {
            ML.Result result = BL.Departamento.AddEF(departamento);
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
        [Route("api/departamento/Update/{IdDepartamento}")]
        public IHttpActionResult Put(int IdDepartamento, [FromBody]ML.Departamento departamento)
        {
            departamento.IdDepartamento = IdDepartamento;
            ML.Result result = BL.Departamento.UpdateEF(departamento);
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
        [Route("api/departamento/Delete/{IdDepartamento}")]
        public IHttpActionResult Delete(int IdDepartamento)
        {
            ML.Result result = BL.Departamento.DeleteEF2(IdDepartamento);
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
