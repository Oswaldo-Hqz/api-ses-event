using Microsoft.AspNetCore.Mvc;
using Nelibur.ObjectMapper;
using sesEntities;

namespace api_ses_event.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SesEventController : ControllerBase
    {
        [HttpPost("mappingSES")]
        public async Task<ActionResult> mappingSES(SESEvent json)
        {
            var res = TinyMapper.Map<JsonResponse>(json);

            return Ok(res);
        }
    }
}
