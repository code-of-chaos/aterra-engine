// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------

using AterraEngine.Interfaces.Logic.EngineObjects;
using Microsoft.Extensions.Logging;

namespace AterraEngine.Logic.EngineObjects;

// ---------------------------------------------------------------------------------------------------------------------
// Code
// ---------------------------------------------------------------------------------------------------------------------
public class ItemPotion: Item, IItemPotion {
    public ItemPotion(int id, ILogger<IEngineObject> logger) : base(id, logger) { }
}