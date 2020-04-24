using Microsoft.Extensions.DependencyInjection;
using PMLAB_TestProject.Services;

public static class ServiceProviderExtensions
{
    public static void AddCalculatorService(this IServiceCollection services)
    {
        services.AddTransient<CalculatorService>();
    }
    public static void AddHistoryService(this IServiceCollection services)
    {        
        services.AddTransient<HistoryService>();
    }
}