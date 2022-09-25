using System;
using System.Collections.Generic;

namespace PRJ_Delivery.Models
{
    public partial class Funcionario
    {
        public Funcionario()
        {
            Personas = new HashSet<Persona>();
        }

        public long IdFuncionario { get; set; }
        public string UserName { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Correo { get; set; } = null!;
        public long Rol { get; set; }
        public int Vehiculo { get; set; }

        public virtual Rol RolNavigation { get; set; } = null!;
        public virtual Vehiculo VehiculoNavigation { get; set; } = null!;
        public virtual ICollection<Persona> Personas { get; set; }
    }
}
