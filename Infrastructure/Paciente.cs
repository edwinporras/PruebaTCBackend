namespace PruebaTC_Backend.Infrastructure
{
    public class Paciente
    {
        public int Id { get; set; }
        public string TipoDocumento { get; set; }
        public string NumeroDocumento { get; set; }
        public string NombrePaciente { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string CorreoElectronico { get; set; }
        public string Genero { get; set; }
        public string Direccion {  get; set; }
        public string Activo { get; set; }

    }
}
