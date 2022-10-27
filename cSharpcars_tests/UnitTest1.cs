namespace cSharpcars_tests;
using c_sharp_cars;
using Newtonsoft.Json.Linq;
using NUnit.Framework.Interfaces;

public class Tests
{
    API _api;

    [SetUp]
    public void Setup()
    {
        _api = new API("<API_Key>");
    }

    [Test]
    public async Task can_hit_api()
    {
        JObject carParks = await this._api.GetAllCarParks();
        Assert.That(carParks, Is.Not.Null);
    }

    [Test]
    public async Task can_get_top_10_carparks()
    {
        JObject carParks = await this._api.GetAllCarParks(10);
        Assert.That(carParks["value"]?.Count(), Is.EqualTo(10));
    }
}
