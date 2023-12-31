﻿// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------
using System.Globalization;
using System.Resources;
using Serilog;

using AterraEngine.Interfaces.Engine;

namespace AterraEngine.Engine;
// ---------------------------------------------------------------------------------------------------------------------
// Code
// ---------------------------------------------------------------------------------------------------------------------
public class EngineCultureManager : IEngineCultureManager {
    private readonly Dictionary<string, CultureInfo> _cultureInfos = new();
    
    private readonly CultureInfo _default_culture = CultureInfo.CurrentCulture;
    private readonly CultureInfo _default_ui_culture=  CultureInfo.CurrentUICulture;
    
    protected ILogger _logger = EngineServices.getLogger();
    
    // -----------------------------------------------------------------------------------------------------------------
    // Constructor
    // -----------------------------------------------------------------------------------------------------------------
    
    // -----------------------------------------------------------------------------------------------------------------
    // Local Culture system
    // -----------------------------------------------------------------------------------------------------------------
    public void addCulture(string culture_name) {
        if (_cultureInfos.TryGetValue(culture_name, out _))
            throw new ArgumentException($"the local of '{culture_name}' is already defined");

        _cultureInfos.Add(culture_name, new CultureInfo(culture_name));
    }

    public void activateCulture(string culture_name) {
        var culture_info = getCultureInfo(culture_name);
        
        CultureInfo.CurrentCulture = culture_info;
        CultureInfo.CurrentUICulture = culture_info;
    }

    public void activateDefaultCulture() {
        CultureInfo.CurrentCulture = _default_culture;
        CultureInfo.CurrentUICulture = _default_ui_culture;
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
    /// 
    /// <param name="resource">
    ///     A resource file's name to check. Make sure to give the full path, example:
    ///     'LostLegion.data.engine.local.UniversalText'
    /// </param>
    public void checkResourceForCultures(ResourceManager resource) {
        var missing_locals = _cultureInfos.Values
            .Where(culture => !isCultureImplemented(resource, culture))
            .Select(culture => culture.Name)
            .ToList();

        if (missing_locals.Any())
            throw new CultureNotFoundException(
                $"Resource '{resource}' did not have the following Localization Cultures "
                + $"{string.Join(", ", missing_locals)}"
            );
    }
    public bool isCultureImplemented(ResourceManager resource, string culture_name) => _isCultureImplemented(resource, getCultureInfo(culture_name));
    public bool isCultureImplemented(ResourceManager resource, CultureInfo culture) => _isCultureImplemented(resource, culture);
    
    private static bool _isCultureImplemented(ResourceManager resource, CultureInfo culture) {
        try {
            var resourceSet = resource.GetResourceSet(culture, true, false);
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