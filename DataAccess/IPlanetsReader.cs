using StarWarsPlanetStatus.Model;

namespace StarWarsPlanetStatus.DataAccess;

public interface IPlanetsReader
{
    Task<IEnumerable<Planet>> Read();
}