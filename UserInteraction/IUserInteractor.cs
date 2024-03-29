namespace StarWarsPlanetStatus.UserInteraction;

public interface IUserInteractor
{
    void ShowMessage(string message);
    string? ReadFromUser();
}