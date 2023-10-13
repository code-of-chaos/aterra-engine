// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------

namespace AterraEngine.Map;

// ---------------------------------------------------------------------------------------------------------------------
// Code
// ---------------------------------------------------------------------------------------------------------------------
public static class TileManager {
    public static Dictionary<int, Tile?> tile_dictionary { get; } = new Dictionary<int, Tile?>()
    {
        { 0, new Tile("UNDEFINED", "UUU",false) },
        { 1, new Tile("water", "~~~",true) },
        { 2, new Tile("grass", "---",true) },
        { 3, new Tile("wall", "\u2589\u2589\u2589",false) },
        { 4, new Tile("floor","   " ,true) },
        { 5, new Tile("deep water", "...",false) },
    };

    public static Tile getTileById(int tile_id) {
        tile_dictionary.TryGetValue(tile_id, out var tile);
        return tile ?? throw new NullReferenceException($"Id {tile_id} was found, but was null");
    }
}