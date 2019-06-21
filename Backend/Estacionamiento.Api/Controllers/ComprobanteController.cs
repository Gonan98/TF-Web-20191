using Estacionamiento.Domain;
using Estacionamiento.Service;
using Microsoft.AspNetCore.Mvc;

namespace Estacionamiento.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComprobanteController:ControllerBase
    {
        private IComprobanteService comprobanteService;
        public ComprobanteController(IComprobanteService comprobanteService)
        {
            this.comprobanteService = comprobanteService;
        }

        [HttpGet]
        public ActionResult Get()
        {
            return Ok(
                comprobanteService.GetAllComprobantes()
            );
        }

        [HttpPost]
        public ActionResult Post([FromBody] Comprobante comprobante)
        {
            return Ok(
                comprobanteService.Save(comprobante)
            );
        }
        [HttpPut]
        public ActionResult Put([FromBody] Comprobante comprobante)
        {
            return Ok(
                comprobanteService.Update(comprobante)
            );
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            return Ok(
                comprobanteService.Delete(id)
            );
        }
    }
}