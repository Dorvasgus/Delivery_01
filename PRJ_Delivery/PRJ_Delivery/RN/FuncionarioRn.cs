using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PRJ_Delivery.Data;
using PRJ_Delivery.DTOs;
using PRJ_Delivery.Helpers;

namespace PRJ_Delivery.RN
{
    public class FuncionarioRn
    {

        private readonly deliveryContext context;
        private readonly IMapper mapper;

        public FuncionarioRn(deliveryContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        internal static Task get(FuncionarioDTO funcionario)
        {
            throw new NotImplementedException();
        }

        internal static Task getAll(FuncionarioDTO funcionario)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseListDTO<FuncionarioDTO>> getAll(PaginacionDTO paginacion)
        {
            var query = context.Funcionarios
              .Include(x => x.Rol)
               .AsQueryable();

            var datosPaginacion = await query.datosPaginacion(paginacion.CantidadRegistroPorPagina);
            var entidades = await query.Paginar(paginacion).ToListAsync();

            var list = mapper.Map<List<FuncionarioDTO>>(entidades);

            return new ResponseListDTO<FuncionarioDTO>
            {
                cantidad = int.Parse(datosPaginacion["cantidadPaginas"]),
                pagina = paginacion.Pagina,
                total = int.Parse(datosPaginacion["totalRegistros"]),
                valores = list
            };

        }


    }
}
