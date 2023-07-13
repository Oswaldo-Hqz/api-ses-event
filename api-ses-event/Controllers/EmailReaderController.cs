using Microsoft.AspNetCore.Mvc;
using sesBO;

namespace api_ses_event.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailReaderController : ControllerBase
    {
        private EmailReaderBO erBO;

        [HttpGet("getEmailJson")]
        public async Task<ActionResult> getEmailJson(string urlEmail)
        {
            try
            {
                using (erBO = new EmailReaderBO())
                {
                    var result = erBO.getEmailJsonBO(urlEmail);
                    return Ok(result);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
