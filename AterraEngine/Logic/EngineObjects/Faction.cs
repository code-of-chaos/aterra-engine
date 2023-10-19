// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------
using System.Collections.ObjectModel;
namespace AterraEngine.Logic.EngineObjects;

// ---------------------------------------------------------------------------------------------------------------------
// Interface Code
// ---------------------------------------------------------------------------------------------------------------------
public interface IFaction:IEngineObject {
    string? name { get; set; }
    ReadOnlyDictionary<int,IEngineObject> entities { get; }

    bool tryAddEngineObject(IEngineObject entity);
    bool tryRemoveEngineObject(IEngineObject engine_object);
}
// ---------------------------------------------------------------------------------------------------------------------
// Code
// ---------------------------------------------------------------------------------------------------------------------
public class Faction : EngineObject, IFaction {
    public string? name { get; set; }
    
    private Dictionary<int,IEngineObject> _entities { get; } = new Dictionary<int, IEngineObject>();
    public ReadOnlyDictionary<int,IEngineObject> entities => _entities.AsReadOnly();

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