using AGUIRRE_Mongo_SM53.Models;
using AGUIRRE_Mongo_SM53.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AGUIRRE_Mongo_SM53.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class lugaresController : ControllerBase
    {
        private readonly lugaresServices _lugaresServices;

        public lugaresController(lugaresServices lugaresServices) =>
            _lugaresServices = lugaresServices;
        //Muestra todos en general
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var lugares = await _lugaresServices.FindAsync();
            return Ok(lugares);
        }
        //Para busquedas con el id
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var lugares = await _lugaresServices.FindById(id);
            if (lugares == null)
                return NotFound();
            return Ok(lugares);
        }
        //Creación
        [HttpPost]
        public async Task<IActionResult> Post(lugares lugaresNew)
        {
            await _lugaresServices.Insert(lugaresNew);
            return CreatedAtAction(nameof(Get), new { id = lugaresNew.Id }, lugaresNew);
        }
        //Actualizacion
        [HttpPut]
        public async Task<IActionResult> Put(string id, lugares lugaresUpdated)
        {
            var lugares = _lugaresServices.FindById(id);
            if (lugares == null)
                return NoContent();
            lugaresUpdated.Id = id;
            await _lugaresServices.UpdateOne(id, lugaresUpdated);
            return Ok(lugaresUpdated);
        }
        //Eliminar
        [HttpDelete]
        public async Task<IActionResult> Delete(string id)
        {
            var lugares = _lugaresServices.FindById(id);
            if (lugares == null)
                return NoContent();
            await _lugaresServices.DeleteOne(id);
            return NoContent();
        }
    }
}
