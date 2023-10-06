// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------
using System.ComponentModel.DataAnnotations.Schema;
using SQLite;

namespace AterraLL_Lib.SQL.Models;

// ---------------------------------------------------------------------------------------------------------------------
// Code
// ---------------------------------------------------------------------------------------------------------------------
public class POI {
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }    
    
    [Indexed, ForeignKey(nameof(AreaTiles))]
    public int AreaTileID { get; set; }
    
    [Indexed, ForeignKey(nameof(AreaTiles))]
    public int? LinkToArea { get; set; }
}