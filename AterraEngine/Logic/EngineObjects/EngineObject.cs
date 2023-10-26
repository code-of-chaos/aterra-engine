// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------
using AterraEngine.Engine;
using Serilog;
using AterraEngine.Interfaces.Logic.EngineObjects;
using AterraEngine.Lib.Structs;

namespace AterraEngine.Logic.EngineObjects;
// ---------------------------------------------------------------------------------------------------------------------
// Code
// ---------------------------------------------------------------------------------------------------------------------
public class EngineObject : IEngineObject {
    public AterraEngineId id { get; init; }
    public string resource_location { get; init; } = null!;

    protected ILogger _logger = EngineServices.getLogger();
    
}