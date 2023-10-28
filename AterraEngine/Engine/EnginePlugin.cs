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
    public int id_prefix { get; private set; }
    public const string local_resx = null!;
    
    public virtual void defineEngineServices(IServiceCollection service_collection) {}
    public virtual void defineResx() {} 
    public virtual void defineLogic() {}
    
    public void Initialize(int idPrefix) {
        id_prefix = idPrefix;
    }
}