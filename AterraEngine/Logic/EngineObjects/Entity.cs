// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------

using AterraEngine.Engine;
using AterraEngine.Interfaces.Engine;
using AterraEngine.Interfaces.Logic.EngineObjects;
using Microsoft.Extensions.Logging;

namespace AterraEngine.Logic.EngineObjects;
// ---------------------------------------------------------------------------------------------------------------------
// Code
// ---------------------------------------------------------------------------------------------------------------------
public class Entity : EngineObject, IEntity {
    public string internal_name { get; set; } = "UNDEFINED";
    public string? display_name => EngineServices.getRESXM()
        .getResourceManager(resource_location)
        .GetString(internal_name);

    public Entity(int id, ILogger<IEngineObject> logger) : base(id, logger) { }
}