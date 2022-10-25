namespace cSharpcars_tests;
using c_sharp_cars;
using Newtonsoft.Json.Linq;

public class Tests
{
    API _api;

    [SetUp]
    public void Setup()
    {
        _api = new API("<your_api_key>");
    }

    [Test]
    public async Task can_hit_api()
    {
        JObject carParks = await this._api.GetAllCarParks();
        Assert.That(carParks, Is.Not.Null);
    }
}
