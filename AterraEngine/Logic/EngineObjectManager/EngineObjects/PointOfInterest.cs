// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------
using System.Numerics;
using AterraEngine.Interfaces.Logic.EngineObjectManager.EngineObjects;
using AterraEngine.Interfaces.Structs;
using AterraEngine.Structs;

namespace AterraEngine.Logic.EngineObjectManager.EngineObjects;

// ---------------------------------------------------------------------------------------------------------------------
// Code
// ---------------------------------------------------------------------------------------------------------------------
public class PointOfInterest:Tile,IPointOfInterest {
    public ILinkToArea? link_exit { get; init; }
}