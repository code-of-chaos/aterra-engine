// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------
using Xunit.Abstractions;
using AterraLL_Lib.SQL;

namespace AterraLL_Tests;

// ---------------------------------------------------------------------------------------------------------------------
// Code
// ---------------------------------------------------------------------------------------------------------------------
public class UnitTest_StringMatchSqlite {

    // -----------------------------------------------------------------------------------------------------------------
    // Constructor
    // -----------------------------------------------------------------------------------------------------------------
    private readonly ITestOutputHelper output;
    public UnitTest_StringMatchSqlite(ITestOutputHelper output) {
        this.output = output;
    }
    
    // -----------------------------------------------------------------------------------------------------------------
    // Tests
    // -----------------------------------------------------------------------------------------------------------------
    [Theory]
    [InlineData("", false)]
    [InlineData("Data Source=my.db", true)]
    [InlineData("Data Source=../data/my.db", true)]
    public void Test_isSqliteDbPath(string connectionString, bool is_pass) {
        Assert.Equal(is_pass, RegexSqlite.isSqliteDbPath(connectionString));
    }
    
    [Theory]
    [InlineData("", false)]
    [InlineData("data/my.db", true)]
    [InlineData("data\\my.db", true)]
    [InlineData("data/something/data.db", true)]
    public void Test_isFileInDataFolderPath(string connectionString, bool is_pass) {
        Assert.Equal(is_pass, RegexSqlite.isFileInDataFolderPath(connectionString));
    }
    
    [Theory]
    [InlineData("", false)]
    [InlineData("data/my.db", true)]
    [InlineData("data\\my.db", true)]
    [InlineData("data/something/data.db", false)]
    public void Test_isFileInDirectDataFolderPath(string connectionString, bool is_pass) {
        Assert.Equal(is_pass, RegexSqlite.isFileInDirectDataFolderPath(connectionString));
    }

    
    
}