using System.Text.Json;
using StarWarsPlanetsStats.ApiDataAccess;
using StarWarsPlanetStatus.DTOs;
using StarWarsPlanetStatus.Model;

namespace StarWarsPlanetStatus.DataAccess;

public class PlanetsFromApiReader : IPlanetsReader
{
    private readonly IApiDataReader _apiDataReader;
    private readonly IApiDataReader _secondaryApiDataReader;

    public PlanetsFromApiReader(IApiDataReader apiDataReader, IApiDataReader secondaryApiDataReader)
    {
        _apiDataReader = apiDataReader;
        _secondaryApiDataReader = secondaryApiDataReader;
    }

    public async Task<IEnumerable<Planet>> Read()
    {
        string? json = null;
        try
        {
            json = await _apiDataReader.Read("https://swapi.dev/", "api/planets");
        }
        catch (HttpRequestException ex)
        {
            Console.WriteLine($"API request was unseccessful. Switching to mock data. Exception message: {ex.Message}");
            throw;
        }

        json ??= await _secondaryApiDataReader.Read("https://swapi.dev/", "api/planets");

        var root = JsonSerializer.Deserialize<Root>(json);

        return ToPlanets(root);
    }

    private IEnumerable<Planet> ToPlanets(Root? root)
    {
        if (root is null)
        {
            throw new ArgumentNullException(nameof(root));
        }

        return root.results.Select(planetDto => (Planet) planetDto);
    }
}