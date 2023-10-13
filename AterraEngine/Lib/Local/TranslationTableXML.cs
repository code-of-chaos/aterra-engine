// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace AterraEngine.Lib.Local; 

// ---------------------------------------------------------------------------------------------------------------------
// Support Code
// ---------------------------------------------------------------------------------------------------------------------
[XmlRoot("translations")]
public class Translation
{
    [XmlElement("translation")]
    public List<TranslationItem> Items { get; set; } = null!;
}

public class TranslationItem
{
    [XmlAttribute("key")]
    public string Key { get; set; } = null!;

    [XmlText]
    public string Text { get; set; } = null!;
}

// ---------------------------------------------------------------------------------------------------------------------
// Code
// ---------------------------------------------------------------------------------------------------------------------
public class TranslationTableXML : ITranslationTable {
    public string xmlFolderPath { get; }
    private Translation _translation = null!;
    
    // ---
    // Constructor
    // ---
    public TranslationTableXML(string FolderPath) {
        xmlFolderPath = FolderPath;
    }
    
    // ---
    // Methods
    // ---
    public string getTranslation(string keyName) {
        var translationItem = _translation.Items.FirstOrDefault(item => item.Key == keyName);
        return (translationItem != null) ? translationItem.Text : $"!!! UNDEFINED {keyName}";
    }
    
    // ---
    public void defineTranslationTable(string ChosenCultureCode) => _defineTranslationTableXML(Path.Combine(xmlFolderPath, $"{ChosenCultureCode}.xml"));
    public void defineTranslationTable(CultureCode ChosenCultureCode) => _defineTranslationTableXML(Path.Combine(xmlFolderPath, $"{ChosenCultureCode.ToString()}.xml"));
    
    private void _defineTranslationTableXML(string filePath) {
        var serializer = new XmlSerializer(typeof(Translation));
        Translation translation;
        
        using (var fileStream = new FileStream(filePath, FileMode.Open)) {
            translation = (Translation)serializer.Deserialize(fileStream)!;
            if (translation is null) throw new NullReferenceException();
        }
        
        if (_tableHasDuplicateKeys(translation)) {
            throw new Exception("Duplicate keys are not allowed in the translation table.");
        }
        
        _translation = translation;
    }
    
    // ---
    public void saveTranslationTable(string ChosenCultureCode) => _saveTranslationTable(Path.Combine(xmlFolderPath, $"{ChosenCultureCode}.xml"));
    public void saveTranslationTable(CultureCode ChosenCultureCode) => _saveTranslationTable(Path.Combine(xmlFolderPath, $"{ChosenCultureCode.ToString()}.xml"));

    private void _saveTranslationTable(string filePath) {
        if (_tableHasDuplicateKeys(_translation)) {
            throw new Exception("Duplicate keys are not allowed in the translation table.");
        }
        
        var serializer = new XmlSerializer(typeof(Translation));

        using (var fileStream = new FileStream(filePath, FileMode.Create)) {
            serializer.Serialize(fileStream, _translation);
        }
    }
    
    
    // ---
    private static bool _tableHasDuplicateKeys(Translation translation) {
        // Uses a form of LINQ to go over all keys
        // This function is very useful in debug mode
        
        var duplicateKeys = translation.Items
            .GroupBy(item => item.Key)
            .Where(group => group.Count() > 1)
            .Select(group => group.Key)
            .ToList();

        // The check passes if there are duplicate keys
        return duplicateKeys.Count != 0;

    }

}