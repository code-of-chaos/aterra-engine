// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------
namespace AterraEngine.Engine;
// ---------------------------------------------------------------------------------------------------------------------
// Interface Code
// ---------------------------------------------------------------------------------------------------------------------
public interface IEngineDefaults{
    int hex_padding { get;}
    float item_weight { get;}
    string entity_internal_name { get;}
    string item_internal_name { get;}
}

// ---------------------------------------------------------------------------------------------------------------------
// Code
// ---------------------------------------------------------------------------------------------------------------------
public class EngineDefaults : IEngineDefaults{
    public int hex_padding => 8;
    public float item_weight => 1f;
    public string entity_internal_name => "Undefined Entity Name";
    public string item_internal_name => "Undefined Item Name";
}