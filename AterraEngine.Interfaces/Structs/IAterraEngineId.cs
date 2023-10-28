// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------
namespace AterraEngine.Interfaces.Structs; 
// ---------------------------------------------------------------------------------------------------------------------
// Code
// ---------------------------------------------------------------------------------------------------------------------
public interface IAterraEngineId {
    public int plugin_id { get; init; }
    public int object_id { get; init; }
    public string asHex { get; }
    public static IAterraEngineId fromHex(string hex_value) { throw new NotImplementedException(); }
}