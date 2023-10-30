// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------

using System.Numerics;
using AterraEngine.Engine;
using AterraEngine.Interfaces.Logic.EngineObjectManager.EngineObjects;
using AterraEngine.Interfaces.Structs;

namespace AterraEngine.Logic.EngineObjectManager.EngineObjects;

// ---------------------------------------------------------------------------------------------------------------------
// Code
// ---------------------------------------------------------------------------------------------------------------------
public class Tile:EngineObject,ITile {
    public bool isWalkable { get; init; } = EngineServices.getDEFAULTS().tile_isWalkable;
}