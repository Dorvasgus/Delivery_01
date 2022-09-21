using System;
using System.Collections.Generic;

namespace PRJ_Delivery.Models
{
    public partial class DetallePedido
    {
        public int IdDetallePedido { get; set; }
        public int Cantidad { get; set; }
        public int SubTotal { get; set; }
        public int TipoProducto { get; set; }
        public string Detalles { get; set; } = null!;

        public virtual Producto TipoProductoNavigation { get; set; } = null!;
        public virtual Pedido? Pedido { get; set; }
    }
}
