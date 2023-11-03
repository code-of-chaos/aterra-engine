// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------
using AterraEngine.Interfaces.Structs;
namespace AterraEngine.Interfaces.Logic.EngineObjectManager.ConstructorStructs;
// ---------------------------------------------------------------------------------------------------------------------
// Interface Code
// ---------------------------------------------------------------------------------------------------------------------
public interface ICSTile : ICSEngineObject {
    bool? isWalkable { get; set; }
    bool? isPOI { get; set; }
    ILinkToLevel? link_to_level { get; set; }
    string? console_text { get; set; }
}