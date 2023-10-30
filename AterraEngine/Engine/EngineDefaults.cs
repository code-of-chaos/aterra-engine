// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------
using AterraEngine.Interfaces.Engine;
namespace AterraEngine.Engine;

// ---------------------------------------------------------------------------------------------------------------------
// Code
// ---------------------------------------------------------------------------------------------------------------------
public class EngineDefaults :IEngineDefaults {
    public int AterraEngineId_value_padding => 6;
    public int AterraEngineId_prefix_padding => 3;
    
    public string entity_internal_name => "ENTITY_NAME_UNDEFINED";
    public float entity_health_max => 100f;
    
    public float item_weight => 1f;
    public string item_internal_name => "ITEM_NAME_UNDEFINED";

    public bool tile_isWalkable => false;
    
    public string area_internal_name => "AREA_UNDEFINED";
    public string tile_internal_name => "TILE_UNDEFINED";
    public string poi_internal_name  => "POI_UNDEFINED";
}