// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------

using System.Diagnostics;
using System.Resources;
using AterraEngine;
using AterraEngine.Items;
using AterraEngine.Lib;
using LostLegion.data.enigne.local;

namespace LostLegion;

// ---------------------------------------------------------------------------------------------------------------------
// Code
// ---------------------------------------------------------------------------------------------------------------------
internal class Program {
    private static async Task Main() {
        // Create the engine
        var engine = new Engine(
            new EngineFlags(
                true
            )
        );

        // Add data to the engine
        engine.localization_system.addCulture("la");

        // Let the engine check the data
        engine.validateSetup<Program>(
            new List<string> { "LostLegion.data.engine.local.UniversalText" }
        );

        Console.Out.WriteLine(UniversalText.txt_hello);
        
        engine.localization_system.activateCulture("la");
        
        Console.Out.WriteLine(UniversalText.txt_hello);


        ItemManager item_manager = new ItemManager();
        item_manager.importXmlFolder("data/engine/items",cultureLocalizationSystem:engine.localization_system);
        
        
        

        Item test_item = item_manager.getItemById(0xF)!;
        
        
        Console.Out.WriteLine(test_item);
        Console.Out.WriteLine(test_item.name);
        Console.Out.WriteLine(test_item.description);

        foreach (var (key, item) in item_manager.availableItems) {
            Console.Out.Write(IdConverter.toHex(key, 6));
            Console.Out.Write(" ");
            Console.Out.Write(item);
            Console.Out.Write(item.name);
            Console.Out.Write(item.description);
            Console.Out.Write("\n");
        }
        
        
        

        // Execute the game loop
    
        // return;
        // await Task.Run(AsyncMain).ConfigureAwait(false);
    }

    private static async Task AsyncMain() {
        var game = new Game();
        await game.start();
    }
}