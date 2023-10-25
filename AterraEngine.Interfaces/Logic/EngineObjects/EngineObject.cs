// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------
using Microsoft.Extensions.Logging;

namespace AterraEngine.Interfaces.Logic.EngineObjects;
// ---------------------------------------------------------------------------------------------------------------------
// Interface Code
// ---------------------------------------------------------------------------------------------------------------------
public interface IEngineObject {
    string? hex_id { get;}
    int id { get; init; }
    ILogger<IEngineObjectManager> logger { init;}
    string resource_location { get; init; }
    
}