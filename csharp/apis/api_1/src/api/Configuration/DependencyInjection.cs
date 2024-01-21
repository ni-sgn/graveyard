namespace api.Configuration;

using Helpers;

public static class DependencyInjection {
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services
    ){
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        return services;
    }

    public static IServiceCollection AddApplication(
        this IServiceCollection services
    ){
        return services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(AssemblyReference.Assembly));
    }
}