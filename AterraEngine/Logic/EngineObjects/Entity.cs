// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------
using AterraEngine.Engine;
using AterraEngine.Interfaces.Logic.EngineObjects;
using Microsoft.Extensions.Logging;

namespace AterraEngine.Logic.EngineObjects;
// ---------------------------------------------------------------------------------------------------------------------
// Code
// ---------------------------------------------------------------------------------------------------------------------
public class Entity : EngineObject, IEntity {
    public string internal_name { get; set; } = "UNDEFINED";
    public string display_name => EngineServices.getRESXM()
        .getResourceManager(resource_location)
        .GetString(internal_name) 
        ?? $"LOCAL_NOT_FOUND={resource_location}:{internal_name}";
}