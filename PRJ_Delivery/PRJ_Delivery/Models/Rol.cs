using System;
using System.Collections.Generic;

namespace PRJ_Delivery.Models
{
    public partial class Rol
    {
        public Rol()
        {
            Funcionarios = new HashSet<Funcionario>();
            Personas = new HashSet<Persona>();
        }

        public long IdRol { get; set; }
        public string Alias { get; set; } = null!;

        public virtual ICollection<Funcionario> Funcionarios { get; set; }
        public virtual ICollection<Persona> Personas { get; set; }
    }
}
