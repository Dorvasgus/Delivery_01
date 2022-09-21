namespace PRJ_Delivery.DTOs
{
    public class PersonaInsertarDTO
    {
        public string Nombre { get; set; } = null!;
        public string Apellido { get; set; } = null!;
        public string NumeroIdentidad { get; set; } = null!;
        public int Rol { get; set; }
        public int Telefono { get; set; }
    }
}
