// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------
using AterraEngine.Interfaces.Structs;

namespace AterraEngine.Interfaces.Logic.EngineObjectManager.EngineObjects.Level;

// ---------------------------------------------------------------------------------------------------------------------
// Code
// ---------------------------------------------------------------------------------------------------------------------
public interface IChunk {
    ITile?[,] tile_map { get;}
    
    bool tryAssignTile(IPosition2D pos, ITile tile);
    bool tryOverrideTile(IPosition2D pos, ITile tile,out ITile? overriden_tile);
    
    bool tryGetTile<T>(IPosition2D pos, out T? found_tile) where T: class, ITile;
    bool tryGetTile<T>(IAterraEngineId tile_id, out T? found_tile) where T: class, ITile;
    bool tryGetPosition(IAterraEngineId tile_id, out IPosition2D? found_position_2d);

    int max_x {get;}
    int max_y {get;}

}