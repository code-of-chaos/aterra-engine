namespace TestAterraUnleashed;
// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------
using AterraUnleashedLib.Items;
using AterraUnleashedLib;
using Xunit.Abstractions;

// ---------------------------------------------------------------------------------------------------------------------
// Code
// ---------------------------------------------------------------------------------------------------------------------
public class UnitTest1 {
    private readonly ITestOutputHelper output;

    public UnitTest1(ITestOutputHelper output) {
        this.output = output;
    }
    
    [Theory]
    [InlineData(1, "wood", "wood")]
    [InlineData(2, "wood", "wood", "rock")]
    public void TestInventory_MaxSize_Fail(int maxSize, params string[] item_ids) {
        var inventory = new Inventory(maxSize:maxSize);
        
        foreach (var item_id in item_ids[..^1]) {
            Assert.True(inventory.AddItem(new Item(item_id)));
        }
        
        Assert.False(inventory.AddItem(new Item(item_ids[^1])));
    }
    
    [Theory]
    [InlineData("wood", "rock")]
    [InlineData("rock", "wood")]
    public void TestInventory_RemoveItem_Fail(string itemid_to_remove ,params string[] item_ids) {
        var inventory = new Inventory(100);
        
        foreach (var item_id in item_ids[..^1]) {
            Assert.True(inventory.AddItem(new Item(item_id)));
        }

        var item = inventory.RemoveItem(itemid_to_remove); 
        Assert.Null(item);
    }
    
    [Theory]
    [InlineData("wood", "wood")]
    [InlineData("rock", "wood", "rock")]
    public void TestInventory_RemoveItem_Pass(string itemid ,params string[] item_ids) {
        var inventory = new Inventory(100);
        
        foreach (var item_id in item_ids) {
            Assert.True(inventory.AddItem(new Item(item_id)));
        }

        var item = inventory.RemoveItem(itemid);
        Assert.NotNull(item);
        Assert.True(item.item_id == itemid);
    }
}