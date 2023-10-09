// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------

namespace AterraLL_Lib.Map;

// ---------------------------------------------------------------------------------------------------------------------
// Support Code
// ---------------------------------------------------------------------------------------------------------------------

// simple helped class for JSON deserializer logic
public record AreaJson(List<List<int>> map, Dictionary<string, POI> POIs);

// ---------------------------------------------------------------------------------------------------------------------
// Code
// ---------------------------------------------------------------------------------------------------------------------
public class Area {
    public List<List<Tile>> area_map;

    private Area(List<List<Tile>> area_map) {
        this.area_map = area_map; 
    }

    public static async Task<Area> createFromJson(string area_map_filepath) {
        var area_json = await AsyncJson.LoadJsonAsync<AreaJson>(filepath: area_map_filepath);
        if (area_json is null) {
            throw new Exception($"{area_map_filepath} could not be loaded");
        }

        List<List<Tile>> area_map = new List<List<Tile>>();
        
        // Go over all tiles, and find the POI's
        for (int i = 0; i < area_json.map.Count; i++) {
            
            // actually create a row
            area_map.Add(new List<Tile>());
            
            for (int j = 0; j < area_json.map[i].Count; j++) {

                switch (area_json.map[i][j]) {
                    case 0: {
                        if (!area_json.POIs.TryGetValue($"{i},{j}", out var poi)) {
                            throw new Exception("POI undefined");
                        }
                        area_map[i].Add(poi);
                        break;
                    }
                    
                    default:
                        area_map[i].Add(new Tile(tile_type:area_json.map[i][j]));
                        break;
                }
            }
        }
        
        
        return new Area(area_map: area_map);
    }
    
}