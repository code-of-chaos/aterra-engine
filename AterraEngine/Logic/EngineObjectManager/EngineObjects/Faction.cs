// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------
using System.Collections.ObjectModel;
using AterraEngine.Interfaces.Logic;
using AterraEngine.Interfaces.Logic.EngineObjectManager.EngineObjects;
using AterraEngine.Interfaces.Logic.EngineObjectManager;
using AterraEngine.Interfaces.Structs;
using AterraEngine.Lib.Structs;

namespace AterraEngine.Logic.EngineObjectManager.EngineObjects;
// ---------------------------------------------------------------------------------------------------------------------
// Code
// ---------------------------------------------------------------------------------------------------------------------
public class Faction : EngineObject, IFaction {
    public string? name { get; set; }
    
    private Dictionary<IAterraEngineId,IEngineObject> _entities { get; } = new();
    public ReadOnlyDictionary<IAterraEngineId, IEngineObject> entities => _entities.AsReadOnly();

    // -----------------------------------------------------------------------------------------------------------------
    // Methods  
    // -----------------------------------------------------------------------------------------------------------------
    public bool tryAddEngineObject(IEngineObject engine_object) {
        return !_entities.ContainsKey(engine_object.id) && _entities.TryAdd(engine_object.id, engine_object);
    }
    public bool tryRemoveEngineObject(IEngineObject engine_object) {
        return _entities.ContainsKey(engine_object.id) && _entities.Remove(engine_object.id);
    }
}