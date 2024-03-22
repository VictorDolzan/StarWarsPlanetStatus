using System.Text.Json;
using StarWarsPlanetsStats.ApiDataAccess;
using StarWarsPlanetStatus.DTOs;

try
{
    await new StarWarsPlanetsStatsApp(
        new ApiDataReader(), 
        new MockStarWarsApiDataReader())
        .Run();
}
catch (Exception exception)
{
    Console.WriteLine($"An error occurred. Exception message: {exception.Message}");
}

Console.ReadKey();
Console.WriteLine("Hello, World!");

public class StarWarsPlanetsStatsApp
{
    private readonly IApiDataReader _apiDataReader;
    private readonly IApiDataReader _secondaryApiDataReader;

    public StarWarsPlanetsStatsApp(IApiDataReader apiDataReader, IApiDataReader secondaryApiDataReader)
    {
        _apiDataReader = apiDataReader;
        _secondaryApiDataReader = secondaryApiDataReader;
    }

    public async Task Run()
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

        if (json is null)
        {
            json = await _secondaryApiDataReader.Read("https://swapi.dev/", "api/planets");
        }

        var root = JsonSerializer.Deserialize<Root>(json);
    }
}