// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------
using AterraLL_Lib.Items;
using Xunit.Abstractions;

namespace AterraLL_Lib;
// ---------------------------------------------------------------------------------------------------------------------
// Code
// ---------------------------------------------------------------------------------------------------------------------
/// Simple Inventory system, based on a dictionary
public class Inventory
{
    // Set properties
    private readonly Dictionary<string, List<Item>> _itemInventory = new();
    private readonly int max_size;

    // Init
    public Inventory(int maxSize) {
        max_size = maxSize;
    }

    // Methods
    private bool CheckSizeConstraint() {
        return  GetAllItemCount() < max_size;
    }

    public bool AddItem(Item item) {
        if (!CheckSizeConstraint()) {
            return false;
        }
        
        // Either create anew list with the item in it,
        //  Or append to the list that is already there
        if (!_itemInventory.ContainsKey(item.item_id)) {
            _itemInventory[item.item_id] = new List<Item> { item };
        }
        else {
            _itemInventory[item.item_id].Add(item);
        }
        
        return true;
    }
    
    // This function can return null, keep this in mind!
    public Item? RemoveItem(string item_id) {
        // Exit guard: Can't get an item from a list, if the list doesn't exist
        if (!_itemInventory.ContainsKey(item_id)) {
            return null;
        }
        // First get the item,
        //  then make sure to remove the list, to not trip up the exit guard above if no items are present
        var list_of_items = _itemInventory[item_id];
        var item = list_of_items[^1];
        list_of_items.RemoveAt(list_of_items.Count - 1);
        
        if (list_of_items.Count == 0) {
            _itemInventory.Remove(item_id);
        }
        return item;
    }

    public int GetItemCount(string item_id) {
        return _itemInventory.TryGetValue(item_id, out var item_list) ? item_list.Count : 0;
    }

    public IReadOnlyDictionary<string, List<Item>> GetAllItems()
    {
        // Return the entire inventory as a dictionary.
        return _itemInventory.AsReadOnly();
    }

    public int GetAllItemCount() {
        // Return the entire inventory as a dictionary.
        return _itemInventory.Values.Sum(item_list => item_list.Count);
    }
    
}