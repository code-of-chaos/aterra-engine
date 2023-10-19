// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------
using AterraEngine.Engine;
using AterraEngine.Lib;
using Microsoft.Extensions.Logging;

namespace AterraEngine.Logic.EngineObjects;
// ---------------------------------------------------------------------------------------------------------------------
// Interface Code
// ---------------------------------------------------------------------------------------------------------------------
public interface IEngineObject {
    string? hex_id { get;}
    int id { get; init; }
    ILogger<EngineObjectManager> logger { init;}
}
// ---------------------------------------------------------------------------------------------------------------------
// Code
// ---------------------------------------------------------------------------------------------------------------------
public class EngineObject : IEngineObject {
    public string hex_id => IdConverter.toHex(id, EngineServices.getED().hex_padding);
    public int id { get; init; }
    public ILogger<EngineObjectManager> logger { private get; init;} = null!;
}