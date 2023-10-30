// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------
using System.Resources;
using AterraEngine.Lib.Exceptions;
using AterraEngine.Interfaces.Engine;
using Serilog;

namespace AterraEngine.Engine;
// ---------------------------------------------------------------------------------------------------------------------
// Code
// ---------------------------------------------------------------------------------------------------------------------
public class EngineResxManager : IEngineResxManager {
    public string default_resource_location { get; private set; } = null!;
    private readonly Dictionary<string, ResourceManager> _resourceManagers = new();
    protected ILogger _logger = EngineServices.getLogger();
    
    // -----------------------------------------------------------------------------------------------------------------
    // Constructor
    // -----------------------------------------------------------------------------------------------------------------
    
    // -----------------------------------------------------------------------------------------------------------------
    // Storage of Implemented Resource Managers
    // -----------------------------------------------------------------------------------------------------------------
    public ResourceManager addResourceManager<type_of_project>(string manager_name) {
        ResourceManager resource_manager = new ResourceManager(manager_name, typeof(type_of_project).Assembly);
        _resourceManagers.Add(manager_name, resource_manager);
        return resource_manager;
    }
    public ResourceManager addDefaultResourceManager<type_of_project>(string manager_name) {
        if (default_resource_location is not null) {
            throw new Exception("Default Resource Location already set");
        }
        default_resource_location = manager_name;
        return addResourceManager<type_of_project>(manager_name);
    }
    
    public ResourceManager getResourceManager(string manager_name) {
        if (!_resourceManagers.TryGetValue(manager_name, out var manager)) {
            throw new ResourceManagerNotFoundException($"Manager was never assigned '{manager_name}'");
        }
        return manager;
    }
}