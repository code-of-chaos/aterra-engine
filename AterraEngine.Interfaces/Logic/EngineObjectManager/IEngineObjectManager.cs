// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------
using AterraEngine.Lib.Structs;
using AterraEngine.Interfaces.Logic.EngineObjectManager.EngineObjects;
using AterraEngine.Interfaces.Logic.EngineObjectManager.ConstructorStructs;

namespace AterraEngine.Interfaces.Logic.EngineObjectManager;

// ---------------------------------------------------------------------------------------------------------------------
// Interface Code
// ---------------------------------------------------------------------------------------------------------------------
public interface IEngineObjectManager {
    IReadOnlyDictionary<AterraEngineId, IEngineObject> engine_objects { get; }
    
    AterraEngineId getUniqueId();
    
    T[] getAllByType<T>();
    void importFromManager(IEngineObjectManager manager);
    public IEngineObject saveNewObject(IEngineObject engine_object);

    IEngineObject? getById(string hex_id);
    IEngineObject? getById(int id);
    IEngineObject? getById(AterraEngineId id);
    
    IEntityNPC createNewEntityNPC(ICSEntityNPC cs_entity_npc);

}