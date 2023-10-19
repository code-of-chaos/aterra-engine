// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------

using AterraEngine.Logic.EngineObjects;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace AterraEngine.Lib;
// ---------------------------------------------------------------------------------------------------------------------
// Code
// ---------------------------------------------------------------------------------------------------------------------
public static class DependencyContainer {
    private static ServiceProvider _service_provider = null!;
    
    // -----------------------------------------------------------------------------------------------------------------
    // Methods  
    // -----------------------------------------------------------------------------------------------------------------
    public static void buildServiceProvider(IServiceCollection service_collection) {
        _service_provider = service_collection.BuildServiceProvider();
    }

    public static T getService<T>() where T : notnull{
        return _service_provider.GetRequiredService<T>();
    }
    
    // -----------------------------------------------------------------------------------------------------------------
    // Quick Methods  
    // -----------------------------------------------------------------------------------------------------------------
    public static IEngineObjectManager getEOM() {
        return _service_provider.GetRequiredService<IEngineObjectManager>();
    }
    
    public static IEngineFlags getEF() {
        return _service_provider.GetRequiredService<IEngineFlags>();
    }
    
    public static IEngine getEngine() {
        return _service_provider.GetRequiredService<IEngine>();
    }
}