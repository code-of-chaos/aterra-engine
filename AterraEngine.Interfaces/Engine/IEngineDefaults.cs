// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------
namespace AterraEngine.Interfaces.Engine;

// ---------------------------------------------------------------------------------------------------------------------
// Code
// ---------------------------------------------------------------------------------------------------------------------
public interface IEngineDefaults {
    int     AterraEngineId_value_padding { get; }
    int     AterraEngineId_prefix_padding{ get; }
    float   item_weight{ get; }
    string  entity_internal_name{ get; }
    float   entity_health_max{ get; }
    string  item_internal_name { get; }
}