// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------

using System.Numerics;
using AterraEngine.Engine;
using AterraEngine.Interfaces.Logic.EngineObjectManager.EngineObjects;
using AterraEngine.Interfaces.Logic.EngineObjectManager.EngineObjects.Level;
using AterraEngine.Interfaces.Structs;
using AterraEngine.Lib.Structs;
using AterraEngine.Structs;

namespace AterraEngine.Logic.EngineObjectManager.EngineObjects.Level;
// ---------------------------------------------------------------------------------------------------------------------
// Code
// ---------------------------------------------------------------------------------------------------------------------
public class Level : EngineObject, ILevel {
    private Dictionary<IPosition2D, IChunk> _chunk_map = new Dictionary<IPosition2D, IChunk>();
    public IReadOnlyDictionary<IPosition2D, IChunk> chunk_map => _chunk_map.AsReadOnly();

    // -----------------------------------------------------------------------------------------------------------------
    // Constructor
    // -----------------------------------------------------------------------------------------------------------------
    
    // -----------------------------------------------------------------------------------------------------------------
    // Methods
    // -----------------------------------------------------------------------------------------------------------------
    public bool tryAssignChunk(IPosition2D pos, IChunk chunk) {
        if (chunk_map.TryGetValue(pos, out var found_chunk)) {
            _logger.Error("'{pos}' is already defined with the following chunk '{found_chunk}'", pos, found_chunk);
            return false;
        }
        
        return _chunk_map.TryAdd(pos, chunk);
    }
    
    public bool tryOverrideChunk(IPosition2D pos, IChunk chunk, out IChunk? overriden_chunk) {
        overriden_chunk = null;

        if (chunk_map.TryGetValue(pos, out overriden_chunk)) {
            _logger.Information("'{pos}' was already defined with the following chunk '{tile}'", pos, overriden_chunk);
        }
        
        _chunk_map[pos] = chunk;
        return true;
    }
    
    public bool tryGetChunk(IPosition2D pos, out IChunk? found_chunk) {
        found_chunk = null;
        
        if (!chunk_map.TryGetValue(pos, out found_chunk)) {
            _logger.Error("'{pos}' was not defined with any chunk data", pos);
            return false;
        }
        
        return true;
    }

    public bool tryGetPosition(IChunk chunk, out IPosition2D? found_position_2d) {

        KeyValuePair<IPosition2D, IChunk>? pair = chunk_map.FirstOrDefault(value_pair => value_pair.Value == chunk);
        found_position_2d = pair.Value.Key ?? null;
        return true;

    }
    
    public bool tryCreateChunk(IPosition2D pos, out IChunk? created_chunk, ByteVector3? chunk_color = null) {
        created_chunk = new Chunk(
            max_x:EngineServices.getDEFAULTS().chunk_max_size,
            max_y:EngineServices.getDEFAULTS().chunk_max_size,
            debug_console_color:chunk_color
        );

        if (!tryAssignChunk(pos, created_chunk)) {
            created_chunk = null;
            return false;
        }

        return true; 
    }

    public bool tryAssignTileFromAbsolutePos(IPosition2D absolute_pos, ITile tile) {
        int chunk_max_size = EngineServices.getDEFAULTS().chunk_max_size;
        
        Position2D chunk_pos = new Position2D(
            (int)Math.Floor(absolute_pos.X / (float)chunk_max_size),
            (int)Math.Floor(absolute_pos.Y / (float)chunk_max_size)
        );

        if (!tryGetChunk(chunk_pos, out IChunk? chunk)) {
            return false;
        }
        
        int new_x = absolute_pos.X % chunk_max_size;
        int new_y = absolute_pos.Y % chunk_max_size;
        
        chunk!.tryOverrideTile(
            new Position2D(
                new_x >= 0 ? new_x : chunk_max_size - Math.Abs(new_x), 
                new_y >= 0 ? new_y : chunk_max_size - Math.Abs(new_y)
                ),
            tile,
            out _
        );
        return true;
    }
}