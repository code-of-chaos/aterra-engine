// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------

using AterraEngine.Interfaces.Logic.EngineObjects;
using Microsoft.Extensions.Logging;

namespace AterraEngine.Logic.EngineObjects;

// ---------------------------------------------------------------------------------------------------------------------
// Code
// ---------------------------------------------------------------------------------------------------------------------
public class Item: EngineObject, IItem {
    public float weight { get; init; }
    public string? internal_name { get; init; }
    public Item(int id, ILogger<IEngineObject> logger) : base(id, logger) { }
}