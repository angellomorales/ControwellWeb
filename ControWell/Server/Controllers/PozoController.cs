using ControWell.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ControWell.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PozoController : ControllerBase
    {
        
        private readonly DataContext _context;

        public PozoController(DataContext context)
        {
            
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult<List<Pozo>>> GetPozo()
        {
            var pozos=await _context.Pozos.ToListAsync();
            return Ok(pozos);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Pozo>> GetSinglePozo(int id)
        {
            var pozo = _context.Pozos.FirstOrDefault(p => p.Id == id);
            if(pozo==null)
            {
                return NotFound("El pozo no existe");
            }
            return Ok(pozo);
        }

        [HttpPost]
        public async Task<ActionResult<List<Pozo>>> CreatePozo(Pozo pozo)
        {
           
            _context.Pozos.Add(pozo);

            await _context.SaveChangesAsync();

            return Ok(await GetDbPozos());
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<Pozo>>> UpdatePozo(Pozo pozo,int id)
        {

            var dbPozo = await _context.Pozos.FirstOrDefaultAsync(p=>p.Id==id);

            return Ok(await GetDbPozos());
            if (dbPozo == null)
                return NotFound("El pozo no se encuentra regustrado");
            dbPozo.Id = pozo.Id;
            dbPozo.NombrePozo=pozo.NombrePozo;
            dbPozo.Ubicacion=pozo.Ubicacion;
            dbPozo.Operadora=pozo.Operadora;
            dbPozo.Comentario=pozo.Comentario;
            await _context.SaveChangesAsync();
            return Ok(await GetDbPozos());
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<Pozo>>> DeletePozo(Pozo pozo, int id)
        {

            var dbPozo = await _context.Pozos.FirstOrDefaultAsync(p => p.Id == id);

            return Ok(await GetDbPozos());
            if (dbPozo == null)
                return NotFound("El pozo no se encuentra regustrado");
            _context.Pozos.Remove(dbPozo);
            await _context.SaveChangesAsync();
            return Ok(await GetDbPozos());
        }

        private async Task<List<Pozo>>GetDbPozos()
        {
            return await _context.Pozos.ToListAsync();
        }

        
    }
}