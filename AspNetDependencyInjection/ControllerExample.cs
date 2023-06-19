using AspNetDependencyInjection.InterfacesExamples;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace AspNetDependencyInjection
{
    public class ControllerExample : ControllerBase
    {
        private readonly IService _service;

        public ControllerExample(IService service)
        {
            _service = service;
        }

        [HttpGet("/one")]
        public IActionResult GetOne()
        {
            return Ok(_service.GetType().Name);
        }

        [HttpGet("/many")]
        public IActionResult GetMany(
            [FromServices] IEnumerable<IService> services
            )
        {
            return Ok(services.Select(x => x.GetType().Name));
        }

        [HttpGet("/options")]
        public IActionResult GetOptions(
            [FromServices] IOptions<OptionsExample> options
            )
        {
            return Ok(options.Value.OptionsName);
        }
    }
}
