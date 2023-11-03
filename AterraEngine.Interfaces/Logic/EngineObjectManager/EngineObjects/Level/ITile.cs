// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------
using AterraEngine.Interfaces.Structs;
namespace AterraEngine.Interfaces.Logic.EngineObjectManager.EngineObjects.Level;

// ---------------------------------------------------------------------------------------------------------------------
// Code
// ---------------------------------------------------------------------------------------------------------------------
public interface ITile: IEngineObject {
    bool isWalkable { get; init; }
    bool isPOI { get; init; }
    ILinkToLevel? link_to_level { get; init; }
    
    string console_text { get; init; }
    
}
