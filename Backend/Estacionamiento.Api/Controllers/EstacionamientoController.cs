using Estacionamiento.Domain;
using Estacionamiento.Service;
using Microsoft.AspNetCore.Mvc;

namespace Estacionamiento.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstacionamientoController:ControllerBase
    {
        private IEstacionamientoService estacionamientoservice;
        public EstacionamientoController(IEstacionamientoService estacionamientoservice){
            this.estacionamientoservice=estacionamientoservice;
        }
          [HttpGet]
        public ActionResult Get()
        {
            return Ok(
                estacionamientoservice.GetAll()
            );
        }
         [HttpGet("{id}")]
        public ActionResult Get([FromRoute]int id)
        {
            return Ok(
                estacionamientoservice.Get(id)
            );
        }

        [HttpPost]
        public ActionResult Post([FromBody] Estacionamientos estacionamiento)
        {
            return Ok(
                estacionamientoservice.Save(estacionamiento)
            );
        }

        [HttpPut]
        public ActionResult Put([FromBody] Estacionamientos estacionamiento)
        {
            return Ok(
               estacionamientoservice.Update(estacionamiento)
            );
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            return Ok(
                estacionamientoservice.Delete(id)
            );
        }
    }
}