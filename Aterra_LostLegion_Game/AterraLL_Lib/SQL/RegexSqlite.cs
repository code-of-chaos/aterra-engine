// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------
using System.Text.RegularExpressions;

namespace AterraLL_Lib.SQL;

// ---------------------------------------------------------------------------------------------------------------------
// Code
// ---------------------------------------------------------------------------------------------------------------------
public static class RegexSqlite {
    // Regex Patterns
    private static readonly Regex _RegexDbpath = new(@"^Data Source=(.*\.db)$");
    private static readonly Regex _DataFolderPath = new(@"^data[\\/].*\.db$");
    private static readonly Regex _DirectDataFolderPath = new(@"^data[\\/][^\\/.]*\.db$");
    
    // Check functions
    public static bool isSqliteDbPath(string text) {
        return _RegexDbpath.Match(text).Success;
    }

    public static bool isFileInDataFolderPath(string text) {
        return _DataFolderPath.Match(text).Success;
    }
    public static bool isFileInDirectDataFolderPath(string text) {
        return _DirectDataFolderPath.Match(text).Success;
    }
}