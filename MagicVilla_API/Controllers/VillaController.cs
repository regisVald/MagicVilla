using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MagicVilla_API.Modelos;
using MagicVilla_API.Modelos.Dto;
using MagicVilla_API.Datos;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;

namespace MagicVilla_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VillaController : ControllerBase
    {
        private readonly ILogger<VillaController> _logger;
        private readonly ApplicationDBContext _dBContext;
        public VillaController(ILogger<VillaController> logger,ApplicationDBContext db)
        {

            _logger = logger;   
            _dBContext = db;   

        }
        [HttpGet]
        [ProducesResponseType(200)]
        public ActionResult<IEnumerable<VillaDto>> GetVillas()
        {
            _logger.LogInformation("Obtener las villas");
            //Devolver una lista de villas
            return Ok(_dBContext.Villas.ToList());
        }

        [HttpGet("id:int", Name = "Getvilla")]
        [ProducesResponseType(200)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public ActionResult<VillaDto> GetVilla(int id)
        {   
            if(id == 0)
            {
                _logger.LogError("Error al traer villa");
                return BadRequest();//Codigo 400,
            }

            var villa = _dBContext.Villas.FirstOrDefault(x => x.Id == id);

            if(villa == null)
            {
                return NotFound();//codigo 404  no existe un registro con id 0
            }

            return Ok(villa);//Codigo 200
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<VillaDto> CrearVilla([FromBody] VillaDto villaDto)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if(_dBContext.Villas.FirstOrDefault(v=>v.nombre.ToLower() == villaDto.nombre.ToLower()) != null) 
            {
                ModelState.AddModelError("NombreExiste", "La villa con ese nombre ya existe");
                return BadRequest(ModelState);
            }
            if(villaDto == null)
            {
                return BadRequest(); //Si no mandan data no podemos crear un nuevo registro.
            }
            if(villaDto.Id > 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            Villa modelo = new Villa()
            {
                nombre = villaDto.nombre,
                detalle = villaDto.detalle,
                tarifa = villaDto.Tarifa,
                ocupante = villaDto.ocupante,
                imagenUrl = villaDto.imagenUrl,
                amenidad = villaDto.amenidad,
                metrocuadrado = villaDto.MetroCuadrado
            };

            _dBContext.Villas.Add(modelo);
            _dBContext.SaveChanges();
            return CreatedAtRoute("Getvilla", new {id = villaDto.Id}, villaDto);
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]


        public IActionResult DeleteVilla(int id) 
        { 
            if(id == 0)
            {
                return BadRequest();
            }

            var villa = _dBContext.Villas.FirstOrDefault(v=>v.Id == id);
            if(villa == null) 
            {
                return NotFound();
            }

            _dBContext.Villas.Remove(villa);
            _dBContext.SaveChanges();

            return NoContent();//Siempre que se trabaja con Delete se agrega el NoContent()
        }

        [HttpPut("{id:int}")]
        public IActionResult UpdateVilla(int id, [FromBody] VillaDto villaDto) 
        {
            if (villaDto == null || id != villaDto.Id)
            {
                return BadRequest();
            }


            Villa modelo = new Villa() {

                Id = villaDto.Id,
                nombre = villaDto.nombre,
                detalle = villaDto.detalle,
                tarifa = villaDto.Tarifa,
                ocupante = villaDto.ocupante,
                imagenUrl = villaDto.imagenUrl,
                amenidad = villaDto.amenidad,
                metrocuadrado = villaDto.MetroCuadrado

            };

            _dBContext.Update(modelo);
            _dBContext.SaveChanges();
            //var villa = VillaStore.villaList.FirstOrDefault(v => v.Id == id);

            //villa.nombre = villaDto.nombre;
            //villa.ocupante = villaDto.ocupante;
            //villa.MetroCuadrado = villaDto.MetroCuadrado;

            return NoContent();

        }

        [HttpPatch("{id:int}")]
        public IActionResult UpdatePartialVilla(int id, JsonPatchDocument<VillaDto> patchDto)
        {
            if (patchDto == null || id  == 0)
            {
                return BadRequest();
            }

            var villa = _dBContext.Villas.AsNoTracking().FirstOrDefault(x=> x.Id == id);
            VillaDto villaDto = new()
            {
                Id = villa.Id,
                nombre = villa.nombre,
                detalle = villa.detalle,
                Tarifa = villa.tarifa,
                ocupante = villa.ocupante,
                imagenUrl = villa.imagenUrl,
                amenidad = villa.amenidad,
                MetroCuadrado = villa.metrocuadrado
            };
          
            if (villa == null) return BadRequest();


            patchDto.ApplyTo(villaDto, ModelState);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Villa modelo = new()
            {
                Id = villaDto.Id,
                nombre = villaDto.nombre,
                detalle = villaDto.detalle,
                imagenUrl = villaDto.imagenUrl,
                ocupante = villaDto.ocupante,
                tarifa = villaDto.Tarifa,
                metrocuadrado = villaDto.MetroCuadrado,
                amenidad = villaDto.amenidad
            };

            _dBContext.Villas.Update(modelo);
            _dBContext.SaveChanges();
            return NoContent();

        }





    }
}
