using Microsoft.AspNetCore.Mvc;

namespace WebApplication.Controllers
{
    [Route("csharp")]
    public class CsharpController: ControllerBase
    {
        private readonly IHelloWorldGenerator _helloWorldGenerator;

        public CsharpController(IHelloWorldGenerator helloWorldGenerator)
            => _helloWorldGenerator = helloWorldGenerator;
        
        [HttpGet]
        public IActionResult Get() => Ok(_helloWorldGenerator.Say());
    }
}