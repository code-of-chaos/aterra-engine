// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------

using System.Numerics;
using AterraEngine.Engine;
using AterraEngine.Interfaces.Logic.EngineObjectManager.EngineObjects;
using AterraEngine.Interfaces.Logic.EngineObjectManager.EngineObjects.Level;
using AterraEngine.Interfaces.Structs;
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
    
    public bool tryCreateChunk(IPosition2D pos, out IChunk? created_chunk) {
        created_chunk = new Chunk(
            max_x:EngineServices.getDEFAULTS().chunk_max_size,
            max_y:EngineServices.getDEFAULTS().chunk_max_size
        );

        if (!tryAssignChunk(pos, created_chunk)) {
            created_chunk = null;
            return false;
        }

        return true; 
    }

    public bool tryAssignTileFromAbsolutePos(IPosition2D absolute_pos, ITile tile) {

        int chunk_max_size = EngineServices.getDEFAULTS().chunk_max_size;
        
        Vector2 chunk_pos = new Vector2(
            absolute_pos.X / (float)chunk_max_size,
            absolute_pos.Y / (float)chunk_max_size
        );
        _logger.Information("absolute_pos {a}", absolute_pos);
        _logger.Information("chunk_pos {a}", chunk_pos);
        _logger.Information("x_div {a}", absolute_pos.X / chunk_max_size);
        _logger.Information("y_div {a}", absolute_pos.Y / chunk_max_size);

        if (!tryGetChunk(new Position2D((int)Math.Floor(chunk_pos.X), (int)Math.Floor(chunk_pos.Y)), out IChunk? chunk)) {
            return false;
        }
        
        _logger.Information("Chunk to be used at : {x}, {y}", chunk_pos.X, chunk_pos.Y);
        
        int new_x = absolute_pos.X % (chunk_max_size);
        int new_y = absolute_pos.Y % (chunk_max_size);
        
        _logger.Information("new_x {a}", new_x);
        _logger.Information("new_y {a}", new_y);
        
        new_x = new_x >= 0 ? new_x : chunk_max_size - Math.Abs(new_x);
        new_y = new_y >= 0 ? new_y : chunk_max_size - Math.Abs(new_y);
        
        _logger.Information("new_x {a}", new_x);
        _logger.Information("new_y {a}", new_y);
        
        chunk!.tryOverrideTile(
            new Position2D(new_x, new_y),
            tile,
            out _
        );
        return true;
    }
}