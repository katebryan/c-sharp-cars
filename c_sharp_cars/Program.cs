/*
 
 schedule->onTick()  => data scraper => pushed to kafta streams/logs => 
 
 */

using c_sharp_cars;

string? apiKey;

if (args.Length < 1)
{
    Console.WriteLine("Please enter API key...");
    apiKey = Console.ReadLine();
}
else {
    apiKey = args[0];
}

if (apiKey == null) {
    Console.WriteLine("API key must be provided");
    Console.ReadLine();
    return 1;
}

Console.WriteLine("Using API key " + apiKey);

API api = new API(apiKey);
Console.WriteLine(await api.GetAllCarParks());

Console.ReadLine();

while (true)
{

}