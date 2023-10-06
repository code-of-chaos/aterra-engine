// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------

namespace AterraLL_Lib;

// ---------------------------------------------------------------------------------------------------------------------
// Code
// ---------------------------------------------------------------------------------------------------------------------
public class POI {
    private bool local; // defines if the POI opens up a new map or not. Local == true -> no sub map
    private bool connected_map_if_not_local;
}

public class Area {
    private int tile_map; // 2d array?
    private int poi_list; // dictionary of coordinates with Points of interests added to them
}

public class World {
    // TODO a way to create the world space
    // TODO a way to spawn a player in the world
    // todo a way to move the player inside of the world
    // todo a way to generate terrain?
    
    // Load area
    
}