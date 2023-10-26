// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------
using AterraEngine.Lib.Structs;

namespace AterraEngine.Lib.Ansi;
// ---------------------------------------------------------------------------------------------------------------------
// Code
// ---------------------------------------------------------------------------------------------------------------------
/// <summary>
/// A utility class containing ANSI escape codes for terminal control.
/// </summary>
public static class AnsiEscapeCodes {
    public const string escapeCtrl = "^[";
    public const string escapeOctal = "\033";
    public const string escapeUnicode = "\u001b";
    public const string escapeHexadecimal = "\x1B";
}
