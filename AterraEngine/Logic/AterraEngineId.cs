// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------
using AterraEngine.Engine;
using AterraEngine.Interfaces.Logic;
using AterraEngine.Lib;
namespace AterraEngine.Logic; 
// ---------------------------------------------------------------------------------------------------------------------
// Code
// ---------------------------------------------------------------------------------------------------------------------
public readonly struct AterraEngineId : IAterraEngineId{ // Todo as the project grows: check performance impact of this being a struct vs class
    public int value { get; init; }
    public string asHex => IdConverter.toHex(value, EngineServices.getDEFAULTS().hex_padding);
    public static IAterraEngineId fromHex(string hex_value) => new AterraEngineId{ value = IdConverter.toInt(hex_value) };
}