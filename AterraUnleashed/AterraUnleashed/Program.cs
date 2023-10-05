namespace AterraUnleashed; 
// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------
using System.Numerics;
using System;
using System.IO;
using System.Text.Json;
using AterraUnleashedLib;

// ---------------------------------------------------------------------------------------------------------------------
// Code
// ---------------------------------------------------------------------------------------------------------------------
public class JsonData
{
    public List<List<int>> tile_map { get; set; }
    public JsonData(List<List<int>> tile_map) {
        this.tile_map = tile_map;
    }
}
internal static class Program {
    private static void Main() {
        // get data from json file
        string json_data = File.ReadAllText("map_data.json");
        
        Console.WriteLine(json_data);
        
        // Deserialize the JSON data into the JsonData class
        JsonData? jsonData = JsonSerializer.Deserialize<JsonData>(json_data);
        if (jsonData?.tile_map == null) {
            throw new Exception("Json file wasn't configured properly");
        }
        
        // Extract the tile_map property
        List<List<int>> tile_map = jsonData.tile_map;
        
        // Store tile placement commands in a list
        var world_rows = tile_map.Count;
        var world_cols = tile_map[0].Count;
        
        var world = new World(
            world_size_x:world_rows,
            world_size_y:world_cols
        );

        int x;
        int y;
        for (x = 0; x < world_rows; x++) {
            for (y = 0; y < world_cols; y++) {
                int tileTypeNum = tile_map[x][y];

                // Get the correct TileTypes based on the integer value
                TileTypes tileType = (TileTypes)tileTypeNum;

                world.add_tile_to_grid(new Vector2(x, y), new Tile(tileType));
            }
        }

        world.print_grid();

        Console.ReadLine();
        
        world.spawn_player();
        world.print_grid();

        Console.WriteLine("x_offset");
        string? input = Console.ReadLine();
        int.TryParse(input, out var x_);
        
        Console.WriteLine("y_offset");
        input = Console.ReadLine();
        int.TryParse(input, out var y_);

        
        world.move_player(new Vector2(x_, y_));
        world.print_grid();
        
    }
}