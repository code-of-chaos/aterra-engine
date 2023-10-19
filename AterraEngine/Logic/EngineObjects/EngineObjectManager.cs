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

    IEntity createEntity<TEntity>() where TEntity : IEntity, new();
    // IItem createItem(params string[] entity_params);
    // IPlayer createPlayer(params string[] entity_params);

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

    public IEntity createEntity<TEntity>() where TEntity : IEntity, new() {
        IEntity entity = new TEntity {
            id = getUniqueId(),
            pos = new Vector2(1, 1)
        };
        
        return entity;
    }
    
}