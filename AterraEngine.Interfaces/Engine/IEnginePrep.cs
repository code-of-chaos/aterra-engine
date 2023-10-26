// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------

using Microsoft.Extensions.DependencyInjection;

namespace AterraEngine.Interfaces.Engine;

// ---------------------------------------------------------------------------------------------------------------------
// Code
// ---------------------------------------------------------------------------------------------------------------------
public interface IEnginePrep {
    public Dictionary<int, string> load_order { get;}
    
    // -----------------------------------------------------------------------------------------------------------------
    // Methods
    // -----------------------------------------------------------------------------------------------------------------
    public void loadDataFromEnginePrepJson(string json_filepath);
    public void registerLoadOrderFromJson(string json_filepath);
    public void registerLoadOrderFromArray(string[] assembly_locations);
    
    // Main Method
    public IEnginePlugin[] prepareEngine();
}