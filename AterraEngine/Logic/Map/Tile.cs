// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------
namespace AterraEngine.Logic.Map;
// ---------------------------------------------------------------------------------------------------------------------
// Code
// ---------------------------------------------------------------------------------------------------------------------
public record Tile(string name, string printableText, bool isWalkable) {
    //
    // [StringLength(3, ErrorMessage = "PrintableText has to be a length of 3 to currently make sense")]
    // public string printableText { get;} = null!;

    public override string ToString() {
        return $"Tile-{name}";
    }
}