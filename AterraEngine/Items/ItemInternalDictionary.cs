// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------
using AterraEngine.Lib;

namespace AterraEngine.Items;

// ---------------------------------------------------------------------------------------------------------------------
// Code
// ---------------------------------------------------------------------------------------------------------------------
public static class ItemInternalDictionary {
    
    // Todo think about if different item types have to be seperated out into multiple dictionaries
    private static readonly Dictionary<string, Item?> _items = new Dictionary<string, Item?>();

    private static void setItem(Item item) {
        if (_items.TryGetValue(item.itemId, out var item_duplicate)) {
            throw new Exception($"Item id of '{item.itemId}' already used by '{item_duplicate}'");
        }
        _items[item.itemId] = item;
    }
    
    public static Item? getItemById(string itemId) {
        return !_items.TryGetValue(itemId, out var found_item) ? null : found_item;
    }

    public static IEnumerable<string> getAllItemIds() {
        return _items.AsReadOnly().Keys.ToList();
    }
    
    public static async Task loadFromJson<T>(string jsonFilePath) where T: Item{
        var items = await AsyncJson.LoadJsonAsync<List<T>>(filepath: jsonFilePath);
        if (items is null) {
            throw new Exception($"Could not load from json file '{jsonFilePath}'");
        }
        
        // items is defined
        foreach (var item in items) {
            setItem(item);
        }
    }
}