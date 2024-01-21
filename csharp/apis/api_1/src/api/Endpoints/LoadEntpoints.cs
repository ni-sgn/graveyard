namespace api.Endpoints;

using MediatR;
using api.Commands;
public static class LoadEnpoints
{
    public static void MapLoanEndpoints(this IEndpointRouteBuilder app){
        app.MapPost("api/loan/get_application{id}", async (GetLoanDataCommand command, ISender sender) =>
        {
            throw new NotImplementedException();
            var a = await sender.Send<int>(command);

            return Results.Ok(a);
        })
        .WithName("GetWeatherForecast")
        .WithOpenApi();

;
    } 
}