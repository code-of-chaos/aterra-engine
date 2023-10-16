// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------
using System.Resources;
using AterraEngine.Logic.Items;
using AterraEngine.Lib;
using AterraEngine.Lib.Localization;

namespace AterraEngine;
// ---------------------------------------------------------------------------------------------------------------------
// Interface Code
// ---------------------------------------------------------------------------------------------------------------------
public interface IEngine {
    public void validateSetup(IEnumerable<string> localization_files_var);
}

// ---------------------------------------------------------------------------------------------------------------------
// Code
// ---------------------------------------------------------------------------------------------------------------------
public class Engine : IEngine {
    // All of these are just for easy use within the "Engine" class
    //      Todo think about implementing them (again, this was the old way) as variables? 
    private IEngineFlags _engine_flags => DependencyContainer.instance.resolve<IEngineFlags>();
    private ICultureManager _localization_system => DependencyContainer.instance.resolve<ICultureManager>();
    private IResxManager _resx_manager => DependencyContainer.instance.resolve<IResxManager>();
    private IItemManager _item_manager => DependencyContainer.instance.resolve<IItemManager>();

    // -----------------------------------------------------------------------------------------------------------------
    // Constructor
    // -----------------------------------------------------------------------------------------------------------------
    
    // -----------------------------------------------------------------------------------------------------------------
    // Check setup
    // -----------------------------------------------------------------------------------------------------------------
    public void validateSetup(IEnumerable<string> localization_files_var) {
        if (_engine_flags.isDebug)
            // Checks if all the resource files have all the expected cultures
            foreach (var resx_file in localization_files_var) {
                ResourceManager resource_manager = _resx_manager.getResourceManager(resx_file);
                _localization_system.checkResourceForCultures(resource_manager);
            }
    }

    // -----------------------------------------------------------------------------------------------------------------
    // Sections fo the engine
    // -----------------------------------------------------------------------------------------------------------------

    // Game Loop

    // |
    // V

    // UI +  Renderer (print to console)

    // |
    // V
}