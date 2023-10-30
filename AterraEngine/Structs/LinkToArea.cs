// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------

using AterraEngine.Interfaces.Structs;

namespace AterraEngine.Structs; 
// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------
public struct LinkToArea : ILinkToArea{
    public IAterraEngineId target_area { get; init; }
    public IPosition2D target_tile_pos { get; init; }

    public override string ToString() {
        return $"LinkToArea(target_area : {target_area}, target_tile_pos : {target_tile_pos})";
    }
}