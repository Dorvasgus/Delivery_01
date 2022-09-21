using System;
using System.Collections.Generic;

namespace PRJ_Delivery.Models
{
    public partial class Localidad
    {
        public Localidad()
        {
            Clientes = new HashSet<Cliente>();
            Pedidos = new HashSet<Pedido>();
        }

        public int IdLocalidad { get; set; }
        public string Calle { get; set; } = null!;
        public string Barrio { get; set; } = null!;
        public string Zona { get; set; } = null!;

        public virtual ICollection<Cliente> Clientes { get; set; }
        public virtual ICollection<Pedido> Pedidos { get; set; }
    }
}
