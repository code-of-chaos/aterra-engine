// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------
using System.Text;
using AterraEngine;
using AterraEngine.Items;
using AterraEngine.Map;
using AterraEngine;
using Area = AterraEngine.Map.Area;

using AterraEngine.Lib;

using System;
using System.Globalization;
using System.Resources;
using LostLegion.data.local;

namespace LostLegion; 

// ---------------------------------------------------------------------------------------------------------------------
// Code
// ---------------------------------------------------------------------------------------------------------------------
internal class Program {
    private static async Task Main() {
        // Create the engine
        Engine engine = new Engine(
            engine_flags: new EngineFlags(
                is_debug: true
            )
        );
        
        // Add data to the engine
        engine.localization_system.addCulture("la");
        
        // Let the engine check the data
        engine.validateSetup<Program>(
            localization_files_var:new List<string>{ "LostLegion.data.local.UniversalText" }
        );
        
        // Execute the game loop
        
        // return;
        await Task.Run(AsyncMain).ConfigureAwait(false);
    }

    private static async Task AsyncMain() {
        var game = new Game();
        await game.start();
    }
}