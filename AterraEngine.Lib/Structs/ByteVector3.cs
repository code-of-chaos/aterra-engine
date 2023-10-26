// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------
namespace AterraEngine.Lib.Structs;
// ---------------------------------------------------------------------------------------------------------------------
// Code
// ---------------------------------------------------------------------------------------------------------------------
/// <summary>
/// Represents a three-dimensional vector with byte components.
/// </summary>
public struct ByteVector3 {
    public byte X { get;set;}
    public byte Y { get;set;}
    public byte Z { get;set;}
    // -----------------------------------------------------------------------------------------------------------------
    // Constructor
    // -----------------------------------------------------------------------------------------------------------------
    /// <summary>
    /// Initializes a new instance of the ByteVector3 struct with the specified components.
    /// </summary>
    /// <param name="x">The X component.</param>
    /// <param name="y">The Y component.</param>
    /// <param name="z">The Z component.</param>
    public ByteVector3(byte x, byte y, byte z) {
        X = x;
        Y = y;
        Z = z;
    }
    // -----------------------------------------------------------------------------------------------------------------
    // Instance creators
    // -----------------------------------------------------------------------------------------------------------------
    public static ByteVector3 Zero => new(0, 0, 0);
    public static ByteVector3 Max => new(255, 255, 255);
    // -----------------------------------------------------------------------------------------------------------------
    // Methods
    // -----------------------------------------------------------------------------------------------------------------
    /// <summary>
    /// Converts the ByteVector3 to a byte array.
    /// </summary>
    /// <returns>A byte array containing the X, Y, and Z components, in that order.</returns>
    public byte[] toArray() => new[] { X, Y, Z };
    public string toAnsiString() => $"{X};{Y};{Z}";
}