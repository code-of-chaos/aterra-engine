// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------

using System.Text.Json;

namespace AterraEngine.Lib;

// ---------------------------------------------------------------------------------------------------------------------
// Code
// ---------------------------------------------------------------------------------------------------------------------
public static class AsyncJson {
    public static async Task<T?> LoadJsonAsync<T>(string filepath) {
        // Because this function is written as a "use for any json file",
        //  we can't know beforehand what object data will be
        T? data;

        await using var fs = File.OpenRead(filepath);
        data = await JsonSerializer.DeserializeAsync<T>(fs);

        return data;
    }
}