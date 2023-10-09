namespace AterraLL_Lib.Entities;
// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------
using AterraLL_Lib.Items;
using AterraLL_Lib;

// ---------------------------------------------------------------------------------------------------------------------
// Code
// ---------------------------------------------------------------------------------------------------------------------
public abstract class Entity
{
    // Properties
    public float health { get; private set; }
    public Inventory inventory { get; private set; }
    public EntityType entity_type;
    public string printable;
    
    // Init of Entity
    protected Entity(int i_size, float hp, EntityType e_type, string printable)
    {
        inventory = new Inventory(maxSize:i_size); // max inventory size is "inventory_size"
        health = hp;
        entity_type = e_type;
        this.printable = printable;
    }
    
    // Useful methods
    public void updateHealth(float value) {
        health += value;
    }

    public bool isAlive() {
        return health > 0;
    }
    
}

public enum EntityType
{
    player,
    enemy
}