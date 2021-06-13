using System.Threading.Tasks;
using Bot.Business.Abstractions.ServicesAbstractions;
using Microsoft.AspNetCore.Mvc;
using Telegram.Bot.Types;

namespace Bot.Api.Controllers
{
    [Route("api/[controller]")]
    public class UpdateController : Controller
    {
        private readonly IUpdateService _updateService;

        public UpdateController(IUpdateService updateService)
        {
            _updateService = updateService;
        }

        // POST api/update
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Update update)
        {
            await _updateService.HandleUpdateAsync(update);
            return Ok();
        }
    }
}
