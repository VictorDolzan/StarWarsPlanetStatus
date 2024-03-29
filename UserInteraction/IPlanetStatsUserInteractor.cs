using StarWarsPlanetStatus.Model;

namespace StarWarsPlanetStatus.UserInteraction;

public interface IPlanetStatsUserInteractor
{
    void Show(IEnumerable<Planet> planets);
    string? ChooseStatisticsToBeShown(IEnumerable<string> propertiesThatCanBeChosen);
    void ShowMessage(string message);
}