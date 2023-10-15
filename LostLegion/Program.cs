// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------

using AterraEngine;
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

        // Execute the game loop

        // return;
        // await Task.Run(AsyncMain).ConfigureAwait(false);
    }

    private static async Task AsyncMain() {
        var game = new Game();
        await game.start();
    }
}