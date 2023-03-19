using AGUIRRE_Mongo_SM53.Models;
using AGUIRRE_Mongo_SM53.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AGUIRRE_Mongo_SM53.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class poderesController : ControllerBase
    {
        private readonly poderesServices _poderesServices;

        public poderesController(poderesServices poderesServices) =>
            _poderesServices = poderesServices;
        //Muestra todos en general
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var poderes = await _poderesServices.FindAsync();
            return Ok(poderes);
        }
        //Para busquedas con el id
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var poderes = await _poderesServices.FindById(id);
            if (poderes == null)
                return NotFound();
            return Ok(poderes);
        }
        //Creación
        [HttpPost]
        public async Task<IActionResult> Post(poderes poderesNew)
        {
            await _poderesServices.Insert(poderesNew);
            return CreatedAtAction(nameof(Get), new { id = poderesNew.Id }, poderesNew);
        }
        //Actualizacion
        [HttpPut]
        public async Task<IActionResult> Put(string id, poderes poderesUpdated)
        {
            var poderes = _poderesServices.FindById(id);
            if (poderes == null)
                return NoContent();
            poderesUpdated.Id = id;
            await _poderesServices.UpdateOne(id, poderesUpdated);
            return Ok(poderesUpdated);
        }
        //Eliminar
        [HttpDelete]
        public async Task<IActionResult> Delete(string id)
        {
            var poderes = _poderesServices.FindById(id);
            if (poderes == null)
                return NoContent();
            await _poderesServices.DeleteOne(id);
            return NoContent();
        }
    }
}
