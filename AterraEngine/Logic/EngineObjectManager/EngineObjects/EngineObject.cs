// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------
using AterraEngine.Engine;
using Serilog;
using AterraEngine.Lib.Structs;
using AterraEngine.Interfaces.Logic.EngineObjectManager.EngineObjects;

namespace AterraEngine.Logic.EngineObjectManager.EngineObjects;
// ---------------------------------------------------------------------------------------------------------------------
// Code
// ---------------------------------------------------------------------------------------------------------------------
public class EngineObject : IEngineObject {
    public AterraEngineId id { get; init; }
    public string? resource_location { get; init; } = null!;
    public string internal_name { get; init; } = null!;
    public string display_name => EngineServices
                                      .getRESXM()
                                      .getResourceManager(resource_location)
                                      .GetString(internal_name) 
                                  ?? _logAndReturnFallbackDisplayName();
    
    // ReSharper disable once MemberCanBePrivate.Global
    protected string _logAndReturnFallbackDisplayName() {
        string txt = $"LOCAL_NOT_FOUND={resource_location}:{internal_name}";
        _logger.Error(txt);
        return txt;
    }

    protected ILogger _logger = EngineServices.getLogger();
    
}