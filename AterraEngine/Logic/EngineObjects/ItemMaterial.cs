// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------

using AterraEngine.Interfaces.Logic.EngineObjects;
using Microsoft.Extensions.Logging;

namespace AterraEngine.Logic.EngineObjects;

// ---------------------------------------------------------------------------------------------------------------------
// Code
// ---------------------------------------------------------------------------------------------------------------------
public class ItemMaterial: Item, IItemMaterial {
    public ItemMaterial(int id, ILogger<IEngineObject> logger) : base(id, logger) { }
}