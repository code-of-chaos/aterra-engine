// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------
using AterraLL_Lib.Items;
using AterraLL_Lib;
using Xunit.Abstractions;

namespace AterraLL_Tests;
// ---------------------------------------------------------------------------------------------------------------------
// Code
// ---------------------------------------------------------------------------------------------------------------------
public class UnitTest_Inventory {
    // -----------------------------------------------------------------------------------------------------------------
    // Constructor
    // -----------------------------------------------------------------------------------------------------------------
    private readonly ITestOutputHelper output;
    public UnitTest_Inventory(ITestOutputHelper output) {
        this.output = output;
    }
    
    // -----------------------------------------------------------------------------------------------------------------
    // Tests
    // -----------------------------------------------------------------------------------------------------------------
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
    
    // -----------------------------------------------------------------------------------------------------------------
    [Theory]
    [InlineData(1,"wood", "rock")]
    [InlineData(3,"rock", "wood", "twidi", "javascript")]
    public void TestInventory_AddItem_Fail(int maxSize, params string[] item_ids) {
        var inventory = new Inventory(maxSize);
        
        foreach (var item_id in item_ids[..^1]) {
            Assert.True(inventory.AddItem(new Item(item_id)));
        }

        Assert.False(inventory.AddItem(new Item(item_ids[^1])));
    }
    
    [Theory]
    [InlineData(2,"wood")]
    [InlineData(4,"rock", "wood", "twidi", "javascript")]
    public void TestInventory_AddItem_Pass(int maxSize, params string[] item_ids) {
        var inventory = new Inventory(maxSize);
        
        foreach (var item_id in item_ids) {
            Assert.True(inventory.AddItem(new Item(item_id)));
        }
    }
    
    // -----------------------------------------------------------------------------------------------------------------
    [Theory]
    [InlineData("wood", "rock")]
    [InlineData("rock", "wood")]
    public void TestInventory_RemoveItem_Fail(string itemid_to_remove ,params string[] item_ids) {
        var inventory = new Inventory(100);
        
        foreach (var item_id in item_ids) {
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
    
    // -----------------------------------------------------------------------------------------------------------------
    [Theory]
    [InlineData(1, "wood" )]
    [InlineData(3, "rock", "wood", "rock")]
    public void TestInventory_GetAllItemCount(int expected_result, params string[] item_ids) {
        var inventory = new Inventory(100);
        
        foreach (var item_id in item_ids) {
            Assert.True(inventory.AddItem(new Item(item_id)));
        }
        Assert.Equal(expected_result, inventory.GetAllItemCount());
    }
    
    // -----------------------------------------------------------------------------------------------------------------
    [Theory]
    [InlineData(1, "wood" , "wood", "rock", "test")]
    [InlineData(2, "rock", "wood", "rock", "rock", "test")]
    public void TestInventory_GetItemCount(int expected_result, string item_to_count, params string[] item_ids) {
        var inventory = new Inventory(100);
        
        foreach (var item_id in item_ids) {
            Assert.True(inventory.AddItem(new Item(item_id)));
        }
        Assert.Equal(expected_result, inventory.GetItemCount(item_to_count));
    }
    
}