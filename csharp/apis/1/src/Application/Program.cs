using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using DAL;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddDbContext<SocialLifeContext>( options => {
  //options.UseMemoryCache(); //what does this do??? 
<<<<<<< HEAD
  options.UseSqlServer("Server=localhost,1433; Database=DataHub; User=SA;Password=putStrLn $ p2ssw0rd; TrustServerCertificate=True;");
=======
  options.UseSqlServer("Server=localhost,1433;Database=DataHub;User=SA;Password=P@ssw0rd;TrustServerCertificate=True;");
>>>>>>> 3aaafc9 (quit being violent woman)
});

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at
// https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen( options => {
  options.SwaggerDoc("v1",
      new Microsoft.OpenApi.Models.OpenApiInfo {
      Title = "My API", Version = "1"});

  var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml"; 
  var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
 
  options.IncludeXmlComments(xmlPath);
});

builder.Services.AddApiVersioning(options => {
  options.DefaultApiVersion = new ApiVersion(1,0);
  options.AssumeDefaultVersionWhenUnspecified = true;
  options.ReportApiVersions = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
  app.UseSwagger();
  app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
