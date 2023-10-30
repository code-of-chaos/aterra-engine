// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------
using AterraEngine.Interfaces.Structs;

namespace AterraEngine.Interfaces.Logic.EngineObjectManager.EngineObjects;

// ---------------------------------------------------------------------------------------------------------------------
// Code
// ---------------------------------------------------------------------------------------------------------------------
public interface IArea:IEngineObject {
    public ITile?[,] map { get;}

    public bool tryAssignTile(IPosition2D pos, ITile tile);
    public bool tryOverrideTile(IPosition2D pos, ITile tile,out ITile? overriden_tile);
    
    public bool tryGetTile<T>(IPosition2D pos, out T? found_tile) where T: class, ITile;
    public bool tryGetTile<T>(IAterraEngineId tile_id, out T? found_tile) where T: class, ITile;
    public bool tryGetPosition(IAterraEngineId tile_id, out IPosition2D? found_position_2d);
}