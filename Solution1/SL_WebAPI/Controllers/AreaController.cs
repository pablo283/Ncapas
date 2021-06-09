using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SL_WebAPI.Controllers
{
    public class AreaController : ApiController
    {
        [HttpGet]
        [Route("api/area")]
        public IHttpActionResult Get()
        {
            ML.Result result = BL.Area.GetAllEF();
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
