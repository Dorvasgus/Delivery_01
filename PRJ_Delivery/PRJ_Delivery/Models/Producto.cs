using System;
using System.Collections.Generic;

namespace PRJ_Delivery.Models
{
    public partial class Producto
    {
        public Producto()
        {
            DetallePedidos = new HashSet<DetallePedido>();
        }

        public int Id { get; set; }
        public string PizzaFamiliar { get; set; } = null!;
        public string PizzaMediana { get; set; } = null!;
        public string PizzaPequeña { get; set; } = null!;

        public virtual ICollection<DetallePedido> DetallePedidos { get; set; }
    }
}
