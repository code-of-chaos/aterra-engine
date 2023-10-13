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

namespace LostLegion; 

// ---------------------------------------------------------------------------------------------------------------------
// Code
// ---------------------------------------------------------------------------------------------------------------------
internal static class Program {
    private static async Task Main() {

        TranslationTableXML translationTableXml = new TranslationTableXML("data/local");
        translationTableXml.defineTranslationTable(CultureCode.en_US);

        var text = translationTableXml.getTranslation("greeting");
        Console.Out.WriteLine(text);
        
        return;
        
        Console.OutputEncoding = Encoding.Unicode;
        
        await Task.Run(AsyncMain).ConfigureAwait(false);
    }

    private static async Task AsyncMain() {
        
        // Load all item type
        await Task.WhenAll(
            ItemInternalDictionary.loadFromJson<Item>("data/item_dictionary/armor.json"),
            ItemInternalDictionary.loadFromJson<Item>("data/item_dictionary/items.json"),
            ItemInternalDictionary.loadFromJson<Item>("data/item_dictionary/potions.json"),
            ItemInternalDictionary.loadFromJson<ItemWeapon>("data/item_dictionary/weapons.json")
        );

        await Console.Out.WriteLineAsync($"{string.Join(",", ItemInternalDictionary.getAllItemIds()) }");

        var item = ItemInternalDictionary.getItemById("SwordOfJustice");
        await Console.Out.WriteLineAsync($"{item}");


        var game = new Game();
        await game.start();

    }
}