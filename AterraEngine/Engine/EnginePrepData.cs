// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------
using Serilog.Events;

namespace AterraEngine.Engine;
// ---------------------------------------------------------------------------------------------------------------------
// Code
// ---------------------------------------------------------------------------------------------------------------------
public class EnginePrepData {
    public record _Logging {
        public LogEventLevel level { get; init; } = LogEventLevel.Information;
        public string? file { get; init; } = null;
        public bool allow_file_output{ get; init; } = false;
        public bool allow_console_output{ get; init; } = false;
    }
    public _Logging logging  { get; init; } = new();
    public Dictionary<string, string> load_order { get; init; } = new();
}