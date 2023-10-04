namespace AterraUnleashedLib;

/// Simple Inventory system, based on a dictionary
public class Inventory
{
    // Set properties
    private Dictionary<string, int> itemInventory = new();
    public int max_size { get; private set; }

    // Init
    public Inventory(int maxSize)
    {
        max_size = maxSize;
    }

    // Methods
    private bool checkSizeConstraint()
    {
        return  GetAllItemCount() < max_size;

    }
    
    public bool AddItem(string itemName, int quantity)
    {
        for (int i = 0; i < quantity; i++)
        {
            if (!checkSizeConstraint())
            {
                return false;
            }
        
            if (itemInventory.ContainsKey(itemName))
            {
                itemInventory[itemName] += quantity;
            }
            else
            {
                itemInventory[itemName] = quantity;
            }
        }
        return true;
    }

    public bool RemoveItem(string itemName, int quantity)
    {
        if (itemInventory.ContainsKey(itemName))
        {
            itemInventory[itemName] -= quantity;
            if (itemInventory[itemName] <= 0)
            {
                itemInventory.Remove(itemName);
            }

            return true;
        }

        return false;
    }

    public int GetItemCount(string itemName)
    {
        if (itemInventory.TryGetValue(itemName, out var count))
        {
            return count;
        }
        return 0;
    }

    public Dictionary<string, int> GetAllItems()
    {
        // Return the entire inventory as a dictionary.
        return itemInventory;
    }
    
    public int GetAllItemCount()
    {
        // Return the entire inventory as a dictionary.
        return itemInventory.Values.Sum();
    }
    
}