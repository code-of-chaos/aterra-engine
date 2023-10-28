// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------
using System.Collections.ObjectModel;
using AterraEngine.Lib.Structs;

namespace AterraEngine.Interfaces.Logic.EngineObjectManager.EngineObjects;
// ---------------------------------------------------------------------------------------------------------------------
// Interface Code
// ---------------------------------------------------------------------------------------------------------------------
public interface IFaction:IEngineObject {
    string? name { get; set; }
    ReadOnlyDictionary<AterraEngineId,IEngineObject> entities { get; }

    bool tryAddEngineObject(IEngineObject entity);
    bool tryRemoveEngineObject(IEngineObject engine_object);
}