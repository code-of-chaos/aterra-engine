// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------
using Microsoft.Extensions.Logging;
using AterraEngine.Lib.Localization;
using AterraEngine.Logic.EngineObjects;
using Microsoft.Extensions.DependencyInjection;

namespace AterraEngine.Engine;
// ---------------------------------------------------------------------------------------------------------------------
// Code
// ---------------------------------------------------------------------------------------------------------------------
/// <summary>
/// A static class that provides extension methods for configuring and adding base services to the service collection.
/// </summary>
public static class EngineServicesExtension {
    // -----------------------------------------------------------------------------------------------------------------
    // Base Services
    // -----------------------------------------------------------------------------------------------------------------
    /// <summary>
    /// Adds logging services to the provided service collection, enabling console logging.
    /// </summary>
    /// <param name="service_collection">The service collection to which logging services should be added.</param>
    public static void addLoggingServices(this IServiceCollection service_collection) {
        service_collection.AddLogging(builder => { builder.AddConsole(); });
    }

    /// <summary>
    /// Adds essential services for the Aterra Engine to the provided service collection.
    /// This includes services for engine flags, engine core, culture management, and more.
    /// </summary>
    /// <param name="service_collection">The service collection to which services should be added.</param>
    public static void addEngineServices(this IServiceCollection service_collection) {
        service_collection.AddSingleton<IEngineFlags, EngineFlags>();
        service_collection.AddSingleton<IEngine, Engine>();
        service_collection.AddSingleton<ICultureManager, CultureManager>();
        service_collection.AddSingleton<IResxManager, ResxManager>();
        
        service_collection.AddSingleton<IEngineObjectManager,EngineObjectManager>();
        service_collection.AddTransient<IEntity>(provider => EngineServices.getEOM().createEntity<Entity>());
        service_collection.AddTransient<IItem>(provider => EngineServices.getEOM().createItem<Item>());
        service_collection.AddSingleton<IPlayer>(provider => EngineServices.getEOM().createPlayer<Player>()); // Because there can only ever be one player
    }
}
