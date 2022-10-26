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
    public void GetCorrectResponseFromAPI()
    {
        var result = new API().getApiResponse();
        Console.WriteLine(result);
        Assert.That(result, Is.Not.Null);
    }
}
