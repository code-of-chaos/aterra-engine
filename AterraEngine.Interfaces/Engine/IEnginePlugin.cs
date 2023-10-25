// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------
using Microsoft.Extensions.DependencyInjection;

namespace AterraEngine.Interfaces.Engine;
// ---------------------------------------------------------------------------------------------------------------------
// Interface
// ---------------------------------------------------------------------------------------------------------------------
public interface IEnginePlugin {
    public IServiceCollection addEngineServices(IServiceCollection service_collection);
    public void defineResx();
    public void main();
}