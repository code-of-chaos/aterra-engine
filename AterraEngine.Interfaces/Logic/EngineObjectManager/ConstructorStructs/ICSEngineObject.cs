// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------
using AterraEngine.Lib.Structs;

namespace AterraEngine.Interfaces.Logic.EngineObjectManager.ConstructorStructs;
// ---------------------------------------------------------------------------------------------------------------------
// Interface Code
// ---------------------------------------------------------------------------------------------------------------------
public interface ICSEngineObject {
    AterraEngineId? id { get; init; }
    string? resource_location { get; init; }
    string? internal_name { get; init; }
    
}