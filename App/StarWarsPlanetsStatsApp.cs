using StarWarsPlanetStatus.DataAccess;
using StarWarsPlanetStatus.UserInteraction;

namespace StarWarsPlanetStatus.App;

public class StarWarsPlanetsStatsApp
{
    private readonly IPlanetsReader _planetsReader;
    private readonly IPlanetsStatisticsAnalyzer _planetsStatisticsAnalyzer;
    private readonly IPlanetStatsUserInteractor _planetStatsUserInteractor;

    public StarWarsPlanetsStatsApp(IPlanetsReader planetsReader, 
        IPlanetsStatisticsAnalyzer planetsStatisticsAnalyzer, 
        IPlanetStatsUserInteractor planetStatsUserInteractor)
    {
        _planetsReader = planetsReader;
        _planetsStatisticsAnalyzer = planetsStatisticsAnalyzer;
        _planetStatsUserInteractor = planetStatsUserInteractor;
    }

    public async Task Run()
    {
        var planets = await _planetsReader.Read();

        _planetStatsUserInteractor.Show(planets);

        _planetsStatisticsAnalyzer.Analyze(planets);
    }
}