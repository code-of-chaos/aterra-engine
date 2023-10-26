// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------
using AterraEngine.Lib.Structs;

namespace AterraEngine.Lib.Ansi;
// ---------------------------------------------------------------------------------------------------------------------
// Code
// ---------------------------------------------------------------------------------------------------------------------
public static class Ansi {
    // -----------------------------------------------------------------------------------------------------------------
    // Logic
    // -----------------------------------------------------------------------------------------------------------------
    private static ByteVector3 _tryGetColor(string color_name) {
        return !AnsiColors.knownColorsDictionary.TryGetValue(color_name, out var value)
            ? ByteVector3.Max
            : value;
    }
    
    // -----------------------------------------------------------------------------------------------------------------
    // String Logic
    // -----------------------------------------------------------------------------------------------------------------
    public static string Fore(string color_name, string? text) => $"{AnsiCodes.RGBForegroundColor(_tryGetColor(color_name))}{text}{AnsiCodes.ResetGraphicsModes}";
    public static string Back(string color_name, string text) => $"{AnsiCodes.RGBBackgroundColor(_tryGetColor(color_name))}{text}{AnsiCodes.ResetGraphicsModes}";
    public static string Under(string color_name, string text) => $"{AnsiCodes.RGBUnderlineColor(_tryGetColor(color_name))}{text}{AnsiCodes.ResetGraphicsModes}";
}