﻿// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------
namespace AterraEngine.Interfaces.Logic.EngineObjects;
// ---------------------------------------------------------------------------------------------------------------------
// Interface Code
// ---------------------------------------------------------------------------------------------------------------------
public interface IItem:IEngineObject {
    float weight { get; init; }
    string? internal_name { get; init; }
    
}