// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------
using AterraEngine.Engine;
using AterraEngine.Interfaces.Engine;
using AterraEngine.Interfaces.Logic;
using AterraEngine.Lib.Structs;
using Serilog;
using AterraEngine.Interfaces.Logic.EngineObjectManager;
using AterraEngine.Interfaces.Logic.EngineObjectManager.EngineObjects;
using AterraEngine.Interfaces.Logic.EngineObjectManager.ConstructorStructs;
using AterraEngine.Interfaces.Structs;
using AterraEngine.Lib;
using AterraEngine.Logic.EngineObjectManager.EngineObjects;
using AterraEngine.Structs;

namespace AterraEngine.Logic.EngineObjectManager;

// ---------------------------------------------------------------------------------------------------------------------
// Code
// ---------------------------------------------------------------------------------------------------------------------
public class EngineObjectManager : IEngineObjectManager {
    public IReadOnlyDictionary<IAterraEngineId, IEngineObject> engine_objects => _engine_objects.AsReadOnly();
    protected readonly Dictionary<IAterraEngineId, IEngineObject> _engine_objects = new();
    protected readonly ILogger _logger = EngineServices.getLogger();

    // -----------------------------------------------------------------------------------------------------------------
    // General use Methods  
    // -----------------------------------------------------------------------------------------------------------------
    public IAterraEngineId getUniqueId(IEnginePlugin current_plugin) {
        // This function is too powerful
        //      It must be contained at some point

        Random random = EngineServices.getRANDOM().random;

        for (var i = 0; i < int.MaxValue; i++) {
            var randomId = new AterraEngineId {object_id=random.Next(int.MaxValue), plugin_id = current_plugin.id_prefix};
            if (_engine_objects.ContainsKey(randomId)) continue;
            
            _logger.Debug("Generated a new Unique id of '{value}'", randomId.asHex);
            return randomId;
        }

        // this should never be reached, but who knows
        _logger.Error("Unable to generate a unique ID.");
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
    public IEngineObject? getById(int id) => getById(new AterraEngineId{object_id=id});
    public IEngineObject? getById(IAterraEngineId id) {
        engine_objects.TryGetValue(id, out var entity);
        return entity;
    }
    
    // -----------------------------------------------------------------------------------------------------------------
    // Logic methods
    // -----------------------------------------------------------------------------------------------------------------
    public IEngineObject saveNewObject(IEngineObject engine_object) {
        if (!_engine_objects.TryAdd(engine_object.id, engine_object)) {
            _logger.Error("ID of engine object '{obj}' with id '{id}' was already stored into the manager", engine_object, engine_object.id);
            throw new Exception($"ID of engine object ${engine_object} with id ${engine_object.id.object_id} was already stored into the manager");
        }
        _logger.Debug("AterraEngineId({id}) mapped to '{obj}'", engine_object.id.object_id, engine_object.internal_name);
        return engine_object;
    }

    // -----------------------------------------------------------------------------------------------------------------
    // Create Methods
    // -----------------------------------------------------------------------------------------------------------------
    public virtual IEntityNPC createNewEntityNPC(IEnginePlugin current_plugin, ICSEntityNPC cs) {
        // Only get the default once, don't repeat yourself!
        IEngineDefaults defaults = EngineServices.getDEFAULTS();
        
        // Create the EngineObject with the ConstructorStruct
        IEntityNPC entity_npc = new EntityNPC{
            id =                cs.id                   ?? getUniqueId(current_plugin),
            resource_location = cs.resource_location    ?? null, // todo, do something better
            internal_name =     cs.internal_name        ?? defaults.entity_internal_name,
            health_max=         cs.health_max           ?? defaults.entity_health_max,
        };
        // Don't forget to save the object to to the internal dictionary
        saveNewObject(entity_npc);
        
        return entity_npc;
    }
}