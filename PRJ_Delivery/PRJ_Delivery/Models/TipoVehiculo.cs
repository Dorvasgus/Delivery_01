using System;
using System.Collections.Generic;

namespace PRJ_Delivery.Models
{
    public partial class TipoVehiculo
    {
        public TipoVehiculo()
        {
            Vehiculos = new HashSet<Vehiculo>();
        }

        public int IdTipoVehi { get; set; }
        public string Nombre { get; set; } = null!;

        public virtual ICollection<Vehiculo> Vehiculos { get; set; }
    }
}
