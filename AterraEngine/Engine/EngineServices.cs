﻿// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------
using Microsoft.Extensions.DependencyInjection;

using AterraEngine.Interfaces.Engine;
using AterraEngine.Interfaces.Logic.EngineObjects;

namespace AterraEngine.Engine;
// ---------------------------------------------------------------------------------------------------------------------
// Code
// ---------------------------------------------------------------------------------------------------------------------
/// <summary>
/// A static class responsible for managing and providing services for the Aterra Engine.
/// </summary>
public static class EngineServices {
    private static ServiceProvider _service_provider = null!;
    
    // -----------------------------------------------------------------------------------------------------------------
    // Methods  
    // -----------------------------------------------------------------------------------------------------------------
    /// <summary>
    /// Builds the service provider using the provided collection of services.
    /// </summary>
    /// <param name="service_collection">The collection of services to be used for building the service provider.
    /// Make sure to add necessary services to the collection before calling this method, typically after invoking one or more <see cref="EnginePlugin.addEngineServices"/>.</param>
    public static void buildServiceProvider(IServiceCollection service_collection) {
        _service_provider = service_collection.BuildServiceProvider();
    }

    /// <summary>
    /// Retrieves a required service of type <typeparamref name="T"/> from the service provider.
    /// </summary>
    /// <typeparam name="T">The type of service to retrieve.</typeparam>
    /// <returns>The instance of the requested service.</returns>
    public static T getService<T>() where T : notnull{
        return _service_provider.GetRequiredService<T>();
    }
    
    // -----------------------------------------------------------------------------------------------------------------
    // Quick Call Methods  
    // -----------------------------------------------------------------------------------------------------------------
    public static IEngineObjectManager getEOM() =>  _service_provider.GetRequiredService<IEngineObjectManager>();
    public static IEngineFlags getEF() =>           _service_provider.GetRequiredService<IEngineFlags>();
    public static IEngineDefaults getED() =>        _service_provider.GetRequiredService<IEngineDefaults>();
    public static IEngine getEngine() =>            _service_provider.GetRequiredService<IEngine>();
    public static IEngineCultureManager getCM() =>        _service_provider.GetRequiredService<IEngineCultureManager>();
    public static IEngineResxManager getRESXM() =>        _service_provider.GetRequiredService<IEngineResxManager>();
    public static IEngineRandom getRANDOM() =>      _service_provider.GetRequiredService<IEngineRandom>();
}