// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------

using System.Xml.Serialization;

namespace AterraEngine.Lib;

// ---------------------------------------------------------------------------------------------------------------------
// Interface Code
// ---------------------------------------------------------------------------------------------------------------------
public interface IXmlHandler<T> {
    public void exportXml(T serializable, string file_path);
    public void exportXmlFolder(List<T> objects_to_export, string folder_path, Func<T, string> name_operation);

    public T importXml(string file_path);
    public T[] importXmlFolder(string folder_path);
}
// ---------------------------------------------------------------------------------------------------------------------
// Code
// ---------------------------------------------------------------------------------------------------------------------
public class XmlHandler<T> : IXmlHandler<T>{
    public void exportXml(T serializable, string file_path) {
        // can't make async, as there isn't an async serializer???
        XmlSerializer serializer = new XmlSerializer(typeof(T));
        using (var writer = new StreamWriter(file_path)) {
            serializer.Serialize(writer, serializable);
        }
    }

    public void exportXmlFolder(List<T> objects_to_export, string folder_path, Func<T, string> name_operation) {
        foreach (T item in objects_to_export) {
            exportXml(
                serializable: item,
                file_path: Path.Combine(folder_path, name_operation(item))
            );
        }
    }
    
    public T importXml(string file_path) {
        // can't make async, as there isn't an async serializer???
        XmlSerializer serializer = new XmlSerializer(typeof(T));
        using (var reader = new StreamReader(file_path)) {
            return (T)serializer.Deserialize(reader)!;
        }
    }

    public T[] importXmlFolder(string folder_path) {
        return Directory.GetFiles(folder_path, "*.xml")
            .Select(filepath => importXml(filepath))
            .ToArray();
        
    }
    
}