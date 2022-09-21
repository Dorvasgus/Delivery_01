using PRJ_Delivery.Models;

namespace PRJ_Delivery.DTOs
{
    public class LocalidadDTO
    {
        public LocalidadDTO()
        {
            Clientes = new HashSet<ClienteDTO>();
            Pedidos = new HashSet<PedidoDTO>();
        }

        public string Calle { get; set; } = null!;
        public string Barrio { get; set; } = null!;
        public string Zona { get; set; } = null!;

        public virtual ICollection<ClienteDTO> Clientes { get; set; }
        public virtual ICollection<PedidoDTO> Pedidos { get; set; }
    }
}
