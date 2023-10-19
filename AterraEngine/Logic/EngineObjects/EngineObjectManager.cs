// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------

using AterraEngine.Engine;
using Microsoft.Extensions.Logging;

namespace AterraEngine.Logic.EngineObjects;

// ---------------------------------------------------------------------------------------------------------------------
// Interface Code
// ---------------------------------------------------------------------------------------------------------------------
public interface IEngineObjectManager {
    IReadOnlyDictionary<int, IEngineObject> engine_objects { get; }
    
    int getUniqueId();

    IEntityPlayer createPlayer(int? id = null, string? name = null);
    IEntityNPC createNPC(int? id = null, string? name = null);
    IEntityContainer createContainer(int? id = null, string? name = null);
    
    IItemArmor createItemArmor(int? id = null);
    IItemBook createItemBook(int? id = null);
    IItemMaterial createItemMaterial(int? id = null);
    IItemPotion createItemPotion(int? id = null);
    IItemTool createItemTool(int? id = null);
    IItemWeapon createItemWeapon(int? id = null);
    
    IFaction createFaction(int? id = null, string? name = null);
    
    T[] getByType<T>();

}
// ---------------------------------------------------------------------------------------------------------------------
// Code
// ---------------------------------------------------------------------------------------------------------------------
public class EngineObjectManager : IEngineObjectManager {
    public IReadOnlyDictionary<int, IEngineObject> engine_objects => _engine_objects.AsReadOnly();
    private readonly Dictionary<int, IEngineObject> _engine_objects = new Dictionary<int, IEngineObject>();
    private readonly ILogger<EngineObjectManager> _logger;

    // -----------------------------------------------------------------------------------------------------------------
    // Constructor  
    // -----------------------------------------------------------------------------------------------------------------
    public EngineObjectManager(ILogger<EngineObjectManager> logger) {
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

    // -----------------------------------------------------------------------------------------------------------------
    // Create Methods  
    // -----------------------------------------------------------------------------------------------------------------
    private T _createNewObject<T>(int? id = null) where T : IEngineObject, new() {
        T engine_object = new T{
            id=id ?? getUniqueId(),
            logger=_logger
        };
        
        _engine_objects.Add(engine_object.id, engine_object);
        return engine_object;
    }
    
    // --- ENTITIES ---
    private T _createEntity<T>(int? id = null, string? name = null) where T : Entity, new(){
        T entity = _createNewObject<T>(id:id);
        entity.name = name;
        return entity;
    }

    public IEntityPlayer createPlayer(int? id = null, string? name = null) => _createEntity<EntityPlayer>(id: id, name: name);
    public IEntityNPC createNPC(int? id = null, string? name = null) => _createEntity<EntityNPC>(id: id, name: name);
    public IEntityContainer createContainer(int? id = null, string? name = null) => _createEntity<EntityContainer>(id: id, name: name);
    
    // --- FACTION ---
    public IFaction createFaction(int? id = null, string? name = null) {
        IFaction faction = _createNewObject<Faction>(id:id);
        faction.name = name;
        return faction;
    }
        
    // --- ITEMS ---
    private T _createItem<T>(int? id = null, float? weight = null) where T : Item, new(){
        T item = _createNewObject<T>(id:id);
        item.weight = weight ?? EngineServices.getED().item_weight;
        return item;
    }
    public IItemArmor createItemArmor(int? id = null) => _createItem<ItemArmor>(id:id);
    public IItemBook createItemBook(int? id = null) => _createItem<ItemBook>(id:id);
    public IItemMaterial createItemMaterial(int? id = null) => _createItem<ItemMaterial>(id:id);
    public IItemPotion createItemPotion(int? id = null) => _createItem<ItemPotion>(id:id);
    public IItemTool createItemTool(int? id = null) => _createItem<ItemTool>(id:id);
    public IItemWeapon createItemWeapon(int? id = null) => _createItem<ItemWeapon>(id:id);
    
    // -----------------------------------------------------------------------------------------------------------------
    // Filter methods
    // -----------------------------------------------------------------------------------------------------------------
    public T[] getByType<T>() {
        return engine_objects.Values
            .Where(engine_object => engine_object is T)
            .Cast<T>()
            .ToArray();;
    }
}