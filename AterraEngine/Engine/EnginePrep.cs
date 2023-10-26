// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------
using System.Reflection;
using AterraEngine.Interfaces.Engine;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace AterraEngine.Engine;
// ---------------------------------------------------------------------------------------------------------------------
// Code
// ---------------------------------------------------------------------------------------------------------------------
public class EnginePrep : IEnginePrep {
    public Dictionary<int, string> load_order { get; private set; } = new();
    private readonly IServiceCollection _serviceCollection = new ServiceCollection();

    // -----------------------------------------------------------------------------------------------------------------
    // Load Order Methods
    // -----------------------------------------------------------------------------------------------------------------
    public void registerLoadOrderFromJson(string json_filepath) {
        string json = File.ReadAllText(json_filepath);
        EnginePrepData engineData = JsonConvert.DeserializeObject<EnginePrepData>(json)
            ?? throw new FileLoadException($"Load order could not be extracted from file : '{json_filepath}'");
        load_order = engineData.load_order.ToDictionary(
            pair => int.Parse(pair.Key), 
            pair => pair.Value
            );
    }

    public void registerLoadOrderFromArray(string[] assembly_locations) {
        for (int i = 0; i < assembly_locations.Length; i++) {
            load_order.Add(i, assembly_locations[i]);
        }
    }
    
    // -----------------------------------------------------------------------------------------------------------------
    // Prep logic (not really meant to be use individually, but you can)
    // -----------------------------------------------------------------------------------------------------------------
    internal IEnginePlugin[] loadPluginServices() {
        return load_order
            // Sort the dictionary by the int key 
            .OrderBy(pair => pair.Key)
            .Select(pair => pair.Value)
            // Go over the list and load them as assemblies
            .Select(Assembly.LoadFrom)
            // Go over the assemblies and extract Plugins
            .SelectMany(assembly => assembly
                .GetTypes()
                .Where(type => typeof(IEnginePlugin).IsAssignableFrom(type) 
                               && !type.IsInterface 
                               && !type.IsAbstract
                )
                .Select(pluginType => {
                    IEnginePlugin plugin = (IEnginePlugin)Activator.CreateInstance(pluginType)!;
                    // Add (and possible overwrite) services to the service collection
                    plugin.defineEngineServices(_serviceCollection);
                    return plugin;
                })
            ).ToArray()
        ;
    }
    
    // -----------------------------------------------------------------------------------------------------------------
    // Main Method
    // -----------------------------------------------------------------------------------------------------------------
    public IEnginePlugin[] prepareEngine() {
        if (load_order.Count == 0) {
            throw new Exception("Engine wasn't prepared with any data. Please add Plugins to the load order");
        }
        // These two have to be added before anything else
        //      Assigns logging and the Engine
        _serviceCollection.AddLogging(builder => { builder.AddConsole(); }); 
        _serviceCollection.AddSingleton<IEngine, Engine>();
        
        // preparation of the Engine starts with (IN ORDER):
        //      - Load the plugins
        //      - load the DI Service mappings from those plugins in correct load order
        //      - Build the DI Service provider
        IEnginePlugin[] engine_plugins = loadPluginServices();
        foreach (var plugin in engine_plugins) plugin.defineEngineServices(_serviceCollection);
        
        EngineServices.buildServiceProvider(_serviceCollection);
        
        // Store the Plugins to the Engine, might be useful to something or someone
        IEngine engine = EngineServices.getEngine();
        engine.addPlugins(engine_plugins);

        // After Preparation of the Engine (IN ORDER, but as two separate steps):
        //      - Register the RESX resources
        //      - Register logic from plugins
        foreach (var plugin in engine_plugins) plugin.defineResx();
        foreach (var plugin in engine_plugins) plugin.defineLogic();
        
        // Engine has been loaded 
        //      - Start the main loop
        //      - Let the chaos win!
        return engine_plugins;
    }
}