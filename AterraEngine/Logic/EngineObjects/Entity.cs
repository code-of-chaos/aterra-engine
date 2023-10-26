// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------
using AterraEngine.Engine;
using AterraEngine.Interfaces.Logic.EngineObjects;
using AterraEngine.Lib;

namespace AterraEngine.Logic.EngineObjects;
// ---------------------------------------------------------------------------------------------------------------------
// Code
// ---------------------------------------------------------------------------------------------------------------------
public class Entity : EngineObject, IEntity {
    public string internal_name { get; set; } = AterraEngineDefaults.entity_internal_name;

    public string display_name => EngineServices.getRESXM()
        .getResourceManager(resource_location)
        .GetString(internal_name) 
        ?? _logAndReturnFallbackDisplayName();
    
    // ReSharper disable once MemberCanBePrivate.Global
    protected string _logAndReturnFallbackDisplayName() {
        string txt = $"LOCAL_NOT_FOUND={resource_location}:{internal_name}";
        _logger.Error(txt);
        return txt;
    }
}