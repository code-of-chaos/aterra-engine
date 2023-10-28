// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------
using AterraEngine.Lib.Structs;

namespace AterraEngine.Interfaces.Logic.EngineObjectManager.ConstructorStructs;
// ---------------------------------------------------------------------------------------------------------------------
// Interface Code
// ---------------------------------------------------------------------------------------------------------------------
public interface ICSEngineObject {
    IAterraEngineId? id { get; set; }
    string? resource_location { get; set; }
    string? internal_name { get; set; }
}