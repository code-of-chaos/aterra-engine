﻿// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------

using AterraEngine.Interfaces.Logic;
using AterraEngine.Interfaces.Logic.EngineObjectManager.ConstructorStructs;
using AterraEngine.Interfaces.Structs;
using AterraEngine.Lib.Structs;

namespace AterraEngine.Logic.EngineObjectManager.ConstructorStructs;

// ---------------------------------------------------------------------------------------------------------------------
// Code
// ---------------------------------------------------------------------------------------------------------------------
public struct CSEntityNPC : ICSEntityNPC {
    public IAterraEngineId? id { get; set; }
    public string? resource_location { get; set; }
    public string? internal_name { get; set; }
    public float? health_max { get; set; }
}   