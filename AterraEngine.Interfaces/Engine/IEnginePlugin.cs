// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------
using Microsoft.Extensions.DependencyInjection;

namespace AterraEngine.Interfaces.Engine;
// ---------------------------------------------------------------------------------------------------------------------
// Interface
// ---------------------------------------------------------------------------------------------------------------------
public interface IEnginePlugin {
    public int id_prefix { get;}
    public const string local_resx = null!;
    
    public void defineEngineServices(IServiceCollection service_collection);
    public void defineResx();
    public void defineLogic();

    public void Initialize(int idPrefix);
}