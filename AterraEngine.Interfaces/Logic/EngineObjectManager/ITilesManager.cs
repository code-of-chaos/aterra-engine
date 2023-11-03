// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------

using AterraEngine.Interfaces.Logic.EngineObjectManager.EngineObjects.Level;
using AterraEngine.Interfaces.Structs;

namespace AterraEngine.Interfaces.Logic.EngineObjectManager;

// ---------------------------------------------------------------------------------------------------------------------
// Code
// ---------------------------------------------------------------------------------------------------------------------
public interface ITilesAtlas {
    IReadOnlyDictionary<IAterraEngineId, ITile> tiles { get; }
    ITile default_tile { get; }

    bool tryAddTile(ITile tile);
    void defineDefaultTile(ITile tile);
    bool tryGetTile(IAterraEngineId aterra_engine_id, out ITile tile);
}