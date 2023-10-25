// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------
using Microsoft.Extensions.Logging;

namespace AterraEngine.Interfaces.Logic.EngineObjects;

// ---------------------------------------------------------------------------------------------------------------------
// Interface Code
// ---------------------------------------------------------------------------------------------------------------------
public interface IEngineObjectManager {
    IReadOnlyDictionary<int, IEngineObject> engine_objects { get; }
    
    int getUniqueId();
    
    T[] getAllByType<T>();
    void importFromManager(IEngineObjectManager manager);
    public T createNewObject<T>(Func<int, ILogger<IEngineObjectManager>,  string, T> callback_func, int? id = null, string? resource_location = null) where T : IEngineObject, new();
    public T saveNewObject<T>(T engine_object) where T : IEngineObject, new();

    IEngineObject? getById(string hex_id);
    IEngineObject? getById(int id);

}