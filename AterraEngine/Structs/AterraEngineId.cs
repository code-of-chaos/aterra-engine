// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------
using AterraEngine.Engine;
using AterraEngine.Interfaces.Engine;
using AterraEngine.Interfaces.Logic;
using AterraEngine.Interfaces.Structs;
using AterraEngine.Lib;

namespace AterraEngine.Structs; 
// ---------------------------------------------------------------------------------------------------------------------
// Code
// ---------------------------------------------------------------------------------------------------------------------
public readonly struct AterraEngineId : IAterraEngineId{ // Todo as the project grows: check performance impact of this being a struct vs class
    public int prefix_value { get; init; }
    public int value { get; init; }
    public string asHex {
        get {
            var prefix = IdConverter.toHex(prefix_value, EngineServices.getDEFAULTS().AterraEngineId_prefix_padding);
            var hex_value = IdConverter.toHex(value, EngineServices.getDEFAULTS().AterraEngineId_value_padding);
            return $"{prefix}{hex_value}";
        }
    }

    public static IAterraEngineId fromHex(string hex_value) {
        // hex_value = "00112345678"
        // prefix = 001 =1
        // value = 12345678
        
        IEngineDefaults defaults = EngineServices.getDEFAULTS();
        hex_value = hex_value.Replace("#", "");
        
        int prefix;
        int value;
        int hex_length = hex_value.Length;
        
        if (hex_length <= defaults.AterraEngineId_value_padding) {
            prefix = 0;
            value = IdConverter.toInt(hex_value);
        } else {
            int max_total_length = defaults.AterraEngineId_value_padding + defaults.AterraEngineId_prefix_padding;
            
            
            if (hex_length > max_total_length) {
                throw new Exception($"ID was too big");
            }

            hex_value = hex_value.PadLeft(max_total_length, '0');
            prefix = IdConverter.toInt(hex_value[0..defaults.AterraEngineId_prefix_padding]);
            value = IdConverter.toInt(hex_value[defaults.AterraEngineId_prefix_padding..max_total_length]);
        }
        
        return new AterraEngineId {
            prefix_value = prefix,
            value =value
        };
    }
}