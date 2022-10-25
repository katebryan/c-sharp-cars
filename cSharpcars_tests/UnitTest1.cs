namespace cSharpcars_tests;
using cSharpcars;
using NUnit.Framework;

[TestFixture]
public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Test1()
    {
        Assert.Pass();
    }

    [Test]
    public void triggerAPI()
    {
        var result = new API().callAPI();
        Assert.That(result, Is.Not.Null);
    }
}
