// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------
using Microsoft.Extensions.DependencyInjection;

namespace AterraEngine.Interfaces.Engine;
// ---------------------------------------------------------------------------------------------------------------------
// Interface
// ---------------------------------------------------------------------------------------------------------------------
public interface IEnginePlugin {
    const string local_resx = null!;
    
    public void addEngineServices(IServiceCollection service_collection);
    public void defineResx();
    public void main();
}