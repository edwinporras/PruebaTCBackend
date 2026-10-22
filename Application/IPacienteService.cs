using Dapper;
using Microsoft.Data.SqlClient;
using PruebaTC_Backend.Infrastructure;
using System.Data;
using System.Reflection.Metadata.Ecma335;
using Microsoft.Extensions.Configuration;

namespace PruebaTC_Backend.Application
{
    public interface IPacienteService
    {
        Task<IEnumerable<Paciente>> GetAllAsync();
        Task<Paciente?> GetByIdAsync(int id);
        Task<int> CreateAsync(Paciente paciente);
    }
    public class PacienteService : IPacienteService
    {
        private readonly string _connectionString;
        //private readonly IPacienteService _pacienteService;

        public PacienteService (IConfiguration Configuration)
        {
            _connectionString = Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Falla en la conexion");
        }

        private IDbConnection connection => new SqlConnection(_connectionString);
        public async Task<IEnumerable<Paciente>> GetAllAsync() {
            using var db = connection;
            string query = "SELECT * FROM pacientes";
            return await db.QueryAsync<Paciente>(query);
        }

        public async Task<int> CreateAsync(Paciente paciente)
        {
            using var db = connection;
            string query = @"
            INSERT INTO Pacientes (TipoDocumento, NumeroDocumento, NombrePaciente, FechaNacimiento, CorreoElectronico, Genero, Direccion, Activo);
            VALUES (@TipoDocumento, @NumeroDocumento, @NombrePaciente, @FechaNacimiento, @CorreoElectronico, @Genero, @Direccion, @Activo);
            SELECT CAST(SCOPE_IDENTITY() as int);";

            return await db.ExecuteScalarAsync<int>(query, paciente);
        }

        public Task<Paciente?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
