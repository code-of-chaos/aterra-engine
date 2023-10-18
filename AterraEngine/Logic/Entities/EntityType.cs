// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------
namespace AterraEngine.Logic.Entities;
// ---------------------------------------------------------------------------------------------------------------------
// Code
// ---------------------------------------------------------------------------------------------------------------------
public enum EntityType {// Use Binary flags for this, as this will be VERY limited
    area =          0b0000000000000000001, // zone/worldmap/...
    material =      0b0000000000000000010, // items like coal, wood, hilt, ... 
    armor =         0b0000000000000000100, // a creature can wear these
    tool =          0b0000000000000001000, // a creature can use these. These also contain weapons
    potion =        0b0000000000000010000, // applies effects (buffs or nerfs) to a creature 
    npc =           0b0000000000000100000, // a creature which is not the player
    ability =       0b0000000000001000000, // actions a creature can use (magical spells/moving boulders/...)
    faction =       0b0000000000010000000, // factions to divide creatures into
    container =     0b0000000000100000000, // a object that can hold items
    objective =     0b0000000001000000000, // an objective to a quest
    quest =         0b0000000010000000000, // a quest 
    tile =          0b0000000100000000000, // a tile on the area
    player =        0b0000001000000000000, // a creature controlled by the player
    creature =      0b0000010000000000000, // a creature is an entity which can move around through logic
    dialogue =      0b0000100000000000000, // a dialogue is a component of a conversation
    conversation =  0b0001000000000000000, // a conversation is a tree of dialogues
    stat =          0b0010000000000000000, // a trackable value for a creature
    position =      0b0100000000000000000, // a position in an area
    effect =        0b1000000000000000000, // a position in an area
}