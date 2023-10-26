// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------
using AterraEngine.Engine;
using AterraEngine.Lib.Structs;
using Microsoft.Extensions.Logging;

using AterraEngine.Interfaces.Logic.EngineObjects;

namespace AterraEngine.Logic.EngineObjects;

// ---------------------------------------------------------------------------------------------------------------------
// Code
// ---------------------------------------------------------------------------------------------------------------------
public class EngineObjectManager : IEngineObjectManager {
    public IReadOnlyDictionary<AterraEngineId, IEngineObject> engine_objects => _engine_objects.AsReadOnly();
    protected readonly Dictionary<AterraEngineId, IEngineObject> _engine_objects = new();
    private readonly ILogger<IEngineObjectManager> _logger;
    
    // -----------------------------------------------------------------------------------------------------------------
    // Constructor  
    // -----------------------------------------------------------------------------------------------------------------
    public EngineObjectManager(ILogger<IEngineObjectManager> logger) {
        _logger = logger;
    }

    // -----------------------------------------------------------------------------------------------------------------
    // General use Methods  
    // -----------------------------------------------------------------------------------------------------------------
    public AterraEngineId getUniqueId() {
        // This function is too powerful
        //      It must be contained at some point

        Random random = EngineServices.getRANDOM().random;

        for (var i = 0; i < int.MaxValue; i++) {
            var randomId = new AterraEngineId {value=random.Next(int.MaxValue)};
            if (!_engine_objects.ContainsKey(randomId)) {
                return randomId;
            }
        }

        // this should never be reached, but who knows
        throw new InvalidOperationException("Unable to generate a unique ID.");
    }
    
    public void importFromManager(IEngineObjectManager manager) {
        foreach (var (key, engine_object) in manager.engine_objects) {
            _engine_objects.Add(key, engine_object);
        }
    }

    // -----------------------------------------------------------------------------------------------------------------
    // Filter methods
    // -----------------------------------------------------------------------------------------------------------------
    public T[] getAllByType<T>() {
        return engine_objects.Values
            .Where(engine_object => engine_object is T)
            .Cast<T>()
            .ToArray();
    }

    public IEngineObject? getById(string hex_id) => getById(AterraEngineId.fromHex(hex_id));
    public IEngineObject? getById(int id) => getById(new AterraEngineId{value=id});
    public IEngineObject? getById(AterraEngineId id) {
        engine_objects.TryGetValue(id, out var entity);
        return entity;
    }
    
    // -----------------------------------------------------------------------------------------------------------------
    // Logic methods
    // -----------------------------------------------------------------------------------------------------------------
    public T saveNewObject<T>(T engine_object) where T : IEngineObject {
        if (!_engine_objects.TryAdd(engine_object.id, engine_object)) {
            throw new Exception($"ID of engine object ${engine_object} with id ${engine_object.id} was already stored into the manager");
        }
        return engine_object;
    }

    // -----------------------------------------------------------------------------------------------------------------
    // Create Methods
    // -----------------------------------------------------------------------------------------------------------------
    public virtual IEntityNPC createNewEntityNPC(string hex_id, string resource_location) => createNewEntityNPC(AterraEngineId.fromHex(hex_id), resource_location);
    public virtual IEntityNPC createNewEntityNPC(int id, string resource_location) => createNewEntityNPC(new AterraEngineId{value = id}, resource_location);
    public virtual IEntityNPC createNewEntityNPC(AterraEngineId id, string resource_location) {
        IEntityNPC entity_npc = new EntityNPC{
            id = id,
            resource_location = resource_location
        };
        saveNewObject<IEntityNPC>(entity_npc);
        return entity_npc;
    }

}