using Microsoft.AspNetCore.Mvc;
using business;
using Microsoft.EntityFrameworkCore;
using DAL;
using Azure;

namespace api.Controllers;

[ApiController]
[ApiVersion("1", Deprecated = false)]
[Route("api/v{version:apiVersion}/[controller]/[action]")]
public class MiscController : ControllerBase
{
    private readonly ILogger<MiscController> _logger;
    private readonly SocialLifeContext _context;
    private readonly PeopleOperations _po; 
    private readonly IConfiguration _config;

    public MiscController(
      ILogger<MiscController> logger,
      SocialLifeContext context,
      IConfiguration config
      ) {
        _logger  = logger;
        _context = context;
        _config  = config;

        PeopleOperations po = new PeopleOperations(_context);
        _po                 = po;
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

    /// <summary>
    /// Get last_name of the user 
    /// </summary>
    /// <returns></returns>
    [HttpGet(Name = "get-last-name")]
    public string GetLastName(){
      var name = DAL.DataOperations.GetName("thisDoesNotMatter", _config.GetConnectionString("DataHub") ?? throw new NotImplementedException());
      return name; 
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
