namespace AterraUnleashedLib;
// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------

// ---------------------------------------------------------------------------------------------------------------------
// Code
// ---------------------------------------------------------------------------------------------------------------------
public class Game {
    public Player player = new Player();

    public void start() {
        // create world
        
        // spawn player
        
        // start loop
        try {
            bool game_alive = true;
            while (game_alive) {
                game_alive = game_tick();
            }
        }
        
        catch (Exception e) {
            Console.WriteLine(e);
            throw;
        }
        
        // handle exit
    }

    private bool game_tick() {
        // ask for player input
        
        // execute player input
        return false;
    }
}