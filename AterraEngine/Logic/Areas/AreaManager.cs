// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------
using System.Data;
using AterraEngine.Lib;

namespace AterraEngine.Logic.Areas;
// ---------------------------------------------------------------------------------------------------------------------
// Interface Code
// ---------------------------------------------------------------------------------------------------------------------
public interface IAreaManager {
    IReadOnlyDictionary<int, Area> availableAreas { get; }
}

// ---------------------------------------------------------------------------------------------------------------------
// Code
// ---------------------------------------------------------------------------------------------------------------------
public class AreaManager :XmlHandler<Area>, IAreaManager {
    private readonly Dictionary<int, Area> _availableAreas = new ();
    public IReadOnlyDictionary<int, Area> availableAreas => _availableAreas.AsReadOnly();
    
    // -----------------------------------------------------------------------------------------------------------------
    // XML converter
    // -----------------------------------------------------------------------------------------------------------------
    public new void exportXmlFolder(List<Area> objects_to_export, string folder_path) {
        _exportXmlFolder(objects_to_export, folder_path, (item) => $"{item.areaId}.xml");
    }
    public new void importXmlFolder(string folder_path) {
        foreach (var area in  _importXmlFolder(folder_path:folder_path)) {
            if (!_availableAreas.TryAdd(area.areaId, area)) {
                throw new DuplicateNameException($"Item id '{area.areaId}' was already added");
            }
        }
    }
}