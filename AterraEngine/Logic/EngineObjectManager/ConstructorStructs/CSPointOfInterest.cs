// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------
using AterraEngine.Interfaces.Logic.EngineObjectManager.ConstructorStructs;
using AterraEngine.Interfaces.Structs;
using AterraEngine.Structs;

namespace AterraEngine.Logic.EngineObjectManager.ConstructorStructs;

// ---------------------------------------------------------------------------------------------------------------------
// Code
// ---------------------------------------------------------------------------------------------------------------------
public struct CSPointOfInterest:ICSPointOfInterest {
    public IAterraEngineId? id { get; set; }
    public string? resource_location { get; set; }
    public string? internal_name { get; set; }
    public bool? isWalkable { get; set; }
    public ILinkToArea? link_exit { get; set; }
}