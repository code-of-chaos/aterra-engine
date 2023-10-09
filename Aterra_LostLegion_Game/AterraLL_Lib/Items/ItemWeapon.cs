// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------

namespace AterraLL_Lib.Items;

// ---------------------------------------------------------------------------------------------------------------------
// Code
// ---------------------------------------------------------------------------------------------------------------------
public record ItemWeapon : Item {
    
    public float attackDamage { get; private set; }
    
    public ItemWeapon(string itemId, string displayName, string? details = null, float attackDamage=0f) : base(itemId, displayName, false, 1, details) {
        
        this.attackDamage = Math.Max(attackDamage, 0); // Attack damage has to be above 0
    }
    
}