using System;
using System.Collections.Generic;

namespace PRJ_Delivery.Models
{
    public partial class Cliente
    {
        public int IdCliente { get; set; }
        public string Nit { get; set; } = null!;
        public string RazonSocial { get; set; } = null!;
        public string UserName { get; set; } = null!;
        public string Password { get; set; } = null!;
        public int Localidad { get; set; }

        public virtual Localidad LocalidadNavigation { get; set; } = null!;
        public virtual Persona? Persona { get; set; }
    }
}
