// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------
using AterraEngine.Engine;
using AterraEngine.Interfaces.Engine;
using AterraEngine.Interfaces.Structs;
using AterraEngine.Lib;

namespace AterraEngine.Structs; 
// ---------------------------------------------------------------------------------------------------------------------
// Code
// ---------------------------------------------------------------------------------------------------------------------
public readonly struct AterraEngineId : IAterraEngineId{ // Todo as the project grows: check performance impact of this being a struct vs class
    private readonly int _plugin_id ;
    public int plugin_id {
        get => _plugin_id;
        init => _plugin_id = checkLimit(value, EngineServices.getDEFAULTS().AterraEngineId_prefix_padding);
    }
    private readonly int _object_id ;
    public int object_id {
        get => _object_id;
        init => _object_id = checkLimit(value, EngineServices.getDEFAULTS().AterraEngineId_value_padding);
    }

    private static int checkLimit(int? value, int max_length) {
        switch (value) {
            case null :
                throw new NullReferenceException(); // todo write text + logging
            case var _ when IdConverter.toHex((int)value).Length > max_length :
                throw new FormatException();
            case < 0:
                throw new FormatException();
        }

        return (int)value;
    }
    
    public string asHex {
        get {
            var prefix = IdConverter.toHex(plugin_id, EngineServices.getDEFAULTS().AterraEngineId_prefix_padding);
            var hex_value = IdConverter.toHex(object_id, EngineServices.getDEFAULTS().AterraEngineId_value_padding);
            return $"{prefix}{hex_value}";
        }
    }

    public static IAterraEngineId fromHex(string hex_value) {
        IEngineDefaults defaults = EngineServices.getDEFAULTS();
        var hex_value_edit = hex_value.Replace("#", "");
        
        int prefix;
        int value;
        int hex_length = hex_value_edit.Length;
        
        if (hex_length <= defaults.AterraEngineId_value_padding) {
            prefix = 0;
            value = IdConverter.toInt(hex_value_edit);
        } else {
            int max_total_length = defaults.AterraEngineId_value_padding + defaults.AterraEngineId_prefix_padding;
            
            if (hex_length > max_total_length) {
                throw new FormatException($"ID was too big. The id can have a max length of '{max_total_length}' HEX characters");
            }

            hex_value_edit = hex_value_edit.PadLeft(max_total_length, '0');
            prefix = IdConverter.toInt(hex_value_edit[0..defaults.AterraEngineId_prefix_padding]);
            value = IdConverter.toInt(hex_value_edit[defaults.AterraEngineId_prefix_padding..max_total_length]);
        }
        
        return new AterraEngineId {
            plugin_id = prefix,
            object_id = value
        };
    }
}