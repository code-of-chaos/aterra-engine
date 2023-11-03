// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------
using AterraEngine.Interfaces.Engine;
using AterraEngine.Interfaces.Logic.EngineObjectManager.EngineObjects;
using AterraEngine.Interfaces.Logic.EngineObjectManager.EngineObjects.Level;
using AterraEngine.Interfaces.Logic.EngineObjectManager.ConstructorStructs;
using AterraEngine.Interfaces.Structs;

namespace AterraEngine.Interfaces.Logic.EngineObjectManager;

// ---------------------------------------------------------------------------------------------------------------------
// Interface Code
// ---------------------------------------------------------------------------------------------------------------------
public interface IEngineObjectManager {
    IReadOnlyDictionary<IAterraEngineId, IEngineObject> engine_objects { get; }
    
    IAterraEngineId getUniqueId(IEnginePlugin current_plugin);
    
    T[] getAllByType<T>();
    void importFromManager(IEngineObjectManager manager);
    public IEngineObject saveNewObject(IEngineObject engine_object);

    IEngineObject? getById(string hex_id);
    IEngineObject? getById(int id);
    IEngineObject? getById(IAterraEngineId id);
    
    IEntityNPC createNewEntityNPC(IEnginePlugin current_plugin, ICSEntityNPC cs);
    ILevel createLevel(IEnginePlugin current_plugin, ICSLevel cs);
    ITile createTile(IEnginePlugin current_plugin, ICSTile cs);
}