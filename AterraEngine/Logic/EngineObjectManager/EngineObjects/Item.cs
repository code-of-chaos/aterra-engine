// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------

using AterraEngine.Interfaces.Logic.EngineObjectManager.EngineObjects;

namespace AterraEngine.Logic.EngineObjectManager.EngineObjects;

// ---------------------------------------------------------------------------------------------------------------------
// Code
// ---------------------------------------------------------------------------------------------------------------------
public class Item: EngineObject, IItem {
    public float weight { get; init; }
    public string? internal_name { get; init; }
}