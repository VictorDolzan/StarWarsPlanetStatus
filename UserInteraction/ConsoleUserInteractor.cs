namespace StarWarsPlanetStatus.UserInteraction;

public class ConsoleUserInteractor : IUserInteractor
{
    public string? ReadFromUser()
    {
        return Console.ReadLine();
    }
    
    public void ShowMessage(string message)
    {
        Console.WriteLine(message);
    }
}