using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ControWell.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VariableProcesoController : ControllerBase
    {
        private readonly DataContext _context;

        public VariableProcesoController(DataContext context)
        {

            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<VariableProceso>>> GetVariableProceso()
        {
            var procesos = await _context.VariableProcesos.ToListAsync();
            return Ok(procesos);
        }


        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<List<VariableProceso>>> GetSingleVariableProceso(int id)
        {
            var proceso = await _context.VariableProcesos.FirstOrDefaultAsync(v => v.Id == id);
            if (proceso == null)
            {
                return NotFound("La variable de proceso no ha sido creada :/");
            }

            return Ok(proceso);
        }

        [HttpPost]

        public async Task<ActionResult<VariableProceso>> CreateSuperHero(VariableProceso variable)
        {
            
            _context.VariableProcesos.Add(variable);
            await _context.SaveChangesAsync();
            return Ok(await GetDbVariableProceso());
        }


        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<List<VariableProceso>>> DeleteVariableProceso(int id)
        {
            var dbVariable = await _context.VariableProcesos.FirstOrDefaultAsync(v => v.Id == id);
            if (dbVariable == null)
            {
                return NotFound("La variable no existe :/");
            }

            _context.VariableProcesos.Remove(dbVariable);
            await _context.SaveChangesAsync();

            return Ok(await GetDbVariableProceso());
        }


        private async Task<List<VariableProceso>> GetDbVariableProceso()
        {
            return await _context.VariableProcesos.ToListAsync();
        }
    }
}
