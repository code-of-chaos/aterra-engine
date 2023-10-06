// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------
using AterraLL_Lib.SQL.Models;
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

      // ---------------------------------------------------------------------------------------------------------------
      private async Task _createTable(Type tableType) {
            await _conn.CreateTableAsync(tableType);
            await Console.Out.WriteLineAsync($"{tableType.Name} has been created");
      }
      
      public async Task createTables() {
            // List all tables which need to be created
            //    Don't put this as a property of the class, as we don't need to keep this in memory
            var tables = new List<Type>{
                  typeof(Models.Area),
                  typeof(Models.TileType),
                  typeof(Models.AreaTiles),
                  typeof(Models.POI)
            };
            
            // Assemble the tasks, and execute
            var asyncTasks = tables.Select(_createTable).ToArray();
            await Task.WhenAll(asyncTasks);
            
      }
      // ---------------------------------------------------------------------------------------------------------------
      private async Task _checkIfTablePresent(Type table) {
            var table_info = await _conn.GetTableInfoAsync(table.Name);
            if (table_info is null) {
                  throw new Exception($"{table.Name} could not be found");
            }
      }

      public async Task checkIfTablesPresent() {
            var tables = new List<Type> {
                  typeof(Models.Area),
                  typeof(Models.TileType),
                  typeof(Models.AreaTiles),
                  typeof(Models.POI),
            };

            var asyncTasks = tables.Select(_checkIfTablePresent).ToArray();
            await Task.WhenAll(asyncTasks);
      }
      
      // ---------------------------------------------------------------------------------------------------------------
      public async Task createTileType(string render_as) {
            var tileType = new TileType() {
                  RenderedString = render_as
            };

            await _conn.InsertAsync(tileType);
            await Console.Out.WriteLineAsync($"{tileType.Id} - rendered as : '{tileType.RenderedString}'");
            
      }
}