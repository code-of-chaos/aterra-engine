// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------
using System.Resources;

namespace AterraEngine.Interfaces.Engine;
// ---------------------------------------------------------------------------------------------------------------------
// Interface Code
// ---------------------------------------------------------------------------------------------------------------------
public interface IEngineResxManager {
    public string default_resource_location { get;}
    ResourceManager addResourceManager<type_of_project>(string manager_name);
    ResourceManager addDefaultResourceManager<type_of_project>(string manager_name);
    ResourceManager getResourceManager(string manager_name);
}