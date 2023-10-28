// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------
using AterraEngine.Lib.Structs;
namespace AterraEngine.Interfaces.Logic.EngineObjectManager.EngineObjects;
// ---------------------------------------------------------------------------------------------------------------------
// Interface Code
// ---------------------------------------------------------------------------------------------------------------------
public interface IEngineObject {
    IAterraEngineId id { get; init; }
    string resource_location { get; init; }
    string internal_name { get; init; }
    string display_name { get; }
}