// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------
using System.Resources;
using AterraEngine.Lib.Exceptions;

namespace AterraEngine.Lib.Localization;
// ---------------------------------------------------------------------------------------------------------------------
// Interface Code
// ---------------------------------------------------------------------------------------------------------------------
public interface IResxManager {
    ResourceManager addResourceManager<type_of_project>(string manager_name);
    ResourceManager getResourceManager(string manager_name);
    ResourceManager getResourceManagerAlways<type_of_project>(string manager_name);
}

// ---------------------------------------------------------------------------------------------------------------------
// Code
// ---------------------------------------------------------------------------------------------------------------------
public class ResxManager : IResxManager {
    private readonly Dictionary<string, ResourceManager> _resourceManagers = new();
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
    
    public ResourceManager getResourceManager(string manager_name) {
        if (!_resourceManagers.TryGetValue(manager_name, out var manager)) {
            throw new ResourceManagerNotFoundException($"Manager was never assigned '{manager_name}'");
        }
        return manager;
    }

    public ResourceManager getResourceManagerAlways<type_of_project>(string manager_name) {
        ResourceManager resource_manager;
        
        // Make use of the getResourceManager method
        //  This way we don't write code twice
        try {
            resource_manager = getResourceManager(manager_name);
        }
        catch (ResourceManagerNotFoundException) {
            resource_manager =  addResourceManager<type_of_project>(manager_name);
        }
        
        return resource_manager;
    }
}