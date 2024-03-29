using StarWarsPlanetsStats.ApiDataAccess;
using StarWarsPlanetStatus.App;
using StarWarsPlanetStatus.DataAccess;
using StarWarsPlanetStatus.UserInteraction;

try
{
    var consoleUserInteractor = new ConsoleUserInteractor();
    var planetsStatsUserInteractor = new PlanetsStatsUserInteractor(consoleUserInteractor);
    await new StarWarsPlanetsStatsApp(
            new PlanetsFromApiReader(
                new ApiDataReader(),
                new MockStarWarsApiDataReader()),
            new PlanetStatisticsAnalyzer(planetsStatsUserInteractor), planetsStatsUserInteractor)
        .Run();
}
catch (Exception exception)
{
    Console.WriteLine($"An error occurred. Exception message: {exception.Message}");
}

Console.ReadKey();
Console.WriteLine("Bye bye, earthling!");