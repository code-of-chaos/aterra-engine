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
    
    private const int _frame_size = 31;
    private readonly IChunk?[,] _camera_view = new IChunk?[_frame_size, _frame_size];
    private readonly int _chunk_size = EngineServices.getDEFAULTS().chunk_max_size;
    private const string _blank_str = "-";
    private static readonly int _lbound = -(int)Math.Floor(_frame_size / 2f);
    // private static readonly int ubound =  (int)Math.Ceiling(_frame_size / 2f);
    
    public void renderFrame(ILevel current_level, IPosition2D camera_pos) {
        // Gather chunks for the camera to view
        for (int i = 0; i < _frame_size; i++) {
            for (int j = 0; j < _frame_size; j++) {
                current_level.tryGetChunk(
                    new Position2D(camera_pos.X + i + _lbound, camera_pos.Y + j + _lbound),
                    out _camera_view[i, j]
                );
            }
        }
        
        // Print to console as soon as we get it
        //      Only use _frame_size if the camera's view is a square
        for (            int n_row = 0;       n_row < _frame_size;        n_row++) {
            for (        int n_chunk_row = 0; n_chunk_row < _chunk_size; n_chunk_row++) {
                for (    int n_col = 0;       n_col < _frame_size;        n_col++) {
                    for (int n_chunk_col = 0; n_chunk_col < _chunk_size; n_chunk_col++) {
                        
                        string text = _camera_view[n_row, n_col]?.tile_map[n_chunk_row, n_chunk_col]?.console_text ?? _blank_str;
                        Console.Out.Write($"{text}{text}");
                    }
                }
                Console.Out.Write(Environment.NewLine);
            }
        }
        // Cleanup
        Array.Clear(_camera_view);
    }
}