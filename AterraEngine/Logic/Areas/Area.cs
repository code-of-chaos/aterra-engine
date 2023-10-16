// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------
using System.Resources;
using System.Xml.Serialization;
using AterraEngine.Lib;
namespace AterraEngine.Logic.Areas; 

// ---------------------------------------------------------------------------------------------------------------------
// Code
// ---------------------------------------------------------------------------------------------------------------------
public record Map {
    [XmlArray("map")]
    [XmlArrayItem("row")]
    public List<string> rows { get; set; }

    [XmlIgnore]
    public int[][] map_array {
        get {
            return rows.Select(row => row.Split(",").Select(int.Parse).ToArray()).ToArray();
        } 
    }
}

// ---------------------------------------------------------------------------------------------------------------------
[XmlRoot("area")]
public record Area {
    
    [XmlAttribute("id")]
    public required string areaIdString { get; set; }
    [XmlIgnore] // Ignore this property during serialization
                // This is the actual ID used by the manager
    public int areaId => IdConverter.toInt(areaIdString);
    
    [XmlElement("map")]
    public Map map { get; set; } 
}
