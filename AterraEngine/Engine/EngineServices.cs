// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------

using AterraEngine.Lib.Localization;
using AterraEngine.Logic.EngineObjects;
using Microsoft.Extensions.DependencyInjection;

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
    /// Make sure to add necessary services to the collection before calling this method, typically after invoking <see cref="EngineServicesExtension.addEngineServices"/>.</param>
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
    
    // /// <summary>
    // /// Create an instance of a service of type <typeparamref name="T"/>.
    // /// </summary>
    // /// <typeparam name="T">The type of service to create or retrieve.</typeparam>
    // /// <param name="constructor_arguments">Optional constructor arguments for creating the service instance.</param>
    // /// <returns>An instance of the service of type <typeparamref name="T"/>.</returns>
    // /// <exception cref="InvalidOperationException">Thrown when the service provider cannot provide an instance of type <typeparamref name="T"/>.</exception>
    // /// <remarks>
    // /// This method creates an instance of the specified service type <typeparamref name="T" />,
    // /// either by using provided constructor arguments or by retrieving it from a service provider.
    // /// </remarks>
    // public static T getService<T>(params object[]? constructor_arguments) where T : notnull{
    //     if (constructor_arguments is null) {
    //         return _service_provider.GetRequiredService<T>();
    //     }
    //     // this has to return a value
    //     return (T)Activator.CreateInstance(typeof(T), constructor_arguments)!;
    // }
    
    // -----------------------------------------------------------------------------------------------------------------
    // Quick Call Methods  
    // -----------------------------------------------------------------------------------------------------------------
    public static IEngineObjectManager getEOM() =>  _service_provider.GetRequiredService<IEngineObjectManager>();
    public static IEngineFlags getEF() =>           _service_provider.GetRequiredService<IEngineFlags>();
    public static IEngineDefaults getED() =>           _service_provider.GetRequiredService<IEngineDefaults>();
    public static IEngine getEngine() =>            _service_provider.GetRequiredService<IEngine>();
    public static ICultureManager getCM() =>        _service_provider.GetRequiredService<ICultureManager>();
    public static IResxManager getRESXM() =>        _service_provider.GetRequiredService<IResxManager>();
    public static IEngineRandom getRANDOM() =>      _service_provider.GetRequiredService<IEngineRandom>();
}