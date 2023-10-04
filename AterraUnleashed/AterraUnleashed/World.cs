// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------
namespace AterraUnleashed; 

using System;
using System.Text;
using System.Numerics; 

// ---------------------------------------------------------------------------------------------------------------------
// Code
// ---------------------------------------------------------------------------------------------------------------------
public class World {
    private readonly Tile[,] _world_grid;
    private Vector2 _player_pos;
    private Boolean _player_has_spawned;
    
    public World(int world_size_x, int world_size_y) {
        _world_grid = new Tile[world_size_x, world_size_y];
        _player_has_spawned = false;
    }

    public void add_tile_to_grid(Vector2 pos, Tile tile) {
        // Extract variables
        var x = (int)pos.X;
        var y = (int)pos.Y;
        
        // Check if the position is within the bounds of the grid
        if ((x < 0 || x >= _world_grid.GetLength(0)) || (y < 0 || y >= _world_grid.GetLength(1))) {
            throw new Exception("Pos " + pos + "is out of bounds of the world");
        }
        // Check if the tile isn't already populated on that position
        if (_world_grid[x, y] != null) {
            throw new Exception("The tile at pos " + pos + "is already populated");
        }
        
        // If all checks are done, simply set the tile to the correct position
        _world_grid[x, y] = tile;
    }

    public void print_grid() {
        var rows = _world_grid.GetLength(0);
        var cols = _world_grid.GetLength(1);
        
        StringBuilder output = new StringBuilder();

        for (var x = 0; x < rows; x++) {
            for (var y = 0; y < cols; y++) {
                Tile tile = _world_grid[x, y];
                
                
                if (((_player_pos.X, _player_pos.Y) == (x, y)) && _player_has_spawned) {
                    output.Append("@@");
                }
                output.Append(tile.to_text());
            }
            output.AppendLine();
        }
        
        // actually write the full text to the console
        Console.WriteLine(output.ToString());
    }

    public void spawn_player() {
        _player_pos = new Vector2();

        var pos_set = false;
        
        var rows = _world_grid.GetLength(0);
        var cols = _world_grid.GetLength(1);
        
        for (var x = 0; x < rows; x++) {
            for (var y = 0; y < cols; y++) {
                Tile tile = _world_grid[x, y];

                if (tile.type == TileTypes.Void) {
                    continue;
                }

                _player_pos.X = x;
                _player_pos.Y = y;
                
                Console.WriteLine(tile.type);
                Console.WriteLine($"{x}, {y}");
                pos_set = true;

                break;
            }
            // do this, else it'll still go through the first for loop
            if (pos_set) {
                break;
            }
        }

        if (!pos_set) {
            throw new Exception("Player had no valid spawning location");
        }
        _player_has_spawned = true;
        

    }

    public bool move_player(Vector2 pos_offset) {
        if (!_player_has_spawned) {
            return false;
        }
        
        Vector2 new_pos = _player_pos + pos_offset;
        Tile new_tile = _world_grid[(int)new_pos.X, (int)new_pos.Y];
        
        if (new_tile.type == TileTypes.Void) {
            return false;
        }

        _player_pos = new_pos;
        return true;

    }
}