
namespace SaveSystemLab.Models;

public class GameTime
{
    public string TimeOfDay { get; set; } = "Day";  // "Dawn", "Day", "Dusk", "Night"
    public int DayCount { get; set; } = 0;          // np. 1, 2, 3...
    public string Weather { get; set; } = "Clear";  // "Rain", "Snow", "Fog", "Storm"
}
