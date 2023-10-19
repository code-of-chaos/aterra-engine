// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------
using System.Resources;
using AterraEngine.Logic.Items;
using AterraEngine.Lib;
using AterraEngine.Lib.Localization;
using Microsoft.Extensions.DependencyInjection;

namespace AterraEngine;
// ---------------------------------------------------------------------------------------------------------------------
// Interface Code
// ---------------------------------------------------------------------------------------------------------------------
public interface IEngine {
    void validateSetup(IEnumerable<string> localization_files_var);
    void startGameLoop();
    void renderUI();
}

// ---------------------------------------------------------------------------------------------------------------------
// Code
// ---------------------------------------------------------------------------------------------------------------------
public class Engine : IEngine {
    // All of these are just for easy use within the "Engine" class
    //      Todo think about implementing them (again, this was the old way) as variables? 
    private static IEngineFlags _engine_flags => DependencyContainer.getService<IEngineFlags>();
    private static ICultureManager _localization_system => DependencyContainer.getService<ICultureManager>();
    private static IResxManager _resx_manager => DependencyContainer.getService<IResxManager>();
    private static IItemManager _item_manager => DependencyContainer.getService<IItemManager>();

    // -----------------------------------------------------------------------------------------------------------------
    // Constructor
    // -----------------------------------------------------------------------------------------------------------------
    
    // -----------------------------------------------------------------------------------------------------------------
    // setup
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
    public void startGameLoop(){}
    
    // |
    // V

    // UI +  Renderer (print to console)
    public void renderUI(){}
    
    // |
    // V
}