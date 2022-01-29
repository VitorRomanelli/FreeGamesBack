using Microsoft.AspNetCore.Mvc;
using FreeGamesConsume.Utils;
using FreeGamesConsume.Services;

namespace FreeGamesConsume.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GameController : ControllerBase
    {
        public GameService _service;

        public GameController(GameService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("list")]
        public async Task<IActionResult> ListAttributes()
        {
            return new ResponseHelper().CreateResponse(await _service.List());
        }
    }
}
