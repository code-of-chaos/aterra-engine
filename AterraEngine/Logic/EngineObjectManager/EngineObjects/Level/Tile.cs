// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------
using AterraEngine.Engine;
using AterraEngine.Interfaces.Logic.EngineObjectManager.EngineObjects.Level;
using AterraEngine.Interfaces.Structs;

namespace AterraEngine.Logic.EngineObjectManager.EngineObjects.Level;

// ---------------------------------------------------------------------------------------------------------------------
// Code
// ---------------------------------------------------------------------------------------------------------------------
public class Tile:EngineObject, ITile {
    public bool isWalkable { get; init; } = EngineServices.getDEFAULTS().tile_isWalkable;
    public bool isPOI { get; init; } = false;
    public ILinkToLevel? link_to_level { get; init; } = null;
    public string console_text { get; init; } = EngineServices.getDEFAULTS().tile_console_text;
}