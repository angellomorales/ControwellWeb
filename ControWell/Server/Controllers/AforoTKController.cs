using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ControWell.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AforoTKController : ControllerBase
    {
        private readonly DataContext _context;

        public AforoTKController(DataContext context)
        {

            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult<List<AforoTK>>> GetAforoTK()
        {
            var aforos = await _context.AforoTKs.ToListAsync();
            return Ok(aforos);
        }

    }
}
