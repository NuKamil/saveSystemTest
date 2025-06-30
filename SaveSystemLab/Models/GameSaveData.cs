

namespace SaveSystemLab.Models;

public class GameSaveData
{
    public PlayerData Player { get; set; } = new();
    public WorldState World { get; set; } = new();
    public string CheckpointName { get; set; } = string.Empty;
    public DateTime SaveTime { get; set; } = DateTime.UtcNow;
    public int SaveSlot { get; set; } = 0;
}
