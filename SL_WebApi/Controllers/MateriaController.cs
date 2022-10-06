using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SL_WebApi.Controllers
{
    public class MateriaController : ApiController
    {
        [HttpPost]
        [Route("api/Materia/Add")]
        public IHttpActionResult Add([FromBody] ML.Materia materia) {

            var result = BL.Materia.Add(materia);
            if (result.Correct) {

                return Content(HttpStatusCode.OK, result);
            }
            else { 

                return Content(HttpStatusCode.BadRequest, result);
            
            }
        }

        [HttpPost]
        [Route("api/Materia/Update")]
        public IHttpActionResult Update([FromBody] ML.Materia materia)
        {

            var result = BL.Materia.Update(materia);
            if (result.Correct)
            {

                return Content(HttpStatusCode.OK, result);
            }
            else
            {

                return Content(HttpStatusCode.BadRequest, result);

            }
        }

        [HttpGet]
        [Route("api/Materia/GetAll")]
        public IHttpActionResult GetAll() {

            var result = BL.Materia.GetAll();

            if (result.Correct) {
                return Content(HttpStatusCode.OK, result);
            }
            else {

                return Content(HttpStatusCode.BadRequest, result);
            }
        
        }

        [HttpGet]
        [Route("api/Materia/GetById")]
        public IHttpActionResult GetById(int IdMateria)
        {

            var result = BL.Materia.GetById(IdMateria);

            if (result.Correct)
            {
                return Content(HttpStatusCode.OK, result);
            }
            else
            {

                return Content(HttpStatusCode.BadRequest, result);
            }

        }


    }
}
