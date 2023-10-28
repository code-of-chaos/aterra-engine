// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------

using AterraEngine.Interfaces.Logic.EngineObjectManager.ConstructorStructs;
using AterraEngine.Lib.Structs;

namespace AterraEngine.Logic.EngineObjectManager.ConstructorStructs;
// ---------------------------------------------------------------------------------------------------------------------
// Code
// ---------------------------------------------------------------------------------------------------------------------
public struct CSEngineObject:ICSEngineObject {
    public AterraEngineId? id { get; init; }
    public string? resource_location { get; init; }
    public string? internal_name { get; init; }
}