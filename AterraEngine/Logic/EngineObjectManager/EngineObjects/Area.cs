// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------
using AterraEngine.Interfaces.Logic.EngineObjectManager.EngineObjects;
using AterraEngine.Interfaces.Structs;
using AterraEngine.Structs;

namespace AterraEngine.Logic.EngineObjectManager.EngineObjects;
// ---------------------------------------------------------------------------------------------------------------------
// Code
// ---------------------------------------------------------------------------------------------------------------------
public class Area : EngineObject, IArea {
    public ITile?[,] map { get; }

    // -----------------------------------------------------------------------------------------------------------------
    // Constructor
    // -----------------------------------------------------------------------------------------------------------------
    public Area(int map_max_x, int map_max_y) {
        map = new ITile?[map_max_x, map_max_y];
    }
    
    // -----------------------------------------------------------------------------------------------------------------
    // Methods
    // -----------------------------------------------------------------------------------------------------------------
    private bool _checkBounds(IPosition2D pos) {
        if (map.GetLength(0) < pos.X) {
            _logger.Error("'{pos}' is out of bounds. Max X axis value allowed: '{maxX}'", pos, map.GetLength(0));
            return false;
        } if (map.GetLength(1) < pos.Y) {
            _logger.Error("'{pos}' is out of bounds. Max Y axis value allowed: '{maxY}'", pos, map.GetLength(1));
            return false;
        }

        return true;
    }
    private bool _checkId<T>(IAterraEngineId aterra_engine_id, out T? found_tile) where T: class, ITile{
        var matched_type = map
            .Cast<ITile?>()
            .FirstOrDefault(tile => tile != null && tile.id == aterra_engine_id);

        if (matched_type == null) {
            _logger.Error("'{tile_id}' is not defined with any tile data", aterra_engine_id);
            found_tile = null;
            return false;
        }

        found_tile = (T)matched_type;
        return true;
    }
    
    public bool tryAssignTile(IPosition2D pos, ITile tile) {
        if (!_checkBounds(pos)) {
            return false;
        }
        
        var expected_location = map[pos.X, pos.Y];
        if (expected_location != null) {
            _logger.Error("'{pos}' is already defined with the following tile '{tile}'", pos, expected_location);
            return false;
        }

        map[pos.X, pos.Y] = tile;
        return true;
    }
    
    public bool tryOverrideTile(IPosition2D pos, ITile tile, out ITile? overriden_tile) {
        overriden_tile = null;
        
        if (!_checkBounds(pos)) {
            return false;
        }
        
        var expected_empty_location = map[pos.X, pos.Y];
        switch (expected_empty_location) {
            case PointOfInterest:
                _logger.Information("'{pos}' is already defined with the following POI '{tile}'", pos, expected_empty_location);
                return false;
            case Tile:
                overriden_tile = expected_empty_location;
                _logger.Information("'{pos}' is already defined with the following tile '{tile}'", pos, expected_empty_location);
                break;
        }

        map[pos.X, pos.Y] = tile;
        return true;
    }
    
    public bool tryGetTile<T>(IPosition2D pos, out T? found_tile)  where T: class, ITile {
        if (!_checkBounds(pos)) {
            found_tile = null;
            return false;
        }
        
        var matched_tile = map[pos.X, pos.Y];
        
        if (matched_tile == null) {
            _logger.Error("'{pos}' is not already defined with any tile data", pos);
            found_tile = null;
            return false;
        }

        found_tile = (T)matched_tile;
        return true;
    }

    public bool tryGetTile<T>(IAterraEngineId tile_id, out T? found_tile) where T: class, ITile{
        return !_checkId<T>(tile_id, out found_tile);
    }

    public bool tryGetPosition(IAterraEngineId tile_id, out IPosition2D? found_position_2d) {
        if (_checkId<ITile>(tile_id, out var found_tile)) {
            found_position_2d = null;
            return false;
        }
        
        int x = Array.IndexOf(map, found_tile) % map.GetLength(0);
        int y = Array.IndexOf(map, found_tile) / map.GetLength(0);

        found_position_2d = new Position2D(x, y);
        return true;

    }
    
}