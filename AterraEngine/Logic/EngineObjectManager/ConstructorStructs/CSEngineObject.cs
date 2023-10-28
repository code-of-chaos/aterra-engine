// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------
using AterraEngine.Interfaces.Logic;
using AterraEngine.Interfaces.Logic.EngineObjectManager.ConstructorStructs;

namespace AterraEngine.Logic.EngineObjectManager.ConstructorStructs;
// ---------------------------------------------------------------------------------------------------------------------
// Code
// ---------------------------------------------------------------------------------------------------------------------
public struct CSEngineObject:ICSEngineObject {
    public IAterraEngineId? id { get; set; }
    public string? resource_location { get; set; }
    public string? internal_name { get; set; }
}