using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ControWell.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        private readonly DataContext _context;

        public SuperHeroController(DataContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> GetSuperHeroes()
        {
            var heroes =await _context.SuperHeroes.Include(sh=>sh.Comic).ToListAsync();
            return Ok(heroes);
        }
        [HttpGet("Comics")]
        public async Task<ActionResult<List<Comic>>> GetComics()
        {
            var comics = await _context.Comics.ToArrayAsync();
            return Ok(comics);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<List<SuperHero>>> GetSingleHeroes(int id)
        {
            var hero = await _context.SuperHeroes.
                Include(h=>h.Comic)
                .FirstOrDefaultAsync(h => h.Id == id);
            if(hero == null)
            {
                return NotFound("Lo siento, el heroe no se encuentra :/");
            }
            
            return Ok(hero);
        }
    }
}
