// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------
using AterraEngine.Interfaces.Logic.EngineObjectManager.ConstructorStructs;
using AterraEngine.Interfaces.Structs;

namespace AterraEngine.Logic.EngineObjectManager.ConstructorStructs;

// ---------------------------------------------------------------------------------------------------------------------
// Code
// ---------------------------------------------------------------------------------------------------------------------
public struct CSTile:ICSTile {
    public IAterraEngineId? id { get; set; }
    public string? resource_location { get; set; }
    public string? internal_name { get; set; }
    public bool? isWalkable { get; set; }
}