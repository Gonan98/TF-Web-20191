using Estacionamiento.Domain;
using Estacionamiento.Service;
using Microsoft.AspNetCore.Mvc;

namespace Estacionamiento.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarifaController:ControllerBase
    {
        private ITarifaService tarifaService;
        public TarifaController(ITarifaService tarifaService){
            this.tarifaService=tarifaService;
        }
          [HttpGet]
        public ActionResult Get()
        {
            return Ok(
                tarifaService.GetAll()
            );
        }

        [HttpPost]
        public ActionResult Post([FromBody] Tarifa tarifa)
        {
            return Ok(
                tarifaService.Save(tarifa)
            );
        }

        [HttpPut]
        public ActionResult Put([FromBody] Tarifa tarifa)
        {
            return Ok(
               tarifaService.Update(tarifa)
            );
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            return Ok(
                tarifaService.Delete(id)
            );
        }
    }  
}