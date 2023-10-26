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
    public const string local_resx = null!;

    public virtual void addEngineServices(IServiceCollection service_collection) {}
    public virtual void defineResx() {} 
    public virtual void main() {} 
}