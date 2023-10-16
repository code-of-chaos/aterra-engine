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
    public IEngineFlags engine_flags { get; }
    public ICultureManager localization_system { get; }
    public IResxManager resx_manager { get; }
    public IItemManager item_manager { get; }

    public void validateSetup(string[] localization_files_var);
}

// ---------------------------------------------------------------------------------------------------------------------
// Code
// ---------------------------------------------------------------------------------------------------------------------
public class Engine : IEngine {
    public IEngineFlags engine_flags { get; } = DependencyContainer.instance.resolve<IEngineFlags>();
    public ICultureManager localization_system { get; } = DependencyContainer.instance.resolve<ICultureManager>();
    public IResxManager resx_manager { get; } = DependencyContainer.instance.resolve<IResxManager>();
    public IItemManager item_manager { get; } = DependencyContainer.instance.resolve<IItemManager>();

    // -----------------------------------------------------------------------------------------------------------------
    // Constructor
    // -----------------------------------------------------------------------------------------------------------------

    // -----------------------------------------------------------------------------------------------------------------
    // Check setup
    // -----------------------------------------------------------------------------------------------------------------
    public void validateSetup(string[] localization_files_var) {
        if (engine_flags.isDebug)
            // Checks if all the resource files have all the expected cultures
            foreach (var resx_file in localization_files_var) {
                ResourceManager resource_manager = resx_manager.getResourceManager(resx_file);
                localization_system.checkResourceForCultures(resource_manager);
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