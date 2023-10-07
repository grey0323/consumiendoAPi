namespace ApiPractive.Dtos
{
    public class EmpleadoDto
    {
        public int IdEmpleado { get; set; }

        public string Nombre { get; set; } = null!;

        public string Apellido { get; set; } = null!;

        public string Puesto { get; set; } = null!;
    }
}
