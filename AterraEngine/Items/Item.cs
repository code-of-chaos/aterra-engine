// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------
using System.Globalization;
using System.Reflection;
using System.Resources;
using System.Xml.Serialization;
using AterraEngine.Lib;
namespace AterraEngine.Items;

// ---------------------------------------------------------------------------------------------------------------------
// Code
// ---------------------------------------------------------------------------------------------------------------------
[XmlRoot("item")]
public record Item {
    
    [XmlAttribute("id")]
    public required string itemIdString { get; set; }
    
    [XmlIgnore] // Ignore this property during serialization
                // This is the actual itemId
    public int itemId => IdConverter.toInt(itemIdString);

    [XmlAttribute("resource_manager")] 
    public required string resource_manager_name;

    [XmlIgnore] 
    private ResourceManager? _resource_manager;
    
    [XmlAttribute("internal_name")]
    public required string internal_name;
    
    [XmlIgnore]
    public string name =>
        // custom getter, as this needs the _resource_manager
        _resource_manager?.GetString($"{internal_name}_name") ?? "ITEM NAME UNDEFINED";
    
    [XmlAttribute("has_description")]
    public required bool has_description;
    
    [XmlIgnore]
    public string description =>
        // custom getter, as this needs the _resource_manager
        // if there is no description, returns an empty string
        has_description 
            ? _resource_manager?.GetString($"{internal_name}_description") ?? "ITEM DESCRIPTION UNDEFINED" 
            : ""; 

    [XmlAttribute("stacksize")] 
    public required int stacksize = 1; // default has to be always 1

    [XmlAttribute("print_icon")] 
    public required string print_icon;

    // -----------------------------------------------------------------------------------------------------------------
    // Constructor
    // -----------------------------------------------------------------------------------------------------------------
    public Item() { } // Add a parameterless constructor for deserialization
    
    /// <summary>
    /// Method populates the _resourceManager field of the item, so the fields can be translated
    /// Has to be run after the item has been parsed from xml, as this is done by the <see cref="ItemManager"/> class.
    /// Even though Item is a record, this is the best approach I think, given Item(s) are parsed from xml files.
    /// </summary>
    /// <param name="resource_manager"></param>
    public void assignResourceManager(ResourceManager? resource_manager) {
        _resource_manager = resource_manager;
    }
    
    // -----------------------------------------------------------------------------------------------------------------
    public override string ToString() {
        return $"{itemIdString} - '{name}' - '{description}'";
    }

    // -----------------------------------------------------------------------------------------------------------------
    // DON'T KEEP THIS
    // -----------------------------------------------------------------------------------------------------------------
    public static Item copy(Item OldItem, int offset) {
        return new Item(){
            itemIdString = OldItem.itemIdString+offset,
            resource_manager_name = OldItem.resource_manager_name,
            internal_name = $"{OldItem.internal_name}{offset}",
            has_description = OldItem.has_description,
            stacksize = OldItem.stacksize,
            print_icon = OldItem.print_icon
        };
    }
}