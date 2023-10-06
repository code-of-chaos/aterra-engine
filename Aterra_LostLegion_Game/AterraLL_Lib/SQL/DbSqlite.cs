// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------

using System.Diagnostics;
using SQLite;

namespace AterraLL_Lib.SQL;

// ---------------------------------------------------------------------------------------------------------------------
// Code
// ---------------------------------------------------------------------------------------------------------------------
public class DbSqlite {
      // Constructor and check for connection
      private readonly SQLiteAsyncConnection _conn;
      
      // Init
      public DbSqlite(string connectionString) {
            // Check arguments
            if (!RegexSqlite.isFileInDataFolderPath(connectionString)) {
                  throw new ArgumentException(
                        $"The connectionString did not adhere to the convention of 'Data Source=*****.db', " +
                        $"instead '{connectionString}' was given"
                  );
            }
            
            // Create the connection
            _conn = new SQLiteAsyncConnection(connectionString);
      }

      private async Task _createTable(Type tableType) {
            await _conn.CreateTableAsync(tableType);
            await Console.Out.WriteLineAsync($"{tableType.Name} has been created");
      }
      
      public async Task createTables() {
            // List all tables which need to be created
            var tables = new List<Type>{
                  typeof(Models.Area),
                  typeof(Models.TileType),
                  typeof(Models.AreaTiles),
                  typeof(Models.POI)
            };
            
            // Assemble the tasks, and execute
            var asyncTasks = tables.Select(table => _createTable(table)).ToArray();
            await Task.WhenAll(asyncTasks);
            
      }
}