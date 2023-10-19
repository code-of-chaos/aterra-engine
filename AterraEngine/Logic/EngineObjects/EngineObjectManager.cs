// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------

using System.Numerics;
using AterraEngine.Lib;
using Microsoft.Extensions.DependencyInjection;

namespace AterraEngine.Logic.EngineObjects;

// ---------------------------------------------------------------------------------------------------------------------
// Interface Code
// ---------------------------------------------------------------------------------------------------------------------
public interface IEngineObjectManager {
    IReadOnlyDictionary<int, IEngineObject> engine_objects { get; }
    
    int getUniqueId();

    IEntity createEntity<T>() where T : IEntity, new();
    IItem createItem<T>() where T : IItem, new();
    IPlayer createPlayer<T>() where T : IPlayer, new();

}
// ---------------------------------------------------------------------------------------------------------------------
// Code
// ---------------------------------------------------------------------------------------------------------------------
public class EngineObjectManager:IEngineObjectManager {
    public IReadOnlyDictionary<int, IEngineObject> engine_objects => _engine_objects.AsReadOnly();
    
    private int _id_counter = 0;
    private Dictionary<int, IEngineObject> _engine_objects = new Dictionary<int, IEngineObject>();
    
    // -----------------------------------------------------------------------------------------------------------------
    // Constructor  
    // -----------------------------------------------------------------------------------------------------------------
    
    // -----------------------------------------------------------------------------------------------------------------
    // Methods  
    // -----------------------------------------------------------------------------------------------------------------
    public int getUniqueId() => Interlocked.Increment(ref _id_counter);

    public IEntity createEntity<T>() where T : IEntity, new() {
        IEntity entity = new T {
            id = getUniqueId(),
            pos = new Vector2(1, 1)
        };

        _engine_objects.Add(entity.id, entity);
        
        return entity;
    }
    
    public IItem createItem<T>() where T : IItem, new() {
        IItem item = new T {
            id = getUniqueId(),
            weight = 0f
        };

        _engine_objects.Add(item.id, item);
        
        return item;
    }
    
    public IPlayer createPlayer<T>() where T : IPlayer, new() {
        IPlayer entity = new T {
            id = getUniqueId(),
            pos = new Vector2(1, 1)
        };

        _engine_objects.Add(entity.id, entity);
        
        return entity;
    }
    
}