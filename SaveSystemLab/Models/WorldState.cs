
namespace SaveSystemLab.Models;

public class WorldState
{
    public Dictionary<string, float> Reputation { get; set; } = new();
    public HashSet<int> KnownLocations { get; set; } = new();
    public List<int> CompletedQuests { get; set; } = new();
    public GameTime Time { get; set; } = new();
    public string Season { get; set; } = "Spring"; // "Spring", "Summer", "Autumn", "Winter"

}
