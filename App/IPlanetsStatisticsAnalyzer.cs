using StarWarsPlanetStatus.Model;

namespace StarWarsPlanetStatus.App;

public interface IPlanetsStatisticsAnalyzer
{
    void Analyze(IEnumerable<Planet> planets);
}