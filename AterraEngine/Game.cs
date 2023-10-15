// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------

using System.Numerics;
using AterraEngine.Entities;
using AterraEngine.Map;

namespace AterraEngine;

// ---------------------------------------------------------------------------------------------------------------------
// Code
// ---------------------------------------------------------------------------------------------------------------------
public class Game {
    private Area area;
    private AreaManager area_manager;
    private Dictionary<string, Dictionary<Entity, Vector2>> entity_manager;
    private bool game_alive;
    private Player player;

    public async Task start() {
        // create world
        area_manager = await AreaManager.createAreaManagerAsync(
            "data/area/aterra.json"
        );

        // We start in the overworld
        area = area_manager.getOverworld();

        // spawn player
        player = new Player();

        // register entities to table
        entity_manager = new Dictionary<string, Dictionary<Entity, Vector2>> {
            {
                area_manager.getOverworld().area_id, new Dictionary<Entity, Vector2> {
                    { player, new Vector2() }
                }
            }
        };

        // start loop
        game_alive = true;
        try {
            while (game_alive) game_alive = await game_tick();
        }

        catch (Exception e) {
            Console.WriteLine(e);
            throw;
        }

        // handle exit
    }

    private async Task<bool> game_tick() {
        // print UI
        var area_rows = area.area_map.GetLength(0);
        var area_cols = area.area_map.GetLength(1);

        // Create Entity map
        Entity?[,] entity_area_grid = new Entity[area_rows, area_cols];
        entity_manager.TryGetValue(area.area_id, out var area_entity_map);
        var areaEntityMap = area_entity_map ?? throw new Exception("Entity not found in area");

        area_entity_map.TryGetValue(player, out var player_pos);

        entity_area_grid[(int)player_pos.X, (int)player_pos.Y] = player;

        POI? POI_buffer = null;

        Console.Out.WriteLine(
            string.Join(" , ", area_manager.area_dictionary.Keys)
        );

        // print 
        for (var i = 0; i < area_rows; i++) {
            // Get the number of rows
            for (var j = 0; j < area_cols; j++) {
                // Get the number of columns

                string printable;

                var entity = entity_area_grid[i, j];
                var tile = area.area_map[i, j];
                if (tile is POI poi && entity is not null) POI_buffer = poi;

                if (entity != null)
                    printable = entity.printable;
                else
                    printable = tile.printableText;

                Console.Out.Write($"{printable}");
            }

            Console.Out.WriteLine();
        }

        // Prompt the player on what they want to do.
        if (POI_buffer is not null) {
            Console.Out.WriteLine(POI_buffer.data);
            Console.Out.WriteLine(POI_buffer.area_link);

            if (POI_buffer.area_link != null) {
                area_manager.area_dictionary.TryGetValue(POI_buffer.area_link, out var new_area);
                area = new_area ?? throw new Exception("No Area found");
                area_entity_map.Remove(player);
                if (!entity_manager.TryAdd(area.area_id,
                        new Dictionary<Entity, Vector2> { { player, new Vector2() } })) {
                    entity_manager.TryGetValue(area.area_id, out var new_ara_entity_map);
                    area_entity_map = new_ara_entity_map;
                }

                ;
            }
        }

        // ask for player input
        var input = Console.ReadLine();

        switch (input) {
            case "n":
                player_pos.X -= 1;
                break;
            case "e":
                player_pos.Y += 1;
                break;
            case "s":
                player_pos.X += 1;
                break;
            case "w":
                player_pos.Y -= 1;
                break;
        }

        player_pos.X = Math.Max(player_pos.X, 0);
        player_pos.Y = Math.Max(player_pos.Y, 0);

        area_entity_map[player] = player_pos;

        // execute player input
        return await Task.FromResult(true);
    }
}