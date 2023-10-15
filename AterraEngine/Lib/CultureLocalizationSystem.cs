// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------

using System.Globalization;
using System.Resources;

namespace AterraEngine.Lib;

// ---------------------------------------------------------------------------------------------------------------------
// Code
// ---------------------------------------------------------------------------------------------------------------------
public class CultureLocalizationSystem {
    private readonly Dictionary<string, CultureInfo> _cultureInfos = new();
    private readonly Dictionary<string, ResourceManager> _resourceManagers = new();
    
    // -----------------------------------------------------------------------------------------------------------------
    // Storage of Implemented Resource Managers
    // -----------------------------------------------------------------------------------------------------------------
    public void addResourceManager(string manager_name, ResourceManager manager) {
        _resourceManagers.Add(manager_name, manager);
    }
    
    public ResourceManager getResourceManager(string manager_name) {
        if (!_resourceManagers.TryGetValue(manager_name, out var manager)) {
            throw new Exception($"Manager was never assigned '{manager_name}'");
        }
        return manager;
    }
    
    // -----------------------------------------------------------------------------------------------------------------
    // Local Culture system
    // -----------------------------------------------------------------------------------------------------------------
    public void addCulture(string culture_name) {
        if (_cultureInfos.TryGetValue(culture_name, out _))
            throw new ArgumentException($"the local of '{culture_name}' is already defined");

        _cultureInfos.Add(culture_name, new CultureInfo(culture_name));
    }

    public void activateCulture(string culture_name) {
        if (!_cultureInfos.TryGetValue(culture_name, out var culture_info))
            throw new ArgumentException($"the local of '{culture_name}' is not defined");

        CultureInfo.CurrentCulture = culture_info;
        CultureInfo.CurrentUICulture = culture_info;
    }

    private CultureInfo getCultureInfo(string culture_name) {
        if (!_cultureInfos.TryGetValue(culture_name, out var culture_info))
            throw new ArgumentException($"the local of '{culture_name}' is not defined");

        return culture_info;
    }

    // -----------------------------------------------------------------------------------------------------------------
    // Check for resx files against the known locals
    // -----------------------------------------------------------------------------------------------------------------
    /// <summary>
    ///     Checks if a collection of resource files are implemented for a set of localization cultures.
    ///     Preferably only used in DEBUG mode, or by the editor.
    /// </summary>
    /// <typeparam name="project_assembly">The type of the project to access its assembly.</typeparam>
    /// <param name="resource_names">
    ///     An array of resource file names to check. Make sure to give the full path, example:
    ///     'LostLegion.data.engine.local.UniversalText'
    /// </param>
    public void checkResourceFilesForCultures<project_assembly>(IEnumerable<string> resource_names) {
        foreach (var res_name in resource_names) {
            var missing_locals = _cultureInfos.Values
                .Where(culture => !isCultureImplemented<project_assembly>(res_name, culture))
                .Select(culture => culture.Name)
                .ToList();

            if (missing_locals.Any())
                throw new CultureNotFoundException(
                    $"Resource '{res_name}' did not have the following Localization Cultures "
                    + $"{string.Join(", ", missing_locals)}"
                );
        }
    }

    public bool isCultureImplemented<type_of_project>(string resource_name, CultureInfo culture) {
        return _isCultureImplemented<type_of_project>(resource_name, culture);
    }

    public bool isCultureImplemented<type_of_project>(string resource_name, string culture_name) {
        return _isCultureImplemented<type_of_project>(resource_name, getCultureInfo(culture_name));
    }

    private bool _isCultureImplemented<type_of_project>(string resource_name, CultureInfo culture) {
        try {
            var resource_manager = new ResourceManager(resource_name, typeof(type_of_project).Assembly);
            var resourceSet = resource_manager.GetResourceSet(culture, true, false);
            if (resourceSet != null)
                // The culture is implemented in the .resx file.
                return true;
        }
        catch (MissingManifestResourceException ex) {
            Console.WriteLine($"Resource not found: {ex.Message}");
        }
        catch (Exception ex) {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }

        // The culture is not implemented in the .resx file.
        return false;
    }
}