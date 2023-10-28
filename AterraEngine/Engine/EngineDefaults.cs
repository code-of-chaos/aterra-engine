// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------
using AterraEngine.Interfaces.Engine;
namespace AterraEngine.Engine;

// ---------------------------------------------------------------------------------------------------------------------
// Code
// ---------------------------------------------------------------------------------------------------------------------
public class EngineDefaults :IEngineDefaults {
    public new const string     filepath_engine_prep = "engine_prep.json";
    public new const int        hex_padding = 8;
    public new const float      item_weight = 1f;
    public new const string     entity_internal_name = "ENTITY_NAME_UNDEFINED";
    public new const float      entity_health_max = 100f;
    public new const string     item_internal_name = "ITEM_NAME_UNDEFINED";
}