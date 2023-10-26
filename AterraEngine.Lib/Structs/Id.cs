// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------
namespace AterraEngine.Lib.Structs; 
// ---------------------------------------------------------------------------------------------------------------------
// Code
// ---------------------------------------------------------------------------------------------------------------------
public readonly struct AterraEngineId { // Todo as the project grows: check performance impact of this being a struct vs class
    public int value { get; init; }
    
    public string asHex => IdConverter.toHex(value, AterraEngineDefaults.hex_padding);
    public static AterraEngineId fromHex(string hex_value) => new(){ value = IdConverter.toInt(hex_value) };
}