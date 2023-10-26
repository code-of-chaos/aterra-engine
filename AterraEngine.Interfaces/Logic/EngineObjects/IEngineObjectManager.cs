// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------

using AterraEngine.Lib.Structs;

namespace AterraEngine.Interfaces.Logic.EngineObjects;

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
    
    IEntityNPC createNewEntityNPC(string resource_location);
    IEntityNPC createNewEntityNPC(string hex_id, string resource_location);
    IEntityNPC createNewEntityNPC(int id, string resource_location);
    IEntityNPC createNewEntityNPC(AterraEngineId id, string resource_location);

}