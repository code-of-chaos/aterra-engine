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

    public void addToAreaDictionary(string areaName, Area area) {
        if (area_dictionary.ContainsKey(areaName)) {
            throw new Exception($"The areaName of '{areaName}' is already in use.");
        }
        
        area_dictionary.Add(areaName, area);
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
            overworld_id: Path.GetFileNameWithoutExtension(overworld_file)
        );
        
        // We can group all the tasks together, to take advantage of async behaviour
        var areas = await Task.WhenAll(
        area_files.Select(async filepath => {
                var area = await Area.createFromJsonAsync(filepath);
                return (Path.GetFileNameWithoutExtension(filepath), area);
            })
            .ToArray()
        );

        foreach (var (areaName, area) in areas) {
            if (area is null) {
                throw new Exception("Area is undefined ");
            }
            area_manager.addToAreaDictionary(areaName, area);
        }
        
        return area_manager;
    }
}