// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------
using AterraEngine.Interfaces.Structs;
using AterraEngine.Structs;

namespace AterraEngineUnitTests;
// ---------------------------------------------------------------------------------------------------------------------
// Code
// ---------------------------------------------------------------------------------------------------------------------
public class Tests_AterraEngineId :IClassFixture<EngineServicesTestFixture> {
    private readonly EngineServicesTestFixture _fixture;
    public Tests_AterraEngineId(EngineServicesTestFixture fixture) {
        _fixture = fixture;
    }
    
    [Theory]
    [InlineData("1000008", 1, 8)]
    [InlineData("123456", 0, 1_193_046)]
    [InlineData("A", 0, 10)]
    [InlineData("12300000F", 291, 15)]
    [InlineData("000000000", 0, 0)]
    [InlineData("FFFFFFFFF", 4095, 16_777_215)]
    public void Test_fromHex(string input_value, int plugin_id, int object_id) {
        var aterra_engine_id = AterraEngineId.fromHex(input_value);

        Assert.IsAssignableFrom<IAterraEngineId>(aterra_engine_id);
        Assert.Equal(plugin_id, aterra_engine_id.plugin_id);
        Assert.Equal(object_id, aterra_engine_id.object_id);
    }
    
    [Theory]
    [InlineData("G",typeof(FormatException))]
    [InlineData(null, typeof(NullReferenceException))]
    [InlineData("-1", typeof(FormatException))]
    [InlineData("FFFFFFFFFFFF", typeof(FormatException))]
    public void Test_fromHexFail(string input_value, Type exception) {
        Assert.Throws(exception, () => AterraEngineId.fromHex(input_value));
    }
    
    [Theory]
    [InlineData(1, 8, "001000008")]
    [InlineData(0, 1_193_046, "000123456")]
    [InlineData(0, 10, "00000000A")]
    [InlineData(291, 15, "12300000F")]
    [InlineData(0, 0, "000000000")]
    [InlineData(4095, 16_777_215, "FFFFFFFFF")]
    public void Test_asHex(int plugin_id, int object_id, string output_value) {
        var aterra_engine_id = new AterraEngineId {
            plugin_id = plugin_id,
            object_id = object_id
        };
        Assert.IsAssignableFrom<IAterraEngineId>(aterra_engine_id);
        Assert.Equal(output_value, aterra_engine_id.asHex);
    }
    
    [Theory]
    [InlineData(-1, 0, typeof(FormatException))]
    [InlineData(0, -1, typeof(FormatException))]
    [InlineData(0, 268_435_456, typeof(FormatException))]
    [InlineData(0, 16_777_216, typeof(FormatException))]
    [InlineData(4_096, 0, typeof(FormatException))]
    public void Test_asHexFail(int plugin_id, int object_id, Type exception) {
        Assert.Throws(exception, () => new AterraEngineId {
            plugin_id = plugin_id,
            object_id = object_id
        });
    }
}