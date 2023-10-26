// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------

using AterraEngine.Lib.Structs;
using Microsoft.Extensions.Logging;

namespace AterraEngine.Interfaces.Logic.EngineObjects;

// ---------------------------------------------------------------------------------------------------------------------
// Interface Code
// ---------------------------------------------------------------------------------------------------------------------
public interface IEngineObjectManager {
    IReadOnlyDictionary<AterraEngineId, IEngineObject> engine_objects { get; }
    
    AterraEngineId getUniqueId();
    
    T[] getAllByType<T>();
    void importFromManager(IEngineObjectManager manager);
    public T saveNewObject<T>(T engine_object) where T : IEngineObject;

    IEngineObject? getById(string hex_id);
    IEngineObject? getById(int id);
    IEngineObject? getById(AterraEngineId id);
    
    IEntityNPC createNewEntityNPC(string hex_id, string resource_location);
    IEntityNPC createNewEntityNPC(int id, string resource_location);
    IEntityNPC createNewEntityNPC(AterraEngineId id, string resource_location);

}