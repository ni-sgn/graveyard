using Microsoft.AspNetCore.Mvc;

namespace api.Controllers {
    [ApiController]
    //[ApiVersion("v?")]
    [Route("[controller]")] 
    
    public class TestController : ControllerBase {

        private readonly ILogger<TestController> _logger;
        public TestController(ILogger<TestController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "get-name")]
        public string GetName() {
            _logger.LogInformation("Testtest");
            return "hi,my-name-is,hi,my-name-is";
        }
        
    }
}
