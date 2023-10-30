// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------

using AterraEngine.Engine;
using AterraEngine.Interfaces.Logic.EngineObjectManager;
using AterraEngine.Interfaces.Logic.EngineObjectManager.EngineObjects;
using AterraEngine.Interfaces.Structs;
using Serilog;

namespace AterraEngine.Logic.EngineObjectManager;

// ---------------------------------------------------------------------------------------------------------------------
// Code
// ---------------------------------------------------------------------------------------------------------------------
public class TilesManager : ITilesManager {
    private readonly Dictionary<IAterraEngineId, ITile> _tiles = new ();
    private readonly ILogger _logger = EngineServices.getLogger();
    private IAterraEngineId _default_tile_id = null!;
    
    public IReadOnlyDictionary<IAterraEngineId, ITile> tiles => _tiles.AsReadOnly();
    public ITile default_tile {
        get {
            _tiles.TryGetValue(_default_tile_id, out var tile);
            return tile!;
        }
    }

    // -----------------------------------------------------------------------------------------------------------------
    // Methods
    // -----------------------------------------------------------------------------------------------------------------
    public bool tryAddTile(ITile tile) {
        if (_tiles.ContainsKey(tile.id)) {
            _logger.Error("The following ID was already populated to a tile: {tile_id}", tile.id);
        }
        return _tiles.TryAdd(tile.id, tile);
    }

    public void defineDefaultTile(ITile tile) {
        tryAddTile(tile); // Checks if the tile is already in there, if not adds it anyways
        _default_tile_id = tile.id;
    }

    public bool tryGetTile(IAterraEngineId aterra_engine_id, out ITile tile) {
        if (_tiles.TryGetValue(aterra_engine_id, out tile!)) {
            return true;
        }
        // If nothing is found, return the default tile
        tile = default_tile;
        return false;
    }
}