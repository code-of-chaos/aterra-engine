// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------
using System.Globalization;

namespace AterraEngine.Lib;
// ---------------------------------------------------------------------------------------------------------------------
// Code
// ---------------------------------------------------------------------------------------------------------------------
public static class IdConverter {
    public static int toInt(string id_string)               => int.Parse(id_string.Replace("#",""), NumberStyles.HexNumber);
    public static string toString(int id_string)            => id_string.ToString("X");
    public static string toHex(int id_value)                => id_value.ToString("X");
    public static string toHex(int id_value, int padding)   => id_value.ToString($"X{padding}");
}