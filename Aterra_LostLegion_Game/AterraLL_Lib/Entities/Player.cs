﻿namespace AterraLL_Lib.Entities;
// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------

// ---------------------------------------------------------------------------------------------------------------------
// Code
// ---------------------------------------------------------------------------------------------------------------------
public class Player : Entity
{
    public Player() : base(i_size:100, hp:100f, e_type:EntityType.player, printable:" P ") { }
}