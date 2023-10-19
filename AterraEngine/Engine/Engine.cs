// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------
using System.Resources;
using AterraEngine.Lib.Localization;

namespace AterraEngine.Engine;
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

    // -----------------------------------------------------------------------------------------------------------------
    // Constructor
    // -----------------------------------------------------------------------------------------------------------------
    
    // -----------------------------------------------------------------------------------------------------------------
    // setup
    // -----------------------------------------------------------------------------------------------------------------
    public void validateSetup(IEnumerable<string> localization_files_var) {
        if (EngineServices.getEF().isDebug)
            // Checks if all the resource files have all the expected cultures
            foreach (var resx_file in localization_files_var) {
                ResourceManager resource_manager = EngineServices.getRESXM().getResourceManager(resx_file);
                EngineServices.getCM().checkResourceForCultures(resource_manager);
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