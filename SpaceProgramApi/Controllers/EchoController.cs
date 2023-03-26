using Microsoft.AspNetCore.Mvc;

namespace SpaceProgramApi.Controllers
{
    [Route("api/echo")]
    public class EchoController : ControllerBase
    {
        [HttpGet()]
        public IActionResult Echo()
        {
            return Ok($"Echo! {DateTime.Now}");
        }

        [HttpGet("{dummy}")]
        public IActionResult Echo(int dummy)
        {
            return Ok($"Echo! {dummy}");
        }
    }
}
