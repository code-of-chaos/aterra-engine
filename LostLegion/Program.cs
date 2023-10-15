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
using AterraEngine.Lib.Local;

using System;
using System.Globalization;
using System.Resources;
using LostLegion.data.local;

namespace LostLegion; 

// ---------------------------------------------------------------------------------------------------------------------
// Code
// ---------------------------------------------------------------------------------------------------------------------
internal static class Program {
    private static async Task Main() {

        // TranslationTableXML translationTableXml = new TranslationTableXML("data/local");
        // translationTableXml.defineTranslationTable(CultureCode.en_US);
        //
        // var text = translationTableXml.getTranslation("greeting");
        // Console.Out.WriteLine(text);

        // CultureInfo culture = new CultureInfo("en-US");
        // CultureInfo.DefaultThreadCurrentCulture = culture;
        // CultureInfo.DefaultThreadCurrentUICulture = culture;
        
        // return;
        Console.OutputEncoding = Encoding.Unicode;
        Console.Out.WriteLine(UniversalText.txt_hello);
        
        CultureInfo culture2 = new CultureInfo("la");
        CultureInfo.CurrentCulture = culture2;
        CultureInfo.CurrentUICulture = culture2;
        
        Console.Out.WriteLine(UniversalText.txt_hello);
        
        await Task.Run(AsyncMain).ConfigureAwait(false);
    }

    private static async Task AsyncMain() {
        var game = new Game();
        await game.start();
    }
}