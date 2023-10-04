namespace ConsoleApp1; 

public enum TileTypes {
    Void,
    Water,
    Grassland,
    Stone,
    City
}

public class TileTypePrintout {
    private static readonly Dictionary<TileTypes, string> _printout = new Dictionary<TileTypes, string>() {
        {TileTypes.Void , "  "},
        {TileTypes.Water, "~~"},
        {TileTypes.Grassland, ".."},
        {TileTypes.Stone, "/\\"},
        { TileTypes.City, "[]"}
    };

    public static string get_printout(TileTypes tile_type) {
        return _printout.GetValueOrDefault(tile_type, "  ");
    }
}