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
}
