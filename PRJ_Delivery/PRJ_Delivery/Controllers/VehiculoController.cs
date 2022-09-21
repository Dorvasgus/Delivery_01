using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PRJ_Delivery.Data;
using PRJ_Delivery.DTOs;
using PRJ_Delivery.Helpers;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PRJ_Delivery.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiculoController : ControllerBase
    {
        private readonly deliveryContext context;
        private readonly IMapper mapper;
        public VehiculoController(deliveryContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        // GET: api/<VehiculoController>
        [HttpGet]
        public async Task<ActionResult> Get([FromQuery] PaginacionDTO paginacion)
        {
            try
            {
                var query = context.Vehiculos
                .Include(x => x.TipoVehiculo)
                .AsQueryable();

                var datosPaginacion = await query.datosPaginacion(paginacion.cantidadRegistroPorPagina);
                var entidades = await query.Paginar(paginacion).ToListAsync();
                var list = mapper.Map<List<VehiculoDTO>>(entidades);

                return Ok(new ResponseListDTO<VehiculoDTO>
                {
                    cantidad = int.Parse(datosPaginacion["CantidadPaginas"]),
                    pagina = paginacion.Pagina,
                    total = int.Parse(datosPaginacion["TotalRegistros"]),
                    valores = list
                });
            }
            catch (Exception ex)
            {

                return new ResponseError(StatusCodes.Status400BadRequest, ex.Message).GetObjectResult();
            }



        }
        //[HttpGet ]
        ////[Authorize(Roles ="ADM")]
        //public async Task<ActionResult<List<VehiculoDTO>>> Get()
        //{
        //    var vehiculo = await context.Vehiculos
        //        .Include(x => x.TipoVehiculo)
        //        .ToListAsync();

        //    var vehiculoDTOs = mapper.Map<List<VehiculoDTO>>(vehiculo);

        //    return Ok(vehiculoDTOs);
        //}
        // GET api/<VehiculoController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<VehiculoController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<VehiculoController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<VehiculoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
