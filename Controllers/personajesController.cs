using AGUIRRE_Mongo_SM53.Models;
using AGUIRRE_Mongo_SM53.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AGUIRRE_Mongo_SM53.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class personajesController : ControllerBase
    {
        private readonly personajesServices _personajesServices;

        public personajesController(personajesServices personajesServices) =>
            _personajesServices = personajesServices;
        //Muestra todos en general
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var personajes = await _personajesServices.FindAsync();
            return Ok(personajes);
        }
        //Para busquedas con el id
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var personajes = await _personajesServices.FindById(id);
            if (personajes == null)
                return NotFound();
            return Ok(personajes);
        }
        //Creación
        [HttpPost]
        public async Task<IActionResult> Post(personajes personajesNew)
        {
            await _personajesServices.Insert(personajesNew);
            return CreatedAtAction(nameof(Get), new { id = personajesNew.Id }, personajesNew);
        }
        //Actualizacion
        [HttpPut]
        public async Task<IActionResult> Put(string id, personajes personajesUpdated)
        {
            var personajes = _personajesServices.FindById(id);
            if (personajes == null)
                return NoContent();
            personajesUpdated.Id = id;
            await _personajesServices.UpdateOne(id, personajesUpdated);
            return Ok(personajesUpdated);
        }
        //Eliminar
        [HttpDelete]
        public async Task<IActionResult> Delete(string id)
        {
            var personajes = _personajesServices.FindById(id);
            if (personajes == null)
                return NoContent();
            await _personajesServices.DeleteOne(id);
            return NoContent();
        }
    }
}
