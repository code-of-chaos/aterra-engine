// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------

using AterraEngine.Interfaces.Structs;

namespace AterraEngine.Structs; 
// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------
public readonly struct LinkToLevel : ILinkToLevel{
    public IAterraEngineId target_level { get; init; }
    public IPosition2D target_chunk { get; init; }
    public IPosition2D target_tile { get; init; }
    
    public override string ToString() {
        return $"LinkToLevel(target_level : {target_level}, target_chunk : {target_chunk}, target_tile : {target_tile})";
    }
    
}