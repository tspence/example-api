using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NumberBadger.Test;

[TestClass]
public class UnitTest1
{
    [TestMethod]
    public void TestEmptyGuidParsing()
    {
        // Try once with a prefix
        var originalData = Guid.Empty;
        var badge = Badger.CreateBadge(originalData, "My");
        Assert.AreEqual("My1111111111111111", badge);
        var result = Badger.ParseGuid(badge, "My");
        Assert.IsTrue(result.Success);
        Assert.AreEqual(result.Value, originalData);
        
        // Now same thing without a prefix
        badge = Badger.CreateBadge(originalData, null);
        Assert.AreEqual("1111111111111111", badge);
        result = Badger.ParseGuid(badge, null);
        Assert.IsTrue(result.Success);
        Assert.AreEqual(result.Value, originalData);
    }
    
    [TestMethod]
    public void TestGuidFailures()
    {
        // Try a bad prefix
        var badge = "Something that doesn't start with the correct prefix";
        var result = Badger.ParseGuid(badge, "My");
        Assert.IsFalse(result.Success);
        Assert.AreEqual("The ID 'Something that doesn't start with the correct prefix' does not begin with the correct prefix 'My'.", result.Message);
        
        // Try something with a good prefix but bad data
        badge = "My==========";
        result = Badger.ParseGuid(badge, "My");
        Assert.IsFalse(result.Success);
        Assert.AreEqual("The ID 'My==========' is not a valid identity code.", result.Message);
        
        // Try an incomplete code - I've deleted half the data
        badge = "My11111111";
        result = Badger.ParseGuid(badge, "My");
        Assert.IsFalse(result.Success);
        Assert.AreEqual("The ID 'My11111111' is incomplete. Did you forget a few characters?", result.Message);

    }
}