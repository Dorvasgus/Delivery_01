using System;
using System.Collections.Generic;

namespace PRJ_Delivery.Models
{
    public partial class Factura
    {
        public Factura()
        {
            Pedidos = new HashSet<Pedido>();
        }

        public int IdFactura { get; set; }
        public DateTime FechaHoraEmision { get; set; }
        public string Detalle { get; set; } = null!;
        public string EstadodelPedido { get; set; } = null!;
        public string Nit { get; set; } = null!;

        public virtual ICollection<Pedido> Pedidos { get; set; }
    }
}
