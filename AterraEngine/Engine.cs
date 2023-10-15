// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------

using AterraEngine.Lib;

namespace AterraEngine;

// ---------------------------------------------------------------------------------------------------------------------
// Code
// ---------------------------------------------------------------------------------------------------------------------
public class Engine {
    // -----------------------------------------------------------------------------------------------------------------
    // Constructor
    // -----------------------------------------------------------------------------------------------------------------
    public Engine(EngineFlags engine_flags) {
        this.engine_flags = engine_flags;
        localization_system = new CultureLocalizationSystem();
    }

    public EngineFlags engine_flags { get; }
    public CultureLocalizationSystem localization_system { get; }

    // -----------------------------------------------------------------------------------------------------------------
    // Check setup
    // -----------------------------------------------------------------------------------------------------------------
    public void validateSetup<type_of_project>(List<string> localization_files_var) {
        if (engine_flags.isDebug)
            // Checks if all the resource files have all the expected cultures
            localization_system.checkResourceFilesForCultures<type_of_project>(localization_files_var);
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