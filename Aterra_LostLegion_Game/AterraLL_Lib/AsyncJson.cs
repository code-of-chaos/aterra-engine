// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------

using System.Text.Json;

namespace AterraLL_Lib;

// ---------------------------------------------------------------------------------------------------------------------
// Code
// ---------------------------------------------------------------------------------------------------------------------
public static class AsyncJson {
    public static async Task<T?> LoadJsonAsync<T>(string filepath) {
        // Because this function is written as a "use for any json file",
        //  we can't know beforehand what object data will be
        T? data;
        
        try {
            await using var fs = File.OpenRead(filepath);
            data = await JsonSerializer.DeserializeAsync<T>(fs);
        }
        
        catch (Exception ex) {
            Console.WriteLine(ex);
            data = default(T);
        }

        return data;
    } 
}