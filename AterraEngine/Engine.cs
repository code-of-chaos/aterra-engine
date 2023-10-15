// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------

using AterraEngine.Lib;

namespace AterraEngine;

// ---------------------------------------------------------------------------------------------------------------------
// Code
// ---------------------------------------------------------------------------------------------------------------------
public class Engine {
    public EngineFlags engine_flags { get; private set; }
    public CultureLocalizationSystem localization_system { get; private set; }
    
    // -----------------------------------------------------------------------------------------------------------------
    // Constructor
    // -----------------------------------------------------------------------------------------------------------------
    public Engine(EngineFlags engine_flags) {
        this.engine_flags = engine_flags;
        this.localization_system = new CultureLocalizationSystem();
    }
    
    // -----------------------------------------------------------------------------------------------------------------
    // Check setup
    // -----------------------------------------------------------------------------------------------------------------
    public void validateSetup<type_of_project>(List<string> localization_files_var) {
        if (engine_flags.isDebug) {
            // Checks if all the resource files have all the expected cultures
            localization_system.checkResourceFilesForCultures<type_of_project>(localization_files_var);
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