﻿// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------

using System.Text;
using AterraLL_Lib.Items;
using Area = AterraLL_Lib.Map.Area;

namespace AterraLostLegion; 

// ---------------------------------------------------------------------------------------------------------------------
// Code
// ---------------------------------------------------------------------------------------------------------------------
internal static class Program {
    private static async Task Main() {
        Console.OutputEncoding = Encoding.Unicode;
        
        await Task.Run(AsyncMain).ConfigureAwait(false);
    }

    private static async Task AsyncMain() {
        
        // Load all item type
        await Task.WhenAll(
            ItemInternalDictionary.loadFromJson<Item>("data/item_dictionary/armor.json"),
            ItemInternalDictionary.loadFromJson<Item>("data/item_dictionary/items.json"),
            ItemInternalDictionary.loadFromJson<Item>("data/item_dictionary/potions.json"),
            ItemInternalDictionary.loadFromJson<ItemWeapon>("data/item_dictionary/weapons.json")
        );

        await Console.Out.WriteLineAsync($"{string.Join(",", ItemInternalDictionary.getAllItemIds()) }");

        var item = ItemInternalDictionary.getItemById("SwordOfJustice");
        await Console.Out.WriteLineAsync($"{item}");

        Area area = await Area.createFromJsonAsync("data/area/aterra.json");

        foreach (var line in area.area_map) {
            Console.Out.WriteLine(
                string.Join(" , ", line)    
            );
        }
        
        Area area2 = await Area.createFromJsonAsync("data/area/house_1.json");

        foreach (var line in area2.area_map) {
            Console.Out.WriteLine(
                string.Join(" , ", line)    
            );
        }
        

        

        // await dbSqlite.createTables();
        //
        // // todo make an exit guard if not all tables are present, before loading data
        // await dbSqlite.checkIfTablesPresent();
        //
        // List<TileType>? tile_type_data = null;
        // List<List<int>>? map_data = null;
        //
        // await Task.WhenAll(
        //     Task.Run(async () => tile_type_data = await AsyncJson.LoadJsonAsync<List<TileType>>("data/tile_types.json")),
        //     Task.Run(async () => map_data = await AsyncJson.LoadJsonAsync<List<List<int>>>("data/map_data.json"))
        // );
        //
        // if (tile_type_data is null) {
        //     throw new Exception("tile_type_data can't be null");
        // }
        // if (map_data is null) {
        //     throw new Exception("map_data can't be null");
        // }
        //         
        // foreach (var VARIABLE in tile_type_data) {
        //     Console.Out.WriteLine($"{VARIABLE}");
        // }
        //
        // Console.WriteLine();
        //
        // // Store tile placement commands in a list
        // AreaMapBinary areaMapBinary = new AreaMapBinary();
        // areaMapBinary.write("test7.bin", map_data);
        //
        // var read_map_data = areaMapBinary.read("test7.bin");
        //
        // var rows = read_map_data.Count;
        // var cols = read_map_data[0].Count;
        //
        // StringBuilder output = new StringBuilder();
        //
        // Console.WriteLine();
        //
        // for (var x = 0; x < rows; x++) {
        //     for (var y = 0; y < cols; y++) {
        //
        //         var data = map_data[x][y];
        //         var tile_data = tile_type_data.Find(type => type.Id == data);
        //         var text = (tile_data is not null) ? tile_data.RenderedString : $"{data}{data}{data}";
        //         output.Append(text);
        //     }
        //     output.AppendLine();
        // }
        //
        // // actually write the full text to the console
        // Console.WriteLine(output.ToString());

    }
}