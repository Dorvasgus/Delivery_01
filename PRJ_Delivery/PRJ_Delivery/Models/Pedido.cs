using System;
using System.Collections.Generic;

namespace PRJ_Delivery.Models
{
    public partial class Pedido
    {
        public int IdPedido { get; set; }
        public string Numero { get; set; } = null!;
        public DateTime FechaHoraCreacion { get; set; }
        public DateTime FechaHoraEntrega { get; set; }
        public string Calle { get; set; } = null!;
        public int Persona { get; set; }
        public int Factura { get; set; }
        public int Localidad { get; set; }
        public string NombreCliente { get; set; } = null!;
        public int TelefonoCliente { get; set; }
        public int Detalle { get; set; }

        public virtual Factura FacturaNavigation { get; set; } = null!;
        public virtual DetallePedido IdPedidoNavigation { get; set; } = null!;
        public virtual Localidad LocalidadNavigation { get; set; } = null!;
        public virtual Persona PersonaNavigation { get; set; } = null!;
    }
}
