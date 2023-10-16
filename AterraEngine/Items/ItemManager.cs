// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------
using System.Xml.Serialization;
using AterraEngine.Lib;
using AterraEngine.Lib.Localization;

namespace AterraEngine.Items;

// ---------------------------------------------------------------------------------------------------------------------
// Interface Code
// ---------------------------------------------------------------------------------------------------------------------
public interface IItemManager {
    public IReadOnlyDictionary<int, Item> availableItems { get; }

    public Item? getItemById(string itemId);
    public Item? getItemById(int itemId);
    Item[] filterByType(ItemType item_type);
    
    public void addItem(int item_id, Item item);
    public void addItem(Item item);

    public void exportXml(Item item, string filepath);
    public void exportXmlFolder(string folderpath);

    public Item importXml(string filepath);
    public void importXmlFolder(string folderpath);
}
// ---------------------------------------------------------------------------------------------------------------------
// Code
// ---------------------------------------------------------------------------------------------------------------------
public class ItemManager : IItemManager {
    private readonly Dictionary<int, Item> _availableItems = new ();
    public IReadOnlyDictionary<int, Item> availableItems => _availableItems;
    
    // -----------------------------------------------------------------------------------------------------------------
    // Constructor
    // -----------------------------------------------------------------------------------------------------------------
    
    // -----------------------------------------------------------------------------------------------------------------
    // Internal Dictionary
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
    public void exportXml(Item item, string filepath) {
        // validate known IDs vs Item id
        _checkValidId(item, false);
        
        // can't make async, as there isn't an async serializer???
        XmlSerializer serializer = new XmlSerializer(typeof(Item));
        using (var writer = new StreamWriter(filepath)) {
            serializer.Serialize(writer, item);
        }
    }

    public void exportXmlFolder(string folderpath) {
        foreach (Item item in availableItems.Values) {
            exportXml(
                item: item,
                filepath: Path.Combine(folderpath, $"{item.internal_name}.xml")
            );
        }
    }
    
    public Item importXml(string filepath) {
        IResxManager resx_manager = DependencyContainer.instance.resolve<IResxManager>();
        
        // can't make async, as there isn't an async serializer???
        XmlSerializer serializer = new XmlSerializer(typeof(Item));
        using (var reader = new StreamReader(filepath)) {
            Item item = (Item)serializer.Deserialize(reader)!;
            
            // validate known IDs vs Item id 
            _checkValidId(item, true);
            
            // fix the resource manager
            item.assignResourceManager(resx_manager.getResourceManager(item.resource_manager_name));
            return item;
        }
    }

    public void importXmlFolder(string folderpath) {
        string[] xmlFiles = Directory.GetFiles(folderpath, "*.xml");
        foreach (var xml_file in xmlFiles) {
            Item item = importXml(xml_file);
            addItem(item);
        }
    }
}