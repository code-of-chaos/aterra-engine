// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------
using System.Data;
using AterraEngine.Lib;

namespace AterraEngine.Logic.Items;
// ---------------------------------------------------------------------------------------------------------------------
// Interface Code
// ---------------------------------------------------------------------------------------------------------------------
public interface IItemManager: IXmlHandler<Item> {
    public IReadOnlyDictionary<int, Item> availableItems { get; }
    public HashSet<string> availableTags { get; }

    public Item? getItemById(string itemId);
    public Item? getItemById(int itemId);
    Item[] filterByType(ItemType item_type);
    
    public void addItem(int item_id, Item item);
    public void addItem(Item item);
}
// ---------------------------------------------------------------------------------------------------------------------
// Code
// ---------------------------------------------------------------------------------------------------------------------
public class ItemManager : XmlHandler<Item>, IItemManager  {
    private readonly Dictionary<int, Item> _availableItems = new ();
    public IReadOnlyDictionary<int, Item> availableItems => _availableItems.AsReadOnly();

    public HashSet<string> availableTags { get; } = new HashSet<string>();
    // -----------------------------------------------------------------------------------------------------------------
    // Constructor
    // -----------------------------------------------------------------------------------------------------------------
    
    // -----------------------------------------------------------------------------------------------------------------
    // Internal Item Dictionary
    // -----------------------------------------------------------------------------------------------------------------
    public Item? getItemById(string itemId) => _getItemById(IdConverter.toInt(itemId));
    public Item? getItemById(int itemId) => _getItemById(itemId);
    private Item? _getItemById(int itemId) {
        return availableItems.TryGetValue(itemId, out var found_item) ? found_item : null;
        
    }
    
    public void addItem(int item_id, Item item) => _addItem(item_id, item);
    public void addItem(Item item) => _addItem(item.itemId, item);
    private void _addItem(int item_id, Item item) {
        // validate known IDs vs Item id
        _checkValidId(item, true);
        _availableItems.Add(item_id, item);
    }

    private void _checkValidId(Item item, bool is_new_item) {
        if (!is_new_item & !availableItems.TryGetValue(item.itemId, out _)) {
            throw new Exception($"{item.itemId} was not found in the id table. This means something went wrong");
        }
        if (availableItems.TryGetValue(item.itemId, out var item_found) && item_found.itemId != item.itemId) {
            throw new Exception($"{item.itemId} was found in the id table, but was occupied by something else");
        }
    }

    public Item[] filterByType(ItemType item_type) {
        return availableItems.Values.Where(item => item.item_type == item_type).ToArray();
    }
    
    // -----------------------------------------------------------------------------------------------------------------
    // XML converter
    // -----------------------------------------------------------------------------------------------------------------
    public new void exportXmlFolder(List<Item> objects_to_export, string folder_path) {
        _exportXmlFolder(objects_to_export, folder_path, (item) => $"{item.internal_name}.xml");
    }
    public new void importXmlFolder(string folder_path) {
        foreach (var item in  _importXmlFolder(folder_path:folder_path)) {
            if (!_availableItems.TryAdd(item.itemId, item)) {
                throw new DuplicateNameException($"Item id '{item.itemId}' was already added");
            }
        }
    }
    // -----------------------------------------------------------------------------------------------------------------
    // Tag System
    // -----------------------------------------------------------------------------------------------------------------
}