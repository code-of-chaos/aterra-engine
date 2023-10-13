// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------

namespace AterraEngine.Items;
// ---------------------------------------------------------------------------------------------------------------------
// Code
// ---------------------------------------------------------------------------------------------------------------------
public record Item
{
    public string itemId { get; }
    public string displayName { get; private set; }
    public bool isStackable { get; }
    public int maxStackSize { get; private set; }
    public string? details { get; }

    public Item(string itemId, string displayName, bool isStackable=true, int maxStackSize=8, string? details=null)
    {
        this.itemId = itemId;
        this.displayName = displayName;
        this.isStackable = isStackable;
        this.maxStackSize = isStackable ? maxStackSize : 1; // If not stackable, max stack size can be only 1
        this.details = details;
    }

    public override string ToString() {
        return $"{itemId} - stackable:{isStackable} - details:'{details}'";
    }
}