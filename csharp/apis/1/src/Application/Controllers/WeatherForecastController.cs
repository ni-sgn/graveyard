using Microsoft.AspNetCore.Mvc;
using business;
using Microsoft.EntityFrameworkCore;
using DAL;

namespace api.Controllers;

[ApiController]
[ApiVersion("1", Deprecated = false)]
[Route("api/v{version:apiVersion}/[controller]/[action]")]
public class MiscController : ControllerBase
{
    private static readonly string[] Summaries = new[] {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<MiscController> _logger;
    private readonly SocialLifeContext _context;
    private readonly PeopleOperations _po; 

    public  MiscController(
      ILogger<MiscController> logger,
      SocialLifeContext context 
      ) {
        _logger = logger;
        _context = context;
        PeopleOperations po = new PeopleOperations(_context);
        _po = po;
    }

    /// <summary>
    /// Hello, I just return the most unique phrase in programming ever 
    /// </summary>
    /// <returns>string</returns>
    [HttpGet(Name = "GetWeatherForecast")]
    public string Get()
    {
      return "hello world";
    }

    [HttpGet(Name = "OtherThanGet")]
    public string Get2(){
      return "something else";
    }

    [HttpPost(Name = "AddPerson")]
    public ActionResult AddPerson(string firstname, string lastname, DateTime birthDate) {
      try {
        _po.CreatePerson(new DAL.entities.Person{first_name = firstname, last_name = lastname, date_of_birth = birthDate});
        return StatusCode(200);
      } catch (Exception ex) {
        _logger.LogError(ex, "something went wrong");
        return StatusCode(400); //what's 400 btw?
      }
    }

}
