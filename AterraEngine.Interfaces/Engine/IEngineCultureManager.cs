// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------
using System.Globalization;
using System.Resources;

namespace AterraEngine.Interfaces.Engine;
// ---------------------------------------------------------------------------------------------------------------------
// InterfaceCode
// ---------------------------------------------------------------------------------------------------------------------
public interface IEngineCultureManager {
    void addCulture(string culture_name);
    void activateCulture(string culture_name);
    void activateDefaultCulture();
    void checkResourceForCultures(ResourceManager resource);
    bool isCultureImplemented(ResourceManager resource, string culture_name);
    bool isCultureImplemented(ResourceManager resource, CultureInfo culture);
}