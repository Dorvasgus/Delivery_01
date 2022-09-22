using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PRJ_Delivery.Data;
using PRJ_Delivery.DTOs;
using PRJ_Delivery.Models;
using PRJ_Delivery.RN;

namespace PRJ_Delivery.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class FuncionariosController : Controller
    {
        private readonly deliveryContext context;
        private readonly IMapper mapper;

        public FuncionariosController(deliveryContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(typeof(ResponseListDTO<FuncionarioDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseError), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Get([FromQuery] FuncionarioDTO Personas)
        {
            try
            {
                var datos = await FuncionarioRn.getAll(Personas);
                return Ok(datos);

            }
            catch (Exception ex)
            {
                return new ResponseError(StatusCodes.Status400BadRequest, ex.Message).GetObjectResult();
            }

        }

            public IActionResult Index()
        {
            return View();
        }
    }
}
