// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------
using AterraEngine.Engine;
using AterraEngine.Lib;
using Microsoft.Extensions.Logging;

using AterraEngine.Interfaces.Logic.EngineObjects;

namespace AterraEngine.Logic.EngineObjects;
// ---------------------------------------------------------------------------------------------------------------------
// Code
// ---------------------------------------------------------------------------------------------------------------------
public class EngineObject : IEngineObject {
    public string hex_id => IdConverter.toHex(id, EngineServices.getED().hex_padding);
    public int id { get; init; }
    public ILogger<IEngineObjectManager> logger { private get; init;} = null!;
    public string resource_location { get; init; } = null!;
}