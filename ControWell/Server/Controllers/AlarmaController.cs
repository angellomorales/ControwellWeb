using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ControWell.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlarmaController : ControllerBase
    {
        private readonly DataContext _context;

        public AlarmaController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Alarma>>> GetAlarmas()
        {
            var alarmas = await _context.Alarmas.Include(p=>p.Pozo).Include(v=>v.VariableProceso)
                
                .ToListAsync();
            return Ok(alarmas);
        }

        [HttpGet("Pozos")]
        public async Task<ActionResult<List<Pozo>>> GetPozos()
        {
            var pozos = await _context.Pozos.ToArrayAsync();
            return Ok(pozos);
        }

        [HttpGet("VariableProceso")]
        public async Task<ActionResult<List<Pozo>>> GetVariableProcesos()
        {
            var variableprocesos = await _context.VariableProcesos.ToArrayAsync();
            return Ok(variableprocesos);
        }
       

    }
}
