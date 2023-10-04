namespace Test_AterraUnleashedLib;

using AterraUnleashedLib;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Test1()
    {
        const int maxSize = 100;
        Inventory inventory = new Inventory(maxSize:maxSize);

        for (int i = 0; i < maxSize; i++)
        {
            inventory.AddItem("wood", 1);
        }
        
        // We've added 100 items, so we should have an equal amount of items, as the current max size.
        Assert.That(inventory.GetAllItemCount(), Is.EqualTo(inventory.GetItemCount("wood")));
    }

    [Test]
    public void Test2()
    {
        const int maxSize = 100;
        Inventory inventory = new Inventory(maxSize:maxSize);

        for (int i = 0; i < 100; i++)
        {
            inventory.AddItem("wood", 1);
        }
        
        // Can't add more than 100 items, so the output of AddItem should be false
        Assert.False(inventory.AddItem("extra", 1));
    }
}