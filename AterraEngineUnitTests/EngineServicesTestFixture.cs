// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------

using AterraEngine.Engine;
using AterraEngine.Interfaces.Engine;
using Microsoft.Extensions.DependencyInjection;

namespace AterraEngineUnitTests;

// ---------------------------------------------------------------------------------------------------------------------
// Code
// ---------------------------------------------------------------------------------------------------------------------
public class EngineServicesTestFixture: IDisposable {
    
    public EngineServicesTestFixture()
    {
        // Create a service collection and register necessary services
        var service_collection = new ServiceCollection();

        // Register services needed for your tests
        service_collection.AddSingleton<IEngineDefaults,EngineDefaults>();

        // Add more service registrations as needed

        // Build the service provider
        EngineServices.buildServiceProvider(service_collection);
    }

    public void Dispose() {
        // TODO release managed resources here
        EngineServices.disposeServiceProvider();
    }
}