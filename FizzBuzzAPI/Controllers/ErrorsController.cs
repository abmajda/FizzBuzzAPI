using Microsoft.AspNetCore.Mvc;

namespace FizzBuzzAPI.Controllers
{
    [Route("/error")]
    public class ErrorsController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetError()
        {
            return Problem();
        }

        [HttpPost]
        public IActionResult PostError()
        {
            return Problem();
        }

        [HttpDelete]
        public IActionResult DeleteError()
        {
            return Problem();
        }
    }
}
