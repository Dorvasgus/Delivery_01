using System;
using System.Collections.Generic;

namespace PRJ_Delivery.Models
{
    public partial class Persona
    {
        public Persona()
        {
            Pedidos = new HashSet<Pedido>();
        }

        public int IdPersona { get; set; }
        public string Nombre { get; set; } = null!;
        public string Apellido { get; set; } = null!;
        public string NumeroIdentidad { get; set; } = null!;
        public int Rol { get; set; }
        public int Telefono { get; set; }

        public virtual Cliente IdPersonaNavigation { get; set; } = null!;
        public virtual Funcionario RolNavigation { get; set; } = null!;
        public virtual ICollection<Pedido> Pedidos { get; set; }
    }
}
