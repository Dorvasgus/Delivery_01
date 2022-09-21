using PRJ_Delivery.Models;

namespace PRJ_Delivery.DTOs
{
    public class VehiculoDTO
    {
        public VehiculoDTO()
        {
            Funcionarios = new HashSet<FuncionarioDTO>();
        }

        public string Patente { get; set; } = null!;
        public string Modelo { get; set; } = null!;
        public int TipoVehiculo { get; set; }
        public string Licencia { get; set; } = null!;

        public virtual TipoVehiculoDTO TipoVehiculoNavigation { get; set; } = null!;
        public virtual ICollection<FuncionarioDTO> Funcionarios { get; set; }
    }
}
