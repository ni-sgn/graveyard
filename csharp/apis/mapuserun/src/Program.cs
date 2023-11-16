using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

string cs = builder.Configuration.GetConnectionString("PeopleCS");
Console.WriteLine($"{cs}");

builder.Services.AddDbContext<DHContext>(options => 
    options.UseSqlServer(
      builder.Configuration.GetConnectionString("PeopleCS") ?? 
        throw new ArgumentNullException("This connection string is not"
          + "visible")
      )
    );


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

IServiceProvider sp = builder.Services.BuildServiceProvider();
app.MapGet("/", () => {
      var _context = sp.GetService(typeof(DHContext)) as DHContext;
      return _context?.people?.ToList()  
        ?? throw new ArgumentNullException("One of this is null");
    });

app.MapGet("/hello", Functions.simpleFunction); 

app.MapGet("/getPerson/{name}", (string name) => {
      var _context = sp.GetService(typeof(DHContext)) as DHContext;
      return _context?.people?
        .Where(pers => pers.first_name == name)
        .ToList();
    });


app.Run();

public class Functions {
  public static string simpleFunction() {
    return "hello from a static function";
  }
}
