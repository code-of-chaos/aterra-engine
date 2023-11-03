// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------
using AterraEngine.Interfaces.Structs;

namespace AterraEngine.Interfaces.Logic.EngineObjectManager.EngineObjects.Level;

// ---------------------------------------------------------------------------------------------------------------------
// Code
// ---------------------------------------------------------------------------------------------------------------------
public interface ILevel:IEngineObject {
    public IReadOnlyDictionary<IPosition2D, IChunk> chunk_map {get;}

    public bool tryAssignChunk(IPosition2D pos, IChunk chunk);
    public bool tryOverrideChunk(IPosition2D pos, IChunk chunk,out IChunk? overriden_chunk);
    public bool tryGetChunk(IPosition2D pos, out IChunk? found_chunk);
    public bool tryGetPosition(IChunk chunk, out IPosition2D? found_position_2d);

    public bool tryCreateChunk(IPosition2D pos, out IChunk? created_chunk);
    public bool tryAssignTileFromAbsolutePos(IPosition2D absolute_pos, ITile tile);
}