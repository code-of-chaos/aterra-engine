// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------

using AterraEngine.Engine;

namespace AterraEngine.Logic.EngineObjects;
// ---------------------------------------------------------------------------------------------------------------------
// Interface Code
// ---------------------------------------------------------------------------------------------------------------------
public interface IEntity:IEngineObject {
    public string internal_name { get; set; }
    public string? display_name { get; }
}
// ---------------------------------------------------------------------------------------------------------------------
// Code
// ---------------------------------------------------------------------------------------------------------------------
public class Entity : EngineObject, IEntity {
    public string internal_name { get; set; } = "UNDEFINED";
    public string? display_name => EngineServices.getRESXM().getResourceManager(resource_location).GetString(internal_name);
}