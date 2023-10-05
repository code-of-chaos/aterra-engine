namespace AterraUnleashedLib.Entities;
// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------
using AterraUnleashedLib.Items;
using AterraUnleashedLib;

// ---------------------------------------------------------------------------------------------------------------------
// Code
// ---------------------------------------------------------------------------------------------------------------------
public abstract class Entity
{
    // Properties
    public float health { get; private set; }
    public bool alive { get; private set; } = true;
    public Inventory inventory { get; }
    
    // Init of Entity
    protected Entity(int i_size, float hp)
    {
        inventory = new Inventory(maxSize:i_size); // max inventory size is "inventory_size"
        health = hp;
    }
    
    // Useful methods
    public void updateHealth(float value) {
        health += value;
        if (health <= 0f) {
            alive = false;
        }
    }
    
}

public enum EntityType
{
    player,
    enemy
}