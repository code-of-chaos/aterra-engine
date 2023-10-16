// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------

using System.Diagnostics;
using System.Resources;
using AterraEngine;
using AterraEngine.Lib;
using AterraEngine.Lib.Localization;
using AterraEngine.Logic.Items;
using LostLegion.data.enigne.local;
using Microsoft.Extensions.DependencyInjection;

namespace LostLegion;

// ---------------------------------------------------------------------------------------------------------------------
// Code
// ---------------------------------------------------------------------------------------------------------------------
internal class Program {
    // This should work, but .... 
    // public ServiceProvider ConfigureServices() {
    //     ServiceProvider service_provider = new ServiceCollection()
    //         // assign injections    
    //         .AddSingleton<IItemManager, ItemManager>()
    //         .AddSingleton<IEngine, Engine>()
    //         .AddSingleton<IEngineFlags, EngineFlags>()
    //         .AddSingleton<ICultureManager, CultureManager>()
    //         .AddSingleton<IResxManager, ResxManager>()
    //         
    //         // actually build the provider
    //         .BuildServiceProvider();
    //     return service_provider;
    // }
    
    private static async Task Main() {
        // Register all managers to DIC
        DependencyContainer.instance.register<IItemManager, ItemManager>();
        DependencyContainer.instance.register<IEngine, Engine>();
        DependencyContainer.instance.register<IEngineFlags, EngineFlags>();
        DependencyContainer.instance.register<ICultureManager, CultureManager>();
        DependencyContainer.instance.register<IResxManager, ResxManager>();
        
        // Set the Engine flags
        IEngineFlags engine_flags = DependencyContainer.instance.resolve<IEngineFlags>();
        engine_flags.isDebug = true;
        
        // Add Resource files to the engine
        IResxManager resx_manager = DependencyContainer.instance.resolve<IResxManager>();
        string[] resx_files = new[] {
            "LostLegion.data.engine.local.UniversalText"
        };
        foreach (var resx_file in resx_files) {
            resx_manager.addResourceManager<Program>(resx_file);
        }
        
        // Add data to the engine
        ICultureManager culture_manager = DependencyContainer.instance.resolve<ICultureManager>();
        culture_manager.addCulture("la");
        
        // Enter the engine and start running checks
        IEngine engine = DependencyContainer.instance.resolve<IEngine>();
        engine.validateSetup(resx_files);
        
        engine.item_manager.importXmlFolder("data/engine/items");

        Item[] filtered = engine.item_manager.filterByType(ItemType.general);
        Console.Out.WriteLine(string.Join("\n", filtered.ToList()));

        // Execute the game loop

        // return;
        // await Task.Run(AsyncMain).ConfigureAwait(false);
    }

    private static async Task AsyncMain() {
        var game = new Game();
        await game.start();
    }
}