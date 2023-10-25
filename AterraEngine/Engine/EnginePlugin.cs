// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------
using Microsoft.Extensions.DependencyInjection;

using AterraEngine.Interfaces.Engine;

namespace AterraEngine.Engine;
// ---------------------------------------------------------------------------------------------------------------------
// Code
// ---------------------------------------------------------------------------------------------------------------------
public class EnginePlugin : IEnginePlugin {
    public virtual IServiceCollection addEngineServices(IServiceCollection service_collection) => service_collection;
    public virtual void defineResx() {} 
    public virtual void main() {} 
}