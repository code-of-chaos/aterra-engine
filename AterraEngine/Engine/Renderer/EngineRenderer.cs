// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------
using AterraEngine.Interfaces.Engine.Renderer;
using AterraEngine.Interfaces.Logic.EngineObjectManager.EngineObjects.Level;
using AterraEngine.Interfaces.Structs;
using AterraEngine.Structs;
using Serilog;

namespace AterraEngine.Engine.Renderer;
// ---------------------------------------------------------------------------------------------------------------------
// Code
// ---------------------------------------------------------------------------------------------------------------------
public class EngineRenderer:IEngineRenderer {
    private readonly ILogger _logger = EngineServices.getLogger();
    
    public void renderFrame(ILevel current_level, IPosition2D camera_pos) {
        
        var console_text = new string[3,3];
        var camera_view = new IChunk?[3, 3];
    
        for (int i = -1; i < 2; i++) {
            for (int j = -1; j < 2; j++) {

                IPosition2D chunk_pos = new Position2D(camera_pos.X + i, camera_pos.Y + j);
                
                if (!current_level.tryGetChunk(chunk_pos, out var found_chunk)) {
                    _logger.Error("CHUNK NOT FOUND, {x}, {y}",chunk_pos.X,chunk_pos.Y);
                }

                _logger.Information("CHUNK FOUND, {x}, {y}",chunk_pos.X,chunk_pos.Y);
                camera_view[i+1, j+1] = found_chunk;
            }
        }
        
        
        _logger.Warning("{v}",console_text.GetLength(0));
        _logger.Warning("{v}",console_text.GetLength(1));
        
        
        int rowLength = camera_view.GetLength(0);
        int colLength = camera_view.GetLength(1);

        int chunk_max_size = EngineServices.getDEFAULTS().chunk_max_size;

        for (int n_row = 0; n_row < rowLength; n_row++) {
            for (int n_chunk_row = 0; n_chunk_row < chunk_max_size; n_chunk_row++) {

                for (int n_col = 0; n_col < colLength; n_col++) {
                    for (int n_chunk_col = 0; n_chunk_col < chunk_max_size; n_chunk_col++) {

                        var text = camera_view[n_row, n_col]?.tile_map[n_chunk_row, n_chunk_col]?.console_text ?? " ";
                        Console.Out.Write($"{text} ");
                    }
                    Console.Out.Write("| ");
                }
                Console.Out.Write(Environment.NewLine);
                
            }
            Console.Out.Write(new string('-', (3 * chunk_max_size * 2)+rowLength+2));
            Console.Out.Write(Environment.NewLine);
        }
    }
}