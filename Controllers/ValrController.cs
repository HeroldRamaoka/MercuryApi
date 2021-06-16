using System.Threading.Tasks;
using MercuryApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MercuryApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ValrController : ControllerBase
    {
        readonly IValrService _valrService;

        public ValrController(IValrService valrService)
        {
            _valrService = valrService;
        }

        [HttpGet("calculateXrpArbitrage")]
        public async Task<ActionResult> CalculateXrpArbitrage()
        {
            var bitcoinBidPrice = await _valrService.GetValrValue("BTCZAR");

            return Ok();
        }
    }
}
