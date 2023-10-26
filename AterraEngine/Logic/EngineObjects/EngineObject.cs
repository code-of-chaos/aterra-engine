// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------
using AterraEngine.Engine;
using AterraEngine.Lib;
using Microsoft.Extensions.Logging;

using AterraEngine.Interfaces.Logic.EngineObjects;
using AterraEngine.Lib.Structs;

namespace AterraEngine.Logic.EngineObjects;
// ---------------------------------------------------------------------------------------------------------------------
// Code
// ---------------------------------------------------------------------------------------------------------------------
public class EngineObject : IEngineObject {
    public AterraEngineId id { get; init; }
    public string resource_location { get; init; } = null!;

    private ILogger<IEngineObject> _logger = EngineServices.getLogger<IEngineObject>();
    
}