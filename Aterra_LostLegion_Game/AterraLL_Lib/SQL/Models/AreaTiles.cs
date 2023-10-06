// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------
using System.ComponentModel.DataAnnotations.Schema;
using SQLite;

namespace AterraLL_Lib.SQL.Models;

// ---------------------------------------------------------------------------------------------------------------------
// Code
// ---------------------------------------------------------------------------------------------------------------------
public class AreaTiles {
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }    
    
    [Indexed, ForeignKey(nameof(Area)), Unique(Name="uniqueAreaPos")]
    public int AreaID { get; set; }
    
    [Unique(Name="uniqueAreaPos")]
    public int PositionX { get; set; }
    
    [Unique(Name="uniqueAreaPos")]
    public int PositionY { get; set; }
    
    [Indexed, ForeignKey(nameof(POI))]
    public int? POIid { get; set; }
    
    [Indexed, ForeignKey(nameof(TileType))]
    public int TileType { get; set; }
    
}