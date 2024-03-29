using StarWarsPlanetStatus.Model;

namespace StarWarsPlanetStatus.UserInteraction;

public class PlanetsStatsUserInteractor : IPlanetStatsUserInteractor
{
    private readonly IUserInteractor _userInteractor;

    public PlanetsStatsUserInteractor(IUserInteractor userInteractor)
    {
        _userInteractor = userInteractor;
    }
    
    public string? ChooseStatisticsToBeShown(IEnumerable<string> propertiesThatCanBeChosen)
    {
        _userInteractor.ShowMessage(Environment.NewLine);
        _userInteractor.ShowMessage($"The statistics of which property would you like to see?");
        _userInteractor.ShowMessage(string.Join(Environment.NewLine, propertiesThatCanBeChosen));

        return _userInteractor.ReadFromUser();
    }

    public void Show(IEnumerable<Planet> planets)
    {
        foreach (var planet in planets)
        {
            Console.WriteLine(planet);
        }
    }

    public void ShowMessage(string message)
    {
        Console.WriteLine(message);
    }
}