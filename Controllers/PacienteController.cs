
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using PruebaTC_Backend.Application;
using PruebaTC_Backend.Infrastructure;

namespace PruebaTC_Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PacienteController: ControllerBase
    {
        private readonly IPacienteService _pacienteService;
        
        public PacienteController(IPacienteService pacienteService) {
            _pacienteService = pacienteService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() {
            var pacientes = await _pacienteService.GetAllAsync();
            return Ok(pacientes);
        }

        private IActionResult Ok(IEnumerable<Paciente> pacientes)
        {
            throw new NotImplementedException();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var pacientes = await _pacienteService.GetByIdAsync(id);
            if (pacientes == null) return NotFound(new { message = "Paciente no encontrado" });
            return Ok(pacientes);
        }

        public async Task<IActionResult> Create([FromBody] Paciente paciente)
        {
            try
            {
                var nuevoId = await _pacienteService.CreateAsync(paciente);
                paciente.Id = nuevoId;
                return CreatedAtAction(nameof(GetById), new { id = nuevoId }, paciente);
            } catch (Exception ex)
            {
                return BadRequest(new { message = "Error al crear el paciente, posible paciente con numero documento repetido ", ex.Message });
            }
        }

        private IActionResult BadRequest(object value)
        {
            throw new NotImplementedException();
        }

        private IActionResult CreatedAtAction(string v, object value, Paciente paciente)
        {
            throw new NotImplementedException();
        }

        private IActionResult Ok(Paciente pacientes)
        {
            throw new NotImplementedException();
        }

        private IActionResult NotFound(object value)
        {
            throw new NotImplementedException();
        }
    }
}
