// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------
namespace AterraEngine.Interfaces.Structs; 
// ---------------------------------------------------------------------------------------------------------------------
// Code
// ---------------------------------------------------------------------------------------------------------------------
public interface IAterraEngineId {
    public int prefix_value { get; init; }
    public int value { get; init; }
    public string asHex { get; }
    public static IAterraEngineId fromHex(string hex_value) { throw new NotImplementedException(); }
}