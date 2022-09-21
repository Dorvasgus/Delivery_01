using PRJ_Delivery.Models;

namespace PRJ_Delivery.DTOs
{
    public class FacturaDTO
    {
        public FacturaDTO()
        {
            Pedidos = new HashSet<PedidoDTO>();
        }

        public DateTime FechaHoraEmision { get; set; }
        public string Detalle { get; set; } = null!;
        public string EstadodelPedido { get; set; } = null!;
        public string Nit { get; set; } = null!;

        public virtual ICollection<PedidoDTO> Pedidos { get; set; }
    }
}
