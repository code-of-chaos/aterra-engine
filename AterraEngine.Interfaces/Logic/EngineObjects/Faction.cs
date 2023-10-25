// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------
using System.Collections.ObjectModel;

namespace AterraEngine.Interfaces.Logic.EngineObjects;
// ---------------------------------------------------------------------------------------------------------------------
// Interface Code
// ---------------------------------------------------------------------------------------------------------------------
public interface IFaction:IEngineObject {
    string? name { get; set; }
    ReadOnlyDictionary<int,IEngineObject> entities { get; }

    bool tryAddEngineObject(IEngineObject entity);
    bool tryRemoveEngineObject(IEngineObject engine_object);
}