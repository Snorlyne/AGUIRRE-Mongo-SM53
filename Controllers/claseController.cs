using AGUIRRE_Mongo_SM53.Models;
using AGUIRRE_Mongo_SM53.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AGUIRRE_Mongo_SM53.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class claseController : ControllerBase
    {
        private readonly claseServices _claseServices;

        public claseController(claseServices claseServices) =>
            _claseServices = claseServices;
        //Muestra todos en general
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var clase = await _claseServices.FindAsync();
            return Ok(clase);
        }
        //Para busquedas con el id
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var clase = await _claseServices.FindById(id);
            if (clase == null)
                return NotFound();
            return Ok(clase);
        }
        //Creación
        [HttpPost]
        public async Task<IActionResult> Post(clase claseNew)
        {
            await _claseServices.Insert(claseNew);
            return CreatedAtAction(nameof(Get), new { id = claseNew.Id }, claseNew);
        }
        //Actualizacion
        [HttpPut]
        public async Task<IActionResult> Put(string id, clase claseUpdated)
        {
            var clase = _claseServices.FindById(id);
            if (clase == null)
                return NoContent();
            claseUpdated.Id = id;
            await _claseServices.UpdateOne(id, claseUpdated);
            return Ok(claseUpdated);
        }
        //Eliminar
        [HttpDelete]
        public async Task<IActionResult> Delete(string id)
        {
            var clase = _claseServices.FindById(id);
            if (clase == null)
                return NoContent();
            await _claseServices.DeleteOne(id);
            return NoContent();
        }
    }
}
