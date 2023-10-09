// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------

namespace AterraLL_Lib.AreaMapFile;

// ---------------------------------------------------------------------------------------------------------------------
// Code
// ---------------------------------------------------------------------------------------------------------------------
public enum AreaMapFileFormat {
    AreaMap,
    POI,
    Tile,
}

public class AreaMapBinary {
    public List<List<int>>? areaMapData = null;
    public byte[] newLineBytes = new byte[] { 0x0A };

    public List<AreaMapFileFormat> area_map_file_formats = new() {
        AreaMapFileFormat.AreaMap,
        AreaMapFileFormat.POI,
        AreaMapFileFormat.Tile,
    };
    
    private List<List<int>> _read_map(BinaryReader reader)
    {
        // Read the number of rows and columns
        byte numRows = reader.ReadByte();
        byte numCols = reader.ReadByte();

        // Initialize the areaMapData list
        List<List<int>> loadedData = new List<List<int>>(numRows);
        for (int i = 0; i < numRows; i++)
        {
            loadedData.Add(new List<int>(numCols));
        }

        // Read and populate the map data
        for (int i = 0; i < numRows; i++)
        {
            for (int j = 0; j < numCols; j++)
            {
                // Read X coordinate, Y coordinate, and data
                byte data = reader.ReadByte();

                // Add the data to the loadedData list
                loadedData[i].Add(data);
            }

            // Read the newline byte
            reader.ReadBytes(newLineBytes.Length);
        }

        return loadedData;
    }
    
    public List<List<int>> read(string filePath) {
        using var reader = new BinaryReader(File.Open(filePath, FileMode.Open));
        var data = _read_map(reader);
        return data;
    }
    
    // -----------------------------------------------------------------------------------------------------------------
    private void _write_map(BinaryWriter writer) {
        if (areaMapData is null) {
            throw new NullReferenceException();
        }
        
        var numRows = areaMapData.Count;
        var numCols = areaMapData[0].Count;
        
        writer.Write((byte)numRows);
        writer.Write((byte)numCols);
        
        writer.Write(newLineBytes);

        // Write the world map data to the file
        for (int i = 0; i < numRows; i++)
        {
            for (int j = 0; j < numCols; j++)
            {
                writer.Write((byte)areaMapData[i][j]);
                writer.Write(newLineBytes);
            }
        }
        
    }
    
    public void write(string filePath, List<List<int>> areaMapData) {
        // Create a BinaryWriter to write the binary data to the file asynchronously
        
        this.areaMapData = areaMapData;
        
        using (BinaryWriter writer = new BinaryWriter(File.Open(filePath, FileMode.Create)))
        {
            // Write the dimensions to the file
            _write_map(writer: writer);
        }


        Console.WriteLine("World map data has been written to the binary file asynchronously.");

    }
}