using api.Endpoints;
using Serilog;
using api.Middleware; 
using api.Configuration;


var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddInfrastructure()
    .AddApplication();

builder.Host.UseSerilog((context, loggerConfig) => 
    loggerConfig.ReadFrom.Configuration(context.Configuration));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseMiddleware<RequestLogContextMiddleware>();
app.UseSerilogRequestLogging();
app.MapLoanEndpoints();
app.Run();

app.UseEndpoints(cfg => cfg.MapLoanEndpoints());