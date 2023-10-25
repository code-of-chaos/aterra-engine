// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------

using AterraEngine.Interfaces.Engine;

namespace AterraEngine.Engine;
// ---------------------------------------------------------------------------------------------------------------------
// Code
// ---------------------------------------------------------------------------------------------------------------------
public class EngineDefaults : IEngineDefaults{
    public int hex_padding => 8;
    public float item_weight => 1f;
    public string entity_internal_name => "Undefined Entity Name";
    public string item_internal_name => "Undefined Item Name";
}