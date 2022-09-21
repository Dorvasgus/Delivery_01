using PRJ_Delivery.Models;

namespace PRJ_Delivery.DTOs
{
    public class ClienteDTO
    {
        public string Nit { get; set; } = null!;
        public string RazonSocial { get; set; } = null!;
        public string UserName { get; set; } = null!;
        public string Password { get; set; } = null!;
        public int Localidad { get; set; }

        public virtual LocalidadDTO LocalidadNavigation { get; set; } = null!;
        public virtual PersonaDTO? Persona { get; set; }
    }
}
