// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------
using Microsoft.Extensions.DependencyInjection;

namespace AterraEngine.Interfaces.Engine;
// ---------------------------------------------------------------------------------------------------------------------
// Interface Code
// ---------------------------------------------------------------------------------------------------------------------
public interface IEngineServicesExtension {
    public static void addLoggingServices(IServiceCollection service_collection){}
    public static void addEngineServices(IServiceCollection service_collection){}
}
