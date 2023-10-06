﻿// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------

using System.Text;
using AterraLL_Lib.SQL;
using AterraLL_Lib;
using AterraLL_Lib.SQL.Models;
namespace AterraLostLegion; 

// ---------------------------------------------------------------------------------------------------------------------
// Code
// ---------------------------------------------------------------------------------------------------------------------
internal static class Program {
    private static async Task Main() {
        // Some things can be setup here, to then be handed off
        var dbSqlite = new DbSqlite(
            connectionString: "data/data.db"
        );
        
        await Task.Run(() => AsyncMain(dbSqlite)).ConfigureAwait(false);
    }

    private static async Task AsyncMain(DbSqlite dbSqlite) {
        await dbSqlite.createTables();
        
        // todo make an exit guard if not all tables are present, before loading data
        await dbSqlite.checkIfTablesPresent();
        
        List<TileType>? tile_type_data = null;
        List<List<int>>? map_data = null;
        
        await Task.WhenAll(
            Task.Run(async () => tile_type_data = await AsyncJson.LoadJsonAsync<List<TileType>>("data/tile_types.json")),
            Task.Run(async () => map_data = await AsyncJson.LoadJsonAsync<List<List<int>>>("data/map_data.json"))
        );
        
        if (tile_type_data is null) {
            throw new Exception("tile_type_data can't be null");
        }
        if (map_data is null) {
            throw new Exception("map_data can't be null");
        }
        
                
        foreach (var VARIABLE in tile_type_data) {
            Console.Out.WriteLine($"{VARIABLE}");
        }
        
        Console.WriteLine();
        
        // Store tile placement commands in a list
        var rows = map_data.Count;
        var cols = map_data[0].Count;
        
        StringBuilder output = new StringBuilder();

        for (var x = 0; x < rows; x++) {
            for (var y = 0; y < cols; y++) {

                var data = map_data[x][y];
                var tile_data = tile_type_data.Find(type => type.Id == data);
                var text = (tile_data is not null) ? tile_data.RenderedString : $"{data}{data}{data}";
                output.Append(text);
            }
            output.AppendLine();
        }
        
        // actually write the full text to the console
        Console.WriteLine(output.ToString());
        
    }
}