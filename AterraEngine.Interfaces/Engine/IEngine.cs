// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------

using System.Collections.ObjectModel;

namespace AterraEngine.Interfaces.Engine;
// ---------------------------------------------------------------------------------------------------------------------
// Interface Code
// ---------------------------------------------------------------------------------------------------------------------
public interface IEngine {
    public ReadOnlyCollection<IEnginePlugin> plugins { get; }
    
    void addPlugins(IEnginePlugin[] plugin_list);
    void startGameLoop();
    void renderUI();
}
