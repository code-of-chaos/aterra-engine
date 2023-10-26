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
    public string hex_id => IdConverter.toHex(id, EngineServices.getED().hex_padding);
    public int id { get; init; }
    private readonly ILogger<IEngineObject> _logger;
    public string resource_location { get; init; } = null!;
    
    // -----------------------------------------------------------------------------------------------------------------
    // Constructor
    // -----------------------------------------------------------------------------------------------------------------
    public EngineObject(int id, ILogger<IEngineObject> logger)
    {
        this.id = id;
        this._logger = logger;
    }
}