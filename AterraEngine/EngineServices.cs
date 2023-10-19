// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------

using System.Numerics;
using System.Runtime;
using AterraEngine.Lib;
using AterraEngine.Lib.Localization;
using AterraEngine.Logic.EngineObjects;
using AterraEngine.Logic.Items;
using Microsoft.Extensions.DependencyInjection;

namespace AterraEngine;

// ---------------------------------------------------------------------------------------------------------------------
// Code
// ---------------------------------------------------------------------------------------------------------------------
public static class EngineServices {
    // -----------------------------------------------------------------------------------------------------------------
    // Base Services
    // -----------------------------------------------------------------------------------------------------------------
    public static IServiceCollection addEngineServices(this IServiceCollection service_collection) {
        service_collection.AddSingleton<IEngineFlags, EngineFlags>();
        service_collection.AddSingleton<IItemManager, ItemManager>();
        service_collection.AddSingleton<IEngine, Engine>();
        service_collection.AddSingleton<IEngineFlags, EngineFlags>();
        service_collection.AddSingleton<ICultureManager, CultureManager>();
        service_collection.AddSingleton<IResxManager, ResxManager>();
        service_collection.AddSingleton<IEngineObjectManager,EngineObjectManager>();
        service_collection.AddTransient<IEntity>(provider => DependencyContainer.getService<IEngineObjectManager>().createEntity<Entity>());
    
        return service_collection;
    }

    // -----------------------------------------------------------------------------------------------------------------
    // Replacements
    //      TODO look into this code. It works, but I'm afraid it's prone to breaking a lot
    // -----------------------------------------------------------------------------------------------------------------
    public static void replaceEngineService<TService, TNewImplementation>(this IServiceCollection service_collection) 
        where TNewImplementation : TService, new()
        where TService : class 
        => service_collection._replaceEngineService<TService>(provider => new TNewImplementation());
    
    public static void replaceEngineService<TService>(this IServiceCollection service_collection, Func<IServiceProvider, TService> new_factory) 
        where TService : class 
        => service_collection._replaceEngineService<TService>(new_factory);
    
    private static void _replaceEngineService<TService>(this IServiceCollection service_collection, Func<IServiceProvider, TService> new_factory)
        where TService : class {
        
        // Look if the service is registered
        //  If not, then you have a big issue
        var service_descriptor = service_collection.FirstOrDefault(
            descriptor => descriptor.ServiceType == typeof(TService)
        );
        if (service_descriptor is null) {
            throw new AmbiguousImplementationException($"Service wasn't found: {typeof(TService)}");
        }
        
        // Remove old implementation
        service_collection.Remove(service_descriptor);
        
        // Check to create new factory
        
        // assign new implementation
        switch (service_descriptor.Lifetime) {
            case ServiceLifetime.Transient:
                service_collection.AddTransient<TService>(new_factory) ;
                break ;
            case ServiceLifetime.Singleton:
                service_collection.AddSingleton<TService>(new_factory) ;
                break ;
            case ServiceLifetime.Scoped:
                service_collection.AddScoped<TService>(new_factory) ;
                break ;
            default: {
                throw new AmbiguousImplementationException(
                    $"ServiceLifetime wasn't found: {service_descriptor.Lifetime}");
            }
        }
    }
    
}
