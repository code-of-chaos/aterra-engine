// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------

using System.Xml.Serialization;
using System.Xml.Linq;
namespace AterraEngine.Items;

// ---------------------------------------------------------------------------------------------------------------------
// Code
// ---------------------------------------------------------------------------------------------------------------------
public class ItemManager {
    public Dictionary<string, Item> availableItems { get; private set; } = new Dictionary<string, Item>();
    
    // -----------------------------------------------------------------------------------------------------------------
    // Constructor
    // -----------------------------------------------------------------------------------------------------------------

    // -----------------------------------------------------------------------------------------------------------------
    // Internal Dictionary
    // -----------------------------------------------------------------------------------------------------------------
    public void addItem(string item_name, Item item) => _addItem(item_name, item);
    public void addItem(Item item) => _addItem(item.itemId, item);

    private void _addItem(string item_name, Item item) {
        // Exit clause: Can't have items with duplicate names
        if (availableItems.TryGetValue(item_name, out var duplicate_item)) {
            throw new Exception($"duplicate item of {duplicate_item}");
        }
        
        availableItems.Add(item_name, item);
    }
    
    // -----------------------------------------------------------------------------------------------------------------
    // XML converter
    // -----------------------------------------------------------------------------------------------------------------
    // TODO make async
    public void exportXml(Item item, string filepath) {
        XmlSerializer serializer = new XmlSerializer(typeof(Item));
        using (var writer = new StreamWriter(filepath)) {
            serializer.Serialize(writer, item);
        }
    }
    
    // TODO make async
    public Item importXml(string filepath) {
        XmlSerializer serializer = new XmlSerializer(typeof(Item));
        try {
            using (var reader = new StreamReader(filepath)) {
                return (Item)serializer.Deserialize(reader);
            }
        }
        catch (Exception ex) {
            throw;
        }
    }
}