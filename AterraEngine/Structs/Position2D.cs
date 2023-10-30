// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------

using AterraEngine.Interfaces.Structs;

namespace AterraEngine.Structs;
// ---------------------------------------------------------------------------------------------------------------------
// Code
// ---------------------------------------------------------------------------------------------------------------------
public struct Position2D:IPosition2D {
    private readonly int _y;
    private readonly int _x;

    public int X {
        readonly get => _x;
        init => _x = _checkLimit(value);
    }

    public int Y {
        readonly get => _y;
        init => _y = _checkLimit(value);
    }

    // -----------------------------------------------------------------------------------------------------------------
    // Constructor
    // -----------------------------------------------------------------------------------------------------------------
    public Position2D(int x, int y) {
        X = x;
        Y = y;
    }
    
    // -----------------------------------------------------------------------------------------------------------------
    // Methods
    // -----------------------------------------------------------------------------------------------------------------
    public override string ToString() {
        return $"Position2D(X: {X}, Y: {Y})";
    }
    
    private static int _checkLimit(int? value) {
        switch (value) {
            case null :
                throw new NullReferenceException(); // todo write text + logging
            case < 0:
                throw new FormatException();
        }

        return (int)value;
    }

}