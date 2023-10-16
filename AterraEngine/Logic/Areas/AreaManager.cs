﻿// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------
using System.Xml.Serialization;
using AterraEngine.Lib;
using AterraEngine.Lib.Localization;

namespace AterraEngine.Logic.Areas;

// ---------------------------------------------------------------------------------------------------------------------
// Interface Code
// ---------------------------------------------------------------------------------------------------------------------
public interface IAreaManager {
    
}

// ---------------------------------------------------------------------------------------------------------------------
// Code
// ---------------------------------------------------------------------------------------------------------------------
public class AreaManager :XmlHandler<Area>, IAreaManager {
    
    // -----------------------------------------------------------------------------------------------------------------
    // XML converter
    // -----------------------------------------------------------------------------------------------------------------
    public new void exportXmlFolder(List<Area> objects_to_export, string folder_path) {
        _exportXmlFolder(objects_to_export, folder_path, (item) => $"{item.areaId}.xml");
    }
}