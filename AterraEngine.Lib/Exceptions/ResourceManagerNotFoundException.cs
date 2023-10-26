// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------
namespace AterraEngine.Lib.Exceptions;
// ---------------------------------------------------------------------------------------------------------------------
// Code
// ---------------------------------------------------------------------------------------------------------------------
public class ResourceManagerNotFoundException : Exception {
    public ResourceManagerNotFoundException() {}
    public ResourceManagerNotFoundException(string message):base(message) {}
    public ResourceManagerNotFoundException(string message, Exception inner_exception):base(message, inner_exception) { }
}