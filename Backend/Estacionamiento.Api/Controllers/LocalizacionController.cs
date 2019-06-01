using Estacionamiento.Domain;
using Estacionamiento.Service;
using Microsoft.AspNetCore.Mvc;

namespace Estacionamiento.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocalizacionController:ControllerBase
    {
        private ILocalizacionService localizacionservice;
        public LocalizacionController(ILocalizacionService localizacionservice){
            this.localizacionservice=localizacionservice;
        }
          [HttpGet]
        public ActionResult Get()
        {
            return Ok(
                localizacionservice.GetAll()
            );
        }

        [HttpPost]
        public ActionResult Post([FromBody] Localizacion localizacion)
        {
            return Ok(
                localizacionservice.Save(localizacion)
            );
        }

        [HttpPut]
        public ActionResult Put([FromBody] Localizacion localizacion)
        {
            return Ok(
                localizacionservice.Update(localizacion)
            );
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            return Ok(
                localizacionservice.Delete(id)
            );
        }
    }
}