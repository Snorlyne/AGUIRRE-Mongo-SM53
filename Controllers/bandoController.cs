using AGUIRRE_Mongo_SM53.Models;
using AGUIRRE_Mongo_SM53.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AGUIRRE_Mongo_SM53.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class bandoController : ControllerBase
    {
        private readonly bandoServices _bandoServices;

        public bandoController(bandoServices bandoServices) =>
            _bandoServices = bandoServices;
        //Muestra todos en general
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var bando = await _bandoServices.FindAsync();
            return Ok(bando);
        }
        //Para busquedas con el id
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var bando = await _bandoServices.FindById(id);
            if (bando == null)
                return NotFound();
            return Ok(bando);
        }
        //Creación
        [HttpPost]
        public async Task<IActionResult> Post(bando bandoNew)
        {
            await _bandoServices.Insert(bandoNew);
            return CreatedAtAction(nameof(Get), new { id = bandoNew.Id }, bandoNew);
        }
        //Actualizacion
        [HttpPut]
        public async Task<IActionResult> Put(string id, bando bandoUpdated)
        {
            var bando = _bandoServices.FindById(id);
            if (bando == null)
                return NoContent();
            bandoUpdated.Id = id;
            await _bandoServices.UpdateOne(id, bandoUpdated);
            return Ok(bandoUpdated);
        }
        //Eliminar
        [HttpDelete]
        public async Task<IActionResult> Delete(string id)
        {
            var bando = _bandoServices.FindById(id);
            if (bando == null)
                return NoContent();
            await _bandoServices.DeleteOne(id);
            return NoContent();
        }
    }
}
