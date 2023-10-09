// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------
namespace AterraLL_Lib.Map;

// ---------------------------------------------------------------------------------------------------------------------
// Code
// ---------------------------------------------------------------------------------------------------------------------
public class AreaManager {
    private readonly string _overworld_id;
    public Dictionary<string, Area?> area_dictionary { get; }
    private readonly string[] area_files;

    private AreaManager(string[] area_files, string overworld_id) {
        this.area_files = area_files;
        _overworld_id = overworld_id;
        area_dictionary = new Dictionary<string, Area?>();
    }

    public Area getOverworld() {
        // Makes sure the overworld area exists.
        //  If this doesn't exist, then we are in deep shit
        if (!area_dictionary.TryGetValue(_overworld_id, out var overworld) || overworld is null)  {
            throw new Exception("Overworld was not defined");
        }
        return overworld;
    }
    
    private async Task addAreaToDictionaryAsync(string filepath) {
        Area? area = await Area.createFromJsonAsync(filepath);
        area_dictionary.Add(Path.GetFileName(filepath), area);
    }
    
    public static async Task<AreaManager> createAreaManagerAsync(string overworld_file) {
        // Fixes the issue if there are issues with "/" or "\" or "//"
        var area_files = Directory.GetFiles("data/area", "*.json")
            .Select(path => path.Replace('\\', '/'))
            .ToArray();
        if (!area_files.Any(path => path.Equals(overworld_file, StringComparison.OrdinalIgnoreCase))) {
            throw new Exception($"The Overworld file was not found");
        }
        
        // Now that all the files have been found, we can create the overworld file, and start mapping
        var area_manager = new AreaManager(
            area_files: area_files,
            overworld_id: Path.GetFileName(overworld_file)
        );
        
        // We can group all the tasks together, to take advantage of async behaviour
        await Task.WhenAll(
            area_files.Select(async path => await area_manager.addAreaToDictionaryAsync(path))
                .ToArray()
        );
        
        return area_manager;
    }
}