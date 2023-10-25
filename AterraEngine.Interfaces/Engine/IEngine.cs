// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------
namespace AterraEngine.Interfaces.Engine;
// ---------------------------------------------------------------------------------------------------------------------
// Interface Code
// ---------------------------------------------------------------------------------------------------------------------
public interface IEngine {
    void validateSetup(IEnumerable<string> localization_files_var);

    void registerPluginFromAssemblies(string[] assembly_locations);
    
    void startGameLoop();
    void renderUI();
}
