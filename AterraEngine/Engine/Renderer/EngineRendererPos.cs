// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------
using AterraEngine.Interfaces.Engine.Renderer;
using AterraEngine.Interfaces.Logic.EngineObjectManager.EngineObjects.Level;
using AterraEngine.Interfaces.Structs;
using AterraEngine.Lib.Ansi;
using AterraEngine.Lib.Structs;
using AterraEngine.Structs;
using Serilog;

namespace AterraEngine.Engine.Renderer;
// ---------------------------------------------------------------------------------------------------------------------
// Code
// ---------------------------------------------------------------------------------------------------------------------
public class EngineRendererPos:IEngineRenderer {
    private readonly ILogger _logger = EngineServices.getLogger();
    private const int _frame_size = 9;

    public void renderFrame(ILevel current_level, IPosition2D camera_pos) {
        
        var console_text = new string[_frame_size,_frame_size];
        var camera_view = new IChunk?[_frame_size, _frame_size];

        int lbound = -(int)Math.Floor(_frame_size / 2f);
        int ubound =  (int)Math.Ceiling(_frame_size / 2f);
        
        _logger.Warning("_frame_size: {_frame_size}",_frame_size);
        _logger.Warning("lbound: {lbound}",lbound);
        _logger.Warning("ubound: {ubound}",ubound);
        
        for (int i = 0; i < _frame_size; i++) {
            for (int j = 0; j < _frame_size; j++) {

                IPosition2D chunk_pos = new Position2D(camera_pos.X + i + lbound, camera_pos.Y + j + lbound);
                
                if (!current_level.tryGetChunk(chunk_pos, out var found_chunk)) {
                    _logger.Error("CHUNK NOT FOUND, {x}, {y}",chunk_pos.X,chunk_pos.Y);
                }

                _logger.Information("CHUNK FOUND, {x}, {y}",chunk_pos.X,chunk_pos.Y);
                _logger.Information("2d camera_view coord, {x}, {y}",i, j);
                camera_view[i, j] = found_chunk;
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
                        var color = AnsiCodes.RGBForegroundColor(
                            camera_view[n_row, n_col]?.debug_console_color ?? ByteVector3.Max
                        );
                        var text =  $"{color}({n_chunk_row},{n_chunk_col}){AnsiCodes.ResetGraphicsModes} ";
                        Console.Out.Write($"{text}");
                    }
                    // Console.Out.Write("| ");
                }
                Console.Out.Write(Environment.NewLine);
                
            }
            // Console.Out.Write(new string('-', (3 * chunk_max_size * 2)+rowLength+2));
            // Console.Out.Write(Environment.NewLine);
        }
    }
}