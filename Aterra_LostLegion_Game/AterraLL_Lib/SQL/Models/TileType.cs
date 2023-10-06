// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------
using SQLite;
namespace AterraLL_Lib.SQL.Models;

// ---------------------------------------------------------------------------------------------------------------------
// Code
// ---------------------------------------------------------------------------------------------------------------------
public class TileType {
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }

    [Unique, NotNull]
    public string Name { get; set; } = null!;
    
    [Unique, NotNull]
    public string RenderedString { get; set; } = null!;

    public override string ToString() {
        return $"{Id}, {Name}, {RenderedString}";
    }
}