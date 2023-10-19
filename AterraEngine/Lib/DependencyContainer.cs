// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace AterraEngine.Lib;
// ---------------------------------------------------------------------------------------------------------------------
// Interface Code
// ---------------------------------------------------------------------------------------------------------------------
// public interface IDependencyContainer {
//     static IDependencyContainer instance { get; } = null!;
//
//     void registerService<TService, TImplementation>(ServiceLifetime lifetime = ServiceLifetime.Transient)
//         where TService : class
//         where TImplementation : class, TService ;
//     void buildServiceProvider();
//     T getService<T>() where T : notnull;
// }
// ---------------------------------------------------------------------------------------------------------------------
// Code
// ---------------------------------------------------------------------------------------------------------------------
public static class DependencyContainer {
    private static  readonly ServiceCollection _service_collection = new();
    private static ServiceProvider _service_provider = null!;
    
    // -----------------------------------------------------------------------------------------------------------------
    // Methods  
    // -----------------------------------------------------------------------------------------------------------------
    public static void registerService<TService, TImplementation>(ServiceLifetime lifetime = ServiceLifetime.Transient)
        where TService : class
        where TImplementation : class, TService {
        
        // Store in collection
        _service_collection.Add(new ServiceDescriptor(
            typeof(TService), 
            typeof(TImplementation), 
            lifetime
        ));
    }
    
    public static void buildServiceProvider() {
        _service_provider = _service_collection.BuildServiceProvider();
    }

    public static  T getService<T>() where T : notnull{
        return _service_provider.GetRequiredService<T>();
    }
    
}