using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ControWell.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TanqueController : ControllerBase
    {
        private static List<Tanque> Tanques = new List<Tanque>
        {
            new Tanque
                {
                    Id = 1,
                    NombreTanque = "TK-915 NF",
                    Capacidad = "1000",
                    TipoFluido = "Nafta",

                },

                new Tanque
                {
                    Id = 2,
                    NombreTanque = "TK-98 OL",
                    Capacidad = "2000",
                    TipoFluido = "Petroleo",

                },

                new Tanque
                {
                    Id = 3,
                    NombreTanque = "TK-103 WT",
                    Capacidad = "1000",
                    TipoFluido = "Agua",

                }
        };

        [HttpGet]

        public async Task<IActionResult> GetTanque()
        {
            return Ok(Tanques);
        }
    }
}
