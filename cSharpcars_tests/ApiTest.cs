namespace cSharpcars_tests;

using System.Diagnostics;
using cSharpcars;
using NUnit.Framework;

[TestFixture]
public class Tests
{
    [SetUp]
    public void Setup()
    {
        Debug.WriteLine("SetUp Called");
    }

    [Test]
    public void Test1()
    {
        Assert.Pass();
    }

    [Test]
    public void GetCorrectResponseFromAPI()
    {
        var api = new API();
        var result = api.getApiResponse(api.getParking());

        //Console.WriteLine("in test--> " + result);
        Assert.That(result, Is.Not.Null);
    }
}
