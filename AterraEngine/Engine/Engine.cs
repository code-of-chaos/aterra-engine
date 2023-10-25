// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------

using System.Reflection;
using System.Resources;

namespace AterraEngine.Engine;
// ---------------------------------------------------------------------------------------------------------------------
// Interface Code
// ---------------------------------------------------------------------------------------------------------------------
public interface IEngine {
    void validateSetup(IEnumerable<string> localization_files_var);

    void registerPluginFromAssemblies(string[] assembly_locations);
    
    void startGameLoop();
    void renderUI();
}

// ---------------------------------------------------------------------------------------------------------------------
// Code
// ---------------------------------------------------------------------------------------------------------------------
public class Engine : IEngine {
    // -----------------------------------------------------------------------------------------------------------------
    // Constructor
    // -----------------------------------------------------------------------------------------------------------------
    
    // -----------------------------------------------------------------------------------------------------------------
    // setup
    // -----------------------------------------------------------------------------------------------------------------
    public void validateSetup(IEnumerable<string> localization_files_var) {
        IEngineFlags engine_flags = EngineServices.getEF();
        if (engine_flags.isDebug)
            // Checks if all the resource files have all the expected cultures
            foreach (var resx_file in localization_files_var) {
                ResourceManager resource_manager = EngineServices.getRESXM().getResourceManager(resx_file);
                EngineServices.getCM().checkResourceForCultures(resource_manager);
            }
    }

    
    // -----------------------------------------------------------------------------------------------------------------
    // Plugin logic
    // -----------------------------------------------------------------------------------------------------------------
    public void registerPluginFromAssemblies(string[] assembly_locations) {
        foreach (var assembly_location in assembly_locations) {
            Assembly customAssembly = Assembly.LoadFrom(assembly_location);
            _pluginFromAssembly(customAssembly);
        }
    }
    
    private void _pluginFromAssembly(Assembly assembly) {
        // Get classes from the assembly
        //      Only retrieve those who inherit from "IEnginePlugin"

        // var types = assembly.GetTypes();
        // Console.Out.WriteLine(string.Join("\n", types.Select(type => type.ToString())));
        
        var plugins = assembly.GetTypes()
            .Where(type => typeof(IEnginePlugin).IsAssignableFrom(type) 
                           && !type.IsInterface 
                           && !type.IsAbstract
            );
        
        foreach (var pluginType  in plugins) {
            IEnginePlugin plugin = (IEnginePlugin)Activator.CreateInstance(pluginType)!;
            
            // Order of execution is important here!
            plugin.defineResx();
            plugin.main();
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