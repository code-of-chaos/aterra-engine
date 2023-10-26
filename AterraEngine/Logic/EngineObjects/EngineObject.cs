// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------
using AterraEngine.Engine;
using AterraEngine.Lib;
using Microsoft.Extensions.Logging;

using AterraEngine.Interfaces.Logic.EngineObjects;

namespace AterraEngine.Logic.EngineObjects;
// ---------------------------------------------------------------------------------------------------------------------
// Code
// ---------------------------------------------------------------------------------------------------------------------
public class EngineObject : IEngineObject {
    public int id { get; init; }
    public string resource_location { get; init; } = null!;
    
    private readonly ILogger<IEngineObject> _logger;
    
    public string hex_id => IdConverter.toHex(id, AterraEngineDefaults.hex_padding);
    
    // -----------------------------------------------------------------------------------------------------------------
    // Constructor
    // -----------------------------------------------------------------------------------------------------------------
    public EngineObject(int id, ILogger<IEngineObject> logger)
    {
        this.id = id;
        _logger = logger;
    }
}