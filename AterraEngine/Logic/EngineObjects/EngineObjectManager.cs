// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------

using AterraEngine.Engine;
using AterraEngine.Lib;
using Microsoft.Extensions.Logging;

using AterraEngine.Interfaces.Logic.EngineObjects;

namespace AterraEngine.Logic.EngineObjects;

// ---------------------------------------------------------------------------------------------------------------------
// Code
// ---------------------------------------------------------------------------------------------------------------------
public class EngineObjectManager : IEngineObjectManager {
    public IReadOnlyDictionary<int, IEngineObject> engine_objects => _engine_objects.AsReadOnly();
    protected readonly Dictionary<int, IEngineObject> _engine_objects = new Dictionary<int, IEngineObject>();
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
    public int getUniqueId() {
        // This function is too powerful
        //      It must be contained at some point

        Random random = EngineServices.getRANDOM().random;

        for (var i = 0; i < int.MaxValue; i++) {
            var randomId = random.Next(int.MaxValue);
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
    
    public IEngineObject? getById(string hex_id) {
        engine_objects.TryGetValue(IdConverter.toInt(hex_id), out var entity);
        return entity;
    }
    public IEngineObject? getById(int id) {
        engine_objects.TryGetValue(id, out var entity);
        return entity;
    }
    
    public T createNewObject<T>(Func<int, ILogger<IEngineObjectManager>, string, T> callback_func, int? id = null, string? resource_location = null) where T : IEngineObject, new() {
        return saveNewObject(
            callback_func(
                id ?? getUniqueId(), 
                _logger,
                resource_location ?? EngineServices.getRESXM().default_resource_location
            ));
    }
    
    public T saveNewObject<T>(T engine_object) where T : IEngineObject, new() {
        if (!_engine_objects.TryAdd(engine_object.id, engine_object)) {
            throw new Exception($"ID of engine object ${engine_object} with id ${engine_object.id} was already stored into the manager");
        }
        return engine_object;
    }

    public virtual IEntityNPC createNewEntityNPC(int id, string resource_location) {
        IEntityNPC entity_npc = new EntityNPC(id, EngineServices.getLogger<IEntityNPC>()){
            resource_location = resource_location
        };
        _engine_objects.Add(entity_npc.id, entity_npc);
        return entity_npc;
    }

}