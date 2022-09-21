using System;
using System.Collections.Generic;

namespace PRJ_Delivery.Models
{
    public partial class Vehiculo
    {
        public Vehiculo()
        {
            Funcionarios = new HashSet<Funcionario>();
        }

        public int IdVehiculo { get; set; }
        public string Patente { get; set; } = null!;
        public string Modelo { get; set; } = null!;
        public int TipoVehiculo { get; set; }
        public string Licencia { get; set; } = null!;

        public virtual TipoVehiculo TipoVehiculoNavigation { get; set; } = null!;
        public virtual ICollection<Funcionario> Funcionarios { get; set; }
    }
}
