using Estacionamiento.Domain;
using Estacionamiento.Service;
using Microsoft.AspNetCore.Mvc;

namespace Estacionamiento.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngresoController:ControllerBase
    {
        private IIngresoService ingresoService;
        public IngresoController(IIngresoService ingresoService){

            this.ingresoService=ingresoService;
        }

        [HttpGet]
        public ActionResult GetAll(){

            return Ok(ingresoService.Getall());
        }
        [HttpPost]
        public ActionResult Post([FromBody]Ingreso ingreso){

            return Ok(ingresoService.Save(ingreso));
        }
        [HttpPut]
        public ActionResult Put([FromBody]Ingreso ingreso){

            return Ok(ingresoService.Update(ingreso));
        }
        [HttpGet("{id}")]
        public ActionResult GetById([FromRoute]int id){

            return Ok(ingresoService.Getid(id));
        }
        
        [HttpGet("placa/{codigo}")]
        public ActionResult FindByPlaca([FromRoute]string codigo){

            return Ok(ingresoService.FindByPlaca(codigo));
        }

        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute]int id){

            return Ok(ingresoService.Delete(id));
        }

        
    }
}