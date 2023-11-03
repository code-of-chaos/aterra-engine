// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------

using System.ComponentModel;
using AterraEngine.Engine;
using AterraEngine.Interfaces.Logic.EngineObjectManager.EngineObjects.Level;
using AterraEngine.Interfaces.Structs;
using AterraEngine.Lib.Structs;
using AterraEngine.Structs;
using Serilog;

namespace AterraEngine.Logic.EngineObjectManager.EngineObjects.Level;
// ---------------------------------------------------------------------------------------------------------------------
// Code
// ---------------------------------------------------------------------------------------------------------------------
public class Chunk : IChunk {
    public ITile?[,] tile_map { get; }
    private readonly ILogger _logger = EngineServices.getLogger();
    public ByteVector3 debug_console_color { get; }

    public int max_x { get; private set;}
    public int max_y { get; private set;}

    // -----------------------------------------------------------------------------------------------------------------
    // Constructor
    // -----------------------------------------------------------------------------------------------------------------
    public Chunk(int? max_x=null, int? max_y=null, ByteVector3? debug_console_color=null) {
        this.max_x = max_x ?? EngineServices.getDEFAULTS().chunk_max_size;
        this.max_y = max_y ?? EngineServices.getDEFAULTS().chunk_max_size;
        tile_map = new ITile?[this.max_x, this.max_y];

        this.debug_console_color = debug_console_color ?? new ByteVector3(255, 255, 255);

    }
    
    // -----------------------------------------------------------------------------------------------------------------
    // Methods
    // -----------------------------------------------------------------------------------------------------------------
    private bool _checkBounds(IPosition2D pos) {
        if (tile_map.GetLength(0) < pos.X) {
            _logger.Error("'{pos}' is out of bounds. Max X axis value allowed: '{maxX}'", pos, tile_map.GetLength(0));
            return false;
        } if (tile_map.GetLength(1) < pos.Y) {
            _logger.Error("'{pos}' is out of bounds. Max Y axis value allowed: '{maxY}'", pos, tile_map.GetLength(1));
            return false;
        }

        return true;
    }
    private bool _checkId<T>(IAterraEngineId aterra_engine_id, out T? found_tile) where T: class, ITile{
        var matched_type = tile_map
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
        
        var expected_location = tile_map[pos.X, pos.Y];
        if (expected_location != null) {
            _logger.Error("'{pos}' is already defined with the following tile '{tile}'", pos, expected_location);
            return false;
        }

        tile_map[pos.X, pos.Y] = tile;
        return true;
    }
    
    public bool tryOverrideTile(IPosition2D pos, ITile tile, out ITile? overriden_tile) {
        overriden_tile = null;
        
        if (!_checkBounds(pos)) {
            return false;
        }
        
        var expected_empty_location = tile_map[pos.X, pos.Y];
        switch (expected_empty_location) {
            case Tile:
                overriden_tile = expected_empty_location;
                _logger.Information("'{pos}' is already defined with the following tile '{tile}'", pos, expected_empty_location);
                break;
        }

        tile_map[pos.X, pos.Y] = tile;
        return true;
    }
    
    public bool tryGetTile<T>(IPosition2D pos, out T? found_tile)  where T: class, ITile {
        if (!_checkBounds(pos)) {
            found_tile = null;
            return false;
        }
        
        var matched_tile = tile_map[pos.X, pos.Y];
        
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
        
        int x = Array.IndexOf(tile_map, found_tile) % tile_map.GetLength(0);
        int y = Array.IndexOf(tile_map, found_tile) / tile_map.GetLength(0);

        found_position_2d = new Position2D(x, y);
        return true;

    }
    
}