// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------
using System;
using System.IO;
using System.Linq;
namespace AterraLL_Lib.Map;

// ---------------------------------------------------------------------------------------------------------------------
// Code
// ---------------------------------------------------------------------------------------------------------------------
public class AreaManager {
    public Area overworld;
    private readonly string[] area_files;
    
    public AreaManager(string[] area_files, Area overworld) {
        this.area_files = area_files;
        this.overworld = overworld;
    }

    public static async Task<AreaManager> createAreaManagerAsync(string overworld_file) {
        var area_files = Directory.GetFiles("data/area", "*.json");
        if (!area_files.Contains(overworld_file)) {
            throw new Exception($"The Overworld file was not found");
        }

        AreaManager area_manager = new AreaManager(
            area_files: area_files,
            overworld: await Area.createFromJsonAsync(overworld_file));
        
        return area_manager;
    }
}