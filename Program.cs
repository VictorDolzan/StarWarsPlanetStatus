using System.Text.Json;
using StarWarsPlanetsStats.ApiDataAccess;
using StarWarsPlanetStatus.DTOs;

var apiDataReader = new ApiDataReader();

var json = await apiDataReader.Read("https://swapi.dev/", "api/planets");

var root = JsonSerializer.Deserialize<Root>(json);

Console.ReadKey();
Console.WriteLine("Hello, World!");