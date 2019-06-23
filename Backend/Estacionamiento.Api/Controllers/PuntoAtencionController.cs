using Estacionamiento.Domain;
using Estacionamiento.Service;
using Microsoft.AspNetCore.Mvc;

namespace Estacionamiento.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PuntoAtencionController:ControllerBase
    {
        private IPuntoAtencionService puntoService;
        public PuntoAtencionController(IPuntoAtencionService puntoService)
        {
            this.puntoService = puntoService;
        }

        [HttpGet]
        public ActionResult Get()
        {
            return Ok(
                puntoService.GetAll()
            );
        }

        [HttpPost]
        public ActionResult Post([FromBody] PuntoAtencion punto)
        {
            return Ok(
                puntoService.Save(punto)
            );
        }
        [HttpPut]
        public ActionResult Put([FromBody] PuntoAtencion punto)
        {
            return Ok(
                puntoService.Update(punto)
            );
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            return Ok(
                puntoService.Delete(id)
            );
        }
    }
}