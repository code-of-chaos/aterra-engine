// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------
using AterraEngine.Lib;

namespace AterraEngine.Logic.Map;
// ---------------------------------------------------------------------------------------------------------------------
// Support Code
// ---------------------------------------------------------------------------------------------------------------------

// simple helped class for JSON deserializer logic
public record AreaJson(List<List<int>> map, Dictionary<string, POI> POIs);

// ---------------------------------------------------------------------------------------------------------------------
// Code
// ---------------------------------------------------------------------------------------------------------------------
public class Area {
    public string area_id;
    public Tile[,] area_map;

    public Area(string area_id, Tile[,] area_map) {
        this.area_id = area_id;
        this.area_map = area_map;
    }

    public static async Task<Area?> createFromJsonAsync(string area_filepath) {
        var area_json = await AsyncJson.LoadJsonAsync<AreaJson>(area_filepath)
                        // OH, remember this! it "replaces" the "if null" 
                        ?? throw new Exception($"{area_filepath} could not be loaded");

        var rows = area_json.map.Count;
        var columns = rows > 0 ? area_json.map[0].Count : 0;

        // Initialize the area_map with appropriate dimensions
        var area_map = new Tile[rows, columns];

        // Go over all tiles, and find the POI's
        for (var i = 0; i < rows; i++)
        for (var j = 0; j < columns; j++) {
            Tile tile_data;
            switch (area_json.map[i][j]) {
                case 0: {
                    if (!area_json.POIs.TryGetValue($"{i},{j}", out var poi)) throw new Exception("POI undefined");

                    // Populates the var data, may be altered in future use
                    tile_data = poi;
                    break;
                }
                default:
                    if (!TileManager.tile_dictionary.TryGetValue(area_json.map[i][j], out var tile))
                        throw new Exception($"Used a Tile id which isn't known => {area_json.map[i][j]}");

                    // Populates the var data, may be altered in future use
                    tile_data = tile ?? throw new Exception("Tile was found, but was null");
                    break;
            }

            // actually assign tile data to the multi dimensional array
            area_map[i, j] = tile_data;
        }

        return new Area(Path.GetFileName(area_filepath), area_map);
    }
}