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
public class EngineRendererChunks:IEngineRenderer {
    private readonly ILogger _logger = EngineServices.getLogger();
    private const int _frame_size = 15;

    public void renderFrame(ILevel current_level, IPosition2D camera_pos) {
        
        var camera_view = new IChunk?[_frame_size, _frame_size];

        int lbound = -(int)Math.Floor(_frame_size / 2f);
        
        for (int i = 0; i < _frame_size; i++) {
            for (int j = 0; j < _frame_size; j++) {

                IPosition2D chunk_pos = new Position2D(camera_pos.X + i + lbound, camera_pos.Y + j + lbound);

                current_level.tryGetChunk(chunk_pos, out var found_chunk);
                camera_view[i, j] = found_chunk;
            }
        }
        
        
        int rowLength = camera_view.GetLength(0);
        int colLength = camera_view.GetLength(1);

        int chunk_max_size = EngineServices.getDEFAULTS().chunk_max_size;
        const string spacing = " | ";
        const char blank = '-';
        const string blank_str = "'-'";

        for (int n_row = 0; n_row < rowLength; n_row++) {
            for (int n_chunk_row = 0; n_chunk_row < chunk_max_size; n_chunk_row++) {
                for (int n_col = 0; n_col < colLength; n_col++) {
                    for (int n_chunk_col = 0; n_chunk_col < chunk_max_size; n_chunk_col++) {
                        string text = camera_view[n_row, n_col]?.tile_map[n_chunk_row, n_chunk_col]?.console_text ?? blank_str;
                        Console.Out.Write(text);
                        Console.Out.Write(text);
                    }
                    Console.Out.Write(spacing);
                }
                Console.Out.Write(Environment.NewLine);
                
            }
            Console.Out.Write(new string(blank, (rowLength * (chunk_max_size * 2) + rowLength * 3)));
            Console.Out.Write(Environment.NewLine);
        }
    }
}