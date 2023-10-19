// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------
using System.Globalization;

namespace AterraEngine.Lib;
// ---------------------------------------------------------------------------------------------------------------------
// Code
// ---------------------------------------------------------------------------------------------------------------------
public static class IdConverter {
    public static int toInt(string id_string) => int.Parse(id_string[2..], NumberStyles.HexNumber);
    public static string toString(int id_string) => id_string.ToString("X");
    public static string toHex(int id_value) => "0x" + id_value.ToString("X");
    public static string toHex(int id_value, int padding) => "0x" + id_value.ToString($"X{padding}");
}