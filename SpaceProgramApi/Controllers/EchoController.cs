using Microsoft.AspNetCore.Mvc;

namespace SpaceProgramApi.Controllers
{
    [Route("api")]
    [ApiController]
    public class EchoController : ControllerBase
    {
        [Route("echo")]
        [HttpGet]
        public IActionResult Echo()
        {
            return Ok("Echo Gui " + DateTime.Now);
        }
    }
}
