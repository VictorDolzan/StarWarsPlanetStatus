using StarWarsPlanetStatus.Model;
using StarWarsPlanetStatus.UserInteraction;

namespace StarWarsPlanetStatus.App;

public class PlanetStatisticsAnalyzer : IPlanetsStatisticsAnalyzer
{
    private readonly IPlanetStatsUserInteractor _planetStatsUserInteractor;

    public PlanetStatisticsAnalyzer(IPlanetStatsUserInteractor planetStatsUserInteractor)
    {
        _planetStatsUserInteractor = planetStatsUserInteractor;
    }

    public void Analyze(IEnumerable<Planet> planets)
    {
        var propertyNamesToSelectorsMapping = new Dictionary<string, Func<Planet, int?>>
        {
            ["population"] = planet => planet.Population,
            ["diameter"] = planet => planet.Diameter,
            ["surface water"] = planet => planet.SurfaceWater
        };

        var userChoice = 
            _planetStatsUserInteractor.ChooseStatisticsToBeShown(propertyNamesToSelectorsMapping.Keys);

        if (userChoice is null || !propertyNamesToSelectorsMapping.ContainsKey(userChoice))
        {
            _planetStatsUserInteractor.ShowMessage("Invalid Choice!");
        }
        else
        {
            ShowStatistics(planets, userChoice, propertyNamesToSelectorsMapping[userChoice]);
        }
    }
    
    private void ShowStatistics(IEnumerable<Planet> planets, string propertyName, Func<Planet, int?> propertySelector)
    {
        ShowStatistics("Max", planets.MaxBy(propertySelector), propertySelector, propertyName);
        ShowStatistics("Min", planets.MinBy(propertySelector), propertySelector, propertyName);
    }

    private static void ShowStatistics(string descriptor, Planet selectedPlanet, Func<Planet, int?> propertySelector,
        string propertyName)
    {
        Console.WriteLine(
            $"{descriptor} {propertyName} is: {propertySelector(selectedPlanet)} (planet is: {selectedPlanet.Name})");
    }
}