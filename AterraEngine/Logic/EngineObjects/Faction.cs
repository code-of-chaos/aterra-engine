// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------
using System.Collections.ObjectModel;
using AterraEngine.Interfaces.Logic.EngineObjects;
using Microsoft.Extensions.Logging;

namespace AterraEngine.Logic.EngineObjects;
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

    public Faction(int id, ILogger<IEngineObject> logger) : base(id, logger) { }
}